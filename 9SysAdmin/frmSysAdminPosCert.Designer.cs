namespace thepos._9SysAdmin
{
    partial class frmSysAdminPosCert
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwList = new System.Windows.Forms.ListView();
            this.PosNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pos_group_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pos_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.conn_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.conn_last = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.u_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbShopCode = new System.Windows.Forms.TextBox();
            this.lblShopCodeTitle = new System.Windows.Forms.Label();
            this.tbMAC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(656, 648);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 47);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Red;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnter.ForeColor = System.Drawing.Color.White;
            this.btnEnter.Location = new System.Drawing.Point(718, 648);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(140, 47);
            this.btnEnter.TabIndex = 25;
            this.btnEnter.TabStop = false;
            this.btnEnter.Text = "인증/수정";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(33, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 14);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "포스기기 인증";
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PosNo,
            this.mac,
            this.date,
            this.stat,
            this.pos_group_code,
            this.pos_type,
            this.conn_cnt,
            this.conn_last,
            this.u_name});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(16, 64);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(842, 474);
            this.lvwList.TabIndex = 28;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            // 
            // PosNo
            // 
            this.PosNo.Text = "번호";
            this.PosNo.Width = 40;
            // 
            // mac
            // 
            this.mac.Text = "기기번호";
            this.mac.Width = 140;
            // 
            // date
            // 
            this.date.Text = "신청일";
            this.date.Width = 120;
            // 
            // stat
            // 
            this.stat.Text = "상태";
            this.stat.Width = 80;
            // 
            // pos_group_code
            // 
            this.pos_group_code.Text = "포스그룹";
            this.pos_group_code.Width = 70;
            // 
            // pos_type
            // 
            this.pos_type.Text = "유형";
            this.pos_type.Width = 50;
            // 
            // conn_cnt
            // 
            this.conn_cnt.Text = "접속수";
            this.conn_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // conn_last
            // 
            this.conn_last.Text = "최종접속";
            this.conn_last.Width = 120;
            // 
            // u_name
            // 
            this.u_name.Text = "실사용자";
            this.u_name.Width = 130;
            // 
            // tbShopCode
            // 
            this.tbShopCode.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbShopCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbShopCode.Location = new System.Drawing.Point(718, 578);
            this.tbShopCode.MaxLength = 2;
            this.tbShopCode.Name = "tbShopCode";
            this.tbShopCode.Size = new System.Drawing.Size(140, 23);
            this.tbShopCode.TabIndex = 37;
            // 
            // lblShopCodeTitle
            // 
            this.lblShopCodeTitle.AutoSize = true;
            this.lblShopCodeTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblShopCodeTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblShopCodeTitle.Location = new System.Drawing.Point(645, 584);
            this.lblShopCodeTitle.Name = "lblShopCodeTitle";
            this.lblShopCodeTitle.Size = new System.Drawing.Size(63, 14);
            this.lblShopCodeTitle.TabIndex = 38;
            this.lblShopCodeTitle.Text = "포스그룹";
            // 
            // tbMAC
            // 
            this.tbMAC.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbMAC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbMAC.Location = new System.Drawing.Point(718, 550);
            this.tbMAC.MaxLength = 50;
            this.tbMAC.Name = "tbMAC";
            this.tbMAC.Size = new System.Drawing.Size(140, 23);
            this.tbMAC.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(670, 556);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 14);
            this.label1.TabIndex = 40;
            this.label1.Text = "MAC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(35, 586);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 98);
            this.label2.TabIndex = 41;
            this.label2.Text = "포스번호룰\r\n\r\n01~ 포스\r\n11~ 키오스크\r\n21~ 테블릿(KDS)\r\n31~ 모바일(가앰점)\r\n41~ 모바일(공급자)\r\n";
            // 
            // tbUname
            // 
            this.tbUname.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbUname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbUname.Location = new System.Drawing.Point(718, 607);
            this.tbUname.MaxLength = 20;
            this.tbUname.Name = "tbUname";
            this.tbUname.Size = new System.Drawing.Size(140, 23);
            this.tbUname.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(645, 613);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 43;
            this.label3.Text = "실사용자";
            // 
            // frmSysAdminPosCert
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.tbUname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMAC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbShopCode);
            this.Controls.Add(this.lblShopCodeTitle);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysAdminPosCert";
            this.Text = "frmSysAdminMac";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader PosNo;
        private System.Windows.Forms.ColumnHeader mac;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader stat;
        private System.Windows.Forms.ColumnHeader pos_group_code;
        private System.Windows.Forms.TextBox tbShopCode;
        private System.Windows.Forms.Label lblShopCodeTitle;
        private System.Windows.Forms.TextBox tbMAC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader pos_type;
        private System.Windows.Forms.ColumnHeader conn_cnt;
        private System.Windows.Forms.ColumnHeader conn_last;
        private System.Windows.Forms.ColumnHeader u_name;
        private System.Windows.Forms.TextBox tbUname;
        private System.Windows.Forms.Label label3;
    }
}