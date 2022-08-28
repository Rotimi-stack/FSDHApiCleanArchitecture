using FSDH.Application.Common.Models.FSDHIDENTITY;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetDetailedInfoforABVN;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetDetailedInfoMultipleBVN;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetSingleBVNbyDate;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetSingleBVNbyOTP;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.IsBVNWatchlisted;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.VerifySingleBvn;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.VerifySingleBvnbyDate;
using FSDH.Application.FSDHIdentity.FSDHIdentityQuery.ValidateOTP;
using FSDH.Application.FSDHIdentity.VerifyMultipleBVN;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSDH.API.Controllers
{
    public class FSDHIdentityController : BaseController
    {
        [HttpPost("info-a-bvn-fsdhidentity")]
        public async Task<ActionResult<GetSingleBVNResponse>> GetDetailedInfoforABVN(GetDetailedInfoforABVNCommand abc )
        {
            return await Mediator.Send(abc);
        }

        [HttpPost("info-multiplebvn-fsdhidentity")]
        public async Task<ActionResult<GetDetailedInfoforAListofBVNResponse>> GetDetailedInfoMultipleBVN(GetDetailedInfoMultipleBVNCommand abc)
        {
            return await Mediator.Send(abc);
        }

        [HttpPost("info-bvn-date-fsdhidentity")]
        public async Task<ActionResult<GetSingleBVNbyDAteResponses>> GetSingleBVNbyDate(GetSingleBVNbyDateCommand abc)
        {
            return await Mediator.Send(abc);
        }

        [HttpPost("info-bvn-otp-fsdhidentity")]
        public async Task<ActionResult<GetSingleBVNbyOTPResponses>> GetSingleBVNbyOTPs(GetSingleBVNbyOTPCommand abc)
        {
            return await Mediator.Send(abc);
        }

        [HttpPost("bvn-iswatchlisted-fsdhidentity")]
        public async Task<ActionResult<IsBVNWatchListedResponses>> IsBVNWatchListed(IsBvnWatchListedCommand abc)
        {
            return await Mediator.Send(abc);
        }

        [HttpGet("bvn-validateotp-fsdhidentity")]
        public async Task<ActionResult<ValidateOTPResponses>> ValidateanOTP([FromQuery] string RecordReference, [FromQuery] string OTP)
        {
            return await Mediator.Send(new ValidateOTPQuery {OTP = OTP, RecordReference = RecordReference });
        }

        [HttpPost("verify-multiple-bvn-fsdhidentity")]
        public async Task<ActionResult<VerifyMultipleBVNResponses>> VerifyMultipleBVN(VerifyMultipleBvnCommand abc)
        {
            return await Mediator.Send(abc);
        }

        [HttpPost("verify-single-bvn-fsdhidentity")]
        public async Task<ActionResult<VerifySingleBVN>> VerifySingleBVN(VerifySingleBvnCommand abc)
        {
            return await Mediator.Send(abc);
        }

        [HttpPost("verify-single-bvn-date-fsdhidentity")]
        public async Task<ActionResult<VerifySingleBVNbyDate>> verifySingleBVNbyDate(VerifySingleBvnbyDateCommand abc)
        {
            return await Mediator.Send(abc);
        }
    }
}
