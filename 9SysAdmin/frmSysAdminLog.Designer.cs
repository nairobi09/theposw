namespace thepos._9SysAdmin
{
    partial class frmSysAdminLog
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
            this.log_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.log_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SiteId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PosNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.formName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.formAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.formMemo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitle = new System.Windows.Forms.Label();
            this.dtpBizDate = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.tbPosNo = new System.Windows.Forms.TextBox();
            this.tbFromTime = new System.Windows.Forms.TextBox();
            this.tbSiteId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.log_date,
            this.log_time,
            this.SiteId,
            this.PosNo,
            this.formName,
            this.formAction,
            this.formMemo});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(8, 43);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(854, 659);
            this.lvwList.TabIndex = 33;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            this.lvwList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwList_MouseDoubleClick);
            // 
            // log_date
            // 
            this.log_date.Text = "date";
            this.log_date.Width = 70;
            // 
            // log_time
            // 
            this.log_time.Text = "time";
            // 
            // SiteId
            // 
            this.SiteId.Text = "site";
            this.SiteId.Width = 50;
            // 
            // PosNo
            // 
            this.PosNo.Text = "pos";
            this.PosNo.Width = 40;
            // 
            // formName
            // 
            this.formName.Text = "form";
            this.formName.Width = 120;
            // 
            // formAction
            // 
            this.formAction.Text = "action";
            this.formAction.Width = 150;
            // 
            // formMemo
            // 
            this.formMemo.Text = "memo";
            this.formMemo.Width = 339;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(12, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 14);
            this.lblTitle.TabIndex = 29;
            this.lblTitle.Text = "로그";
            // 
            // dtpBizDate
            // 
            this.dtpBizDate.CalendarFont = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBizDate.Location = new System.Drawing.Point(472, 12);
            this.dtpBizDate.Name = "dtpBizDate";
            this.dtpBizDate.Size = new System.Drawing.Size(92, 23);
            this.dtpBizDate.TabIndex = 86;
            this.dtpBizDate.TabStop = false;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnView.Location = new System.Drawing.Point(749, 12);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 23);
            this.btnView.TabIndex = 85;
            this.btnView.TabStop = false;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // tbPosNo
            // 
            this.tbPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPosNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbPosNo.Location = new System.Drawing.Point(694, 12);
            this.tbPosNo.MaxLength = 2;
            this.tbPosNo.Name = "tbPosNo";
            this.tbPosNo.Size = new System.Drawing.Size(31, 23);
            this.tbPosNo.TabIndex = 88;
            this.tbPosNo.TabStop = false;
            // 
            // tbFromTime
            // 
            this.tbFromTime.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbFromTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbFromTime.Location = new System.Drawing.Point(570, 12);
            this.tbFromTime.MaxLength = 6;
            this.tbFromTime.Name = "tbFromTime";
            this.tbFromTime.Size = new System.Drawing.Size(54, 23);
            this.tbFromTime.TabIndex = 89;
            this.tbFromTime.TabStop = false;
            // 
            // tbSiteId
            // 
            this.tbSiteId.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSiteId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSiteId.Location = new System.Drawing.Point(647, 12);
            this.tbSiteId.MaxLength = 4;
            this.tbSiteId.Name = "tbSiteId";
            this.tbSiteId.Size = new System.Drawing.Size(41, 23);
            this.tbSiteId.TabIndex = 87;
            this.tbSiteId.TabStop = false;
            // 
            // frmSysAdminLog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.tbFromTime);
            this.Controls.Add(this.tbPosNo);
            this.Controls.Add(this.tbSiteId);
            this.Controls.Add(this.dtpBizDate);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysAdminLog";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader formName;
        private System.Windows.Forms.ColumnHeader formAction;
        private System.Windows.Forms.ColumnHeader log_date;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader SiteId;
        private System.Windows.Forms.ColumnHeader PosNo;
        private System.Windows.Forms.DateTimePicker dtpBizDate;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ColumnHeader log_time;
        private System.Windows.Forms.ColumnHeader formMemo;
        private System.Windows.Forms.TextBox tbPosNo;
        private System.Windows.Forms.TextBox tbFromTime;
        private System.Windows.Forms.TextBox tbSiteId;
    }
}