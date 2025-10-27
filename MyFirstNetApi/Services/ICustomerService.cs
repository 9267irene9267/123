using MyFirstNetApi.Dto.Request;
using MyFirstNetApi.Dto.Response;
using MyFirstNetApi.Models;

namespace MyFirstNetApi.Services
{
    public interface ICustomerService
    {
        List<Product> GetCustomerAllProduct(string name);
        List<Customer> GetCustomersByEmail(string Email);


        List<Customer> GetCustomersByName(string name);

        List<Customer> GetCustomersByEmailLinq(string Email);


        List<Customer> GetCustomersByNameLinq(string name);

        Customer GetCustomerById(int id);

        // 新增此方法
        ResponseBase AddCustomer(CustomerRequest request);
    }
}
