using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDH360
{
  public  class Response
    {
       
    }


    public class GetAllAsignedDynamicAccount
    {
        public bool hasExpired { get; set; }
        public DateTime expires { get; set; }
        public string uniqueReference { get; set; }
        public bool isOneTimePaymentAccount { get; set; }
        public string expectedAmount { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public int accountType { get; set; }
        public string accountCurrency { get; set; }
    }

    public class GetAllAsignedDynamicAccountBVN
    {
        public bool hasExpired { get; set; }
        public DateTime expires { get; set; }
        public string uniqueReference { get; set; }
        public bool isOneTimePaymentAccount { get; set; }
        public string expectedAmount { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public int accountType { get; set; }
        public string accountCurrency { get; set; }
    }

    public class GetADynamicAccount
    {
        public bool hasExpired { get; set; }
        public DateTime expires { get; set; }
        public string uniqueReference { get; set; }
        public bool isOneTimePaymentAccount { get; set; }
        public string expectedAmount { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public int accountType { get; set; }
        public string accountCurrency { get; set; }
    }



    public class GetUnAssignedDynamicAccount
    {
       
    }


    public class GetAllAsignedDynamicAcciountByCollectionAccount
    {
        public bool hasExpired { get; set; }
        public DateTime expires { get; set; }
        public string uniqueReference { get; set; }
        public bool isOneTimePaymentAccount { get; set; }
        public string expectedAmount { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public int accountType { get; set; }
        public string accountCurrency { get; set; }
    }

    public class CollectionAccountBalanceDetails
    {
        public int availableBalance { get; set; }
        public int ledgerBalance { get; set; }
    }

    public class UnassignDynamicAccount
    {

    }

    public class GetAllstaticAccount
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public string accountType { get; set; }
        public string accountCurrency { get; set; }
    }

    public class GetAstaticAccount
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public string accountType { get; set; }
        public string accountCurrency { get; set; }
    }

    public class GetAllCollectionLinkedAccount
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public string accountType { get; set; }
        public string accountCurrency { get; set; }
    }

    public class GetAllStaticAccountLinkedtoBVN
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public string accountType { get; set; }
        public string accountCurrency { get; set; }
    }
}
