using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPOS.View
{
    public partial class Dashboard : Form
    {
        private Timer timer;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            intilize_details();
        }

        public void intilize_details()
        {
            lblUser.Text = "User : " + Controller.SessionController.emp.Name;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = "Date : " + DateTime.Now.ToLongDateString();
            lblTime.Text = "Time : " + DateTime.Now.ToLongTimeString();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            new ProductsMenu().Show();
        }
    }
}
