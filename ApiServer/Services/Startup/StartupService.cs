using System;
using System.Linq;
using ApiServer.Services.Startup.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiServer.Services.Startup
{
    public static class StartupService
    {
        public static void ConfigureServices(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment env)
        {
            var configs = typeof(ApiServer.Startup).Assembly.ExportedTypes
                .Where(x => typeof(IStartupService).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IStartupService>().ToList();

            configs.ForEach(config => config.Configure(services, configuration, env));
        }
    }
}