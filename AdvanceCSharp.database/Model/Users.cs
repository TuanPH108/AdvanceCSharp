using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceCSharp.database.Model
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public Guid User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string User_Contact { get; set; }
    }
}
