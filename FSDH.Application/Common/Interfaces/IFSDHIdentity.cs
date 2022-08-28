using FSDH.Application.Common.Models.FSDHIDENTITY;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSDH.Application.Common.Interfaces
{
   public interface IFSDHIdentity
    {
        Task<GetDetailedInfoforAListofBVNResponse> GetDetailedInfoMultipleBVN(GetMultipleBVNResources var);
        Task<GetSingleBVNResponse> GetDetailedInfoforABVN(GetSingleBVNResources uae);
        Task<GetSingleBVNbyDAteResponses> GetSingleBVNbyDate(GetSingleBVNByDateResources vae);
        Task<GetSingleBVNbyOTPResponses> GetSingleBVNbyOTPs(GetBVNInfoSendOTPResources add);
        Task<ValidateOTPResponses> ValidateanOTP(string RecordReference, string OTP);
        Task<IsBVNWatchListedResponses> IsBVNWatchListed(IsBVNWatchlistedResources vadd);
        Task<VerifyMultipleBVNResponses> VerifyMultipleBVN(VerifyMultipleBVNResources com);
        Task<VerifySingleBVN> VerifySingleBVN(VerifySingleBVNResources art);
        Task<VerifySingleBVNbyDate> verifySingleBVNbyDate(VerifyBVNbyDateResources bdr);


    }
}
