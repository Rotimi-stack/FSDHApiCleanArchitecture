using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHIDENTITY;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetSingleBVNbyOTP;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommandHandler.GetSingleBVNbyOTP
{
    public class GetSingleBVNbyOTPCommandHandler : IRequestHandler<GetSingleBVNbyOTPCommand, GetSingleBVNbyOTPResponses>
    {
        private readonly IFSDHIdentity _fsdhidentity;
        public GetSingleBVNbyOTPCommandHandler(IFSDHIdentity fsdhidentity)
        {
            _fsdhidentity = fsdhidentity;
        }
        public async Task<GetSingleBVNbyOTPResponses> Handle(GetSingleBVNbyOTPCommand request, CancellationToken cancellationToken)
        {
            var data = new GetBVNInfoSendOTPResources
            {
                bvn = request.bvn
            };
            return await _fsdhidentity.GetSingleBVNbyOTPs(data);
            
        }
    }
}
