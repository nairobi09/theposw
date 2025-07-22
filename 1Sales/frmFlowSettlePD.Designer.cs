namespace thepos
{
    partial class frmFlowSettlePD
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
            this.lvwList = new System.Windows.Forms.ListView();
            this.checkbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flow_step = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emtry_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.point_usage_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.point_usage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddPay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbTicketNo = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
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
            this.panelback.Controls.Add(this.lvwList);
            this.panelback.Controls.Add(this.btnAddPay);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 539);
            this.panelback.TabIndex = 6;
            // 
            // lvwList
            // 
            this.lvwList.CheckBoxes = true;
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.checkbox,
            this.flow_step,
            this.no,
            this.ticket_name,
            this.emtry_dt,
            this.point_usage_cnt,
            this.point_usage});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(5, 107);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(511, 363);
            this.lvwList.TabIndex = 79;
            this.lvwList.TabStop = false;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // checkbox
            // 
            this.checkbox.Text = "";
            this.checkbox.Width = 25;
            // 
            // flow_step
            // 
            this.flow_step.Text = "단계";
            // 
            // no
            // 
            this.no.Text = "#";
            // 
            // ticket_name
            // 
            this.ticket_name.Text = "티켓명";
            this.ticket_name.Width = 120;
            // 
            // emtry_dt
            // 
            this.emtry_dt.Text = "입장";
            this.emtry_dt.Width = 50;
            // 
            // point_usage_cnt
            // 
            this.point_usage_cnt.Text = "수량";
            this.point_usage_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.point_usage_cnt.Width = 50;
            // 
            // point_usage
            // 
            this.point_usage.Text = "금액";
            this.point_usage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.point_usage.Width = 80;
            // 
            // btnAddPay
            // 
            this.btnAddPay.BackColor = System.Drawing.Color.White;
            this.btnAddPay.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPay.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAddPay.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnAddPay.Location = new System.Drawing.Point(284, 484);
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
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
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
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(4, 5);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(512, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "정산(후불)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFlowSettlePD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 545);
            this.Controls.Add(this.panelback);
            this.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFlowSettlePD";
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
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddPay;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader checkbox;
        private System.Windows.Forms.ColumnHeader emtry_dt;
        private System.Windows.Forms.ColumnHeader ticket_name;
        private System.Windows.Forms.ColumnHeader point_usage_cnt;
        private System.Windows.Forms.ColumnHeader point_usage;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader flow_step;
    }
}