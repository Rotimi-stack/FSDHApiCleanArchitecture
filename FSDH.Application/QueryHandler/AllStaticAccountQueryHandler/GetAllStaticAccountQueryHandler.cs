using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.Query.AllStaticAccountQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.QueryHandler.AllStaticAccountQueryHandler
{
    public class GetAllStaticAccountQueryHandler : IRequestHandler<GetAllStaticAccountQuery, GetAllstaticAccount>
    {
        private readonly IFSDH360 _fsdh360;
        public GetAllStaticAccountQueryHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public async Task<GetAllstaticAccount> Handle(GetAllStaticAccountQuery request, CancellationToken cancellationToken)
        {
            var data = new GetAllStaticAccountResources
            {
                apiversion = request.apiversion,
                skip = request.skip,
                take = request.take
            };
            return await _fsdh360.GetAllstaticAccount(request.take, request.skip, request.apiversion);
        }
    }
}
