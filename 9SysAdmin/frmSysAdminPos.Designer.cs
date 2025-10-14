namespace thepos._9SysAdmin
{
    partial class frmSysAdminPos
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbSiteId = new System.Windows.Forms.TextBox();
            this.tbPosNo = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblSiteIdTitle = new System.Windows.Forms.Label();
            this.lblPosNoTitle = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.tbShopCode = new System.Windows.Forms.TextBox();
            this.lblShopCodeTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(204, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 14);
            this.lblTitle.TabIndex = 27;
            this.lblTitle.Text = "기기 등록신청";
            // 
            // tbSiteId
            // 
            this.tbSiteId.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSiteId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSiteId.Location = new System.Drawing.Point(285, 171);
            this.tbSiteId.MaxLength = 4;
            this.tbSiteId.Name = "tbSiteId";
            this.tbSiteId.Size = new System.Drawing.Size(140, 26);
            this.tbSiteId.TabIndex = 0;
            // 
            // tbPosNo
            // 
            this.tbPosNo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPosNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbPosNo.Location = new System.Drawing.Point(285, 209);
            this.tbPosNo.MaxLength = 2;
            this.tbPosNo.Name = "tbPosNo";
            this.tbPosNo.Size = new System.Drawing.Size(140, 26);
            this.tbPosNo.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInfo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblInfo.Location = new System.Drawing.Point(204, 99);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(448, 14);
            this.lblInfo.TabIndex = 30;
            this.lblInfo.Text = "본기기를 아래 기관으로 등록신청합니다. 인증심사후 사용가능합니다.";
            // 
            // lblSiteIdTitle
            // 
            this.lblSiteIdTitle.AutoSize = true;
            this.lblSiteIdTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSiteIdTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSiteIdTitle.Location = new System.Drawing.Point(204, 177);
            this.lblSiteIdTitle.Name = "lblSiteIdTitle";
            this.lblSiteIdTitle.Size = new System.Drawing.Size(63, 14);
            this.lblSiteIdTitle.TabIndex = 31;
            this.lblSiteIdTitle.Text = "고객코드";
            // 
            // lblPosNoTitle
            // 
            this.lblPosNoTitle.AutoSize = true;
            this.lblPosNoTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNoTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPosNoTitle.Location = new System.Drawing.Point(204, 215);
            this.lblPosNoTitle.Name = "lblPosNoTitle";
            this.lblPosNoTitle.Size = new System.Drawing.Size(63, 14);
            this.lblPosNoTitle.TabIndex = 32;
            this.lblPosNoTitle.Text = "포스번호";
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnter.ForeColor = System.Drawing.Color.White;
            this.btnEnter.Location = new System.Drawing.Point(285, 488);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(140, 50);
            this.btnEnter.TabIndex = 3;
            this.btnEnter.TabStop = false;
            this.btnEnter.Text = "등록신청";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // tbShopCode
            // 
            this.tbShopCode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbShopCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbShopCode.Location = new System.Drawing.Point(285, 251);
            this.tbShopCode.MaxLength = 2;
            this.tbShopCode.Name = "tbShopCode";
            this.tbShopCode.Size = new System.Drawing.Size(140, 26);
            this.tbShopCode.TabIndex = 2;
            // 
            // lblShopCodeTitle
            // 
            this.lblShopCodeTitle.AutoSize = true;
            this.lblShopCodeTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblShopCodeTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblShopCodeTitle.Location = new System.Drawing.Point(204, 257);
            this.lblShopCodeTitle.Name = "lblShopCodeTitle";
            this.lblShopCodeTitle.Size = new System.Drawing.Size(63, 14);
            this.lblShopCodeTitle.TabIndex = 36;
            this.lblShopCodeTitle.Text = "포스그롭";
            // 
            // frmSysAdminPos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.tbShopCode);
            this.Controls.Add(this.lblShopCodeTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.tbSiteId);
            this.Controls.Add(this.tbPosNo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblSiteIdTitle);
            this.Controls.Add(this.lblPosNoTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysAdminPos";
            this.Text = "frmSysAdminPos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbSiteId;
        private System.Windows.Forms.TextBox tbPosNo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblSiteIdTitle;
        private System.Windows.Forms.Label lblPosNoTitle;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox tbShopCode;
        private System.Windows.Forms.Label lblShopCodeTitle;
    }
}