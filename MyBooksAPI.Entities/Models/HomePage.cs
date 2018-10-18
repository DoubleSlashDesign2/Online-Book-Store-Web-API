using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.Models
{
   public  class HomePage
    {
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
        public List<string> BookName { get; set; }
        public List<string> Category { get; set; }
        public List<double?> Rating { get; set; }
        public List<string> Author { get; set; }
        public string searchType { get; set; }
        public string searchText { get; set; }
    }
}
