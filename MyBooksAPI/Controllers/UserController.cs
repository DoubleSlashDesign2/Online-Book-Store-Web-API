using System.Web.Http;
using MyBooksAPI.BusinessAccessLayer.Services;
using MyBooksAPI.BusinessAccessLayer.IServices;
using MyBooksAPI.Entities.Models;
using MyBooksAPI.Entities.ViewModels;

namespace MyBooksAPI.Controllers
{
    public class UserController : ApiController
    {

        private readonly IUserService userReg;

        public UserController(UserService _userReg)
        {
            userReg = _userReg;
        }
        /// <summary>
        /// Action for Posting User Details
        /// </summary>
        /// <param name="userTableClass"></param>
        /// <returns></returns>
        [HttpPost]
        public RegistrationResponseViewModel PostUserDetails(UserTableClass userTableClass)
        {

            return userReg.UserRegister(userTableClass);

        }
        /// <summary>
        /// /Action for getting User Details
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public LoginResponseViewModel GetUserDetails(UserLogin userLogin)
        {

            return userReg.UserLogin(userLogin);

        }

        /// <summary>
        /// Forgot password action
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        [HttpPost]
        public ForgotPasswordViewModel ForgotPassword(ForgotPasswordViewModel emailId)
        {
            return userReg.ForgotPass(emailId);
        }


        /// <summary>
        /// Partner Forgot password action
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        [HttpPost]
        public ForgotPasswordViewModel PartnerForgotPassword(ForgotPasswordViewModel emailId)
        {
            return userReg.PartnerForgotPass(emailId);
        }


        /// <summary>
        /// User Verification Action
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>

        [HttpGet]
        public string UserVerfication(int UserId)
        {
            return userReg.UserVerification(UserId);
        }

        /// <summary>
        /// Post google login details
        /// </summary>
        /// <param name="googleLogin"></param>
        /// <returns></returns>

        [HttpPost]
        public LoginResponseViewModel PostGoogleDetails(GoogleLogin googleLogin)
        {

            return userReg.GoogleUser(googleLogin);

        }

        /// <summary>
        /// Action for posting partner details
        /// </summary>
        /// <param name="userTableClass"></param>
        /// <returns></returns>

        [HttpPost]
        public RegistrationResponseViewModel PostPartnerDetails(UserTableClass userTableClass)
        {

            return userReg.PartnerRegister(userTableClass);

        }

        /// <summary>
        /// Action for getting partner details
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public LoginResponseViewModel GetPartnerDetails(UserLogin userLogin)
        {

            return userReg.PartnerLogin(userLogin);

        }


        /// <summary>
        /// Action for getting Administrator details
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public LoginResponseViewModel GetAdminDetails(UserLogin userLogin)
        {

            return userReg.AdminLogin(userLogin);

        }

        [HttpPost]
        public ForgotPasswordViewModel UserToPartner(ForgotPasswordViewModel forgotPasswordViewModel)
        {

            return userReg.UserToPass(forgotPasswordViewModel);

        }

    }
}
