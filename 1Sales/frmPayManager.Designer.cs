namespace thepos
{
    partial class frmPayManager
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
            this.panelback = new System.Windows.Forms.Panel();
            this.btnPrintBilldisp = new System.Windows.Forms.Button();
            this.lvwPayOrder = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_goods = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc_shop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPrintBillex = new System.Windows.Forms.Button();
            this.btnPrintOrder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtBizDt = new System.Windows.Forms.DateTimePicker();
            this.tbTheNo = new System.Windows.Forms.TextBox();
            this.cbPosNo = new System.Windows.Forms.ComboBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.lvwPayManager = new System.Windows.Forms.ListView();
            this.bill_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_class = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.order_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pos_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancel_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paykeep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_calss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancel_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount_etc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount_card = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelback.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.btnPrintBilldisp);
            this.panelback.Controls.Add(this.lvwPayOrder);
            this.panelback.Controls.Add(this.btnPrintBillex);
            this.panelback.Controls.Add(this.btnPrintOrder);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.btnCancel);
            this.panelback.Controls.Add(this.btnPrintBill);
            this.panelback.Controls.Add(this.lvwPayManager);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 3;
            // 
            // btnPrintBilldisp
            // 
            this.btnPrintBilldisp.BackColor = System.Drawing.Color.White;
            this.btnPrintBilldisp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBilldisp.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrintBilldisp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnPrintBilldisp.Location = new System.Drawing.Point(397, 558);
            this.btnPrintBilldisp.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrintBilldisp.Name = "btnPrintBilldisp";
            this.btnPrintBilldisp.Size = new System.Drawing.Size(119, 40);
            this.btnPrintBilldisp.TabIndex = 81;
            this.btnPrintBilldisp.TabStop = false;
            this.btnPrintBilldisp.Text = "영수증\r\n(화면보기)";
            this.btnPrintBilldisp.UseVisualStyleBackColor = false;
            this.btnPrintBilldisp.Click += new System.EventHandler(this.btnPrintBilldisp_Click);
            // 
            // lvwPayOrder
            // 
            this.lvwPayOrder.BackColor = System.Drawing.Color.White;
            this.lvwPayOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.pay_goods,
            this.amount_cnt,
            this.dc_shop});
            this.lvwPayOrder.Font = new System.Drawing.Font("굴림체", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwPayOrder.ForeColor = System.Drawing.Color.Black;
            this.lvwPayOrder.FullRowSelect = true;
            this.lvwPayOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPayOrder.HideSelection = false;
            this.lvwPayOrder.Location = new System.Drawing.Point(4, 472);
            this.lvwPayOrder.MultiSelect = false;
            this.lvwPayOrder.Name = "lvwPayOrder";
            this.lvwPayOrder.Size = new System.Drawing.Size(386, 220);
            this.lvwPayOrder.TabIndex = 80;
            this.lvwPayOrder.TabStop = false;
            this.lvwPayOrder.UseCompatibleStateImageBehavior = false;
            this.lvwPayOrder.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#주문";
            this.no.Width = 70;
            // 
            // pay_goods
            // 
            this.pay_goods.Text = "상품/결제";
            this.pay_goods.Width = 130;
            // 
            // amount_cnt
            // 
            this.amount_cnt.Text = "수량/금액";
            this.amount_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount_cnt.Width = 80;
            // 
            // dc_shop
            // 
            this.dc_shop.Text = "업장";
            this.dc_shop.Width = 50;
            // 
            // btnPrintBillex
            // 
            this.btnPrintBillex.BackColor = System.Drawing.Color.White;
            this.btnPrintBillex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBillex.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrintBillex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnPrintBillex.Location = new System.Drawing.Point(397, 515);
            this.btnPrintBillex.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrintBillex.Name = "btnPrintBillex";
            this.btnPrintBillex.Size = new System.Drawing.Size(119, 40);
            this.btnPrintBillex.TabIndex = 79;
            this.btnPrintBillex.TabStop = false;
            this.btnPrintBillex.Text = "영수증\r\n(상품제외)";
            this.btnPrintBillex.UseVisualStyleBackColor = false;
            this.btnPrintBillex.Click += new System.EventHandler(this.btnPrintBillex_Click);
            // 
            // btnPrintOrder
            // 
            this.btnPrintOrder.BackColor = System.Drawing.Color.White;
            this.btnPrintOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintOrder.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrintOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnPrintOrder.Location = new System.Drawing.Point(397, 605);
            this.btnPrintOrder.Name = "btnPrintOrder";
            this.btnPrintOrder.Size = new System.Drawing.Size(119, 40);
            this.btnPrintOrder.TabIndex = 78;
            this.btnPrintOrder.TabStop = false;
            this.btnPrintOrder.Text = "#주문서";
            this.btnPrintOrder.UseVisualStyleBackColor = false;
            this.btnPrintOrder.Click += new System.EventHandler(this.btnPrintOrder_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.dtBizDt);
            this.panel1.Controls.Add(this.tbTheNo);
            this.panel1.Controls.Add(this.cbPosNo);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(5, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 50);
            this.panel1.TabIndex = 77;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::theposw.Properties.Resources.scanbar4;
            this.pictureBox1.Location = new System.Drawing.Point(203, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            // 
            // dtBizDt
            // 
            this.dtBizDt.CalendarFont = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtBizDt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtBizDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBizDt.Location = new System.Drawing.Point(8, 14);
            this.dtBizDt.Name = "dtBizDt";
            this.dtBizDt.Size = new System.Drawing.Size(94, 23);
            this.dtBizDt.TabIndex = 68;
            this.dtBizDt.TabStop = false;
            this.dtBizDt.Value = new System.DateTime(2023, 5, 19, 0, 0, 0, 0);
            // 
            // tbTheNo
            // 
            this.tbTheNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbTheNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTheNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbTheNo.Location = new System.Drawing.Point(231, 13);
            this.tbTheNo.Name = "tbTheNo";
            this.tbTheNo.Size = new System.Drawing.Size(165, 23);
            this.tbTheNo.TabIndex = 0;
            this.tbTheNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTheNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbTheNo_KeyUp);
            // 
            // cbPosNo
            // 
            this.cbPosNo.BackColor = System.Drawing.Color.White;
            this.cbPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPosNo.FormattingEnabled = true;
            this.cbPosNo.ItemHeight = 13;
            this.cbPosNo.Items.AddRange(new object[] {
            "",
            "01",
            "02",
            "03"});
            this.cbPosNo.Location = new System.Drawing.Point(140, 15);
            this.cbPosNo.Name = "cbPosNo";
            this.cbPosNo.Size = new System.Drawing.Size(50, 21);
            this.cbPosNo.TabIndex = 73;
            this.cbPosNo.TabStop = false;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lbl2.Location = new System.Drawing.Point(110, 20);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(29, 12);
            this.lbl2.TabIndex = 69;
            this.lbl2.Text = "포스";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnView.Location = new System.Drawing.Point(404, 10);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 30);
            this.btnView.TabIndex = 72;
            this.btnView.TabStop = false;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(474, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 43;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(4, 5);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(512, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "결제내역관리";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(397, 652);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 40);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "결제취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.BackColor = System.Drawing.Color.White;
            this.btnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBill.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrintBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnPrintBill.Location = new System.Drawing.Point(396, 472);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(120, 40);
            this.btnPrintBill.TabIndex = 48;
            this.btnPrintBill.TabStop = false;
            this.btnPrintBill.Text = "영수증";
            this.btnPrintBill.UseVisualStyleBackColor = false;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // lvwPayManager
            // 
            this.lvwPayManager.BackColor = System.Drawing.Color.White;
            this.lvwPayManager.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bill_no,
            this.pay_class,
            this.pay_type,
            this.order_dt,
            this.pos_no,
            this.amount,
            this.dc,
            this.cancel_name,
            this.paykeep,
            this.pay_calss,
            this.cancel_code});
            this.lvwPayManager.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwPayManager.ForeColor = System.Drawing.Color.Black;
            this.lvwPayManager.FullRowSelect = true;
            this.lvwPayManager.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPayManager.HideSelection = false;
            this.lvwPayManager.Location = new System.Drawing.Point(4, 107);
            this.lvwPayManager.MultiSelect = false;
            this.lvwPayManager.Name = "lvwPayManager";
            this.lvwPayManager.Size = new System.Drawing.Size(512, 359);
            this.lvwPayManager.TabIndex = 44;
            this.lvwPayManager.UseCompatibleStateImageBehavior = false;
            this.lvwPayManager.View = System.Windows.Forms.View.Details;
            this.lvwPayManager.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvwPayManager_ColumnWidthChanging);
            this.lvwPayManager.SelectedIndexChanged += new System.EventHandler(this.lvwPayManager_SelectedIndexChanged);
            // 
            // bill_no
            // 
            this.bill_no.Text = "영수증";
            this.bill_no.Width = 67;
            // 
            // pay_class
            // 
            this.pay_class.Text = "유형";
            this.pay_class.Width = 50;
            // 
            // pay_type
            // 
            this.pay_type.Text = "결제";
            this.pay_type.Width = 50;
            // 
            // order_dt
            // 
            this.order_dt.Text = "거래시간";
            this.order_dt.Width = 90;
            // 
            // pos_no
            // 
            this.pos_no.Text = "포스";
            this.pos_no.Width = 40;
            // 
            // amount
            // 
            this.amount.Text = "금액";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount.Width = 70;
            // 
            // dc
            // 
            this.dc.Text = "할인";
            this.dc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dc.Width = 40;
            // 
            // cancel_name
            // 
            this.cancel_name.Text = "취소";
            this.cancel_name.Width = 50;
            // 
            // paykeep
            // 
            this.paykeep.Text = "";
            this.paykeep.Width = 0;
            // 
            // pay_calss
            // 
            this.pay_calss.Text = "";
            this.pay_calss.Width = 0;
            // 
            // cancel_code
            // 
            this.cancel_code.Text = "";
            this.cancel_code.Width = 0;
            // 
            // amount_etc
            // 
            this.amount_etc.Text = "기타";
            this.amount_etc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount_etc.Width = 40;
            // 
            // amount_card
            // 
            this.amount_card.Text = "금액";
            this.amount_card.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount_card.Width = 80;
            // 
            // frmPayManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmSetup";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayManager_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwPayManager;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.ColumnHeader pay_class;
        private System.Windows.Forms.ColumnHeader pos_no;
        private System.Windows.Forms.ColumnHeader bill_no;
        private System.Windows.Forms.ColumnHeader amount_etc;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.ColumnHeader amount_card;
        private System.Windows.Forms.ColumnHeader dc;
        private System.Windows.Forms.ColumnHeader cancel_name;
        private System.Windows.Forms.ColumnHeader order_dt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtBizDt;
        private System.Windows.Forms.TextBox tbTheNo;
        private System.Windows.Forms.ComboBox cbPosNo;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ColumnHeader paykeep;
        private System.Windows.Forms.ColumnHeader pay_type;
        private System.Windows.Forms.Button btnPrintBillex;
        private System.Windows.Forms.Button btnPrintOrder;
        private System.Windows.Forms.ColumnHeader pay_calss;
        private System.Windows.Forms.ColumnHeader cancel_code;
        private System.Windows.Forms.ListView lvwPayOrder;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader pay_goods;
        private System.Windows.Forms.ColumnHeader amount_cnt;
        private System.Windows.Forms.ColumnHeader dc_shop;
        private System.Windows.Forms.Button btnPrintBilldisp;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}