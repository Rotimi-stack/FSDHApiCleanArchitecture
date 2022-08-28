using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHIDENTITY;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetDetailedInfoMultipleBVN;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommandHandler.GetDetailedInfoMultipleBVNCommandHandler
{
    public class GetDetailedInfoMultipleBVNCommandHandler : IRequestHandler<GetDetailedInfoMultipleBVNCommand, GetDetailedInfoforAListofBVNResponse>
    {
        private readonly IFSDHIdentity _fsdhidentity;
        public GetDetailedInfoMultipleBVNCommandHandler(IFSDHIdentity fsdhidentity)
        {
            _fsdhidentity = fsdhidentity;
        }
        public async Task<GetDetailedInfoforAListofBVNResponse> Handle(GetDetailedInfoMultipleBVNCommand request, CancellationToken cancellationToken)
        {
            var data = new GetMultipleBVNResources
            {
                bvns = request.bvns,
                requestReference = request.requestReference
            };
           return await _fsdhidentity.GetDetailedInfoMultipleBVN(data);
        }
    }
}
