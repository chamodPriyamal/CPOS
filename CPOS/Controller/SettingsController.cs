using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Controller
{
    public static class SettingsController
    {
        private static CPOSContext context = DatabaseController.GetConnection();
        public static Model.Settings Settings = context.Settings.FirstOrDefault();
    }
}
