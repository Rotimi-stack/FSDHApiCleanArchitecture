using FSDH.Application.Command.GetVirtualaccountTransactionHistory;
using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.CommandHandler.GetVirtualAccountTransactionHistory
{
    public class GetVirtualAccountTransactionHistoryCommandHandler : IRequestHandler<GetVirtualaccountTransactionHistoryCommand, List<GetVirtualaccountTransactionHistoryResponse>>
    {
        private readonly IFSDH360 _fsdh360;
        public GetVirtualAccountTransactionHistoryCommandHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }
        public async Task<List<GetVirtualaccountTransactionHistoryResponse>> Handle(GetVirtualaccountTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            var data = new GetVirtualaccountTransactionHistoryResource
            {
                accountNumber = request.accountNumber,
                endDate = request.endDate,
                skip = request.skip,
                startDate = request.startDate,
                take = request.take
            };
            return await _fsdh360.GetVirtualaccountTransactionHistory(data);
        }
    }
}
