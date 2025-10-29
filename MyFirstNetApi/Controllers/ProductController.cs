using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstNetApi.Dto.Request;
using MyFirstNetApi.Services;
using NLog;

namespace MyFirstNetApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IProductService _IProductService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ICustomerService service, ILogger<ProductController> logger, IProductService iproductServie)
        {
            _service = service;
            _logger = logger;
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
            _logger.LogInformation("CreateProduct called with request: {@request}", request);
            return Ok(_IProductService.AddProduct(request));
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


