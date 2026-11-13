using Microsoft.EntityFrameworkCore;
using ModShop.Entities;

namespace ModShop.Data
{
    public sealed class ModShopDbContext(DbContextOptions<ModShopDbContext> options) : DbContext(options)
    {

    }
}