namespace AdvanceCSharp.dto.Carts.Request
{
    public class CreateCartRequest
    {
        public Guid CartID { get; set; }
        public Guid UserID { get; set; }
        public string CartListProduct { get; set; } = string.Empty;
        public float Total { get; set; }
        public int Quantity { get; set; }
    }
}
