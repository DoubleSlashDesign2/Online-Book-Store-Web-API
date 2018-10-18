using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.Models
{
    public class UserLogin
    {
        public string EmailId { get; set; }
        public int UserId { get; set; }
        public int Role { get; set; }
        public string Password { get; set; }
    }
}
