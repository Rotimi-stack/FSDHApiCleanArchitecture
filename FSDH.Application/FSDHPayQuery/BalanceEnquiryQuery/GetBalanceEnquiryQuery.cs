using FSDH.Application.Common.Models.FSDHPAY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace FSDH.Application.Query.FSDHPayQuery.BalanceEnquiryQuery
{
    public class GetBalanceEnquiryQuery : IRequest<GetBalanceEnquiryResponse>
    {
        public string apiversion { get; set; }
        public string AccountNumber { get; set; }
    }
}
