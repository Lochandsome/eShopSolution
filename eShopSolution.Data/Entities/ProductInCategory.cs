using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class ProductInCategory
    {
        //ở đây thì bảng này sẽ liên kết khóa ngoại giữa 2 bảng là Product vs Category
        // với ID tham chiếu
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
