using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FSDH.Application.Common.Models.FSDH360
{
   public class GetAStaticAccountResources
    {
        [Required]
        public string AccountNumber { get; set; }
        public string apiversion { get; set; }
    }
}
