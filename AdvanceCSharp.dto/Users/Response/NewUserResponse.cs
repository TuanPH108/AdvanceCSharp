namespace AdvanceCSharp.dto.Users.Response;

public class NewUserResponse
{
    public Guid User_ID { get; set; }
    public string User_Name { get; set; } = string.Empty;
    public string User_Email { get; set; } = string.Empty;
    public string User_Contact { get; set; } = string.Empty;
}
