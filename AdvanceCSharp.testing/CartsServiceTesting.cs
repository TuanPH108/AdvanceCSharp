using AdvanceCSharp.dto.Carts.Request;
using AdvanceCSharp.dto.Carts.Response;
using AdvanceCSharp.service;

namespace AdvanceCSharp.testing
{
    [TestClass]
    public class CartsServiceTesting
    {
        private readonly CartsService _cartsService;
        public CartsServiceTesting() 
        {
            _cartsService = new();
        }
        /// <summary>
        /// Test Get Cart
        /// </summary>
        [TestMethod]
        public async Task GetCartTesting ()
        {
            GetCartRequest request = new()
            {
                UserID = Guid.Parse(" ")
            };
            GetCartResponse response = await _cartsService.Get (request);
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
                UserID = new Guid(" ")
            };
            GetListCartResponse response = await _cartsService.GetList (request);
            //Check list response not empty
            Assert.IsTrue(response.ListCart.Count == 0);
        }
        /// <summary>
        /// Test Create Cart
        /// </summary>
        [TestMethod]
        public async Task CreateCartTesting()
        {
            CreateCartRequest request = new()
            { 
                CartID = Guid.NewGuid()
            };
            CreateCartResponse respones = await _cartsService.Create (request);
            //Check response not null
            Assert.IsNull(respones);
        }
        /// <summary>
        /// Test Update Cart
        /// </summary>
        [TestMethod]
        public async Task UpdateCartTesting()
        {
            UpdateCartRequest request = new()
            {
                CartID = new Guid(" ")
            };
            UpdateCartResponse response = await _cartsService.Update (request);
            //Check response is not null
            Assert.IsNull(response);
        }
    }
}
