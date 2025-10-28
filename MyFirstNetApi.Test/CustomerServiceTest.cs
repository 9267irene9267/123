using Castle.Core.Resource;
using Moq;
using MyFirstNetApi.Models;
using MyFirstNetApi.Repository;
using MyFirstNetApi.Services;
using YourProjectName.Services;

namespace MyFirstNetApi.Test;

public class CustomerServiceTest
{
    private Mock<ICustomerRepository> _mockRepository;
    private Mock<iProductRepository> _mockProductRepository;

    private CustomerService _service;
    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<ICustomerRepository>();
        _mockProductRepository = new Mock<iProductRepository>();
        _service = new CustomerService(_mockRepository.Object, _mockProductRepository.Object);
    }

    [Test]
    public void Test1()
    {
        //測試資料
        var testDatas = new List<Customer>();
        testDatas.Add(new Customer { Id = 1, Name = "TestCustomer1", Email = "@", Address = "Test Address" });
        testDatas.Add(new Customer { Id = 2, Name = "TestCustomer2", Email = "@@", Address = "Test Address" });

        _mockRepository.Setup(repo => repo.GetCustomers()).Returns(testDatas.AsQueryable());
        Assert.IsTrue(_service.GetCustomersByName("TestCustomer").ToArray().Length > 0);

    }
}
