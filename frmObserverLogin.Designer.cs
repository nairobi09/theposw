namespace thepos
{
    partial class frmObserverLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmObserverLogin));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLoginDev = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPW = new System.Windows.Forms.Label();
            this.tbPosNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPinNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(449, 256);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLoginDev
            // 
            this.btnLoginDev.Location = new System.Drawing.Point(359, 256);
            this.btnLoginDev.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoginDev.Name = "btnLoginDev";
            this.btnLoginDev.Size = new System.Drawing.Size(73, 25);
            this.btnLoginDev.TabIndex = 2;
            this.btnLoginDev.Text = "로그인";
            this.btnLoginDev.UseVisualStyleBackColor = true;
            this.btnLoginDev.Click += new System.EventHandler(this.btnLoginDev_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(200, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "옵저버로그인 - 키벤저스";
            // 
            // lblPW
            // 
            this.lblPW.AutoSize = true;
            this.lblPW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPW.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPW.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPW.Location = new System.Drawing.Point(202, 117);
            this.lblPW.Name = "lblPW";
            this.lblPW.Size = new System.Drawing.Size(61, 15);
            this.lblPW.TabIndex = 43;
            this.lblPW.Text = "포스번호";
            this.lblPW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPosNo
            // 
            this.tbPosNo.BackColor = System.Drawing.Color.DarkGray;
            this.tbPosNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPosNo.Location = new System.Drawing.Point(270, 117);
            this.tbPosNo.Margin = new System.Windows.Forms.Padding(4);
            this.tbPosNo.MaxLength = 2;
            this.tbPosNo.Name = "tbPosNo";
            this.tbPosNo.Size = new System.Drawing.Size(39, 16);
            this.tbPosNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(68, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 96);
            this.label2.TabIndex = 6;
            this.label2.Text = "01 - 입장\r\n02  -입장\r\n03 - 퇴장\r\n04 - MD\r\n05 - 카트\r\n06 - F&&B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(180, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 6;
            // 
            // tbPinNo
            // 
            this.tbPinNo.BackColor = System.Drawing.Color.DarkGray;
            this.tbPinNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPinNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPinNo.Location = new System.Drawing.Point(267, 159);
            this.tbPinNo.Margin = new System.Windows.Forms.Padding(4);
            this.tbPinNo.MaxLength = 8;
            this.tbPinNo.Name = "tbPinNo";
            this.tbPinNo.Size = new System.Drawing.Size(89, 16);
            this.tbPinNo.TabIndex = 44;
            this.tbPinNo.Text = "20250630";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(205, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 45;
            this.label4.Text = "PIN NO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl.Location = new System.Drawing.Point(267, 195);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(16, 15);
            this.lbl.TabIndex = 46;
            this.lbl.Text = "_";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmObserverLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(561, 316);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.tbPinNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPosNo);
            this.Controls.Add(this.lblPW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoginDev);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmObserverLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDevAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLoginDev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPW;
        public System.Windows.Forms.TextBox tbPosNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbPinNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl;
    }
}