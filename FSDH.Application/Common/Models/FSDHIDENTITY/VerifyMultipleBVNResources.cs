using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDHIDENTITY
{
    public class VerifyMultipleBVNResources
    {
        public string requestReference { get; set; }
        public List<BVN> bvns { get; set; }

    }

    public class BVNN
    {
        public string bvn { get; set; }
    }
}
