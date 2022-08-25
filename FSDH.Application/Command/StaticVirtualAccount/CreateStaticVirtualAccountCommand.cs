using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Command.StaticVirtualAccount
{
   public class CreateStaticVirtualAccountCommand : IRequest<CreateStaticVirtualAccountResponses>
    {
        public string accountName { get; set; }
        public string bvn { get; set; }
        public string collectionAccountNumber { get; set; }
        public string currencyCode { get; set; }
    }
}
