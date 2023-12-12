using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceCSharp.database.Model
{
    [Table("Carts")]
    public class Carts
    {
        [Key]
        public Guid Cart_ID { get; set; }
        public Guid User_ID { get; set; }
        public string Cart_List_Product {  get; set; }
        public float Total { get; set; }
        public int Quantity { get; set; }
    }
}
