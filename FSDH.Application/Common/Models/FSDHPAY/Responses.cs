using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDHPAY
{
   public class Responses
    {
        
    }

    public class GetBalanceEnquiryResponse
    {
        public string accountName { get; set; }
        public string surrency { get; set; }
        public string availableBalance { get; set; }
        public string ledgerBalance { get; set; }
    }

    public class GetBankResponse
    {
        public string institutionCode { get; set; }
        public string institutionName { get; set; }
    }
    

    public class GetFundsTransferResponse
    {
        public string transactionId { get; set; }
        public string sessionID { get; set; }
        public string transDateTimed { get; set; }
        public string nameEnquiryRef { get; set; }
        public string destinationInstitutionCode { get; set; }
        public string channelCode { get; set; }
        public string beneficiaryAccountName { get; set; }
        public string beneficiaryAccountNumber { get; set; }
        public string beneficiaryBankVerificationNumber { get; set; }
        public string beneficiaryKYCLevel { get; set; }
        public string originatorAccountName { get; set; }
        public string originatorAccountNumber { get; set; }
        public string originatorBankVerificationNumberountNumber { get; set; }
        public string originatorKYCLevel { get; set; }
        public string transactionLocation { get; set; }
        public string narration { get; set; }
        public string paymentReference { get; set; }
        public int amount { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
        public bool isReversed { get; set; }

    }


    public class GetFundsTransferHistoryResponse
    {
        public string transactionId { get; set; }
        public string sessionID { get; set; }
        public string transDateTimed { get; set; }
        public string nameEnquiryRef { get; set; }
        public string destinationInstitutionCode { get; set; }
        public string channelCode { get; set; }
        public string beneficiaryAccountName { get; set; }
        public string beneficiaryAccountNumber { get; set; }
        public string beneficiaryBankVerificationNumber { get; set; }
        public string beneficiaryKYCLevel { get; set; }
        public string originatorAccountName { get; set; }
        public string originatorAccountNumber { get; set; }
        public string originatorBankVerificationNumberountNumber { get; set; }
        public string originatorKYCLevel { get; set; }
        public string transactionLocation { get; set; }
        public string narration { get; set; }
        public string paymentReference { get; set; }
        public int amount { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
        public bool isReversed { get; set; }

    }

    public class PostFundsTransferResponses
    {
        public string transactionId { get; set; }
        public string sessionID { get; set; }
        public string nameEnquiryRef { get; set; }
        public string destinationInstitutionCode { get; set; }
        public string channelCode { get; set; }
        public string beneficiaryAccountName { get; set; }
        public string beneficiaryAccountNumber { get; set; }
        public string beneficiaryBankVerificationNumber { get; set; }
        public string beneficiaryKYCLevel { get; set; }
        public string originatorAccountName { get; set; }
        public string originatorAccountNumber { get; set; }
        public string originatorBankVerificationNumber { get; set; }
        public string originatorKYCLevel { get; set; }
        public string transactionLocation { get; set; }
        public string narration { get; set; }
        public string paymentReference { get; set; }
        public int amount { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
    }

    public class PostNameEnquiryResponse
    {
        public string destinationInstitutionCode { get; set; }
        public string channelCode { get; set; }
        public string accountNumber { get; set; }
        public string sessionID { get; set; }
        public string accountName { get; set; }
        public string bankVerificationNumber { get; set; }
        public string kycLevel { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
    }

    public class PostNameEnquiryFSDHresponses
    {
        public string accountName { get; set; }
        public string branchCode { get; set; }
        public string bvn { get; set; }
        public string kycLevel { get; set; }
    }

}
