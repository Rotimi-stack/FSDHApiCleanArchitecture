using FSDH.Application.Common.Models.FSDHPAY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHPayQuery.FundstransferHistoryQuery
{
   public class GetFundsTransferHistoryQuery : IRequest<GetFundsTransferHistoryResponse>
    {
        
        public string startDate { get; set; }
        public string enddate { get; set; }
        public int pagenumber { get; set; }
        public int pagesize { get; set; }
        public string apiversion { get; set; }
    }
}
