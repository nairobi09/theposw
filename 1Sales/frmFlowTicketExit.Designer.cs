namespace theposw._1Sales
{
    partial class frmFlowTicketExit
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
            this.lvwList = new System.Windows.Forms.ListView();
            this.check = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flow_step_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entry_dt_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exit_dt_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gap_dt_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ot_amount_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flow_step_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entry_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exit_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gap_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ot_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ot_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.link_goods_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btmPay = new System.Windows.Forms.Button();
            this.btnDC = new System.Windows.Forms.Button();
            this.btn123 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.cbDCR = new System.Windows.Forms.ComboBox();
            this.btnDCCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTheNo = new System.Windows.Forms.Label();
            this.tbTicketNo = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.panelback = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.CheckBoxes = true;
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.check,
            this.ticket_name,
            this.flow_step_name,
            this.goods_name,
            this.goods_cnt,
            this.entry_dt_name,
            this.exit_dt_name,
            this.gap_dt_name,
            this.ot_amount_name,
            this.ticket_no,
            this.flow_step_code,
            this.goods_code,
            this.entry_dt,
            this.exit_dt,
            this.gap_dt,
            this.ot_cnt,
            this.ot_amt,
            this.link_goods_code});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(4, 109);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(512, 343);
            this.lvwList.TabIndex = 45;
            this.lvwList.TabStop = false;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // check
            // 
            this.check.Text = "";
            this.check.Width = 20;
            // 
            // ticket_name
            // 
            this.ticket_name.Text = "#";
            this.ticket_name.Width = 30;
            // 
            // flow_step_name
            // 
            this.flow_step_name.Text = "상태";
            // 
            // goods_name
            // 
            this.goods_name.Text = "상품명";
            this.goods_name.Width = 120;
            // 
            // goods_cnt
            // 
            this.goods_cnt.Text = "수";
            this.goods_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.goods_cnt.Width = 30;
            // 
            // entry_dt_name
            // 
            this.entry_dt_name.Text = "입장";
            this.entry_dt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.entry_dt_name.Width = 50;
            // 
            // exit_dt_name
            // 
            this.exit_dt_name.Text = "퇴장";
            this.exit_dt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.exit_dt_name.Width = 50;
            // 
            // gap_dt_name
            // 
            this.gap_dt_name.Text = "경과";
            this.gap_dt_name.Width = 80;
            // 
            // ot_amount_name
            // 
            this.ot_amount_name.Text = "요금";
            this.ot_amount_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ticket_no
            // 
            this.ticket_no.Text = "티켓번호";
            this.ticket_no.Width = 0;
            // 
            // flow_step_code
            // 
            this.flow_step_code.Text = "상태코드";
            this.flow_step_code.Width = 0;
            // 
            // goods_code
            // 
            this.goods_code.Text = "상품코드";
            this.goods_code.Width = 0;
            // 
            // entry_dt
            // 
            this.entry_dt.Text = "entry_dt";
            this.entry_dt.Width = 0;
            // 
            // exit_dt
            // 
            this.exit_dt.Text = "exit_dt";
            this.exit_dt.Width = 0;
            // 
            // gap_dt
            // 
            this.gap_dt.Text = "gap_dt";
            this.gap_dt.Width = 0;
            // 
            // ot_cnt
            // 
            this.ot_cnt.Text = "ot_cnt";
            this.ot_cnt.Width = 0;
            // 
            // ot_amt
            // 
            this.ot_amt.Text = "ot_amt";
            this.ot_amt.Width = 0;
            // 
            // link_goods_code
            // 
            this.link_goods_code.Text = "연결상품코드";
            this.link_goods_code.Width = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(470, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 30);
            this.btnClose.TabIndex = 47;
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
            this.lblTitle.TabIndex = 46;
            this.lblTitle.Text = "빠른퇴장";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(8, 487);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(54, 44);
            this.btnPrint.TabIndex = 79;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "출력";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.ForeColor = System.Drawing.Color.Blue;
            this.btnExit.Location = new System.Drawing.Point(169, 461);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 70);
            this.btnExit.TabIndex = 79;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "퇴장";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btmPay
            // 
            this.btmPay.BackColor = System.Drawing.Color.White;
            this.btmPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmPay.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btmPay.ForeColor = System.Drawing.Color.Black;
            this.btmPay.Location = new System.Drawing.Point(284, 461);
            this.btmPay.Name = "btmPay";
            this.btmPay.Size = new System.Drawing.Size(90, 70);
            this.btmPay.TabIndex = 79;
            this.btmPay.TabStop = false;
            this.btmPay.Text = "결제주문";
            this.btmPay.UseVisualStyleBackColor = false;
            this.btmPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnDC
            // 
            this.btnDC.BackColor = System.Drawing.Color.White;
            this.btnDC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDC.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDC.ForeColor = System.Drawing.Color.Black;
            this.btnDC.Location = new System.Drawing.Point(380, 487);
            this.btnDC.Name = "btnDC";
            this.btnDC.Size = new System.Drawing.Size(86, 44);
            this.btnDC.TabIndex = 81;
            this.btnDC.TabStop = false;
            this.btnDC.Text = "할인";
            this.btnDC.UseVisualStyleBackColor = false;
            this.btnDC.Click += new System.EventHandler(this.btnDC_Click);
            // 
            // btn123
            // 
            this.btn123.BackColor = System.Drawing.Color.White;
            this.btn123.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn123.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn123.ForeColor = System.Drawing.Color.Blue;
            this.btn123.Location = new System.Drawing.Point(68, 487);
            this.btn123.Name = "btn123";
            this.btn123.Size = new System.Drawing.Size(40, 44);
            this.btn123.TabIndex = 83;
            this.btn123.TabStop = false;
            this.btn123.Text = "1";
            this.btn123.UseVisualStyleBackColor = false;
            this.btn123.Click += new System.EventHandler(this.btn0123_Click);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.White;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn4.ForeColor = System.Drawing.Color.Black;
            this.btn4.Location = new System.Drawing.Point(113, 487);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(40, 44);
            this.btn4.TabIndex = 85;
            this.btn4.TabStop = false;
            this.btn4.Text = "2";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // cbDCR
            // 
            this.cbDCR.BackColor = System.Drawing.Color.White;
            this.cbDCR.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbDCR.FormattingEnabled = true;
            this.cbDCR.ItemHeight = 13;
            this.cbDCR.Location = new System.Drawing.Point(379, 461);
            this.cbDCR.Name = "cbDCR";
            this.cbDCR.Size = new System.Drawing.Size(137, 21);
            this.cbDCR.TabIndex = 90;
            this.cbDCR.TabStop = false;
            // 
            // btnDCCancel
            // 
            this.btnDCCancel.BackColor = System.Drawing.Color.White;
            this.btnDCCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDCCancel.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDCCancel.ForeColor = System.Drawing.Color.Black;
            this.btnDCCancel.Location = new System.Drawing.Point(471, 487);
            this.btnDCCancel.Name = "btnDCCancel";
            this.btnDCCancel.Size = new System.Drawing.Size(45, 44);
            this.btnDCCancel.TabIndex = 91;
            this.btnDCCancel.TabStop = false;
            this.btnDCCancel.Text = "취소";
            this.btnDCCancel.UseVisualStyleBackColor = false;
            this.btnDCCancel.Click += new System.EventHandler(this.btnDCCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTheNo);
            this.panel1.Controls.Add(this.tbTicketNo);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(4, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 50);
            this.panel1.TabIndex = 92;
            // 
            // lblTheNo
            // 
            this.lblTheNo.AutoSize = true;
            this.lblTheNo.Location = new System.Drawing.Point(13, 19);
            this.lblTheNo.Name = "lblTheNo";
            this.lblTheNo.Size = new System.Drawing.Size(14, 13);
            this.lblTheNo.TabIndex = 79;
            this.lblTheNo.Text = "_";
            // 
            // tbTicketNo
            // 
            this.tbTicketNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbTicketNo.Font = new System.Drawing.Font("굴림체", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbTicketNo.Location = new System.Drawing.Point(229, 12);
            this.tbTicketNo.Name = "tbTicketNo";
            this.tbTicketNo.Size = new System.Drawing.Size(175, 23);
            this.tbTicketNo.TabIndex = 0;
            this.tbTicketNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTicketNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTicketNo_KeyDown);
            this.tbTicketNo.Leave += new System.EventHandler(this.tbTicketNo_Leave);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnView.Location = new System.Drawing.Point(412, 9);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(90, 30);
            this.btnView.TabIndex = 72;
            this.btnView.TabStop = false;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.lvwList);
            this.panelback.Controls.Add(this.btnDCCancel);
            this.panelback.Controls.Add(this.cbDCR);
            this.panelback.Controls.Add(this.btnPrint);
            this.panelback.Controls.Add(this.btn4);
            this.panelback.Controls.Add(this.btnExit);
            this.panelback.Controls.Add(this.btn123);
            this.panelback.Controls.Add(this.btmPay);
            this.panelback.Controls.Add(this.btnDC);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 539);
            this.panelback.TabIndex = 93;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::theposw.Properties.Resources.locker_icon1;
            this.pictureBox2.Location = new System.Drawing.Point(171, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 82;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::theposw.Properties.Resources.ticket_icon;
            this.pictureBox1.Location = new System.Drawing.Point(200, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 81;
            this.pictureBox1.TabStop = false;
            // 
            // frmFlowTicketExit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(529, 545);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFlowTicketExit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmTicketFlowDetail";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFlowTicketExit_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelback.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader ticket_name;
        private System.Windows.Forms.ColumnHeader goods_name;
        private System.Windows.Forms.ColumnHeader entry_dt_name;
        private System.Windows.Forms.ColumnHeader exit_dt_name;
        private System.Windows.Forms.ColumnHeader gap_dt_name;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader goods_code;
        private System.Windows.Forms.ColumnHeader link_goods_code;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ColumnHeader flow_step_name;
        private System.Windows.Forms.ColumnHeader entry_dt;
        private System.Windows.Forms.ColumnHeader exit_dt;
        private System.Windows.Forms.ColumnHeader gap_dt;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btmPay;
        private System.Windows.Forms.ColumnHeader ot_amount_name;
        private System.Windows.Forms.ColumnHeader flow_step_code;
        private System.Windows.Forms.ColumnHeader ticket_no;
        private System.Windows.Forms.ColumnHeader ot_amt;
        private System.Windows.Forms.ColumnHeader ot_cnt;
        private System.Windows.Forms.Button btnDC;
        private System.Windows.Forms.Button btn123;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.ColumnHeader check;
        private System.Windows.Forms.ComboBox cbDCR;
        private System.Windows.Forms.Button btnDCCancel;
        private System.Windows.Forms.ColumnHeader goods_cnt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbTicketNo;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblTheNo;
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}