using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHIDENTITY;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetDetailedInfoforABVN;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommandHandler.GetDetailedInfoforABVNCommandHandler
{
    public class GetDetailedInfoforABVNCommandHandler : IRequestHandler<GetDetailedInfoforABVNCommand, GetSingleBVNResponse>
    {

        private readonly IFSDHIdentity _fsdhidentity;
        public GetDetailedInfoforABVNCommandHandler(IFSDHIdentity fsdhidentity)
        {
            _fsdhidentity = fsdhidentity;
        }
        public async Task<GetSingleBVNResponse> Handle(GetDetailedInfoforABVNCommand request, CancellationToken cancellationToken)
        {
            var data = new GetSingleBVNResources
            {
                bvn = request.bvn
            };
            return await _fsdhidentity.GetDetailedInfoforABVN(data);
        }
    }
}
