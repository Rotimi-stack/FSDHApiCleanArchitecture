using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHPAY;
using FSDH.Application.FSDHPayCommand.NameEnquiryFSDH;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHPayCommandHandler.NameEnquiryFSDHCommandHandler
{
    public class PostNameEnquiryFSDHQueryHandler : IRequestHandler<PostNameEnquiryFSDHQuery, List<PostNameEnquiryFSDHresponses>>
    {

        private readonly IFSDHPay _fSDHPay;
        public PostNameEnquiryFSDHQueryHandler(IFSDHPay fSDHPay)
        {
            _fSDHPay = fSDHPay;
        }
        public async Task<List<PostNameEnquiryFSDHresponses>> Handle(PostNameEnquiryFSDHQuery request, CancellationToken cancellationToken)
        {
            var data = new PostNameEnquiryFSDHResources
            {
                AccountNumber = request.AccountNumber,
                ApiVersion = request.ApiVersion
                
            };
            return await _fSDHPay.PostNameEnquiryFSDH(request.AccountNumber, request.ApiVersion);
        }
    }
}
