namespace LMS.Views
{
    partial class FRMMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMMain));
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.btnLicenseSearch = new MaterialSkin.Controls.MaterialButton();
            this.btnNewLicense = new MaterialSkin.Controls.MaterialButton();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblExit = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblMaxmize = new System.Windows.Forms.Label();
            this.lblMinimize = new System.Windows.Forms.Label();
            this.pctDashboard = new System.Windows.Forms.PictureBox();
            this.pnlSideBar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctDashboard)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlSideBar.Controls.Add(this.materialButton1);
            this.pnlSideBar.Controls.Add(this.btnLicenseSearch);
            this.pnlSideBar.Controls.Add(this.btnNewLicense);
            this.pnlSideBar.Controls.Add(this.pnlLogo);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSideBar.Location = new System.Drawing.Point(1050, 0);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(230, 720);
            this.pnlSideBar.TabIndex = 0;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButton1.Depth = 0;
            this.materialButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialButton1.DrawShadows = true;
            this.materialButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(0, 192);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.Size = new System.Drawing.Size(230, 36);
            this.materialButton1.TabIndex = 3;
            this.materialButton1.Text = "التقارير";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // btnLicenseSearch
            // 
            this.btnLicenseSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLicenseSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLicenseSearch.Depth = 0;
            this.btnLicenseSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLicenseSearch.DrawShadows = true;
            this.btnLicenseSearch.HighEmphasis = true;
            this.btnLicenseSearch.Icon = null;
            this.btnLicenseSearch.Location = new System.Drawing.Point(0, 156);
            this.btnLicenseSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLicenseSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLicenseSearch.Name = "btnLicenseSearch";
            this.btnLicenseSearch.Size = new System.Drawing.Size(230, 36);
            this.btnLicenseSearch.TabIndex = 2;
            this.btnLicenseSearch.Text = "البحث عن رخصة";
            this.btnLicenseSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnLicenseSearch.UseAccentColor = false;
            this.btnLicenseSearch.UseVisualStyleBackColor = true;
            this.btnLicenseSearch.Click += new System.EventHandler(this.btnLicenseSearch_Click);
            // 
            // btnNewLicense
            // 
            this.btnNewLicense.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNewLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewLicense.Depth = 0;
            this.btnNewLicense.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewLicense.DrawShadows = true;
            this.btnNewLicense.HighEmphasis = true;
            this.btnNewLicense.Icon = null;
            this.btnNewLicense.Location = new System.Drawing.Point(0, 120);
            this.btnNewLicense.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNewLicense.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNewLicense.Name = "btnNewLicense";
            this.btnNewLicense.Size = new System.Drawing.Size(230, 36);
            this.btnNewLicense.TabIndex = 1;
            this.btnNewLicense.Text = "رخصة جديدة";
            this.btnNewLicense.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnNewLicense.UseAccentColor = false;
            this.btnNewLicense.UseVisualStyleBackColor = true;
            this.btnNewLicense.Click += new System.EventHandler(this.btnNewLicense_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.pctDashboard);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(230, 120);
            this.pnlLogo.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlHeader.Controls.Add(this.lblMinimize);
            this.pnlHeader.Controls.Add(this.lblExit);
            this.pnlHeader.Controls.Add(this.lblMaxmize);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1050, 40);
            this.pnlHeader.TabIndex = 1;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseMove);
            this.pnlHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseUp);
            // 
            // lblExit
            // 
            this.lblExit.Location = new System.Drawing.Point(0, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(40, 40);
            this.lblExit.TabIndex = 0;
            this.lblExit.Text = "X";
            this.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            this.lblExit.MouseEnter += new System.EventHandler(this.lblExit_MouseEnter);
            this.lblExit.MouseLeave += new System.EventHandler(this.lblExit_MouseLeave);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 40);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1050, 680);
            this.pnlContainer.TabIndex = 2;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // lblMaxmize
            // 
            this.lblMaxmize.Image = global::LMS.Properties.Resources.icons8_maximize_40;
            this.lblMaxmize.Location = new System.Drawing.Point(40, 0);
            this.lblMaxmize.Name = "lblMaxmize";
            this.lblMaxmize.Size = new System.Drawing.Size(40, 40);
            this.lblMaxmize.TabIndex = 2;
            this.lblMaxmize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxmize.Click += new System.EventHandler(this.lblMaxmize_Click);
            this.lblMaxmize.MouseEnter += new System.EventHandler(this.lblMaxmize_MouseEnter);
            this.lblMaxmize.MouseLeave += new System.EventHandler(this.lblMaxmize_MouseLeave);
            // 
            // lblMinimize
            // 
            this.lblMinimize.Image = global::LMS.Properties.Resources.icons8_minimize_30;
            this.lblMinimize.Location = new System.Drawing.Point(80, 0);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(40, 40);
            this.lblMinimize.TabIndex = 1;
            this.lblMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            this.lblMinimize.MouseEnter += new System.EventHandler(this.lblMinimize_MouseEnter);
            this.lblMinimize.MouseLeave += new System.EventHandler(this.lblMinimize_MouseLeave);
            // 
            // pctDashboard
            // 
            this.pctDashboard.Image = global::LMS.Properties.Resources.lms_high_resolution_logo_color_on_transparent_background;
            this.pctDashboard.Location = new System.Drawing.Point(65, 0);
            this.pctDashboard.Name = "pctDashboard";
            this.pctDashboard.Size = new System.Drawing.Size(100, 120);
            this.pctDashboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctDashboard.TabIndex = 0;
            this.pctDashboard.TabStop = false;
            this.pctDashboard.Click += new System.EventHandler(this.pctDashboard_Click);
            // 
            // FRMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSideBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FRMMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRMMain_Load);
            this.Resize += new System.EventHandler(this.FRMMain_Resize);
            this.pnlSideBar.ResumeLayout(false);
            this.pnlSideBar.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctDashboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.PictureBox pctDashboard;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Panel pnlContainer;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private MaterialSkin.Controls.MaterialButton btnNewLicense;
        private MaterialSkin.Controls.MaterialButton btnLicenseSearch;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.Label lblMaxmize;
    }
}