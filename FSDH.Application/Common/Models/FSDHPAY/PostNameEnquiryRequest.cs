using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDHPAY
{
   public class PostNameEnquiryRequest
    {
        public string destinationInstitutionCode { get; set; }
        public string channelCode { get; set; }
        public string accountNumber { get; set; }
    }
}
