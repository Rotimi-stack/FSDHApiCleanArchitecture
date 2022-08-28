using FSDH.Application.Command.StaticVirtualAccount;
using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.CommandHandler.StaticVirtualAccount
{
    public class CreateStaticVirtualAccountCommandHandler : IRequestHandler<CreateStaticVirtualAccountCommand, CreateStaticVirtualAccountResponses>
    {
        private readonly IFSDH360 _fsdh360;
        public CreateStaticVirtualAccountCommandHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }
        public async Task<CreateStaticVirtualAccountResponses> Handle(CreateStaticVirtualAccountCommand request, CancellationToken cancellationToken)
        {
            var data = new CreateStaticVirtualAccountResource
            {
                accountName = request.accountName,
                bvn = request.bvn,
                collectionAccountNumber = request.collectionAccountNumber,
                currencyCode = request.currencyCode
            };
            return await _fsdh360.CreateStaticVirtualAccount(data);

        }
    }
}
