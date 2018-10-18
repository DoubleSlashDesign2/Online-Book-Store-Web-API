using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.ViewModels
{
public class UserView
    {   
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public bool IsVerified { get; set; }
        public int Role { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
