using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Query.AllStaticAccountLinkedtoBVNQuery
{
    public class GetAllStaticAccountLinkedtoBVNQuery : IRequest<GetAllStaticAccountLinkedtoBVN>
    {
        public string apiversion { get; set; }
        public string BVN { get; set; }
    }
}
