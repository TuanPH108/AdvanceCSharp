using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceCSharp.database.Model
{
    [Table("Carts")]
    public class Carts
    {
        [Key]
        public Guid CartID { get; set; }
        public Guid UserID { get; set; }
        public string CartListProduct { get; set; } = string.Empty;
        public float Total { get; set; }
        public int Quantity { get; set; }
    }
}
