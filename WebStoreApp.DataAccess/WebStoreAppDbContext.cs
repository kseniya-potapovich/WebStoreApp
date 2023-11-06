using Microsoft.EntityFrameworkCore;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess
{
    public class WebStoreAppDbContext : DbContext
    {
        public WebStoreAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}