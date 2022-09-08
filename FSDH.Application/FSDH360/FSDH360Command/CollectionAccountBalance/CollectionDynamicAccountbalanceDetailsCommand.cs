using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Command.CollectionAccountBalance
{
    public class CollectionDynamicAccountbalanceDetailsCommand : IRequest<CollectionAccountBalanceDetails>
    {
        public string accountNumber { get; set; }

    }
}
