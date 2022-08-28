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
        [HttpGet("api/allassignedaccount")]
        public async Task<ActionResult<List<GetAllAsignedDynamicAccount>>> AsignedDynamicAccount([FromQuery] int skip, [FromQuery] int take, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllDynamicAssignedQuery { skip = skip, take = take,  apiversion = apiversion });
        }


        [HttpGet("api/allunassignedaccount")]
        public async Task<ActionResult<List<GetUnAssignedDynamicAccount>>> UnAssignedDynamicAccount([FromQuery] int skip, [FromQuery] int take, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllDynamicUnAssignedAccountQuery { skip = skip, take = take, apiversion = apiversion });
        }

        [HttpGet("api/alldynamic/assigned/account/bycollectionaccount")]
        public async Task<ActionResult<List<GetAllAsignedDynamicAcciountByCollectionAccount>>> AssignedDynamicAccountByCollectionAccount([FromQuery][Required] string AccountNumber, [FromQuery] int skip, [FromQuery] int take, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllDynamicAssignedAccountByCollectionAccountQuery {AccountNumber = AccountNumber, skip = skip, take = take, apiversion = apiversion });
        }

        [HttpPost("api/collection/account/balancequery")]
        public async Task<ActionResult<CollectionAccountBalanceDetails>> CollectionAccountbalanceDetails([FromQuery(Name = "api-version")] string apiversion, CollectionAccountBalanceCommand actCom)
        {
            return await Mediator.Send(actCom);
        }

        [HttpPost("api/create/dynamic/virtualaccount")]
        public async Task<ActionResult<CreateDynamicVirtualAccountResponses>> CreateDynamicVirtualAccount([FromQuery(Name = "api-version")] string apiversion, CreateVirtualAccountCommand actCom)
        {
            return await Mediator.Send(actCom);
        }

        [HttpPost("api/dynamic/account/transaction/history")]
        public async Task<ActionResult<List<GetDynamicAccountTransactionHistory>>> GetDynamicAccountTransactionHistory([FromQuery(Name = "api-version")] string apiversion, DynamicAccountTransactionHistoryCommand actCom)
        {
            return await Mediator.Send(actCom);
        }

        [HttpPut("api/update/dynamicaccount/fsdh360")]
        public async Task<ActionResult<List<UpdateDynamicAccountResponse>>> UpdateDynamicAccount([FromQuery(Name = "api-version")] string apiversion, UpdateDynamicAccountCommand actCom)
        {
            return await Mediator.Send(actCom);
        }


        [HttpGet("api/dynamic/assignedaccount/bybvn")]
        public async Task<ActionResult<List<GetAllAsignedDynamicAccountBVN>>> GetAllDynamicAssignedAccountByBVN([FromQuery][Required] string BVN,[FromQuery] int skip, [FromQuery] int take, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllDynamicAssignedAccountByBVNQuery { BVN = BVN, skip = skip, take = take,  apiversion = apiversion,  });
        }

        [HttpGet("api/adynamic/account")]
        public async Task<ActionResult<List<GetADynamicAccount>>> GetADynamicAccount([FromQuery(Name = "api-version")] string apiversion, string AccountNumber)
        {
            return await Mediator.Send(new GetADynamicAccountQuery { apiversion = apiversion, AccountNumber = AccountNumber });

        }

        [HttpDelete("api/unassigned/dynamic/account")]
        public async Task<ActionResult<List<UnassignDynamicAccount>>> UnAssignDynamicAccount([FromQuery(Name = "api-version")] string apiversion, string AccountNumber)
        {
            return await Mediator.Send(new UnassignADynamicAccountQuery { apiversion = apiversion, AccountNumber = AccountNumber });

        }
        #endregion


        #region StaticAccount

        [HttpGet("api/all/static/account")]
        public async Task<ActionResult<List<GetAllstaticAccount>>> GetAllstaticAccount(int take, int skip, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllStaticAccountQuery { take = take, skip = skip, apiversion = apiversion });

        }

        [HttpGet("api/astatic/account")]
        public async Task<ActionResult<GetAstaticAccount>> GetAStaticAccount([Required]string AccountNumber, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAStaticAccountQuery { apiversion = apiversion, AccountNumber = AccountNumber });
                 
        }

        [HttpGet("api/allcollection/linked/account")]
        public async Task<ActionResult<List<GetAllCollectionLinkedAccount>>> GetAllCollectionLinkedAccount([Required] string AccountNumber,int take, int skip, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllCollectionLinkedAccountQuery { apiversion = apiversion, AccountNumber = AccountNumber, take = take, skip = skip });
        }

        [HttpGet("api/allstatic/account/linkedtobvn")]
        public async Task<List<GetAllStaticAccountLinkedtoBVN>> GetGetAllStaticAccountLinkedtoBVN([Required] string BVN, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetAllStaticAccountLinkedtoBVNQuery{ apiversion = apiversion, BVN = BVN });
                
        }

        [HttpPost("api/create/static/virtualaccount")]
        public async Task<ActionResult<CreateStaticVirtualAccountResponses>> CreateStaticVirtualAccount([FromQuery(Name = "api-version")] string apiversion, CreateStaticVirtualAccountCommand var)
        {
            return await Mediator.Send(var);
           
        }

        [HttpPut("api/update/static/virtualaccount")]
        public async Task<ActionResult<List<UpdateStaticVirtualAccountResponse>>> UpdateStaticVirtualAccount([FromQuery(Name = "api-version")] string apiversion, UpdateStaticVirtualAccountCommand var)
        {
            return await Mediator.Send(var);

        }
        [HttpPost("api/query/balance/collectionaccount")]
        public async Task<List<QueryBalanceforCollectionAccountResponse>> QueryBalanceforCollectionAccount([FromQuery(Name = "api-version")] string apiversion, QueryBalanceforCollectionAccountCommand car)
        {
            return await Mediator.Send(car);
        }

        [HttpPost("api/get/virtual/transaction/history")]
        public async Task<List<GetVirtualaccountTransactionHistoryResponse>> GetVirtualaccountTransactionHistory([FromQuery(Name = "api-version")] string apiversion, GetVirtualaccountTransactionHistoryCommand thr)
        {
            return await Mediator.Send(thr);
        }
        #endregion
    }
  

}
