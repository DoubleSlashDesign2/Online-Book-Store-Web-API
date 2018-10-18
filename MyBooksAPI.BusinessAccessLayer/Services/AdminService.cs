using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooksAPI.BusinessAccessLayer.IServices;
using MyBooksAPI.Entities.ViewModels;
using MyBooksAPI.DataAccessLayer.Services;
using MyBooksAPI.Entities.Models;

namespace MyBooksAPI.BusinessAccessLayer.Services
{
    public class AdminService:IAdmin
    {
        AdminManager am = new AdminManager();
        public BookStatus DisplayBooks()
        {
            return am.DisplayBooks();
        }
        public string AddBook(BookView book)
        {
            return am.AddBook(book);
        }
        public string RemoveBook(string ISBN)
        {
            return am.RemoveBook(ISBN);
        }
        public string EditBook(BookEditView book)
        {
            return am.EditBook(book);
        }
        public UserStatus DisplayUsers()
        {
            return am.DisplayUsers();
        }
        public string RemoveUser(int UserId)
        {
            return am.RemoveUser(UserId); 
        }
        public string UnblockUser(int UserId)
        {
            return am.UnblockUser(UserId);
        }
        public UserStatus DisplayPartners()
        {
            return am.DisplayPartners();
        }
        public string ApprovePartner(int UserId)
        {
            return am.ApprovePartner(UserId);
        }

        public PriceStatus modifybook(WishListModel wish)
        {
            return am.modifybook(wish);
        }

        public string InvoiceTableUpdate()
        {
            return am.InvoiceTableUpdate();
        }
    }
}
