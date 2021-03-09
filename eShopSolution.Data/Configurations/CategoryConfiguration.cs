using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        //h thì tiếp tục đặt khóa ngoại cho bảng category
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Gọi các API từ đối tượng entity để xây dựng bảng Product
            builder.ToTable("Categories");   // Tùy chọn tên của bảng là Categories(mặc định là ở bên Entity -> Category)

            builder.HasKey(x => x.Id); // Thiết lập User.Id là Pk

            // Vd : hasindex, ngoài ra còn có hasone
            // entity.HasIndex(p => p.UserName)     // Đánh chỉ mục UserName (user_name)
            //.IsUnique(true);               // Unique
            builder.Property(x => x.Id).UseIdentityColumn();
            //Để thiết lập thuộc tính (trường, cột) của một Model (bảng) thì đầu tiên phải lấy được đối tượng lớp
            //PropertyBuilder dành cho thuộc tính đó :

            builder.Property(x => x.Status).HasDefaultValue(Status.Active); // Lấy PropertyBuilder cho Status

             // HasColumnName tùy chọn đặt tên cột
             // HasColumnType tùy chọn thiết lập kiểu cột, ví dụ HasColumnType("varchar(20)")
            //HasDefaultValue thiết lập giá trị mặc định
            //HasMaxLength độ dài dữ liệu
            //IsRequired khác null
        }
    }
}
