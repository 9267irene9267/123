using MyFirstNetApi.Models;

namespace MyFirstNetApi.Repository
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetCustomers();

        void UpdateCustomer(Customer name);

        int AddCustomer(Customer name);

        void DeleteCustomer(long id);
    }
}