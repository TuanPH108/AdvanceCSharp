using AdvanceCSharp.database;
using AdvanceCSharp.database.Model;
using AdvanceCSharp.dto.Products.Request;
using AdvanceCSharp.dto.Products.Response;
using AdvanceCSharp.service.Interface;

namespace AdvanceCSharp.service
{
    public class ProductsService : IProductsService
    {
        public Task<GetProductResponse> Get(GetProductRequest request)
        {
            GetProductResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Products? getProduct = dbContext.Products.Where(product => product.ProductID == request.ProductID).FirstOrDefault();
                response.ProductID = getProduct.ProductID;
                response.ProductName = getProduct.ProductName;
                response.ProductPrice = getProduct.ProductPrice;
                response.ProductType = getProduct.ProductType;
            }
            return Task.FromResult(response);
        }

        public Task<GetListProductResponse> GetList(GetListProductRequest request)
        {
            GetListProductResponse response = new();
            using (AppDbContext dbContext = new())
            {
                List<Products> GetListProduct = [.. dbContext.Products.Where(product => product.ProductName == request.ProductName)];
                foreach (Products product in GetListProduct)
                {
                    response.ListProduct.Add(new GetProductResponse()
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductType = product.ProductType
                    });
                }
            }    
            return Task.FromResult(response);
        }

        public Task<UpdateProductResponse> Update(UpdateProductRequest request)
        {
            UpdateProductResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Products updateProduct = new()
                {
                    ProductID = request.ProductID,
                    ProductName = request.ProductName,
                    ProductPrice = request.ProductPrice,
                    ProductType = request.ProductType
                };  
                _ = dbContext.Products.Update(updateProduct);
                _ = dbContext.SaveChanges();

                Products? getProduct = dbContext.Products.Where(p => p.ProductID == request.ProductID).FirstOrDefault();
                response.ProductID = getProduct.ProductID;
                response.ProductName = getProduct.ProductName;
                response.ProductType = getProduct.ProductType;
                response.ProductPrice = getProduct.ProductPrice;
            }
            return Task.FromResult(response);
        }

        public Task<CreateProductResponse> Create(CreateProductRequest request)
        {
            CreateProductResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Products tempProduct = new()
                {
                    ProductID = request.ProductID,
                    ProductName = request.ProductName,
                    ProductPrice = request.ProductPrice,
                    ProductType = request.ProductType
                };
                _= dbContext.Products.Add(tempProduct);
                _ = dbContext.SaveChanges();

                Products? getProduct = dbContext.Products.Where(p => p.ProductID == request.ProductID).FirstOrDefault();
                response.ProductID = getProduct.ProductID;
                response.ProductName = getProduct.ProductName;
                response.ProductType = getProduct.ProductType;
                response.ProductPrice = getProduct.ProductPrice;
            }
            return Task.FromResult(response);
        }

        public Task<DeleteProductResponse> Delete(DeleteProductRequest request)
        {
            DeleteProductResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Products? findProduct = dbContext.Products.Find(request.ProductID);
                _ = dbContext.Products.Remove(findProduct);
                _ = dbContext.SaveChanges();
            }
            response.ProductID = Guid.Empty;
            response.ProductName = "";
            response.ProductType = "";
            response.ProductPrice = 0;
            return Task.FromResult(response);
        }
    }
}
