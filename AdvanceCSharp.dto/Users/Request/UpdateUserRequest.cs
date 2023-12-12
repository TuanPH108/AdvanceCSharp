using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCSharp.dto.Users.Request
{
    public class UpdateUserRequest
    {
        public Guid User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string User_Contact { get; set; }
    }
}
