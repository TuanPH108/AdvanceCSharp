﻿namespace AdvanceCSharp.dto.Products.Request
{
    public class UpdateProductRequest
    {
        public Guid Product_ID { get; set; }
        public string Product_Name { get; set; } = string.Empty;
        public int Product_Price { get; set; }
        public string Product_Type { get; set; } = string.Empty;
    }
}
