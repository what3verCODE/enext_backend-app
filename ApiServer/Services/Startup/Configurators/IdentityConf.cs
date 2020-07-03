using ApiServer.Services.Startup.Abstract;
using Application.Infrastructure.Persistence;
using Domain.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiServer.Services.Startup.Configurators
{
    public class IdentityConf : IStartupService
    {
        public void Configure(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddIdentityCore<UserEntity>()
                .AddEntityFrameworkStores<ApiDataContext>();
        }
    }
}