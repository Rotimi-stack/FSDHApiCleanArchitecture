using FSDH.Application.Common.Models.FSDHIDENTITY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetDetailedInfoMultipleBVN
{
    public class GetDetailedInfoMultipleBVNCommand : IRequest<GetDetailedInfoforAListofBVNResponse>
    {
        public string requestReference { get; set; }
        public List<BVN> bvns { get; set; }
    }
   
}
