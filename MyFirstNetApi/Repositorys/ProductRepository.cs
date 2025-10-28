using Microsoft.EntityFrameworkCore;
using MyFirstNetApi.Models;

namespace MyFirstNetApi.Repository
{
    public class ProductRepository : iProductRepository

    {
        private readonly TestContext _TestContext;
        public ProductRepository(TestContext testContext)
        {
            _TestContext = new TestContext();

        }

        public int AddProduct(Product product)
        {
            _TestContext.Products.Add(product);
            return _TestContext.SaveChanges();
        }

        public void DeleteProduct(long productId)
        {
            _TestContext.Products.Remove(new Product { Id = productId });
        }

        public object GetCustomer()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetProduct()
        {
            return _TestContext.Products.AsQueryable();
        }

        public void UpdateProduct(Product product)
        {
            _TestContext.Products.Update(product);
            _TestContext.SaveChanges();
        }

    
        public void DeleteProduct(Product product)
        {
            _TestContext.Products.Remove(product);
            _TestContext.SaveChanges();
        }

    }
}
