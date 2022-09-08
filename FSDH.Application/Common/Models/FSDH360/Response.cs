using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDH360
{
  public  class Response
    {
       
    }

    public class GetVirtualaccountTransactionHistoryResponse
    {

        public string virtualAccountNumber { get; set; }
        public DateTime transactionDate { get; set; }
        public DateTime endDate { get; set; }
        public string collectionAccountNumber { get; set; }
        public string transactionType { get; set; }
        public string transactionCurrencyCode { get; set; }
        public string amount { get; set; }
        public string narration { get; set; }
        public string counterPartyAccountNumber { get; set; }
        public string counterPartyAccountName { get; set; }

    }

    public class Validfor
    {
        public int years { get; set; }
        public int months { get; set; }
        public int days { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }
    }

    public class QueryBalanceforCollectionAccountResponse
    {
        public double availableBalance { get; set; }
        public double ledgerBalance { get; set; }
    }
    public class UpdateDynamicAccountResponse
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

    public class GetDynamicAccountTransactionHistory
    {
        public string virtualAccountNumber { get; set; }
        public string collectionAccountNumber { get; set; }
        public string transactionType { get; set; }
        public string transactionCurrencyCode { get; set; }
        public int amount { get; set; }
        public string narration { get; set; }
        public string transactionDate { get; set; }
        public string counterPartyAccountNumber { get; set; }
        public string counterPartyAccountName { get; set; }
    }

    public class CreateStaticVirtualAccountResponses
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public int accountType { get; set; }
        public string accountCurrency { get; set; }
    }

    public class GetAllAsignedDynamicAccount
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public int accountType { get; set; }
        public string accountCurrency { get; set; }
        public bool hasExpired { get; set; }
        public DateTime expires { get; set; }
        public string uniqueReference { get; set; }
        public bool isOneTimePaymentAccount { get; set; }
        public string expectedAmount { get; set; }

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

    public class UpdateStaticVirtualAccountResponse
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public string accountType { get; set; }
        public string accountCurrency { get; set; }
    }

    public class GetUnAssignedDynamicAccount
    {
        public List<string> MyArray { get; set; }
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
        public double availableBalance { get; set; }
        public double ledgerBalance { get; set; }
    }

    public class UnassignDynamicAccount
    {

    }

    public class CreateDynamicVirtualAccountResponses
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

    public class GetAllstaticAccount
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public int accountType { get; set; }
        public string accountCurrency { get; set; }
    }

    public class GetAstaticAccount
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public int accountType { get; set; }
        public string accountCurrency { get; set; }
    }

    public class GetAllCollectionLinkedAccount
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public int accountType { get; set; }
        public string accountCurrency { get; set; }
    }

    public class GetAllStaticAccountLinkedtoBVN
    {
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string collectionAccountNumber { get; set; }
        public string bvn { get; set; }
        public int accountType { get; set; }
        public string accountCurrency { get; set; }
    }
}
