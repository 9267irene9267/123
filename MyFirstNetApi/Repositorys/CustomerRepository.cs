using MyFirstNetApi.Models;

namespace MyFirstNetApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TestContext _context;
        public CustomerRepository()
        {
            _context = new TestContext();

        }

        public int AddCustomer(Customer name)
        {
            _context.Customers.Add(name);
            return _context.SaveChanges();
        }

        public void DeleteCustomer(long id)
        {
            _context.Customers.Remove(_context.Customers.Find(id));
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public void UpdateCustomer(Customer name)
        {
            _context.Customers.Update(name);
        }

    }
}
