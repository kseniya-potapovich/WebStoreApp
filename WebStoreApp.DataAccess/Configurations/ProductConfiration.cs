using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess.Configurations
{
    public class ProductConfiration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo").HasKey(x => x.Id);
            
            builder.HasKey(_ => _.Users).WithOne(_ => _.Products).HasForeignKey(_ => _.UserId);
        }
    }
}
