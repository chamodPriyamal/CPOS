// Author  : Chamod Priyamal Kumarasiri
// Email   : chammaofficial@gmail.com
// Company : www.techwiz.lk
// Date    : 2021-04-15
// Comment : This Class Provides Easy Access to Messagbox Objects

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPOS.Helper
{
    public static class MessageHelper
    {
        public static void AlertError(string msg)
        {
           MessageBox.Show(msg,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void AlertWarning(string msg)
        {
            MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void AlertInfo(string msg)
        {
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static DialogResult AlertUpdateConfirmation(string msg = "Are you sure want to update this existing record ?")
        {
            return MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult AlertRegisterConfirmation(string msg = "Are you sure want to add this new record ?")
        {
           return MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult AlertRemoveConfirmation(string msg = "Are you sure want to delete this existing record ?")
        {
            return MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }


        public static void AlertRegisterSuccess(string msg = "New Record Insert Success!")
        {
            MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void AlertRemoveSuccess(string msg = "Record Deletion Success!")
        {
            MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void AlertUpdateSuccess(string msg = "Record Update Success!")
        {
            MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }

    public static class ClearForm
    {
        public static void ClearAllTextFields(Form f)
        {
            foreach (Control ctrl in f.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }
        }

        public static void ClearAllTextFieldsOnPanel2(Form f)
        {
            var panel1 = FindControlByName(f, "panel1");
            var panel2 = FindControlByName(panel1, "panel2");
            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }
        }

        private static Control FindControlByName(Control f, string name)
        {
            Control c = null;
            foreach (Control ctrl in f.Controls)
            {
                if (ctrl.Name == name)
                {
                    c = ctrl;
                }

            }
            return c;
        }
    }
}
