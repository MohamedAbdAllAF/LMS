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
            this.rbtnAddedInSystem = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnLFinalPaymentDate = new System.Windows.Forms.RadioButton();
            this.rbtnLExaminationFeeDate = new System.Windows.Forms.RadioButton();
            this.rbtnLInitialSupplyDate = new System.Windows.Forms.RadioButton();
            this.rbtnLEntryDate = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnVValidatySupplyDate = new System.Windows.Forms.RadioButton();
            this.rbtnVInitialSupplyDate = new System.Windows.Forms.RadioButton();
            this.rbtnVEntryDate = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.picTo = new Bunifu.Framework.UI.BunifuDatepicker();
            this.picFrom = new Bunifu.Framework.UI.BunifuDatepicker();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSave = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnGetAll = new Bunifu.Framework.UI.BunifuTileButton();
            this.groupBox10.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LMS.Reports.MLicenseReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 218);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1050, 462);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
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
            this.groupBox10.Controls.Add(this.rbtnAddedInSystem);
            this.groupBox10.Controls.Add(this.groupBox2);
            this.groupBox10.Controls.Add(this.groupBox1);
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Controls.Add(this.picTo);
            this.groupBox10.Controls.Add(this.picFrom);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox10.Location = new System.Drawing.Point(238, 39);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox10.Size = new System.Drawing.Size(800, 173);
            this.groupBox10.TabIndex = 4;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "تاريخ البحث";
            // 
            // rbtnAddedInSystem
            // 
            this.rbtnAddedInSystem.AutoSize = true;
            this.rbtnAddedInSystem.Checked = true;
            this.rbtnAddedInSystem.Location = new System.Drawing.Point(569, 139);
            this.rbtnAddedInSystem.Name = "rbtnAddedInSystem";
            this.rbtnAddedInSystem.Size = new System.Drawing.Size(220, 28);
            this.rbtnAddedInSystem.TabIndex = 11;
            this.rbtnAddedInSystem.TabStop = true;
            this.rbtnAddedInSystem.Text = "تاريخ الأضافة علي البرنامج";
            this.rbtnAddedInSystem.UseVisualStyleBackColor = true;
            this.rbtnAddedInSystem.Click += new System.EventHandler(this.rbtnVValidatySupplyDate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnLFinalPaymentDate);
            this.groupBox2.Controls.Add(this.rbtnLExaminationFeeDate);
            this.groupBox2.Controls.Add(this.rbtnLInitialSupplyDate);
            this.groupBox2.Controls.Add(this.rbtnLEntryDate);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox2.Location = new System.Drawing.Point(262, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(310, 105);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الرخصة";
            // 
            // rbtnLFinalPaymentDate
            // 
            this.rbtnLFinalPaymentDate.AutoSize = true;
            this.rbtnLFinalPaymentDate.Location = new System.Drawing.Point(31, 62);
            this.rbtnLFinalPaymentDate.Name = "rbtnLFinalPaymentDate";
            this.rbtnLFinalPaymentDate.Size = new System.Drawing.Size(140, 28);
            this.rbtnLFinalPaymentDate.TabIndex = 8;
            this.rbtnLFinalPaymentDate.Text = "دفع الرسوم النهائية";
            this.rbtnLFinalPaymentDate.UseVisualStyleBackColor = true;
            this.rbtnLFinalPaymentDate.Click += new System.EventHandler(this.rbtnVValidatySupplyDate_Click);
            // 
            // rbtnLExaminationFeeDate
            // 
            this.rbtnLExaminationFeeDate.AutoSize = true;
            this.rbtnLExaminationFeeDate.Location = new System.Drawing.Point(177, 62);
            this.rbtnLExaminationFeeDate.Name = "rbtnLExaminationFeeDate";
            this.rbtnLExaminationFeeDate.Size = new System.Drawing.Size(127, 28);
            this.rbtnLExaminationFeeDate.TabIndex = 3;
            this.rbtnLExaminationFeeDate.Text = "دفع رسم الفحص";
            this.rbtnLExaminationFeeDate.UseVisualStyleBackColor = true;
            this.rbtnLExaminationFeeDate.Click += new System.EventHandler(this.rbtnVValidatySupplyDate_Click);
            // 
            // rbtnLInitialSupplyDate
            // 
            this.rbtnLInitialSupplyDate.AutoSize = true;
            this.rbtnLInitialSupplyDate.Location = new System.Drawing.Point(61, 28);
            this.rbtnLInitialSupplyDate.Name = "rbtnLInitialSupplyDate";
            this.rbtnLInitialSupplyDate.Size = new System.Drawing.Size(110, 28);
            this.rbtnLInitialSupplyDate.TabIndex = 2;
            this.rbtnLInitialSupplyDate.Text = "دفع رسم أولي";
            this.rbtnLInitialSupplyDate.UseVisualStyleBackColor = true;
            this.rbtnLInitialSupplyDate.Click += new System.EventHandler(this.rbtnVValidatySupplyDate_Click);
            // 
            // rbtnLEntryDate
            // 
            this.rbtnLEntryDate.AutoSize = true;
            this.rbtnLEntryDate.Location = new System.Drawing.Point(234, 28);
            this.rbtnLEntryDate.Name = "rbtnLEntryDate";
            this.rbtnLEntryDate.Size = new System.Drawing.Size(70, 28);
            this.rbtnLEntryDate.TabIndex = 1;
            this.rbtnLEntryDate.Text = "الدخول";
            this.rbtnLEntryDate.UseVisualStyleBackColor = true;
            this.rbtnLEntryDate.Click += new System.EventHandler(this.rbtnVValidatySupplyDate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnVValidatySupplyDate);
            this.groupBox1.Controls.Add(this.rbtnVInitialSupplyDate);
            this.groupBox1.Controls.Add(this.rbtnVEntryDate);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Location = new System.Drawing.Point(578, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(217, 105);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيان الصلاحية";
            // 
            // rbtnVValidatySupplyDate
            // 
            this.rbtnVValidatySupplyDate.AutoSize = true;
            this.rbtnVValidatySupplyDate.Location = new System.Drawing.Point(42, 62);
            this.rbtnVValidatySupplyDate.Name = "rbtnVValidatySupplyDate";
            this.rbtnVValidatySupplyDate.Size = new System.Drawing.Size(169, 28);
            this.rbtnVValidatySupplyDate.TabIndex = 3;
            this.rbtnVValidatySupplyDate.Text = "دفع رسم بيان الصلاحية";
            this.rbtnVValidatySupplyDate.UseVisualStyleBackColor = true;
            this.rbtnVValidatySupplyDate.Click += new System.EventHandler(this.rbtnVValidatySupplyDate_Click);
            // 
            // rbtnVInitialSupplyDate
            // 
            this.rbtnVInitialSupplyDate.AutoSize = true;
            this.rbtnVInitialSupplyDate.Location = new System.Drawing.Point(15, 28);
            this.rbtnVInitialSupplyDate.Name = "rbtnVInitialSupplyDate";
            this.rbtnVInitialSupplyDate.Size = new System.Drawing.Size(115, 28);
            this.rbtnVInitialSupplyDate.TabIndex = 2;
            this.rbtnVInitialSupplyDate.Text = "دفع رسم أولي ";
            this.rbtnVInitialSupplyDate.UseVisualStyleBackColor = true;
            this.rbtnVInitialSupplyDate.Click += new System.EventHandler(this.rbtnVValidatySupplyDate_Click);
            // 
            // rbtnVEntryDate
            // 
            this.rbtnVEntryDate.AutoSize = true;
            this.rbtnVEntryDate.Location = new System.Drawing.Point(136, 28);
            this.rbtnVEntryDate.Name = "rbtnVEntryDate";
            this.rbtnVEntryDate.Size = new System.Drawing.Size(75, 28);
            this.rbtnVEntryDate.TabIndex = 1;
            this.rbtnVEntryDate.Text = "الدخول ";
            this.rbtnVEntryDate.UseVisualStyleBackColor = true;
            this.rbtnVEntryDate.Click += new System.EventHandler(this.rbtnVValidatySupplyDate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "إلى :";
            // 
            // picTo
            // 
            this.picTo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.picTo.BorderRadius = 30;
            this.picTo.ForeColor = System.Drawing.Color.White;
            this.picTo.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.picTo.FormatCustom = null;
            this.picTo.Location = new System.Drawing.Point(12, 81);
            this.picTo.Margin = new System.Windows.Forms.Padding(6);
            this.picTo.Name = "picTo";
            this.picTo.Size = new System.Drawing.Size(194, 37);
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
            this.picFrom.Location = new System.Drawing.Point(12, 37);
            this.picFrom.Margin = new System.Windows.Forms.Padding(4);
            this.picFrom.Name = "picFrom";
            this.picFrom.Size = new System.Drawing.Size(194, 37);
            this.picFrom.TabIndex = 4;
            this.picFrom.Value = new System.DateTime(2023, 9, 7, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(216, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "من :";
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
            this.btnSave.ImagePosition = 10;
            this.btnSave.ImageZoom = 15;
            this.btnSave.LabelPosition = 35;
            this.btnSave.LabelText = "جلب";
            this.btnSave.Location = new System.Drawing.Point(15, 50);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(214, 78);
            this.btnSave.TabIndex = 7;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGetAll
            // 
            this.btnGetAll.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnGetAll.color = System.Drawing.Color.CornflowerBlue;
            this.btnGetAll.colorActive = System.Drawing.Color.LightSkyBlue;
            this.btnGetAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetAll.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnGetAll.ForeColor = System.Drawing.Color.White;
            this.btnGetAll.Image = global::LMS.Properties.Resources.data_transfer;
            this.btnGetAll.ImagePosition = 10;
            this.btnGetAll.ImageZoom = 15;
            this.btnGetAll.LabelPosition = 35;
            this.btnGetAll.LabelText = "جلب الكل";
            this.btnGetAll.Location = new System.Drawing.Point(15, 133);
            this.btnGetAll.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(214, 78);
            this.btnGetAll.TabIndex = 8;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // FRMLicenseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 680);
            this.Controls.Add(this.btnGetAll);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.btnSave);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnVEntryDate;
        private System.Windows.Forms.RadioButton rbtnVValidatySupplyDate;
        private System.Windows.Forms.RadioButton rbtnVInitialSupplyDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnLExaminationFeeDate;
        private System.Windows.Forms.RadioButton rbtnLInitialSupplyDate;
        private System.Windows.Forms.RadioButton rbtnLEntryDate;
        private System.Windows.Forms.RadioButton rbtnLFinalPaymentDate;
        private System.Windows.Forms.RadioButton rbtnAddedInSystem;
        private Bunifu.Framework.UI.BunifuTileButton btnGetAll;
    }
}