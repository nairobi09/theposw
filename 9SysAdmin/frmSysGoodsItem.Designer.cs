﻿namespace thepos
{
    partial class frmSysGoodsItem
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
            this.lvwGoodsLink = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.X = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Y = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.W = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.H = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_color = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanelItemSelected = new System.Windows.Forms.TableLayoutPanel();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblT5 = new System.Windows.Forms.Label();
            this.tbLocateX = new System.Windows.Forms.TextBox();
            this.tbLocateY = new System.Windows.Forms.TextBox();
            this.tbSizeX = new System.Windows.Forms.TextBox();
            this.tbSizeY = new System.Windows.Forms.TextBox();
            this.lvwGoods = new System.Windows.Forms.ListView();
            this.item_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nod1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbPosNo = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelItem = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLink = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbColor = new System.Windows.Forms.TextBox();
            this.lblT6 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblPosNoTitle = new System.Windows.Forms.Label();
            this.lblGroupTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cbSourceGroup = new System.Windows.Forms.ComboBox();
            this.lblCopyGroupTitle = new System.Windows.Forms.Label();
            this.cbSourcePosNo = new System.Windows.Forms.ComboBox();
            this.lblCopyPosNoTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbShopView = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnShopView = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwGoodsLink
            // 
            this.lvwGoodsLink.BackColor = System.Drawing.SystemColors.Window;
            this.lvwGoodsLink.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.amt,
            this.X,
            this.Y,
            this.W,
            this.H,
            this.btn_color});
            this.lvwGoodsLink.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwGoodsLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwGoodsLink.FullRowSelect = true;
            this.lvwGoodsLink.GridLines = true;
            this.lvwGoodsLink.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwGoodsLink.HideSelection = false;
            this.lvwGoodsLink.Location = new System.Drawing.Point(347, 55);
            this.lvwGoodsLink.MultiSelect = false;
            this.lvwGoodsLink.Name = "lvwGoodsLink";
            this.lvwGoodsLink.Size = new System.Drawing.Size(388, 333);
            this.lvwGoodsLink.TabIndex = 43;
            this.lvwGoodsLink.TabStop = false;
            this.lvwGoodsLink.UseCompatibleStateImageBehavior = false;
            this.lvwGoodsLink.View = System.Windows.Forms.View.Details;
            this.lvwGoodsLink.SelectedIndexChanged += new System.EventHandler(this.lvwGoodsLink_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "상품명";
            this.name.Width = 120;
            // 
            // amt
            // 
            this.amt.Text = "단가";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt.Width = 50;
            // 
            // X
            // 
            this.X.Text = "X";
            this.X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.X.Width = 30;
            // 
            // Y
            // 
            this.Y.Text = "Y";
            this.Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Y.Width = 30;
            // 
            // W
            // 
            this.W.Text = "W";
            this.W.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.W.Width = 30;
            // 
            // H
            // 
            this.H.Text = "H";
            this.H.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.H.Width = 30;
            // 
            // btn_color
            // 
            this.btn_color.Text = "Color";
            this.btn_color.Width = 70;
            // 
            // tableLayoutPanelItemSelected
            // 
            this.tableLayoutPanelItemSelected.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelItemSelected.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelItemSelected.ColumnCount = 8;
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelItemSelected.Location = new System.Drawing.Point(378, 398);
            this.tableLayoutPanelItemSelected.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelItemSelected.Name = "tableLayoutPanelItemSelected";
            this.tableLayoutPanelItemSelected.RowCount = 8;
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.Size = new System.Drawing.Size(357, 299);
            this.tableLayoutPanelItemSelected.TabIndex = 60;
            // 
            // cbGroup
            // 
            this.cbGroup.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(6, 79);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(105, 21);
            this.cbGroup.TabIndex = 61;
            this.cbGroup.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(457, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(107, 14);
            this.lblTitle.TabIndex = 62;
            this.lblTitle.Text = "상품배치(POS)";
            // 
            // lblT5
            // 
            this.lblT5.AutoSize = true;
            this.lblT5.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblT5.Location = new System.Drawing.Point(8, 28);
            this.lblT5.Name = "lblT5";
            this.lblT5.Size = new System.Drawing.Size(23, 13);
            this.lblT5.TabIndex = 70;
            this.lblT5.Text = "XY";
            // 
            // tbLocateX
            // 
            this.tbLocateX.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLocateX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbLocateX.Location = new System.Drawing.Point(38, 21);
            this.tbLocateX.MaxLength = 1;
            this.tbLocateX.Name = "tbLocateX";
            this.tbLocateX.Size = new System.Drawing.Size(31, 23);
            this.tbLocateX.TabIndex = 0;
            // 
            // tbLocateY
            // 
            this.tbLocateY.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLocateY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbLocateY.Location = new System.Drawing.Point(73, 21);
            this.tbLocateY.MaxLength = 1;
            this.tbLocateY.Name = "tbLocateY";
            this.tbLocateY.Size = new System.Drawing.Size(31, 23);
            this.tbLocateY.TabIndex = 1;
            // 
            // tbSizeX
            // 
            this.tbSizeX.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSizeX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSizeX.Location = new System.Drawing.Point(38, 50);
            this.tbSizeX.MaxLength = 1;
            this.tbSizeX.Name = "tbSizeX";
            this.tbSizeX.Size = new System.Drawing.Size(31, 23);
            this.tbSizeX.TabIndex = 2;
            // 
            // tbSizeY
            // 
            this.tbSizeY.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSizeY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSizeY.Location = new System.Drawing.Point(73, 50);
            this.tbSizeY.MaxLength = 1;
            this.tbSizeY.Name = "tbSizeY";
            this.tbSizeY.Size = new System.Drawing.Size(31, 23);
            this.tbSizeY.TabIndex = 3;
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
            this.lvwGoods.FullRowSelect = true;
            this.lvwGoods.GridLines = true;
            this.lvwGoods.HideSelection = false;
            this.lvwGoods.Location = new System.Drawing.Point(14, 55);
            this.lvwGoods.MultiSelect = false;
            this.lvwGoods.Name = "lvwGoods";
            this.lvwGoods.Size = new System.Drawing.Size(320, 333);
            this.lvwGoods.TabIndex = 80;
            this.lvwGoods.TabStop = false;
            this.lvwGoods.UseCompatibleStateImageBehavior = false;
            this.lvwGoods.View = System.Windows.Forms.View.Details;
            this.lvwGoods.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwGoods_ColumnClick);
            // 
            // item_name
            // 
            this.item_name.Text = "상품명";
            this.item_name.Width = 120;
            // 
            // amt1
            // 
            this.amt1.Text = "단가";
            this.amt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt1.Width = 50;
            // 
            // shop
            // 
            this.shop.Text = "업장";
            // 
            // nod1
            // 
            this.nod1.Text = "분류1";
            // 
            // cbPosNo
            // 
            this.cbPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPosNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbPosNo.FormattingEnabled = true;
            this.cbPosNo.Location = new System.Drawing.Point(6, 32);
            this.cbPosNo.Name = "cbPosNo";
            this.cbPosNo.Size = new System.Drawing.Size(105, 21);
            this.cbPosNo.TabIndex = 82;
            this.cbPosNo.TabStop = false;
            this.cbPosNo.SelectedIndexChanged += new System.EventHandler(this.comboPosNo_SelectedIndexChanged);
            // 
            // tableLayoutPanelItem
            // 
            this.tableLayoutPanelItem.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelItem.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelItem.ColumnCount = 8;
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelItem.Location = new System.Drawing.Point(14, 398);
            this.tableLayoutPanelItem.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelItem.Name = "tableLayoutPanelItem";
            this.tableLayoutPanelItem.RowCount = 8;
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.Size = new System.Drawing.Size(357, 299);
            this.tableLayoutPanelItem.TabIndex = 84;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(6, 201);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 25);
            this.btnDelete.TabIndex = 88;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(7, 160);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 35);
            this.btnUpdate.TabIndex = 89;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLink
            // 
            this.btnLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLink.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLink.ForeColor = System.Drawing.Color.White;
            this.btnLink.Location = new System.Drawing.Point(748, 203);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(105, 30);
            this.btnLink.TabIndex = 90;
            this.btnLink.TabStop = false;
            this.btnLink.Text = "상품연결";
            this.btnLink.UseVisualStyleBackColor = false;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnColor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbColor);
            this.groupBox1.Controls.Add(this.tbLocateX);
            this.groupBox1.Controls.Add(this.lblT6);
            this.groupBox1.Controls.Add(this.lblT5);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.tbSizeY);
            this.groupBox1.Controls.Add(this.tbSizeX);
            this.groupBox1.Controls.Add(this.tbLocateY);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(743, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 243);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.White;
            this.btnColor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(73, 115);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(31, 23);
            this.btnColor.TabIndex = 92;
            this.btnColor.TabStop = false;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(1, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 91;
            this.label1.Text = "color";
            // 
            // tbColor
            // 
            this.tbColor.BackColor = System.Drawing.Color.White;
            this.tbColor.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbColor.Location = new System.Drawing.Point(36, 89);
            this.tbColor.MaxLength = 8;
            this.tbColor.Name = "tbColor";
            this.tbColor.Size = new System.Drawing.Size(68, 23);
            this.tbColor.TabIndex = 4;
            this.tbColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbColor_KeyDown);
            // 
            // lblT6
            // 
            this.lblT6.AutoSize = true;
            this.lblT6.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblT6.Location = new System.Drawing.Point(7, 57);
            this.lblT6.Name = "lblT6";
            this.lblT6.Size = new System.Drawing.Size(28, 13);
            this.lblT6.TabIndex = 70;
            this.lblT6.Text = "WH";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.White;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnApply.Location = new System.Drawing.Point(750, 494);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(105, 30);
            this.btnApply.TabIndex = 95;
            this.btnApply.TabStop = false;
            this.btnApply.Text = "적용보기";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblPosNoTitle
            // 
            this.lblPosNoTitle.AutoSize = true;
            this.lblPosNoTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPosNoTitle.Location = new System.Drawing.Point(7, 16);
            this.lblPosNoTitle.Name = "lblPosNoTitle";
            this.lblPosNoTitle.Size = new System.Drawing.Size(35, 14);
            this.lblPosNoTitle.TabIndex = 97;
            this.lblPosNoTitle.Text = "포스";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnView);
            this.groupBox2.Controls.Add(this.cbGroup);
            this.groupBox2.Controls.Add(this.lblGroupTitle);
            this.groupBox2.Controls.Add(this.cbPosNo);
            this.groupBox2.Controls.Add(this.lblPosNoTitle);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(743, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 150);
            this.groupBox2.TabIndex = 98;
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
            this.btnView.Size = new System.Drawing.Size(105, 30);
            this.btnView.TabIndex = 99;
            this.btnView.TabStop = false;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCopy);
            this.groupBox3.Controls.Add(this.cbSourceGroup);
            this.groupBox3.Controls.Add(this.lblCopyGroupTitle);
            this.groupBox3.Controls.Add(this.cbSourcePosNo);
            this.groupBox3.Controls.Add(this.lblCopyPosNoTitle);
            this.groupBox3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(743, 543);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(118, 150);
            this.groupBox3.TabIndex = 100;
            this.groupBox3.TabStop = false;
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopy.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Location = new System.Drawing.Point(6, 114);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(105, 30);
            this.btnCopy.TabIndex = 99;
            this.btnCopy.TabStop = false;
            this.btnCopy.Text = "그룹복사";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbSourceGroup
            // 
            this.cbSourceGroup.BackColor = System.Drawing.Color.White;
            this.cbSourceGroup.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbSourceGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbSourceGroup.FormattingEnabled = true;
            this.cbSourceGroup.Location = new System.Drawing.Point(6, 82);
            this.cbSourceGroup.Name = "cbSourceGroup";
            this.cbSourceGroup.Size = new System.Drawing.Size(105, 21);
            this.cbSourceGroup.TabIndex = 61;
            this.cbSourceGroup.TabStop = false;
            // 
            // lblCopyGroupTitle
            // 
            this.lblCopyGroupTitle.AutoSize = true;
            this.lblCopyGroupTitle.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCopyGroupTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCopyGroupTitle.Location = new System.Drawing.Point(8, 64);
            this.lblCopyGroupTitle.Name = "lblCopyGroupTitle";
            this.lblCopyGroupTitle.Size = new System.Drawing.Size(59, 13);
            this.lblCopyGroupTitle.TabIndex = 97;
            this.lblCopyGroupTitle.Text = "소스그룹";
            // 
            // cbSourcePosNo
            // 
            this.cbSourcePosNo.BackColor = System.Drawing.Color.White;
            this.cbSourcePosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbSourcePosNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbSourcePosNo.FormattingEnabled = true;
            this.cbSourcePosNo.Location = new System.Drawing.Point(6, 36);
            this.cbSourcePosNo.Name = "cbSourcePosNo";
            this.cbSourcePosNo.Size = new System.Drawing.Size(105, 21);
            this.cbSourcePosNo.TabIndex = 82;
            this.cbSourcePosNo.TabStop = false;
            this.cbSourcePosNo.SelectedIndexChanged += new System.EventHandler(this.cbSourcePosNo_SelectedIndexChanged);
            // 
            // lblCopyPosNoTitle
            // 
            this.lblCopyPosNoTitle.AutoSize = true;
            this.lblCopyPosNoTitle.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCopyPosNoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCopyPosNoTitle.Location = new System.Drawing.Point(8, 18);
            this.lblCopyPosNoTitle.Name = "lblCopyPosNoTitle";
            this.lblCopyPosNoTitle.Size = new System.Drawing.Size(59, 13);
            this.lblCopyPosNoTitle.TabIndex = 97;
            this.lblCopyPosNoTitle.Text = "소스포스";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbShopView);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(18, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 30);
            this.panel1.TabIndex = 101;
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
            // btnShopView
            // 
            this.btnShopView.BackColor = System.Drawing.Color.White;
            this.btnShopView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShopView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnShopView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnShopView.Location = new System.Drawing.Point(207, 15);
            this.btnShopView.Name = "btnShopView";
            this.btnShopView.Size = new System.Drawing.Size(100, 29);
            this.btnShopView.TabIndex = 102;
            this.btnShopView.TabStop = false;
            this.btnShopView.Text = "조회";
            this.btnShopView.UseVisualStyleBackColor = false;
            this.btnShopView.Click += new System.EventHandler(this.btnShopView_Click);
            // 
            // frmSysGoodsItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.btnShopView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvwGoodsLink);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanelItem);
            this.Controls.Add(this.lvwGoods);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tableLayoutPanelItemSelected);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysGoodsItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "상품등록";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvwGoodsLink;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader X;
        private System.Windows.Forms.ColumnHeader Y;
        private System.Windows.Forms.ColumnHeader W;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelItemSelected;
        private System.Windows.Forms.ColumnHeader H;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblT5;
        private System.Windows.Forms.TextBox tbLocateX;
        private System.Windows.Forms.TextBox tbLocateY;
        private System.Windows.Forms.TextBox tbSizeX;
        private System.Windows.Forms.TextBox tbSizeY;
        private System.Windows.Forms.ListView lvwGoods;
        private System.Windows.Forms.ColumnHeader item_name;
        private System.Windows.Forms.ColumnHeader amt1;
        private System.Windows.Forms.ColumnHeader nod1;
        private System.Windows.Forms.ComboBox cbPosNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblT6;
        private System.Windows.Forms.Label lblPosNoTitle;
        private System.Windows.Forms.Label lblGroupTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ComboBox cbSourceGroup;
        private System.Windows.Forms.Label lblCopyGroupTitle;
        private System.Windows.Forms.ComboBox cbSourcePosNo;
        private System.Windows.Forms.Label lblCopyPosNoTitle;
        private System.Windows.Forms.ColumnHeader shop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbShopView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnShopView;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ColumnHeader btn_color;
    }
}