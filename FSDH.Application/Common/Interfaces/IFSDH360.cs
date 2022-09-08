using FSDH.Application.Common.Models.FSDH360;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSDH.Application.Common.Interfaces
{
   public interface IFSDH360
    {
        Task <List<GetAllAsignedDynamicAccount>> AsignedDynamicAccount(int take, int skip, string apiversion);
        Task <GetUnAssignedDynamicAccount> UnAssignedDynamicAccount(int take, int skip, string apiversion);
        Task<List<GetAllAsignedDynamicAcciountByCollectionAccount>> AssignedDynamicAccountByCollectionAccount(string AccountNumber, int skip, int take, string apiversion);
        Task<CollectionAccountBalanceDetails> CollectionDynamicAccountbalanceDetails(CollectionAccountBalanceResources res);
        Task<List<GetAllAsignedDynamicAccountBVN>> GetAllDynamicAssignedAccountByBVN(string BVN, int skip, int take, string apiversion);
        Task<GetADynamicAccount> GetADynamicAccount(string apiversion, string AccountNumber);
        Task<UnassignDynamicAccount> UnAssignDynamicAccount(string apiversion, string AccountNumber);
        Task<List<GetAllstaticAccount>> GetAllstaticAccount(int take, int skip, string apiversion);
        Task<GetAstaticAccount> GetAStaticAccount(string apiversion, string AccountNumber);
        Task<List<GetAllCollectionLinkedAccount>> GetAllCollectionLinkedAccount(int take, int skip, string apiversion, string AccountNumber);
        Task<List<GetAllStaticAccountLinkedtoBVN>> GetGetAllStaticAccountLinkedtoBVN(string apiversion, string BVN);
        Task<CreateDynamicVirtualAccountResponses> CreateDynamicVirtualAccount(CreateVirtualAccountResources var);
        Task<List<GetDynamicAccountTransactionHistory>> GetDynamicAccountTransactionHistory(GetDynamicAccountTransactionHistoryResources atr);
        Task<List<UpdateDynamicAccountResponse>> UpdateDynamicAccount(UpdateDynamicAccountResources adr);
        Task<CreateStaticVirtualAccountResponses> CreateStaticVirtualAccount(CreateStaticVirtualAccountResource var);
        Task<List<UpdateStaticVirtualAccountResponse>> UpdateStaticVirtualAccount(UpdateStaticVirtualAccountResources var);
        Task<QueryBalanceforCollectionAccountResponse> QueryBalanceforCollectionAccount(QueryBalanceforCollectionAccountResource car);
        Task<List<GetVirtualaccountTransactionHistoryResponse>> GetVirtualaccountTransactionHistory(GetVirtualaccountTransactionHistoryResource thr);
    }
}
