
namespace CPOS.View
{
    partial class CustomerMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddCust = new System.Windows.Forms.Button();
            this.btnCustList = new System.Windows.Forms.Button();
            this.loggedUser1 = new CPOS.LoggedUser();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 60);
            this.label1.TabIndex = 27;
            this.label1.Text = "Customers";
            // 
            // btnAddCust
            // 
            this.btnAddCust.BackColor = System.Drawing.Color.Transparent;
            this.btnAddCust.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCust.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCust.ForeColor = System.Drawing.Color.White;
            this.btnAddCust.Image = global::CPOS.Properties.Resources.customer;
            this.btnAddCust.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddCust.Location = new System.Drawing.Point(-8, 249);
            this.btnAddCust.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddCust.Name = "btnAddCust";
            this.btnAddCust.Size = new System.Drawing.Size(269, 57);
            this.btnAddCust.TabIndex = 28;
            this.btnAddCust.Text = "Add New Customer";
            this.btnAddCust.UseVisualStyleBackColor = false;
            this.btnAddCust.Click += new System.EventHandler(this.btnAddCust_Click);
            // 
            // btnCustList
            // 
            this.btnCustList.BackColor = System.Drawing.Color.Transparent;
            this.btnCustList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustList.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustList.ForeColor = System.Drawing.Color.White;
            this.btnCustList.Image = ((System.Drawing.Image)(resources.GetObject("btnCustList.Image")));
            this.btnCustList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCustList.Location = new System.Drawing.Point(-8, 310);
            this.btnCustList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCustList.Name = "btnCustList";
            this.btnCustList.Size = new System.Drawing.Size(269, 57);
            this.btnCustList.TabIndex = 29;
            this.btnCustList.Text = "Customer List";
            this.btnCustList.UseVisualStyleBackColor = false;
            this.btnCustList.Click += new System.EventHandler(this.btnCustList_Click);
            // 
            // loggedUser1
            // 
            this.loggedUser1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loggedUser1.BackColor = System.Drawing.Color.Transparent;
            this.loggedUser1.Location = new System.Drawing.Point(828, 97);
            this.loggedUser1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loggedUser1.Name = "loggedUser1";
            this.loggedUser1.Size = new System.Drawing.Size(413, 183);
            this.loggedUser1.TabIndex = 25;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::CPOS.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1220, 13);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 43);
            this.btnClose.TabIndex = 30;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CustomerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 768);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCustList);
            this.Controls.Add(this.btnAddCust);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loggedUser1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CustomerMenu";
            this.Text = "CustomerMenu";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CustomerMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LoggedUser loggedUser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddCust;
        private System.Windows.Forms.Button btnCustList;
        private System.Windows.Forms.Button btnClose;
    }
}