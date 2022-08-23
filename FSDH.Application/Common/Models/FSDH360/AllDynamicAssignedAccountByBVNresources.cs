using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FSDH.Application.Common.Models.FSDH360
{
   public class AllDynamicAssignedAccountByBVNresources
    {

        public int skip { get; set; }
        public int take { get; set; }
        public string apiversion { get; set; }

        [Required]
        public string BVN { get; set; }
    }
}
