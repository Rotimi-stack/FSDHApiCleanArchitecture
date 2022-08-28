using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.Query.ADynamicAccountQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.QueryHandler.ADynamicAccountQueryHandler
{
    public class GetADynamicAccountQueryHandler : IRequestHandler<GetADynamicAccountQuery, List<GetADynamicAccount>>
    {
        private readonly IFSDH360 _fsdh360;

        public GetADynamicAccountQueryHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public async Task<List<GetADynamicAccount>> Handle(GetADynamicAccountQuery request, CancellationToken cancellationToken)
        {
            var data = new ADynamicAcoountResources
            {
                apiversion = request.apiversion,
                AccountNumber = request.AccountNumber
            };
            return await _fsdh360.GetADynamicAccount(request.AccountNumber, request.apiversion);
        }
    }
}
