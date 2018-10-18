using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.Models
{
   public  class WishListModel
    {
       
        public int id { get; set; }
        public string ISBN { get; set; }
        public int UserId { get; set; }
        public string BookName { get; set; }
        public  double price { get; set; }
        public double? rating { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

    public string BookImageUrl { get; set; }


    }
}
