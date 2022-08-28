using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHIDENTITY;
using FSDH.Application.FSDHIdentity.FSDHIdentityCommand.IsBVNWatchlisted;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommandHandler.IsBvnWatchlisted
{
    public class IsBvnWatchlistedCommandHandler : IRequestHandler<IsBvnWatchListedCommand, IsBVNWatchListedResponses>
    {
        private readonly IFSDHIdentity _fsdhidentity;
        public IsBvnWatchlistedCommandHandler(IFSDHIdentity fsdhidentity)
        {
            _fsdhidentity = fsdhidentity;
        }

        public async Task<IsBVNWatchListedResponses> Handle(IsBvnWatchListedCommand request, CancellationToken cancellationToken)
        {
            var data = new IsBVNWatchlistedResources
            {
                bvn = request.bvn
            };
            return await _fsdhidentity.IsBVNWatchListed(data);
        }
    }
}
