using AdvanceCSharp.service;
using AdvanceCSharp.dto.Products.Request;
using AdvanceCSharp.dto.Products.Response;

namespace AdvanceCSharp.testing
{
    [TestClass]
    public class ProductsServiceTesting
    {
        private readonly ProductsService _ProductsService;

        public ProductsServiceTesting()
        {
            _ProductsService = new ProductsService();
        }
        /// <summary>
        /// Test Get Product
        /// </summary>
        [TestMethod]
        public async Task GetProductTesting()
        {
            GetProductRequest request = new()
            {
                Product_ID = Guid.Parse("1CF6EA52-47A0-46AC-7C07-08DBF891BB00")
            };
            GetProductResponse response = await _ProductsService.GetProduct(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
        [TestMethod]
        public async Task GetListProductTesting()
        {
            GetListProductRequest request = new()
            {
                Product_Name = "Macbook"
            };
            GetListProductResponse response = await _ProductsService.GetListProduct(request);
            //Check response is not null
            Assert.IsNotNull(response);
            //Check Response 1 list of product
            Assert.IsTrue(response.ListProduct.Count > 0);
        }
        [TestMethod]
        public async Task CreateProductTesting()
        {
            CreateProductRequest createProductRequest = new()
            {
                Product_ID = Guid.NewGuid()
            };
            CreateProductRequest request = createProductRequest;
            CreateProductResponse response = await _ProductsService.CreateProduct(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
        [TestMethod]
        public async Task UpdateProductTesting()
        {
            UpdateProductRequest request = new()
            {
                Product_ID = Guid.Parse("F05C7BF8-B542-48D6-7C0A-08DBF891BB00")
            };
            UpdateProductResponse response = await _ProductsService.UpdateProduct(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
        [TestMethod]
        public async Task DeleteProductTesting()
        {
            DeleteProductRequest request = new()
            {
                Product_ID = Guid.Parse("A38BA0FE-F6A9-413D-7C11-08DBF891BB00")
            };
            DeleteProductResponse response = await _ProductsService.DeleteProduct(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
    }
}
