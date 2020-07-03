using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiServer.Services.Startup.Abstract
{
    public interface IStartupService
    {
        void Configure(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env);
    }
}