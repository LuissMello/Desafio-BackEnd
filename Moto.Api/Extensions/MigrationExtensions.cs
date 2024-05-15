using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Api.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using MotoDbContext context = scope.ServiceProvider.GetRequiredService<MotoDbContext>();

            context.Database.Migrate();
        }
    }
}
