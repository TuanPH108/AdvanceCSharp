using AdvanceCSharp.dto.Orders.Request;
using AdvanceCSharp.dto.Orders.Response;
using AdvanceCSharp.database.Model;
using AdvanceCSharp.database;

namespace AdvanceCSharp.service
{
    public class OrdersService
    {
        public static Task<GetOrderResponse> GetOrder(GetOrderRequest request)
        {
            GetOrderResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Orders? GetOrder = dbContext.Orders.Where(order => order.Order_ID == request.Order_ID).FirstOrDefault();
                response.Order_ID = GetOrder.Order_ID;
                response.Product_ID = GetOrder.Product_ID;
                response.User_ID = GetOrder.User_ID;
                response.Price = GetOrder.Price;
                response.Quantity = GetOrder.Quantity;
            }
            return Task.FromResult(response);
        }
        public static Task<GetListOrderResponse> GetListOrder(GetListOrderRequest request)
        {
            GetListOrderResponse response = new();
            using (AppDbContext dbContext = new())
            {
                List<Orders> ListOrder = [.. dbContext.Orders.Where(order => order.User_ID == request.User_Id)];
                foreach(Orders order in ListOrder)
                {
                    GetOrderResponse TmpOrder = new()
                    {
                        Order_ID = order.Order_ID,
                        Product_ID = order.Product_ID,
                        Price = order.Price,
                        Quantity = order.Quantity
                    };
                    response.ListOrder.Add(TmpOrder);
                }
            }
            return Task.FromResult(response);
        }
        public static Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request)
        {
            CreateOrderResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Orders orders = new()
                {
                    Order_ID = request.Order_ID,
                    Product_ID = request.Product_ID,
                    User_ID = request.User_ID,
                    Price = request.Price,
                    Quantity = request.Quantity
                };
                Orders CreateOrder = orders;
                dbContext.Orders.Add(CreateOrder);
                dbContext.SaveChanges();

                Orders? GetOrder = dbContext.Orders.Where(order => order.Order_ID == request.Order_ID).FirstOrDefault();
                response.Order_ID = GetOrder.Order_ID;
                response.Product_ID = GetOrder.Product_ID;
                response.User_ID = GetOrder.User_ID;
                response.Price = GetOrder.Price;
                response.Quantity = GetOrder.Quantity;
            }
            return Task.FromResult (response);
        }

        public static Task<UpdateOrderResponse> UpdateOrder(UpdateOrderRequest request)
        {
            UpdateOrderResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Orders UpdateOrder = new() { 
                    Order_ID = request.Order_ID,
                    Product_ID = request.Product_ID,
                    User_ID = request.User_ID,
                    Price = request.Price,
                    Quantity = request.Quantity
                };
                dbContext.Update(UpdateOrder);
                dbContext.SaveChanges();

                Orders? GetOrder = dbContext.Orders.Where(order => order.Order_ID == request.Order_ID).FirstOrDefault();
                response.Order_ID = GetOrder.Order_ID;
                response.Product_ID = GetOrder.Product_ID;
                response.User_ID = GetOrder.User_ID;
                response.Price = GetOrder.Price;
                response.Quantity = GetOrder.Quantity;
            }
            return Task.FromResult(response);
        }

        public static Task<DeleteOrderResponse> DeleteOrder(DeleteOrderRequest request)
        {
            DeleteOrderResponse response = new()
            {
                Order_ID = Guid.Empty,
                Product_ID = Guid.Empty,
                User_ID = Guid.Empty,
                Quantity = 0,
                Price = 0
            };
            using (AppDbContext dbContext = new())
            {
                Orders? DeleteOrder = dbContext.Orders.Find(request.Order_ID);
                _ = dbContext.Orders.Remove(DeleteOrder);
                dbContext.SaveChanges();
            }

            return Task.FromResult(response);
        }
    }
}
