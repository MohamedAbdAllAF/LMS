namespace LMS.Views
{
    partial class FRMDashboard
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLicenseCount = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblMonthlyIncome = new Bunifu.Framework.UI.BunifuCustomLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = global::LMS.Properties.Resources.slyAlaElnaby;
            this.pictureBox1.Location = new System.Drawing.Point(0, 275);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1050, 405);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblLicenseCount
            // 
            this.lblLicenseCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseCount.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblLicenseCount.Location = new System.Drawing.Point(606, 158);
            this.lblLicenseCount.Name = "lblLicenseCount";
            this.lblLicenseCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLicenseCount.Size = new System.Drawing.Size(350, 100);
            this.lblLicenseCount.TabIndex = 1;
            this.lblLicenseCount.Text = "bunifuCustomLabel1";
            this.lblLicenseCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonthlyIncome
            // 
            this.lblMonthlyIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlyIncome.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblMonthlyIncome.Location = new System.Drawing.Point(95, 158);
            this.lblMonthlyIncome.Name = "lblMonthlyIncome";
            this.lblMonthlyIncome.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMonthlyIncome.Size = new System.Drawing.Size(350, 100);
            this.lblMonthlyIncome.TabIndex = 2;
            this.lblMonthlyIncome.Text = "bunifuCustomLabel2";
            this.lblMonthlyIncome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRMDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 680);
            this.Controls.Add(this.lblMonthlyIncome);
            this.Controls.Add(this.lblLicenseCount);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FRMDashboard";
            this.Text = "FRMDashboard";
            this.Load += new System.EventHandler(this.FRMDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel lblLicenseCount;
        private Bunifu.Framework.UI.BunifuCustomLabel lblMonthlyIncome;
    }
}