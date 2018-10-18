using MyBooksAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyBooksAPI.BusinessAccessLayer.IServices
{
  public  interface IWishListService
    {
        //for retriving the details 
        WishListStatus getBookDetails(int wishListID);
        string deleteFromWishList(int wishListId);
        string addToCart(WishListModel wish);

        string addToWishList(WishListModel wish);

        WishListStatus displayAllItems(int userid);
    }
}
