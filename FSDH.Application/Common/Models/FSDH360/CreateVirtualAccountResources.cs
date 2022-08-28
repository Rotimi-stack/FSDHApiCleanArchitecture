using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDH360
{
   public class CreateVirtualAccountResources
    {
        public string accountName { get; set; }
        public string bvn { get; set; }
        public string collectionAccountNumber { get; set; }
        public string uniqueReference { get; set; }
        public string currencyCode { get; set; }
        public Validfor validFor { get; set; }
        public bool isOneTimePaymentAccount { get; set; }
        public string expectedAmount { get; set; }
    }







}
