using FSDH.Application.Command.UpdateStaticVirtualAccount;
using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.CommandHandler.UpdateStaticVirtualAccount
{
    public class UpdateStaticVirtualAccountCommandHandler : IRequestHandler<UpdateStaticVirtualAccountCommand, UpdateStaticVirtualAccountResponse>
    {
        private readonly IFSDH360 _fsdh360;
        public UpdateStaticVirtualAccountCommandHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }
        public async Task<UpdateStaticVirtualAccountResponse> Handle(UpdateStaticVirtualAccountCommand request, CancellationToken cancellationToken)
        {
            var data = new UpdateStaticVirtualAccountResources
            {
                accountName = request.accountName,
                bvn = request.bvn,
                collectionAccountNumber = request.collectionAccountNumber,
                virtualAccountNumber = request.virtualAccountNumber
            };
            return await _fsdh360.UpdateStaticVirtualAccount(data);
        }
    }
}
