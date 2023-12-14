using AdvanceCSharp.database;
using AdvanceCSharp.database.Model;
using AdvanceCSharp.dto.Carts.Request;
using AdvanceCSharp.dto.Carts.Response;

namespace AdvanceCSharp.service
{
    public class CartsService
    {
        public static Task<GetCartResponse> GetCart(GetCartRequest request)
        {
            GetCartResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Carts? GetCart = dbContext.Carts.Where(cart => cart.User_ID == request.User_ID).FirstOrDefault();
                response.Cart_ID = GetCart.Cart_ID;
                response.User_ID = GetCart.User_ID;
                response.Quantity = GetCart.Quantity;
                response.Cart_List_Product = GetCart.Cart_List_Product;
                response.Total = GetCart.Total;
            }
            return Task.FromResult(response);
        }

        public static Task<GetListCartResponse> GetListCart(GetListCartRequest request)
        {
            GetListCartResponse response = new();
            using AppDbContext dbContext = new();
            List<Carts>? ListCart = [.. dbContext.Carts.Where(cart => cart.User_ID == request.User_ID)];
            foreach (Carts cart in ListCart)
            {
                GetCartResponse TmpCart = new()
                {
                    Cart_ID = cart.Cart_ID,
                    User_ID = cart.User_ID,
                    Quantity = cart.Quantity,
                    Total = cart.Total,
                    Cart_List_Product = cart.Cart_List_Product
                };
            }
            return Task.FromResult(response);
        }

        public static Task<CreateCartResponse> CreateCart(CreateCartRequest request)
        {
            CreateCartResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Carts CreateCart = new()
                {
                    Cart_ID = request.Cart_ID,
                    User_ID = request.User_ID,
                    Quantity = request.Quantity,
                    Total = request.Total,
                    Cart_List_Product = request.Cart_List_Product
                };
                _ = dbContext.Carts.Add(CreateCart);
                _ = dbContext.SaveChanges();

                Carts? GetCart = dbContext.Carts.Where(cart => cart.User_ID == request.User_ID).FirstOrDefault();
                response.Cart_ID = GetCart.Cart_ID;
                response.User_ID = GetCart.User_ID;
                response.Quantity = GetCart.Quantity;
                response.Cart_List_Product = GetCart.Cart_List_Product;
                response.Total = GetCart.Total;
            }
            return Task.FromResult(response);
        }

        public static Task<UpdateCartResponse> UpdateCart(UpdateCartRequest request)
        {
            UpdateCartResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Carts carts = new()
                {
                    Cart_ID = request.Cart_ID,
                    User_ID = request.User_ID,
                    Quantity = request.Quantity,
                    Total = request.Total,
                    Cart_List_Product = request.Cart_List_Product
                };
                Carts UpdateCart = carts;
                _ = dbContext.Carts.Update(UpdateCart);
                _ = dbContext.SaveChanges();

                Carts? GetCart = dbContext.Carts.Where(cart => cart.User_ID == request.User_ID).FirstOrDefault();
                response.Cart_ID = GetCart.Cart_ID;
                response.User_ID = GetCart.User_ID;
                response.Quantity = GetCart.Quantity;
                response.Cart_List_Product = GetCart.Cart_List_Product;
                response.Total = GetCart.Total;
            }
            return Task.FromResult(response);
        }

        public static Task<DeleteCartResponse> DeleteCart(DeleteCartRequest request)
        {
            using (AppDbContext dbContext = new())
            {
                Carts? FindedCart = dbContext.Carts.Find(request.Cart_ID);
                _ = dbContext.Carts.Remove(FindedCart);
                _ = dbContext.SaveChanges();
            }
            DeleteCartResponse response = new()
            {
                Cart_ID = Guid.Empty,
                User_ID = Guid.Empty,
                Quantity = 0,
                Total = 0,
                Cart_List_Product = { }
            };
            return Task.FromResult(response);
        }
    }
}
