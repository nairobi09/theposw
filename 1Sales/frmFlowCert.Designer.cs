namespace thepos
{
    partial class frmFlowCert
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUncheck = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbCouponNo = new System.Windows.Forms.TextBox();
            this.lblNoTitle = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwCoupon = new System.Windows.Forms.ListView();
            this.checkbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.state_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coupon_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cus_hp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.view_state_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.auth_state_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coupon_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coupon_link_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cus_nm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exp_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_idx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPay = new System.Windows.Forms.Button();
            this.panelback.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.label1);
            this.panelback.Controls.Add(this.btnCancel);
            this.panelback.Controls.Add(this.btnUncheck);
            this.panelback.Controls.Add(this.btnCheck);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.lvwCoupon);
            this.panelback.Controls.Add(this.btnPay);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(2, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(8, 629);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 51);
            this.label1.TabIndex = 82;
            this.label1.Text = "[사용취소요청]\r\n- 이 화면의 사용취소는 쿠폰발행사로 취소요청입니다.\r\n- 주문 및 정산 취소를 함께하려면 [결제내역관리]에서 취소바랍니다.";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(11, 528);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 60);
            this.btnCancel.TabIndex = 81;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "사용취소\r\n요청";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUncheck
            // 
            this.btnUncheck.BackColor = System.Drawing.Color.White;
            this.btnUncheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUncheck.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUncheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnUncheck.Location = new System.Drawing.Point(173, 527);
            this.btnUncheck.Name = "btnUncheck";
            this.btnUncheck.Size = new System.Drawing.Size(60, 60);
            this.btnUncheck.TabIndex = 80;
            this.btnUncheck.TabStop = false;
            this.btnUncheck.Text = "전체\r\n해제";
            this.btnUncheck.UseVisualStyleBackColor = false;
            this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.White;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnCheck.Location = new System.Drawing.Point(107, 527);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(60, 60);
            this.btnCheck.TabIndex = 79;
            this.btnCheck.TabStop = false;
            this.btnCheck.Text = "전체\r\n선택";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tbCouponNo);
            this.panel1.Controls.Add(this.lblNoTitle);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(5, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 50);
            this.panel1.TabIndex = 77;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::theposw.Properties.Resources.scanbar4;
            this.pictureBox1.Location = new System.Drawing.Point(268, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            // 
            // tbCouponNo
            // 
            this.tbCouponNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbCouponNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCouponNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCouponNo.Location = new System.Drawing.Point(79, 12);
            this.tbCouponNo.MaxLength = 40;
            this.tbCouponNo.Name = "tbCouponNo";
            this.tbCouponNo.Size = new System.Drawing.Size(185, 23);
            this.tbCouponNo.TabIndex = 0;
            this.tbCouponNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCouponNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCouponNo_KeyDown);
            // 
            // lblNoTitle
            // 
            this.lblNoTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoTitle.Location = new System.Drawing.Point(12, 15);
            this.lblNoTitle.Name = "lblNoTitle";
            this.lblNoTitle.Size = new System.Drawing.Size(65, 18);
            this.lblNoTitle.TabIndex = 71;
            this.lblNoTitle.Text = "쿠폰번호";
            this.lblNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnView.Location = new System.Drawing.Point(400, 9);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 30);
            this.btnView.TabIndex = 1;
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
            this.btnClose.Location = new System.Drawing.Point(473, 5);
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
            this.lblTitle.Location = new System.Drawing.Point(5, 5);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(511, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "쿠폰인증";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwCoupon
            // 
            this.lvwCoupon.CheckBoxes = true;
            this.lvwCoupon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.checkbox,
            this.state_name,
            this.coupon_no,
            this.goods_name,
            this.goods_cnt,
            this.cus_hp,
            this.view_state_code,
            this.auth_state_code,
            this.coupon_name,
            this.coupon_link_no,
            this.cus_nm,
            this.exp_date,
            this.ch_name,
            this.goods_code,
            this.goods_idx});
            this.lvwCoupon.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwCoupon.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwCoupon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwCoupon.HideSelection = false;
            this.lvwCoupon.Location = new System.Drawing.Point(5, 106);
            this.lvwCoupon.MultiSelect = false;
            this.lvwCoupon.Name = "lvwCoupon";
            this.lvwCoupon.Size = new System.Drawing.Size(511, 403);
            this.lvwCoupon.TabIndex = 2;
            this.lvwCoupon.TabStop = false;
            this.lvwCoupon.UseCompatibleStateImageBehavior = false;
            this.lvwCoupon.View = System.Windows.Forms.View.Details;
            // 
            // checkbox
            // 
            this.checkbox.Text = "";
            this.checkbox.Width = 25;
            // 
            // state_name
            // 
            this.state_name.Text = "상태";
            this.state_name.Width = 70;
            // 
            // coupon_no
            // 
            this.coupon_no.Text = "쿠폰번호";
            this.coupon_no.Width = 80;
            // 
            // goods_name
            // 
            this.goods_name.Text = "상품명";
            this.goods_name.Width = 200;
            // 
            // goods_cnt
            // 
            this.goods_cnt.Text = "수";
            this.goods_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.goods_cnt.Width = 25;
            // 
            // cus_hp
            // 
            this.cus_hp.Text = "고객";
            this.cus_hp.Width = 90;
            // 
            // view_state_code
            // 
            this.view_state_code.Text = "view";
            this.view_state_code.Width = 0;
            // 
            // auth_state_code
            // 
            this.auth_state_code.Text = "auth";
            this.auth_state_code.Width = 0;
            // 
            // coupon_name
            // 
            this.coupon_name.Text = "coupon_name";
            this.coupon_name.Width = 0;
            // 
            // coupon_link_no
            // 
            this.coupon_link_no.Text = "coupon_link_no";
            this.coupon_link_no.Width = 0;
            // 
            // cus_nm
            // 
            this.cus_nm.Text = "고객명";
            this.cus_nm.Width = 0;
            // 
            // exp_date
            // 
            this.exp_date.Text = "exp_date";
            this.exp_date.Width = 0;
            // 
            // ch_name
            // 
            this.ch_name.Text = "채널";
            this.ch_name.Width = 0;
            // 
            // goods_code
            // 
            this.goods_code.Text = "goods_code";
            this.goods_code.Width = 0;
            // 
            // goods_idx
            // 
            this.goods_idx.Text = "goods_idx";
            this.goods_idx.Width = 0;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(335, 527);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(171, 60);
            this.btnPay.TabIndex = 78;
            this.btnPay.TabStop = false;
            this.btnPay.Text = "쿠폰사용발권";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // frmFlowCert
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFlowCert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmFlowCert";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFlowCert_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwCoupon;
        private System.Windows.Forms.ColumnHeader goods_name;
        private System.Windows.Forms.ColumnHeader coupon_no;
        private System.Windows.Forms.ColumnHeader cus_nm;
        private System.Windows.Forms.Label lblNoTitle;
        private System.Windows.Forms.TextBox tbCouponNo;
        private System.Windows.Forms.ColumnHeader goods_cnt;
        private System.Windows.Forms.ColumnHeader cus_hp;
        private System.Windows.Forms.ColumnHeader state_name;
        private System.Windows.Forms.ColumnHeader coupon_link_no;
        private System.Windows.Forms.ColumnHeader exp_date;
        private System.Windows.Forms.ColumnHeader view_state_code;
        private System.Windows.Forms.ColumnHeader ch_name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColumnHeader coupon_name;
        private System.Windows.Forms.ColumnHeader goods_code;
        private System.Windows.Forms.ColumnHeader goods_idx;
        private System.Windows.Forms.ColumnHeader checkbox;
        private System.Windows.Forms.ColumnHeader auth_state_code;
        private System.Windows.Forms.Button btnUncheck;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
    }
}