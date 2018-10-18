using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyBooksAPI.BusinessAccessLayer.IServices;
using MyBooksAPI.BusinessAccessLayer.Services;
using MyBooksAPI.Entities.Models;
namespace MyBooksAPI.Controllers
{

    public class WishListController : ApiController
    {
        private readonly IWishListService service;
        public WishListController(WishListService _service)
        {
            service = _service;
        }

        [HttpGet]
        //calls the action in service DAlayer which gets the details of the book in the wishlist
        public WishListStatus getBookDetails(int wishListId)
        {
            WishListStatus a = service.getBookDetails(wishListId);
            return a;
        }

        [HttpDelete]
        //calls the action in service DAlayer which deletes the book from the wishlist
        public string deleteFromWishList(int wishListId)
        {

            return service.deleteFromWishList(wishListId);
        }
        [HttpPost]
        //calls the action in service DAlayer which add books from wishlist to cart
        public string addToCart(WishListModel ins)
        {
            return service.addToCart(ins);
        }

        [HttpGet]
        //calls the action in service DAlayer which displays all book present in the wishlist
        public WishListStatus displayAllItems(int userid)
        {
            WishListStatus a = service.displayAllItems(userid);
            return a;
        }
        [HttpPost]
        //calls the action in service DAlayer which adds the book to wishlist
        public string addToWishList(WishListModel wish)
        {
            return service.addToWishList(wish);
        }

    }
}
