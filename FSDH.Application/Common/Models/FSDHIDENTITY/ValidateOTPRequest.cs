using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDHIDENTITY
{
   public class ValidateOTPRequest
    {
        public string RecordReference { get; set; }
        public string OTP { get; set; }
        public string XVersion { get; set; }
    }
}
