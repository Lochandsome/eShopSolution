using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using eShopSolution.Application.Dtos;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        // nếu dùng task<int> thì có thể tận dụng xử lí nhiều reques cùng lúc
        // phần này chỉ có thêm sửa xóa thôi
        Task<int> Create(ProductCreateReqest reqest);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int ProductId, int addQuantity);

        Task AddViewCount(int productId);

        // truyền vào keyword để tìm kiếm, pageindex hiển thị thứ tự trang và pagesize kích cỡ của 1 trang
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}
