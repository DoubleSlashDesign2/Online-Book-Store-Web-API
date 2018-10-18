using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.ViewModels
{
   public class RegistrationResponseViewModel
    {
        public string Email { get; set; }
        public int UserId { get; set; }
        public string StatusMessage { get; set; }
    }
}
