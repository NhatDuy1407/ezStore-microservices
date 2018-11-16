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
        }

        private static void PerformMigrations(IServiceProvider services)
        {
            services.GetRequiredService<ProductDbContext>().Database.Migrate();
        }
    }
}
