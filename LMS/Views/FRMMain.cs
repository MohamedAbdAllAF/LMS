﻿using LMS.Views.ResizeHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.Views
{
    public partial class FRMMain : Form
    {
        public int AdminId;
        private bool _isNormal = true;
        private FormResizer _resizer = new FormResizer();
        Dictionary<Control, Size> originalSizes = new Dictionary<Control, Size>();
        public FRMMain(int adminId)
        {
            InitializeComponent();
            AdminId = adminId;
            //LoadForm(new FRMDashboard());
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            Form childForm = new FRMDashboard();
            await LoadFormAsync(childForm);
        }

        #region Form Loader Controller

        private Form activeForm = null;
        public void LoadForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(childForm);
            pnlContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public async Task LoadFormAsync(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(childForm);
            pnlContainer.Tag = childForm;
            childForm.BringToFront();

            // Use await to asynchronously show the form
            await Task.Yield(); // Ensure the control returns to the caller to maintain responsiveness
            childForm.Show();
        }

        private void FRMMain_Load(object sender, EventArgs e)
        {
            originalSizes = _resizer.GetControlSizes(this);
        }

        private void FRMMain_Resize(object sender, EventArgs e)
        {
            //_resizer.ResizeComponents(this, originalSizes);
        }

        #endregion

        #region Make The Form Movable Events
        bool drag = false;
        Point StartPoint = new Point(0,0);
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            StartPoint = new Point(e.X, e.Y);
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Point Current =  PointToScreen(e.Location);
                this.Location = new Point(Current.X-StartPoint.X,Current.Y-StartPoint.Y);
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        #endregion

        #region Exit Label Events

        private void lblExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("هل تريد الخروج","تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void lblExit_MouseEnter(object sender, EventArgs e)
        {
            lblExit.BackColor = Color.Red;
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.BackColor = Color.FromArgb(100, 149, 237);
        }


        #endregion

        #region Minimize Label Events

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblMinimize_MouseEnter(object sender, EventArgs e)
        {
            lblMinimize.BackColor = Color.FromArgb(200, 200, 200);
        }

        private void lblMinimize_MouseLeave(object sender, EventArgs e)
        {
            lblMinimize.BackColor = Color.FromArgb(100, 149, 237);
        }


        #endregion

        #region Maximize Label Events
        private void lblMaxmize_Click(object sender, EventArgs e)
        {
            if (_isNormal)
            {
                WindowState = FormWindowState.Maximized;
                lblMaxmize.Image = Properties.Resources.icons8_restore_down_40;
                _isNormal = false;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                lblMaxmize.Image = Properties.Resources.icons8_maximize_40;
                _isNormal = true;
            }
        }

        private void lblMaxmize_MouseEnter(object sender, EventArgs e)
        {
            lblMaxmize.BackColor = Color.FromArgb(200, 200, 200);
        }

        private void lblMaxmize_MouseLeave(object sender, EventArgs e)
        {
            lblMaxmize.BackColor = Color.FromArgb(100, 149, 237);
        }
        #endregion

        private async void btnNewLicense_Click(object sender, EventArgs e)
        {
            await LoadFormAsync(new FRMNewLicense(AdminId));
        }

        private async void pctDashboard_Click(object sender, EventArgs e)
        {
            await LoadFormAsync(new FRMDashboard());
        }

        private async void btnLicenseSearch_Click(object sender, EventArgs e)
        {
            await LoadFormAsync(new FRMDisplayLicenses());
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            await LoadFormAsync(new FRMLicenseReport());
        }
    }
}
