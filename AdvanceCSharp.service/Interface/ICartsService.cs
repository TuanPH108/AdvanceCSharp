using AdvanceCSharp.dto.Carts.Request;
using AdvanceCSharp.dto.Carts.Response;

namespace AdvanceCSharp.service.Interface
{
    public interface ICartsService
    {
        public Task <GetCartResponse> Get(GetCartRequest request);
        public Task<GetListCartResponse> GetList(GetListCartRequest request);
        public Task<UpdateCartResponse> Update(UpdateCartRequest request);
        public Task<DeleteCartResponse> Delete(DeleteCartRequest request);
        public Task<CreateCartResponse> Create(CreateCartRequest request);
    }
}
