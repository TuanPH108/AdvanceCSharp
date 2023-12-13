using AdvanceCSharp.database;
using AdvanceCSharp.database.Model;
using AdvanceCSharp.dto.Products.Request;
using AdvanceCSharp.dto.Products.Response;

namespace AdvanceCSharp.service
{
    public class ProductsService
    {
        public async Task<GetProductResponse> GetProduct(GetProductRequest request)
        {
            GetProductResponse response = new GetProductResponse();
            using(AppDbContext dbContext = new AppDbContext()) 
            {
                Products GetProduct = dbContext.Products.Where(product => product.Product_ID == request.Product_ID).FirstOrDefault();
                response.Product_ID = GetProduct.Product_ID;
                response.Product_Name = GetProduct.Product_Name;
                response.Product_Price = GetProduct.Product_Price;
                response.Product_Type = GetProduct.Product_Type;
            }
            return response;
        }

        public async Task<GetListProductResponse> GetListProduct(GetListProductRequest request)
        {
            GetListProductResponse response = new GetListProductResponse();
            using (AppDbContext dbContext = new AppDbContext())
            {
                List<Products> GetListProduct = dbContext.Products.Where(product => product.Product_Name == request.Product_Name).ToList();
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
            return response;
        }

        public async Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request)
        {
            UpdateProductResponse response = new UpdateProductResponse();
            using(AppDbContext dbContext = new AppDbContext()) 
            {
                Products UpdateProduct = new Products()
                {
                    Product_ID = request.Product_ID,
                    Product_Name = request.Product_Name,
                    Product_Price = request.Product_Price,
                    Product_Type = request.Product_Type
                };  
                _ = dbContext.Products.Update(UpdateProduct);
                _ = dbContext.SaveChanges();

                Products GetProduct = dbContext.Products.Where(p => p.Product_ID == request.Product_ID).FirstOrDefault();
                response.Product_ID = GetProduct.Product_ID;
                response.Product_Name = GetProduct.Product_Name;
                response.Product_Type = GetProduct.Product_Type;
                response.Product_Price = GetProduct.Product_Price;
            }
            return response;
        }

        public async Task<CreateProductResponse> CreateProduct(CreateProductRequest request)
        {
            CreateProductResponse response = new CreateProductResponse();
            using (AppDbContext dbContext = new AppDbContext()) 
            {
                Products tmpProduct = new Products()
                {
                    Product_ID = request.Product_ID,
                    Product_Name = request.Product_Name,
                    Product_Price = request.Product_Price,
                    Product_Type = request.Product_Type
                };
                _= dbContext.Products.Add(tmpProduct);
                _ = dbContext.SaveChanges();

                Products GetProduct = dbContext.Products.Where(p => p.Product_ID == request.Product_ID).FirstOrDefault();
                response.Product_ID = GetProduct.Product_ID;
                response.Product_Name = GetProduct.Product_Name;
                response.Product_Type = GetProduct.Product_Type;
                response.Product_Price = GetProduct.Product_Price;
            }
            return response;
        }

        public async Task<DeleteProductResponse> DeleteProduct (DeleteProductRequest request)
        {
            DeleteProductResponse response = new DeleteProductResponse();
            using (AppDbContext dbContext = new AppDbContext())
            {
                _ = dbContext.Products.Remove(dbContext.Products.Find(request.Product_ID));
                _ = dbContext.SaveChanges();

                Products GetProduct = dbContext.Products.Where(p => p.Product_ID == request.Product_ID).FirstOrDefault();
                response.Product_ID = GetProduct.Product_ID;
                response.Product_Name = GetProduct.Product_Name;
                response.Product_Type = GetProduct.Product_Type;
                response.Product_Price = GetProduct.Product_Price;
            }
            return response;
        }
    }
}
