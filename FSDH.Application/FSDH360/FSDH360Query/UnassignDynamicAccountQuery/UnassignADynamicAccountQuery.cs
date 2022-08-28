using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Query.UnassignDynamicAccountQuery
{
   public class UnassignADynamicAccountQuery : IRequest<List<UnassignDynamicAccount>>
    {
        public string apiversion { get; set; }
        public string AccountNumber { get; set; }
    }
}
