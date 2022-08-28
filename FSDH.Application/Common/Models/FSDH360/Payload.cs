//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace FSDH.Application.Common.Models.FSDH360
//{
//   public class Payload
//    {
//        public string AccountNumber { get; set; }
//    }


//    public class TransactionHistory
//    {
//        public string accountNumber { get; set; }
//        public DateTime startDate { get; set; }
//        public DateTime endDate { get; set; }
//        public int skip { get; set; }
//        public int take { get; set; }
//    }

//    public class UpdateDynamicAccount
//    {
//        public string accountName { get; set; }
//        public string bvn { get; set; }
//        public string accountNumber { get; set; }
//        public string collectionAccountNumber { get; set; }
//        public string uniqueReference { get; set; }
//        public DateTime validTill { get; set; }
//        public Validfor validFor { get; set; }

//    }

//    public class Validfor
//    {
//        public int years { get; set; }
//        public int months { get; set; }
//        public int days { get; set; }
//        public int hours { get; set; }
//        public int minutes { get; set; }
//    }

//    public class CreateDynamicAccountPayload
//    {
//        public string accountName { get; set; }
//        public string bvn { get; set; }
//        public string accountNumber { get; set; }
//        public string collectionAccountNumber { get; set; }
//        public string uniqueReference { get; set; }
//        public DateTime validTill { get; set; }
//        public Validfor validFor { get; set; }
//        public bool isOneTimePaymentAccount { get; set; }

//    }

//    public class GetDynamicAccount
//    {
//        public string AccountNumber { get; set; }
//        public string version { get; set; }
//    }


//    public class GetDynamicAccountBVN
//    {
//        public string BVN { get; set; }
//        public int Skip { get; set; }
//        public int take { get; set; }
//        public string version { get; set; }
//    }

//    public class GetDynamicAccountByAccountNum
//    {
//        public string BVN { get; set; }
//        public int Skip { get; set; }
//        public int take { get; set; }
//        public string apiversion { get; set; }
//    }

   
//}
