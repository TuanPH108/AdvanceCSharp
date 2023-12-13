namespace AdvanceCSharp.dto.Products.Response
{
    public class GetListProductResponse
    {
        public List<GetProductResponse> ListProduct { get; set; } = new List<GetProductResponse>();
    }
}
