using AdvanceCSharp.database.Model;
namespace AdvanceCSharp.dto.Users.Response
{
    public class NewUserResponse
    {
        public Guid User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string User_Contact { get; set; }
    }
}
