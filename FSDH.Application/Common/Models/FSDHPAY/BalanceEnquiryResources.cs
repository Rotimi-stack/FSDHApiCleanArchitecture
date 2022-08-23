using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FSDH.Application.Common.Models.FSDHPAY
{
   public class BalanceEnquiryResources
    {
        public string apiversion { get; set; }
        [Required]
        public string AccountNumber { get; set; }
    }
}
