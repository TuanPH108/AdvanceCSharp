namespace AdvanceCSharp.dto.Products.Response
{
    public class UpdateProductResponse
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int ProductPrice { get; set; }
        public string ProductType { get; set; } = string.Empty;
    }
}
