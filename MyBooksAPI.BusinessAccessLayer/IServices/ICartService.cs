using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooksAPI.Entities.Models;
using MyBooksAPI.Entities.ViewModels;

namespace MyBooksAPI.BusinessAccessLayer.IServices
{
    public interface ICartService
    {
        CartStatus Display(int UserId); 
        string Remove(int CartId);
        string Buy(int UserId);
        string AddToCart(Cart cart);
        CartStatus Invoice(int UserId);
        string AddInvoice(InvoiceView invoiceView);
    }
}
