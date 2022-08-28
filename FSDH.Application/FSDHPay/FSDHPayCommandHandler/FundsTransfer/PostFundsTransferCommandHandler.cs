using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHPAY;
using FSDH.Application.FSDHPayCommand.FundsTransfer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHPayCommandHandler.FundsTransfer
{
    class PostFundsTransferCommandHandler : IRequestHandler<PostFundstransferCommand, List<PostFundsTransferResponses>>
    {
        private readonly IFSDHPay _fSDHPay;
        public PostFundsTransferCommandHandler(IFSDHPay fSDHPay)
        {
            _fSDHPay = fSDHPay;
        }
        public async Task<List<PostFundsTransferResponses>> Handle(PostFundstransferCommand request, CancellationToken cancellationToken)
        {
            var data = new PostFundsTransferResources
            {
                beneficiaryAccountName = request.beneficiaryAccountName,
                beneficiaryAccountNumber = request.beneficiaryAccountNumber,
                beneficiaryBankVerificationNumber=request.beneficiaryBankVerificationNumber,
                beneficiaryKYCLevel = request.beneficiaryKYCLevel,
                destinationInstitutionCode = request.destinationInstitutionCode,
                nameEnquiryRef = request.nameEnquiryRef,
                narration = request.narration,
                originatorAccountBranch = request.originatorAccountBranch,
                originatorAccountName = request.originatorAccountName,
               originatorAccountNumber = request.originatorAccountNumber,
               originatorBankVerificationNumber = request.originatorBankVerificationNumber,
               paymentReference = request.paymentReference,
               transactionAmount = request.transactionAmount
               
            };
            return await _fSDHPay.PostFundsTransfers(data);
        }
    }
}
