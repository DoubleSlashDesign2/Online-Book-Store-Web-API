using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyBooksAPI.Entities.Models;
using MyBooksAPI.Entities.ViewModels;
using MyBooksAPI.BusinessAccessLayer.IServices;
using MyBooksAPI.BusinessAccessLayer.Services;


namespace MyBooksAPI.Controllers
{
    public class CartController : ApiController
    {
        private readonly ICartService icart;

        public CartController(BusinessAccessLayer.Services.CartService _icart)
        {
            icart = _icart;
        }

        [HttpGet]
        public CartStatus CartAction(int UserId) 
        {
            return icart.Display(UserId);
        }
        /// <summary>
        /// Removing items from Cart
        /// </summary>
        /// <param name="CartId"></param>
        /// <returns></returns>
        [HttpDelete]
        public string Remove(int CartId)
        {
           return icart.Remove(CartId);
        }
        /// <summary>
        /// Buy items from Cart action method
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        public string Buy(int UserId)
        {
            return icart.Buy(UserId);
        }
        /// <summary>
        /// This logic is to add items in the cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddToCart(Entities.Models.Cart cart)
        {
            return icart.AddToCart(cart);
        }
        /// <summary>
        /// generating invoice
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        public CartStatus Invoice(int UserId)
        {
            return icart.Invoice(UserId);
        }
        /// <summary>
        /// Adding invoice to the db
        /// </summary>
        /// <param name="invoiceView"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddInvoice(InvoiceView invoiceView)
        {
            return icart.AddInvoice(invoiceView);
        }
    }
}
