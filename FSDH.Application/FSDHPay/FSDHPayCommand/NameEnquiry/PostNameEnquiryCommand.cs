using FSDH.Application.Common.Models.FSDHPAY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHPayCommand.NameEnquiry
{
    public class PostNameEnquiryCommand : IRequest<List<PostNameEnquiryResponse>>
    {
        public string destinationInstitutionCode { get; set; }
        public string channelCode { get; set; }
        public string accountNumber { get; set; }
    }
}
