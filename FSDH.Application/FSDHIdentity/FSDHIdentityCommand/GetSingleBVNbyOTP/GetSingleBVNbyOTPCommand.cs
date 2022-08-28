using FSDH.Application.Common.Models.FSDHIDENTITY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetSingleBVNbyOTP
{
    public class GetSingleBVNbyOTPCommand : IRequest<GetSingleBVNbyOTPResponses>
    {
        public string bvn { get; set; }
    }
}
