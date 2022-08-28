using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Query.AllDynamicUnAssignedQuery
{
   public class GetAllDynamicUnAssignedAccountQuery : IRequest<List<GetUnAssignedDynamicAccount>>
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string apiversion { get; set; }
    }
}
