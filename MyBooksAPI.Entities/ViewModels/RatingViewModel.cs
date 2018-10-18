using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.ViewModels
{
   public class RatingViewModel
    {
        public List<double?> Ratings { get; set; }
        public string StatusMessage { get; set; }
    }
}
