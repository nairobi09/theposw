namespace thepos._9SysAdmin
{
    partial class frmSysGoodsItemKiosk
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
            this.nod1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbShop = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLink = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.lblGroupTitle = new System.Windows.Forms.Label();
            this.lblPosNoTitle = new System.Windows.Forms.Label();
            this.shop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwGoodsLink = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwGoods = new System.Windows.Forms.ListView();
            this.item_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDn = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShopView = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbShopView = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nod1
            // 
            this.nod1.Text = "분류1";
            this.nod1.Width = 80;
            // 
            // cbShop
            // 
            this.cbShop.BackColor = System.Drawing.Color.White;
            this.cbShop.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbShop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbShop.FormattingEnabled = true;
            this.cbShop.Location = new System.Drawing.Point(6, 32);
            this.cbShop.Name = "cbShop";
            this.cbShop.Size = new System.Drawing.Size(120, 21);
            this.cbShop.TabIndex = 82;
            this.cbShop.SelectedIndexChanged += new System.EventHandler(this.cbPosNo_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(733, 269);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.TabIndex = 88;
            this.btnDelete.Text = "연결해제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLink
            // 
            this.btnLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLink.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLink.ForeColor = System.Drawing.Color.White;
            this.btnLink.Location = new System.Drawing.Point(733, 223);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(120, 40);
            this.btnLink.TabIndex = 106;
            this.btnLink.Text = "상품연결";
            this.btnLink.UseVisualStyleBackColor = false;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnView);
            this.groupBox2.Controls.Add(this.cbGroup);
            this.groupBox2.Controls.Add(this.lblGroupTitle);
            this.groupBox2.Controls.Add(this.cbShop);
            this.groupBox2.Controls.Add(this.lblPosNoTitle);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(728, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 155);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnView.Location = new System.Drawing.Point(6, 112);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(120, 30);
            this.btnView.TabIndex = 99;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // cbGroup
            // 
            this.cbGroup.BackColor = System.Drawing.Color.White;
            this.cbGroup.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(6, 79);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(120, 21);
            this.cbGroup.TabIndex = 61;
            // 
            // lblGroupTitle
            // 
            this.lblGroupTitle.AutoSize = true;
            this.lblGroupTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGroupTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGroupTitle.Location = new System.Drawing.Point(8, 63);
            this.lblGroupTitle.Name = "lblGroupTitle";
            this.lblGroupTitle.Size = new System.Drawing.Size(35, 14);
            this.lblGroupTitle.TabIndex = 97;
            this.lblGroupTitle.Text = "그룹";
            // 
            // lblPosNoTitle
            // 
            this.lblPosNoTitle.AutoSize = true;
            this.lblPosNoTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPosNoTitle.Location = new System.Drawing.Point(7, 16);
            this.lblPosNoTitle.Name = "lblPosNoTitle";
            this.lblPosNoTitle.Size = new System.Drawing.Size(63, 14);
            this.lblPosNoTitle.TabIndex = 97;
            this.lblPosNoTitle.Text = "포스업장";
            // 
            // shop
            // 
            this.shop.Text = "업장";
            // 
            // lvwGoodsLink
            // 
            this.lvwGoodsLink.BackColor = System.Drawing.SystemColors.Window;
            this.lvwGoodsLink.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.name,
            this.amt});
            this.lvwGoodsLink.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwGoodsLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwGoodsLink.FullRowSelect = true;
            this.lvwGoodsLink.GridLines = true;
            this.lvwGoodsLink.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwGoodsLink.HideSelection = false;
            this.lvwGoodsLink.Location = new System.Drawing.Point(401, 55);
            this.lvwGoodsLink.MultiSelect = false;
            this.lvwGoodsLink.Name = "lvwGoodsLink";
            this.lvwGoodsLink.Size = new System.Drawing.Size(286, 643);
            this.lvwGoodsLink.TabIndex = 101;
            this.lvwGoodsLink.TabStop = false;
            this.lvwGoodsLink.UseCompatibleStateImageBehavior = false;
            this.lvwGoodsLink.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#";
            this.no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.no.Width = 45;
            // 
            // name
            // 
            this.name.Text = "상품명";
            this.name.Width = 160;
            // 
            // amt
            // 
            this.amt.Text = "단가";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt.Width = 50;
            // 
            // lvwGoods
            // 
            this.lvwGoods.BackColor = System.Drawing.SystemColors.Window;
            this.lvwGoods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.item_name,
            this.amt1,
            this.shop,
            this.nod1});
            this.lvwGoods.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwGoods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwGoods.FullRowSelect = true;
            this.lvwGoods.GridLines = true;
            this.lvwGoods.HideSelection = false;
            this.lvwGoods.Location = new System.Drawing.Point(14, 55);
            this.lvwGoods.MultiSelect = false;
            this.lvwGoods.Name = "lvwGoods";
            this.lvwGoods.Size = new System.Drawing.Size(381, 643);
            this.lvwGoods.TabIndex = 104;
            this.lvwGoods.TabStop = false;
            this.lvwGoods.UseCompatibleStateImageBehavior = false;
            this.lvwGoods.View = System.Windows.Forms.View.Details;
            this.lvwGoods.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwGoods_ColumnClick);
            // 
            // item_name
            // 
            this.item_name.Text = "상품명▲▼";
            this.item_name.Width = 160;
            // 
            // amt1
            // 
            this.amt1.Text = "단가";
            this.amt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt1.Width = 50;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(409, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(116, 14);
            this.lblTitle.TabIndex = 103;
            this.lblTitle.Text = "상품배치(KIOSK)";
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.White;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUp.Location = new System.Drawing.Point(693, 612);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 40);
            this.btnUp.TabIndex = 112;
            this.btnUp.TabStop = false;
            this.btnUp.Text = "▲";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDn
            // 
            this.btnDn.BackColor = System.Drawing.Color.White;
            this.btnDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDn.Location = new System.Drawing.Point(693, 658);
            this.btnDn.Name = "btnDn";
            this.btnDn.Size = new System.Drawing.Size(40, 40);
            this.btnDn.TabIndex = 111;
            this.btnDn.TabStop = false;
            this.btnDn.Text = "▼";
            this.btnDn.UseVisualStyleBackColor = false;
            this.btnDn.Click += new System.EventHandler(this.btnDn_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(733, 339);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 50);
            this.btnSave.TabIndex = 113;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "순번저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShopView
            // 
            this.btnShopView.BackColor = System.Drawing.Color.White;
            this.btnShopView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShopView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnShopView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnShopView.Location = new System.Drawing.Point(203, 13);
            this.btnShopView.Name = "btnShopView";
            this.btnShopView.Size = new System.Drawing.Size(100, 29);
            this.btnShopView.TabIndex = 115;
            this.btnShopView.Text = "조회";
            this.btnShopView.UseVisualStyleBackColor = false;
            this.btnShopView.Click += new System.EventHandler(this.btnShopView_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbShopView);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(14, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 30);
            this.panel1.TabIndex = 114;
            // 
            // cbShopView
            // 
            this.cbShopView.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbShopView.FormattingEnabled = true;
            this.cbShopView.Location = new System.Drawing.Point(49, 3);
            this.cbShopView.Name = "cbShopView";
            this.cbShopView.Size = new System.Drawing.Size(124, 23);
            this.cbShopView.TabIndex = 79;
            this.cbShopView.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.label4.Location = new System.Drawing.Point(6, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 78;
            this.label4.Text = "업장";
            // 
            // frmSysGoodsItemKiosk
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.btnShopView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDn);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lvwGoodsLink);
            this.Controls.Add(this.lvwGoods);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysGoodsItemKiosk";
            this.Text = "frmSysGoodsItem2";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader nod1;
        private System.Windows.Forms.ComboBox cbShop;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.Label lblGroupTitle;
        private System.Windows.Forms.Label lblPosNoTitle;
        private System.Windows.Forms.ColumnHeader shop;
        private System.Windows.Forms.ListView lvwGoodsLink;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ListView lvwGoods;
        private System.Windows.Forms.ColumnHeader item_name;
        private System.Windows.Forms.ColumnHeader amt1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnShopView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbShopView;
        private System.Windows.Forms.Label label4;
    }
}