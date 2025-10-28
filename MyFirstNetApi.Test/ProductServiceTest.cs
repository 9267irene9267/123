using Moq;
using MyFirstNetApi.Models;
using MyFirstNetApi.Repository;
using MyFirstNetApi.Services;

namespace MyFirstNetApi.Test;

public class ProductServiceTest
{
    private Mock<iProductRepository> _mockRepository;
    private ProductService _service;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<iProductRepository>();
        _service = new ProductService(_mockRepository.Object);
    }
    [Test]
    public void TestGetProduct()
    {
        //測試資料
        var testDatas = new List<Product>();
        testDatas.Add(new Product{ Id=1, Name="TestProduct", Price=100, Description="Test Description" });
        testDatas.Add(new Product { Id = 2, Name = "TestProduct", Price = 200, Description = "Test Description" });

        _mockRepository.Setup(repo => repo.GetProduct()).Returns(testDatas.AsQueryable());
        Assert.IsTrue(_service.GetProducts().ToArray().Length>0);
    }

}
