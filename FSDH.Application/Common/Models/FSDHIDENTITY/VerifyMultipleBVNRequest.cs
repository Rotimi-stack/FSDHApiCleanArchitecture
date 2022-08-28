using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDHIDENTITY
{
    public class VerifyMultipleBVNRequest
    {
        public string requestReference { get; set; }
        public List<BVN> bvns{ get; set; }
        
    }

    public class BVN
    {
        public string bvn { get; set; }
    }
}
