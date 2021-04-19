using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
            CPOSContext c = Controller.DatabaseController.GetConnection();
            Model.User u = c.Users.FirstOrDefault(x => x.Id == 1);
            Console.WriteLine(u.Username);
            
            foreach (Model.Permission item in u.Permissions)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Nothing to Show");
        }
    }
}
