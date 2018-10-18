using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooksAPI.BusinessAccessLayer.IServices;
using MyBooksAPI.Entities.Models;
using MyBooksAPI.DataAccessLayer.Services;
namespace MyBooksAPI.BusinessAccessLayer.Services
{
  public class WishListService:IWishListService
    {
        
        WishListManager ser = new WishListManager();
        public WishListStatus getBookDetails(int wishListID)
        {
            return ser.getBookDetails(wishListID);
        }
      public   string deleteFromWishList(int wishListId)
        {
             return ser.deleteFromWishList(wishListId);
            
        }

     public string addToCart(WishListModel wish)
        {
           return ser.addToCart(wish);
        }

      public   string addToWishList(WishListModel wish)
        {
           return ser.addToWishList(wish);
        }

        public WishListStatus displayAllItems(int userid)
        {
            return ser.displayAllItems(userid);
        }
    }
}
