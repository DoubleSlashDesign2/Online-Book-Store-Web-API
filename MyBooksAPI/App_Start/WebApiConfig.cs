using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyBooksAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            #region Admin
            config.Routes.MapHttpRoute(
              name: "DisplayBooks",
              routeTemplate: "api/Admin",
              defaults: new { controller = "Admin", action = "DisplayBooks", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "AddBook",
              routeTemplate: "api/Admin/AddBook",
              defaults: new { controller = "Admin", action = "AddBook", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "RemoveBook",
              routeTemplate: "api/Admin/RemoveBook",
              defaults: new { controller = "Admin", action = "RemoveBook", id = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
              name: "EditBook",
              routeTemplate: "api/Admin/EditBook",
              defaults: new { controller = "Admin", action = "EditBook", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
             name: "InvoiceTableUpdate",
             routeTemplate: "api/Admin/InvoiceTableUpdate",
             defaults: new { controller = "Admin", action = "InvoiceTableUpdate", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
              name: "DisplayUsers",
              routeTemplate: "api/Admin/DisplayUsers",
              defaults: new { controller = "Admin", action = "DisplayUsers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "RemoveUser",
              routeTemplate: "api/Admin/RemoveUser",
              defaults: new { controller = "Admin", action = "RemoveUser", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "DisplayPartners",
              routeTemplate: "api/Admin/DisplayPartners",
              defaults: new { controller = "Admin", action = "DisplayPartners", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "ApprovePartner",
              routeTemplate: "api/Admin/ApprovePartner",
              defaults: new { controller = "Admin", action = "ApprovePartner", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
             name: "modifybook",
             routeTemplate: "api/Admin/modifybook",
             defaults: new { controller = "Admin", action = "modifybook", id = RouteParameter.Optional }
           );

           
              config.Routes.MapHttpRoute(
              name: "UnblockUser",
              routeTemplate: "api/Admin/UnblockUser",
              defaults: new { controller = "Admin", action = "UnblockUser", id = RouteParameter.Optional
    }
            ); 
 

            #endregion

            #region Display
            config.Routes.MapHttpRoute(
             name: "Displaybookdetails",
             routeTemplate: "api/Display",
             defaults: new { controller = "Home", action = "getBookdetails", id = RouteParameter.Optional }
           );
            #endregion 
            #region Cart
            config.Routes.MapHttpRoute(
              name: "CartDisplay",
              routeTemplate: "api/Cart",
              defaults: new { controller = "Cart", action = "CartAction", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
             name: "CartRemove",
             routeTemplate: "api/Cart/Remove",
             defaults: new { controller = "Cart", action = "Remove", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
             name: "Buy",
             routeTemplate: "api/Cart/Buy",
             defaults: new { controller = "Cart", action = "Buy", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
             name: "AddToCart",
             routeTemplate: "api/Cart/AddToCart",
             defaults: new { controller = "Cart", action = "AddToCart", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
           name: "Invoice",
           routeTemplate: "api/Cart/Invoice",
           defaults: new { controller = "Cart", action = "Invoice", id = RouteParameter.Optional }
          );
            config.Routes.MapHttpRoute(
         name: "AddInvoice",
         routeTemplate: "api/AddInvoice",
         defaults: new { controller = "Cart", action = "AddInvoice", id = RouteParameter.Optional }
        );
            #endregion

            #region Wishlist
            config.Routes.MapHttpRoute(
                name: "InserttoCart",
                routeTemplate: "api/addToCart",
                defaults: new { controller = "WishList", action = "addToCart", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "getBookDetails",
                routeTemplate: "api/getBookDetails",
                defaults: new { controller = "WishList", action = "getBookDetails", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "deletefromWishlist",
                routeTemplate: "api/deleteFromWishList",
                defaults: new { controller = "WishList", action = "deleteFromWishList", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "RetriveAll",
               routeTemplate: "api/displayAllItems",
               defaults: new { controller = "WishList", action = "displayAllItems", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "addToWishList",
               routeTemplate: "api/addToWishList",
               defaults: new { controller = "WishList", action = "addToWishList", id = RouteParameter.Optional }
           );
            #endregion

            #region Filter - Home
            config.Routes.MapHttpRoute(
                name: "FilterPage",
                routeTemplate: "api/Filter",
                defaults: new { controller = "Home", action = "filterbooks", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
               name: "Category",
               routeTemplate: "api/Categories",
               defaults: new { controller = "Home", action = "Category", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
              name: "Author",
              routeTemplate: "api/AuthorName",
              defaults: new { controller = "Home", action = "Author", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
             name: "Ratings",
             routeTemplate: "api/Rating",
             defaults: new { controller = "Home", action = "Ratings", id = RouteParameter.Optional }
            );
            #endregion

            #region Search - Home
            //Web API Confg for Searchbook action from Test Controller.
            config.Routes.MapHttpRoute(
                name: "AutoSearch",
                routeTemplate: "api/AutoSearch/{id}",          // For taking input eg. text=Bookname.
                defaults: new { controller = "Home", action = "Searchbook", id = RouteParameter.Optional }
            );

            // for search by a bookname display all data.
            config.Routes.MapHttpRoute(
                name: "searchdetail",
                routeTemplate: "api/SearchDetails/{id}",            // For taking input with Authorname and Bookname.
                defaults: new { controller = "Home", action = "Details", id = RouteParameter.Optional }
            );
            #endregion

            #region Login/Sign-Up
            config.Routes.MapHttpRoute(
               name: "GetUserDetails",
               routeTemplate: "api/Login",
               defaults: new { controller = "User", action = "GetUserDetails", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "ForgotPassword",
              routeTemplate: "api/ForgotPassword/{id}",
              defaults: new { controller = "User", action = "ForgotPassword", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "PostUserDetails",
                routeTemplate: "api/Registration",
                defaults: new { controller = "User", action = "PostUserDetails", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "UserVerification",
               routeTemplate: "api/UserVerification/{id}",
               defaults: new { controller = "User", action = "UserVerfication", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "PostGoogleDetails",
              routeTemplate: "api/PostGoogleDetails/{id}",
              defaults: new { controller = "User", action = "PostGoogleDetails", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
             name: "PostPartnerDetails",
             routeTemplate: "api/PostPartnerDetails/{id}",
             defaults: new { controller = "User", action = "PostPartnerDetails", id = RouteParameter.Optional }
           );
            config.Routes.MapHttpRoute(
              name: "GetPartnerDetails",
              routeTemplate: "api/GetPartnerDetails",
              defaults: new { controller = "User", action = "GetPartnerDetails", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
              name: "GetAdminDetails",
              routeTemplate: "api/GetAdminDetails",
              defaults: new { controller = "User", action = "GetAdminDetails", id = RouteParameter.Optional }
           );
            config.Routes.MapHttpRoute(
             name: "UserToPartner",
             routeTemplate: "api/UserToPartner",
             defaults: new { controller = "User", action = "UserToPartner", id = RouteParameter.Optional }
          );
            config.Routes.MapHttpRoute(
             name: "PartnerForgotPassword",
             routeTemplate: "api/PartnerForgotPassword/{id}",
             defaults: new { controller = "User", action = "PartnerForgotPassword", id = RouteParameter.Optional }
           );


            #endregion
        }
    }
}
