using LMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Form1 : Form
    {
        LMSContext context = new LMSContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            context.Admins.Add(new Admin { Name="Mohamed",UserName=txtUserName.Text,Password=txtPassword.Text});
            context.SaveChanges();
            MessageBox.Show("Done");
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var query = context.Admins.Where(a => a.UserName == txtUserName.Text && a.Password == txtPassword.Text);
            if(query.Count() > 0 )
            {
                MessageBox.Show("Welcome "+query.FirstOrDefault().Password);
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
    }
}
