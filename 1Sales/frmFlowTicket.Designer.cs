namespace thepos
{
    partial class frmFlowTicket
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
            this.btnTicketDetail = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbTicketNo = new System.Windows.Forms.TextBox();
            this.lblBusinessTitle = new System.Windows.Forms.Label();
            this.dtBusiness = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwList = new System.Windows.Forms.ListView();
            this.the_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entry_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exit_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gap_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblActTheNoCnt = new System.Windows.Forms.Label();
            this.lblTicketNoCnt = new System.Windows.Forms.Label();
            this.lblTheNoCnt = new System.Windows.Forms.Label();
            this.lblActTicketNoCnt = new System.Windows.Forms.Label();
            this.lblClickTime = new System.Windows.Forms.Label();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.panelback.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.panel2);
            this.panelback.Controls.Add(this.btnTicketDetail);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.lvwList);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 539);
            this.panelback.TabIndex = 4;
            // 
            // btnTicketDetail
            // 
            this.btnTicketDetail.BackColor = System.Drawing.Color.White;
            this.btnTicketDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTicketDetail.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTicketDetail.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnTicketDetail.Location = new System.Drawing.Point(390, 473);
            this.btnTicketDetail.Name = "btnTicketDetail";
            this.btnTicketDetail.Size = new System.Drawing.Size(125, 60);
            this.btnTicketDetail.TabIndex = 78;
            this.btnTicketDetail.Text = "팀티켓보기";
            this.btnTicketDetail.UseVisualStyleBackColor = false;
            this.btnTicketDetail.Click += new System.EventHandler(this.btnTicketDetail_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbTicketNo);
            this.panel1.Controls.Add(this.lblBusinessTitle);
            this.panel1.Controls.Add(this.dtBusiness);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(5, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 47);
            this.panel1.TabIndex = 77;
            // 
            // tbTicketNo
            // 
            this.tbTicketNo.Font = new System.Drawing.Font("굴림체", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbTicketNo.Location = new System.Drawing.Point(221, 11);
            this.tbTicketNo.Name = "tbTicketNo";
            this.tbTicketNo.Size = new System.Drawing.Size(170, 23);
            this.tbTicketNo.TabIndex = 0;
            this.tbTicketNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTicketNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTicketNo_KeyDown);
            this.tbTicketNo.Leave += new System.EventHandler(this.tbTicketNo_Leave);
            // 
            // lblBusinessTitle
            // 
            this.lblBusinessTitle.AutoSize = true;
            this.lblBusinessTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBusinessTitle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblBusinessTitle.Location = new System.Drawing.Point(12, 16);
            this.lblBusinessTitle.Name = "lblBusinessTitle";
            this.lblBusinessTitle.Size = new System.Drawing.Size(63, 14);
            this.lblBusinessTitle.TabIndex = 71;
            this.lblBusinessTitle.Text = "영업일자";
            this.lblBusinessTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtBusiness
            // 
            this.dtBusiness.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtBusiness.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBusiness.Location = new System.Drawing.Point(84, 12);
            this.dtBusiness.Name = "dtBusiness";
            this.dtBusiness.Size = new System.Drawing.Size(100, 23);
            this.dtBusiness.TabIndex = 68;
            this.dtBusiness.Value = new System.DateTime(2023, 5, 19, 1, 4, 57, 0);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnView.Location = new System.Drawing.Point(397, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 30);
            this.btnView.TabIndex = 72;
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
            this.btnClose.Location = new System.Drawing.Point(475, 5);
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
            this.lblTitle.Text = "티켓";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.the_no,
            this.cnt,
            this.entry_dt,
            this.exit_dt,
            this.gap_dt});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwList.FullRowSelect = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(5, 101);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(511, 367);
            this.lvwList.TabIndex = 44;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // the_no
            // 
            this.the_no.Text = "팀티켓번호";
            this.the_no.Width = 150;
            // 
            // cnt
            // 
            this.cnt.Text = "인원";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cnt.Width = 40;
            // 
            // entry_dt
            // 
            this.entry_dt.Text = "입장";
            this.entry_dt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.entry_dt.Width = 50;
            // 
            // exit_dt
            // 
            this.exit_dt.Text = "퇴장";
            this.exit_dt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.exit_dt.Width = 50;
            // 
            // gap_dt
            // 
            this.gap_dt.Text = "경과";
            this.gap_dt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gap_dt.Width = 80;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lbl1.Location = new System.Drawing.Point(146, 12);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(53, 12);
            this.lbl1.TabIndex = 79;
            this.lbl1.Text = "잔여팀수";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(146, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 79;
            this.label1.Text = "잔여인원";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lbl2.Location = new System.Drawing.Point(262, 12);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(53, 12);
            this.lbl2.TabIndex = 79;
            this.lbl2.Text = "입장팀수";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.label3.Location = new System.Drawing.Point(262, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "입장인원";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnMonitor);
            this.panel2.Controls.Add(this.lblClickTime);
            this.panel2.Controls.Add(this.lblActTheNoCnt);
            this.panel2.Controls.Add(this.lblTicketNoCnt);
            this.panel2.Controls.Add(this.lblTheNoCnt);
            this.panel2.Controls.Add(this.lblActTicketNoCnt);
            this.panel2.Controls.Add(this.lbl1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lbl2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(8, 473);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 60);
            this.panel2.TabIndex = 80;
            // 
            // lblActTheNoCnt
            // 
            this.lblActTheNoCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblActTheNoCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblActTheNoCnt.Location = new System.Drawing.Point(203, 11);
            this.lblActTheNoCnt.Name = "lblActTheNoCnt";
            this.lblActTheNoCnt.Size = new System.Drawing.Size(33, 12);
            this.lblActTheNoCnt.TabIndex = 80;
            this.lblActTheNoCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTicketNoCnt
            // 
            this.lblTicketNoCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTicketNoCnt.ForeColor = System.Drawing.Color.Black;
            this.lblTicketNoCnt.Location = new System.Drawing.Point(319, 34);
            this.lblTicketNoCnt.Name = "lblTicketNoCnt";
            this.lblTicketNoCnt.Size = new System.Drawing.Size(33, 12);
            this.lblTicketNoCnt.TabIndex = 81;
            this.lblTicketNoCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTheNoCnt
            // 
            this.lblTheNoCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTheNoCnt.ForeColor = System.Drawing.Color.Black;
            this.lblTheNoCnt.Location = new System.Drawing.Point(319, 11);
            this.lblTheNoCnt.Name = "lblTheNoCnt";
            this.lblTheNoCnt.Size = new System.Drawing.Size(33, 12);
            this.lblTheNoCnt.TabIndex = 82;
            this.lblTheNoCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblActTicketNoCnt
            // 
            this.lblActTicketNoCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblActTicketNoCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblActTicketNoCnt.Location = new System.Drawing.Point(203, 34);
            this.lblActTicketNoCnt.Name = "lblActTicketNoCnt";
            this.lblActTicketNoCnt.Size = new System.Drawing.Size(33, 12);
            this.lblActTicketNoCnt.TabIndex = 83;
            this.lblActTicketNoCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClickTime
            // 
            this.lblClickTime.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblClickTime.ForeColor = System.Drawing.Color.Blue;
            this.lblClickTime.Location = new System.Drawing.Point(79, 23);
            this.lblClickTime.Name = "lblClickTime";
            this.lblClickTime.Size = new System.Drawing.Size(48, 15);
            this.lblClickTime.TabIndex = 85;
            // 
            // btnMonitor
            // 
            this.btnMonitor.BackColor = System.Drawing.Color.Transparent;
            this.btnMonitor.FlatAppearance.BorderSize = 0;
            this.btnMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonitor.Font = new System.Drawing.Font("굴림", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMonitor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMonitor.Location = new System.Drawing.Point(-1, -7);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(72, 66);
            this.btnMonitor.TabIndex = 86;
            this.btnMonitor.Text = "↺";
            this.btnMonitor.UseVisualStyleBackColor = false;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // frmFlowTicket
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 545);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFlowTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmFlowTicketing";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFlowTicketing_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader cnt;
        private System.Windows.Forms.ColumnHeader exit_dt;
        private System.Windows.Forms.ColumnHeader entry_dt;
        private System.Windows.Forms.ColumnHeader the_no;
        private System.Windows.Forms.Label lblBusinessTitle;
        private System.Windows.Forms.DateTimePicker dtBusiness;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnTicketDetail;
        private System.Windows.Forms.ColumnHeader gap_dt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbTicketNo;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lblActTheNoCnt;
        private System.Windows.Forms.Label lblTicketNoCnt;
        private System.Windows.Forms.Label lblTheNoCnt;
        private System.Windows.Forms.Label lblActTicketNoCnt;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Label lblClickTime;
    }
}