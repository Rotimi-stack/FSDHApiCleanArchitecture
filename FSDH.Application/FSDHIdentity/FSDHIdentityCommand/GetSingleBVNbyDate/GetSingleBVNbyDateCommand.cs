using FSDH.Application.Common.Models.FSDHIDENTITY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommand.GetSingleBVNbyDate
{
    public class GetSingleBVNbyDateCommand : IRequest<GetSingleBVNbyDAteResponses>
    {
        public string bvn { get; set; }
        public DateTime birthDate { get; set; }
    }
}
