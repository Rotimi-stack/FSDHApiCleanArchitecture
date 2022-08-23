using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDH360
{
    public class GetAllStaticAccountResources
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string apiversion { get; set; }
    }
}
