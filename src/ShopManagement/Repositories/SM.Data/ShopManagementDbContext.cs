using Microsoft.EntityFrameworkCore;
using SM.Data.Models;

namespace SM.Data
{
    public class ShopManagementDbContext : DbContext
    {
        public ShopManagementDbContext(DbContextOptions<ShopManagementDbContext> options) : base(options) { }
        
        //All entities from Database as DBsets
        public DbSet<Product> Products { get; set; }
    }
}