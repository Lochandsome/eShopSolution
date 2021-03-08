using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalog.Products.Dtos.Manage // cái nào dùng chung thì chúng ta add thêm .Manage vào
{
    public class ProductCreateReqest
    {
        public decimal Price { set; get; }

        public decimal OriginalPrice { set; get; }

        public int Stock { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public string Details { set; get; }

        public string SeoDescription { set; get; }

        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }

        public string LanguageId { set; get; }

    }
}
