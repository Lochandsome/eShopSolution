using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Category
    {
        //những cái mà chúng ta tạo dưới đây có thể hiểu nó là Fluent API
        //ta sẽ dùng Fluent API để thiết lập.
        //Đưa lớp này vào ShopContext, bằng cách thêm "public DbSet<User> users {set; get;}" ở bên EShpDbContext

        public int Id { set; get; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public int? ParentId { set; get; }
        public Status Status { set; get; }

        public List<ProductInCategory> ProductInCategories { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
