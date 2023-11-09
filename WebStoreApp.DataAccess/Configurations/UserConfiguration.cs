using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo").HasKey(x => x.Id);
            builder.HasKey(t => t.Products);
        }
    }
}
