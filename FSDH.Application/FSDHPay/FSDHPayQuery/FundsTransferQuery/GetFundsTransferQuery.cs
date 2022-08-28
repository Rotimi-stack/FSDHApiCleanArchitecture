using FSDH.Application.Common.Models.FSDHPAY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHPayQuery.FundsTransferQuery
{
   public class GetFundsTransferQuery : IRequest<List<GetFundsTransferResponse>>
    {
        public string TransactionId { get; set; }
        public string PaymentReference { get; set; }
        public string apiversion { get; set; }
    }
}
