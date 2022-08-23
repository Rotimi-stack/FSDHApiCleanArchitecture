using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Query.AStaticAccountQuery
{
   public class GetAStaticAccountQuery : IRequest<GetAstaticAccount>
    {
        public string AccountNumber { get; set; }
        public string apiversion { get; set; }
    }
}
