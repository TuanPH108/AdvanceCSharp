﻿namespace AdvanceCSharp.dto.Users.Request
{
    public class NewUserRequest
    {
        public Guid User_ID {  get; set; }
        public string User_Name { get; set; } = string.Empty;
        public string User_Email { get; set; } = string.Empty;
        public string User_Contact {  get; set;} = string.Empty;
    }
}
