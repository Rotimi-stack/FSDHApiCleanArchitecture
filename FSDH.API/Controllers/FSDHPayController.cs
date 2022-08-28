using FSDH.Application.Common.Models.FSDHPAY;
using FSDH.Application.FSDHPayCommand.FundsTransfer;
using FSDH.Application.FSDHPayCommand.NameEnquiry;
using FSDH.Application.FSDHPayCommand.NameEnquiryFSDH;
using FSDH.Application.FSDHPayQuery.FundstransferHistoryQuery;
using FSDH.Application.FSDHPayQuery.FundsTransferQuery;
using FSDH.Application.FSDHPayQuery.GetBankQuery;
using FSDH.Application.Query.FSDHPayQuery.BalanceEnquiryQuery;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSDH.API.Controllers
{
    public class FSDHPayController : BaseController
    {
        [HttpGet("api/balance/enquiry")]
        public async Task<ActionResult<List<GetBalanceEnquiryResponse>>> AsignedDynamicAccount([FromQuery][Required] string AccountNumber,[FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetBalanceEnquiryQuery { AccountNumber = AccountNumber, apiversion = apiversion });
        }

        [HttpGet("api/bank/enquiry")]
        public async Task<ActionResult<List<GetBankResponse>>> GetBank(string name, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetBanksQuery { apiversion = apiversion, name = name });
                 
        }

        [HttpGet("api/funds/transfer")]
        public async Task<ActionResult<List<GetFundsTransferResponse>>> GetFundsTransfer(string TransactionId, string PaymentReference, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetFundsTransferQuery { TransactionId = TransactionId, PaymentReference = PaymentReference, apiversion = apiversion });
                  
        }
        [HttpGet("api/funds/transfer/history")]
        public async Task<ActionResult<List<GetFundsTransferHistoryResponse>>> GetFundsTransferHistory(string StartDate, string EndDate, int PageNumber, int PageSize, string apiversion)
        {
            return await Mediator.Send(new GetFundsTransferHistoryQuery { startDate = StartDate, enddate = EndDate, pagenumber = PageNumber, pagesize = PageSize, apiversion = apiversion});
        
        }

        [HttpPost("api/funds/transfer")]
        public async Task<ActionResult<List<PostFundsTransferResponses>>> PostFundsTransfers([FromQuery(Name = "api-version")] string apiversion, PostFundstransferCommand ftr)
        {
            return await Mediator.Send(ftr);
        }

        [HttpPost("api/name/enquiry/nip")]
        public async Task<ActionResult<List<PostNameEnquiryResponse>>> PostNameEnquiryNIP([FromQuery(Name = "api-version")] string apiversion, PostNameEnquiryCommand ftr)
        {
            return await Mediator.Send(ftr);
        }

        [HttpPost("api/name/enquiry")]
        public async Task<ActionResult<List<PostNameEnquiryFSDHresponses>>> PostNameEnquiryFSDH([FromQuery][Required] string AccountNumber, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new PostNameEnquiryFSDHQuery { AccountNumber = AccountNumber, ApiVersion = apiversion});
        }

    }
}
