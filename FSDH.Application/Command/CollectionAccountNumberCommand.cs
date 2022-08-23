using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Command
{
   public class CollectionAccountNumberCommand : IRequest<CollectionAccountBalanceDetails>
    {
        public string accountNumber { get; set; }
        public string apiversion { get; set; }
    }
}
