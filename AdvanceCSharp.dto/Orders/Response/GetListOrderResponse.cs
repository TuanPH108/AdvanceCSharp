namespace AdvanceCSharp.dto.Orders.Response
{
    public class GetListOrderResponse
    {
        public List<GetOrderResponse> ListOrder { get; set; } = new List<GetOrderResponse>();
    }
}
