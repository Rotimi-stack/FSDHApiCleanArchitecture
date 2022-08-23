using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHPAY;
using FSDH.Application.FSDHPayQuery.FundstransferHistoryQuery;
using FSDH.Application.FSDHPayQuery.FundsTransferQuery;
using FSDH.Application.FSDHPayQuery.GetBankQuery;
using FSDH.Application.Query.FSDHPayQuery.BalanceEnquiryQuery;
using FSDH.Domain.Enums.FSDH360;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FSDH.Infrastructure.ServiceIntegration.FSDHPay
{
    public class FSDHPayService : IFSDHPay
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public FSDHPayService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _client = httpClientFactory.CreateClient();
            _config = config;
        }

        public async Task<GetBalanceEnquiryResponse> GetBalanceEnquiry(string apiversion, string AccountNumber)
        {
            return await SendAsync<GetBalanceEnquiryQuery, GetBalanceEnquiryResponse>(
                 new GetBalanceEnquiryQuery(), $"/BalanceEnquiry?AccountNumber={AccountNumber}&api-version{apiversion}", FSDH360HttpMethodType.Get);
        }

        public async Task<GetBankResponse> GetBank(string apiversion, string name)
        {
            return await SendAsync<GetBanksQuery, GetBankResponse>(
                new GetBanksQuery(), $"/Banks/NIP?name={name}&api-version{apiversion}", FSDH360HttpMethodType.Get
                );
        }

        public async Task<GetFundsTransferResponse> GetFundsTransfer(string TransactionId, string PaymentReference, string apiversion)
        {
            return await SendAsync<GetFundsTransferQuery, GetFundsTransferResponse>(
                new GetFundsTransferQuery(), $"/FundsTransfer/NIP?{TransactionId}&{PaymentReference}&{apiversion}", FSDH360HttpMethodType.Get
               );
        }

        public async Task<GetFundsTransferHistoryResponse> GetFundsTransferHistory(string apiversion, string StartDate, string EndDate, int PageSize, int PageNumber)
        {
            return await SendAsync<GetFundsTransferHistoryQuery, GetFundsTransferHistoryResponse>(
                new GetFundsTransferHistoryQuery(), $"/FundsTransfer/history?{StartDate}&{EndDate}&{PageNumber}&{PageSize}&{apiversion}", FSDH360HttpMethodType.Get);
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
                    return System.Text.Json.JsonSerializer.Deserialize<U>(content);

                case FSDH360HttpMethodType.Delete:
                    var resssp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await resssp.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<U>(content);

                default:

                    var ressp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await ressp.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<U>(content);





            }

        }
    }
}
