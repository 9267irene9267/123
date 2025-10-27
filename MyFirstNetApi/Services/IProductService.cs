using MyFirstNetApi.Dto.Request;
using MyFirstNetApi.Dto.Response;
using MyFirstNetApi.Models;

namespace MyFirstNetApi.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        ResponseBase addProduct(ProductRequest product);
        ResponseBase UpdateProduct(ProductUpdateRequest request);
        List<Product> GetProductsByPrice(int price);

        List<Product> GetProductsByName(string name);

        List<Product> GetProductsByPriceLinq(int price);


        List<Product> GetProductsByNameLinq(string name);
    }
}
