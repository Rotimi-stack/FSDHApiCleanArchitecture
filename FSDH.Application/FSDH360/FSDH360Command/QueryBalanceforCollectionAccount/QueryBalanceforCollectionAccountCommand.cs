using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Command.QueryBalanceforCollectionAccount
{
   public class QueryBalanceforCollectionAccountCommand : IRequest<List<QueryBalanceforCollectionAccountResponse>>
    {
        public string accountNumber { get; set; }
    }
}
