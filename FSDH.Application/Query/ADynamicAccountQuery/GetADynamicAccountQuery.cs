using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Query.ADynamicAccountQuery
{
   public class GetADynamicAccountQuery : IRequest<GetADynamicAccount>
    {
        public string apiversion { get; set; }
        public string AccountNumber { get; set; }
    }
}
