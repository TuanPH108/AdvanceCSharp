namespace AdvanceCSharp.dto.Users.Request
{
    public class UpdateUserRequest
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserContact { get; set; } = string.Empty;
    }
}
