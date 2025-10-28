using MyFirstNetApi.Models;

namespace MyFirstNetApi.Repository
{
    public interface iProductRepository
    {
        IQueryable<Product> GetProduct();

        void UpdateProduct(Product product);

        int AddProduct(Product product);

        void DeleteProduct(long id);
        object GetCustomer();
        void DeleteProduct(Product entity);
    }
}
