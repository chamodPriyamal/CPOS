// Author  : Chamod Priyamal Kumarasiri
// Email   : chammaofficial@gmail.com
// Company : www.techwiz.lk
// Date    : 2021-04-15
// Comment : This Controller Provides the Login Functionality.

using System;
using System.Collections.Generic;
using System.Linq;
using CPOS.Exceptions;

namespace CPOS.Controller
{
    public static class LoginController
    {
        private static CPOSContext context = DatabaseController.GetConnection();

        public static void Login(string username, string password)
        {
            try
            {
                if (username == "" || password == "")
                {
                    throw new UsernameOrPasswordEmptyException();
                }
                else
                {
                    var UserFromDB = context.Users.FirstOrDefault(x => x.Username == username);
                    if (UserFromDB == null)
                    {
                        throw new UsernameNotFoundException();
                    }
                    else
                    {
                        if(UserFromDB.IsActive == false)
                        {

                        }
                        else
                        {
                            if (UserFromDB.Password == password)
                            {
                                UserFromDB.LastLogin = DateTime.Now;
                                SessionController.StartSession(UserFromDB.Employee, UserFromDB);
                                context.SaveChanges();
                                Helper.MessageHelper.AlertInfo("Login Success!");

                            }
                            else
                            {
                                throw new InvalidCredentialsException();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageHelper.AlertError(ex.Message);
            }
        }
        public static void Logout()
        {
            SessionController.EndSession();
        }
    }
}
