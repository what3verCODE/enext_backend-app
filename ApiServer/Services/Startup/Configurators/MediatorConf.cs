using ApiServer.Services.Startup.Abstract;
using Application.Common;
using Microsoft.Extensions.Configuration;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ApiServer.Services.Startup.Configurators
{
    public class MediatorConf : IStartupService
    {
        public void Configure(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddMediatR(DependencyInjection.GetAssembly);
        }
    }
}