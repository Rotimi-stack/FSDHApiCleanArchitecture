using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.Query.UnassignDynamicAccountQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.QueryHandler.UnassignDynamicAccountQueryHandler
{
    public class UnAssignaDynamicAccountQueryHandler : IRequestHandler<UnassignADynamicAccountQuery, List<UnassignDynamicAccount>>
    {
        private readonly IFSDH360 _fsdh360;

        public UnAssignaDynamicAccountQueryHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }
        public Task<List<UnassignDynamicAccount>> Handle(UnassignADynamicAccountQuery request, CancellationToken cancellationToken)
        {
            var data = new UnassignDynamicAccountResources
            {
                apiversion = request.apiversion,
                AccountNumber = request.AccountNumber
            };
            return _fsdh360.UnAssignDynamicAccount(request.AccountNumber, request.apiversion);
        }
    }
}
