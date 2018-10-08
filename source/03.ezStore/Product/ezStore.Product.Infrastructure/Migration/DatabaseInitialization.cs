using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ezStore.Product.Infrastructure.Migration
{
    public static class DatabaseInitialization
    {
        public static void InitializeDatabase(IServiceProvider services)
        {
            PerformMigrations(services);
            SeedData(services);
        }

        private static void PerformMigrations(IServiceProvider services)
        {
            services.GetRequiredService<ApplicationDbContext>().Database.Migrate();
        }

        private static void SeedData(IServiceProvider services)
        {
            //var context = services.GetRequiredService<ApplicationDbContext>();
        }
    }
}
