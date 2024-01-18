namespace HMI_Eray
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblAxisX = new System.Windows.Forms.Label();
            this.spnTargetX = new System.Windows.Forms.NumericUpDown();
            this.btnGoX = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGoY = new System.Windows.Forms.Button();
            this.spnTargetY = new System.Windows.Forms.NumericUpDown();
            this.lblAxisY = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGoZ = new System.Windows.Forms.Button();
            this.spnTargetZ = new System.Windows.Forms.NumericUpDown();
            this.lblAxisZ = new System.Windows.Forms.Label();
            this.btnZeroAll = new System.Windows.Forms.Button();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.spnAxisValue = new System.Windows.Forms.NumericUpDown();
            this.radX = new System.Windows.Forms.RadioButton();
            this.radY = new System.Windows.Forms.RadioButton();
            this.radZ = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pnlMotorStatus = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radZspeed = new System.Windows.Forms.RadioButton();
            this.radYspeed = new System.Windows.Forms.RadioButton();
            this.radXspeed = new System.Windows.Forms.RadioButton();
            this.btn1x = new System.Windows.Forms.Button();
            this.btn2x = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pctMotorZ = new System.Windows.Forms.PictureBox();
            this.pctMotorY = new System.Windows.Forms.PictureBox();
            this.pctMotorX = new System.Windows.Forms.PictureBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btn05x = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spnTargetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnTargetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnTargetZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnAxisValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMotorZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMotorY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMotorX)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAxisX
            // 
            this.lblAxisX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxisX.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAxisX.Location = new System.Drawing.Point(53, 13);
            this.lblAxisX.Name = "lblAxisX";
            this.lblAxisX.Size = new System.Drawing.Size(138, 38);
            this.lblAxisX.TabIndex = 0;
            this.lblAxisX.Text = "0";
            this.lblAxisX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // spnTargetX
            // 
            this.spnTargetX.DecimalPlaces = 1;
            this.spnTargetX.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnTargetX.Location = new System.Drawing.Point(13, 68);
            this.spnTargetX.Name = "spnTargetX";
            this.spnTargetX.Size = new System.Drawing.Size(178, 32);
            this.spnTargetX.TabIndex = 1;
            this.spnTargetX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGoX
            // 
            this.btnGoX.Location = new System.Drawing.Point(101, 106);
            this.btnGoX.Name = "btnGoX";
            this.btnGoX.Size = new System.Drawing.Size(90, 33);
            this.btnGoX.TabIndex = 2;
            this.btnGoX.Text = "GİT";
            this.btnGoX.UseVisualStyleBackColor = true;
            this.btnGoX.Click += new System.EventHandler(this.btnGoX_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F);
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 24F);
            this.label2.Location = new System.Drawing.Point(222, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y";
            // 
            // btnGoY
            // 
            this.btnGoY.Location = new System.Drawing.Point(311, 106);
            this.btnGoY.Name = "btnGoY";
            this.btnGoY.Size = new System.Drawing.Size(90, 33);
            this.btnGoY.TabIndex = 7;
            this.btnGoY.Text = "GİT";
            this.btnGoY.UseVisualStyleBackColor = true;
            this.btnGoY.Click += new System.EventHandler(this.btnGoY_Click);
            // 
            // spnTargetY
            // 
            this.spnTargetY.DecimalPlaces = 1;
            this.spnTargetY.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnTargetY.Location = new System.Drawing.Point(223, 68);
            this.spnTargetY.Name = "spnTargetY";
            this.spnTargetY.Size = new System.Drawing.Size(178, 32);
            this.spnTargetY.TabIndex = 6;
            this.spnTargetY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAxisY
            // 
            this.lblAxisY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxisY.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAxisY.Location = new System.Drawing.Point(263, 13);
            this.lblAxisY.Name = "lblAxisY";
            this.lblAxisY.Size = new System.Drawing.Size(138, 38);
            this.lblAxisY.TabIndex = 5;
            this.lblAxisY.Text = "0";
            this.lblAxisY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 24F);
            this.label4.Location = new System.Drawing.Point(440, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 37);
            this.label4.TabIndex = 12;
            this.label4.Text = "Z";
            // 
            // btnGoZ
            // 
            this.btnGoZ.Location = new System.Drawing.Point(529, 106);
            this.btnGoZ.Name = "btnGoZ";
            this.btnGoZ.Size = new System.Drawing.Size(90, 33);
            this.btnGoZ.TabIndex = 11;
            this.btnGoZ.Text = "GİT";
            this.btnGoZ.UseVisualStyleBackColor = true;
            this.btnGoZ.Click += new System.EventHandler(this.btnGoZ_Click);
            // 
            // spnTargetZ
            // 
            this.spnTargetZ.DecimalPlaces = 1;
            this.spnTargetZ.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnTargetZ.Location = new System.Drawing.Point(441, 68);
            this.spnTargetZ.Name = "spnTargetZ";
            this.spnTargetZ.Size = new System.Drawing.Size(178, 32);
            this.spnTargetZ.TabIndex = 10;
            this.spnTargetZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAxisZ
            // 
            this.lblAxisZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxisZ.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAxisZ.Location = new System.Drawing.Point(481, 13);
            this.lblAxisZ.Name = "lblAxisZ";
            this.lblAxisZ.Size = new System.Drawing.Size(138, 38);
            this.lblAxisZ.TabIndex = 9;
            this.lblAxisZ.Text = "0";
            this.lblAxisZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnZeroAll
            // 
            this.btnZeroAll.BackColor = System.Drawing.Color.Yellow;
            this.btnZeroAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroAll.Location = new System.Drawing.Point(657, 77);
            this.btnZeroAll.Name = "btnZeroAll";
            this.btnZeroAll.Size = new System.Drawing.Size(120, 37);
            this.btnZeroAll.TabIndex = 13;
            this.btnZeroAll.Text = "RESET(ALL AXİS) ";
            this.btnZeroAll.UseVisualStyleBackColor = false;
            this.btnZeroAll.Click += new System.EventHandler(this.btnZeroAll_Click);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(263, 368);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(82, 40);
            this.btnAddToList.TabIndex = 19;
            this.btnAddToList.Text = "EKLE";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(262, 453);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(82, 35);
            this.btnClearList.TabIndex = 20;
            this.btnClearList.Text = "TEMİZLE";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // spnAxisValue
            // 
            this.spnAxisValue.DecimalPlaces = 1;
            this.spnAxisValue.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnAxisValue.Location = new System.Drawing.Point(263, 193);
            this.spnAxisValue.Name = "spnAxisValue";
            this.spnAxisValue.Size = new System.Drawing.Size(83, 32);
            this.spnAxisValue.TabIndex = 22;
            this.spnAxisValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radX
            // 
            this.radX.AutoSize = true;
            this.radX.Checked = true;
            this.radX.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.radX.Location = new System.Drawing.Point(20, 19);
            this.radX.Name = "radX";
            this.radX.Size = new System.Drawing.Size(44, 29);
            this.radX.TabIndex = 23;
            this.radX.TabStop = true;
            this.radX.Text = "X";
            this.radX.UseVisualStyleBackColor = true;
            // 
            // radY
            // 
            this.radY.AutoSize = true;
            this.radY.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.radY.Location = new System.Drawing.Point(20, 54);
            this.radY.Name = "radY";
            this.radY.Size = new System.Drawing.Size(45, 29);
            this.radY.TabIndex = 24;
            this.radY.Text = "Y";
            this.radY.UseVisualStyleBackColor = true;
            // 
            // radZ
            // 
            this.radZ.AutoSize = true;
            this.radZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.radZ.Location = new System.Drawing.Point(20, 89);
            this.radZ.Name = "radZ";
            this.radZ.Size = new System.Drawing.Size(43, 29);
            this.radZ.TabIndex = 25;
            this.radZ.Text = "Z";
            this.radZ.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radX);
            this.groupBox1.Controls.Add(this.radZ);
            this.groupBox1.Controls.Add(this.radY);
            this.groupBox1.Location = new System.Drawing.Point(263, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(83, 131);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(625, 23);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(86, 48);
            this.btnStart.TabIndex = 27;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseDown);
            this.btnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseUp);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(717, 23);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(86, 48);
            this.btnStop.TabIndex = 28;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseDown);
            this.btnStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStop_MouseUp);
            // 
            // pnlMotorStatus
            // 
            this.pnlMotorStatus.BackColor = System.Drawing.Color.Red;
            this.pnlMotorStatus.Location = new System.Drawing.Point(627, 12);
            this.pnlMotorStatus.Name = "pnlMotorStatus";
            this.pnlMotorStatus.Size = new System.Drawing.Size(178, 3);
            this.pnlMotorStatus.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 33);
            this.button1.TabIndex = 30;
            this.button1.Text = "SİL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btn2x);
            this.groupBox2.Controls.Add(this.btn05x);
            this.groupBox2.Controls.Add(this.btn1x);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 193);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EKSEN HIZ KONTOLÜ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HMI_Eray.Properties.Resources.icons8_level_64__3_;
            this.pictureBox3.Location = new System.Drawing.Point(157, 124);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(58, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 36;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HMI_Eray.Properties.Resources.icons8_level_64__2_;
            this.pictureBox2.Location = new System.Drawing.Point(157, 82);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HMI_Eray.Properties.Resources.icons8_level_64__1_1;
            this.pictureBox1.Location = new System.Drawing.Point(157, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radZspeed);
            this.groupBox3.Controls.Add(this.radYspeed);
            this.groupBox3.Controls.Add(this.radXspeed);
            this.groupBox3.Location = new System.Drawing.Point(8, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(83, 131);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            // 
            // radZspeed
            // 
            this.radZspeed.AutoSize = true;
            this.radZspeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radZspeed.Location = new System.Drawing.Point(22, 89);
            this.radZspeed.Name = "radZspeed";
            this.radZspeed.Size = new System.Drawing.Size(43, 29);
            this.radZspeed.TabIndex = 2;
            this.radZspeed.TabStop = true;
            this.radZspeed.Text = "Z";
            this.radZspeed.UseVisualStyleBackColor = true;
            // 
            // radYspeed
            // 
            this.radYspeed.AutoSize = true;
            this.radYspeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radYspeed.Location = new System.Drawing.Point(21, 54);
            this.radYspeed.Name = "radYspeed";
            this.radYspeed.Size = new System.Drawing.Size(45, 29);
            this.radYspeed.TabIndex = 1;
            this.radYspeed.TabStop = true;
            this.radYspeed.Text = "Y";
            this.radYspeed.UseVisualStyleBackColor = true;
            // 
            // radXspeed
            // 
            this.radXspeed.AutoSize = true;
            this.radXspeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radXspeed.Location = new System.Drawing.Point(22, 19);
            this.radXspeed.Name = "radXspeed";
            this.radXspeed.Size = new System.Drawing.Size(44, 29);
            this.radXspeed.TabIndex = 0;
            this.radXspeed.TabStop = true;
            this.radXspeed.Text = "X";
            this.radXspeed.UseVisualStyleBackColor = true;
            // 
            // btn1x
            // 
            this.btn1x.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn1x.Location = new System.Drawing.Point(97, 126);
            this.btn1x.Name = "btn1x";
            this.btn1x.Size = new System.Drawing.Size(54, 36);
            this.btn1x.TabIndex = 37;
            this.btn1x.Text = "x0.5";
            this.btn1x.UseVisualStyleBackColor = true;
            this.btn1x.Click += new System.EventHandler(this.btn1x_Click);
            // 
            // btn2x
            // 
            this.btn2x.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn2x.Location = new System.Drawing.Point(97, 84);
            this.btn2x.Name = "btn2x";
            this.btn2x.Size = new System.Drawing.Size(54, 36);
            this.btn2x.TabIndex = 35;
            this.btn2x.Text = "x1";
            this.btn2x.UseVisualStyleBackColor = true;
            this.btn2x.Click += new System.EventHandler(this.btn2x_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(352, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(243, 430);
            this.dataGridView1.TabIndex = 35;
            // 
            // pctMotorZ
            // 
            this.pctMotorZ.Image = global::HMI_Eray.Properties.Resources.calısıyor;
            this.pctMotorZ.Location = new System.Drawing.Point(447, 106);
            this.pctMotorZ.Name = "pctMotorZ";
            this.pctMotorZ.Size = new System.Drawing.Size(58, 59);
            this.pctMotorZ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctMotorZ.TabIndex = 31;
            this.pctMotorZ.TabStop = false;
            this.pctMotorZ.Visible = false;
            // 
            // pctMotorY
            // 
            this.pctMotorY.Image = global::HMI_Eray.Properties.Resources.calısıyor;
            this.pctMotorY.Location = new System.Drawing.Point(235, 106);
            this.pctMotorY.Name = "pctMotorY";
            this.pctMotorY.Size = new System.Drawing.Size(58, 59);
            this.pctMotorY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctMotorY.TabIndex = 31;
            this.pctMotorY.TabStop = false;
            this.pctMotorY.Visible = false;
            // 
            // pctMotorX
            // 
            this.pctMotorX.Image = global::HMI_Eray.Properties.Resources.calısıyor;
            this.pctMotorX.Location = new System.Drawing.Point(19, 106);
            this.pctMotorX.Name = "pctMotorX";
            this.pctMotorX.Size = new System.Drawing.Size(58, 59);
            this.pctMotorX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctMotorX.TabIndex = 31;
            this.pctMotorX.TabStop = false;
            this.pctMotorX.Visible = false;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.Transparent;
            this.btnRun.BackgroundImage = global::HMI_Eray.Properties.Resources.icons8_start_96;
            this.btnRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRun.Location = new System.Drawing.Point(292, 494);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(54, 53);
            this.btnRun.TabIndex = 21;
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btn05x
            // 
            this.btn05x.Location = new System.Drawing.Point(97, 41);
            this.btn05x.Name = "btn05x";
            this.btn05x.Size = new System.Drawing.Size(54, 40);
            this.btn05x.TabIndex = 36;
            this.btn05x.Text = "x2";
            this.btn05x.UseVisualStyleBackColor = true;
            this.btn05x.Click += new System.EventHandler(this.btn05x_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "StatusImage";
            this.Column1.HeaderText = "Status";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "Axis";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DisplayValue";
            this.Column3.HeaderText = "Value";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(817, 631);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pctMotorZ);
            this.Controls.Add(this.pctMotorY);
            this.Controls.Add(this.pctMotorX);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlMotorStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.spnAxisValue);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.btnZeroAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGoZ);
            this.Controls.Add(this.spnTargetZ);
            this.Controls.Add(this.lblAxisZ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGoY);
            this.Controls.Add(this.spnTargetY);
            this.Controls.Add(this.lblAxisY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGoX);
            this.Controls.Add(this.spnTargetX);
            this.Controls.Add(this.lblAxisX);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.spnTargetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnTargetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnTargetZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnAxisValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMotorZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMotorY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMotorX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAxisX;
        private System.Windows.Forms.NumericUpDown spnTargetX;
        private System.Windows.Forms.Button btnGoX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGoY;
        private System.Windows.Forms.NumericUpDown spnTargetY;
        private System.Windows.Forms.Label lblAxisY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGoZ;
        private System.Windows.Forms.NumericUpDown spnTargetZ;
        private System.Windows.Forms.Label lblAxisZ;
        private System.Windows.Forms.Button btnZeroAll;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.NumericUpDown spnAxisValue;
        private System.Windows.Forms.RadioButton radX;
        private System.Windows.Forms.RadioButton radY;
        private System.Windows.Forms.RadioButton radZ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel pnlMotorStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pctMotorX;
        private System.Windows.Forms.PictureBox pctMotorY;
        private System.Windows.Forms.PictureBox pctMotorZ;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radZspeed;
        private System.Windows.Forms.RadioButton radYspeed;
        private System.Windows.Forms.RadioButton radXspeed;
        private System.Windows.Forms.Button btn1x;
        private System.Windows.Forms.Button btn2x;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn05x;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}