using FSDH.Application.Common.Models.FSDHPAY;
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
        [HttpGet("balanceenquiry-fsdhpay")]
        public async Task<ActionResult<GetBalanceEnquiryResponse>> AsignedDynamicAccount([FromQuery(Name = "api-version")] string apiversion, [FromQuery][Required]string AccountNumber)
        {
            return await Mediator.Send(new GetBalanceEnquiryQuery { AccountNumber = AccountNumber, apiversion = apiversion });
        }

        [HttpGet("bankenquiry-fsdhpay")]
        public async Task<GetBankResponse> GetBank([FromQuery(Name = "api-version")] string apiversion, string name)
        {
            return await Mediator.Send(new GetBanksQuery { apiversion = apiversion, name = name });
                 
        }


        [HttpGet("funds-transfer-fsdhpay")]
        public async Task<GetFundsTransferResponse> GetFundsTransfer(string TransactionId, string PaymentReference, [FromQuery(Name = "api-version")] string apiversion)
        {
            return await Mediator.Send(new GetFundsTransferQuery { TransactionId = TransactionId, PaymentReference = PaymentReference, apiversion = apiversion });
                  
        }
        [HttpGet("funds-transfer-history-fsdhpay")]
        public async Task<GetFundsTransferHistoryResponse> GetFundsTransferHistory(string apiversion, string StartDate, string EndDate, int PageSize, int PageNumber)
        {
            return await Mediator.Send(new GetFundsTransferHistoryQuery { apiversion = apiversion, startDate = StartDate, enddate = EndDate, pagenumber = PageNumber, pagesize = PageSize });
        
        }

    }
}
