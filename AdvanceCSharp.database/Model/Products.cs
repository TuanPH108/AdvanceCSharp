using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceCSharp.database.Model
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public Guid Product_ID { get; set; }
        public string Product_Name { get; set; } = string.Empty;
        public int Product_Price {  get; set; }
        public string Product_Type { get; set; } = string.Empty;
    }
}
