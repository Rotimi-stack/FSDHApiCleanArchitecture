using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FSDH.Application.Common.Models.FSDH360
{
    public class ADynamicAcoountResources
    {
        public string apiversion { get; set; }

        [Required]
        public string AccountNumber { get; set; }

    }
}
