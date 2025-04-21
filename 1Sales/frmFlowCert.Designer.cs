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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGoodsName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCouponName = new System.Windows.Forms.Label();
            this.lblChName = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblCushp = new System.Windows.Forms.Label();
            this.lblCusnm = new System.Windows.Forms.Label();
            this.lblExpdate = new System.Windows.Forms.Label();
            this.lblUstate = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCouponNo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbCouponNo = new System.Windows.Forms.TextBox();
            this.lblNoTitle = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwCoupon = new System.Windows.Forms.ListView();
            this.ustate_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ustate_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coupon_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coupon_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coupon_link_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cus_nm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cus_hp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exp_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCoupon = new System.Windows.Forms.Button();
            this.btnCouponCancel = new System.Windows.Forms.Button();
            this.panelback.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.panel2);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.lvwCoupon);
            this.panelback.Controls.Add(this.btnCoupon);
            this.panelback.Controls.Add(this.btnCouponCancel);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblGoodsName);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lblCouponName);
            this.panel2.Controls.Add(this.lblChName);
            this.panel2.Controls.Add(this.lblQty);
            this.panel2.Controls.Add(this.lblCushp);
            this.panel2.Controls.Add(this.lblCusnm);
            this.panel2.Controls.Add(this.lblExpdate);
            this.panel2.Controls.Add(this.lblUstate);
            this.panel2.Controls.Add(this.lblState);
            this.panel2.Controls.Add(this.lblCouponNo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(20, 415);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 263);
            this.panel2.TabIndex = 81;
            // 
            // lblGoodsName
            // 
            this.lblGoodsName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsName.Location = new System.Drawing.Point(85, 234);
            this.lblGoodsName.Name = "lblGoodsName";
            this.lblGoodsName.Size = new System.Drawing.Size(271, 18);
            this.lblGoodsName.TabIndex = 82;
            this.lblGoodsName.Text = "_";
            this.lblGoodsName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(20, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 18);
            this.label10.TabIndex = 83;
            this.label10.Text = "상품명";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCouponName
            // 
            this.lblCouponName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCouponName.Location = new System.Drawing.Point(85, 85);
            this.lblCouponName.Name = "lblCouponName";
            this.lblCouponName.Size = new System.Drawing.Size(271, 18);
            this.lblCouponName.TabIndex = 71;
            this.lblCouponName.Text = "_";
            this.lblCouponName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChName
            // 
            this.lblChName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChName.Location = new System.Drawing.Point(85, 140);
            this.lblChName.Name = "lblChName";
            this.lblChName.Size = new System.Drawing.Size(137, 18);
            this.lblChName.TabIndex = 80;
            this.lblChName.Text = "_";
            this.lblChName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty
            // 
            this.lblQty.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblQty.Location = new System.Drawing.Point(85, 107);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(53, 18);
            this.lblQty.TabIndex = 71;
            this.lblQty.Text = "_";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCushp
            // 
            this.lblCushp.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCushp.Location = new System.Drawing.Point(85, 201);
            this.lblCushp.Name = "lblCushp";
            this.lblCushp.Size = new System.Drawing.Size(137, 18);
            this.lblCushp.TabIndex = 71;
            this.lblCushp.Text = "_";
            this.lblCushp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCusnm
            // 
            this.lblCusnm.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCusnm.Location = new System.Drawing.Point(85, 181);
            this.lblCusnm.Name = "lblCusnm";
            this.lblCusnm.Size = new System.Drawing.Size(137, 18);
            this.lblCusnm.TabIndex = 71;
            this.lblCusnm.Text = "_";
            this.lblCusnm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpdate
            // 
            this.lblExpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblExpdate.Location = new System.Drawing.Point(85, 161);
            this.lblExpdate.Name = "lblExpdate";
            this.lblExpdate.Size = new System.Drawing.Size(137, 18);
            this.lblExpdate.TabIndex = 71;
            this.lblExpdate.Text = "_";
            this.lblExpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUstate
            // 
            this.lblUstate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUstate.Location = new System.Drawing.Point(85, 38);
            this.lblUstate.Name = "lblUstate";
            this.lblUstate.Size = new System.Drawing.Size(137, 18);
            this.lblUstate.TabIndex = 71;
            this.lblUstate.Text = "_";
            this.lblUstate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblState
            // 
            this.lblState.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblState.Location = new System.Drawing.Point(85, 17);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(137, 18);
            this.lblState.TabIndex = 71;
            this.lblState.Text = "_";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCouponNo
            // 
            this.lblCouponNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCouponNo.Location = new System.Drawing.Point(85, 64);
            this.lblCouponNo.Name = "lblCouponNo";
            this.lblCouponNo.Size = new System.Drawing.Size(271, 18);
            this.lblCouponNo.TabIndex = 71;
            this.lblCouponNo.Text = "_";
            this.lblCouponNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(20, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 18);
            this.label9.TabIndex = 81;
            this.label9.Text = "채널명";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(20, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 71;
            this.label1.Text = "수량";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(20, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 71;
            this.label4.Text = "쿠폰명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(20, 201);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 18);
            this.label13.TabIndex = 71;
            this.label13.Text = "고객HP";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(20, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 18);
            this.label5.TabIndex = 71;
            this.label5.Text = "고객명";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(20, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 71;
            this.label3.Text = "만기일";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(20, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 18);
            this.label7.TabIndex = 71;
            this.label7.Text = "사용상태";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(20, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 18);
            this.label6.TabIndex = 71;
            this.label6.Text = "예약상태";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 71;
            this.label2.Text = "쿠폰번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbCouponNo);
            this.panel1.Controls.Add(this.lblNoTitle);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(20, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 100);
            this.panel1.TabIndex = 77;
            // 
            // tbCouponNo
            // 
            this.tbCouponNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbCouponNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCouponNo.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCouponNo.Location = new System.Drawing.Point(91, 22);
            this.tbCouponNo.MaxLength = 40;
            this.tbCouponNo.Name = "tbCouponNo";
            this.tbCouponNo.Size = new System.Drawing.Size(249, 27);
            this.tbCouponNo.TabIndex = 0;
            this.tbCouponNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCouponNo_KeyDown);
            this.tbCouponNo.Leave += new System.EventHandler(this.tbCouponNo_Leave);
            // 
            // lblNoTitle
            // 
            this.lblNoTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoTitle.Location = new System.Drawing.Point(8, 27);
            this.lblNoTitle.Name = "lblNoTitle";
            this.lblNoTitle.Size = new System.Drawing.Size(74, 18);
            this.lblNoTitle.TabIndex = 71;
            this.lblNoTitle.Text = "쿠폰번호";
            this.lblNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnView.Location = new System.Drawing.Point(351, 22);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 40);
            this.btnView.TabIndex = 1;
            this.btnView.TabStop = false;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(463, 20);
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
            this.lblTitle.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "쿠폰인증";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwCoupon
            // 
            this.lvwCoupon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ustate_name,
            this.ustate_code,
            this.coupon_no,
            this.coupon_name,
            this.coupon_link_no,
            this.qty,
            this.cus_nm,
            this.cus_hp,
            this.exp_date,
            this.state,
            this.ch_name});
            this.lvwCoupon.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwCoupon.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwCoupon.FullRowSelect = true;
            this.lvwCoupon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwCoupon.HideSelection = false;
            this.lvwCoupon.Location = new System.Drawing.Point(20, 176);
            this.lvwCoupon.MultiSelect = false;
            this.lvwCoupon.Name = "lvwCoupon";
            this.lvwCoupon.Size = new System.Drawing.Size(483, 228);
            this.lvwCoupon.TabIndex = 2;
            this.lvwCoupon.TabStop = false;
            this.lvwCoupon.UseCompatibleStateImageBehavior = false;
            this.lvwCoupon.View = System.Windows.Forms.View.Details;
            this.lvwCoupon.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            // 
            // ustate_name
            // 
            this.ustate_name.Text = "사용";
            this.ustate_name.Width = 80;
            // 
            // ustate_code
            // 
            this.ustate_code.Text = "ustate";
            this.ustate_code.Width = 0;
            // 
            // coupon_no
            // 
            this.coupon_no.Text = "쿠폰번호";
            this.coupon_no.Width = 110;
            // 
            // coupon_name
            // 
            this.coupon_name.Text = "쿠폰명";
            this.coupon_name.Width = 80;
            // 
            // coupon_link_no
            // 
            this.coupon_link_no.Text = "coupon_link_no";
            this.coupon_link_no.Width = 0;
            // 
            // qty
            // 
            this.qty.Text = "수량";
            this.qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qty.Width = 40;
            // 
            // cus_nm
            // 
            this.cus_nm.Text = "고객명";
            // 
            // cus_hp
            // 
            this.cus_hp.Text = "고객HP";
            this.cus_hp.Width = 90;
            // 
            // exp_date
            // 
            this.exp_date.Text = "exp_date";
            this.exp_date.Width = 0;
            // 
            // state
            // 
            this.state.Text = "state";
            this.state.Width = 0;
            // 
            // ch_name
            // 
            this.ch_name.Text = "채널";
            this.ch_name.Width = 0;
            // 
            // btnCoupon
            // 
            this.btnCoupon.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnCoupon.Enabled = false;
            this.btnCoupon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCoupon.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCoupon.ForeColor = System.Drawing.Color.White;
            this.btnCoupon.Location = new System.Drawing.Point(408, 551);
            this.btnCoupon.Name = "btnCoupon";
            this.btnCoupon.Size = new System.Drawing.Size(94, 82);
            this.btnCoupon.TabIndex = 78;
            this.btnCoupon.TabStop = false;
            this.btnCoupon.Text = "쿠폰\r\n사용\r\n발권";
            this.btnCoupon.UseVisualStyleBackColor = false;
            this.btnCoupon.Click += new System.EventHandler(this.btnCoupon_Click);
            // 
            // btnCouponCancel
            // 
            this.btnCouponCancel.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnCouponCancel.Enabled = false;
            this.btnCouponCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCouponCancel.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCouponCancel.ForeColor = System.Drawing.Color.White;
            this.btnCouponCancel.Location = new System.Drawing.Point(408, 639);
            this.btnCouponCancel.Name = "btnCouponCancel";
            this.btnCouponCancel.Size = new System.Drawing.Size(94, 39);
            this.btnCouponCancel.TabIndex = 79;
            this.btnCouponCancel.TabStop = false;
            this.btnCouponCancel.Text = "취소";
            this.btnCouponCancel.UseVisualStyleBackColor = false;
            this.btnCouponCancel.Click += new System.EventHandler(this.btnCouponCancel_Click);
            // 
            // frmFlowCert
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFlowCert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmFlowCert";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFlowCert_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnCoupon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwCoupon;
        private System.Windows.Forms.ColumnHeader coupon_name;
        private System.Windows.Forms.ColumnHeader coupon_no;
        private System.Windows.Forms.ColumnHeader cus_nm;
        private System.Windows.Forms.Label lblNoTitle;
        private System.Windows.Forms.TextBox tbCouponNo;
        private System.Windows.Forms.Button btnCouponCancel;
        private System.Windows.Forms.ColumnHeader qty;
        private System.Windows.Forms.ColumnHeader cus_hp;
        private System.Windows.Forms.ColumnHeader ustate_name;
        private System.Windows.Forms.ColumnHeader coupon_link_no;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCusnm;
        private System.Windows.Forms.Label lblExpdate;
        private System.Windows.Forms.Label lblUstate;
        private System.Windows.Forms.Label lblCouponNo;
        private System.Windows.Forms.Label lblCushp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblCouponName;
        private System.Windows.Forms.ColumnHeader ustate_code;
        private System.Windows.Forms.ColumnHeader exp_date;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader state;
        private System.Windows.Forms.ColumnHeader ch_name;
        private System.Windows.Forms.Label lblChName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblGoodsName;
        private System.Windows.Forms.Label label10;
    }
}