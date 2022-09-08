using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDH360.FSDH360Command.CreateDynamicVirtualAccount
{
    public class CreateDynamicVirtualAccountCommand : IRequest<CreateDynamicVirtualAccountResponses>
    {
        public string accountName { get; set; }
        public string bvn { get; set; }
        public string collectionAccountNumber { get; set; }
        public string uniqueReference { get; set; }
        public string currencyCode { get; set; }
        public Validfor validFor { get; set; }
        public bool isOneTimePaymentAccount { get; set; }
        public string expectedAmount { get; set; }


    }

    public class ValidFor
    {
        public int years { get; set; }
        public int months { get; set; }
        public int days { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }

    }
}