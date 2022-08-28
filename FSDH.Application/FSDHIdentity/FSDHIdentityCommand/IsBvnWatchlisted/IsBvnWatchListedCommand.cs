using FSDH.Application.Common.Models.FSDHIDENTITY;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.FSDHIdentity.FSDHIdentityCommand.IsBVNWatchlisted
{
   public class IsBvnWatchListedCommand : IRequest<IsBVNWatchListedResponses>
    {
        public string bvn { get; set; }
    }
}
