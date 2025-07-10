namespace thepos
{
    partial class frmReportDayCard
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
            this.pos_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.net_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c01 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c02 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c03 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c06 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c07 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c08 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnView = new System.Windows.Forms.Button();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.dtpBizDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pos_no,
            this.net_amount,
            this.c01,
            this.c02,
            this.c03,
            this.c06,
            this.c07,
            this.c08,
            this.c11,
            this.c17,
            this.c33});
            this.lvwList.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(8, 70);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(785, 610);
            this.lvwList.TabIndex = 87;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // pos_no
            // 
            this.pos_no.Text = "포스";
            this.pos_no.Width = 40;
            // 
            // net_amount
            // 
            this.net_amount.Text = "매출금액";
            this.net_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.net_amount.Width = 80;
            // 
            // c01
            // 
            this.c01.Text = "비씨";
            this.c01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c01.Width = 75;
            // 
            // c02
            // 
            this.c02.Text = "KB국민";
            this.c02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c02.Width = 75;
            // 
            // c03
            // 
            this.c03.Text = "하나";
            this.c03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c03.Width = 75;
            // 
            // c06
            // 
            this.c06.Text = "삼성";
            this.c06.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c06.Width = 75;
            // 
            // c07
            // 
            this.c07.Text = "신한";
            this.c07.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c07.Width = 75;
            // 
            // c08
            // 
            this.c08.Text = "현대";
            this.c08.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c08.Width = 75;
            // 
            // c11
            // 
            this.c11.Text = "NH농협";
            this.c11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c11.Width = 70;
            // 
            // c17
            // 
            this.c17.Text = "우리";
            this.c17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c17.Width = 70;
            // 
            // c33
            // 
            this.c33.Text = "롯데";
            this.c33.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c33.Width = 70;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnView.Location = new System.Drawing.Point(660, 25);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 27);
            this.btnView.TabIndex = 86;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblReportTitle.Location = new System.Drawing.Point(25, 27);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(176, 28);
            this.lblReportTitle.TabIndex = 85;
            this.lblReportTitle.Text = "일별 카드사별 포스별 매출\r\n(매입사 기준)";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpBizDate
            // 
            this.dtpBizDate.CalendarFont = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBizDate.Location = new System.Drawing.Point(349, 27);
            this.dtpBizDate.Name = "dtpBizDate";
            this.dtpBizDate.Size = new System.Drawing.Size(110, 23);
            this.dtpBizDate.TabIndex = 88;
            // 
            // frmReportDayCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblReportTitle);
            this.Controls.Add(this.dtpBizDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportDayCard";
            this.Text = "frmReportDayPos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader pos_no;
        private System.Windows.Forms.ColumnHeader net_amount;
        private System.Windows.Forms.ColumnHeader c01;
        private System.Windows.Forms.ColumnHeader c02;
        private System.Windows.Forms.ColumnHeader c03;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.DateTimePicker dtpBizDate;
        private System.Windows.Forms.ColumnHeader c06;
        private System.Windows.Forms.ColumnHeader c07;
        private System.Windows.Forms.ColumnHeader c08;
        private System.Windows.Forms.ColumnHeader c17;
        private System.Windows.Forms.ColumnHeader c33;
        private System.Windows.Forms.ColumnHeader c11;
    }
}