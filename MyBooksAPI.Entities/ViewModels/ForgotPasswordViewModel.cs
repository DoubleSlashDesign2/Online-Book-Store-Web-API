using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.ViewModels
{
    public class ForgotPasswordViewModel
    {
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string StatusMessage { get; set; }
    }
}
