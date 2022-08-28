using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHIDENTITY;
using FSDH.Application.FSDHIdentity.FSDHIdentityQuery.ValidateOTP;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityQueryHandler
{
    public class ValidateOTPQueryHandler : IRequestHandler<ValidateOTPQuery, ValidateOTPResponses>
    {
        private readonly IFSDHIdentity _fsdhidentity;
        public ValidateOTPQueryHandler(IFSDHIdentity fsdhidentity)
        {
            _fsdhidentity = fsdhidentity;
        }
        public async Task<ValidateOTPResponses> Handle(ValidateOTPQuery request, CancellationToken cancellationToken)
        {
            var data = new ValidateOTPResources
            {
                OTP = request.OTP,
                RecordReference = request.RecordReference
            };
            return await _fsdhidentity.ValidateanOTP(request.RecordReference, request.OTP);
        }
    }
}
