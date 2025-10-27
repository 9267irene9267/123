using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstNetApi.Models;
using MyFirstNetApi.Repository;
using MyFirstNetApi.Services;
using System.Reflection.Metadata.Ecma335;

namespace MyFirstNetApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MyfirstApiController : ControllerBase

    {
        private readonly IProductService _productService;
        public MyfirstApiController(IProductService productService)
        {
            this._productService = productService;
        }
        
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);

        }

        [HttpGet]
        public IActionResult GetProductsByName(string name)
        {
            var products = _productService.GetProductsByName(name);
            return Ok(products);
        }

        [HttpGet]
        public IActionResult GetProductsByNameLinq(string name)
        {
            var products = _productService.GetProductsByNameLinq(name);
            return Ok(products);
        }

        [HttpGet]
        public IActionResult GetProductByPrice(int price)
        {
            var products = _productService.GetProductsByPrice(price);
            return Ok(products);
        }

    }
}
