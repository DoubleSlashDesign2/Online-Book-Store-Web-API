using System;
using System.Linq;
using MyBooksAPI.Entities.Models;
using MyBooksAPI.Entities.ViewModels;
using MyBooksAPI.DataAccessLayer.DB;


namespace MyBooksAPI.DataAccessLayer.Services
{
    public class UserServiceManager
    {
        /// <summary>
        /// User Registration
        /// </summary>
        /// <param name="userTableClass"></param>
        /// <returns></returns>
        public RegistrationResponseViewModel AddUser(UserTableClass userTableClass)
        {
            RegistrationResponseViewModel model = new RegistrationResponseViewModel();
            try
            {
                if (userTableClass != null)
                {
                    using (var db = new Orchard9Entities())
                    {
                        //checking whether email already exists in the database or not
                        var isEmailExist = db.tblUsers.Where(a => a.EmailId == userTableClass.EmailId).FirstOrDefault();

                        if (isEmailExist == null)
                        {
                            db.tblUsers.Add(new tblUser()
                            {
                                EmailId = userTableClass.EmailId,
                                Name = userTableClass.Name,
                                Password = userTableClass.Password,
                                ContactNo = userTableClass.ContactNo,
                                Gender = userTableClass.Gender,
                                Address = userTableClass.Address,
                                ReferralId = userTableClass.ReferralId,
                                DateOfBirth = userTableClass.DateOfBirth,
                                IsVerified = false,
                                Role = 1,
                                IsActive = true,
                                CreatedDate = DateTime.Now,
                                UserType = "Normal"


                            });
                            //saving changes to database
                            db.SaveChanges();
                            var data = (from res in db.tblUsers
                                        where res.EmailId == userTableClass.EmailId
                                        select new { res.EmailId, res.UserId }).FirstOrDefault();
                            model.UserId = data.UserId;
                            model.Email = data.EmailId;
                            model.StatusMessage = "Registration successfully done. Account activation link has been sent to your Email ID " + model.Email;
                        }
                        else
                        {
                            model.StatusMessage = "Email Already Exist";
                        }

                    }
                }
                else
                {
                    model.StatusMessage = "Input model is empty";
                }
            }
            catch (Exception ex)
            {
                model.StatusMessage = ex.Message;
            }
            return model;
        }



        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public LoginResponseViewModel LoginUser(UserLogin userLogin)
        {
            LoginResponseViewModel logModel = new LoginResponseViewModel();
            try
            {
                if (userLogin != null)
                {
                    using (var db = new Orchard9Entities())
                    {
                        // checking whether Email id is present in the database or not
                        var v = db.tblUsers.Where(a => a.EmailId == userLogin.EmailId && (a.Role==1 || a.Role==5)).FirstOrDefault();
                        var v1 = db.tblUsers.Where(a => a.EmailId==userLogin.EmailId && a.IsActive==true).FirstOrDefault();

                       
                        if (v != null)
                        {
                            

                            if (!v.IsVerified)
                            {
                                logModel.StatusMessage = "Email Not Verified";
                                return logModel;
                            }
                            if (string.Compare(userLogin.Password, v.Password) == 0)
                            {
                                if (v1 == null)
                                {
                                    logModel.StatusMessage = "Account is Blocked";
                                    return logModel;
                                }
                                logModel.userLogin = (from res in db.tblUsers
                                                      where res.EmailId == userLogin.EmailId
                                                      select new UserLogin()
                                                      {
                                                          EmailId = res.EmailId,
                                                          UserId = res.UserId,
                                                          Role = res.Role


                                                      }).FirstOrDefault();
                                logModel.StatusMessage = "Login Successful";
                                return logModel;
                            }
                            else
                            {
                                logModel.StatusMessage = "Invalid Password";
                                return logModel;
                            }
                        }
                        else
                        {
                            logModel.StatusMessage = " User account not found, please register before Login ";
                            return logModel;
                        }
                    }
                }
                else
                {
                    logModel.StatusMessage = "Input model is empty";
                    return logModel;
                }

            }
            catch (Exception ex)
            {
                logModel.StatusMessage = ex.Message;
                return logModel;
            }


        }


        /// <summary>
        /// Forgot Password
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public ForgotPasswordViewModel ForgotPassword(string Email)
        {
            ForgotPasswordViewModel passModel = new ForgotPasswordViewModel();
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    using (var db = new Orchard9Entities())
                    {
                        var v = db.tblUsers.Where(a => a.EmailId == Email && a.UserType == "Normal" && (a.Role==1 || a.Role==5)).FirstOrDefault();
                        var v1 = db.tblUsers.Where(a => a.EmailId == Email && a.IsActive == true).FirstOrDefault();

                        
                        if (v != null)
                        {
                            if (v1 == null)
                            {
                                passModel.StatusMessage = "Account is Blocked";
                                return passModel;
                            }
                            if (!v.IsVerified)
                            {
                                passModel.StatusMessage = "Email Not Verified";
                                return passModel;
                            }
                            else
                            {
                                passModel = (from res in db.tblUsers
                                             where res.EmailId == Email
                                             select new ForgotPasswordViewModel
                                             {
                                                 UserId = res.UserId,
                                                 EmailId = res.EmailId,
                                                 Password = res.Password
                                             }).FirstOrDefault();
                                passModel.StatusMessage = "Records found! Check Email for Password";
                                return passModel;

                            }

                        }
                        else
                        {
                            passModel.StatusMessage = "Email Id is not Present";
                            return passModel;
                        }
                    }

                }
                else
                {
                    passModel.StatusMessage = "Email Id is empty";
                    return passModel;
                }
            }
            catch (Exception ex)
            {
                passModel.StatusMessage = ex.Message;
                return passModel;
            }

        }

        //-------------------------------------------------------Partner Forgot Password--------------------------------------------------------

        /// <summary>
        /// Partner Forgot Password
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public ForgotPasswordViewModel PartnerForgotPassword(string Email)
        {
            ForgotPasswordViewModel passModel = new ForgotPasswordViewModel();
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    using (var db = new Orchard9Entities())
                    {
                        var v = db.tblUsers.Where(a => a.EmailId == Email && a.UserType == "Normal" && a.Role==3).FirstOrDefault();
                        var v1 = db.tblUsers.Where(a => a.EmailId == Email && a.IsActive == true).FirstOrDefault();

                        
                        if (v != null)
                        {
                            if (v1 == null)
                            {
                                passModel.StatusMessage = "Account is Blocked";
                                return passModel;
                            }
                            if (!v.IsVerified)
                            {
                                passModel.StatusMessage = "Email Not Verified";
                                return passModel;
                            }
                            else
                            {
                                passModel = (from res in db.tblUsers
                                             where res.EmailId == Email
                                             select new ForgotPasswordViewModel
                                             {
                                                 UserId = res.UserId,
                                                 EmailId = res.EmailId,
                                                 Password = res.Password
                                             }).FirstOrDefault();
                                passModel.StatusMessage = "Records found! Check Email for Password";
                                return passModel;

                            }

                        }
                        else
                        {
                            passModel.StatusMessage = "Email Id is not Present";
                            return passModel;
                        }
                    }

                }
                else
                {
                    passModel.StatusMessage = "Email Id is empty";
                    return passModel;
                }
            }
            catch (Exception ex)
            {
                passModel.StatusMessage = ex.Message;
                return passModel;
            }

        }




        /// <summary>
        /// User Verifiction
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string UserVerification(int UserId)
        {
            try
            {
                using (var db = new Orchard9Entities())
                {

                    var verifyUser = db.tblUsers.Where(a => a.UserId == UserId).FirstOrDefault();
                    if (verifyUser != null)
                    {
                        db.tblUsers.Where(a => a.UserId == UserId).ToList().ForEach(i => i.IsVerified = true);
                        db.SaveChanges();
                        return "User verified successfully";
                    }
                    else
                    {
                        return "User verification Error";
                    }


                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Google Login
        /// </summary>
        /// <param name="googleLogin"></param>
        /// <returns></returns>
        public LoginResponseViewModel GoogleLogin(GoogleLogin googleLogin)
        {
            LoginResponseViewModel googleModel = new LoginResponseViewModel();

            if (googleLogin != null)
            {
                using (var db = new Orchard9Entities())
                {
                    var gUser = db.tblUsers.Where(a => a.EmailId == googleLogin.emailaddress).FirstOrDefault();
                    var gUser1 = db.tblUsers.Where(a => a.EmailId == googleLogin.emailaddress && a.IsActive==true).FirstOrDefault();

                    if(gUser1==null)
                    {
                        googleModel.StatusMessage = "Account is Blocked";
                        return googleModel;
                    }

                    if (gUser == null)
                    {
                        db.tblUsers.Add(new tblUser()
                        {
                            EmailId = googleLogin.emailaddress,
                            Name = googleLogin.givenname,
                            IsVerified = true,
                            UserType = "External",
                            Role = 1,
                            IsActive=true,
                            CreatedDate = DateTime.Now,
                            DateOfBirth = DateTime.Now.Date

                        });
                        db.SaveChanges();
                        googleModel.StatusMessage = "Login Successful";


                    }
                    googleModel.userLogin = (from res in db.tblUsers
                                             where res.EmailId == googleLogin.emailaddress
                                             select new UserLogin()
                                             {
                                                 EmailId = res.EmailId,
                                                 UserId = res.UserId


                                             }).FirstOrDefault();
                    googleModel.StatusMessage = "Login Successful";
                    return googleModel;
                }
            }
            else
            {
                googleModel.StatusMessage = "Empty Model";
            }
            return googleModel;
        }



        /// <summary>
        /// Partner Registration
        /// </summary>
        /// <param name="userTableClass"></param>
        /// <returns></returns>
        public RegistrationResponseViewModel AddPartner(UserTableClass userTableClass)
        {
            RegistrationResponseViewModel model = new RegistrationResponseViewModel();
            try
            {
                if (userTableClass != null)
                {
                    using (var db = new Orchard9Entities())
                    {
                        //checking whether email already exists in the database or not
                        var isEmailExist = db.tblUsers.Where(a => a.EmailId == userTableClass.EmailId).FirstOrDefault();

                        if (isEmailExist == null)
                        {
                            db.tblUsers.Add(new tblUser()
                            {
                                EmailId = userTableClass.EmailId,
                                Name = userTableClass.Name,
                                Password = userTableClass.Password,
                                ContactNo = userTableClass.ContactNo,
                                Gender = userTableClass.Gender,
                                Address = userTableClass.Address,
                                ReferralId = userTableClass.ReferralId,
                                DateOfBirth = userTableClass.DateOfBirth,
                                IsVerified = false,
                                Role = 5,
                                IsActive=true,
                                CreatedDate = DateTime.Now,
                                UserType = "Normal"


                            });
                            //saving changes to database
                            db.SaveChanges();
                            var data = (from res in db.tblUsers
                                        where res.EmailId == userTableClass.EmailId
                                        select new { res.EmailId, res.UserId }).FirstOrDefault();
                            model.UserId = data.UserId;
                            model.Email = data.EmailId;
                            model.StatusMessage = "Registration successfully done. Account activation link has been sent to your Email ID " + model.Email;
                        }
                        else
                        {
                            model.StatusMessage = "Email Already Exist";
                        }

                    }
                }
                else
                {
                    model.StatusMessage = "Input model is empty";
                }
            }
            catch (Exception ex)
            {
                model.StatusMessage = ex.Message;
            }
            return model;
        }



        /// <summary>
        /// Partner Login
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public LoginResponseViewModel LoginPartner(UserLogin userLogin)
        {
            LoginResponseViewModel logModel = new LoginResponseViewModel();
            try
            {
                if (userLogin != null)
                {
                    using (var db = new Orchard9Entities())
                    {
                        // checking whether Email id is present in the database or not
                        var v = db.tblUsers.Where(a => a.EmailId == userLogin.EmailId && a.Role == 3).FirstOrDefault();
                        var v1 = db.tblUsers.Where(a => a.EmailId == userLogin.EmailId && a.IsActive == true).FirstOrDefault();

                        
                        if (v != null)
                        {
                            
                            if (!v.IsVerified)
                            {
                                logModel.StatusMessage = "Email Not Verified";
                                return logModel;
                            }
                            if (string.Compare(userLogin.Password, v.Password) == 0)
                            {
                                if (v1 == null)
                                {
                                    logModel.StatusMessage = "Account is Blocked";
                                    return logModel;
                                }
                                logModel.userLogin = (from res in db.tblUsers
                                                      where res.EmailId == userLogin.EmailId
                                                      select new UserLogin()
                                                      {
                                                          EmailId = res.EmailId,
                                                          UserId = res.UserId,
                                                          Role = res.Role


                                                      }).FirstOrDefault();
                                logModel.StatusMessage = "Login Successful";
                                return logModel;
                            }
                            else
                            {
                                logModel.StatusMessage = "Invalid Password";
                                return logModel;
                            }
                        }
                        else
                        {
                            logModel.StatusMessage = " User account not found, please register before Login ";
                            return logModel;
                        }
                    }
                }
                else
                {
                    logModel.StatusMessage = "Input model is empty";
                    return logModel;
                }

            }
            catch (Exception ex)
            {
                logModel.StatusMessage = ex.Message;
                return logModel;
            }


        }


        /// <summary>
        /// Administrator Login
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public LoginResponseViewModel LoginAdmin(UserLogin userLogin)
        {
            LoginResponseViewModel logModel = new LoginResponseViewModel();
            try
            {
                if (userLogin != null)
                {
                    using (var db = new Orchard9Entities())
                    {
                        // checking whether Email id is present in the database or not
                        var v = db.tblUsers.Where(a => a.EmailId == userLogin.EmailId && a.Role == 2).FirstOrDefault();
                        if (v != null)
                        {
                            if (!v.IsVerified)
                            {
                                logModel.StatusMessage = "Email Not Verified";
                                return logModel;
                            }
                            if (string.Compare(userLogin.Password, v.Password) == 0)
                            {
                                logModel.userLogin = (from res in db.tblUsers
                                                      where res.EmailId == userLogin.EmailId
                                                      select new UserLogin()
                                                      {
                                                          EmailId = res.EmailId,
                                                          UserId = res.UserId,
                                                          Role = res.Role


                                                      }).FirstOrDefault();
                                logModel.StatusMessage = "Login Successful";
                                return logModel;
                            }
                            else
                            {
                                logModel.StatusMessage = "Invalid Password";
                                return logModel;
                            }
                        }
                        else
                        {
                            logModel.StatusMessage = " User account not found, please register before Login ";
                            return logModel;
                        }
                    }
                }
                else
                {
                    logModel.StatusMessage = "Input model is empty";
                    return logModel;
                }

            }
            catch (Exception ex)
            {
                logModel.StatusMessage = ex.Message;
                return logModel;
            }


        }

        /// <summary>
        /// User To Partner
        /// </summary>
        /// <param name="userToPartner"></param>
        /// <returns></returns>

        public ForgotPasswordViewModel UserToPartner(ForgotPasswordViewModel userToPartner)
        {
            ForgotPasswordViewModel logModel = new ForgotPasswordViewModel();
            try
            {
                if (userToPartner != null)
                {
                    using (var db = new Orchard9Entities())
                    {
                        var v = db.tblUsers.Where(a => a.EmailId == userToPartner.EmailId && a.UserType!="External").FirstOrDefault();
                        var v1 = db.tblUsers.Where(a => a.EmailId == userToPartner.EmailId && a.IsActive==false).FirstOrDefault();
                        var v2 = db.tblUsers.Where(a => a.EmailId == userToPartner.EmailId && a.Role==5).FirstOrDefault();

                        if(v1!=null)
                        {
                            logModel.StatusMessage = "You are Blocked by Admin";
                            return logModel;
                        }

                        if (v != null)
                        {
                            
                            if (string.Compare(userToPartner.Password, v.Password) == 0)
                            {
                                if (v2 != null)
                                {
                                    logModel.StatusMessage = "You are already in the Waiting List";
                                    return logModel;
                                }

                                db.tblUsers.Where(u => u.EmailId==userToPartner.EmailId).ToList().ForEach(s => s.Role = 5);
                                db.SaveChanges();
                                logModel.StatusMessage = "Successfully Added to Partner waiting list";
                                return logModel;
                            }
                            else
                            {
                                logModel.StatusMessage = "Invalid Password";
                                return logModel;
                            }
                        }
                        else
                        {
                            logModel.StatusMessage = "External Users Cannot become partner without registration ";
                            return logModel;
                        }
                    }
                }
                else
                {
                    logModel.StatusMessage = "Input model is empty";
                    return logModel;
                }

            }
            catch (Exception ex)
            {
                logModel.StatusMessage = ex.Message;
                return logModel;
            }


        }





    }
}
