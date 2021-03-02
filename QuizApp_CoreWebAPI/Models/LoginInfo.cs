using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp_CoreWebAPI.Models
{
    public class LoginInfo
    {
        public int Id { get; set; }
       
        public string Username { get; set; }
     
        public string Password { get; set; }
        public string Role { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
