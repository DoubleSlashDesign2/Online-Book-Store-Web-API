using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooksAPI.DataAccessLayer;
using MyBooksAPI.DataAccessLayer.DB;
using MyBooksAPI.Entities.ViewModels;
using MyBooksAPI.Entities.Models;
namespace MyBooksAPI.DataAccessLayer.Services
{
    public class SearchManager
    {
        //Logic for Autosearch according to Initial alphabet.
        public SearchHome searchbooklist(string searchType, string searchText)
        {
            SearchHome model = new SearchHome();
            try
            {
                if (searchType != null && searchText != null)
                {
                    using (var db = new Orchard9Entities())
                    {
                        if (searchType.ToLower() == "author")
                        {
                            model.BookOrAuthorNameOrIsbn = (from res in db.tblBooks
                                                      where res.isactive == true && res.Author.ToLower().Contains(searchText.ToLower())
                                                      select res.Author).Distinct().ToList();
                        }

                        else if (searchType.ToLower() == "book")
                        {
                            model.BookOrAuthorNameOrIsbn = (from res in db.tblBooks
                                                      where res.isactive == true && res.BookName.ToLower().Contains(searchText.ToLower())
                                                      select res.BookName).Distinct().ToList();
                        }
                        else if (searchType.ToLower() == "isbn")
                        {
                            model.BookOrAuthorNameOrIsbn = (from res in db.tblBooks
                                                      where res.isactive == true && res.ISBN.ToLower().Contains(searchText.ToLower())
                                                      select res.ISBN).Distinct().ToList();
                        }
                        if (model.BookOrAuthorNameOrIsbn.Count > 0)
                            model.StatusMessage = "Success";
                        else
                            model.StatusMessage = "No records found";
                    }
                }
                else
                {
                    model.StatusMessage = "Searchtype and Searchtext are invalid!";
                }
            }
            catch (Exception e)
            {
                model.StatusMessage = e.Message;
            }

            return model;


        }
        // Logic for search by Author and Bookname and Display complete detail of Book.
        public HomePageViewStatus SearchBookDetails(string searchType, string searchText)
        {
            HomePageViewStatus ob = new HomePageViewStatus();
            List<HomePageView> model = new List<HomePageView>();
            try
            {
                if (searchType != null && searchText != null)
                {
                    using (var db = new Orchard9Entities())
                    {
                        if (searchType.ToLower() == "author")
                        {
                            model = (from book in db.tblBooks
                                     where book.isactive == true && book.Author.ToLower().Contains(searchText.ToLower())
                                     select new HomePageView
                                     {
                                         ISBN = book.ISBN,
                                         BookImageUrl = book.BookImageUrl,
                                         BookName = book.BookName,
                                         Author = book.Author,
                                         Publisher = book.Publisher,
                                         Rating = book.Rating,
                                         Category = book.Category,
                                         Price = book.Price
                                     }).ToList();
                        }
                        else if (searchType.ToLower() == "book")
                        {
                            model = (from book in db.tblBooks
                                     where book.isactive == true && book.BookName.ToLower().Contains(searchText.ToLower())
                                     select new HomePageView
                                     {
                                         ISBN = book.ISBN,
                                         BookImageUrl = book.BookImageUrl,
                                         BookName = book.BookName,
                                         Author = book.Author,
                                         Publisher = book.Publisher,
                                         Rating = book.Rating,
                                         Category = book.Category,
                                         Price = book.Price
                                     }).ToList();
                        }

                        else if (searchType.ToLower() == "isbn")
                        {
                            model = (from book in db.tblBooks
                                     where book.isactive == true && book.ISBN.ToLower().Contains(searchText.ToLower())
                                     select new HomePageView
                                     {
                                         ISBN = book.ISBN,
                                         BookImageUrl = book.BookImageUrl,
                                         BookName = book.BookName,
                                         Author = book.Author,
                                         Publisher = book.Publisher,
                                         Rating = book.Rating,
                                         Category = book.Category,
                                         Price = book.Price
                                     }).ToList();
                        }
                        else if (searchType.ToLower() == "initial")
                        {
                            model = (from book in db.tblBooks
                                     where book.isactive == true
                                     select new HomePageView
                                     {
                                         ISBN = book.ISBN,
                                         BookImageUrl = book.BookImageUrl,
                                         BookName = book.BookName,
                                         Author = book.Author,
                                         Publisher = book.Publisher,
                                         Rating = book.Rating,
                                         Category = book.Category,
                                         Price = book.Price
                                     }).ToList();
                        }
                    }

                    ob.statuslist = model;
                    if (model.Count > 0)
                    {
                        ob.statusMessage = "Success";
                    }
                    else
                    {
                        ob.statusMessage = "No record found.!";
                    }
                }
                else
                {
                    ob.statusMessage = "Searchtype and Searchtext are invalid!";
                }
            }
            catch (Exception ex)
            {
                ob.statuslist = model;
                ob.statusMessage = ex.Message;
            }

            return ob;


        }
    }
}

