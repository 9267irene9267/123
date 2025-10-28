using Microsoft.AspNetCore.Mvc;
using MyFirstNetApi.Dto.Request;
using MyFirstNetApi.Services;

namespace MyFirstNetApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IProductService _IProductService;


        public ProductController(IProductService iproductServie)
        {
            _IProductService = iproductServie;
        }

        [HttpGet]
        public IActionResult GetCustomerAllProduct(string name)
        {
            var products = _service.GetCustomerAllProduct(name);

            if (products == null || products.Count == 0)
                return NotFound("查無此客戶或該客戶沒有產品資料");

            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductRequest request)
        {
            return Ok(_IProductService.addProduct(request));
        }
        [HttpPut]
        public IActionResult UpdateProduct(ProductUpdateRequest request)
        {
            return Ok(_IProductService.UpdateProduct(request));

        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            return Ok(_IProductService.DeleteProduct(id));
        }
    }
}


