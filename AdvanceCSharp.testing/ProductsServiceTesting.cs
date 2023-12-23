using AdvanceCSharp.service;
using AdvanceCSharp.dto.Products.Request;
using AdvanceCSharp.dto.Products.Response;

namespace AdvanceCSharp.testing
{
    [TestClass]
    public class ProductsServiceTesting
    {
        private readonly ProductsService _productsService;

        public ProductsServiceTesting()
        {
            _productsService = new ProductsService();
        }
        /// <summary>
        /// Test Get Product
        /// </summary>
        [TestMethod]
        public async Task GetProductTesting()
        {
            GetProductRequest request = new()
            {
                ProductID = Guid.Parse("1CF6EA52-47A0-46AC-7C07-08DBF891BB00")
            };
            GetProductResponse response = await _productsService.Get(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
        /// <summary>
        /// Test Get List Product
        /// </summary>
        [TestMethod]
        public async Task GetListProductTesting()
        {
            GetListProductRequest request = new()
            {
                ProductName = "Macbook"
            };
            GetListProductResponse response = await _productsService.GetList(request);
            //Check response is not null
            Assert.IsNotNull(response);
            //Check Response 1 list of product
            Assert.IsTrue(response.ListProduct.Count > 0);
        }
        /// <summary>
        /// Test Create Product
        /// </summary>
        [TestMethod]
        public async Task CreateProductTesting()
        {
            CreateProductRequest request = new()
            {
                ProductID = Guid.NewGuid()
            };
            CreateProductResponse response = await _productsService.Create(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
        /// <summary>
        /// Test Update Product
        /// </summary>
        [TestMethod]
        public async Task UpdateProductTesting()
        {
            UpdateProductRequest request = new()
            {
                ProductID = Guid.Parse("F05C7BF8-B542-48D6-7C0A-08DBF891BB00")
            };
            UpdateProductResponse response = await _productsService.Update(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
    }
}
