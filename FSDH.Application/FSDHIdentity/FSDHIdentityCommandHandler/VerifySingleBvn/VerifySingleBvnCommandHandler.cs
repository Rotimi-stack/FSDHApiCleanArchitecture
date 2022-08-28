using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHIDENTITY;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.VerifySingleBvn;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommandHandler.VerifySingleBvn
{
    public class VerifySingleBvnCommandHandler : IRequestHandler<VerifySingleBvnCommand, VerifySingleBVN>
    {
        private readonly IFSDHIdentity _fsdhidentity;
        public VerifySingleBvnCommandHandler(IFSDHIdentity fsdhidentity)
        {
            _fsdhidentity = fsdhidentity;
        }
        public async Task<VerifySingleBVN> Handle(VerifySingleBvnCommand request, CancellationToken cancellationToken)
        {
            var data = new VerifySingleBVNResources
            {
                bvn = request.bvn
            };
            return await _fsdhidentity.VerifySingleBVN(data);
        }
    }
}
