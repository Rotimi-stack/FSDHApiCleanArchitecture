using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDH360;
using FSDH.Application.Query.AllStaticAccountLinkedtoBVNQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSDH.Application.QueryHandler.AllStaticAccountLinkedtoBVNQueryHandler
{
    public class GetAllStaticAccountLinkedtoBVNQueryHandler : IRequestHandler<GetAllStaticAccountLinkedtoBVNQuery, GetAllStaticAccountLinkedtoBVN>
    {
        private readonly IFSDH360 _fsdh360;
        public GetAllStaticAccountLinkedtoBVNQueryHandler(IFSDH360 fsdh360)
        {
            _fsdh360 = fsdh360;
        }

        public Task<GetAllStaticAccountLinkedtoBVN> Handle(GetAllStaticAccountLinkedtoBVNQuery request, CancellationToken cancellationToken)
        {
            var data = new AllStaticAccountLinkedtoBVNResources
            {
                apiversion = request.apiversion,
                BVN = request.BVN
            };
            return _fsdh360.GetGetAllStaticAccountLinkedtoBVN(request.BVN, request.apiversion);
        }
    }
}
