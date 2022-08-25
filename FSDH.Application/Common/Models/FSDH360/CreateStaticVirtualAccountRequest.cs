using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDH360
{
   public class CreateStaticVirtualAccountRequest
    {
        public string accountName { get; set; }
        public string bvn { get; set; }
        public string collectionAccountNumber { get; set; }
        public string currencyCode { get; set; }
    }
}
