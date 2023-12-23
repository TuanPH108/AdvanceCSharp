using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceCSharp.database.Model
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public Guid ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int ProductPrice {  get; set; }
        public string ProductType { get; set; } = string.Empty;
    }
}
