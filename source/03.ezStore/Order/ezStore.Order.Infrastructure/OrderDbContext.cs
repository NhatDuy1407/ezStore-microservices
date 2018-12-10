using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ezStore.Order.Infrastructure
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
             : base(options)
        {

        }

        public DbSet<ezStore.Order.ApplicationCore.Entities.Order> WareHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // remove plural name of table
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
        }
    }
}
