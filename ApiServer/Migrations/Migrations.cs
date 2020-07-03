using System.Linq;
using Application.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace ApiServer.Migrations
{
    public static class Migrations
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<ApiDataContext>())
                {
                    if(context.Database.GetPendingMigrations().Any())
                        context.Database.Migrate();
                }
            }
        } 
    }
}