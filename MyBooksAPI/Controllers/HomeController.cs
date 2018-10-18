using MyBooksAPI.BusinessAccessLayer.Services;
using MyBooksAPI.Entities.Models;
using MyBooksAPI.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using MyBooksAPI.BusinessAccessLayer.IServices;

namespace MyBooksAPI.Controllers
{
    public class HomeController : ApiController
    {

        private readonly IHomeService _homeService;
        public HomeController(HomeService homeService)
        {
            _homeService = homeService;
        }
        /// <summary>
        /// To display the particular book details
        /// </summary>
        /// <param name="ISBN"></param>
        /// <returns></returns>
        [HttpGet]
        public HomePageViewStatus getBookdetails(string ISBN)
        {
            return _homeService.getBookdetails(ISBN);
        }

        //Filtering action is done based on users need 
        [HttpPost]
        public HomePageViewStatus filterbooks(HomePage homepage) 
        {
            return _homeService.filterbooks(homepage);
        }
        //fetching the values of category from the database and displaying it
        [HttpGet]
        public CategoryViewModel Category()
        {
            return _homeService.getCategories();
        }
        //fetching the values of Author from the database and displaying it
        [HttpGet]
        public AuthorViewModel Author()
        {
            return _homeService.getAuthor();
        }
        //fetching the values of Rating from the database and displaying it
        [HttpGet]
        public RatingViewModel Ratings()
        {
            return _homeService.getRating();
        }

        // Autosearch book prefix in Book database
        [HttpGet]
        public SearchHome Searchbook(string searchType, string searchText)
        {
            return _homeService.searchbookval(searchType, searchText);


        }

        //Search by bookname and get the detail.
        [HttpGet]
        public HomePageViewStatus Details(string searchType, string searchText)
        {

            return _homeService.Searchingbookdetail(searchType, searchText);


        }
    }
}
