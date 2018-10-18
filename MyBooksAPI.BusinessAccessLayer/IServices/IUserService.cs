using MyBooksAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooksAPI.Entities.ViewModels;

namespace MyBooksAPI.BusinessAccessLayer.IServices
{

    public interface IUserService
    {
        RegistrationResponseViewModel UserRegister(UserTableClass userTableClass);
        LoginResponseViewModel UserLogin(UserLogin userLogin);
        ForgotPasswordViewModel ForgotPass(ForgotPasswordViewModel Email);
        ForgotPasswordViewModel PartnerForgotPass(ForgotPasswordViewModel Email);

        string UserVerification(int UserId);
        LoginResponseViewModel GoogleUser(GoogleLogin googleLogin);
        RegistrationResponseViewModel PartnerRegister(UserTableClass userTableClass);
        LoginResponseViewModel PartnerLogin(UserLogin userLogin);
        LoginResponseViewModel AdminLogin(UserLogin userLogin);
        ForgotPasswordViewModel UserToPass(ForgotPasswordViewModel userToPass);
    }
}
