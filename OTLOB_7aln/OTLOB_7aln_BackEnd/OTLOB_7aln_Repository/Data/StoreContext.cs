using Microsoft.EntityFrameworkCore;
using OTLOB_7aln_Core.Entities;
using System.Reflection;

namespace OTLOB_7aln_Repository.Data
{
    public class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
    }
}
