using FSDH.Application.Common.Models.FSDHIDENTITY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommand.VerifySingleBvn
{
   public class VerifySingleBvnCommand : IRequest<VerifySingleBVN>
    {
        public string bvn { get; set; }
    }
}
