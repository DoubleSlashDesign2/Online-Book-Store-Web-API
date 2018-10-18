using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.Models
{
   public class PriceStatus
    {
        public List<PriceModel> statusList { get; set; }

        public string statusMessage { get; set; }

        public double? changedPrice { get; set; }

        public string bookName { get; set; }
    }
}
