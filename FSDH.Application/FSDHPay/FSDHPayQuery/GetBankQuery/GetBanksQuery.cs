using FSDH.Application.Common.Models.FSDHPAY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHPayQuery.GetBankQuery
{
    public class GetBanksQuery : IRequest<List<GetBankResponse>>
    {
        public string name { get; set; }
        public string apiversion { get; set; }
    }
}
