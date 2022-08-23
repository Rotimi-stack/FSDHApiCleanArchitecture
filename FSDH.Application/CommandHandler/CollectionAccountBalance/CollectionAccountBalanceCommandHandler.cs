using FSDH.Application.Command;
using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.CommandHandler.CollectionAccountBalance
{
    public class CollectionAccountBalanceCommandHandler : IRequestHandler<CollectionAccountNumberCommand, CollectionAccountBalanceDetails>
    {
        private readonly IFSDH360 _fsdh360;
        public CollectionAccountBalanceCommandHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public async Task<CollectionAccountBalanceDetails> Handle(CollectionAccountNumberCommand request, CancellationToken cancellationToken)
        {
            var data = new CollectionAccountBalanceResources
            {
                accountNumber = request.accountNumber
                
            };
            return await _fsdh360.CollectionAccountbalanceDetails(data, request.apiversion);
        } 
    }
}
