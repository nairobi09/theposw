namespace thepos._9SysAdmin
{
    partial class frmSysAdminUserCert
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
            this.stat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.auth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.req_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEnter = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbAuth = new System.Windows.Forms.TextBox();
            this.lblShopCodeTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stat,
            this.ID,
            this.auth,
            this.name,
            this.req_date});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(190, 77);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(472, 290);
            this.lvwList.TabIndex = 33;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            // 
            // stat
            // 
            this.stat.Text = "상태";
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 70;
            // 
            // auth
            // 
            this.auth.Text = "권한";
            // 
            // name
            // 
            this.name.Text = "성명";
            this.name.Width = 80;
            // 
            // req_date
            // 
            this.req_date.Text = "등록일시";
            this.req_date.Width = 140;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Red;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnter.ForeColor = System.Drawing.Color.White;
            this.btnEnter.Location = new System.Drawing.Point(364, 408);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(140, 50);
            this.btnEnter.TabIndex = 31;
            this.btnEnter.TabStop = false;
            this.btnEnter.Text = "인증등록";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(186, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 14);
            this.lblTitle.TabIndex = 29;
            this.lblTitle.Text = "사용자계정 인증";
            // 
            // tbAuth
            // 
            this.tbAuth.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbAuth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbAuth.Location = new System.Drawing.Point(681, 341);
            this.tbAuth.MaxLength = 1;
            this.tbAuth.Name = "tbAuth";
            this.tbAuth.Size = new System.Drawing.Size(64, 26);
            this.tbAuth.TabIndex = 39;
            // 
            // lblShopCodeTitle
            // 
            this.lblShopCodeTitle.AutoSize = true;
            this.lblShopCodeTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblShopCodeTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblShopCodeTitle.Location = new System.Drawing.Point(678, 319);
            this.lblShopCodeTitle.Name = "lblShopCodeTitle";
            this.lblShopCodeTitle.Size = new System.Drawing.Size(94, 14);
            this.lblShopCodeTitle.TabIndex = 40;
            this.lblShopCodeTitle.Text = "권한 (U or A)";
            // 
            // frmSysAdminUserCert
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.tbAuth);
            this.Controls.Add(this.lblShopCodeTitle);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysAdminUserCert";
            this.Text = "frmSysAdminUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader req_date;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader stat;
        private System.Windows.Forms.ColumnHeader auth;
        private System.Windows.Forms.TextBox tbAuth;
        private System.Windows.Forms.Label lblShopCodeTitle;
    }
}