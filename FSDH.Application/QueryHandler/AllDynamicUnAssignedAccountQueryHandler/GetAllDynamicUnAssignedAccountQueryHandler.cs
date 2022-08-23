using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.Query.AllDynamicUnAssignedQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.QueryHandler.AllDynamicUnAssignedAccountQueryHandler
{
    public class GetAllDynamicUnAssignedAccountQueryHandler : IRequestHandler<GetAllDynamicUnAssignedAccountQuery, GetUnAssignedDynamicAccount>
    {
        private readonly IFSDH360 _fsdh360;

        public GetAllDynamicUnAssignedAccountQueryHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public async Task<GetUnAssignedDynamicAccount> Handle(GetAllDynamicUnAssignedAccountQuery request, CancellationToken cancellationToken)
        {
            var data = new AllDynamicUnAssignedAccountResource
            {
                skip = request.skip,
                take = request.take,
                apiversion = request.apiversion
            };

            return await _fsdh360.UnAssignedDynamicAccount(request.skip, request.take, request.apiversion);
        }
    }
}
