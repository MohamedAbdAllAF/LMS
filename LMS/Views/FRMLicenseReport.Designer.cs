namespace LMS.Views
{
    partial class FRMLicenseReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new Bunifu.Framework.UI.BunifuTileButton();
            this.picTo = new Bunifu.Framework.UI.BunifuDatepicker();
            this.picFrom = new Bunifu.Framework.UI.BunifuDatepicker();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LMS.Reports.MLicenseReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 162);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1050, 546);
            this.reportViewer1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTitle.Location = new System.Drawing.Point(483, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(85, 36);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "التقارير";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Controls.Add(this.btnSave);
            this.groupBox10.Controls.Add(this.picTo);
            this.groupBox10.Controls.Add(this.picFrom);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox10.Location = new System.Drawing.Point(12, 39);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox10.Size = new System.Drawing.Size(1026, 117);
            this.groupBox10.TabIndex = 4;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "تاريخ إضافة الرخصة";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(533, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "الي :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSave.color = System.Drawing.Color.CornflowerBlue;
            this.btnSave.colorActive = System.Drawing.Color.LightSkyBlue;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::LMS.Properties.Resources.data_transfer;
            this.btnSave.ImagePosition = 15;
            this.btnSave.ImageZoom = 20;
            this.btnSave.LabelPosition = 35;
            this.btnSave.LabelText = "جلب";
            this.btnSave.Location = new System.Drawing.Point(8, 17);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 82);
            this.btnSave.TabIndex = 7;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picTo
            // 
            this.picTo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.picTo.BorderRadius = 30;
            this.picTo.ForeColor = System.Drawing.Color.White;
            this.picTo.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.picTo.FormatCustom = null;
            this.picTo.Location = new System.Drawing.Point(194, 40);
            this.picTo.Margin = new System.Windows.Forms.Padding(6);
            this.picTo.Name = "picTo";
            this.picTo.Size = new System.Drawing.Size(305, 37);
            this.picTo.TabIndex = 6;
            this.picTo.Value = new System.DateTime(2023, 9, 14, 1, 34, 26, 285);
            // 
            // picFrom
            // 
            this.picFrom.BackColor = System.Drawing.Color.CornflowerBlue;
            this.picFrom.BorderRadius = 30;
            this.picFrom.ForeColor = System.Drawing.Color.White;
            this.picFrom.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.picFrom.FormatCustom = null;
            this.picFrom.Location = new System.Drawing.Point(624, 40);
            this.picFrom.Margin = new System.Windows.Forms.Padding(4);
            this.picFrom.Name = "picFrom";
            this.picFrom.Size = new System.Drawing.Size(305, 37);
            this.picFrom.TabIndex = 4;
            this.picFrom.Value = new System.DateTime(2023, 9, 7, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(963, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 31);
            this.label12.TabIndex = 0;
            this.label12.Text = "من :";
            // 
            // FRMLicenseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 710);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FRMLicenseReport";
            this.Text = "FRMLicenseReport";
            this.Load += new System.EventHandler(this.FRMLicenseReport_Load);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox10;
        private Bunifu.Framework.UI.BunifuDatepicker picTo;
        private Bunifu.Framework.UI.BunifuDatepicker picFrom;
        private System.Windows.Forms.Label label12;
        private Bunifu.Framework.UI.BunifuTileButton btnSave;
        private System.Windows.Forms.Label label1;
    }
}