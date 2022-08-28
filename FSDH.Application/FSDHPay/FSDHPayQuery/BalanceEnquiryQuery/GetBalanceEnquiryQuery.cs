using FSDH.Application.Common.Models.FSDHPAY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace FSDH.Application.Query.FSDHPayQuery.BalanceEnquiryQuery
{
    public class GetBalanceEnquiryQuery : IRequest<List<GetBalanceEnquiryResponse>>
    {
        public string AccountNumber { get; set; }
        public string apiversion { get; set; }
        
    }
}
