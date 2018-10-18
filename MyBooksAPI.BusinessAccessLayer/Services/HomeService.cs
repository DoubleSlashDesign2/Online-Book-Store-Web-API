using MyBooksAPI.BusinessAccessLayer.IServices;
using MyBooksAPI.DataAccessLayer.Services;
using MyBooksAPI.Entities.Models;
using MyBooksAPI.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace MyBooksAPI.BusinessAccessLayer.Services
{
    public class HomeService : IHomeService
    {
        #region Search
        SearchManager searchmanager = new SearchManager();
        //Calling DAL Service.// for Autosearch
        public SearchHome searchbookval(string searchType, string searchText)
        {
            return searchmanager.searchbooklist(searchType, searchText);
        }
        //Calling DAL Service .// For Searching all the details of book.
        public HomePageViewStatus Searchingbookdetail(string searchType, string searchText)
        {
            return searchmanager.SearchBookDetails(searchType, searchText);
        }
        #endregion
        #region Filter
        FilterManager fm = new FilterManager();
        public HomePageViewStatus filterbooks(HomePage homepage)
        {
            return fm.filtermanage(homepage);
        }

        public CategoryViewModel getCategories()
        {
            return fm.Category();
        }
        public AuthorViewModel getAuthor()
        {
            return fm.Author();
        }
        public RatingViewModel getRating()
        {
            return fm.Ratings();
        }
        #endregion
        #region Display
        FilterManager filtermanager= new FilterManager();
        public HomePageViewStatus getBookdetails(string ISBN)
        {
            return filtermanager.getBookdetails(ISBN);
        }
        #endregion
    }
}
