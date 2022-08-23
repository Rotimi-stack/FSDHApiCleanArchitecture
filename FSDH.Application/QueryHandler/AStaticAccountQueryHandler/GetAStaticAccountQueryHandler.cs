using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.Query.AStaticAccountQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.QueryHandler.AStaticAccountQueryHandler
{
    public class GetAStaticAccountQueryHandler : IRequestHandler<GetAStaticAccountQuery, GetAstaticAccount>
    {
        private readonly IFSDH360 _fsdh360;

        public GetAStaticAccountQueryHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public Task<GetAstaticAccount> Handle(GetAStaticAccountQuery request, CancellationToken cancellationToken)
        {
            var data = new GetAStaticAccountResources
            {
                apiversion = request.apiversion,
                AccountNumber = request.AccountNumber,
            };
            return _fsdh360.GetAStaticAccount(request.apiversion, request.AccountNumber);
        }
    }
}
