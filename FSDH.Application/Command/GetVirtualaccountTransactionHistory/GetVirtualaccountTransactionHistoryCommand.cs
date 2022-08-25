using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Command.GetVirtualaccountTransactionHistory
{
    public class GetVirtualaccountTransactionHistoryCommand : IRequest<GetVirtualaccountTransactionHistoryResponse>
    {
        public string accountNumber { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string skip { get; set; }
        public string take { get; set; }
    }
}
