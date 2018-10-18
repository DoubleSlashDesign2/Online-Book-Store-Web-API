using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Entities.ViewModels
{
    public class InvoiceView
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
       

    }
}
