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
    public class AdminManager
    {
        public BookStatus DisplayBooks()   
        {
            BookStatus status = new BookStatus();
                using (var db = new Orchard9Entities())
                {
               
                    var query = (from books in db.tblBooks
                                 where books.isactive==true
                                 select new BookView()
                                 {
                                     ISBN = books.ISBN,
                                     BookName = books.BookName,
                                     Category = books.Category,
                                     Price=books.Price,
                                     Rating=books.Rating,
                                     Author=books.Author,
                                     Publisher=books.Publisher,
                                     Description=books.Description,
                                     BookImageUrl=books.BookImageUrl
                                 }).ToList();
                status.statusList = query;       
                }
            return status;
        }

        public string AddBook(BookView book)
        {
            string msg = "";
            try
            {
                using (var db = new Orchard9Entities())
                {
                    if ((from e in db.tblUsers where e.UserId == book.UserId && e.IsActive == false select e.UserId).ToList().Count > 0)
                    {
                        return "You are Blocked by Admin";
                    }
                    else if((from e in db.tblBooks where (e.ISBN == book.ISBN && e.isactive == false) select e.ISBN).ToList().Count > 0)
                    {
                        db.tblBooks.Where(b => b.ISBN == book.ISBN).ToList().ForEach(b =>
                        {
                            b.BookName = book.BookName;
                            b.Category = book.Category;
                            b.Price = book.Price;
                            b.Rating = book.Rating;
                            b.Author = book.Author;
                            b.Publisher = book.Publisher;
                            b.Description = book.Description;
                            b.BookImageUrl = book.BookImageUrl;
                            b.isactive = true;
                            b.createddate = System.DateTime.Now;
                        });
                        db.SaveChanges();
                        return "Book updated";
                    }

                    else if ((from e in db.tblBooks where e.ISBN == book.ISBN || (e.BookName == book.BookName && e.Author == book.Author) select e.ISBN).ToList().Count > 0)
                    {
                        return "Book Already Exists";
                    }
                    else
                    {
                        db.tblBooks.Add(new tblBook()
                        {
                            ISBN = book.ISBN,
                            BookName = book.BookName,
                            Category = book.Category,
                            Price = book.Price,
                            Rating = book.Rating,
                            Author = book.Author,
                            Publisher = book.Publisher,
                            Description = book.Description,
                            BookImageUrl = book.BookImageUrl,
                            isactive=true,
                            createddate=System.DateTime.Now
                        });
                        db.SaveChanges();
                        return "New Book Added";
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
        public string RemoveBook(string ISBN)  
        {
            string message;
            try
            {
                using (var db = new Orchard9Entities())
                {
                    db.tblBooks.Where(u => u.ISBN == ISBN).ToList().ForEach(s => s.isactive = false);
                    db.SaveChanges();
                    message = ISBN + " removed ";
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return message;
        }
        public string EditBook(BookEditView book)
        {
            string message = "";
            try
            {
                using (var db = new Orchard9Entities())
                {
                    db.tblBooks.Where(b => b.ISBN == book.ISBN).ToList().ForEach(b =>
                        {
                            b.Price = book.Price;
                        });
                    db.SaveChanges();
                    message = book.ISBN + " Price updated";
                }

            }
            catch(Exception e)
            {
                message = e.Message;
            }
            return message;
        }
        public UserStatus DisplayUsers()
        {
            UserStatus status = new UserStatus();
            using (var db = new Orchard9Entities())
            {
                var query = (from users in db.tblUsers
                             where users.Role!=2
                             select new UserView()
                             {
                                 UserId = users.UserId,
                                 EmailId = users.EmailId,
                                 Name = users.Name,
                                 UserType = users.UserType,
                                 IsVerified = users.IsVerified,
                                 Role = users.Role,
                                 IsActive = users.IsActive
                             }).ToList();
                status.statusList = query;
            }
            return status;
        }
        public string RemoveUser(int UserId)
        {
            string msg = "";
            try
            {
                using (var db = new Orchard9Entities())
                {
                   
                    {
                        db.tblUsers.Where(u => u.UserId == UserId).ToList().ForEach(s => s.IsActive = false);
                        db.SaveChanges();
                        msg = "User Blocked";
                      
                        return msg;
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
        public string UnblockUser(int UserId)
        {
            string msg = "";
            try
            {
                using (var db = new Orchard9Entities())
                {

                    {
                        db.tblUsers.Where(u => u.UserId == UserId).ToList().ForEach(s => s.IsActive = true);
                        db.SaveChanges();
                        msg = "User Unblocked";

                        return msg;
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
        public UserStatus DisplayPartners()
        {
            UserStatus status = new UserStatus();
            using (var db = new Orchard9Entities())
            {
                var query = (from users in db.tblUsers
                             where users.Role==5
                             select new UserView()
                             {
                                 UserId = users.UserId,
                                 EmailId = users.EmailId,
                                 Name = users.Name,
                                 UserType = users.UserType,
                                 IsVerified = users.IsVerified,
                                 Role = users.Role,
                                 IsActive = users.IsActive,
                                 CreatedDate=users.CreatedDate
                             }).ToList();
                status.statusList = query;
            }
            return status;
        }
        public string ApprovePartner(int UserId)
        {
            string msg = "";
            try
            {
                using (var db = new Orchard9Entities())
                {

                    {
                        db.tblUsers.Where(u => u.UserId == UserId).ToList().ForEach(s => s.Role = 3);
                        db.SaveChanges();
                        msg = "Partner Approved";
                        return msg;
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }


        public PriceStatus modifybook(WishListModel wish)
        {
            string s = "";

            PriceStatus pr = new PriceStatus();



            try
            {
                using (var dbcontext = new Orchard9Entities())
                {

                    double? amount = 0;
                    if ((from d in dbcontext.tblWishlists where d.ISBN == wish.ISBN select d).Count() > 0)
                    {
                        amount = (from d in dbcontext.tblWishlists where d.ISBN == wish.ISBN select d.CurrentPrice).FirstOrDefault();
                    }
                    else
                    {
                        amount = (from d in dbcontext.tblBooks where d.ISBN == wish.ISBN select d.Price).FirstOrDefault();
                    }
                    var dis = Convert.ToDouble(wish.price);

                    var query = (from e in dbcontext.tblWishlists
                                 join d in dbcontext.tblBooks on e.ISBN equals d.ISBN
                                 join x in dbcontext.tblUsers on e.UserId equals x.UserId
                                 where e.UserId == x.UserId && wish.ISBN == d.ISBN
                                 select new PriceModel() { mailid = x.EmailId }).ToList();



                    if ((from d in dbcontext.tblBooks where d.ISBN == wish.ISBN select d.Price).ToList().Count == 0)
                    {
                        pr.statusMessage = "This book does not exist";

                        return pr;
                    }
                    if (amount == dis)
                    {
                        pr.statusMessage = "no changes";
                        pr.statusList = query;
                        pr.changedPrice = 0;
                        pr.bookName = wish.BookName;

                    }
                    else if (amount > dis)

                    {
                        pr.changedPrice = amount - dis;
                        pr.statusList = query;
                        pr.statusMessage = "reduced";
                        pr.bookName = wish.BookName;
                    }
                    else
                    {
                        pr.changedPrice = dis - amount;
                        pr.statusList = query;
                        pr.bookName = wish.BookName;
                        pr.statusMessage = "increased";
                    }





                    dbcontext.tblBooks.Where(h => h.ISBN == wish.ISBN).ToList().ForEach(h =>
                    {

                        h.Price = wish.price;
                        h.Publisher = wish.Publisher;
                        h.Author = wish.Author;
                        h.Rating = wish.rating;
                        h.BookName = wish.BookName;
                        h.Description = "jj";
                        h.Category = "hhh";
                        h.isactive = true;
                        h.BookImageUrl = wish.BookImageUrl;



                    });
                    dbcontext.tblWishlists.Where(h => h.ISBN == wish.ISBN).ToList().ForEach(h =>
                    {
                        h.CurrentPrice = wish.price;




                    });
                    dbcontext.SaveChanges();





                }
            }

            catch (Exception e)
            {
                s = e.Message;
                pr.statusMessage = s;
            }
            return pr;



        }

        public string InvoiceTableUpdate()
        {
            using (var db = new Orchard9Entities())
            {
                try
                {
                    var query = db.tblUsers.Where(x => x.IsActive == false).Select(r => r.UserId).Distinct().ToList();
                    db.tblInvoices.Where(y => query.Contains((int)y.UserId)).ToList().ForEach(y => y.InvoiceStatus = false);
                    db.SaveChanges();
                    return "Success";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }
    }
}
