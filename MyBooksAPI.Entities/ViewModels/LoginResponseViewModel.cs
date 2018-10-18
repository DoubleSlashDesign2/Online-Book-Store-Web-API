using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooksAPI.Entities.Models;

namespace MyBooksAPI.Entities.ViewModels
{
    public class LoginResponseViewModel
    {
        public string StatusMessage { get; set; }
        public int Role { get; set; }
        public UserLogin userLogin { get; set; }
        
    }
}
