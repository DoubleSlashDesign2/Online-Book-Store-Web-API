using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.ViewModels
{
   public class AuthorViewModel
    {
        public List<string> AuthorName { get; set; }
        public string StatusMessage { get; set; }
    }
}
