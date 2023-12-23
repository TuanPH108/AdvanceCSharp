namespace AdvanceCSharp.dto.Orders.Request
{
    public class CreateOrderRequest
    {
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
