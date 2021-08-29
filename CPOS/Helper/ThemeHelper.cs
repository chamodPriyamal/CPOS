using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPOS.Helper
{
    public static class ThemeHelper
    {
        public static void ChangeFormBackgroundColor(Form f)
        {
            f.BackColor = Color.FromArgb(57, 62, 70);
        }
    }
}
