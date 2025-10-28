using MyFirstNetApi.Dto.Request;
using MyFirstNetApi.Dto.Response;
using MyFirstNetApi.Models;
using MyFirstNetApi.Repository;
using MyFirstNetApi.Services;

namespace YourProjectName.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _ICustomerRepository;
        private readonly iProductRepository _productRepository;

        public CustomerService(ICustomerRepository ICustomerRepository, iProductRepository productRepository)
        {
            _ICustomerRepository = ICustomerRepository;
            _productRepository = productRepository;
        }

        public ResponseBase  AddCustomer(CustomerRequest request)
        {
            var response = new ResponseBase();
            try
            {
                var count = _ICustomerRepository.AddCustomer(new Customer()
                {
                    Name = request.Name,
                    Email = request.Email,
                    Address = request.Address,
                    CreateDate = DateOnly.FromDateTime(DateTime.Now),
                    CreateUser = "System",
                    ModifyDate = DateOnly.FromDateTime(DateTime.Now),
                    ModifyUser = "System",

                    CustomerId = Guid.NewGuid().ToString().Substring(0, 10),

                });
                if (count > 0)
                {
                    response.Result = true;
                    response.Message = "Add Customer Success";
                }
                else
                {
                    response.Result = false;
                    response.Message = "Add Customer Fail";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                return response;
            }
            return response;
        }

        public List<Product> GetCustomerAllProduct(string name)
        {


            var customer = _ICustomerRepository.GetCustomers().Where(c => c.Name == name).FirstOrDefault();
            var list = _productRepository.GetProduct().Where(p => p.CustomerId == customer.CustomerId).ToList();
            return list;
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomersByEmail(string Email)
        {
            var customers = _ICustomerRepository.GetCustomers().ToList();
            return customers;
        }

        public List<Customer> GetCustomersByEmailLinq(string Email)
        {
            var customers = _ICustomerRepository.GetCustomers().ToList();
            return customers;
        }

        public List<Customer> GetCustomersByName(string name)
        {
            var customers = _ICustomerRepository.GetCustomers().ToList();
            return customers;
        }

        public List<Customer> GetCustomersByNameLinq(string name)
        {
            var customers = _ICustomerRepository.GetCustomers().ToList();
            return customers;
        }

        public ResponseBase UpdateCustomer(CustomerUpdateRequest request)
        {
            try
            {
                //抓取資料
                var entity = _ICustomerRepository.GetCustomers().Where(p => p.Id == request.Id).FirstOrDefault();
                //判斷資料是否存在
                if (entity == null)
                {
                    return new ResponseBase
                    {
                        Result = false,
                        Message = "Customer not found"
                    };
                }
                //更新資料
                entity.Name = request.Name;
                entity.Email = request.Email ;
                entity.Address = request.Address;
                //將 DateTime 轉換為 DateOnly
                entity.ModifyDate = DateOnly.FromDateTime(DateTime.Now);
                entity.ModifyUser = "System";

                //更新資料庫
                _ICustomerRepository.UpdateCustomer(entity);
            }
            catch (Exception ex)
            {
                return new ResponseBase
                {
                    Result = false,
                    Message = $"Error updating customer: {ex.Message}"
                };
            }
            //回傳成功結果
            return new ResponseBase
            {
                Result = true,
                Message = "Update customer success"
            };
        }
    }
}

