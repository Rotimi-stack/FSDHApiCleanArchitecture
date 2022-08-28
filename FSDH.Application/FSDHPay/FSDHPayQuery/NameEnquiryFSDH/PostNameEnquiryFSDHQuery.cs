using FSDH.Application.Common.Models.FSDHPAY;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FSDH.Application.FSDHPayCommand.NameEnquiryFSDH
{
   public class PostNameEnquiryFSDHQuery : IRequest<List<PostNameEnquiryFSDHresponses>>
    {
        [Required]
        public string AccountNumber { get; set; }

        public string ApiVersion { get; set; }
    }
}
