using FSDH.Application.Command.CollectionAccountBalance;
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
    public class CollectionDynamicAccountbalanceDetailsCommandHandler : IRequestHandler<CollectionDynamicAccountbalanceDetailsCommand, CollectionAccountBalanceDetails>
    {
        private readonly IFSDH360 _fsdh360;
        public CollectionDynamicAccountbalanceDetailsCommandHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public async Task<CollectionAccountBalanceDetails> Handle(CollectionDynamicAccountbalanceDetailsCommand request, CancellationToken cancellationToken)
        {
            var data = new CollectionAccountBalanceResources
            {
                accountNumber = request.accountNumber
                
            };
            return await _fsdh360.CollectionDynamicAccountbalanceDetails(data);
        } 
    }
}
