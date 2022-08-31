using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.ConfigurationOptionsSettings;
using FSDH.Application.Query.ADynamicAccountQuery;
using FSDH.Application.Query.AllCollectionLinkedAccountQuery;
using FSDH.Application.Query.AllDynamicAssignedAccountByBVN;
using FSDH.Application.Query.AllDynamicAssignedAccountByCollectionAccountQuery;
using FSDH.Application.Query.AllDynamicAssignedAccountQuery;
using FSDH.Application.Query.AllDynamicUnAssignedQuery;
using FSDH.Application.Query.AllStaticAccountLinkedtoBVNQuery;
using FSDH.Application.Query.AllStaticAccountQuery;
using FSDH.Application.Query.AStaticAccountQuery;
using FSDH.Application.Query.UnassignDynamicAccountQuery;
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

namespace FSDH.Infrastructure.ServiceIntegration.FSDH360
{
    public class FSDH360Service : IFSDH360
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly FSDH360Configurationsettings _fsdhsettings;
        private readonly ILogWritter _logger;

        private static Logger log = LogManager.GetCurrentClassLogger();

        public FSDH360Service(IHttpClientFactory httpClientFactory, IConfiguration config, FSDH360Configurationsettings fsdhsettings, ILogWritter logger)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient();
            _config = config;
            _fsdhsettings = fsdhsettings;


        }


        #region VirtualAccounts
        public async Task<List<GetAllAsignedDynamicAccount>> AsignedDynamicAccount(int skip, int take, string apiversion)
        {
            return await SendAsync<GetAllDynamicAssignedQuery, List<GetAllAsignedDynamicAccount>>(
                 new GetAllDynamicAssignedQuery(), $"/v1/virtualaccounts/dynamic/assigned?skip={skip}&take={take}&api-version={apiversion}", FSDH360HttpMethodType.Get);

        }

        public async Task<List<GetUnAssignedDynamicAccount>> UnAssignedDynamicAccount(int skip, int take, string apiversion)
        {
            return await SendAsync<GetAllDynamicUnAssignedAccountQuery, List<GetUnAssignedDynamicAccount>>(
                new GetAllDynamicUnAssignedAccountQuery(), $"/v1/virtualaccounts/dynamic/unassigned?skip={skip}&take={take}&api-version{apiversion}", FSDH360HttpMethodType.Get);
        }

        public async Task<List<GetAllAsignedDynamicAcciountByCollectionAccount>> AssignedDynamicAccountByCollectionAccount(string AccountNumber,int skip, int take, string apiversion)
        {
            return await SendAsync<GetAllDynamicAssignedAccountByCollectionAccountQuery, List<GetAllAsignedDynamicAcciountByCollectionAccount>>(
                new GetAllDynamicAssignedAccountByCollectionAccountQuery(), 
                
                $"/v1/virtualaccounts/dynamic/assigned/collectionaccount?AccountNumber={AccountNumber}&skip={skip}&take={take}&api-version={apiversion}", FSDH360HttpMethodType.Get);

        }

        public async Task<CollectionAccountBalanceDetails> CollectionAccountbalanceDetails(CollectionAccountBalanceResources res)
        {
            var data = new CollectionAccountBalanceRequest
            {
                accountNumber = res.accountNumber

            };
            return await SendAsync<CollectionAccountBalanceRequest, CollectionAccountBalanceDetails>(
                data, $"/v1/virtualaccounts/dynamic/collectionaccount/balance?api-version=1", FSDH360HttpMethodType.Post);

        }

        public async Task<List<GetAllAsignedDynamicAccountBVN>> GetAllDynamicAssignedAccountByBVN(string BVN, int skip, int take,  string apiversion)
        {
            return await SendAsync<GetAllDynamicAssignedAccountByBVNQuery, List<GetAllAsignedDynamicAccountBVN>>(
                new GetAllDynamicAssignedAccountByBVNQuery(), $"/v1/virtualaccounts/dynamic/assigned/bvn?BVN={BVN}&skip={skip}&take={take}&api-version{apiversion}", FSDH360HttpMethodType.Get);
        }

        public async Task<List<GetADynamicAccount>> GetADynamicAccount(string apiversion, string AccountNumber)
        {
            return await SendAsync<GetADynamicAccountQuery, List<GetADynamicAccount>>(
                new GetADynamicAccountQuery(), $"v1/virtualaccounts/dynamic/account?{AccountNumber}&{apiversion}", FSDH360HttpMethodType.Get
                );
        }
        public async Task<List<UnassignDynamicAccount>> UnAssignDynamicAccount(string apiversion, string AccountNumber)
        {
            return await SendAsync<UnassignADynamicAccountQuery, List<UnassignDynamicAccount>>(
                new UnassignADynamicAccountQuery(), $"/v1/virtualaccounts/dynamic?{AccountNumber}&{apiversion}", FSDH360HttpMethodType.Delete
                );
        }

        public async Task<CreateDynamicVirtualAccountResponses> CreateDynamicVirtualAccount(CreateVirtualAccountResources var)
        {
            var data = new CreateVirtualAccountRequest
            {
               
                accountName = var.accountName,
                bvn = var.bvn,
                collectionAccountNumber = var.collectionAccountNumber,
                currencyCode = var.currencyCode,
                expectedAmount = var.expectedAmount,
                isOneTimePaymentAccount = var.isOneTimePaymentAccount,
                uniqueReference = var.uniqueReference,
                validFor = var.validFor
            };
            return await SendAsync<CreateVirtualAccountRequest, CreateDynamicVirtualAccountResponses>(
                data, $"/v1/virtualaccounts/dynamic?api-version=1", FSDH360HttpMethodType.Post);
        }

        public async Task<List<GetDynamicAccountTransactionHistory>> GetDynamicAccountTransactionHistory(GetDynamicAccountTransactionHistoryResources atr)
        {
            var data = new GetDynamicAccountTransactionHistoryRequest
            {
                
                accountNumber = atr.accountNumber,
                startDate = atr.startDate,
                endDate = atr.endDate,
                skip = atr.skip,
                take = atr.take

            };
            return await SendAsync<GetDynamicAccountTransactionHistoryRequest, List<GetDynamicAccountTransactionHistory>>(
                data, $"/v1/virtualaccounts/dynamic/history?api-version=1", FSDH360HttpMethodType.Post
                );
        }
        public async Task<List<UpdateDynamicAccountResponse>> UpdateDynamicAccount(UpdateDynamicAccountResources adr)
        {
            var data = new UpdateDynamicAccountRequest
            {
                accountName = adr.accountName,
                accountNumber = adr.accountNumber,
                bvn = adr.bvn,
                collectionAccountNumber = adr.collectionAccountNumber,
                expectedAmount = adr.expectedAmount,
                uniqueReference = adr.uniqueReference,
                validFor = adr.validFor,
                validTill = adr.validTill

            };
            return await SendAsync<UpdateDynamicAccountRequest, List<UpdateDynamicAccountResponse>>(
                data, $"/v1/virtualaccounts/dynamic?api-version=1", FSDH360HttpMethodType.Put
                );

        }



        #endregion

        #region StaticAccount


        public async Task<List<GetAllstaticAccount>> GetAllstaticAccount(int take, int skip, string apiversion)
        {
            return await SendAsync<GetAllStaticAccountQuery, List<GetAllstaticAccount>>(
                 new GetAllStaticAccountQuery(), $"/v1/virtualaccounts/static?{skip}&{take}&{apiversion}", FSDH360HttpMethodType.Get);
        }

        public async  Task<GetAstaticAccount> GetAStaticAccount(string apiversion, string AccountNumber)
        {
            return await SendAsync<GetAStaticAccountQuery, GetAstaticAccount>(
                 new GetAStaticAccountQuery(), $"/v1/virtualaccounts/static/account?AccountNumber={AccountNumber}&{apiversion}", FSDH360HttpMethodType.Get);
        }

        public async Task<List<GetAllCollectionLinkedAccount>> GetAllCollectionLinkedAccount(int take, int skip, string apiversion, string AccountNumber)
        {
            return await SendAsync<GetAllCollectionLinkedAccountQuery, List<GetAllCollectionLinkedAccount>>(
                new GetAllCollectionLinkedAccountQuery(), $"/v1/virtualaccounts/static/collectionaccount?AccountNumber={AccountNumber}&{skip}&{take}&{apiversion}", FSDH360HttpMethodType.Get
                );
        }

        public async Task<List<GetAllStaticAccountLinkedtoBVN>> GetGetAllStaticAccountLinkedtoBVN(string BVN, string apiversion)
        {
            return await SendAsync<GetAllStaticAccountLinkedtoBVNQuery, List<GetAllStaticAccountLinkedtoBVN>>(
                new GetAllStaticAccountLinkedtoBVNQuery(), $"/v1/virtualaccounts/static/bvn?BVN={BVN}&api-version={apiversion}", FSDH360HttpMethodType.Get);
        }

        public async Task<CreateStaticVirtualAccountResponses> CreateStaticVirtualAccount(CreateStaticVirtualAccountResource var)
        {
            var data = new CreateStaticVirtualAccountRequest
            {
                currencyCode = var.currencyCode,
                collectionAccountNumber = var.collectionAccountNumber,
                bvn = var.bvn,
                accountName = var.accountName
            };
            return await SendAsync<CreateStaticVirtualAccountRequest, CreateStaticVirtualAccountResponses>(
                data, $"/v1/virtualaccounts/static?api-version=1", FSDH360HttpMethodType.Post
                );
        }

        public async Task<List<UpdateStaticVirtualAccountResponse>> UpdateStaticVirtualAccount(UpdateStaticVirtualAccountResources var)
        {
            var data = new UpdateStaticVirtualAccountRequest
            {
                virtualAccountNumber = var.virtualAccountNumber,
                collectionAccountNumber = var.collectionAccountNumber,
                bvn = var.bvn,
                accountName = var.accountName
            };
            return await SendAsync<UpdateStaticVirtualAccountRequest, List<UpdateStaticVirtualAccountResponse>>(
                data, $"/v1/virtualaccounts/static?api-version=1", FSDH360HttpMethodType.Put
                );
        }

        public async Task<List<QueryBalanceforCollectionAccountResponse>> QueryBalanceforCollectionAccount(QueryBalanceforCollectionAccountResource car)
        {
            var data = new QueryBalanceforCollectionAccountRequest
            {
                accountNumber = car.accountNumber
            };
            return await SendAsync<QueryBalanceforCollectionAccountRequest, List<QueryBalanceforCollectionAccountResponse>>(
                data, $"/v1/virtualaccounts/static/collectionaccount/balance?api-version=1", FSDH360HttpMethodType.Post);
        }


        public async Task<List<GetVirtualaccountTransactionHistoryResponse>> GetVirtualaccountTransactionHistory(GetVirtualaccountTransactionHistoryResource thr)
        {
            var data = new GetVirtualaccountTransactionHistoryRequest
            {
                take = thr.take,
                accountNumber = thr.accountNumber,
                endDate = thr.endDate,
                skip = thr.skip,
                startDate = thr.startDate
            };
            return await SendAsync<GetVirtualaccountTransactionHistoryRequest, List<GetVirtualaccountTransactionHistoryResponse>>(
                data, $"/v1/virtualaccounts/static/history?api-version=1", FSDH360HttpMethodType.Post
                );
        }
        #endregion











        public async Task<U> SendAsync<T, U>(T payload, string relativePath, FSDH360HttpMethodType httpMethod)
        {
            var baseaddress = _config.GetSection("BaseAddress").Value.ToString();
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
                    return JsonSerializer.Deserialize<U>(content);


                case FSDH360HttpMethodType.Delete:
                    var resssp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await resssp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (resssp.StatusCode == HttpStatusCode.BadGateway || (resssp.StatusCode == HttpStatusCode.Unauthorized) || resssp.StatusCode == HttpStatusCode.BadRequest || resssp.StatusCode == HttpStatusCode.ServiceUnavailable || resssp.StatusCode == HttpStatusCode.InternalServerError || resssp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return JsonSerializer.Deserialize<U>(content);

                    }
                    return JsonSerializer.Deserialize<U>(content);


                case FSDH360HttpMethodType.Put:
                    var reesp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await reesp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (reesp.StatusCode == HttpStatusCode.BadGateway || (reesp.StatusCode == HttpStatusCode.Unauthorized) || reesp.StatusCode == HttpStatusCode.BadRequest || reesp.StatusCode == HttpStatusCode.ServiceUnavailable || reesp.StatusCode == HttpStatusCode.InternalServerError || reesp.StatusCode == HttpStatusCode.NotFound)
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

                    return JsonSerializer.Deserialize<U>(content);     


            }

        }

       
    }
}




