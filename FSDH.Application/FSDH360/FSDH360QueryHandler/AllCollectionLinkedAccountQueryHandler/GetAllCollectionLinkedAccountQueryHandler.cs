using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.Query.AllCollectionLinkedAccountQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.QueryHandler.AllCollectionLinkedAccountQueryHandler
{
    public class GetAllCollectionLinkedAccountQueryHandler : IRequestHandler<GetAllCollectionLinkedAccountQuery, List<GetAllCollectionLinkedAccount>>
    {
        private readonly IFSDH360 _fsdh360;
        public GetAllCollectionLinkedAccountQueryHandler( IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public async  Task<List<GetAllCollectionLinkedAccount>> Handle(GetAllCollectionLinkedAccountQuery request, CancellationToken cancellationToken)
        {
            var data = new GetAllCollectionLinkedAccountResources
            {
                AccountNumber = request.AccountNumber,
                apiversion = request.apiversion,
                skip = request.skip,
                take = request.take
            };
            return await _fsdh360.GetAllCollectionLinkedAccount(request.take, request.skip, request.apiversion, request.AccountNumber);

        }
    }
}
