using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FSDH.Application.Common.Models.FSDHPAY
{
   public class FundsTransferHistoryResources
    {

        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string apiversion { get; set; }
    }
}
