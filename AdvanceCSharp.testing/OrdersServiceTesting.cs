using AdvanceCSharp.dto.Orders.Request;
using AdvanceCSharp.dto.Orders.Response;
using AdvanceCSharp.service;

namespace AdvanceCSharp.testing
{
    [TestClass]
    public class OrdersServiceTesting
    {
            private readonly OrdersService _OrdersService;

            public OrdersServiceTesting()
            {
                _OrdersService = new();
            }
            /// <summary>
            /// Test Get Order
            /// </summary>
            [TestMethod]
            public async Task GetOrderTesting()
            {
                GetOrderRequest request = new()
                {
                    Order_ID = Guid.Parse(" ")
                };
                GetOrderResponse response = await _OrdersService.GetOrder(request);
                //Check response is not null
                Assert.IsNotNull(response);
            }
            /// <summary>
            /// Test Get Order (List)
            /// </summary>
            [TestMethod]
            public async Task GetListOrderTesting()
            {
            GetListOrderRequest request = new()
            {
                User_Id = Guid.Parse(" ")
                };
                GetListOrderResponse response = await _OrdersService.GetListOrder(request);
                //Check response is not null
                Assert.IsNotNull(response);
                //Check Response 1 list of order
                Assert.IsTrue(response.ListOrder.Count > 0);
            }
            /// <summary>
            /// Test Create
            /// </summary>
            [TestMethod]
            public async Task CreateOrderTesting()
            {
                CreateOrderRequest request = new()
                {
                    Order_ID = Guid.NewGuid()
                };
                CreateOrderResponse response = await _OrdersService.CreateOrder(request);
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
                    Order_ID = Guid.Parse(" ")
                };
                UpdateOrderResponse response = await _OrdersService.UpdateOrder(request);
                //Check response is not null
                Assert.IsNotNull(response);
            }
            /// <summary>
            /// Test Delete
            /// </summary>
            [TestMethod]
            public async Task DeleteOrderTesting()
            {
                DeleteOrderRequest request = new()
                {
                    Order_ID = Guid.Parse(" ")
                };
                DeleteOrderResponse response = await _OrdersService.DeleteOrder(request);
                //Check response is not null
                Assert.IsNotNull(response);
            }
        }
    }
