namespace thepos
{
    partial class frmReportAllim
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
            this.btnView = new System.Windows.Forms.Button();
            this.lvwList = new System.Windows.Forms.ListView();
            this.mm_dd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblYYYYMM = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnView.Location = new System.Drawing.Point(680, 28);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 27);
            this.btnView.TabIndex = 97;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mm_dd,
            this.cnt});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(20, 71);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(760, 604);
            this.lvwList.TabIndex = 94;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // mm_dd
            // 
            this.mm_dd.Text = "일자";
            this.mm_dd.Width = 40;
            // 
            // cnt
            // 
            this.cnt.Text = "발송수량";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cnt.Width = 80;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblReportTitle.Location = new System.Drawing.Point(25, 34);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(91, 14);
            this.lblReportTitle.TabIndex = 95;
            this.lblReportTitle.Text = "알림발송내역";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnNext.Location = new System.Drawing.Point(463, 28);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 27);
            this.btnNext.TabIndex = 112;
            this.btnNext.TabStop = false;
            this.btnNext.Text = "▶";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.White;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnPrev.Location = new System.Drawing.Point(329, 28);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(30, 27);
            this.btnPrev.TabIndex = 111;
            this.btnPrev.TabStop = false;
            this.btnPrev.Text = "◀";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblYYYYMM
            // 
            this.lblYYYYMM.BackColor = System.Drawing.Color.White;
            this.lblYYYYMM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYYYYMM.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblYYYYMM.Location = new System.Drawing.Point(361, 28);
            this.lblYYYYMM.Name = "lblYYYYMM";
            this.lblYYYYMM.Size = new System.Drawing.Size(100, 27);
            this.lblYYYYMM.TabIndex = 110;
            this.lblYYYYMM.Text = "2023-10";
            this.lblYYYYMM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmReportAllim
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.lblYYYYMM);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.lblReportTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportAllim";
            this.Text = "frmReportAllim";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader cnt;
        private System.Windows.Forms.ColumnHeader mm_dd;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblYYYYMM;
    }
}