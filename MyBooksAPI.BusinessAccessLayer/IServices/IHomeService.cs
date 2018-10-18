using MyBooksAPI.Entities.ViewModels;
using MyBooksAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.BusinessAccessLayer.IServices
{
    public interface IHomeService
    {
        #region Search
        //Interface for SearchBooks service BAL.
        SearchHome searchbookval(string searchType, string searchText);
        HomePageViewStatus Searchingbookdetail(string searchType, string searchText);
        #endregion
        #region Filter
        HomePageViewStatus filterbooks(HomePage homepage);
        CategoryViewModel getCategories();
        AuthorViewModel getAuthor();
        RatingViewModel getRating();
        #endregion
        #region Display
        HomePageViewStatus getBookdetails(string ISBN);
        #endregion
    }
}
