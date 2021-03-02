using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp_CoreWebAPI.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }

        public string EmailId { get; set; }

        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }
}
