using ezStore.Product.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ezStore.Product.Infrastructure
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
             : base(options)
        {

        }

        public DbSet<ApplicationCore.Entities.Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductCategoryMapping> ProductCategoryMappings { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<ProductTapMapping> ProductTapMappings { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<ProductManufactureMapping> ProductManufactureMappings { get; set; }


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
