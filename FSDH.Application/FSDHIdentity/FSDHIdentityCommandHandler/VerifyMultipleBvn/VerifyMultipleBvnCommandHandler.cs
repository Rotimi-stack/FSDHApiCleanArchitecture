using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHIDENTITY;
using FSDH.Application.FSDHIdentity.VerifyMultipleBVN;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommandHandler.VerifyMultipleBvn
{
    public class VerifyMultipleBvnCommandHandler : IRequestHandler<VerifyMultipleBvnCommand, VerifyMultipleBVNResponses>
    {
        private readonly IFSDHIdentity _fsdhidentity;
        public VerifyMultipleBvnCommandHandler(IFSDHIdentity fsdhidentity)
        {
            _fsdhidentity = fsdhidentity;
        }

        public async Task<VerifyMultipleBVNResponses> Handle(VerifyMultipleBvnCommand request, CancellationToken cancellationToken)
        {
            var data = new VerifyMultipleBVNResources
            {
                bvns = request.bvns,
                requestReference = request.requestReference
            };
            return await _fsdhidentity.VerifyMultipleBVN(data);
        }
    }
}
