﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedStoreApp.Entities;

namespace WebStoreApp.DataAccess.Configurations
{
    public class SellerConfiration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers", "dbo").HasKey(x => x.Id);

        }
    }
}
