using AdvanceCSharp.dto.Products.Request;
using AdvanceCSharp.dto.Products.Response;

namespace AdvanceCSharp.service.Interface
{
    public interface IProductsService
    {
        public Task<GetProductResponse> Get(GetProductRequest request);
        public Task<GetListProductResponse> GetList(GetListProductRequest request); 
        public Task<CreateProductResponse> Create (CreateProductRequest request);
        public Task<UpdateProductResponse> Update (UpdateProductRequest request);
        public Task<DeleteProductResponse> Delete (DeleteProductRequest request);
    }
}
