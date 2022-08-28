using FSDH.Application.Command.CollectionAccountBalance;
using FSDH.Application.Command.CreateVirtualAccount;
using FSDH.Application.Command.DynamicAccountTransactionHistory;
using FSDH.Application.Command.GetVirtualaccountTransactionHistory;
using FSDH.Application.Command.QueryBalanceforCollectionAccount;
using FSDH.Application.Command.StaticVirtualAccount;
using FSDH.Application.Command.UpdateDynamicAccount;
using FSDH.Application.Command.UpdateStaticVirtualAccount;
using FSDH.Application.Common.Models.FSDH360;
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
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSDH.API.Controllers
{
    public class FSDH360Controller : BaseController
    {
        #region VirtualAccount
        [HttpGet("allassignedaccount-fsdh360")]
        public async Task<ActionResult<List<GetAllAsignedDynamicAccount>>> AsignedDynamicAccount([FromQuery] int skip, [FromQuery] int take, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllDynamicAssignedQuery { skip = skip, take = take,  apiversion = apiversion });
        }


        [HttpGet("allunassignedaccount-fsdh360")]
        public async Task<ActionResult<List<GetUnAssignedDynamicAccount>>> UnAssignedDynamicAccount([FromQuery] int skip, [FromQuery] int take, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllDynamicUnAssignedAccountQuery { skip = skip, take = take, apiversion = apiversion });
        }

        [HttpGet("all-dynamic-assigned-account-bycollectionaccount-fsdh360")]
        public async Task<ActionResult<List<GetAllAsignedDynamicAcciountByCollectionAccount>>> AssignedDynamicAccountByCollectionAccount([FromQuery][Required] string AccountNumber, [FromQuery] int skip, [FromQuery] int take, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllDynamicAssignedAccountByCollectionAccountQuery {AccountNumber = AccountNumber, skip = skip, take = take, apiversion = apiversion });
        }

        [HttpPost("collection-account-balance-query")]
        public async Task<ActionResult<CollectionAccountBalanceDetails>> CollectionAccountbalanceDetails([FromQuery(Name = "api-version")] string apiversion, CollectionAccountBalanceCommand actCom)
        {
            return await Mediator.Send(actCom);
        }

        [HttpPost("create-dynamic-virtual-account")]
        public async Task<ActionResult<CreateDynamicVirtualAccountResponses>> CreateDynamicVirtualAccount([FromQuery(Name = "api-version")] string apiversion, CreateVirtualAccountCommand actCom)
        {
            return await Mediator.Send(actCom);
        }

        [HttpPost("dynamic-account-transaction-history")]
        public async Task<ActionResult<List<GetDynamicAccountTransactionHistory>>> GetDynamicAccountTransactionHistory([FromQuery(Name = "api-version")] string apiversion, DynamicAccountTransactionHistoryCommand actCom)
        {
            return await Mediator.Send(actCom);
        }

        [HttpPut("update-dynamic-account")]
        public async Task<ActionResult<List<UpdateDynamicAccountResponse>>> UpdateDynamicAccount([FromQuery(Name = "api-version")] string apiversion, UpdateDynamicAccountCommand actCom)
        {
            return await Mediator.Send(actCom);
        }


        [HttpGet("dynamic-assigned-account-by-bvn")]
        public async Task<ActionResult<List<GetAllAsignedDynamicAccountBVN>>> GetAllDynamicAssignedAccountByBVN([FromQuery][Required] string BVN,[FromQuery] int skip, [FromQuery] int take, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllDynamicAssignedAccountByBVNQuery { BVN = BVN, skip = skip, take = take,  apiversion = apiversion,  });
        }

        [HttpGet("adynamic-account")]
        public async Task<ActionResult<List<GetADynamicAccount>>> GetADynamicAccount([FromQuery(Name = "api-version")] string apiversion, string AccountNumber)
        {
            return await Mediator.Send(new GetADynamicAccountQuery { apiversion = apiversion, AccountNumber = AccountNumber });

        }

        [HttpDelete("unassigned-dynamic-account")]
        public async Task<ActionResult<List<UnassignDynamicAccount>>> UnAssignDynamicAccount([FromQuery(Name = "api-version")] string apiversion, string AccountNumber)
        {
            return await Mediator.Send(new UnassignADynamicAccountQuery { apiversion = apiversion, AccountNumber = AccountNumber });

        }
        #endregion


        #region StaticAccount

        [HttpGet("all-static-account")]
        public async Task<ActionResult<List<GetAllstaticAccount>>> GetAllstaticAccount(int take, int skip, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllStaticAccountQuery { take = take, skip = skip, apiversion = apiversion });

        }

        [HttpGet("a-static-account")]
        public async Task<ActionResult<GetAstaticAccount>> GetAStaticAccount([Required]string AccountNumber, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAStaticAccountQuery { apiversion = apiversion, AccountNumber = AccountNumber });
                 
        }

        [HttpGet("all-collection-linked-account")]
        public async Task<ActionResult<List<GetAllCollectionLinkedAccount>>> GetAllCollectionLinkedAccount([Required] string AccountNumber,int take, int skip, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllCollectionLinkedAccountQuery { apiversion = apiversion, AccountNumber = AccountNumber, take = take, skip = skip });
        }

        [HttpGet("all-static-account-linkedtobvn")]
        public async Task<List<GetAllStaticAccountLinkedtoBVN>> GetGetAllStaticAccountLinkedtoBVN([Required] string BVN, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllStaticAccountLinkedtoBVNQuery{ apiversion = apiversion, BVN = BVN });
                
        }

        [HttpPost("create-static-virtualaccount")]
        public async Task<ActionResult<CreateStaticVirtualAccountResponses>> CreateStaticVirtualAccount([FromQuery(Name = "api-version")] string apiversion, CreateStaticVirtualAccountCommand var)
        {
            return await Mediator.Send(var);
           
        }

        [HttpPut("update-static-virtualaccount")]
        public async Task<ActionResult<List<UpdateStaticVirtualAccountResponse>>> UpdateStaticVirtualAccount([FromQuery(Name = "api-version")] string apiversion, UpdateStaticVirtualAccountCommand var)
        {
            return await Mediator.Send(var);

        }
        [HttpPost("query-balance-collectionaccount")]
        public async Task<List<QueryBalanceforCollectionAccountResponse>> QueryBalanceforCollectionAccount([FromQuery(Name = "api-version")] string apiversion, QueryBalanceforCollectionAccountCommand car)
        {
            return await Mediator.Send(car);
        }

        [HttpPost("get-virtualtransaction-history")]
        public async Task<List<GetVirtualaccountTransactionHistoryResponse>> GetVirtualaccountTransactionHistory([FromQuery(Name = "api-version")] string apiversion, GetVirtualaccountTransactionHistoryCommand thr)
        {
            return await Mediator.Send(thr);
        }
        #endregion
    }
  

}
