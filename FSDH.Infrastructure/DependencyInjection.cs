using FSDH.Application.Common.Interfaces;
using FSDH.Infrastructure.ServiceIntegration.FSDH360;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IFSDH360, FSDH360Service>();
            return services;
        }

    }
}
