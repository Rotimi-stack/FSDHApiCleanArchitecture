using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.FSDH360.FSDH360Command.CreateDynamicVirtualAccount;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.CommandHandler.CreateVirtualAccount
{
    public class CreateDynamicVirtualAccountCommandHandler : IRequestHandler<CreateDynamicVirtualAccountCommand, CreateDynamicVirtualAccountResponses>
    {
        private readonly IFSDH360 _fsdh360;
        public CreateDynamicVirtualAccountCommandHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }




        public async Task<CreateDynamicVirtualAccountResponses> Handle(CreateDynamicVirtualAccountCommand request, CancellationToken cancellationToken)
        {
            var data = new CreateVirtualAccountResources
            {
                accountName = request.accountName,
                collectionAccountNumber = request.collectionAccountNumber,
                bvn = request.bvn,
                currencyCode = request.currencyCode,
                expectedAmount = request.expectedAmount,
                isOneTimePaymentAccount = request.isOneTimePaymentAccount,
                uniqueReference = request.uniqueReference,
                validFor = request.validFor,
                
            };
            return await _fsdh360.CreateDynamicVirtualAccount(data);
        }
    }
}
