using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHPAY;
using FSDH.Application.FSDHPayQuery.FundstransferHistoryQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHPayQueryHandler.FundsTransferHistoryQueryHandler
{
    public class GetFundsTransferHistoryQueryHandler : IRequestHandler<GetFundsTransferHistoryQuery, GetFundsTransferHistoryResponse>
    {

        private readonly IFSDHPay _fSDHPay;
        public GetFundsTransferHistoryQueryHandler(IFSDHPay fSDHPay)
        {
            _fSDHPay = fSDHPay;
        }
        public async Task<GetFundsTransferHistoryResponse> Handle(GetFundsTransferHistoryQuery request, CancellationToken cancellationToken)
        {
            var data = new FundsTransferHistoryResources
            {
                apiversion = request.apiversion,
                EndDate = request.enddate,
                StartDate = request.startDate,
                PageNumber = request.pagenumber,
                PageSize = request.pagesize
            };
            return await _fSDHPay.GetFundsTransferHistory(request.apiversion, request.startDate, request.enddate, request.pagesize, request.pagenumber);
        }
    }
}
