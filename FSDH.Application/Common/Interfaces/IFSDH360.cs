using FSDH.Application.Common.Models.FSDH360;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSDH.Application.Common.Interfaces
{
   public interface IFSDH360
    {
        Task <GetAllAsignedDynamicAccount> AsignedDynamicAccount(int take, int skip, string apiversion);
        Task <GetUnAssignedDynamicAccount> UnAssignedDynamicAccount(int take, int skip, string apiversion);
        Task<GetAllAsignedDynamicAcciountByCollectionAccount> AssignedDynamicAccountByCollectionAccount(int take, int skip, string apiversion, string AccountNumber);
        Task<CollectionAccountBalanceDetails> CollectionAccountbalanceDetails(CollectionAccountBalanceResources res);
        Task<GetAllAsignedDynamicAccountBVN> GetAllDynamicAssignedAccountByBVN(int take, int skip, string apiversion, string BVN);
        Task<GetADynamicAccount> GetADynamicAccount(string apiversion, string AccountNumber);
        Task<UnassignDynamicAccount> UnAssignDynamicAccount(string apiversion, string AccountNumber);
        Task<GetAllstaticAccount> GetAllstaticAccount(int take, int skip, string apiversion);
        Task<GetAstaticAccount> GetAStaticAccount(string apiversion, string AccountNumber);
        Task<GetAllCollectionLinkedAccount> GetAllCollectionLinkedAccount(int take, int skip, string apiversion, string AccountNumber);
        Task<GetAllStaticAccountLinkedtoBVN> GetGetAllStaticAccountLinkedtoBVN(string apiversion, string BVN);
        Task<CreateDynamicVirtualAccountResponses> CreateDynamicVirtualAccount(CreateVirtualAccountResources var);
        Task<GetDynamicAccountTransactionHistory> GetDynamicAccountTransactionHistory(GetDynamicAccountTransactionHistoryResources atr);
        Task<UpdateDynamicAccountResponse> UpdateDynamicAccount(UpdateDynamicAccountResources adr);
        Task<CreateStaticVirtualAccountResponses> CreateStaticVirtualAccount(CreateStaticVirtualAccountResource var);
        Task<UpdateStaticVirtualAccountResponse> UpdateStaticVirtualAccount(UpdateStaticVirtualAccountResources var);
        Task<QueryBalanceforCollectionAccountResponse> QueryBalanceforCollectionAccount(QueryBalanceforCollectionAccountResource car);
        Task<GetVirtualaccountTransactionHistoryResponse> GetVirtualaccountTransactionHistory(GetVirtualaccountTransactionHistoryResource thr);
    }
}
