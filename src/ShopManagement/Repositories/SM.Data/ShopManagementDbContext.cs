using Microsoft.EntityFrameworkCore;
using SM.Data.Models;

namespace SM.Data
{
    public class ShopManagementDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}