using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.Query.AllDynamicAssignedAccountByCollectionAccountQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.QueryHandler.AllDynamicAssignedAccountByCollectionAccountQuery
{
    public class GetAllDynamicAssignedAccountByCollectionAccountQueryHandler : IRequestHandler<GetAllDynamicAssignedAccountByCollectionAccountQuery, GetAllAsignedDynamicAcciountByCollectionAccount>
    {
        private readonly IFSDH360 _fsdh360;

        public GetAllDynamicAssignedAccountByCollectionAccountQueryHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public async Task<GetAllAsignedDynamicAcciountByCollectionAccount> Handle(GetAllDynamicAssignedAccountByCollectionAccountQuery request, CancellationToken cancellationToken)
        {
            var data = new AllDynamicAssignedAccountByCollectionAccountResources
            {
                skip = request.skip,
                take = request.take,
                apiversion = request.apiversion,
                AccountNumber = request.AccountNumber
            };
            return await _fsdh360.AssignedDynamicAccountByCollectionAccount(request.skip, request.take, request.apiversion, request.AccountNumber);
        }
    }
}
