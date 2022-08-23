using FSDH.Application.Common.Models.FSDHPAY;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSDH.Application.Common.Interfaces
{
   public interface IFSDHPay
    {
        Task<GetBalanceEnquiryResponse> GetBalanceEnquiry(string apiversion, string AccountNumber);
        Task<GetBankResponse> GetBank(string apiversion, string name);
        Task<GetFundsTransferResponse> GetFundsTransfer(string TransactionId, string PaymentReference, string apiversion);
        Task<GetFundsTransferHistoryResponse> GetFundsTransferHistory(string apiversion, string StartDate, string EndDate, int PageSize, int PageNumber);
    }
}
