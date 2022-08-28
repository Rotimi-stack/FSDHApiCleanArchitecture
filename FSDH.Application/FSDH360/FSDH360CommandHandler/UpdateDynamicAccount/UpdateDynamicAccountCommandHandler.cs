using FSDH.Application.Command.UpdateDynamicAccount;
using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.CommandHandler.UpdateDynamicAccount
{
    public class UpdateDynamicAccountCommandHandler : IRequestHandler<UpdateDynamicAccountCommand, List<UpdateDynamicAccountResponse>>
    {
        private readonly IFSDH360 _fsdh360;
        public UpdateDynamicAccountCommandHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public async Task<List<UpdateDynamicAccountResponse>> Handle(UpdateDynamicAccountCommand request, CancellationToken cancellationToken)
        {
            var data = new UpdateDynamicAccountResources
            {
                accountName = request.accountName,
                accountNumber = request.accountNumber,
                bvn = request.bvn,
                collectionAccountNumber = request.collectionAccountNumber,
                expectedAmount = request.expectedAmount,
                uniqueReference = request.uniqueReference,
                validFor = request.validFor,
                validTill = request.validTill
            };
            return await _fsdh360.UpdateDynamicAccount(data);
        }
    }
}
