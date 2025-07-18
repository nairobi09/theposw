﻿namespace thepos
{
    partial class frmReportDayShop
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
            this.btnViewDay = new System.Windows.Forms.Button();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.lvwList = new System.Windows.Forms.ListView();
            this.items_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.net_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpBizDate = new System.Windows.Forms.DateTimePicker();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.tbKeyword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnViewDay
            // 
            this.btnViewDay.BackColor = System.Drawing.Color.White;
            this.btnViewDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDay.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnViewDay.Location = new System.Drawing.Point(609, 26);
            this.btnViewDay.Name = "btnViewDay";
            this.btnViewDay.Size = new System.Drawing.Size(100, 27);
            this.btnViewDay.TabIndex = 78;
            this.btnViewDay.Text = "조회";
            this.btnViewDay.UseVisualStyleBackColor = false;
            this.btnViewDay.Click += new System.EventHandler(this.btnViewDay_Click);
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblReportTitle.Location = new System.Drawing.Point(25, 35);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(102, 13);
            this.lblReportTitle.TabIndex = 76;
            this.lblReportTitle.Text = "업장별 일별매출";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.items_name,
            this.cnt,
            this.amount,
            this.dc_amount,
            this.net_amount});
            this.lvwList.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(20, 70);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(760, 610);
            this.lvwList.TabIndex = 83;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // items_name
            // 
            this.items_name.Text = "상품명";
            this.items_name.Width = 250;
            // 
            // cnt
            // 
            this.cnt.Text = "수량";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // amount
            // 
            this.amount.Text = "상품금액";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount.Width = 90;
            // 
            // dc_amount
            // 
            this.dc_amount.Text = "할인금액";
            this.dc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dc_amount.Width = 90;
            // 
            // net_amount
            // 
            this.net_amount.Text = "매출금액";
            this.net_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.net_amount.Width = 90;
            // 
            // dtpBizDate
            // 
            this.dtpBizDate.CalendarFont = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBizDate.Location = new System.Drawing.Point(352, 27);
            this.dtpBizDate.Name = "dtpBizDate";
            this.dtpBizDate.Size = new System.Drawing.Size(110, 23);
            this.dtpBizDate.TabIndex = 84;
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.BackColor = System.Drawing.Color.White;
            this.btnSaveExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveExcel.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSaveExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnSaveExcel.Location = new System.Drawing.Point(723, 25);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(57, 27);
            this.btnSaveExcel.TabIndex = 102;
            this.btnSaveExcel.Text = "엑셀";
            this.btnSaveExcel.UseVisualStyleBackColor = false;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // tbKeyword
            // 
            this.tbKeyword.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbKeyword.Location = new System.Drawing.Point(500, 27);
            this.tbKeyword.Name = "tbKeyword";
            this.tbKeyword.Size = new System.Drawing.Size(100, 23);
            this.tbKeyword.TabIndex = 107;
            this.tbKeyword.TabStop = false;
            // 
            // frmReportDayShop
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.tbKeyword);
            this.Controls.Add(this.btnSaveExcel);
            this.Controls.Add(this.dtpBizDate);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.btnViewDay);
            this.Controls.Add(this.lblReportTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportDayShop";
            this.Text = "frmReportDay1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnViewDay;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.DateTimePicker dtpBizDate;
        private System.Windows.Forms.ColumnHeader items_name;
        private System.Windows.Forms.ColumnHeader cnt;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.ColumnHeader dc_amount;
        private System.Windows.Forms.ColumnHeader net_amount;
        private System.Windows.Forms.Button btnSaveExcel;
        private System.Windows.Forms.TextBox tbKeyword;
    }
}