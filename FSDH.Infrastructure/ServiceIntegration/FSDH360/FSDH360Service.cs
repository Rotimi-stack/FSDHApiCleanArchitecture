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
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public FSDH360Service(IHttpClientFactory httpClientFactory, IConfiguration config, FSDH360Configurationsettings fsdhsettings)
        {
            _client = httpClientFactory.CreateClient();
            _config = config;
            _fsdhsettings = fsdhsettings;


        }


        #region VirtualAccounts
        public async Task<GetAllAsignedDynamicAccount> AsignedDynamicAccount(int take, int skip, string apiversion)
        {
            return await SendAsync<GetAllDynamicAssignedQuery, GetAllAsignedDynamicAccount>(
                 new GetAllDynamicAssignedQuery(), $"/v1/virtualaccounts/dynamic/assigned?skip={skip}&take={take}&api-version={apiversion}", FSDH360HttpMethodType.Get);

        }

        public async Task<GetUnAssignedDynamicAccount> UnAssignedDynamicAccount(int take, int skip, string apiversion)
        {
            return await SendAsync<GetAllDynamicUnAssignedAccountQuery, GetUnAssignedDynamicAccount>(
                new GetAllDynamicUnAssignedAccountQuery(), $"/v1/virtualaccounts/dynamic/unassigned?skip={skip}&take={take}&api-version{apiversion}", FSDH360HttpMethodType.Get);
        }

        public async Task<GetAllAsignedDynamicAcciountByCollectionAccount> AssignedDynamicAccountByCollectionAccount(int take, int skip, string apiversion, string AccountNumber)
        {
            return await SendAsync<GetAllDynamicAssignedAccountByCollectionAccountQuery, GetAllAsignedDynamicAcciountByCollectionAccount>(
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

        public async Task<GetAllAsignedDynamicAccountBVN> GetAllDynamicAssignedAccountByBVN(int take, int skip, string apiversion, string BVN)
        {
            return await SendAsync<GetAllDynamicAssignedAccountByBVNQuery, GetAllAsignedDynamicAccountBVN>(
                new GetAllDynamicAssignedAccountByBVNQuery(), $"/v1/virtualaccounts/dynamic/assigned/bvn?BVN={BVN}&skip={skip}&take={take}&api-version{apiversion}", FSDH360HttpMethodType.Get);
        }

        public async Task<GetADynamicAccount> GetADynamicAccount(string apiversion, string AccountNumber)
        {
            return await SendAsync<GetADynamicAccountQuery, GetADynamicAccount>(
                new GetADynamicAccountQuery(), $"v1/virtualaccounts/dynamic/account?{AccountNumber}&{apiversion}", FSDH360HttpMethodType.Get
                );
        }
        public async Task<UnassignDynamicAccount> UnAssignDynamicAccount(string apiversion, string AccountNumber)
        {
            return await SendAsync<UnassignADynamicAccountQuery, UnassignDynamicAccount>(
                new UnassignADynamicAccountQuery(), $"v1/virtualaccounts/dynamic?{AccountNumber}&{apiversion}", FSDH360HttpMethodType.Delete
                );
        }

        public async Task<CreateDynamicVirtualAccountResponses> CreateDynamicVirtualAccount(CreateVirtualAccountResources var)
        {
            var data = new CreateVirtualAccountRequest
            {
                validTill = var.validTill,
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

        public async Task<GetDynamicAccountTransactionHistory> GetDynamicAccountTransactionHistory(GetDynamicAccountTransactionHistoryResources atr)
        {
            var data = new GetDynamicAccountTransactionHistoryRequest
            {
                take = atr.take,
                accountNumber = atr.accountNumber,
                endDate = atr.endDate,
                skip = atr.skip,
                startDate = atr.startDate
            };
            return await SendAsync<GetDynamicAccountTransactionHistoryRequest, GetDynamicAccountTransactionHistory>(
                data, $"v1/virtualaccounts/dynamic/history?api-version=1", FSDH360HttpMethodType.Post
                );
        }
        public async Task<UpdateDynamicAccountResponse> UpdateDynamicAccount(UpdateDynamicAccountResources adr)
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
            return await SendAsync<UpdateDynamicAccountRequest, UpdateDynamicAccountResponse>(
                data, $"/v1/virtualaccounts/dynamic?api-version=1", FSDH360HttpMethodType.Put
                );

        }



        #endregion

        #region StaticAccount


        public async Task<GetAllstaticAccount> GetAllstaticAccount(int take, int skip, string apiversion)
        {
            return await SendAsync<GetAllStaticAccountQuery, GetAllstaticAccount>(
                 new GetAllStaticAccountQuery(), $"v1/virtualaccounts/static?{skip}&{take}&{apiversion}", FSDH360HttpMethodType.Get);
        }

        public async  Task<GetAstaticAccount> GetAStaticAccount(string apiversion, string AccountNumber)
        {
            return await SendAsync<GetAStaticAccountQuery, GetAstaticAccount>(
                 new GetAStaticAccountQuery(), $"v1/virtualaccounts/static/account?{AccountNumber}&{apiversion}", FSDH360HttpMethodType.Get);
        }

        public async Task<GetAllCollectionLinkedAccount> GetAllCollectionLinkedAccount(int take, int skip, string apiversion, string AccountNumber)
        {
            return await SendAsync<GetAllCollectionLinkedAccountQuery, GetAllCollectionLinkedAccount>(
                new GetAllCollectionLinkedAccountQuery(), $"v1/virtualaccounts/static/collectionaccount?{AccountNumber}&{skip}&{take}&{apiversion}", FSDH360HttpMethodType.Get
                );
        }

        public async Task<GetAllStaticAccountLinkedtoBVN> GetGetAllStaticAccountLinkedtoBVN(string apiversion, string BVN)
        {
            return await SendAsync<GetAllStaticAccountLinkedtoBVNQuery, GetAllStaticAccountLinkedtoBVN>(
                new GetAllStaticAccountLinkedtoBVNQuery(), $"v1/virtualaccounts/static/bvn?{BVN}&{apiversion}", FSDH360HttpMethodType.Get);
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

        public async Task<UpdateStaticVirtualAccountResponse> UpdateStaticVirtualAccount(UpdateStaticVirtualAccountResources var)
        {
            var data = new UpdateStaticVirtualAccountRequest
            {
                virtualAccountNumber = var.virtualAccountNumber,
                collectionAccountNumber = var.collectionAccountNumber,
                bvn = var.bvn,
                accountName = var.accountName
            };
            return await SendAsync<UpdateStaticVirtualAccountRequest, UpdateStaticVirtualAccountResponse>(
                data, $"/v1/virtualaccounts/static?api-version=1", FSDH360HttpMethodType.Put
                );
        }

        public async Task<QueryBalanceforCollectionAccountResponse> QueryBalanceforCollectionAccount(QueryBalanceforCollectionAccountResource car)
        {
            var data = new QueryBalanceforCollectionAccountRequest
            {
                accountNumber = car.accountNumber
            };
            return await SendAsync<QueryBalanceforCollectionAccountRequest, QueryBalanceforCollectionAccountResponse>(
                data, $"/v1/virtualaccounts/static/collectionaccount/balance?api-version=1", FSDH360HttpMethodType.Post);
        }


        public async Task<GetVirtualaccountTransactionHistoryResponse> GetVirtualaccountTransactionHistory(GetVirtualaccountTransactionHistoryResource thr)
        {
            var data = new GetVirtualaccountTransactionHistoryRequest
            {
                take = thr.take,
                accountNumber = thr.accountNumber,
                endDate = thr.endDate,
                skip = thr.skip,
                startDate = thr.startDate
            };
            return await SendAsync<GetVirtualaccountTransactionHistoryRequest, GetVirtualaccountTransactionHistoryResponse>(
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
                    return JsonSerializer.Deserialize<U>(content);

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










//$"/v1/virtualaccounts/dynamic/assigned/collectionaccount?{AccountNumber}&{skip}&{take}&{apiversion}