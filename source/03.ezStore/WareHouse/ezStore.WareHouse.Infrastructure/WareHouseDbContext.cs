using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ezStore.WareHouse.Infrastructure
{
    public class WareHouseDbContext : DbContext
    {
        public WareHouseDbContext(DbContextOptions<WareHouseDbContext> options)
             : base(options)
        {

        }

        public DbSet<ApplicationCore.Entities.Warehouse> WareHouses { get; set; }

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
