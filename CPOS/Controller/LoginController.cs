// Author  : Chamod Priyamal Kumarasiri
// Email   : chammaofficial@gmail.com
// Company : www.techwiz.lk
// Date    : 2021-04-15
// Comment : This Controller Provides the Login Functionality.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPOS.Controller
{
    public static class LoginController
    {
        private static CPOSContext context = DatabaseController.GetConnection();

        public static bool Login(string username, string password)
        {
            try
            {
                if (username == "" || password == "")
                {
                    return true;
                    throw new Exception("Username or Password Cannot be Empty!");
                }
                else
                {
                    var UserFromDB = context.Users.FirstOrDefault(x => x.Username == username);
                    if (UserFromDB == null)
                    {
                        throw new Exception("Username Cannot be Found!");               
                    }
                    else
                    {
                        if(UserFromDB.IsActive == false)
                        {
                            throw new Exception("User is not Active!");
                        }
                        else
                        {
                            if (UserFromDB.Password == password)
                            {
                                UserFromDB.LastLogin = DateTime.Now;
                                SessionController.StartSession(UserFromDB.Employee, UserFromDB);
                                context.SaveChanges();
                                return true;
                            }
                            else
                            {
                                throw new Exception("Invalid Username or Password!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageHelper.AlertError(ex.Message);
                return false;
            }
        }
        public static void Logout()
        {
            SessionController.EndSession();
        }
    }
}
