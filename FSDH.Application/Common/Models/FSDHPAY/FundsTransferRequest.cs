using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDHPAY
{
  public  class FundsTransferRequest
    {
        public string nameEnquiryRef { get; set; }
        public string destinationInstitutionCode { get; set; }
        public string beneficiaryAccountName { get; set; }
        public string beneficiaryAccountNumber { get; set; }
        public string beneficiaryBankVerificationNumber { get; set; }
        public string beneficiaryKYCLevel { get; set; }
        public string originatorAccountName { get; set; }
        public string originatorAccountNumber { get; set; }
        public string originatorAccountBranch { get; set; }
        public string originatorBankVerificationNumber { get; set; }
        public string paymentReference { get; set; }
        public int transactionAmount { get; set; }
        public string narration { get; set; }
    }
}
