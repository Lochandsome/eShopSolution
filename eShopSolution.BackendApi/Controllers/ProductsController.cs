using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;

        public ProductsController(IPublicProductService publicProductService, 
            IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        // tại là nếu để 2 cái đứa httpget thì nó k đc nên phải truyền thêm tham sô vô thì nó sẽ như này, nó sẽ k bị trùng
        //http://localhost:port/product/public-paging
        [HttpGet("{languageId}")]
        public async Task<IActionResult> Get(string languageId, [FromQuery]GetPublicProductPagingRequest request)
        {//FROMQUERY là tất cá các tham số Get...PagingRequest là nó lấy từ query ra
            var products = await _publicProductService.GetAllByCategoryId(languageId, request);
            return Ok(products);
        }

        //http://localhost:port/product/1
        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(int id, string languageId)
        {
            var product = await _manageProductService.GetById(id, languageId);
            if (product == null)
                return BadRequest("Cannot Find Product");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductCreateReqest request)
        {
            var productId = await _manageProductService.Create(request);
            if (productId == 0)
                return BadRequest(); // báo lỗi 400

            var product = await _manageProductService.GetById(productId, request.LanguageId);
             
            return CreatedAtAction(nameof(GetById),new {ID = productId }, productId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]ProductUpdateRequest request)
        {
            var affectResult = await _manageProductService.Update(request);
            if (affectResult == 0)
                return BadRequest(); // báo lỗi 400
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectResult = await _manageProductService.Delete(id);
            if (affectResult == 0)
                return BadRequest(); // báo lỗi 400
            return Ok();
        }

        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id,  decimal newPrice)
        {
            var isSucessful = await _manageProductService.UpdatePrice(id, newPrice);
            if (isSucessful)
                return Ok(); 

            return BadRequest();
        }
    }
}
