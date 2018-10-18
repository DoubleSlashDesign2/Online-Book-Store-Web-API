using MyBooksAPI.BusinessAccessLayer.IServices;
using MyBooksAPI.Entities.Models;
using MyBooksAPI.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBooksAPI.Controllers
{
    public class AdminController : ApiController
    {
        private readonly IAdmin iadmin;

        public AdminController(BusinessAccessLayer.Services.AdminService _iadmin)
        {
            iadmin = _iadmin;
        }
        [HttpGet]
        public BookStatus DisplayBooks()
        {
            return iadmin.DisplayBooks();
        }
        [HttpPost]
        public string AddBook(BookView book)
        {
            return iadmin.AddBook(book);
        }
        [HttpGet]
        public string RemoveBook(string ISBN)
        {
            return iadmin.RemoveBook(ISBN);
        }
        [HttpPut]
        public string EditBook(BookEditView book)
        {
            return iadmin.EditBook(book);
        }
        [HttpGet]
        public UserStatus DisplayUsers()
        {
            return iadmin.DisplayUsers();
        }
        [HttpGet]
        public string RemoveUser(int UserId)
        {
            return iadmin.RemoveUser(UserId);
        }
        [HttpGet]
        public string InvoiceTableUpdate()
        {
            return iadmin.InvoiceTableUpdate();
        }
        [HttpPut]
        public PriceStatus modifybook(WishListModel wish)
        {
            return iadmin.modifybook(wish);
        }
        [HttpGet]
        public UserStatus DisplayPartners()
        {
            return iadmin.DisplayPartners();
        }
        [HttpGet]
        public string ApprovePartner(int UserId)
        {
            return iadmin.ApprovePartner(UserId);
        }

        [HttpGet]
        public string UnblockUser(int UserId)
        {
            return iadmin.UnblockUser(UserId);
        }

    }
}
