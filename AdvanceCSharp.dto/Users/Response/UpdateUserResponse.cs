namespace AdvanceCSharp.dto.Users.Response
{
    public class UpdateUserResponse
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set;} = string.Empty;
        public string UserContact { get; set; } = string.Empty;
    }
}
