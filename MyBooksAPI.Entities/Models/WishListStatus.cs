using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.Models
{
 public   class WishListStatus
    {
       public List<WishListModel> statusList { get; set; }
        public string statusMessage { get; set; }
    }
}
