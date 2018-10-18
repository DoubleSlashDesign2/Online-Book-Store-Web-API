using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooksAPI.Entities.ViewModels;
using MyBooksAPI.Entities.Models;

namespace MyBooksAPI.BusinessAccessLayer.IServices
{
    public interface IAdmin
    {
        BookStatus DisplayBooks();
        string AddBook(BookView book);
        string RemoveBook(string ISBN);
        string EditBook(BookEditView book);
        UserStatus DisplayUsers();
        string RemoveUser(int UserId);
        string ApprovePartner(int UserId);

        PriceStatus modifybook(WishListModel wish);

        UserStatus DisplayPartners();
        string UnblockUser(int UserId);
        string InvoiceTableUpdate();


    }
}
