namespace theposw._9SysAdmin
{
    partial class frmSysAdminTree
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
            this.c0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnView = new System.Windows.Forms.Button();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.tvwList = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c0,
            this.c1});
            this.lvwList.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(491, 70);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(284, 607);
            this.lvwList.TabIndex = 97;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // c0
            // 
            this.c0.Text = "항목";
            this.c0.Width = 127;
            // 
            // c1
            // 
            this.c1.Text = "내용";
            this.c1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c1.Width = 124;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnView.Location = new System.Drawing.Point(377, 24);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 29);
            this.btnView.TabIndex = 94;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblReportTitle.Location = new System.Drawing.Point(25, 30);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(93, 19);
            this.lblReportTitle.TabIndex = 92;
            this.lblReportTitle.Text = "등록정보트리";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvwList
            // 
            this.tvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tvwList.Location = new System.Drawing.Point(29, 70);
            this.tvwList.Name = "tvwList";
            this.tvwList.Size = new System.Drawing.Size(446, 606);
            this.tvwList.TabIndex = 98;
            this.tvwList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwList_AfterSelect);
            // 
            // frmSysAdminTree
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.tvwList);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblReportTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysAdminTree";
            this.Text = "frmSysAdminTree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader c0;
        private System.Windows.Forms.ColumnHeader c1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.TreeView tvwList;
    }
}