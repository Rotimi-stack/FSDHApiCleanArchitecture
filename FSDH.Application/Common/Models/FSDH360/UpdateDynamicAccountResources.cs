using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDH360
{
   public class UpdateDynamicAccountResources
    {
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public string bvn { get; set; }
        public string collectionAccountNumber { get; set; }
        public string uniqueReference { get; set; }
        public DateTime validTill { get; set; }
        public Validfor validFor { get; set; }
        public string expectedAmount { get; set; }
    }


   

}
