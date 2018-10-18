using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooksAPI.BusinessAccessLayer.IServices;
using MyBooksAPI.Entities.Models;
using MyBooksAPI.Entities.ViewModels;
using MyBooksAPI.DataAccessLayer.Services;

namespace MyBooksAPI.BusinessAccessLayer.Services
{
    public class CartService : ICartService
    {
        CartManager carts = new CartManager();
        public CartStatus Display(int UserId)  
        {
            return carts.Display(UserId);
           
        }
        public string Remove(int CartId)
        {
           return carts.Remove(CartId);
        }
        public string Buy(int UserId)
        {
            return carts.Buy(UserId);
        }
        public string AddToCart(Entities.Models.Cart cart)
        {
            return carts.AddToCart(cart);
        }
        public CartStatus Invoice(int UserId)
        {
            return carts.Invoice(UserId);
        }
        public string AddInvoice(InvoiceView invoiceView)
        {
            return carts.AddInvoice(invoiceView);
        }
    }
}
