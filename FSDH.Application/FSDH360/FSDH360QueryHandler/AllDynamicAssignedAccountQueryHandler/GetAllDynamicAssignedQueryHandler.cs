using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.Query.AllDynamicAssignedAccountQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.QueryHandler
{
    public class GetAllDynamicAssignedQueryHandler : IRequestHandler<GetAllDynamicAssignedQuery, List<GetAllAsignedDynamicAccount>>
    {
        private readonly IFSDH360 _fsdh360;

        public GetAllDynamicAssignedQueryHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public async Task<List<GetAllAsignedDynamicAccount>> Handle(GetAllDynamicAssignedQuery request, CancellationToken cancellationToken)
        {
            var data = new AllDynamicAssignedAccountResource
            {
                skip = request.skip,
                take = request.take,
                apiversion = request.apiversion
            };

            
            return await _fsdh360.AsignedDynamicAccount(request.skip,request.take,request.apiversion);
        }
    }
}
