using FSDH.Application.Common.Models.FSDHPAY;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSDH.Application.Common.Interfaces
{
   public interface IFSDHPay
    {
        Task<List<GetBalanceEnquiryResponse>> GetBalanceEnquiry(string AccountNumber, string apiversion);
        Task<List<GetBankResponse>> GetBank(string apiversion, string name);
        Task<List<GetFundsTransferResponse>> GetFundsTransfer(string TransactionId, string PaymentReference, string apiversion);
        Task<List<GetFundsTransferHistoryResponse>> GetFundsTransferHistory( string StartDate, string EndDate, int PageNumber ,int PageSize, string apiversion);

        Task<List<PostFundsTransferResponses>> PostFundsTransfers(PostFundsTransferResources ftr);

        Task<List<PostNameEnquiryResponse>> PostNameEnquiryNIP(PostNameEnquiryResources ner);
        Task<List<PostNameEnquiryFSDHresponses>> PostNameEnquiryFSDH(string AccountNumber, string ApiVersion);
    }
}
