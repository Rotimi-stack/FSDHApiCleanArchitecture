using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHPAY;
using FSDH.Application.FSDHPayQuery.FundsTransferQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHPayQueryHandler.FundsTransferQueryHandler
{
    public class GetFundsTransferQueryHandler : IRequestHandler<GetFundsTransferQuery, GetFundsTransferResponse>
    {

        private readonly IFSDHPay _fSDHPay;
        public GetFundsTransferQueryHandler(IFSDHPay fSDHPay)
        {
            _fSDHPay = fSDHPay;
        }
        public async Task<GetFundsTransferResponse> Handle(GetFundsTransferQuery request, CancellationToken cancellationToken)
        {
            var data = new FundsTransferResources
            {
                apiversion = request.apiversion,
                PaymentReference = request.PaymentReference,
                TransactionId = request.TransactionId
            };
            return await _fSDHPay.GetFundsTransfer(request.TransactionId, request.PaymentReference, request.apiversion);
        }
    }
}
