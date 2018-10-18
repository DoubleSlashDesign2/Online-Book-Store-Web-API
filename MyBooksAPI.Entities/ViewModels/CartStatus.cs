using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.ViewModels
{
    public class CartStatus
    {
        public List<CartView> statusList { get; set; }
        public string statusMessage { get; set; }
    }
}
