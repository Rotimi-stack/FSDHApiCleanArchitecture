using FSDH.Application.Common.Models.FSDHIDENTITY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommand.VerifySingleBvnbyDate
{
    public class VerifySingleBvnbyDateCommand : IRequest<VerifySingleBVNbyDate>
    {
        public string bvn { get; set; }
        public DateTime birthDate { get; set; }
    }
}
