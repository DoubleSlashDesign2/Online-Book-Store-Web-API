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
    public class FilterManager
    {
        // this logic is to fetch book details
        public HomePageViewStatus getBookdetails(string ISBN)
        {
            HomePageViewStatus ob = new HomePageViewStatus();
            List<HomePageView> model = new List<HomePageView>();
            try
            {
                using (var db = new Orchard9Entities())
                {
                    model = (from book in db.tblBooks
                                  where book.isactive == true && ISBN==book.ISBN
                                  select new HomePageView
                                  {
                                      ISBN = book.ISBN,
                                      BookImageUrl = book.BookImageUrl,
                                      BookName = book.BookName,
                                      Author = book.Author,
                                      Publisher = book.Publisher,
                                      Description=book.Description,
                                      Rating = book.Rating,
                                      Category = book.Category,
                                      Price = book.Price
                                  }).ToList();
                    ob.statuslist = model;
                    if (model.Count > 0)
                    {
                        ob.statusMessage = "Success";
                    }
                    else
                    {
                        ob.statusMessage = "No books available";
                    }
                

            }
            }
            catch (Exception ex)
            {
                ob.statuslist = model;
                ob.statusMessage = ex.Message;
            }
            return ob;
        }

//this logic is used to perform filter operation
public HomePageViewStatus filtermanage(HomePage homepage)
        {
            HomePageViewStatus ob = new HomePageViewStatus();
            List<HomePageView> model = new List<HomePageView>();
            try
            {
                using (var db = new Orchard9Entities())
                {
                    var result = (from book in db.tblBooks
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
                    if (result.Count > 0)
                    {
                        #region Search criteria
                        if (homepage.searchType != null && homepage.searchText != null)
                        {
                            if (homepage.searchType.ToLower() == "author")
                            {
                                result = result.Where(s => s.Author.ToLower().Contains(homepage.searchText.ToLower())).ToList();
                            }
                            else if (homepage.searchType.ToLower() == "book")
                            {
                                result = result.Where(s => s.BookName.ToLower().Contains(homepage.searchText.ToLower())).ToList();
                            }
                        }
                        #endregion
                        #region Filter Criteria
                        if (homepage.Author == null && homepage.Category == null && homepage.Rating == null)
                        {
                            model = (from book in result
                                     where (book.Price >= homepage.PriceFrom && book.Price <= homepage.PriceTo)
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
                        else if (homepage.Author != null && homepage.Category == null && homepage.Rating == null)
                        {
                            model = (from book in result
                                     where (book.Price >= homepage.PriceFrom && book.Price <= homepage.PriceTo)
                                     && homepage.Author.Contains(book.Author)
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
                        else if (homepage.Author != null && homepage.Category != null && homepage.Rating == null)
                        {
                            model = (from book in result
                                     where (book.Price >= homepage.PriceFrom && book.Price <= homepage.PriceTo)
                                     && homepage.Author.Contains(book.Author) && homepage.Category.Contains(book.Category)
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
                        else if (homepage.Author != null && homepage.Category == null && homepage.Rating != null)
                        {
                            model = (from book in result
                                     where (book.Price >= homepage.PriceFrom && book.Price <= homepage.PriceTo)
                                     && homepage.Author.Contains(book.Author) && homepage.Rating.Contains(book.Rating)
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
                        else if (homepage.Author == null && homepage.Category != null && homepage.Rating == null)
                        {
                            model = (from book in result
                                     where (book.Price >= homepage.PriceFrom && book.Price <= homepage.PriceTo)
                                     && homepage.Category.Contains(book.Category)
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
                        else if (homepage.Author == null && homepage.Category != null && homepage.Rating != null)
                        {
                            model = (from book in result
                                     where (book.Price >= homepage.PriceFrom && book.Price <= homepage.PriceTo)
                                      && homepage.Category.Contains(book.Category) && homepage.Rating.Contains(book.Rating)
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
                        else if (homepage.Author == null && homepage.Category == null && homepage.Rating != null)
                        {
                            model = (from book in result
                                     where (book.Price >= homepage.PriceFrom && book.Price <= homepage.PriceTo)
                                     && homepage.Rating.Contains(book.Rating)
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
                        else if (homepage.Author != null && homepage.Category != null && homepage.Rating != null)
                        {
                            model = (from book in result
                                     where (book.Price >= homepage.PriceFrom && book.Price <= homepage.PriceTo)
                                     && homepage.Author.Contains(book.Author) && homepage.Category.Contains(book.Category) && homepage.Rating.Contains(book.Rating)
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
                        #endregion

                        ob.statuslist = model;
                        if (model.Count > 0)
                        {
                            ob.statusMessage = "Success";
                        }
                        else
                        {
                            ob.statusMessage = "No books avialble for your selected filters";
                        }
                    }
                    else
                    {
                        ob.statusMessage = "No books avialble in DB";
                    }

                }
            }
            catch (Exception ex)
            {
                ob.statuslist = model;
                ob.statusMessage = ex.Message;
            }
            return ob;
        }
        //this logic is used to fetch the values present in the Category column in the table
        public CategoryViewModel Category()
        {
            CategoryViewModel model = new CategoryViewModel();
            try
            {
                using (var db = new Orchard9Entities())
                {
                    model.CategoryName = (from book in db.tblBooks
                                          where book.isactive == true
                                          orderby book.Category ascending
                                          select book.Category).Distinct().ToList();
                }

                if (model.CategoryName.Count > 0)
                {
                    model.StatusMessage = "Success";
                }
                else
                {
                    model.StatusMessage = "No Categories found";
                }
            }

            catch (Exception ex)
            {
                model.StatusMessage = ex.Message;
            }
            return model;
        }
        //this logic is used to fetch the values present in the Author column in the table
        public AuthorViewModel Author()
        {
            AuthorViewModel model = new AuthorViewModel();
            try
            {
                using (var db = new Orchard9Entities())
                {
                    model.AuthorName = (from book in db.tblBooks
                                        where book.isactive == true
                                        orderby book.Author ascending
                                        select book.Author).Distinct().ToList();
                }

                if (model.AuthorName.Count > 0)
                {
                    model.StatusMessage = "Success";
                }
                else
                {
                    model.StatusMessage = "No Categories found";
                }
            }

            catch (Exception ex)
            {
                model.StatusMessage = ex.Message;
            }
            return model;
        }
        //this logic is used to fetch the values present in the rating column in the table
        public RatingViewModel Ratings()
        {
            RatingViewModel model = new RatingViewModel();
            try
            {
                using (var db = new Orchard9Entities())
                {
                    model.Ratings = (from book in db.tblBooks
                                     where book.isactive == true
                                     orderby book.Rating ascending
                                     select book.Rating).Distinct().ToList();
                }

                if (model.Ratings.Count > 0)
                {
                    model.StatusMessage = "Success";
                }
                else
                {
                    model.StatusMessage = "No Categories found";
                }
            }

            catch (Exception ex)
            {
                model.StatusMessage = ex.Message;
            }
            return model;
        }

    }
}
