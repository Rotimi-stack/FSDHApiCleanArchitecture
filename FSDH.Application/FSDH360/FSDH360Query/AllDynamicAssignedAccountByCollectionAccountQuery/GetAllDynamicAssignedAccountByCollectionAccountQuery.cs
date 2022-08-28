using FSDH.Application.Common.Models.FSDH360;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FSDH.Application.Query.AllDynamicAssignedAccountByCollectionAccountQuery
{
   public  class GetAllDynamicAssignedAccountByCollectionAccountQuery : IRequest<List<GetAllAsignedDynamicAcciountByCollectionAccount>>
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string apiversion { get; set; }
        [Required]
        public string AccountNumber { get; set; }
    }
}
