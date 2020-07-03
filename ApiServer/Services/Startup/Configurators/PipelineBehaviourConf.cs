using ApiServer.Services.Startup.Abstract;
using Application.Common.Behaviours;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiServer.Services.Startup.Configurators
{
    public class PipelineBehaviourConf : IStartupService
    {
        public void Configure(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddTransient(
                typeof(IPipelineBehavior<,>), 
                typeof(RequestPerformanceBehaviour<,>));
            
            services.AddTransient(
                typeof(IPipelineBehavior<,>), 
                typeof(RequestValidationBehaviour<,>));
            
            services.AddTransient(
                typeof(IPipelineBehavior<,>), 
                typeof(UnhandledExceptionBehaviour<,>));
        }
    }
}