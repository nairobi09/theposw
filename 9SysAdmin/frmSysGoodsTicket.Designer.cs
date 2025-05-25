namespace theposw._9SysAdmin
{
    partial class frmSysGoodsTicket
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbOtFreeMinute = new System.Windows.Forms.TextBox();
            this.lvwGoods = new System.Windows.Forms.ListView();
            this.goodscode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goodsname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbOtStdMinute = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.tbAvailableMinute = new System.Windows.Forms.TextBox();
            this.lblGoodsAmtTitle = new System.Windows.Forms.Label();
            this.cbIsCharge = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbLinkGoodsCode = new System.Windows.Forms.TextBox();
            this.tbOtAmt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwGoodsTicket = new System.Windows.Forms.ListView();
            this.code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.available_minute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.is_charge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ot_free_minute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ot_std_minute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ot_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.link_goods_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGoodsLink = new System.Windows.Forms.Button();
            this.lblSelectedGoodsName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(261, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 12);
            this.label2.TabIndex = 70;
            this.label2.Text = "초과무료이용시간(분)";
            // 
            // tbOtFreeMinute
            // 
            this.tbOtFreeMinute.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOtFreeMinute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOtFreeMinute.Location = new System.Drawing.Point(391, 24);
            this.tbOtFreeMinute.MaxLength = 30;
            this.tbOtFreeMinute.Name = "tbOtFreeMinute";
            this.tbOtFreeMinute.Size = new System.Drawing.Size(117, 23);
            this.tbOtFreeMinute.TabIndex = 11;
            // 
            // lvwGoods
            // 
            this.lvwGoods.BackColor = System.Drawing.SystemColors.Window;
            this.lvwGoods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.goodscode,
            this.goodsname});
            this.lvwGoods.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwGoods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwGoods.FullRowSelect = true;
            this.lvwGoods.GridLines = true;
            this.lvwGoods.HideSelection = false;
            this.lvwGoods.Location = new System.Drawing.Point(12, 54);
            this.lvwGoods.MultiSelect = false;
            this.lvwGoods.Name = "lvwGoods";
            this.lvwGoods.Size = new System.Drawing.Size(192, 471);
            this.lvwGoods.TabIndex = 86;
            this.lvwGoods.TabStop = false;
            this.lvwGoods.UseCompatibleStateImageBehavior = false;
            this.lvwGoods.View = System.Windows.Forms.View.Details;
            // 
            // goodscode
            // 
            this.goodscode.Text = "코드";
            // 
            // goodsname
            // 
            this.goodsname.Text = "상품명";
            this.goodsname.Width = 100;
            // 
            // tbOtStdMinute
            // 
            this.tbOtStdMinute.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOtStdMinute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOtStdMinute.Location = new System.Drawing.Point(391, 54);
            this.tbOtStdMinute.MaxLength = 16;
            this.tbOtStdMinute.Name = "tbOtStdMinute";
            this.tbOtStdMinute.Size = new System.Drawing.Size(117, 23);
            this.tbOtStdMinute.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(261, 61);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(123, 12);
            this.label3.TabIndex = 68;
            this.label3.Text = "초과이용기준시간(분)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnView.Location = new System.Drawing.Point(749, 14);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 29);
            this.btnView.TabIndex = 89;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // tbAvailableMinute
            // 
            this.tbAvailableMinute.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbAvailableMinute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbAvailableMinute.Location = new System.Drawing.Point(126, 80);
            this.tbAvailableMinute.MaxLength = 16;
            this.tbAvailableMinute.Name = "tbAvailableMinute";
            this.tbAvailableMinute.Size = new System.Drawing.Size(78, 23);
            this.tbAvailableMinute.TabIndex = 7;
            // 
            // lblGoodsAmtTitle
            // 
            this.lblGoodsAmtTitle.AutoSize = true;
            this.lblGoodsAmtTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsAmtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGoodsAmtTitle.Location = new System.Drawing.Point(129, 64);
            this.lblGoodsAmtTitle.Name = "lblGoodsAmtTitle";
            this.lblGoodsAmtTitle.Size = new System.Drawing.Size(75, 12);
            this.lblGoodsAmtTitle.TabIndex = 44;
            this.lblGoodsAmtTitle.Text = "이용시간(분)";
            // 
            // cbIsCharge
            // 
            this.cbIsCharge.AutoSize = true;
            this.cbIsCharge.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbIsCharge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbIsCharge.Location = new System.Drawing.Point(130, 120);
            this.cbIsCharge.Name = "cbIsCharge";
            this.cbIsCharge.Size = new System.Drawing.Size(48, 16);
            this.cbIsCharge.TabIndex = 13;
            this.cbIsCharge.Text = "과금";
            this.cbIsCharge.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(749, 647);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 84;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSelectedGoodsName);
            this.groupBox1.Controls.Add(this.tbLinkGoodsCode);
            this.groupBox1.Controls.Add(this.tbOtAmt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbOtFreeMinute);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbOtStdMinute);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbAvailableMinute);
            this.groupBox1.Controls.Add(this.lblGoodsAmtTitle);
            this.groupBox1.Controls.Add(this.cbIsCharge);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(196, 531);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 153);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // tbLinkGoodsCode
            // 
            this.tbLinkGoodsCode.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLinkGoodsCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbLinkGoodsCode.Location = new System.Drawing.Point(391, 114);
            this.tbLinkGoodsCode.MaxLength = 16;
            this.tbLinkGoodsCode.Name = "tbLinkGoodsCode";
            this.tbLinkGoodsCode.Size = new System.Drawing.Size(117, 23);
            this.tbLinkGoodsCode.TabIndex = 71;
            // 
            // tbOtAmt
            // 
            this.tbOtAmt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOtAmt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOtAmt.Location = new System.Drawing.Point(391, 84);
            this.tbOtAmt.MaxLength = 16;
            this.tbOtAmt.Name = "tbOtAmt";
            this.tbOtAmt.Size = new System.Drawing.Size(117, 23);
            this.tbOtAmt.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(307, 121);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 68;
            this.label5.Text = "연결상품코드";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(271, 91);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 68;
            this.label4.Text = "초과이용기준당요금";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(749, 601);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 83;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(749, 555);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 82;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(23, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 14);
            this.lblTitle.TabIndex = 87;
            this.lblTitle.Text = "상품";
            // 
            // lvwGoodsTicket
            // 
            this.lvwGoodsTicket.BackColor = System.Drawing.SystemColors.Window;
            this.lvwGoodsTicket.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.code,
            this.name,
            this.available_minute,
            this.is_charge,
            this.ot_free_minute,
            this.ot_std_minute,
            this.ot_amt,
            this.link_goods_code});
            this.lvwGoodsTicket.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwGoodsTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwGoodsTicket.FullRowSelect = true;
            this.lvwGoodsTicket.GridLines = true;
            this.lvwGoodsTicket.HideSelection = false;
            this.lvwGoodsTicket.Location = new System.Drawing.Point(210, 54);
            this.lvwGoodsTicket.MultiSelect = false;
            this.lvwGoodsTicket.Name = "lvwGoodsTicket";
            this.lvwGoodsTicket.Size = new System.Drawing.Size(639, 471);
            this.lvwGoodsTicket.TabIndex = 90;
            this.lvwGoodsTicket.TabStop = false;
            this.lvwGoodsTicket.UseCompatibleStateImageBehavior = false;
            this.lvwGoodsTicket.View = System.Windows.Forms.View.Details;
            this.lvwGoodsTicket.SelectedIndexChanged += new System.EventHandler(this.lvwGoodsTicket_SelectedIndexChanged);
            // 
            // code
            // 
            this.code.Text = "코드";
            // 
            // name
            // 
            this.name.Text = "상품명";
            this.name.Width = 100;
            // 
            // available_minute
            // 
            this.available_minute.Text = "이용(분)";
            this.available_minute.Width = 70;
            // 
            // is_charge
            // 
            this.is_charge.Text = "과금";
            this.is_charge.Width = 40;
            // 
            // ot_free_minute
            // 
            this.ot_free_minute.Text = "초과무료(분)";
            this.ot_free_minute.Width = 100;
            // 
            // ot_std_minute
            // 
            this.ot_std_minute.Text = "초과기준(분)";
            this.ot_std_minute.Width = 90;
            // 
            // ot_amt
            // 
            this.ot_amt.Text = "기준당요금";
            this.ot_amt.Width = 80;
            // 
            // link_goods_code
            // 
            this.link_goods_code.Text = "연결상품";
            this.link_goods_code.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(193, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 87;
            this.label1.Text = "티켓상품";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(195, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 87;
            this.label6.Text = "티켓상품";
            // 
            // btnGoodsLink
            // 
            this.btnGoodsLink.BackColor = System.Drawing.Color.White;
            this.btnGoodsLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoodsLink.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGoodsLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGoodsLink.Location = new System.Drawing.Point(63, 561);
            this.btnGoodsLink.Name = "btnGoodsLink";
            this.btnGoodsLink.Size = new System.Drawing.Size(86, 30);
            this.btnGoodsLink.TabIndex = 83;
            this.btnGoodsLink.TabStop = false;
            this.btnGoodsLink.Text = "연결";
            this.btnGoodsLink.UseVisualStyleBackColor = false;
            this.btnGoodsLink.Click += new System.EventHandler(this.btnGoodsLink_Click);
            // 
            // lblSelectedGoodsName
            // 
            this.lblSelectedGoodsName.AutoSize = true;
            this.lblSelectedGoodsName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelectedGoodsName.Location = new System.Drawing.Point(28, 28);
            this.lblSelectedGoodsName.Name = "lblSelectedGoodsName";
            this.lblSelectedGoodsName.Size = new System.Drawing.Size(15, 14);
            this.lblSelectedGoodsName.TabIndex = 72;
            this.lblSelectedGoodsName.Text = "_";
            // 
            // frmSysGoodsTicket
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.btnGoodsLink);
            this.Controls.Add(this.lvwGoodsTicket);
            this.Controls.Add(this.lvwGoods);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysGoodsTicket";
            this.Text = "frmSysGoodsTicket";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOtFreeMinute;
        private System.Windows.Forms.ListView lvwGoods;
        private System.Windows.Forms.ColumnHeader goodsname;
        private System.Windows.Forms.ColumnHeader goodscode;
        private System.Windows.Forms.TextBox tbOtStdMinute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox tbAvailableMinute;
        private System.Windows.Forms.Label lblGoodsAmtTitle;
        private System.Windows.Forms.CheckBox cbIsCharge;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbOtAmt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLinkGoodsCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvwGoodsTicket;
        private System.Windows.Forms.ColumnHeader code;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader available_minute;
        private System.Windows.Forms.ColumnHeader is_charge;
        private System.Windows.Forms.ColumnHeader ot_free_minute;
        private System.Windows.Forms.ColumnHeader ot_std_minute;
        private System.Windows.Forms.ColumnHeader ot_amt;
        private System.Windows.Forms.ColumnHeader link_goods_code;
        private System.Windows.Forms.Button btnGoodsLink;
        private System.Windows.Forms.Label lblSelectedGoodsName;
    }
}