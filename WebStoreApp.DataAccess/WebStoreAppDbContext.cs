using Microsoft.EntityFrameworkCore;
using WebStoreApp.DataAccess.Configurations;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess
{
    public class WebStoreAppDbContext : DbContext
    {
        public WebStoreAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiration());
           
        }
    }
}