using ApiServer.Filters;
using ApiServer.Services.CurrentUser;
using ApiServer.Services.Identity;
using ApiServer.Services.Startup.Abstract;
using Application.Common.Interfaces;
using Application.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ApiServer.Services.Startup.Configurators
{
    public class AspNetCoreConf : IStartupService
    {
        public void Configure(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddControllers(options => options.Filters.Add(new ApiFilter()))
                .AddNewtonsoftJson();
            
            services.AddHealthChecks()
                .AddDbContextCheck<ApiDataContext>();

            services.AddHttpContextAccessor();

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            
            services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
            });
        }
    }
}