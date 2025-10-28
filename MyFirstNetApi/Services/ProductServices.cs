using MyFirstNetApi.Dto.Request;
using MyFirstNetApi.Dto.Response;
using MyFirstNetApi.Models;
using MyFirstNetApi.Repository;

namespace MyFirstNetApi.Services
{
    public class ProductService : IProductService
    {
        private readonly iProductRepository _productRepository;

        public ProductService(iProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ResponseBase AddProduct(ProductRequest request)
        {
            var response = new ResponseBase();
            try
            {
                var count = _productRepository.AddProduct(new Product
                {
                    Name = request.Name,
                    Price = request.Price ?? 0,
                    Description = request.Description,
                    CustomerId = request.CustomerId,
                    CreateDate = DateTime.Now,
                    CreateUser = "System",
                    ModifyDate = DateTime.Now,
                    ModifyUser = "System",
                });
                if (count > 0)
                {
                    response.Result = true;
                    response.Message = "Add Product Success";
                }
                else
                {
                    response.Result = false;
                    response.Message = "Add Product Fail";
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

        public ResponseBase addProduct(ProductRequest product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProduct().ToList();

        }

        public List<Product> GetProductsByName(string name)
        {
            var list = _productRepository.GetProduct().Where(p => p.Name == name).ToList();

            return list;
        }

        public List<Product> GetProductsByNameLinq(string name)
        {
            var query = from p in _productRepository.GetProduct()
                        where p.Name == name
                        select p;
            return query.ToList();
        }

        public List<Product> GetProductsByPrice(int price)
        {
            var list = _productRepository.GetProduct().Where(p => p.Price < price).ToList();
            return list;
        }

        public List<Product> GetProductsByPriceLinq(int price)
        {
            var query = from p in _productRepository.GetProduct()
                        where p.Price < price
                        select p;
            return query.ToList();
        }

        public ResponseBase UpdateProduct(ProductUpdateRequest request)
        {
            try
            {
                //抓取資料
                var entity = _productRepository.GetProduct().Where(p => p.Id == request.Id).FirstOrDefault();
                //判斷資料是否存在
                if (entity == null)
                {
                    return new ResponseBase
                    {
                        Result = false,
                        Message = "Product not found"
                    };
                }
                //更新資料
                entity.Name = request.Name;
                entity.Price = request.Price ?? 0;
                entity.Description = request.Description;
                entity.ModifyDate = DateTime.Now;
                entity.ModifyUser = "System";
                //更新資料庫
                _productRepository.UpdateProduct(entity);
            }
            catch (Exception ex)
            {
                return new ResponseBase
                {
                    Result = false,
                    Message = $"Error updating product: {ex.Message}"
                };
            }
            //回傳成功結果
            return new ResponseBase
            {
                Result = true,
                Message = "Update product success"
            };
        }

        public ResponseBase DeleteProduct(int id)
        {
            try
            {
                // 1️ 先抓資料
                var entity = _productRepository.GetProduct().FirstOrDefault(p => p.Id == id);

                // 2️ 判斷資料是否存在
                if (entity == null)
                {
                    return new ResponseBase
                    {
                        Result = false,
                        Message = "Product not found"
                    };
                }

                // 3️ 呼叫 Repository 執行刪除
                _productRepository.DeleteProduct(entity);
            }
            catch (Exception ex)
            {
                return new ResponseBase
                {
                    Result = false,
                    Message = $"Error deleting product: {ex.Message}"
                };
            }

            // 4️ 回傳成功結果
            return new ResponseBase
            {
                Result = true,
                Message = "Delete product success"
            };
        }

        object? IProductService.DeleteProduct(int id)
        {
            return DeleteProduct(id);
        }
    }
}
