using Microsoft.EntityFrameworkCore;
using ModShop.Entities;

namespace ModShop.Data
{
    public sealed class ModShopDbContext(DbContextOptions<ModShopDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}