using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHIDENTITY;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetSingleBVNbyDate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommandHandler.GetSingleBVNbyDate
{
    public class GetSingleBVNbyDateCommandHandler : IRequestHandler<GetSingleBVNbyDateCommand, GetSingleBVNbyDAteResponses>
    {
        private readonly IFSDHIdentity _fsdhidentity;
        public GetSingleBVNbyDateCommandHandler(IFSDHIdentity fsdhidentity)
        {
            _fsdhidentity = fsdhidentity;
        }
        public async Task<GetSingleBVNbyDAteResponses> Handle(GetSingleBVNbyDateCommand request, CancellationToken cancellationToken)
        {
            var data = new GetSingleBVNByDateResources
            {
                bvn = request.bvn,
                birthDate = request.birthDate
            };
            return await _fsdhidentity.GetSingleBVNbyDate(data);
        }
    }
}
