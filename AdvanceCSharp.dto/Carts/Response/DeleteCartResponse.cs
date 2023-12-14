namespace AdvanceCSharp.dto.Carts.Response
{
    public class DeleteCartResponse
    {
        public Guid Cart_ID { get; set; }
        public Guid User_ID { get; set; }
        public string Cart_List_Product { get; set; } = string.Empty;
        public float Total { get; set; }
        public int Quantity { get; set; }
    }
}
