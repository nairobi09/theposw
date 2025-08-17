namespace thepos
{
    partial class frmSysAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysAdmin));
            this.panelView = new System.Windows.Forms.Panel();
            this.panelAdminConsole = new System.Windows.Forms.Panel();
            this.btnSysGoodsItemKiosk = new System.Windows.Forms.Button();
            this.btnSysGoodsItemPos = new System.Windows.Forms.Button();
            this.btnSysGoodsGroupKiosk = new System.Windows.Forms.Button();
            this.btnSysGoodsGroupPos = new System.Windows.Forms.Button();
            this.btnSysGoodsTicket = new System.Windows.Forms.Button();
            this.btnSysFlowConsole = new System.Windows.Forms.Button();
            this.btnSysOption = new System.Windows.Forms.Button();
            this.btnSysSoldout = new System.Windows.Forms.Button();
            this.btnDcrFavorite = new System.Windows.Forms.Button();
            this.btnSysSite = new System.Windows.Forms.Button();
            this.btnSysShop = new System.Windows.Forms.Button();
            this.btnSysPayConsole = new System.Windows.Forms.Button();
            this.btnSysGoods = new System.Windows.Forms.Button();
            this.btnPos = new System.Windows.Forms.Button();
            this.panelCertConsole = new System.Windows.Forms.Panel();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnTree = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnPosMac = new System.Windows.Forms.Button();
            this.panelAdminConsole.SuspendLayout();
            this.panelCertConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelView
            // 
            this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelView.Location = new System.Drawing.Point(130, 10);
            this.panelView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(870, 710);
            this.panelView.TabIndex = 1;
            // 
            // panelAdminConsole
            // 
            this.panelAdminConsole.Controls.Add(this.btnSysGoodsItemKiosk);
            this.panelAdminConsole.Controls.Add(this.btnSysGoodsItemPos);
            this.panelAdminConsole.Controls.Add(this.btnSysGoodsGroupKiosk);
            this.panelAdminConsole.Controls.Add(this.btnSysGoodsGroupPos);
            this.panelAdminConsole.Controls.Add(this.btnSysGoodsTicket);
            this.panelAdminConsole.Controls.Add(this.btnSysFlowConsole);
            this.panelAdminConsole.Controls.Add(this.btnSysOption);
            this.panelAdminConsole.Controls.Add(this.btnSysSoldout);
            this.panelAdminConsole.Controls.Add(this.btnDcrFavorite);
            this.panelAdminConsole.Controls.Add(this.btnSysSite);
            this.panelAdminConsole.Controls.Add(this.btnSysShop);
            this.panelAdminConsole.Controls.Add(this.btnSysPayConsole);
            this.panelAdminConsole.Controls.Add(this.btnSysGoods);
            this.panelAdminConsole.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.panelAdminConsole.Location = new System.Drawing.Point(0, 48);
            this.panelAdminConsole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelAdminConsole.Name = "panelAdminConsole";
            this.panelAdminConsole.Size = new System.Drawing.Size(123, 556);
            this.panelAdminConsole.TabIndex = 2;
            this.panelAdminConsole.Visible = false;
            // 
            // btnSysGoodsItemKiosk
            // 
            this.btnSysGoodsItemKiosk.BackColor = System.Drawing.Color.White;
            this.btnSysGoodsItemKiosk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoodsItemKiosk.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysGoodsItemKiosk.Location = new System.Drawing.Point(7, 354);
            this.btnSysGoodsItemKiosk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoodsItemKiosk.Name = "btnSysGoodsItemKiosk";
            this.btnSysGoodsItemKiosk.Size = new System.Drawing.Size(112, 30);
            this.btnSysGoodsItemKiosk.TabIndex = 13;
            this.btnSysGoodsItemKiosk.TabStop = false;
            this.btnSysGoodsItemKiosk.Text = "(KIOSK)";
            this.btnSysGoodsItemKiosk.UseVisualStyleBackColor = false;
            this.btnSysGoodsItemKiosk.Click += new System.EventHandler(this.btnSysGoodsItemKiosk_Click);
            // 
            // btnSysGoodsItemPos
            // 
            this.btnSysGoodsItemPos.BackColor = System.Drawing.Color.White;
            this.btnSysGoodsItemPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoodsItemPos.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysGoodsItemPos.Location = new System.Drawing.Point(7, 310);
            this.btnSysGoodsItemPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoodsItemPos.Name = "btnSysGoodsItemPos";
            this.btnSysGoodsItemPos.Size = new System.Drawing.Size(112, 40);
            this.btnSysGoodsItemPos.TabIndex = 12;
            this.btnSysGoodsItemPos.TabStop = false;
            this.btnSysGoodsItemPos.Text = "상품배치\r\n(POS)";
            this.btnSysGoodsItemPos.UseVisualStyleBackColor = false;
            this.btnSysGoodsItemPos.Click += new System.EventHandler(this.btnSysGoodsItemPos_Click);
            // 
            // btnSysGoodsGroupKiosk
            // 
            this.btnSysGoodsGroupKiosk.BackColor = System.Drawing.Color.White;
            this.btnSysGoodsGroupKiosk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoodsGroupKiosk.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysGoodsGroupKiosk.Location = new System.Drawing.Point(7, 265);
            this.btnSysGoodsGroupKiosk.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSysGoodsGroupKiosk.Name = "btnSysGoodsGroupKiosk";
            this.btnSysGoodsGroupKiosk.Size = new System.Drawing.Size(112, 30);
            this.btnSysGoodsGroupKiosk.TabIndex = 11;
            this.btnSysGoodsGroupKiosk.TabStop = false;
            this.btnSysGoodsGroupKiosk.Text = "(KIOSK)";
            this.btnSysGoodsGroupKiosk.UseVisualStyleBackColor = false;
            this.btnSysGoodsGroupKiosk.Click += new System.EventHandler(this.btnSysGoodsGroupKiosk_Click);
            // 
            // btnSysGoodsGroupPos
            // 
            this.btnSysGoodsGroupPos.BackColor = System.Drawing.Color.White;
            this.btnSysGoodsGroupPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoodsGroupPos.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysGoodsGroupPos.Location = new System.Drawing.Point(7, 221);
            this.btnSysGoodsGroupPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoodsGroupPos.Name = "btnSysGoodsGroupPos";
            this.btnSysGoodsGroupPos.Size = new System.Drawing.Size(112, 40);
            this.btnSysGoodsGroupPos.TabIndex = 10;
            this.btnSysGoodsGroupPos.TabStop = false;
            this.btnSysGoodsGroupPos.Text = "상품그룹\r\n(POS)";
            this.btnSysGoodsGroupPos.UseVisualStyleBackColor = false;
            this.btnSysGoodsGroupPos.Click += new System.EventHandler(this.btnSysGoodsGroupPos_Click);
            // 
            // btnSysGoodsTicket
            // 
            this.btnSysGoodsTicket.BackColor = System.Drawing.Color.White;
            this.btnSysGoodsTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoodsTicket.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysGoodsTicket.Location = new System.Drawing.Point(7, 174);
            this.btnSysGoodsTicket.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoodsTicket.Name = "btnSysGoodsTicket";
            this.btnSysGoodsTicket.Size = new System.Drawing.Size(112, 30);
            this.btnSysGoodsTicket.TabIndex = 9;
            this.btnSysGoodsTicket.TabStop = false;
            this.btnSysGoodsTicket.Text = "티켓상품";
            this.btnSysGoodsTicket.UseVisualStyleBackColor = false;
            this.btnSysGoodsTicket.Click += new System.EventHandler(this.btnSysGoodsTicket_Click);
            // 
            // btnSysFlowConsole
            // 
            this.btnSysFlowConsole.BackColor = System.Drawing.Color.White;
            this.btnSysFlowConsole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysFlowConsole.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysFlowConsole.Location = new System.Drawing.Point(7, 485);
            this.btnSysFlowConsole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysFlowConsole.Name = "btnSysFlowConsole";
            this.btnSysFlowConsole.Size = new System.Drawing.Size(112, 30);
            this.btnSysFlowConsole.TabIndex = 8;
            this.btnSysFlowConsole.TabStop = false;
            this.btnSysFlowConsole.Text = "티켓버튼배치";
            this.btnSysFlowConsole.UseVisualStyleBackColor = false;
            this.btnSysFlowConsole.Click += new System.EventHandler(this.btnSysFlowConsole_Click);
            // 
            // btnSysOption
            // 
            this.btnSysOption.BackColor = System.Drawing.Color.White;
            this.btnSysOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysOption.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysOption.Location = new System.Drawing.Point(7, 132);
            this.btnSysOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysOption.Name = "btnSysOption";
            this.btnSysOption.Size = new System.Drawing.Size(112, 30);
            this.btnSysOption.TabIndex = 7;
            this.btnSysOption.TabStop = false;
            this.btnSysOption.Text = "상품옵션";
            this.btnSysOption.UseVisualStyleBackColor = false;
            this.btnSysOption.Click += new System.EventHandler(this.btnSysOption_Click);
            // 
            // btnSysSoldout
            // 
            this.btnSysSoldout.BackColor = System.Drawing.Color.White;
            this.btnSysSoldout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysSoldout.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysSoldout.Location = new System.Drawing.Point(7, 396);
            this.btnSysSoldout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysSoldout.Name = "btnSysSoldout";
            this.btnSysSoldout.Size = new System.Drawing.Size(112, 40);
            this.btnSysSoldout.TabIndex = 6;
            this.btnSysSoldout.TabStop = false;
            this.btnSysSoldout.Text = "품절/절판";
            this.btnSysSoldout.UseVisualStyleBackColor = false;
            this.btnSysSoldout.Click += new System.EventHandler(this.btnSoldout_Click);
            // 
            // btnDcrFavorite
            // 
            this.btnDcrFavorite.BackColor = System.Drawing.Color.White;
            this.btnDcrFavorite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDcrFavorite.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDcrFavorite.Location = new System.Drawing.Point(7, 452);
            this.btnDcrFavorite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDcrFavorite.Name = "btnDcrFavorite";
            this.btnDcrFavorite.Size = new System.Drawing.Size(112, 30);
            this.btnDcrFavorite.TabIndex = 3;
            this.btnDcrFavorite.TabStop = false;
            this.btnDcrFavorite.Text = "할인즐겨찾기";
            this.btnDcrFavorite.UseVisualStyleBackColor = false;
            this.btnDcrFavorite.Click += new System.EventHandler(this.btnDcrFavorite_Click);
            // 
            // btnSysSite
            // 
            this.btnSysSite.BackColor = System.Drawing.Color.White;
            this.btnSysSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysSite.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysSite.Location = new System.Drawing.Point(7, 0);
            this.btnSysSite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysSite.Name = "btnSysSite";
            this.btnSysSite.Size = new System.Drawing.Size(112, 30);
            this.btnSysSite.TabIndex = 2;
            this.btnSysSite.TabStop = false;
            this.btnSysSite.Text = "사업장\r\n";
            this.btnSysSite.UseVisualStyleBackColor = false;
            this.btnSysSite.Click += new System.EventHandler(this.btnSysSite_Click);
            // 
            // btnSysShop
            // 
            this.btnSysShop.BackColor = System.Drawing.Color.White;
            this.btnSysShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysShop.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysShop.Location = new System.Drawing.Point(7, 36);
            this.btnSysShop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysShop.Name = "btnSysShop";
            this.btnSysShop.Size = new System.Drawing.Size(112, 30);
            this.btnSysShop.TabIndex = 1;
            this.btnSysShop.TabStop = false;
            this.btnSysShop.Text = "업장/분류";
            this.btnSysShop.UseVisualStyleBackColor = false;
            this.btnSysShop.Click += new System.EventHandler(this.btnSysShop_Click);
            // 
            // btnSysPayConsole
            // 
            this.btnSysPayConsole.BackColor = System.Drawing.Color.White;
            this.btnSysPayConsole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysPayConsole.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysPayConsole.Location = new System.Drawing.Point(7, 518);
            this.btnSysPayConsole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysPayConsole.Name = "btnSysPayConsole";
            this.btnSysPayConsole.Size = new System.Drawing.Size(112, 30);
            this.btnSysPayConsole.TabIndex = 0;
            this.btnSysPayConsole.TabStop = false;
            this.btnSysPayConsole.Text = "결제버튼배치";
            this.btnSysPayConsole.UseVisualStyleBackColor = false;
            this.btnSysPayConsole.Click += new System.EventHandler(this.btnSysPayConsole_Click);
            // 
            // btnSysGoods
            // 
            this.btnSysGoods.BackColor = System.Drawing.Color.White;
            this.btnSysGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoods.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSysGoods.Location = new System.Drawing.Point(7, 79);
            this.btnSysGoods.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoods.Name = "btnSysGoods";
            this.btnSysGoods.Size = new System.Drawing.Size(112, 50);
            this.btnSysGoods.TabIndex = 0;
            this.btnSysGoods.TabStop = false;
            this.btnSysGoods.Text = "기초상품";
            this.btnSysGoods.UseVisualStyleBackColor = false;
            this.btnSysGoods.Click += new System.EventHandler(this.btnSysGoods_Click);
            // 
            // btnPos
            // 
            this.btnPos.BackColor = System.Drawing.Color.White;
            this.btnPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPos.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPos.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPos.Location = new System.Drawing.Point(7, 10);
            this.btnPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPos.Name = "btnPos";
            this.btnPos.Size = new System.Drawing.Size(112, 30);
            this.btnPos.TabIndex = 0;
            this.btnPos.TabStop = false;
            this.btnPos.Text = "기기등록신청";
            this.btnPos.UseVisualStyleBackColor = false;
            this.btnPos.Click += new System.EventHandler(this.btnPos_Click);
            // 
            // panelCertConsole
            // 
            this.panelCertConsole.Controls.Add(this.btnUser);
            this.panelCertConsole.Controls.Add(this.btnTree);
            this.panelCertConsole.Controls.Add(this.btnLog);
            this.panelCertConsole.Controls.Add(this.btnPosMac);
            this.panelCertConsole.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.panelCertConsole.Location = new System.Drawing.Point(0, 607);
            this.panelCertConsole.Name = "panelCertConsole";
            this.panelCertConsole.Size = new System.Drawing.Size(122, 116);
            this.panelCertConsole.TabIndex = 3;
            this.panelCertConsole.Visible = false;
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.White;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUser.ForeColor = System.Drawing.Color.Red;
            this.btnUser.Location = new System.Drawing.Point(7, 29);
            this.btnUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(112, 26);
            this.btnUser.TabIndex = 2;
            this.btnUser.TabStop = false;
            this.btnUser.Text = "사용자인증";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnTree
            // 
            this.btnTree.BackColor = System.Drawing.Color.White;
            this.btnTree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTree.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTree.ForeColor = System.Drawing.Color.Red;
            this.btnTree.Location = new System.Drawing.Point(7, 58);
            this.btnTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(112, 26);
            this.btnTree.TabIndex = 4;
            this.btnTree.TabStop = false;
            this.btnTree.Text = "원장트리";
            this.btnTree.UseVisualStyleBackColor = false;
            this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.White;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLog.ForeColor = System.Drawing.Color.Red;
            this.btnLog.Location = new System.Drawing.Point(7, 87);
            this.btnLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(112, 26);
            this.btnLog.TabIndex = 3;
            this.btnLog.TabStop = false;
            this.btnLog.Text = "앱로그";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnPosMac
            // 
            this.btnPosMac.BackColor = System.Drawing.Color.White;
            this.btnPosMac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosMac.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPosMac.ForeColor = System.Drawing.Color.Red;
            this.btnPosMac.Location = new System.Drawing.Point(7, 0);
            this.btnPosMac.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPosMac.Name = "btnPosMac";
            this.btnPosMac.Size = new System.Drawing.Size(112, 26);
            this.btnPosMac.TabIndex = 1;
            this.btnPosMac.TabStop = false;
            this.btnPosMac.Text = "기기인증";
            this.btnPosMac.UseVisualStyleBackColor = false;
            this.btnPosMac.Click += new System.EventHandler(this.btnPosMac_Click);
            // 
            // frmSysAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panelCertConsole);
            this.Controls.Add(this.btnPos);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelAdminConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "사용자어드민";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSysAdmin_FormClosed);
            this.panelAdminConsole.ResumeLayout(false);
            this.panelCertConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Panel panelAdminConsole;
        private System.Windows.Forms.Button btnPos;
        private System.Windows.Forms.Button btnSysGoods;
        private System.Windows.Forms.Button btnSysPayConsole;
        private System.Windows.Forms.Button btnSysShop;
        private System.Windows.Forms.Button btnSysSite;
        private System.Windows.Forms.Panel panelCertConsole;
        private System.Windows.Forms.Button btnPosMac;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnDcrFavorite;
        private System.Windows.Forms.Button btnSysSoldout;
        private System.Windows.Forms.Button btnSysOption;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnSysFlowConsole;
        private System.Windows.Forms.Button btnTree;
        private System.Windows.Forms.Button btnSysGoodsTicket;
        private System.Windows.Forms.Button btnSysGoodsItemKiosk;
        private System.Windows.Forms.Button btnSysGoodsItemPos;
        private System.Windows.Forms.Button btnSysGoodsGroupKiosk;
        private System.Windows.Forms.Button btnSysGoodsGroupPos;
    }
}