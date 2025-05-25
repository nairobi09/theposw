namespace theposw._1Sales
{
    partial class frmFlowTicketFlowDetail
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
            this.ticket_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flow_step_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entry_dt_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exit_dt_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gap_dt_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ot_amt_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flow_step_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entry_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exit_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gap_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ot_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.link_goods_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btmPay = new System.Windows.Forms.Button();
            this.btnEntry = new System.Windows.Forms.Button();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.CheckBoxes = true;
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ticket_name,
            this.flow_step_name,
            this.goods_name,
            this.entry_dt_name,
            this.exit_dt_name,
            this.gap_dt_name,
            this.ot_amt_name,
            this.ticket_no,
            this.flow_step_code,
            this.goods_code,
            this.entry_dt,
            this.exit_dt,
            this.gap_dt,
            this.ot_amt,
            this.link_goods_code});
            this.lvwList.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(12, 57);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(763, 390);
            this.lvwList.TabIndex = 45;
            this.lvwList.TabStop = false;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // ticket_name
            // 
            this.ticket_name.Text = "티켓";
            this.ticket_name.Width = 170;
            // 
            // flow_step_name
            // 
            this.flow_step_name.Text = "상태";
            // 
            // goods_name
            // 
            this.goods_name.Text = "상품명";
            this.goods_name.Width = 150;
            // 
            // entry_dt_name
            // 
            this.entry_dt_name.Text = "입장";
            this.entry_dt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.entry_dt_name.Width = 70;
            // 
            // exit_dt_name
            // 
            this.exit_dt_name.Text = "퇴장";
            this.exit_dt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.exit_dt_name.Width = 70;
            // 
            // gap_dt_name
            // 
            this.gap_dt_name.Text = "경과";
            this.gap_dt_name.Width = 100;
            // 
            // ot_amt_name
            // 
            this.ot_amt_name.Text = "초과요금";
            this.ot_amt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ot_amt_name.Width = 90;
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
            this.btnClose.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(732, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
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
            this.lblTitle.Location = new System.Drawing.Point(9, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(766, 40);
            this.lblTitle.TabIndex = 46;
            this.lblTitle.Text = "티켓";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrint.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnPrint.Location = new System.Drawing.Point(14, 463);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 50);
            this.btnPrint.TabIndex = 79;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "재출력";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnExit.Location = new System.Drawing.Point(332, 463);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 50);
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
            this.btmPay.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btmPay.Location = new System.Drawing.Point(469, 463);
            this.btmPay.Name = "btmPay";
            this.btmPay.Size = new System.Drawing.Size(120, 50);
            this.btmPay.TabIndex = 79;
            this.btmPay.TabStop = false;
            this.btmPay.Text = "초과요금 결제";
            this.btmPay.UseVisualStyleBackColor = false;
            this.btmPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnEntry
            // 
            this.btnEntry.BackColor = System.Drawing.Color.White;
            this.btnEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntry.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEntry.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnEntry.Location = new System.Drawing.Point(196, 463);
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.Size = new System.Drawing.Size(120, 50);
            this.btnEntry.TabIndex = 79;
            this.btnEntry.TabStop = false;
            this.btnEntry.Text = "입장";
            this.btnEntry.UseVisualStyleBackColor = false;
            this.btnEntry.Click += new System.EventHandler(this.btnEntry_Click);
            // 
            // btnClose2
            // 
            this.btnClose2.BackColor = System.Drawing.Color.White;
            this.btnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnClose2.Location = new System.Drawing.Point(693, 463);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(80, 50);
            this.btnClose2.TabIndex = 80;
            this.btnClose2.TabStop = false;
            this.btnClose2.Text = "닫기";
            this.btnClose2.UseVisualStyleBackColor = false;
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // frmFlowTicketFlowDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 540);
            this.Controls.Add(this.btnClose2);
            this.Controls.Add(this.btmPay);
            this.Controls.Add(this.btnEntry);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvwList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFlowTicketFlowDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTicketFlowDetail";
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
        private System.Windows.Forms.ColumnHeader ot_amt_name;
        private System.Windows.Forms.Button btnEntry;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.ColumnHeader flow_step_code;
        private System.Windows.Forms.ColumnHeader ticket_no;
        private System.Windows.Forms.ColumnHeader ot_amt;
    }
}