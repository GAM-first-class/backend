using Microsoft.EntityFrameworkCore;
using ModShop.Entities;
using ModShop.Entities.OrderAggregates;

namespace ModShop.Data
{
    public sealed class ModShopDbContext(DbContextOptions<ModShopDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}