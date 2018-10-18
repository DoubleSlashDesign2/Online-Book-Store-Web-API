using MyBooksAPI.Entities.Models;
using MyBooksAPI.DataAccessLayer.Services;
using MyBooksAPI.BusinessAccessLayer.IServices;
using MyBooksAPI.Entities.ViewModels;

namespace MyBooksAPI.BusinessAccessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly UserServiceManager userTableServiceDAL = new UserServiceManager();

        /// <summary>
        /// User Registration method
        /// </summary>
        /// <param name="userTableClass"></param>
        /// <returns></returns>
        public RegistrationResponseViewModel UserRegister(UserTableClass userTableClass)
        {
            return userTableServiceDAL.AddUser(userTableClass);

        }
        /// <summary>
        /// User Login method
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public LoginResponseViewModel UserLogin(UserLogin userLogin)
        {
            return userTableServiceDAL.LoginUser(userLogin);
        }

        /// <summary>
        /// Forgot password method
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public ForgotPasswordViewModel ForgotPass(ForgotPasswordViewModel Email)
        {
            string forgotEmail = Email.EmailId;
            return userTableServiceDAL.ForgotPassword(forgotEmail);
        }

        /// <summary>
        /// Partner Forgot password method
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public ForgotPasswordViewModel PartnerForgotPass(ForgotPasswordViewModel Email)
        {
            string forgotEmail = Email.EmailId;
            return userTableServiceDAL.PartnerForgotPassword(forgotEmail);
        }



        /// <summary>
        /// User email verification method
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string UserVerification(int UserId)
        {
            return userTableServiceDAL.UserVerification(UserId);
        }

        /// <summary>
        /// Google login method
        /// </summary>
        /// <param name="googleLogin"></param>
        /// <returns></returns>
        public LoginResponseViewModel GoogleUser(GoogleLogin googleLogin)
        {
            return userTableServiceDAL.GoogleLogin(googleLogin);
        }

        /// <summary>
        /// Partner Registration Method
        /// </summary>
        /// <param name="userTableClass"></param>
        /// <returns></returns>
        public RegistrationResponseViewModel PartnerRegister(UserTableClass userTableClass)
        {
            return userTableServiceDAL.AddPartner(userTableClass);

        }

        /// <summary>
        /// Partner Login Method
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public LoginResponseViewModel PartnerLogin(UserLogin userLogin)
        {
            return userTableServiceDAL.LoginPartner(userLogin);
        }


        /// <summary>
        /// Administrator Login Method
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public LoginResponseViewModel AdminLogin(UserLogin userLogin)
        {
            return userTableServiceDAL.LoginAdmin(userLogin);
        }

        public ForgotPasswordViewModel UserToPass(ForgotPasswordViewModel userToPass)
        {
            return userTableServiceDAL.UserToPartner(userToPass);
        }


    }
}
