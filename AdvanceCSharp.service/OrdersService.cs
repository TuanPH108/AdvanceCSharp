using AdvanceCSharp.dto.Orders.Request;
using AdvanceCSharp.dto.Orders.Response;
using AdvanceCSharp.database.Model;
using AdvanceCSharp.database;

namespace AdvanceCSharp.service
{
    public class OrdersService
    {
        public Task <GetOrderResponse> GetOrder (GetOrderRequest request)
        {
            GetOrderResponse response = new GetOrderResponse ();
            using (AppDbContext dbContext = new AppDbContext())
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
        public Task<GetListOrderResponse> GetListOrder(GetListOrderRequest request)
        {
            GetListOrderResponse response = new GetListOrderResponse();
            using(AppDbContext dbContext = new AppDbContext())
            {
                List<Orders> ListOrder = dbContext.Orders.Where(order => order.User_ID == request.User_Id).ToList();
                foreach(Orders order in ListOrder)
                {
                    GetOrderResponse TmpOrder = new GetOrderResponse()
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
        public Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request)
        {
            CreateOrderResponse response = new CreateOrderResponse();
            using (AppDbContext dbContext = new AppDbContext()) 
            {
                Orders CreateOrder = new Orders()
                {
                    Order_ID = request.Order_ID,
                    Product_ID = request.Product_ID,
                    User_ID = request.User_ID,
                    Price = request.Price,
                    Quantity = request.Quantity
                };
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

        public Task<UpdateOrderResponse> UpdateOrder(UpdateOrderRequest request)
        {
            UpdateOrderResponse response = new UpdateOrderResponse();
            using(AppDbContext dbContext = new AppDbContext()) 
            {
                Orders UpdateOrder = new Orders() { 
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

        public Task<DeleteOrderResponse> DeleteOrder (DeleteOrderRequest request)
        {
            DeleteOrderResponse response = new DeleteOrderResponse();
            using(AppDbContext dbContext = new AppDbContext())
            {
                Orders? DeleteOrder = dbContext.Orders.Find(request.Order_ID);
                _ = dbContext.Orders.Remove(DeleteOrder);
                dbContext.SaveChanges();
            }
            return Task.FromResult(response);
        }
    }
}
