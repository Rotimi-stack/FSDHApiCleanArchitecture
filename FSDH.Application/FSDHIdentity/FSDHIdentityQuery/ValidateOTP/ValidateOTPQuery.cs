using FSDH.Application.Common.Models.FSDHIDENTITY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityQuery.ValidateOTP
{
    public class ValidateOTPQuery : IRequest<ValidateOTPResponses>
    {
        public string RecordReference { get; set; }
        public string OTP { get; set; }
    }
}
