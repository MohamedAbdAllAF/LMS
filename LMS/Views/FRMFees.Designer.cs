namespace LMS.Views
{
    partial class FRMFees
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMFees));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddFee = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnDelete = new Bunifu.Framework.UI.BunifuTileButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDisplay = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFeeAmount = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnFeeDate = new Bunifu.Framework.UI.BunifuImageButton();
            this.picFeeDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.txtFeeDate = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.lblPaid = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFeeDate)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1050, 810);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.lblRemaining);
            this.panel1.Controls.Add(this.lblFees);
            this.panel1.Controls.Add(this.lblPaid);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 500);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddFee);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox2.Location = new System.Drawing.Point(6, 345);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(490, 141);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "عمليات";
            // 
            // btnAddFee
            // 
            this.btnAddFee.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAddFee.color = System.Drawing.Color.CornflowerBlue;
            this.btnAddFee.colorActive = System.Drawing.Color.LightSkyBlue;
            this.btnAddFee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFee.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnAddFee.ForeColor = System.Drawing.Color.White;
            this.btnAddFee.Image = global::LMS.Properties.Resources.icons8_add_40;
            this.btnAddFee.ImagePosition = 10;
            this.btnAddFee.ImageZoom = 25;
            this.btnAddFee.LabelPosition = 35;
            this.btnAddFee.LabelText = "إضافة مبلغ";
            this.btnAddFee.Location = new System.Drawing.Point(291, 29);
            this.btnAddFee.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddFee.Name = "btnAddFee";
            this.btnAddFee.Size = new System.Drawing.Size(152, 82);
            this.btnAddFee.TabIndex = 9;
            this.btnAddFee.Click += new System.EventHandler(this.btnAddFee_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.color = System.Drawing.Color.Red;
            this.btnDelete.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::LMS.Properties.Resources.icons8_close_40;
            this.btnDelete.ImagePosition = 10;
            this.btnDelete.ImageZoom = 25;
            this.btnDelete.LabelPosition = 35;
            this.btnDelete.LabelText = "حذف مبلغ";
            this.btnDelete.Location = new System.Drawing.Point(47, 29);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 82);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDisplay);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Location = new System.Drawing.Point(502, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(517, 305);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "سجل الدفع";
            // 
            // dgvDisplay
            // 
            this.dgvDisplay.AllowUserToAddRows = false;
            this.dgvDisplay.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDisplay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisplay.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDisplay.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDisplay.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDisplay.DoubleBuffered = true;
            this.dgvDisplay.EnableHeadersVisualStyles = false;
            this.dgvDisplay.HeaderBgColor = System.Drawing.Color.CornflowerBlue;
            this.dgvDisplay.HeaderForeColor = System.Drawing.Color.Honeydew;
            this.dgvDisplay.Location = new System.Drawing.Point(3, 25);
            this.dgvDisplay.Name = "dgvDisplay";
            this.dgvDisplay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvDisplay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDisplay.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDisplay.RowTemplate.Height = 30;
            this.dgvDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisplay.Size = new System.Drawing.Size(511, 277);
            this.dgvDisplay.TabIndex = 2;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.txtFeeAmount);
            this.groupBox8.Controls.Add(this.btnFeeDate);
            this.groupBox8.Controls.Add(this.picFeeDate);
            this.groupBox8.Controls.Add(this.txtFeeDate);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox8.Location = new System.Drawing.Point(6, 181);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox8.Size = new System.Drawing.Size(490, 158);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "إضافة مبلغ جديد";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(412, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "قيمة المبلغ";
            // 
            // txtFeeAmount
            // 
            this.txtFeeAmount.BorderColorFocused = System.Drawing.Color.Red;
            this.txtFeeAmount.BorderColorIdle = System.Drawing.Color.CornflowerBlue;
            this.txtFeeAmount.BorderColorMouseHover = System.Drawing.Color.Red;
            this.txtFeeAmount.BorderThickness = 2;
            this.txtFeeAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFeeAmount.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtFeeAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFeeAmount.isPassword = false;
            this.txtFeeAmount.Location = new System.Drawing.Point(106, 111);
            this.txtFeeAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtFeeAmount.Name = "txtFeeAmount";
            this.txtFeeAmount.Size = new System.Drawing.Size(275, 35);
            this.txtFeeAmount.TabIndex = 6;
            this.txtFeeAmount.TabStop = false;
            this.txtFeeAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnFeeDate
            // 
            this.btnFeeDate.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFeeDate.Image = ((System.Drawing.Image)(resources.GetObject("btnFeeDate.Image")));
            this.btnFeeDate.ImageActive = null;
            this.btnFeeDate.Location = new System.Drawing.Point(9, 26);
            this.btnFeeDate.Name = "btnFeeDate";
            this.btnFeeDate.Size = new System.Drawing.Size(90, 75);
            this.btnFeeDate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFeeDate.TabIndex = 5;
            this.btnFeeDate.TabStop = false;
            this.btnFeeDate.Zoom = 5;
            this.btnFeeDate.Click += new System.EventHandler(this.btnFeeDate_Click);
            // 
            // picFeeDate
            // 
            this.picFeeDate.BackColor = System.Drawing.Color.CornflowerBlue;
            this.picFeeDate.BorderRadius = 30;
            this.picFeeDate.ForeColor = System.Drawing.Color.White;
            this.picFeeDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.picFeeDate.FormatCustom = null;
            this.picFeeDate.Location = new System.Drawing.Point(106, 24);
            this.picFeeDate.Margin = new System.Windows.Forms.Padding(2);
            this.picFeeDate.Name = "picFeeDate";
            this.picFeeDate.Size = new System.Drawing.Size(275, 36);
            this.picFeeDate.TabIndex = 4;
            this.picFeeDate.Value = new System.DateTime(2023, 9, 1, 1, 11, 57, 513);
            // 
            // txtFeeDate
            // 
            this.txtFeeDate.BorderColorFocused = System.Drawing.Color.Red;
            this.txtFeeDate.BorderColorIdle = System.Drawing.Color.CornflowerBlue;
            this.txtFeeDate.BorderColorMouseHover = System.Drawing.Color.Red;
            this.txtFeeDate.BorderThickness = 2;
            this.txtFeeDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFeeDate.Enabled = false;
            this.txtFeeDate.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtFeeDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFeeDate.isPassword = false;
            this.txtFeeDate.Location = new System.Drawing.Point(106, 68);
            this.txtFeeDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtFeeDate.Name = "txtFeeDate";
            this.txtFeeDate.Size = new System.Drawing.Size(275, 35);
            this.txtFeeDate.TabIndex = 3;
            this.txtFeeDate.TabStop = false;
            this.txtFeeDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(385, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "التاريخ المختار";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(391, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "أختيار التاريخ";
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemaining.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblRemaining.Location = new System.Drawing.Point(148, 73);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(85, 29);
            this.lblRemaining.TabIndex = 6;
            this.lblRemaining.Text = "المتبقي :";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblFees.Location = new System.Drawing.Point(747, 73);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(130, 29);
            this.lblFees.TabIndex = 5;
            this.lblFees.Text = "قيمة الأتعاب :";
            // 
            // lblPaid
            // 
            this.lblPaid.AutoSize = true;
            this.lblPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaid.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblPaid.Location = new System.Drawing.Point(445, 73);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(90, 29);
            this.lblPaid.TabIndex = 4;
            this.lblPaid.Text = "الواصل :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 495);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 5);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(450, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "إدارة الأتعاب";
            // 
            // FRMFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 810);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FRMFees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMFees";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFeeDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtFeeAmount;
        private Bunifu.Framework.UI.BunifuImageButton btnFeeDate;
        private Bunifu.Framework.UI.BunifuDatepicker picFeeDate;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtFeeDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvDisplay;
        private Bunifu.Framework.UI.BunifuTileButton btnAddFee;
        private Bunifu.Framework.UI.BunifuTileButton btnDelete;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}