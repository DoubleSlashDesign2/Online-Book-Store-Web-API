using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.Models
{
  public class SearchHome
    {
        public List<string> BookOrAuthorNameOrIsbn { get; set; }
        public string StatusMessage { get; set; }
    }
}
