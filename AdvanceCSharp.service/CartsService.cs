using AdvanceCSharp.database;
using AdvanceCSharp.database.Model;
using AdvanceCSharp.dto.Carts.Request;
using AdvanceCSharp.dto.Carts.Response;
using AdvanceCSharp.service.Interface;

namespace AdvanceCSharp.service
{
    public class CartsService : ICartsService
    {
        public Task<GetCartResponse> Get(GetCartRequest request)
        {
            GetCartResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Carts? getCart = dbContext.Carts.Where(cart => cart.UserID == request.UserID).FirstOrDefault();
                response.CartID = getCart.CartID;
                response.UserID = getCart.UserID;
                response.Quantity = getCart.Quantity;
                response.CartListProduct = getCart.CartListProduct;
                response.Total = getCart.Total;
            }
            return Task.FromResult(response);
        }

        public Task<GetListCartResponse> GetList(GetListCartRequest request)
        {
            GetListCartResponse response = new();
            using AppDbContext dbContext = new();
            List<Carts>? listCart = [.. dbContext.Carts.Where(cart => cart.UserID == request.UserID)];
            foreach (Carts cart in listCart)
            {
                GetCartResponse tempCart = new()
                {
                    CartID = cart.CartID,
                    UserID = cart.UserID,
                    Quantity = cart.Quantity,
                    Total = cart.Total,
                    CartListProduct = cart.CartListProduct
                };
            }
            return Task.FromResult(response);
        }

        public Task<CreateCartResponse> Create(CreateCartRequest request)
        {
            CreateCartResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Carts createCart = new()
                {
                    CartID = request.CartID,
                    UserID = request.UserID,
                    Quantity = request.Quantity,
                    Total = request.Total,
                    CartListProduct = request.CartListProduct
                };
                _ = dbContext.Carts.Add(createCart);
                _ = dbContext.SaveChanges();

                Carts? getCart = dbContext.Carts.Where(cart => cart.UserID == request.UserID).FirstOrDefault();
                response.CartID = getCart.CartID;
                response.UserID = getCart.UserID;
                response.Quantity = getCart.Quantity;
                response.CartListProduct = getCart.CartListProduct;
                response.Total = getCart.Total;
            }
            return Task.FromResult(response);
        }

        public Task<UpdateCartResponse> Update(UpdateCartRequest request)
        {
            UpdateCartResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Carts carts = new()
                {
                    CartID = request.CartID,
                    UserID = request.UserID,
                    Quantity = request.Quantity,
                    Total = request.Total,
                    CartListProduct = request.CartListProduct
                };
                Carts updateCart = carts;
                _ = dbContext.Carts.Update(updateCart);
                _ = dbContext.SaveChanges();

                Carts? getCart = dbContext.Carts.Where(cart => cart.UserID == request.UserID).FirstOrDefault();
                response.CartID = getCart.CartID;
                response.UserID = getCart.UserID;
                response.Quantity = getCart.Quantity;
                response.CartListProduct = getCart.CartListProduct;
                response.Total = getCart.Total;
            }
            return Task.FromResult(response);
        }

        public Task<DeleteCartResponse> Delete(DeleteCartRequest request)
        {
            using (AppDbContext dbContext = new())
            {
                Carts? findCart = dbContext.Carts.Find(request.CartID);
                _ = dbContext.Carts.Remove(findCart);
                _ = dbContext.SaveChanges();
            }
            DeleteCartResponse response = new()
            {
                CartID = Guid.Empty,
                UserID = Guid.Empty,
                Quantity = 0,
                Total = 0,
                CartListProduct = { }
            };
            return Task.FromResult(response);
        }
    }
}
