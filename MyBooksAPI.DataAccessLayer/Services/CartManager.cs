using MyBooksAPI.DataAccessLayer.DB;
using MyBooksAPI.Entities.Models;
using MyBooksAPI.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyBooksAPI.DataAccessLayer.Services
{
    public class CartManager
    {
        public CartStatus Display(int UserId)   //This method is used for getting all the cart details of a user
        {                                       //and display it.
            CartStatus status = new CartStatus();
            try
            {
                using (var db = new Orchard9Entities())
                {
                    if ((from e in db.tblUsers where e.UserId == UserId && e.IsActive == false select e.UserId).ToList().Count > 0)
                    {
                        status.statusMessage = "You are Blocked by Admin";
                    }
                    else
                    {
                        var query = (from cart in db.tblCarts
                                 join book in db.tblBooks on cart.ISBN equals book.ISBN
                                 where (cart.UserId == UserId) && (cart.PayStatus == true)
                                 select new CartView()
                                 {
                                     CartId = cart.CartId,
                                     UserId = cart.UserId,
                                     BookName = book.BookName,
                                     BookImageUrl = book.BookImageUrl,
                                     Quantity = cart.Quantity,
                                     Price = (book.Price * cart.Quantity)
                                 }).ToList();
                    status.statusList = query;
                        if (query.Count == 0)
                        {
                            status.statusMessage = "No Items in Cart";
                        }
                        else
                        {
                            status.statusMessage = "Items in Cart";
                        }
                    }

                }
            }
            catch (Exception e)
            {
                status.statusMessage = e.Message;
            }
            return status;
        }
        public string Remove(int CartId)  //This method is used for removing a book from the cart.
        {
            string message;
            try
            {
                using (var db = new Orchard9Entities())
                {
                    tblCart a1 = db.tblCarts.Find(CartId);
                    db.tblCarts.Remove(a1);
                    db.SaveChanges();
                    message = CartId + " removed from cart";
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return message;
        }
        public string Buy(int UserId)  //This method is change the payment status of the items 
        {                              //in the cart when the user clicks on the buy button.
            string str;
            try
            {
                using (var db = new Orchard9Entities())
                {
                    if ((from e in db.tblUsers where e.UserId == UserId && e.IsActive == false select e.UserId).ToList().Count > 0)
                    {
                        return "You are Blocked by Admin";
                    }
                    else
                    {
                        db.tblCarts.Where(u => u.UserId == UserId).ToList().ForEach(s => s.PayStatus = false);
                        db.SaveChanges();
                        str = "Payment Successfull";
                    }
                }
            }
            catch (Exception e)
            {
                str = e.Message;
            }
            return str;
        }
        public string AddToCart(Cart cart)
        {
            string msg = "";
            try
            {
                using (var db = new Orchard9Entities())
                {
                    if ((from e in db.tblUsers where e.UserId == cart.UserId && e.IsActive == false select e.UserId).ToList().Count > 0)
                    {
                        return "You are Blocked by Admin";
                    }
                    else
                    {
                        if ((from e in db.tblCarts where e.ISBN == cart.ISBN && e.UserId == cart.UserId && e.PayStatus == true select e.CartId).ToList().Count > 0)
                        {
                            return "Already Present";
                        }
                        else
                        {
                            db.tblCarts.Add(new tblCart()
                            {
                                ISBN = cart.ISBN,
                                UserId = cart.UserId,
                                PayStatus = true,
                                Quantity = 1
                            });
                            db.SaveChanges();
                            return "Added to Cart";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
     
  //fetching details to display the invoice
        public CartStatus Invoice(int UserId)
        {
            CartStatus status = new CartStatus();
            try
            {
                using (var db = new Orchard9Entities())
                {
                    var query = (from cart in db.tblCarts
                                 join book in db.tblBooks on cart.ISBN equals book.ISBN
                                 join user in db.tblUsers on cart.UserId equals user.UserId
                                 where (cart.UserId == UserId) && (cart.PayStatus == true)
                                 select new CartView()
                                 {
                                     CartId = cart.CartId,
                                     UserId = cart.UserId,
                                     UserName = user.Name,
                                     ISBN = book.ISBN,
                                     BookName = book.BookName,
                                     BookImageUrl = book.BookImageUrl,
                                     Author = book.Author,
                                     Publisher = book.Publisher,
                                     Category = book.Category,
                                     Rating = book.Rating,
                                     Description = book.Description,
                                     Quantity = cart.Quantity,
                                     Price = (book.Price * cart.Quantity)
                                 }).ToList();
                    status.statusList = query;
                    if (query.Count == 0)
                    {
                        status.statusMessage = "Invoice unsuccessful";
                    }
                    else
                    {
                        status.statusMessage = "Invoice success";
                    }
                }
            }
            catch (Exception e)
            {
                status.statusMessage = e.Message;
            }
            return status;
        }
        public string AddInvoice(InvoiceView invoiceView)
        {
            string msg = "";

            try
            {
                using (var db = new Orchard9Entities())
                {
                    if ((from e in db.tblUsers where e.UserId == invoiceView.UserId && e.IsActive == false select e.UserId).ToList().Count > 0)
                    {
                        return "You are Blocked by Admin";
                    }
                    else
                    {
                        if ((from e in db.tblInvoices
                             where e.UserId == invoiceView.UserId && e.CartId == invoiceView.CartId
                             select e.InvoiceId).ToList().Count > 0)
                        {
                            return "Invoice is generated already";
                        }
                        else
                        {
                            db.tblInvoices.Add(new tblInvoice()
                            {

                                UserId = invoiceView.UserId,
                                CartId = invoiceView.CartId,
                                InvoiceStatus=true

                            });

                            db.SaveChanges();

                            return "Invoice Added";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }


    }
}