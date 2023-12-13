namespace AdvanceCSharp.dto.Orders.Request
{
    public class CreateOrderRequest
    {
        public Guid Order_ID { get; set; }
        public Guid User_ID { get; set; }
        public Guid Product_ID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
