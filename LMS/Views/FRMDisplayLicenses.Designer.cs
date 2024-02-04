namespace LMS.Views
{
    partial class FRMDisplayLicenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new Bunifu.Framework.UI.BunifuTileButton();
            this.rbtnLocation = new System.Windows.Forms.RadioButton();
            this.grpLocation = new System.Windows.Forms.GroupBox();
            this.txtLocation = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtPlotNumber = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grpOwner = new System.Windows.Forms.GroupBox();
            this.txtOwnerName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOwnerNationalId = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpAgent = new System.Windows.Forms.GroupBox();
            this.txtAgentName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAgentNationalId = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbtnAgent = new System.Windows.Forms.RadioButton();
            this.rbtnOwner = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDataContainer = new System.Windows.Forms.Panel();
            this.dgvDisplay = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ownerNationalIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agentNationalIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlOperations = new System.Windows.Forms.Panel();
            this.btnFees = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnDetails = new Bunifu.Framework.UI.BunifuTileButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchVMBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanelMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpLocation.SuspendLayout();
            this.grpOwner.SuspendLayout();
            this.grpAgent.SuspendLayout();
            this.pnlDataContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).BeginInit();
            this.pnlOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchVMBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.Controls.Add(this.pnlHeader);
            this.flowLayoutPanelMain.Controls.Add(this.pnlDataContainer);
            this.flowLayoutPanelMain.Controls.Add(this.pnlOperations);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(1050, 680);
            this.flowLayoutPanelMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.groupBox1);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.panel1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1025, 211);
            this.pnlHeader.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.rbtnLocation);
            this.groupBox1.Controls.Add(this.grpLocation);
            this.groupBox1.Controls.Add(this.grpOwner);
            this.groupBox1.Controls.Add(this.grpAgent);
            this.groupBox1.Controls.Add(this.rbtnAgent);
            this.groupBox1.Controls.Add(this.rbtnOwner);
            this.groupBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Location = new System.Drawing.Point(9, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1013, 162);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "طريقة البحث";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.color = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.colorActive = System.Drawing.Color.LightSkyBlue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::LMS.Properties.Resources.icons8_search_40;
            this.btnSearch.ImagePosition = 15;
            this.btnSearch.ImageZoom = 20;
            this.btnSearch.LabelPosition = 35;
            this.btnSearch.LabelText = "بحث";
            this.btnSearch.Location = new System.Drawing.Point(7, 40);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(152, 82);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbtnLocation
            // 
            this.rbtnLocation.AutoSize = true;
            this.rbtnLocation.Location = new System.Drawing.Point(859, 110);
            this.rbtnLocation.Name = "rbtnLocation";
            this.rbtnLocation.Size = new System.Drawing.Size(146, 28);
            this.rbtnLocation.TabIndex = 5;
            this.rbtnLocation.Text = "الموقع و رقم القطعة";
            this.rbtnLocation.UseVisualStyleBackColor = true;
            this.rbtnLocation.CheckedChanged += new System.EventHandler(this.rbtnLocation_CheckedChanged);
            // 
            // grpLocation
            // 
            this.grpLocation.Controls.Add(this.txtLocation);
            this.grpLocation.Controls.Add(this.txtPlotNumber);
            this.grpLocation.Controls.Add(this.label7);
            this.grpLocation.Controls.Add(this.label8);
            this.grpLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLocation.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.grpLocation.Location = new System.Drawing.Point(259, 23);
            this.grpLocation.Name = "grpLocation";
            this.grpLocation.Size = new System.Drawing.Size(490, 117);
            this.grpLocation.TabIndex = 4;
            this.grpLocation.TabStop = false;
            this.grpLocation.Text = "بيانات القطعة";
            // 
            // txtLocation
            // 
            this.txtLocation.BorderColorFocused = System.Drawing.Color.Red;
            this.txtLocation.BorderColorIdle = System.Drawing.Color.CornflowerBlue;
            this.txtLocation.BorderColorMouseHover = System.Drawing.Color.Red;
            this.txtLocation.BorderThickness = 2;
            this.txtLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLocation.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLocation.isPassword = false;
            this.txtLocation.Location = new System.Drawing.Point(8, 25);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(386, 35);
            this.txtLocation.TabIndex = 4;
            this.txtLocation.TabStop = false;
            this.txtLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLocation.OnValueChanged += new System.EventHandler(this.txtAgentNationalId_OnValueChanged);
            // 
            // txtPlotNumber
            // 
            this.txtPlotNumber.BorderColorFocused = System.Drawing.Color.Red;
            this.txtPlotNumber.BorderColorIdle = System.Drawing.Color.CornflowerBlue;
            this.txtPlotNumber.BorderColorMouseHover = System.Drawing.Color.Red;
            this.txtPlotNumber.BorderThickness = 2;
            this.txtPlotNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPlotNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPlotNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPlotNumber.isPassword = false;
            this.txtPlotNumber.Location = new System.Drawing.Point(9, 68);
            this.txtPlotNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlotNumber.Name = "txtPlotNumber";
            this.txtPlotNumber.Size = new System.Drawing.Size(386, 35);
            this.txtPlotNumber.TabIndex = 3;
            this.txtPlotNumber.TabStop = false;
            this.txtPlotNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPlotNumber.OnValueChanged += new System.EventHandler(this.txtAgentNationalId_OnValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(411, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 24);
            this.label7.TabIndex = 2;
            this.label7.Text = "رقم القطعة";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(437, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "الموقع";
            // 
            // grpOwner
            // 
            this.grpOwner.Controls.Add(this.txtOwnerName);
            this.grpOwner.Controls.Add(this.label2);
            this.grpOwner.Controls.Add(this.txtOwnerNationalId);
            this.grpOwner.Controls.Add(this.label3);
            this.grpOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOwner.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.grpOwner.Location = new System.Drawing.Point(259, 23);
            this.grpOwner.Name = "grpOwner";
            this.grpOwner.Size = new System.Drawing.Size(490, 117);
            this.grpOwner.TabIndex = 2;
            this.grpOwner.TabStop = false;
            this.grpOwner.Text = " المالك";
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.BorderColorFocused = System.Drawing.Color.Red;
            this.txtOwnerName.BorderColorIdle = System.Drawing.Color.CornflowerBlue;
            this.txtOwnerName.BorderColorMouseHover = System.Drawing.Color.Red;
            this.txtOwnerName.BorderThickness = 2;
            this.txtOwnerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOwnerName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtOwnerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOwnerName.isPassword = false;
            this.txtOwnerName.Location = new System.Drawing.Point(9, 68);
            this.txtOwnerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(386, 35);
            this.txtOwnerName.TabIndex = 3;
            this.txtOwnerName.TabStop = false;
            this.txtOwnerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOwnerName.OnValueChanged += new System.EventHandler(this.txtAgentNationalId_OnValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(444, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "الاسم";
            // 
            // txtOwnerNationalId
            // 
            this.txtOwnerNationalId.BorderColorFocused = System.Drawing.Color.Red;
            this.txtOwnerNationalId.BorderColorIdle = System.Drawing.Color.CornflowerBlue;
            this.txtOwnerNationalId.BorderColorMouseHover = System.Drawing.Color.Red;
            this.txtOwnerNationalId.BorderThickness = 2;
            this.txtOwnerNationalId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOwnerNationalId.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtOwnerNationalId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOwnerNationalId.isPassword = false;
            this.txtOwnerNationalId.Location = new System.Drawing.Point(9, 25);
            this.txtOwnerNationalId.Margin = new System.Windows.Forms.Padding(4);
            this.txtOwnerNationalId.Name = "txtOwnerNationalId";
            this.txtOwnerNationalId.Size = new System.Drawing.Size(386, 35);
            this.txtOwnerNationalId.TabIndex = 1;
            this.txtOwnerNationalId.TabStop = false;
            this.txtOwnerNationalId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOwnerNationalId.OnValueChanged += new System.EventHandler(this.txtAgentNationalId_OnValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(402, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "الرقم القومي";
            // 
            // grpAgent
            // 
            this.grpAgent.Controls.Add(this.txtAgentName);
            this.grpAgent.Controls.Add(this.label4);
            this.grpAgent.Controls.Add(this.txtAgentNationalId);
            this.grpAgent.Controls.Add(this.label5);
            this.grpAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAgent.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.grpAgent.Location = new System.Drawing.Point(259, 23);
            this.grpAgent.Name = "grpAgent";
            this.grpAgent.Size = new System.Drawing.Size(490, 117);
            this.grpAgent.TabIndex = 3;
            this.grpAgent.TabStop = false;
            this.grpAgent.Text = "الوكيل";
            // 
            // txtAgentName
            // 
            this.txtAgentName.BorderColorFocused = System.Drawing.Color.Red;
            this.txtAgentName.BorderColorIdle = System.Drawing.Color.CornflowerBlue;
            this.txtAgentName.BorderColorMouseHover = System.Drawing.Color.Red;
            this.txtAgentName.BorderThickness = 2;
            this.txtAgentName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAgentName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtAgentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAgentName.isPassword = false;
            this.txtAgentName.Location = new System.Drawing.Point(9, 68);
            this.txtAgentName.Margin = new System.Windows.Forms.Padding(4);
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.Size = new System.Drawing.Size(386, 35);
            this.txtAgentName.TabIndex = 3;
            this.txtAgentName.TabStop = false;
            this.txtAgentName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAgentName.OnValueChanged += new System.EventHandler(this.txtAgentNationalId_OnValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(444, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "الاسم";
            // 
            // txtAgentNationalId
            // 
            this.txtAgentNationalId.BorderColorFocused = System.Drawing.Color.Red;
            this.txtAgentNationalId.BorderColorIdle = System.Drawing.Color.CornflowerBlue;
            this.txtAgentNationalId.BorderColorMouseHover = System.Drawing.Color.Red;
            this.txtAgentNationalId.BorderThickness = 2;
            this.txtAgentNationalId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAgentNationalId.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtAgentNationalId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAgentNationalId.isPassword = false;
            this.txtAgentNationalId.Location = new System.Drawing.Point(9, 25);
            this.txtAgentNationalId.Margin = new System.Windows.Forms.Padding(4);
            this.txtAgentNationalId.Name = "txtAgentNationalId";
            this.txtAgentNationalId.Size = new System.Drawing.Size(386, 35);
            this.txtAgentNationalId.TabIndex = 1;
            this.txtAgentNationalId.TabStop = false;
            this.txtAgentNationalId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAgentNationalId.OnValueChanged += new System.EventHandler(this.txtAgentNationalId_OnValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(402, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "الرقم القومي";
            // 
            // rbtnAgent
            // 
            this.rbtnAgent.AutoSize = true;
            this.rbtnAgent.Location = new System.Drawing.Point(941, 67);
            this.rbtnAgent.Name = "rbtnAgent";
            this.rbtnAgent.Size = new System.Drawing.Size(66, 28);
            this.rbtnAgent.TabIndex = 1;
            this.rbtnAgent.Text = "الوكيل";
            this.rbtnAgent.UseVisualStyleBackColor = true;
            this.rbtnAgent.CheckedChanged += new System.EventHandler(this.rbtnAgent_CheckedChanged);
            // 
            // rbtnOwner
            // 
            this.rbtnOwner.AutoSize = true;
            this.rbtnOwner.Checked = true;
            this.rbtnOwner.Location = new System.Drawing.Point(945, 24);
            this.rbtnOwner.Name = "rbtnOwner";
            this.rbtnOwner.Size = new System.Drawing.Size(62, 28);
            this.rbtnOwner.TabIndex = 0;
            this.rbtnOwner.TabStop = true;
            this.rbtnOwner.Text = "المالك";
            this.rbtnOwner.UseVisualStyleBackColor = true;
            this.rbtnOwner.CheckedChanged += new System.EventHandler(this.rbtnOwner_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(430, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "البحث عن رخصة";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 5);
            this.panel1.TabIndex = 0;
            // 
            // pnlDataContainer
            // 
            this.pnlDataContainer.Controls.Add(this.dgvDisplay);
            this.pnlDataContainer.Controls.Add(this.panel3);
            this.pnlDataContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDataContainer.Location = new System.Drawing.Point(3, 220);
            this.pnlDataContainer.Name = "pnlDataContainer";
            this.pnlDataContainer.Size = new System.Drawing.Size(1025, 445);
            this.pnlDataContainer.TabIndex = 1;
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ownerNationalIdDataGridViewTextBoxColumn,
            this.ownerNameDataGridViewTextBoxColumn,
            this.agentNationalIdDataGridViewTextBoxColumn,
            this.agentNameDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.plotNumberDataGridViewTextBoxColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDisplay.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDisplay.DoubleBuffered = true;
            this.dgvDisplay.EnableHeadersVisualStyles = false;
            this.dgvDisplay.HeaderBgColor = System.Drawing.Color.CornflowerBlue;
            this.dgvDisplay.HeaderForeColor = System.Drawing.Color.Honeydew;
            this.dgvDisplay.Location = new System.Drawing.Point(0, 0);
            this.dgvDisplay.Name = "dgvDisplay";
            this.dgvDisplay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvDisplay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDisplay.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDisplay.RowTemplate.Height = 30;
            this.dgvDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisplay.Size = new System.Drawing.Size(1025, 440);
            this.dgvDisplay.TabIndex = 1;
            // 
            // ownerNationalIdDataGridViewTextBoxColumn
            // 
            this.ownerNationalIdDataGridViewTextBoxColumn.DataPropertyName = "OwnerNationalId";
            this.ownerNationalIdDataGridViewTextBoxColumn.HeaderText = "الرقم القومي للمالك";
            this.ownerNationalIdDataGridViewTextBoxColumn.Name = "ownerNationalIdDataGridViewTextBoxColumn";
            // 
            // ownerNameDataGridViewTextBoxColumn
            // 
            this.ownerNameDataGridViewTextBoxColumn.DataPropertyName = "OwnerName";
            this.ownerNameDataGridViewTextBoxColumn.HeaderText = "اسم المالك";
            this.ownerNameDataGridViewTextBoxColumn.Name = "ownerNameDataGridViewTextBoxColumn";
            // 
            // agentNationalIdDataGridViewTextBoxColumn
            // 
            this.agentNationalIdDataGridViewTextBoxColumn.DataPropertyName = "AgentNationalId";
            this.agentNationalIdDataGridViewTextBoxColumn.HeaderText = "الرقم القومي للوكيل";
            this.agentNationalIdDataGridViewTextBoxColumn.Name = "agentNationalIdDataGridViewTextBoxColumn";
            // 
            // agentNameDataGridViewTextBoxColumn
            // 
            this.agentNameDataGridViewTextBoxColumn.DataPropertyName = "AgentName";
            this.agentNameDataGridViewTextBoxColumn.HeaderText = "اسم الوكيل";
            this.agentNameDataGridViewTextBoxColumn.Name = "agentNameDataGridViewTextBoxColumn";
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "الموقع";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            // 
            // plotNumberDataGridViewTextBoxColumn
            // 
            this.plotNumberDataGridViewTextBoxColumn.DataPropertyName = "PlotNumber";
            this.plotNumberDataGridViewTextBoxColumn.HeaderText = "رقم القطعة";
            this.plotNumberDataGridViewTextBoxColumn.Name = "plotNumberDataGridViewTextBoxColumn";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 440);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1025, 5);
            this.panel3.TabIndex = 0;
            // 
            // pnlOperations
            // 
            this.pnlOperations.Controls.Add(this.btnFees);
            this.pnlOperations.Controls.Add(this.btnDetails);
            this.pnlOperations.Controls.Add(this.panel2);
            this.pnlOperations.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOperations.Location = new System.Drawing.Point(3, 671);
            this.pnlOperations.Name = "pnlOperations";
            this.pnlOperations.Size = new System.Drawing.Size(1025, 127);
            this.pnlOperations.TabIndex = 3;
            // 
            // btnFees
            // 
            this.btnFees.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFees.color = System.Drawing.Color.CornflowerBlue;
            this.btnFees.colorActive = System.Drawing.Color.LightSkyBlue;
            this.btnFees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFees.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnFees.ForeColor = System.Drawing.Color.White;
            this.btnFees.Image = global::LMS.Properties.Resources.icons8_money_40;
            this.btnFees.ImagePosition = 10;
            this.btnFees.ImageZoom = 25;
            this.btnFees.LabelPosition = 35;
            this.btnFees.LabelText = "الأتعاب";
            this.btnFees.Location = new System.Drawing.Point(679, 22);
            this.btnFees.Margin = new System.Windows.Forms.Padding(6);
            this.btnFees.Name = "btnFees";
            this.btnFees.Size = new System.Drawing.Size(152, 82);
            this.btnFees.TabIndex = 8;
            this.btnFees.Click += new System.EventHandler(this.btnFees_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDetails.color = System.Drawing.Color.CornflowerBlue;
            this.btnDetails.colorActive = System.Drawing.Color.LightSkyBlue;
            this.btnDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetails.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Image = global::LMS.Properties.Resources.icons8_edit_40;
            this.btnDetails.ImagePosition = 10;
            this.btnDetails.ImageZoom = 25;
            this.btnDetails.LabelPosition = 35;
            this.btnDetails.LabelText = "عرض و تعديل";
            this.btnDetails.Location = new System.Drawing.Point(862, 22);
            this.btnDetails.Margin = new System.Windows.Forms.Padding(6);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(152, 82);
            this.btnDetails.TabIndex = 7;
            this.btnDetails.Click += new System.EventHandler(this.btndetails_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 5);
            this.panel2.TabIndex = 3;
            // 
            // searchVMBindingSource1
            // 
            this.searchVMBindingSource1.DataSource = typeof(LMS.ViewModel.SearchVM);
            // 
            // FRMDisplayLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 680);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FRMDisplayLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMDisplayLicenses";
            this.Load += new System.EventHandler(this.FRMDisplayLicenses_Load);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpLocation.ResumeLayout(false);
            this.grpLocation.PerformLayout();
            this.grpOwner.ResumeLayout(false);
            this.grpOwner.PerformLayout();
            this.grpAgent.ResumeLayout(false);
            this.grpAgent.PerformLayout();
            this.pnlDataContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).EndInit();
            this.pnlOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchVMBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpOwner;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtOwnerName;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtOwnerNationalId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpAgent;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtAgentName;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtAgentNationalId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpLocation;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtPlotNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbtnLocation;
        private System.Windows.Forms.RadioButton rbtnAgent;
        private System.Windows.Forms.RadioButton rbtnOwner;
        private Bunifu.Framework.UI.BunifuTileButton btnSearch;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtLocation;
        private System.Windows.Forms.Panel pnlDataContainer;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn agnetNationalIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agnetNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerNationalIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentNationalIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource searchVMBindingSource1;
        private System.Windows.Forms.Panel pnlOperations;
        private Bunifu.Framework.UI.BunifuTileButton btnDetails;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuTileButton btnFees;
    }
}