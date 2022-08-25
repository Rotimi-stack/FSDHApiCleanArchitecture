using FSDH.Application.Command.DynamicAccountTransactionHistory;
using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.CommandHandler.DynamicAccountTransactionHistory
{
    public class DynamicAccountTransactionHistoryCommandHandler : IRequestHandler<DynamicAccountTransactionHistoryCommand, GetDynamicAccountTransactionHistory>
    {

        private readonly IFSDH360 _fsdh360;
        public DynamicAccountTransactionHistoryCommandHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }
        public async Task<GetDynamicAccountTransactionHistory> Handle(DynamicAccountTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            var data = new GetDynamicAccountTransactionHistoryResources
            {
                accountNumber = request.accountNumber,
                endDate = request.endDate,
                skip = request.skip,
                startDate = request.startDate,
                take = request.take
            };
            return await _fsdh360.GetDynamicAccountTransactionHistory(data);
        }
    }
}
