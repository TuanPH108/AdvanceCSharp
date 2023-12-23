using AdvanceCSharp.dto.Orders.Request;
using AdvanceCSharp.dto.Orders.Response;
using AdvanceCSharp.service;

namespace AdvanceCSharp.testing
{
    [TestClass]
    public class OrdersServiceTesting
    {
            private readonly OrdersService _ordersService;

            public OrdersServiceTesting()
            {
                _ordersService = new();
            }
            /// <summary>
            /// Test Get Order
            /// </summary>
            [TestMethod]
            public async Task GetOrderTesting()
            {
                GetOrderRequest request = new()
                {
                    OrderID = Guid.Parse(" ")
                };
                GetOrderResponse response = await _ordersService.Get(request);
                //Check response is not null
                Assert.IsNull(response);
            }
            /// <summary>
            /// Test Get Order (List)
            /// </summary>
            [TestMethod]
            public async Task GetListOrderTesting()
            {
            GetListOrderRequest request = new()
            {
                UserId = Guid.Parse(" ")
                };
                GetListOrderResponse response = await _ordersService.GetList(request);
                //Check Response 1 list of order
                Assert.IsTrue(response.ListOrder.Count == 0);
            }
            /// <summary>
            /// Test Create
            /// </summary>
            [TestMethod]
            public async Task CreateOrderTesting()
            {
                CreateOrderRequest request = new()
                {
                    OrderID = Guid.NewGuid()
                };
                CreateOrderResponse response = await _ordersService.Create(request);
                //Check response is not null
                Assert.IsNotNull(response);
                }
            /// <summary>
            /// Test Update
            /// </summary>
            [TestMethod]
            public async Task UpdateOrderTesting()
            {
                UpdateOrderRequest request = new()
                {
                    OrderID = Guid.Parse(" ")
                };
                UpdateOrderResponse response = await _ordersService.Update(request);
                //Check response is not null
                Assert.IsNull(response);
            }
        }
    }
