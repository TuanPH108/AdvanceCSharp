using AdvanceCSharp.database;
using AdvanceCSharp.database.Model;
using AdvanceCSharp.dto.Products.Request;
using AdvanceCSharp.dto.Products.Response;

namespace AdvanceCSharp.service
{
    public class ProductsService
    {
        public static Task<GetProductResponse> GetProduct(GetProductRequest request)
        {
            GetProductResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Products? GetProduct = dbContext.Products.Where(product => product.Product_ID == request.Product_ID).FirstOrDefault();
                response.Product_ID = GetProduct.Product_ID;
                response.Product_Name = GetProduct.Product_Name;
                response.Product_Price = GetProduct.Product_Price;
                response.Product_Type = GetProduct.Product_Type;
            }
            return Task.FromResult(response);
        }

        public static Task<GetListProductResponse> GetListProduct(GetListProductRequest request)
        {
            GetListProductResponse response = new();
            using (AppDbContext dbContext = new())
            {
                List<Products> GetListProduct = [.. dbContext.Products.Where(product => product.Product_Name == request.Product_Name)];
                foreach (Products product in GetListProduct)
                {
                    response.ListProduct.Add(new GetProductResponse()
                    {
                        Product_ID = product.Product_ID,
                        Product_Name = product.Product_Name,
                        Product_Price = product.Product_Price,
                        Product_Type = product.Product_Type
                    });
                }
            }    
            return Task.FromResult(response);
        }

        public static Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request)
        {
            UpdateProductResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Products UpdateProduct = new()
                {
                    Product_ID = request.Product_ID,
                    Product_Name = request.Product_Name,
                    Product_Price = request.Product_Price,
                    Product_Type = request.Product_Type
                };  
                _ = dbContext.Products.Update(UpdateProduct);
                _ = dbContext.SaveChanges();

                Products? GetProduct = dbContext.Products.Where(p => p.Product_ID == request.Product_ID).FirstOrDefault();
                response.Product_ID = GetProduct.Product_ID;
                response.Product_Name = GetProduct.Product_Name;
                response.Product_Type = GetProduct.Product_Type;
                response.Product_Price = GetProduct.Product_Price;
            }
            return Task.FromResult(response);
        }

        public static Task<CreateProductResponse> CreateProduct(CreateProductRequest request)
        {
            CreateProductResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Products tmpProduct = new()
                {
                    Product_ID = request.Product_ID,
                    Product_Name = request.Product_Name,
                    Product_Price = request.Product_Price,
                    Product_Type = request.Product_Type
                };
                _= dbContext.Products.Add(tmpProduct);
                _ = dbContext.SaveChanges();

                Products? GetProduct = dbContext.Products.Where(p => p.Product_ID == request.Product_ID).FirstOrDefault();
                response.Product_ID = GetProduct.Product_ID;
                response.Product_Name = GetProduct.Product_Name;
                response.Product_Type = GetProduct.Product_Type;
                response.Product_Price = GetProduct.Product_Price;
            }
            return Task.FromResult(response);
        }

        public static Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request)
        {
            DeleteProductResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Products? FindedProduct = dbContext.Products.Find(request.Product_ID);
                _ = dbContext.Products.Remove(FindedProduct);
                _ = dbContext.SaveChanges();

                Products? GetProduct = dbContext.Products.Where(p => p.Product_ID == request.Product_ID).FirstOrDefault();
                response.Product_ID = Guid.Empty;
                response.Product_Name = "";
                response.Product_Type = "";
                response.Product_Price = 0;
            }
            return Task.FromResult(response);
        }
    }
}
