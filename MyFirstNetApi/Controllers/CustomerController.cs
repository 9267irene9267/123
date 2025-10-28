using Microsoft.AspNetCore.Mvc;
using MyFirstNetApi.Dto.Request;
using MyFirstNetApi.Services;

namespace MyFirstNetApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public CustomerController(ICustomerService customerService, IProductService productService)
        {
            _customerService = customerService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetCustomer(string name)
        {
            var customers = _customerService.GetCustomerAllProduct(name);
            if (customers == null || customers.Count == 0)
                return NotFound("目前沒有客戶資料");

            return Ok(customers);
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound($"找不到 Id = {id} 的客戶");

            return Ok(customer);
        }

        [HttpGet]
        public IActionResult GetCustomerProducts(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("name 參數不可為空");

            var products = _customerService.GetCustomerAllProduct(name);
            if (products == null || products.Count == 0)
                return NotFound("查無此客戶或該客戶沒有產品資料");

            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerRequest request)
        {
            return Ok(_customerService.AddCustomer(request));

        }

        [HttpPut]
        public IActionResult UpdateCustomer(CustomerUpdateRequest request)
        {
            return Ok(_customerService.UpdateCustomer(request));
        }

        }
    }

  
