using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDH360
{
    public class GetVirtualaccountTransactionHistoryRequest
    {
        public string accountNumber { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string skip { get; set; }
        public string take { get; set; }
    }
}
