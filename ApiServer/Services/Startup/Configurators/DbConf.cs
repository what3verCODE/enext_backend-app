using ApiServer.Services.Startup.Abstract;
using Application.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiServer.Services.Startup.Configurators
{
    public class DbConf : IStartupService
    {
        public void Configure(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddDbContext<ApiDataContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString(env.IsDevelopment() ? "LocalConnection" : "DeployConnection"), 
                    o => o.MigrationsAssembly("ApiServer")
                    );
                options.EnableSensitiveDataLogging();
            });
        }
    }
}