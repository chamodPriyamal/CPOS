using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPOS
{
    public partial class LoggedUser : UserControl
    {
        private Timer timer;
        public LoggedUser()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void LoggedUser_Load(object sender, EventArgs e)
        {
            if(!this.DesignMode)
            {
                
                lblUser.Text = "User : " + Controller.SessionController.emp.Name;
                timer = new Timer();
                timer.Interval = 1;
                timer.Tick += Timer_Tick;
                timer.Enabled = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = "Date : " + DateTime.Now.ToLongDateString();
            lblTime.Text = "Time : " + DateTime.Now.ToLongTimeString();
        }
    }
}
