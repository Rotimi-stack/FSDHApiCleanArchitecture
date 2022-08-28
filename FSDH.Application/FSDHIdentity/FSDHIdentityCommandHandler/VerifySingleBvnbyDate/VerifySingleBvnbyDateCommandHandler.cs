using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHIDENTITY;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.VerifySingleBvnbyDate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommandHandler.VerifySingleBvnbyDate
{
    public class VerifySingleBvnbyDateCommandHandler : IRequestHandler<VerifySingleBvnbyDateCommand, VerifySingleBVNbyDate>
    {
        private readonly IFSDHIdentity _fsdhidentity;
        public VerifySingleBvnbyDateCommandHandler(IFSDHIdentity fsdhidentity)
        {
            _fsdhidentity = fsdhidentity;
        }
        public async Task<VerifySingleBVNbyDate> Handle(VerifySingleBvnbyDateCommand request, CancellationToken cancellationToken)
        {
            var data = new VerifyBVNbyDateResources
            {
                bvn = request.bvn,
                birthDate = request.birthDate
            };
            return await _fsdhidentity.verifySingleBVNbyDate(data);
        }
    }
}
