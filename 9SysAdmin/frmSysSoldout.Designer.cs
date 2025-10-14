namespace thepos._9SysAdmin
{
    partial class frmSysSoldout
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
            this.lblGoodsTitle = new System.Windows.Forms.Label();
            this.lvwGoodsList = new System.Windows.Forms.ListView();
            this.shop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_soldout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_cutout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbGoodsCutout = new System.Windows.Forms.CheckBox();
            this.btnGoodsUpdate = new System.Windows.Forms.Button();
            this.cbGoodsSoldout = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbGroupCutout = new System.Windows.Forms.CheckBox();
            this.cbGroupSoldout = new System.Windows.Forms.CheckBox();
            this.btnGroupUpdate = new System.Windows.Forms.Button();
            this.lvwGroupList = new System.Windows.Forms.ListView();
            this.group_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_group_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_group_soldout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_group_cutout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroupTitle = new System.Windows.Forms.Label();
            this.btnViewGoods = new System.Windows.Forms.Button();
            this.btnViewGroup = new System.Windows.Forms.Button();
            this.lblPosNo = new System.Windows.Forms.Label();
            this.cbPosGroup = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbShop = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGoodsTitle
            // 
            this.lblGoodsTitle.AutoSize = true;
            this.lblGoodsTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGoodsTitle.Location = new System.Drawing.Point(15, 28);
            this.lblGoodsTitle.Name = "lblGoodsTitle";
            this.lblGoodsTitle.Size = new System.Drawing.Size(35, 14);
            this.lblGoodsTitle.TabIndex = 50;
            this.lblGoodsTitle.Text = "상품";
            // 
            // lvwGoodsList
            // 
            this.lvwGoodsList.BackColor = System.Drawing.SystemColors.Window;
            this.lvwGoodsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.shop,
            this.name,
            this.goods_amt,
            this.goods_soldout,
            this.goods_cutout});
            this.lvwGoodsList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwGoodsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwGoodsList.FullRowSelect = true;
            this.lvwGoodsList.GridLines = true;
            this.lvwGoodsList.HideSelection = false;
            this.lvwGoodsList.Location = new System.Drawing.Point(25, 86);
            this.lvwGoodsList.MultiSelect = false;
            this.lvwGoodsList.Name = "lvwGoodsList";
            this.lvwGoodsList.Size = new System.Drawing.Size(446, 445);
            this.lvwGoodsList.TabIndex = 51;
            this.lvwGoodsList.TabStop = false;
            this.lvwGoodsList.UseCompatibleStateImageBehavior = false;
            this.lvwGoodsList.View = System.Windows.Forms.View.Details;
            this.lvwGoodsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwGoodsList_ColumnClick);
            this.lvwGoodsList.SelectedIndexChanged += new System.EventHandler(this.lvwGoodsList_SelectedIndexChanged);
            // 
            // shop
            // 
            this.shop.Text = "업장";
            this.shop.Width = 80;
            // 
            // name
            // 
            this.name.Text = "상품명▲▼";
            this.name.Width = 160;
            // 
            // goods_amt
            // 
            this.goods_amt.Text = "단가";
            this.goods_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.goods_amt.Width = 70;
            // 
            // goods_soldout
            // 
            this.goods_soldout.Text = "품절";
            this.goods_soldout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.goods_soldout.Width = 50;
            // 
            // goods_cutout
            // 
            this.goods_cutout.Text = "절판";
            this.goods_cutout.Width = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbGoodsCutout);
            this.groupBox1.Controls.Add(this.btnGoodsUpdate);
            this.groupBox1.Controls.Add(this.cbGoodsSoldout);
            this.groupBox1.Location = new System.Drawing.Point(25, 536);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 101);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // cbGoodsCutout
            // 
            this.cbGoodsCutout.AutoSize = true;
            this.cbGoodsCutout.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbGoodsCutout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.cbGoodsCutout.Location = new System.Drawing.Point(155, 48);
            this.cbGoodsCutout.Name = "cbGoodsCutout";
            this.cbGoodsCutout.Size = new System.Drawing.Size(54, 18);
            this.cbGoodsCutout.TabIndex = 58;
            this.cbGoodsCutout.TabStop = false;
            this.cbGoodsCutout.Text = "절판";
            this.cbGoodsCutout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbGoodsCutout.UseVisualStyleBackColor = true;
            // 
            // btnGoodsUpdate
            // 
            this.btnGoodsUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGoodsUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoodsUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGoodsUpdate.ForeColor = System.Drawing.Color.White;
            this.btnGoodsUpdate.Location = new System.Drawing.Point(255, 36);
            this.btnGoodsUpdate.Name = "btnGoodsUpdate";
            this.btnGoodsUpdate.Size = new System.Drawing.Size(120, 40);
            this.btnGoodsUpdate.TabIndex = 56;
            this.btnGoodsUpdate.TabStop = false;
            this.btnGoodsUpdate.Text = "상품수정";
            this.btnGoodsUpdate.UseVisualStyleBackColor = false;
            this.btnGoodsUpdate.Click += new System.EventHandler(this.btnGoodsUpdate_Click);
            // 
            // cbGoodsSoldout
            // 
            this.cbGoodsSoldout.AutoSize = true;
            this.cbGoodsSoldout.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbGoodsSoldout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.cbGoodsSoldout.Location = new System.Drawing.Point(78, 48);
            this.cbGoodsSoldout.Name = "cbGoodsSoldout";
            this.cbGoodsSoldout.Size = new System.Drawing.Size(54, 18);
            this.cbGoodsSoldout.TabIndex = 55;
            this.cbGoodsSoldout.TabStop = false;
            this.cbGoodsSoldout.Text = "품절";
            this.cbGoodsSoldout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbGoodsSoldout.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbGroupCutout);
            this.groupBox3.Controls.Add(this.cbGroupSoldout);
            this.groupBox3.Controls.Add(this.btnGroupUpdate);
            this.groupBox3.Location = new System.Drawing.Point(498, 536);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 101);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            // 
            // cbGroupCutout
            // 
            this.cbGroupCutout.AutoSize = true;
            this.cbGroupCutout.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbGroupCutout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.cbGroupCutout.Location = new System.Drawing.Point(110, 48);
            this.cbGroupCutout.Name = "cbGroupCutout";
            this.cbGroupCutout.Size = new System.Drawing.Size(54, 18);
            this.cbGroupCutout.TabIndex = 57;
            this.cbGroupCutout.TabStop = false;
            this.cbGroupCutout.Text = "절판";
            this.cbGroupCutout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbGroupCutout.UseVisualStyleBackColor = true;
            // 
            // cbGroupSoldout
            // 
            this.cbGroupSoldout.AutoSize = true;
            this.cbGroupSoldout.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbGroupSoldout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.cbGroupSoldout.Location = new System.Drawing.Point(37, 48);
            this.cbGroupSoldout.Name = "cbGroupSoldout";
            this.cbGroupSoldout.Size = new System.Drawing.Size(54, 18);
            this.cbGroupSoldout.TabIndex = 56;
            this.cbGroupSoldout.TabStop = false;
            this.cbGroupSoldout.Text = "품절";
            this.cbGroupSoldout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbGroupSoldout.UseVisualStyleBackColor = true;
            // 
            // btnGroupUpdate
            // 
            this.btnGroupUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGroupUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroupUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGroupUpdate.ForeColor = System.Drawing.Color.White;
            this.btnGroupUpdate.Location = new System.Drawing.Point(190, 36);
            this.btnGroupUpdate.Name = "btnGroupUpdate";
            this.btnGroupUpdate.Size = new System.Drawing.Size(120, 40);
            this.btnGroupUpdate.TabIndex = 39;
            this.btnGroupUpdate.TabStop = false;
            this.btnGroupUpdate.Text = "그룹수정";
            this.btnGroupUpdate.UseVisualStyleBackColor = false;
            this.btnGroupUpdate.Click += new System.EventHandler(this.btnGroupUpdate_Click);
            // 
            // lvwGroupList
            // 
            this.lvwGroupList.BackColor = System.Drawing.Color.White;
            this.lvwGroupList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.group_code,
            this.goods_group_name,
            this.goods_group_soldout,
            this.goods_group_cutout});
            this.lvwGroupList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwGroupList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwGroupList.FullRowSelect = true;
            this.lvwGroupList.GridLines = true;
            this.lvwGroupList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwGroupList.HideSelection = false;
            this.lvwGroupList.Location = new System.Drawing.Point(498, 86);
            this.lvwGroupList.MultiSelect = false;
            this.lvwGroupList.Name = "lvwGroupList";
            this.lvwGroupList.Size = new System.Drawing.Size(330, 445);
            this.lvwGroupList.TabIndex = 65;
            this.lvwGroupList.TabStop = false;
            this.lvwGroupList.UseCompatibleStateImageBehavior = false;
            this.lvwGroupList.View = System.Windows.Forms.View.Details;
            this.lvwGroupList.SelectedIndexChanged += new System.EventHandler(this.lvwGroupList_SelectedIndexChanged);
            // 
            // group_code
            // 
            this.group_code.Text = "포스그룹";
            this.group_code.Width = 70;
            // 
            // goods_group_name
            // 
            this.goods_group_name.Text = "상품그룹명";
            this.goods_group_name.Width = 140;
            // 
            // goods_group_soldout
            // 
            this.goods_group_soldout.Text = "품절";
            this.goods_group_soldout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.goods_group_soldout.Width = 50;
            // 
            // goods_group_cutout
            // 
            this.goods_group_cutout.Text = "절판";
            this.goods_group_cutout.Width = 50;
            // 
            // lblGroupTitle
            // 
            this.lblGroupTitle.AutoSize = true;
            this.lblGroupTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGroupTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGroupTitle.Location = new System.Drawing.Point(12, 29);
            this.lblGroupTitle.Name = "lblGroupTitle";
            this.lblGroupTitle.Size = new System.Drawing.Size(35, 14);
            this.lblGroupTitle.TabIndex = 68;
            this.lblGroupTitle.Text = "그룹";
            // 
            // btnViewGoods
            // 
            this.btnViewGoods.BackColor = System.Drawing.Color.White;
            this.btnViewGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewGoods.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewGoods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnViewGoods.Location = new System.Drawing.Point(324, 21);
            this.btnViewGoods.Name = "btnViewGoods";
            this.btnViewGoods.Size = new System.Drawing.Size(86, 30);
            this.btnViewGoods.TabIndex = 84;
            this.btnViewGoods.TabStop = false;
            this.btnViewGoods.Text = "조회";
            this.btnViewGoods.UseVisualStyleBackColor = false;
            this.btnViewGoods.Click += new System.EventHandler(this.btnViewGoods_Click);
            // 
            // btnViewGroup
            // 
            this.btnViewGroup.BackColor = System.Drawing.Color.White;
            this.btnViewGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewGroup.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnViewGroup.Location = new System.Drawing.Point(224, 21);
            this.btnViewGroup.Name = "btnViewGroup";
            this.btnViewGroup.Size = new System.Drawing.Size(86, 30);
            this.btnViewGroup.TabIndex = 85;
            this.btnViewGroup.TabStop = false;
            this.btnViewGroup.Text = "조회";
            this.btnViewGroup.UseVisualStyleBackColor = false;
            this.btnViewGroup.Click += new System.EventHandler(this.btnViewGroup_Click);
            // 
            // lblPosNo
            // 
            this.lblPosNo.AutoSize = true;
            this.lblPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPosNo.Location = new System.Drawing.Point(73, 29);
            this.lblPosNo.Name = "lblPosNo";
            this.lblPosNo.Size = new System.Drawing.Size(63, 14);
            this.lblPosNo.TabIndex = 86;
            this.lblPosNo.Text = "포스그룹";
            // 
            // cbPosGroup
            // 
            this.cbPosGroup.BackColor = System.Drawing.Color.White;
            this.cbPosGroup.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPosGroup.FormattingEnabled = true;
            this.cbPosGroup.Location = new System.Drawing.Point(139, 25);
            this.cbPosGroup.Name = "cbPosGroup";
            this.cbPosGroup.Size = new System.Drawing.Size(79, 21);
            this.cbPosGroup.TabIndex = 87;
            this.cbPosGroup.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbShop);
            this.groupBox2.Controls.Add(this.lblGoodsTitle);
            this.groupBox2.Controls.Add(this.btnViewGoods);
            this.groupBox2.Location = new System.Drawing.Point(25, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 64);
            this.groupBox2.TabIndex = 88;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(174, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 88;
            this.label3.Text = "업장";
            // 
            // cbShop
            // 
            this.cbShop.BackColor = System.Drawing.Color.White;
            this.cbShop.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbShop.FormattingEnabled = true;
            this.cbShop.Location = new System.Drawing.Point(214, 24);
            this.cbShop.Name = "cbShop";
            this.cbShop.Size = new System.Drawing.Size(98, 21);
            this.cbShop.TabIndex = 89;
            this.cbShop.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnViewGroup);
            this.groupBox4.Controls.Add(this.lblGroupTitle);
            this.groupBox4.Controls.Add(this.lblPosNo);
            this.groupBox4.Controls.Add(this.cbPosGroup);
            this.groupBox4.Location = new System.Drawing.Point(498, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(330, 64);
            this.groupBox4.TabIndex = 89;
            this.groupBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(290, 650);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 42);
            this.label1.TabIndex = 90;
            this.label1.Text = "[품절]\r\n포스기기 : Disable\r\n키오스크 : Disable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(463, 650);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 42);
            this.label2.TabIndex = 90;
            this.label2.Text = "[절판]\r\n포스기기 : Disable\r\n키오스크 : Invisible";
            // 
            // frmSysSoldout
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lvwGroupList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwGoodsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysSoldout";
            this.Text = "frmSoldout";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGoodsTitle;
        private System.Windows.Forms.ListView lvwGoodsList;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader goods_soldout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbGoodsSoldout;
        private System.Windows.Forms.ColumnHeader goods_amt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGroupUpdate;
        private System.Windows.Forms.ListView lvwGroupList;
        private System.Windows.Forms.ColumnHeader goods_group_name;
        private System.Windows.Forms.ColumnHeader goods_group_soldout;
        private System.Windows.Forms.Label lblGroupTitle;
        private System.Windows.Forms.Button btnGoodsUpdate;
        private System.Windows.Forms.CheckBox cbGroupSoldout;
        private System.Windows.Forms.ColumnHeader group_code;
        private System.Windows.Forms.ColumnHeader shop;
        private System.Windows.Forms.ColumnHeader goods_cutout;
        private System.Windows.Forms.ColumnHeader goods_group_cutout;
        private System.Windows.Forms.CheckBox cbGoodsCutout;
        private System.Windows.Forms.CheckBox cbGroupCutout;
        private System.Windows.Forms.Button btnViewGoods;
        private System.Windows.Forms.Button btnViewGroup;
        private System.Windows.Forms.Label lblPosNo;
        private System.Windows.Forms.ComboBox cbPosGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbShop;
    }
}