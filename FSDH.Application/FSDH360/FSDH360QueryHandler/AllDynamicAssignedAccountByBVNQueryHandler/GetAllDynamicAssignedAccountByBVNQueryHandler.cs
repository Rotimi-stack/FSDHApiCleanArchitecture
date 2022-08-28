using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.Query.AllDynamicAssignedAccountByBVN;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.QueryHandler.AllDynamicAssignedAccountByBVNQueryHandler
{
    public class GetAllDynamicAssignedAccountByBVNQueryHandler : IRequestHandler<GetAllDynamicAssignedAccountByBVNQuery, List<GetAllAsignedDynamicAccountBVN>>
    {
        private readonly IFSDH360 _fsdh360;

        public GetAllDynamicAssignedAccountByBVNQueryHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public async Task<List<GetAllAsignedDynamicAccountBVN>> Handle(GetAllDynamicAssignedAccountByBVNQuery request, CancellationToken cancellationToken)
        {
            var data = new AllDynamicAssignedAccountByBVNresources
            {
                skip = request.skip,
                take = request.take,
                apiversion = request.apiversion,
                BVN = request.BVN
            };
            return await _fsdh360.GetAllDynamicAssignedAccountByBVN(request.BVN, request.skip, request.take, request.apiversion);
        }
    }
}
