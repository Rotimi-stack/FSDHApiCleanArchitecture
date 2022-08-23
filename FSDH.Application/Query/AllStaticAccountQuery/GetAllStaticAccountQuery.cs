using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Query.AllStaticAccountQuery
{
    public class GetAllStaticAccountQuery : IRequest<GetAllstaticAccount>
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string apiversion { get; set; }

    }
}
