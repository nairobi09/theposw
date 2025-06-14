﻿namespace thepos
{
    partial class frmSysGoodsGroup
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
            this.tableLayoutPanelGroup = new System.Windows.Forms.TableLayoutPanel();
            this.lvwList = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name_en = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name_jp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.szX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.szY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_color = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroupNameTitle = new System.Windows.Forms.Label();
            this.lblLocYTitle = new System.Windows.Forms.Label();
            this.lblSzXTitle = new System.Windows.Forms.Label();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.tbLocateX = new System.Windows.Forms.TextBox();
            this.tbLocateY = new System.Windows.Forms.TextBox();
            this.tbSizeX = new System.Windows.Forms.TextBox();
            this.tbSizeY = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelGroupSelected = new System.Windows.Forms.TableLayoutPanel();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblT6 = new System.Windows.Forms.Label();
            this.lblT5 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbColor = new System.Windows.Forms.TextBox();
            this.tbGroupNameJP = new System.Windows.Forms.TextBox();
            this.lblGroupNameTitleJP = new System.Windows.Forms.Label();
            this.tbGroupNameCH = new System.Windows.Forms.TextBox();
            this.lblGroupNameTitleCH = new System.Windows.Forms.Label();
            this.tbGroupNameEN = new System.Windows.Forms.TextBox();
            this.lblGroupNameTitleEN = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.comboPosNo = new System.Windows.Forms.ComboBox();
            this.lblPosNo = new System.Windows.Forms.Label();
            this.btnViewPosNo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelGroup
            // 
            this.tableLayoutPanelGroup.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelGroup.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelGroup.ColumnCount = 8;
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanelGroup.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelGroup.Location = new System.Drawing.Point(81, 547);
            this.tableLayoutPanelGroup.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelGroup.Name = "tableLayoutPanelGroup";
            this.tableLayoutPanelGroup.RowCount = 2;
            this.tableLayoutPanelGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGroup.Size = new System.Drawing.Size(521, 130);
            this.tableLayoutPanelGroup.TabIndex = 1;
            // 
            // lvwList
            // 
            this.lvwList.BackColor = System.Drawing.Color.White;
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.code,
            this.name_en,
            this.name_ch,
            this.name_jp,
            this.locX,
            this.locY,
            this.szX,
            this.szY,
            this.btn_color});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(26, 58);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(576, 303);
            this.lvwList.TabIndex = 38;
            this.lvwList.TabStop = false;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwGoodsGroup_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "그룹명";
            this.name.Width = 110;
            // 
            // name_en
            // 
            this.name_en.Text = "(영문)";
            // 
            // name_ch
            // 
            this.name_ch.Text = "(중문)";
            // 
            // name_jp
            // 
            this.name_jp.Text = "(일문)";
            // 
            // locX
            // 
            this.locX.Text = "locX";
            this.locX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.locX.Width = 45;
            // 
            // locY
            // 
            this.locY.Text = "locY";
            this.locY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.locY.Width = 45;
            // 
            // szX
            // 
            this.szX.Text = "SzX";
            this.szX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.szX.Width = 45;
            // 
            // szY
            // 
            this.szY.Text = "SzY";
            this.szY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.szY.Width = 45;
            // 
            // btn_color
            // 
            this.btn_color.Text = "Color";
            this.btn_color.Width = 70;
            // 
            // lblGroupNameTitle
            // 
            this.lblGroupNameTitle.AutoSize = true;
            this.lblGroupNameTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGroupNameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGroupNameTitle.Location = new System.Drawing.Point(12, 28);
            this.lblGroupNameTitle.Name = "lblGroupNameTitle";
            this.lblGroupNameTitle.Size = new System.Drawing.Size(49, 14);
            this.lblGroupNameTitle.TabIndex = 41;
            this.lblGroupNameTitle.Text = "그룹명";
            // 
            // lblLocYTitle
            // 
            this.lblLocYTitle.AutoSize = true;
            this.lblLocYTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocYTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLocYTitle.Location = new System.Drawing.Point(20, 174);
            this.lblLocYTitle.Name = "lblLocYTitle";
            this.lblLocYTitle.Size = new System.Drawing.Size(32, 14);
            this.lblLocYTitle.TabIndex = 41;
            this.lblLocYTitle.Text = "Loc";
            // 
            // lblSzXTitle
            // 
            this.lblSzXTitle.AutoSize = true;
            this.lblSzXTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSzXTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSzXTitle.Location = new System.Drawing.Point(20, 203);
            this.lblSzXTitle.Name = "lblSzXTitle";
            this.lblSzXTitle.Size = new System.Drawing.Size(36, 14);
            this.lblSzXTitle.TabIndex = 41;
            this.lblSzXTitle.Text = "Size";
            // 
            // tbGroupName
            // 
            this.tbGroupName.BackColor = System.Drawing.Color.White;
            this.tbGroupName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGroupName.Location = new System.Drawing.Point(74, 21);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(135, 23);
            this.tbGroupName.TabIndex = 0;
            // 
            // tbLocateX
            // 
            this.tbLocateX.BackColor = System.Drawing.Color.White;
            this.tbLocateX.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLocateX.Location = new System.Drawing.Point(74, 168);
            this.tbLocateX.MaxLength = 1;
            this.tbLocateX.Name = "tbLocateX";
            this.tbLocateX.Size = new System.Drawing.Size(63, 23);
            this.tbLocateX.TabIndex = 4;
            // 
            // tbLocateY
            // 
            this.tbLocateY.BackColor = System.Drawing.Color.White;
            this.tbLocateY.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLocateY.Location = new System.Drawing.Point(148, 168);
            this.tbLocateY.MaxLength = 1;
            this.tbLocateY.Name = "tbLocateY";
            this.tbLocateY.Size = new System.Drawing.Size(59, 23);
            this.tbLocateY.TabIndex = 5;
            // 
            // tbSizeX
            // 
            this.tbSizeX.BackColor = System.Drawing.Color.White;
            this.tbSizeX.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSizeX.Location = new System.Drawing.Point(74, 197);
            this.tbSizeX.MaxLength = 1;
            this.tbSizeX.Name = "tbSizeX";
            this.tbSizeX.Size = new System.Drawing.Size(63, 23);
            this.tbSizeX.TabIndex = 6;
            // 
            // tbSizeY
            // 
            this.tbSizeY.BackColor = System.Drawing.Color.White;
            this.tbSizeY.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSizeY.Location = new System.Drawing.Point(148, 197);
            this.tbSizeY.MaxLength = 1;
            this.tbSizeY.Name = "tbSizeY";
            this.tbSizeY.Size = new System.Drawing.Size(60, 23);
            this.tbSizeY.TabIndex = 7;
            // 
            // btnInput
            // 
            this.btnInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInput.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInput.ForeColor = System.Drawing.Color.White;
            this.btnInput.Location = new System.Drawing.Point(74, 330);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(135, 40);
            this.btnInput.TabIndex = 39;
            this.btnInput.TabStop = false;
            this.btnInput.Text = "입력";
            this.btnInput.UseVisualStyleBackColor = false;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(74, 376);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(135, 40);
            this.btnUpdate.TabIndex = 39;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(79, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(107, 14);
            this.lblTitle.TabIndex = 42;
            this.lblTitle.Text = "상품그룹(POS)";
            // 
            // tableLayoutPanelGroupSelected
            // 
            this.tableLayoutPanelGroupSelected.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelGroupSelected.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelGroupSelected.ColumnCount = 8;
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanelGroupSelected.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelGroupSelected.Location = new System.Drawing.Point(81, 409);
            this.tableLayoutPanelGroupSelected.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelGroupSelected.Name = "tableLayoutPanelGroupSelected";
            this.tableLayoutPanelGroupSelected.RowCount = 2;
            this.tableLayoutPanelGroupSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGroupSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGroupSelected.Size = new System.Drawing.Size(521, 130);
            this.tableLayoutPanelGroupSelected.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.White;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnApply.Location = new System.Drawing.Point(692, 637);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(135, 40);
            this.btnApply.TabIndex = 43;
            this.btnApply.TabStop = false;
            this.btnApply.Text = "적용보기";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblT6);
            this.groupBox1.Controls.Add(this.lblT5);
            this.groupBox1.Controls.Add(this.btnColor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbColor);
            this.groupBox1.Controls.Add(this.tbGroupNameJP);
            this.groupBox1.Controls.Add(this.lblGroupNameTitleJP);
            this.groupBox1.Controls.Add(this.tbGroupNameCH);
            this.groupBox1.Controls.Add(this.lblGroupNameTitleCH);
            this.groupBox1.Controls.Add(this.tbGroupNameEN);
            this.groupBox1.Controls.Add(this.lblGroupNameTitleEN);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.tbGroupName);
            this.groupBox1.Controls.Add(this.tbLocateX);
            this.groupBox1.Controls.Add(this.tbLocateY);
            this.groupBox1.Controls.Add(this.lblSzXTitle);
            this.groupBox1.Controls.Add(this.tbSizeX);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnInput);
            this.groupBox1.Controls.Add(this.lblLocYTitle);
            this.groupBox1.Controls.Add(this.tbSizeY);
            this.groupBox1.Controls.Add(this.lblGroupNameTitle);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(619, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 463);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // lblT6
            // 
            this.lblT6.AutoSize = true;
            this.lblT6.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblT6.Location = new System.Drawing.Point(166, 150);
            this.lblT6.Name = "lblT6";
            this.lblT6.Size = new System.Drawing.Size(15, 13);
            this.lblT6.TabIndex = 71;
            this.lblT6.Text = "Y";
            // 
            // lblT5
            // 
            this.lblT5.AutoSize = true;
            this.lblT5.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblT5.Location = new System.Drawing.Point(96, 152);
            this.lblT5.Name = "lblT5";
            this.lblT5.Size = new System.Drawing.Size(15, 13);
            this.lblT5.TabIndex = 72;
            this.lblT5.Text = "X";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.White;
            this.btnColor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(148, 247);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(60, 33);
            this.btnColor.TabIndex = 51;
            this.btnColor.TabStop = false;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 50;
            this.label1.Text = "Color";
            // 
            // tbColor
            // 
            this.tbColor.BackColor = System.Drawing.Color.White;
            this.tbColor.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbColor.Location = new System.Drawing.Point(74, 248);
            this.tbColor.MaxLength = 8;
            this.tbColor.Name = "tbColor";
            this.tbColor.Size = new System.Drawing.Size(63, 23);
            this.tbColor.TabIndex = 49;
            this.tbColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbColor_KeyDown);
            // 
            // tbGroupNameJP
            // 
            this.tbGroupNameJP.BackColor = System.Drawing.Color.White;
            this.tbGroupNameJP.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGroupNameJP.Location = new System.Drawing.Point(74, 108);
            this.tbGroupNameJP.Name = "tbGroupNameJP";
            this.tbGroupNameJP.Size = new System.Drawing.Size(135, 23);
            this.tbGroupNameJP.TabIndex = 3;
            // 
            // lblGroupNameTitleJP
            // 
            this.lblGroupNameTitleJP.AutoSize = true;
            this.lblGroupNameTitleJP.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGroupNameTitleJP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGroupNameTitleJP.Location = new System.Drawing.Point(12, 115);
            this.lblGroupNameTitleJP.Name = "lblGroupNameTitleJP";
            this.lblGroupNameTitleJP.Size = new System.Drawing.Size(47, 14);
            this.lblGroupNameTitleJP.TabIndex = 48;
            this.lblGroupNameTitleJP.Text = "(일문)";
            // 
            // tbGroupNameCH
            // 
            this.tbGroupNameCH.BackColor = System.Drawing.Color.White;
            this.tbGroupNameCH.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGroupNameCH.Location = new System.Drawing.Point(74, 79);
            this.tbGroupNameCH.Name = "tbGroupNameCH";
            this.tbGroupNameCH.Size = new System.Drawing.Size(135, 23);
            this.tbGroupNameCH.TabIndex = 2;
            // 
            // lblGroupNameTitleCH
            // 
            this.lblGroupNameTitleCH.AutoSize = true;
            this.lblGroupNameTitleCH.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGroupNameTitleCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGroupNameTitleCH.Location = new System.Drawing.Point(12, 86);
            this.lblGroupNameTitleCH.Name = "lblGroupNameTitleCH";
            this.lblGroupNameTitleCH.Size = new System.Drawing.Size(47, 14);
            this.lblGroupNameTitleCH.TabIndex = 46;
            this.lblGroupNameTitleCH.Text = "(중문)";
            // 
            // tbGroupNameEN
            // 
            this.tbGroupNameEN.BackColor = System.Drawing.Color.White;
            this.tbGroupNameEN.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGroupNameEN.Location = new System.Drawing.Point(74, 50);
            this.tbGroupNameEN.Name = "tbGroupNameEN";
            this.tbGroupNameEN.Size = new System.Drawing.Size(135, 23);
            this.tbGroupNameEN.TabIndex = 1;
            // 
            // lblGroupNameTitleEN
            // 
            this.lblGroupNameTitleEN.AutoSize = true;
            this.lblGroupNameTitleEN.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGroupNameTitleEN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGroupNameTitleEN.Location = new System.Drawing.Point(12, 57);
            this.lblGroupNameTitleEN.Name = "lblGroupNameTitleEN";
            this.lblGroupNameTitleEN.Size = new System.Drawing.Size(47, 14);
            this.lblGroupNameTitleEN.TabIndex = 44;
            this.lblGroupNameTitleEN.Text = "(영문)";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(74, 422);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 30);
            this.btnDelete.TabIndex = 42;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // comboPosNo
            // 
            this.comboPosNo.BackColor = System.Drawing.Color.White;
            this.comboPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboPosNo.FormattingEnabled = true;
            this.comboPosNo.Location = new System.Drawing.Point(73, 24);
            this.comboPosNo.Name = "comboPosNo";
            this.comboPosNo.Size = new System.Drawing.Size(135, 21);
            this.comboPosNo.TabIndex = 45;
            this.comboPosNo.TabStop = false;
            // 
            // lblPosNo
            // 
            this.lblPosNo.AutoSize = true;
            this.lblPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPosNo.Location = new System.Drawing.Point(5, 28);
            this.lblPosNo.Name = "lblPosNo";
            this.lblPosNo.Size = new System.Drawing.Size(63, 14);
            this.lblPosNo.TabIndex = 41;
            this.lblPosNo.Text = "포스번호";
            // 
            // btnViewPosNo
            // 
            this.btnViewPosNo.BackColor = System.Drawing.Color.White;
            this.btnViewPosNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewPosNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnViewPosNo.Location = new System.Drawing.Point(74, 54);
            this.btnViewPosNo.Name = "btnViewPosNo";
            this.btnViewPosNo.Size = new System.Drawing.Size(134, 40);
            this.btnViewPosNo.TabIndex = 46;
            this.btnViewPosNo.TabStop = false;
            this.btnViewPosNo.Text = "조회";
            this.btnViewPosNo.UseVisualStyleBackColor = false;
            this.btnViewPosNo.Click += new System.EventHandler(this.btnViewPosNo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewPosNo);
            this.groupBox2.Controls.Add(this.lblPosNo);
            this.groupBox2.Controls.Add(this.comboPosNo);
            this.groupBox2.Location = new System.Drawing.Point(619, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 105);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            // 
            // code
            // 
            this.code.Text = "code";
            this.code.Width = 1;
            // 
            // frmSysGoodsGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.tableLayoutPanelGroupSelected);
            this.Controls.Add(this.tableLayoutPanelGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysGoodsGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "상품그룹등록";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGroup;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader locX;
        private System.Windows.Forms.ColumnHeader locY;
        private System.Windows.Forms.ColumnHeader szX;
        private System.Windows.Forms.ColumnHeader szY;
        private System.Windows.Forms.Label lblGroupNameTitle;
        private System.Windows.Forms.Label lblLocYTitle;
        private System.Windows.Forms.Label lblSzXTitle;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.TextBox tbLocateX;
        private System.Windows.Forms.TextBox tbLocateY;
        private System.Windows.Forms.TextBox tbSizeX;
        private System.Windows.Forms.TextBox tbSizeY;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGroupSelected;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboPosNo;
        private System.Windows.Forms.Label lblPosNo;
        private System.Windows.Forms.Button btnViewPosNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader name_en;
        private System.Windows.Forms.ColumnHeader name_ch;
        private System.Windows.Forms.ColumnHeader name_jp;
        private System.Windows.Forms.TextBox tbGroupNameJP;
        private System.Windows.Forms.Label lblGroupNameTitleJP;
        private System.Windows.Forms.TextBox tbGroupNameCH;
        private System.Windows.Forms.Label lblGroupNameTitleCH;
        private System.Windows.Forms.TextBox tbGroupNameEN;
        private System.Windows.Forms.Label lblGroupNameTitleEN;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ColumnHeader btn_color;
        private System.Windows.Forms.Label lblT6;
        private System.Windows.Forms.Label lblT5;
        private System.Windows.Forms.ColumnHeader code;
    }
}