using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHPAY;
using FSDH.Application.FSDHPayQuery.GetBankQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHPayQueryHandler.BankQueryHandler
{
    public class GetBankQueryHandler : IRequestHandler<GetBanksQuery, List<GetBankResponse>>
    {
        private readonly IFSDHPay _fSDHPay;
        public GetBankQueryHandler(IFSDHPay fSDHPay)
        {
            _fSDHPay = fSDHPay;
        }

        public Task<List<GetBankResponse>> Handle(GetBanksQuery request, CancellationToken cancellationToken)
        {
            var data = new GetBankResources
            {
                apiversion = request.apiversion,
                name = request.name
            };
            return _fSDHPay.GetBank(request.name, request.apiversion);
        }
    }
}
