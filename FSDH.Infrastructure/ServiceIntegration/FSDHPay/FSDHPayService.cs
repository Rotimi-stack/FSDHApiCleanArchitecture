using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHPAY;
using FSDH.Application.FSDHPayCommand.NameEnquiryFSDH;
using FSDH.Application.FSDHPayQuery.FundstransferHistoryQuery;
using FSDH.Application.FSDHPayQuery.FundsTransferQuery;
using FSDH.Application.FSDHPayQuery.GetBankQuery;
using FSDH.Application.Query.FSDHPayQuery.BalanceEnquiryQuery;
using FSDH.Domain.Enums.FSDH360;
using FSDH.Shared.LogService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FSDH.Infrastructure.ServiceIntegration.FSDHPay
{
    public class FSDHPayService : IFSDHPay
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly ILogWritter _logger;

        private static Logger log = LogManager.GetCurrentClassLogger();

        public FSDHPayService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _client = httpClientFactory.CreateClient();
            _config = config;
        }

        public async Task<List<GetBalanceEnquiryResponse>> GetBalanceEnquiry(string AccountNumber, string apiversion)
        {
            return await SendAsync<GetBalanceEnquiryQuery, List<GetBalanceEnquiryResponse>>(
                 new GetBalanceEnquiryQuery(), $"/BalanceEnquiry?AccountNumber={AccountNumber}&api-version{apiversion}", FSDH360HttpMethodType.Get);
        }

        public async Task<List<GetBankResponse>> GetBank(string name, string apiversion)
        {
            return await SendAsync<GetBanksQuery, List<GetBankResponse>>(
                new GetBanksQuery(), $"/Banks/NIP?name={name}&api-version{apiversion}", FSDH360HttpMethodType.Get
                );
        }

        public async Task<List<GetFundsTransferResponse>> GetFundsTransfer(string TransactionId, string PaymentReference, string apiversion)
        {
            return await SendAsync<GetFundsTransferQuery, List<GetFundsTransferResponse>>(
                new GetFundsTransferQuery(), $"/FundsTransfer/NIP?{TransactionId}&{PaymentReference}&{apiversion}", FSDH360HttpMethodType.Get
               );
        }

        public async Task<List<GetFundsTransferHistoryResponse>> GetFundsTransferHistory(string StartDate , string EndDate, int PageNumber, int PageSize, string apiversion)
        {
            return await SendAsync<GetFundsTransferHistoryQuery, List<GetFundsTransferHistoryResponse>>(
                new GetFundsTransferHistoryQuery(), $"/FundsTransfer/history?{StartDate}&{EndDate}&{PageNumber}&{PageSize}&{apiversion}", FSDH360HttpMethodType.Get);
        }

        public async Task<List<PostFundsTransferResponses>> PostFundsTransfers(PostFundsTransferResources ftr)
        {
            var data = new FundsTransferRequest
            {
                transactionAmount = ftr.transactionAmount,
                paymentReference = ftr.paymentReference,
                originatorBankVerificationNumber = ftr.originatorBankVerificationNumber,
                beneficiaryAccountName = ftr.beneficiaryAccountName,
                beneficiaryAccountNumber = ftr.beneficiaryAccountNumber,
                beneficiaryBankVerificationNumber = ftr.beneficiaryBankVerificationNumber,
                beneficiaryKYCLevel = ftr.beneficiaryKYCLevel,
                destinationInstitutionCode = ftr.destinationInstitutionCode,
                nameEnquiryRef = ftr.nameEnquiryRef,
                narration = ftr.narration,
                originatorAccountBranch = ftr.originatorAccountBranch,
                originatorAccountName = ftr.originatorAccountName,
                originatorAccountNumber = ftr.originatorAccountNumber

            };
            return await SendAsync<FundsTransferRequest, List<PostFundsTransferResponses>>(
                data, $"/FundsTransfer/NIP?api-version=1", FSDH360HttpMethodType.Post
                );
        }

        public async Task<List<PostNameEnquiryFSDHresponses>> PostNameEnquiryFSDH(string AccountNumber, string ApiVersion)
        {
            
            return await SendAsync<PostNameEnquiryFSDHQuery, List<PostNameEnquiryFSDHresponses>>(
                new PostNameEnquiryFSDHQuery(), $"/NameEnquiry/FSDH?AccountNumber={AccountNumber}&api-version=1", FSDH360HttpMethodType.Post
                );
        }

        public async Task<List<PostNameEnquiryResponse>> PostNameEnquiryNIP(PostNameEnquiryResources ner)
        {
            var data = new PostNameEnquiryRequest
            {
                destinationInstitutionCode = ner.destinationInstitutionCode,
                channelCode = ner.channelCode,
                accountNumber = ner.accountNumber
            };
            return await SendAsync<PostNameEnquiryRequest, List<PostNameEnquiryResponse>>(
                data, $"/NameEnquiry/NIP?api-version=1", FSDH360HttpMethodType.Post
                );
        }








        public async Task<U> SendAsync<T, U>(T payload, string relativePath, FSDH360HttpMethodType httpMethod)
        {
            var baseaddress = _config.GetSection("BaseAddressPayUrl").Value.ToString();
            var testkey = _config.GetSection("TestApiKey").Value.ToString();


            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {testkey}");

            var message = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            string content;
            switch (httpMethod)
            {
                case FSDH360HttpMethodType.Post:
                    var resp = await _client.PostAsync($"{baseaddress}{relativePath}", message);
                    content = await resp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (resp.StatusCode == HttpStatusCode.BadGateway || (resp.StatusCode == HttpStatusCode.Unauthorized) || resp.StatusCode == HttpStatusCode.BadRequest || resp.StatusCode == HttpStatusCode.ServiceUnavailable || resp.StatusCode == HttpStatusCode.InternalServerError || resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return JsonSerializer.Deserialize<U>(content);

                    }

                    return System.Text.Json.JsonSerializer.Deserialize<U>(content);

                case FSDH360HttpMethodType.Delete:
                    var resssp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await resssp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (resssp.StatusCode == HttpStatusCode.BadGateway || (resssp.StatusCode == HttpStatusCode.Unauthorized) || resssp.StatusCode == HttpStatusCode.BadRequest || resssp.StatusCode == HttpStatusCode.ServiceUnavailable || resssp.StatusCode == HttpStatusCode.InternalServerError || resssp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return JsonSerializer.Deserialize<U>(content);

                    }

                    return JsonConvert.DeserializeObject<U>(content);

                default:

                    var ressp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await ressp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (ressp.StatusCode == HttpStatusCode.BadGateway || (ressp.StatusCode == HttpStatusCode.Unauthorized) || ressp.StatusCode == HttpStatusCode.BadRequest || ressp.StatusCode == HttpStatusCode.ServiceUnavailable || ressp.StatusCode == HttpStatusCode.InternalServerError || ressp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return JsonSerializer.Deserialize<U>(content);

                    }

                    return JsonConvert.DeserializeObject<U>(content);





            }

        }
    }
}
