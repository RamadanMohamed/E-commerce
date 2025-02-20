﻿using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Data.Config
{
    public class ProductConfigration : IEntityTypeConfiguration<product>
    {
        public void Configure(EntityTypeBuilder<product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.pictureUrl).IsRequired();
            builder.HasOne(b => b.producBrand).WithMany()
           .HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(t => t.ProdctType).WithMany()
           .HasForeignKey(p => p.productTypeId);
                
        }
    }
}
