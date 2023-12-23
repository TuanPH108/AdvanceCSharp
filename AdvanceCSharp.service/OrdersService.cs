using AdvanceCSharp.dto.Orders.Request;
using AdvanceCSharp.dto.Orders.Response;
using AdvanceCSharp.database.Model;
using AdvanceCSharp.database;
using AdvanceCSharp.service.Interface;

namespace AdvanceCSharp.service
{
    public class OrdersService : IOrdersService
    {
        public Task<GetOrderResponse> Get(GetOrderRequest request)
        {
            GetOrderResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Orders? getOrder = dbContext.Orders.Where(order => order.OrderID == request.OrderID).FirstOrDefault();
                response.OrderID = getOrder.OrderID;
                response.ProductID = getOrder.ProductID;
                response.UserID = getOrder.UserID;
                response.Price = getOrder.Price;
                response.Quantity = getOrder.Quantity;
            }
            return Task.FromResult(response);
        }

        public Task<GetListOrderResponse> GetList(GetListOrderRequest request)
        {
            GetListOrderResponse response = new();
            using (AppDbContext dbContext = new())
            {
                List<Orders> listOrder = [.. dbContext.Orders.Where(order => order.UserID == request.UserId)];
                foreach(Orders order in listOrder)
                {
                    GetOrderResponse tempOrder = new()
                    {
                        OrderID = order.OrderID,
                        ProductID = order.ProductID,
                        Price = order.Price,
                        Quantity = order.Quantity
                    };
                    response.ListOrder.Add(tempOrder);
                }
            }
            return Task.FromResult(response);
        }

        public Task<CreateOrderResponse> Create(CreateOrderRequest request)
        {
            CreateOrderResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Orders orders = new()
                {
                    OrderID = request.OrderID,
                    ProductID = request.ProductID,
                    UserID = request.UserID,
                    Price = request.Price,
                    Quantity = request.Quantity
                };
                Orders CreateOrder = orders;
                dbContext.Orders.Add(CreateOrder);
                dbContext.SaveChanges();

                Orders? getOrder = dbContext.Orders.Where(order => order.OrderID == request.OrderID).FirstOrDefault();
                response.OrderID = getOrder.OrderID;
                response.ProductID = getOrder.ProductID;
                response.UserID = getOrder.UserID;
                response.Price = getOrder.Price;
                response.Quantity = getOrder.Quantity;
            }
            return Task.FromResult (response);
        }

        public Task<UpdateOrderResponse> Update(UpdateOrderRequest request)
        {
            UpdateOrderResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Orders updateOrder = new() { 
                    OrderID = request.OrderID,
                    ProductID = request.ProductID,
                    UserID = request.UserID,
                    Price = request.Price,
                    Quantity = request.Quantity
                };
                dbContext.Update(updateOrder);
                dbContext.SaveChanges();

                Orders? getOrder = dbContext.Orders.Where(order => order.OrderID == request.OrderID).FirstOrDefault();
                response.OrderID = getOrder.OrderID;
                response.ProductID = getOrder.ProductID;
                response.UserID = getOrder.UserID;
                response.Price = getOrder.Price;
                response.Quantity = getOrder.Quantity;
            }
            return Task.FromResult(response);
        }

        public Task<DeleteOrderResponse> Delete(DeleteOrderRequest request)
        {
            DeleteOrderResponse response = new()
            {
                OrderID = Guid.Empty,
                ProductID = Guid.Empty,
                UserID = Guid.Empty,
                Quantity = 0,
                Price = 0
            };
            using (AppDbContext dbContext = new())
            {
                Orders? deleteOrder = dbContext.Orders.Find(request.OrderID);
                _ = dbContext.Orders.Remove(deleteOrder);
                dbContext.SaveChanges();
            }
            return Task.FromResult(response);
        }
    }
}
