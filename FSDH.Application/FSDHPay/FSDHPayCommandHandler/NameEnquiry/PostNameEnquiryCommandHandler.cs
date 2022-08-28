using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHPAY;
using FSDH.Application.FSDHPayCommand.NameEnquiry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHPayCommandHandler.NameEnquiry
{
    public class PostNameEnquiryCommandHandler : IRequestHandler<PostNameEnquiryCommand, List<PostNameEnquiryResponse>>
    {
        private readonly IFSDHPay _fSDHPay;
        public PostNameEnquiryCommandHandler(IFSDHPay fSDHPay)
        {
            _fSDHPay = fSDHPay;
        }
        public async  Task<List<PostNameEnquiryResponse>> Handle(PostNameEnquiryCommand request, CancellationToken cancellationToken)
        {
            var data = new PostNameEnquiryResources
            {
                accountNumber = request.accountNumber,
                channelCode = request.channelCode,
                destinationInstitutionCode = request.destinationInstitutionCode
            };
            return await _fSDHPay.PostNameEnquiryNIP(data);
        }
    }
}
