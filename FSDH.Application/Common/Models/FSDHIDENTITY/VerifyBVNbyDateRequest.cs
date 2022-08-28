using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDHIDENTITY
{
   public class VerifyBVNbyDateRequest
    {
        public string bvn { get; set; }
        public DateTime birthDate { get; set; }
    }
}
