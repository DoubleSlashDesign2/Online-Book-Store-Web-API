using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooksAPI.Entities.Models;
using MyBooksAPI.DataAccessLayer.DB;

namespace MyBooksAPI.DataAccessLayer.Services
{
    public class WishListManager
    {
        //gets the details of the particular book in the wishlist
        public WishListStatus getBookDetails(int wishListID)
        {
            WishListStatus a = new WishListStatus();

            try
            {
                using (var dbcontext = new Orchard9Entities())

                {

                   var query = (from e in dbcontext.tblWishlists
                         join d in dbcontext.tblBooks on e.ISBN equals d.ISBN
                         join x in dbcontext.tblUsers on e.UserId equals x.UserId
                         where e.id == wishListID
                         select new WishListModel() { id = e.id, ISBN = e.ISBN, UserId = e.UserId, price = d.Price, Publisher = d.Publisher, Author = d.Author, rating = d.Rating, BookName = d.BookName, BookImageUrl = d.BookImageUrl }).ToList();
                    a.statusList = query;
                    if (query.Count > 0)
                        a.statusMessage = "book details";
                    else
                        a.statusMessage = "book not available";
                }
                
            }
            catch (Exception e)
            {
                a.statusMessage = e.Message;
            }
            return a;
        }

        //deletes the book from wishlist
        public string deleteFromWishList(int wishListId)
        {
            string s = "";
            try
            {
                using (var dbcontext = new Orchard9Entities())
                {
                    tblWishlist test = dbcontext.tblWishlists.Find(wishListId);
                    dbcontext.tblWishlists.Remove(test);
                    dbcontext.SaveChanges();
                    return "deletion successful";
                }
            }
            catch (Exception e)
            {
                 s = e.Message;
            }
            return s;
        }

        //Adds the book from wishlist to cart
        public string addToCart(WishListModel wish)
        {
            string s = "";
            try
            {
                using (var dbcontext = new Orchard9Entities())
                {
                    if ((from e in dbcontext.tblCarts where e.ISBN == wish.ISBN && e.UserId == wish.UserId select e.CartId).ToList().Count > 0)
                    {
                        return "Already present";


                    }
                    else
                    {
                        dbcontext.tblCarts.Add(new tblCart()
                        {
                            CartId = wish.id,
                            ISBN = wish.ISBN,
                            UserId = wish.UserId,
                            PayStatus = true,
                            Quantity = 1
                        });
                        dbcontext.SaveChanges();
                        return "Added to cart";
                    }
                }
            }
            catch (Exception e)
            {
                s = e.Message;
            }
            return s;
        }

        //displays all the books in the wishlist
        public WishListStatus displayAllItems(int userid)
        {
            WishListStatus w = new WishListStatus();
            try
            {
                using (var dbcontext = new Orchard9Entities())
                {
                    if ((from e in dbcontext.tblUsers where e.UserId == userid && e.IsActive == false select e.UserId).ToList().Count > 0)
                    {
                        w.statusMessage = "You are Blocked by Admin";
                    }
                    else
                    {


                        var query = (from e in dbcontext.tblWishlists
                                     join d in dbcontext.tblBooks on e.ISBN equals d.ISBN
                                     join x in dbcontext.tblUsers on e.UserId equals x.UserId
                                     where e.UserId == userid
                                     select new WishListModel() { id = e.id, ISBN = e.ISBN, UserId = e.UserId, price = d.Price, Publisher = d.Publisher, Author = d.Author, rating = d.Rating, BookName = d.BookName, BookImageUrl = d.BookImageUrl }).ToList();

                        w.statusList = query;
                        if (query.Count > 0)
                            w.statusMessage = " Items in Wishlist";
                        else
                            w.statusMessage = "no items in wishlist";
                    }
                }
            }
            catch (Exception e)
            {
                w.statusMessage = e.Message;
            }
            return w;
            }




        
     
        //adds the book to wishlist
      public  string addToWishList(WishListModel wish)
        {

            string s = "";
            try
            {

                using (var dbcontext = new Orchard9Entities())
                {
                    if ((from e in dbcontext.tblUsers where e.UserId == wish.UserId && e.IsActive == false select e.UserId).ToList().Count > 0)
                    {
                        return "You are Blocked by Admin";
                    }
                    else
                    {
                        if ((from e in dbcontext.tblWishlists where e.ISBN == wish.ISBN && e.UserId == wish.UserId select e.id).ToList().Count > 0)
                        {
                            return "Already present";
                        }
                        else
                        {
                            dbcontext.tblWishlists.Add(new tblWishlist()
                            {
                                id = wish.id,
                                ISBN = wish.ISBN,
                                UserId = wish.UserId,
                                CurrentPrice = wish.price




                            });
                            dbcontext.SaveChanges();
                            return "added successfully";
                        }

                    }
                }
            }

            catch (Exception e)
            {
                s = e.Message;
            }
            return s;

        }


    }
}
