namespace thepos
{
    partial class frmFlowSettlementPD
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
            this.btnAddPay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbTicketNo = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.lvwPoint = new System.Windows.Forms.ListView();
            this.ticket_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.charge_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usage_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.settle_charge_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.settle_usage_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelback.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.btnAddPay);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.lvwPoint);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 539);
            this.panelback.TabIndex = 6;
            // 
            // btnAddPay
            // 
            this.btnAddPay.BackColor = System.Drawing.Color.White;
            this.btnAddPay.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPay.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAddPay.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnAddPay.Location = new System.Drawing.Point(385, 479);
            this.btnAddPay.Name = "btnAddPay";
            this.btnAddPay.Size = new System.Drawing.Size(120, 40);
            this.btnAddPay.TabIndex = 78;
            this.btnAddPay.TabStop = false;
            this.btnAddPay.Text = "결제추가";
            this.btnAddPay.UseVisualStyleBackColor = false;
            this.btnAddPay.Click += new System.EventHandler(this.btnAddPay_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tbTicketNo);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(5, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 50);
            this.panel1.TabIndex = 76;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::theposw.Properties.Resources.scanbar4;
            this.pictureBox1.Location = new System.Drawing.Point(166, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // tbTicketNo
            // 
            this.tbTicketNo.BackColor = System.Drawing.SystemColors.Window;
            this.tbTicketNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTicketNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbTicketNo.Location = new System.Drawing.Point(194, 12);
            this.tbTicketNo.MaxLength = 8;
            this.tbTicketNo.Name = "tbTicketNo";
            this.tbTicketNo.Size = new System.Drawing.Size(165, 23);
            this.tbTicketNo.TabIndex = 74;
            this.tbTicketNo.TabStop = false;
            this.tbTicketNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTicketNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTicketNo_KeyDown);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnView.Location = new System.Drawing.Point(367, 9);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(120, 30);
            this.btnView.TabIndex = 72;
            this.btnView.TabStop = false;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lvwPoint
            // 
            this.lvwPoint.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ticket_no,
            this.charge_amt,
            this.usage_amt,
            this.stat,
            this.settle_charge_amt,
            this.settle_usage_amt});
            this.lvwPoint.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwPoint.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwPoint.FullRowSelect = true;
            this.lvwPoint.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPoint.HideSelection = false;
            this.lvwPoint.Location = new System.Drawing.Point(5, 107);
            this.lvwPoint.MultiSelect = false;
            this.lvwPoint.Name = "lvwPoint";
            this.lvwPoint.Size = new System.Drawing.Size(511, 354);
            this.lvwPoint.TabIndex = 67;
            this.lvwPoint.UseCompatibleStateImageBehavior = false;
            this.lvwPoint.View = System.Windows.Forms.View.Details;
            // 
            // ticket_no
            // 
            this.ticket_no.Text = "발권번호";
            this.ticket_no.Width = 87;
            // 
            // charge_amt
            // 
            this.charge_amt.Text = "충전금액";
            this.charge_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.charge_amt.Width = 70;
            // 
            // usage_amt
            // 
            this.usage_amt.Text = "사용금액";
            this.usage_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.usage_amt.Width = 70;
            // 
            // stat
            // 
            this.stat.Text = "상태";
            this.stat.Width = 80;
            // 
            // settle_charge_amt
            // 
            this.settle_charge_amt.Text = "정산충전";
            this.settle_charge_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.settle_charge_amt.Width = 70;
            // 
            // settle_usage_amt
            // 
            this.settle_usage_amt.Text = "정산사용";
            this.settle_usage_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.settle_usage_amt.Width = 70;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.lblTitle.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(4, 5);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(512, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "후불정산";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFlowSettlementPD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 545);
            this.Controls.Add(this.panelback);
            this.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFlowSettlementPD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmFlowSettlement";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFlowSettlement_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbTicketNo;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ListView lvwPoint;
        private System.Windows.Forms.ColumnHeader stat;
        private System.Windows.Forms.ColumnHeader ticket_no;
        private System.Windows.Forms.ColumnHeader charge_amt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader usage_amt;
        private System.Windows.Forms.ColumnHeader settle_charge_amt;
        private System.Windows.Forms.ColumnHeader settle_usage_amt;
        private System.Windows.Forms.Button btnAddPay;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}