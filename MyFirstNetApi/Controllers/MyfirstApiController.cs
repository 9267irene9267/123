using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstNetApi.Models;
using System.Reflection.Metadata.Ecma335;

namespace MyFirstNetApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MyfirstApiController : ControllerBase


    {

        private readonly TestContext _context;
        public MyfirstApiController(TestContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string Hello() => "Hello";

        [HttpGet]
        public Product[] GetProducts() => this._context.Products.ToArray();

        [HttpGet]
        public Student[] GetStudents() => this._context.Students.ToArray();

        [HttpPost]
        public string PostHello() => "Hello from POST";

        [HttpPut]
        public string PutHello() => "Hello from PUT";

        [HttpDelete]
        public string DeleteHello() => "Hello from DELETE";


    }
}
