using ApiServer.Services.Startup.Abstract;
using Application.Common;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiServer.Services.Startup.Configurators
{
    public class AutoMapperConf : IStartupService
    {
        public void Configure(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddAutoMapper(DependencyInjection.GetAssembly);
        }
    }
}