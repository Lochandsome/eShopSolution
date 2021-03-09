using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        // cái này thì chũng ta sẽ cầu hình config cho thằng product
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            // x là cái biến đại diện cho bảng với đối tượng product r chấm .id hay jj đó
            // có thể đặt là x hay s b c t jj đó
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.OriginalPrice).IsRequired();

            builder.Property(x => x.Stock).IsRequired().HasDefaultValue(0);

            builder.Property(x => x.ViewCount).IsRequired().HasDefaultValue(0);

           
        }
    }
}
