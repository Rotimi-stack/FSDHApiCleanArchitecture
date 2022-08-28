using FSDH.Application.Common.Models.FSDHIDENTITY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetDetailedInfoforABVN
{
   public  class GetDetailedInfoforABVNCommand : IRequest<GetSingleBVNResponse>
    {
        public string bvn { get; set; }
    }
}
