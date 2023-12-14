using AdvanceCSharp.dto.Carts.Request;
using AdvanceCSharp.dto.Carts.Response;
using AdvanceCSharp.service;

namespace AdvanceCSharp.testing
{
    [TestClass]
    public class CartsServiceTesting
    {
        private readonly CartsService _CartsService;
        public CartsServiceTesting() 
        {
            _CartsService = new();
        }
        /// <summary>
        /// Test Get Cart
        /// </summary>
        [TestMethod]
        public async Task GetCartTesting ()
        {
            GetCartRequest request = new()
            {
                User_ID = Guid.Parse(" ")
            };
            GetCartResponse response = await _CartsService.GetCart (request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
        /// <summary>
        /// Test Get Cart (List)
        /// </summary>
        [TestMethod]
        public async Task GetListCartTesting()
        {
            GetListCartRequest request = new()
            {
                User_ID = new Guid(" ")
            };
            GetListCartResponse response = await _CartsService.GetListCart (request);
            //Check list response is not null
            Assert.IsNotNull(response);
            //Check list response not empty
            Assert.IsTrue(response.ListCart.Count > 0);
        }
        /// <summary>
        /// Test Create Cart
        /// </summary>
        [TestMethod]
        public async Task CreateCartTesting()
        {
            CreateCartRequest request = new()
            { 
                Cart_ID = Guid.NewGuid()
            };
            CreateCartResponse respones = await _CartsService.CreateCart (request);
            //Check response not null
            Assert.IsNotNull(respones);
        }
        /// <summary>
        /// Test Update Cart
        /// </summary>
        [TestMethod]
        public async Task UpdateCartTesting()
        {
            UpdateCartRequest request = new()
            {
                Cart_ID = new Guid(" ")
            };
            UpdateCartResponse response = await _CartsService.UpdateCart (request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
        /// <summary>
        /// Test Delete Cart
        /// </summary>
        [TestMethod]
        public async Task DeleteCartTesting()
        {
            DeleteCartRequest request = new()
            {
                Cart_ID = new Guid(" ")
            };
            DeleteCartResponse response = await _CartsService.DeleteCart(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
    }
}
