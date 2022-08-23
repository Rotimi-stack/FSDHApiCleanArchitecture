using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHPAY;
using FSDH.Application.Query.FSDHPayQuery.BalanceEnquiryQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHPayQueryHandler
{
    public class BalanceEnquiryQueryHandler : IRequestHandler<GetBalanceEnquiryQuery, GetBalanceEnquiryResponse>
    {
        private readonly IFSDHPay _fSDHPay;
        public BalanceEnquiryQueryHandler(IFSDHPay fSDHPay)
        {
            _fSDHPay = fSDHPay;
        }

        public Task<GetBalanceEnquiryResponse> Handle(GetBalanceEnquiryQuery request, CancellationToken cancellationToken)
        {
            var data = new BalanceEnquiryResources
            {
                AccountNumber = request.AccountNumber,
                apiversion = request.apiversion
            };
            return _fSDHPay.GetBalanceEnquiry(request.apiversion, request.AccountNumber);
        }
    }
}
