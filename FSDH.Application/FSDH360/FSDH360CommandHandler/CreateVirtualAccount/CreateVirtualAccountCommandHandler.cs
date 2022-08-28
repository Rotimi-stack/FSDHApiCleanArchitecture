using FSDH.Application.Command.CreateVirtualAccount;
using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.CommandHandler.CreateVirtualAccount
{
    public class CreateVirtualAccountCommandHandler : IRequestHandler<CreateVirtualAccountCommand, CreateDynamicVirtualAccountResponses>
    {
        private readonly IFSDH360 _fsdh360;
        public CreateVirtualAccountCommandHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }




        public async Task<CreateDynamicVirtualAccountResponses> Handle(CreateVirtualAccountCommand request, CancellationToken cancellationToken)
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
