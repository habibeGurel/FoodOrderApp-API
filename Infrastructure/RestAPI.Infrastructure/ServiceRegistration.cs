using Microsoft.Extensions.DependencyInjection;
using RestAPI.Application.Services;
using RestAPI.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInftastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileService, FileService>();
        }
    }
}
