using FSDH.Application.Command.QueryBalanceforCollectionAccount;
using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.CommandHandler.QueryBalanceforCollectionAccount
{
    public class QueryBalanceforCollectionAccountCommandHandler : IRequestHandler<QueryBalanceforCollectionAccountCommand, QueryBalanceforCollectionAccountResponse>
    {
        private readonly IFSDH360 _fsdh360;
        public QueryBalanceforCollectionAccountCommandHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }
        public async Task<QueryBalanceforCollectionAccountResponse> Handle(QueryBalanceforCollectionAccountCommand request, CancellationToken cancellationToken)
        {
            var data = new QueryBalanceforCollectionAccountResource
            {
                accountNumber = request.accountNumber,

            };
            return await _fsdh360.QueryBalanceforCollectionAccount(data);
        }
    }
}
