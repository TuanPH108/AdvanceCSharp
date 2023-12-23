using AdvanceCSharp.dto.Orders.Request;
using AdvanceCSharp.dto.Orders.Response;

namespace AdvanceCSharp.service.Interface
{
    public interface IOrdersService
    {
        public Task<GetOrderResponse> Get(GetOrderRequest request);
        public Task<GetListOrderResponse> GetList(GetListOrderRequest request);
        public Task<UpdateOrderResponse> Update(UpdateOrderRequest request);
        public Task<DeleteOrderResponse> Delete(DeleteOrderRequest request);
        public Task<CreateOrderResponse> Create(CreateOrderRequest request);
    }
}
