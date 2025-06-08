namespace thepos._9SysAdmin
{
    partial class frmSysShop
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
            this.btnShopDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNetworkPrinterName = new System.Windows.Forms.TextBox();
            this.lblNetworkPrinterName = new System.Windows.Forms.Label();
            this.cbPrinterType = new System.Windows.Forms.ComboBox();
            this.lblPrinterTypeTitle = new System.Windows.Forms.Label();
            this.tbShopName = new System.Windows.Forms.TextBox();
            this.lblGoodsAmtTitle = new System.Windows.Forms.Label();
            this.lblGoodsNameTitle = new System.Windows.Forms.Label();
            this.tbShopCode = new System.Windows.Forms.TextBox();
            this.btnShopUpdate = new System.Windows.Forms.Button();
            this.btnShopAdd = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwShop = new System.Windows.Forms.ListView();
            this.shop_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shop_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.printer_type_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.printer_type_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.network_printer_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnNod1Delete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbNodName1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNodCode1 = new System.Windows.Forms.TextBox();
            this.btnNod1Update = new System.Windows.Forms.Button();
            this.btnNod1Add = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lvwNod1 = new System.Windows.Forms.ListView();
            this.nod_code1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nod_name1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNod2Delete = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbNodName2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNodCode2 = new System.Windows.Forms.TextBox();
            this.btnNod2Update = new System.Windows.Forms.Button();
            this.btnNod2Add = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lvwNod2 = new System.Windows.Forms.ListView();
            this.nod_code2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nod_name2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShopDelete
            // 
            this.btnShopDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShopDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShopDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnShopDelete.ForeColor = System.Drawing.Color.White;
            this.btnShopDelete.Location = new System.Drawing.Point(312, 576);
            this.btnShopDelete.Name = "btnShopDelete";
            this.btnShopDelete.Size = new System.Drawing.Size(90, 34);
            this.btnShopDelete.TabIndex = 55;
            this.btnShopDelete.TabStop = false;
            this.btnShopDelete.Text = "삭제";
            this.btnShopDelete.UseVisualStyleBackColor = false;
            this.btnShopDelete.Click += new System.EventHandler(this.btnShopDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNetworkPrinterName);
            this.groupBox1.Controls.Add(this.lblNetworkPrinterName);
            this.groupBox1.Controls.Add(this.cbPrinterType);
            this.groupBox1.Controls.Add(this.lblPrinterTypeTitle);
            this.groupBox1.Controls.Add(this.tbShopName);
            this.groupBox1.Controls.Add(this.lblGoodsAmtTitle);
            this.groupBox1.Controls.Add(this.lblGoodsNameTitle);
            this.groupBox1.Controls.Add(this.tbShopCode);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(30, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 166);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // tbNetworkPrinterName
            // 
            this.tbNetworkPrinterName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbNetworkPrinterName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbNetworkPrinterName.Location = new System.Drawing.Point(87, 118);
            this.tbNetworkPrinterName.MaxLength = 50;
            this.tbNetworkPrinterName.Name = "tbNetworkPrinterName";
            this.tbNetworkPrinterName.Size = new System.Drawing.Size(151, 23);
            this.tbNetworkPrinterName.TabIndex = 3;
            // 
            // lblNetworkPrinterName
            // 
            this.lblNetworkPrinterName.AutoSize = true;
            this.lblNetworkPrinterName.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNetworkPrinterName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNetworkPrinterName.Location = new System.Drawing.Point(18, 118);
            this.lblNetworkPrinterName.Name = "lblNetworkPrinterName";
            this.lblNetworkPrinterName.Size = new System.Drawing.Size(59, 26);
            this.lblNetworkPrinterName.TabIndex = 48;
            this.lblNetworkPrinterName.Text = "네트워크\r\n프린터명";
            // 
            // cbPrinterType
            // 
            this.cbPrinterType.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPrinterType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbPrinterType.FormattingEnabled = true;
            this.cbPrinterType.Location = new System.Drawing.Point(87, 87);
            this.cbPrinterType.Name = "cbPrinterType";
            this.cbPrinterType.Size = new System.Drawing.Size(151, 21);
            this.cbPrinterType.TabIndex = 2;
            // 
            // lblPrinterTypeTitle
            // 
            this.lblPrinterTypeTitle.AutoSize = true;
            this.lblPrinterTypeTitle.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPrinterTypeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrinterTypeTitle.Location = new System.Drawing.Point(18, 91);
            this.lblPrinterTypeTitle.Name = "lblPrinterTypeTitle";
            this.lblPrinterTypeTitle.Size = new System.Drawing.Size(59, 13);
            this.lblPrinterTypeTitle.TabIndex = 45;
            this.lblPrinterTypeTitle.Text = "주문출력";
            // 
            // tbShopName
            // 
            this.tbShopName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbShopName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbShopName.Location = new System.Drawing.Point(87, 55);
            this.tbShopName.MaxLength = 16;
            this.tbShopName.Name = "tbShopName";
            this.tbShopName.Size = new System.Drawing.Size(151, 23);
            this.tbShopName.TabIndex = 1;
            // 
            // lblGoodsAmtTitle
            // 
            this.lblGoodsAmtTitle.AutoSize = true;
            this.lblGoodsAmtTitle.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsAmtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGoodsAmtTitle.Location = new System.Drawing.Point(18, 62);
            this.lblGoodsAmtTitle.Name = "lblGoodsAmtTitle";
            this.lblGoodsAmtTitle.Size = new System.Drawing.Size(46, 13);
            this.lblGoodsAmtTitle.TabIndex = 44;
            this.lblGoodsAmtTitle.Text = "업장명";
            // 
            // lblGoodsNameTitle
            // 
            this.lblGoodsNameTitle.AutoSize = true;
            this.lblGoodsNameTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsNameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGoodsNameTitle.Location = new System.Drawing.Point(18, 32);
            this.lblGoodsNameTitle.Name = "lblGoodsNameTitle";
            this.lblGoodsNameTitle.Size = new System.Drawing.Size(63, 14);
            this.lblGoodsNameTitle.TabIndex = 43;
            this.lblGoodsNameTitle.Text = "업장코드";
            // 
            // tbShopCode
            // 
            this.tbShopCode.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbShopCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbShopCode.Location = new System.Drawing.Point(87, 25);
            this.tbShopCode.MaxLength = 2;
            this.tbShopCode.Name = "tbShopCode";
            this.tbShopCode.Size = new System.Drawing.Size(151, 23);
            this.tbShopCode.TabIndex = 0;
            // 
            // btnShopUpdate
            // 
            this.btnShopUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShopUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShopUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnShopUpdate.ForeColor = System.Drawing.Color.White;
            this.btnShopUpdate.Location = new System.Drawing.Point(312, 522);
            this.btnShopUpdate.Name = "btnShopUpdate";
            this.btnShopUpdate.Size = new System.Drawing.Size(90, 48);
            this.btnShopUpdate.TabIndex = 52;
            this.btnShopUpdate.TabStop = false;
            this.btnShopUpdate.Text = "수정";
            this.btnShopUpdate.UseVisualStyleBackColor = false;
            this.btnShopUpdate.Click += new System.EventHandler(this.btnShopUpdate_Click);
            // 
            // btnShopAdd
            // 
            this.btnShopAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShopAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShopAdd.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnShopAdd.ForeColor = System.Drawing.Color.White;
            this.btnShopAdd.Location = new System.Drawing.Point(312, 469);
            this.btnShopAdd.Name = "btnShopAdd";
            this.btnShopAdd.Size = new System.Drawing.Size(90, 48);
            this.btnShopAdd.TabIndex = 53;
            this.btnShopAdd.TabStop = false;
            this.btnShopAdd.Text = "추가";
            this.btnShopAdd.UseVisualStyleBackColor = false;
            this.btnShopAdd.Click += new System.EventHandler(this.btnShopAdd_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(33, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(37, 14);
            this.lblTitle.TabIndex = 51;
            this.lblTitle.Text = "업장";
            // 
            // lvwShop
            // 
            this.lvwShop.BackColor = System.Drawing.SystemColors.Window;
            this.lvwShop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.shop_code,
            this.shop_name,
            this.printer_type_code,
            this.printer_type_name,
            this.network_printer_name});
            this.lvwShop.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwShop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwShop.FullRowSelect = true;
            this.lvwShop.GridLines = true;
            this.lvwShop.HideSelection = false;
            this.lvwShop.Location = new System.Drawing.Point(30, 51);
            this.lvwShop.MultiSelect = false;
            this.lvwShop.Name = "lvwShop";
            this.lvwShop.Size = new System.Drawing.Size(395, 377);
            this.lvwShop.TabIndex = 50;
            this.lvwShop.TabStop = false;
            this.lvwShop.UseCompatibleStateImageBehavior = false;
            this.lvwShop.View = System.Windows.Forms.View.Details;
            this.lvwShop.SelectedIndexChanged += new System.EventHandler(this.lvwShop_SelectedIndexChanged);
            // 
            // shop_code
            // 
            this.shop_code.Text = "코드";
            this.shop_code.Width = 47;
            // 
            // shop_name
            // 
            this.shop_name.Text = "업장명";
            this.shop_name.Width = 90;
            // 
            // printer_type_code
            // 
            this.printer_type_code.Text = "printer_type_code";
            this.printer_type_code.Width = 0;
            // 
            // printer_type_name
            // 
            this.printer_type_name.Text = "주문출력";
            this.printer_type_name.Width = 110;
            // 
            // network_printer_name
            // 
            this.network_printer_name.Text = "네트워프린터";
            this.network_printer_name.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(52, 651);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 24);
            this.label1.TabIndex = 56;
            this.label1.Text = "단독업장일 경우(레코드1개) \r\n주문서/교환권 출력시 [코너 : 업장명]이 생략됩니다.";
            // 
            // btnNod1Delete
            // 
            this.btnNod1Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNod1Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNod1Delete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNod1Delete.ForeColor = System.Drawing.Color.White;
            this.btnNod1Delete.Location = new System.Drawing.Point(576, 565);
            this.btnNod1Delete.Name = "btnNod1Delete";
            this.btnNod1Delete.Size = new System.Drawing.Size(46, 45);
            this.btnNod1Delete.TabIndex = 62;
            this.btnNod1Delete.TabStop = false;
            this.btnNod1Delete.Text = "삭제";
            this.btnNod1Delete.UseVisualStyleBackColor = false;
            this.btnNod1Delete.Click += new System.EventHandler(this.btnNod1Delete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbNodName1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbNodCode1);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(440, 444);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 103);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            // 
            // tbNodName1
            // 
            this.tbNodName1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbNodName1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbNodName1.Location = new System.Drawing.Point(68, 62);
            this.tbNodName1.MaxLength = 16;
            this.tbNodName1.Name = "tbNodName1";
            this.tbNodName1.Size = new System.Drawing.Size(96, 23);
            this.tbNodName1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(16, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "분류명";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(16, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 43;
            this.label5.Text = "코드";
            // 
            // tbNodCode1
            // 
            this.tbNodCode1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbNodCode1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbNodCode1.Location = new System.Drawing.Point(68, 29);
            this.tbNodCode1.MaxLength = 2;
            this.tbNodCode1.Name = "tbNodCode1";
            this.tbNodCode1.Size = new System.Drawing.Size(96, 23);
            this.tbNodCode1.TabIndex = 4;
            // 
            // btnNod1Update
            // 
            this.btnNod1Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNod1Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNod1Update.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNod1Update.ForeColor = System.Drawing.Color.White;
            this.btnNod1Update.Location = new System.Drawing.Point(509, 565);
            this.btnNod1Update.Name = "btnNod1Update";
            this.btnNod1Update.Size = new System.Drawing.Size(63, 45);
            this.btnNod1Update.TabIndex = 59;
            this.btnNod1Update.TabStop = false;
            this.btnNod1Update.Text = "수정";
            this.btnNod1Update.UseVisualStyleBackColor = false;
            this.btnNod1Update.Click += new System.EventHandler(this.btnNod1Update_Click);
            // 
            // btnNod1Add
            // 
            this.btnNod1Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNod1Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNod1Add.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNod1Add.ForeColor = System.Drawing.Color.White;
            this.btnNod1Add.Location = new System.Drawing.Point(442, 565);
            this.btnNod1Add.Name = "btnNod1Add";
            this.btnNod1Add.Size = new System.Drawing.Size(63, 45);
            this.btnNod1Add.TabIndex = 60;
            this.btnNod1Add.TabStop = false;
            this.btnNod1Add.Text = "추가";
            this.btnNod1Add.UseVisualStyleBackColor = false;
            this.btnNod1Add.Click += new System.EventHandler(this.btnNod1Add_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(439, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 14);
            this.label6.TabIndex = 58;
            this.label6.Text = "분류1";
            // 
            // lvwNod1
            // 
            this.lvwNod1.BackColor = System.Drawing.SystemColors.Window;
            this.lvwNod1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nod_code1,
            this.nod_name1});
            this.lvwNod1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwNod1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwNod1.FullRowSelect = true;
            this.lvwNod1.GridLines = true;
            this.lvwNod1.HideSelection = false;
            this.lvwNod1.Location = new System.Drawing.Point(440, 51);
            this.lvwNod1.MultiSelect = false;
            this.lvwNod1.Name = "lvwNod1";
            this.lvwNod1.Size = new System.Drawing.Size(181, 377);
            this.lvwNod1.TabIndex = 57;
            this.lvwNod1.TabStop = false;
            this.lvwNod1.UseCompatibleStateImageBehavior = false;
            this.lvwNod1.View = System.Windows.Forms.View.Details;
            this.lvwNod1.SelectedIndexChanged += new System.EventHandler(this.lvwNod1_SelectedIndexChanged);
            // 
            // nod_code1
            // 
            this.nod_code1.Text = "코드";
            this.nod_code1.Width = 45;
            // 
            // nod_name1
            // 
            this.nod_name1.Text = "분류명";
            this.nod_name1.Width = 114;
            // 
            // btnNod2Delete
            // 
            this.btnNod2Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNod2Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNod2Delete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNod2Delete.ForeColor = System.Drawing.Color.White;
            this.btnNod2Delete.Location = new System.Drawing.Point(775, 565);
            this.btnNod2Delete.Name = "btnNod2Delete";
            this.btnNod2Delete.Size = new System.Drawing.Size(46, 45);
            this.btnNod2Delete.TabIndex = 68;
            this.btnNod2Delete.TabStop = false;
            this.btnNod2Delete.Text = "삭제";
            this.btnNod2Delete.UseVisualStyleBackColor = false;
            this.btnNod2Delete.Click += new System.EventHandler(this.btnNod2Delete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbNodName2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbNodCode2);
            this.groupBox3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(637, 444);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(182, 103);
            this.groupBox3.TabIndex = 67;
            this.groupBox3.TabStop = false;
            // 
            // tbNodName2
            // 
            this.tbNodName2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbNodName2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbNodName2.Location = new System.Drawing.Point(68, 62);
            this.tbNodName2.MaxLength = 16;
            this.tbNodName2.Name = "tbNodName2";
            this.tbNodName2.Size = new System.Drawing.Size(96, 23);
            this.tbNodName2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(16, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "분류명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 43;
            this.label3.Text = "코드";
            // 
            // tbNodCode2
            // 
            this.tbNodCode2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbNodCode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbNodCode2.Location = new System.Drawing.Point(68, 29);
            this.tbNodCode2.MaxLength = 2;
            this.tbNodCode2.Name = "tbNodCode2";
            this.tbNodCode2.Size = new System.Drawing.Size(96, 23);
            this.tbNodCode2.TabIndex = 6;
            // 
            // btnNod2Update
            // 
            this.btnNod2Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNod2Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNod2Update.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNod2Update.ForeColor = System.Drawing.Color.White;
            this.btnNod2Update.Location = new System.Drawing.Point(708, 565);
            this.btnNod2Update.Name = "btnNod2Update";
            this.btnNod2Update.Size = new System.Drawing.Size(63, 45);
            this.btnNod2Update.TabIndex = 65;
            this.btnNod2Update.TabStop = false;
            this.btnNod2Update.Text = "수정";
            this.btnNod2Update.UseVisualStyleBackColor = false;
            this.btnNod2Update.Click += new System.EventHandler(this.btnNod2Update_Click);
            // 
            // btnNod2Add
            // 
            this.btnNod2Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNod2Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNod2Add.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNod2Add.ForeColor = System.Drawing.Color.White;
            this.btnNod2Add.Location = new System.Drawing.Point(639, 565);
            this.btnNod2Add.Name = "btnNod2Add";
            this.btnNod2Add.Size = new System.Drawing.Size(65, 45);
            this.btnNod2Add.TabIndex = 66;
            this.btnNod2Add.TabStop = false;
            this.btnNod2Add.Text = "추가";
            this.btnNod2Add.UseVisualStyleBackColor = false;
            this.btnNod2Add.Click += new System.EventHandler(this.btnNod2Add_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Purple;
            this.label7.Location = new System.Drawing.Point(635, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 14);
            this.label7.TabIndex = 64;
            this.label7.Text = "분류2";
            // 
            // lvwNod2
            // 
            this.lvwNod2.BackColor = System.Drawing.SystemColors.Window;
            this.lvwNod2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nod_code2,
            this.nod_name2});
            this.lvwNod2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwNod2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwNod2.FullRowSelect = true;
            this.lvwNod2.GridLines = true;
            this.lvwNod2.HideSelection = false;
            this.lvwNod2.Location = new System.Drawing.Point(636, 51);
            this.lvwNod2.MultiSelect = false;
            this.lvwNod2.Name = "lvwNod2";
            this.lvwNod2.Size = new System.Drawing.Size(183, 377);
            this.lvwNod2.TabIndex = 63;
            this.lvwNod2.TabStop = false;
            this.lvwNod2.UseCompatibleStateImageBehavior = false;
            this.lvwNod2.View = System.Windows.Forms.View.Details;
            this.lvwNod2.SelectedIndexChanged += new System.EventHandler(this.lvwNod2_SelectedIndexChanged);
            // 
            // nod_code2
            // 
            this.nod_code2.Text = "코드";
            this.nod_code2.Width = 45;
            // 
            // nod_name2
            // 
            this.nod_name2.Text = "분류명";
            this.nod_name2.Width = 116;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(453, 651);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(361, 24);
            this.label8.TabIndex = 56;
            this.label8.Text = "상품항목에 분류정보가 적용되어  있는 경우\r\n분류정보를 삭제하면 이후 마감집계시 오류가 발생할 수 있습니다.";
            // 
            // frmSysShop
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.btnNod2Delete);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnNod2Update);
            this.Controls.Add(this.btnNod2Add);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lvwNod2);
            this.Controls.Add(this.btnNod1Delete);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnNod1Update);
            this.Controls.Add(this.btnNod1Add);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lvwNod1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShopDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnShopUpdate);
            this.Controls.Add(this.btnShopAdd);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvwShop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysShop";
            this.Text = "frmSysShop";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShopDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbShopName;
        private System.Windows.Forms.Label lblGoodsAmtTitle;
        private System.Windows.Forms.Label lblGoodsNameTitle;
        private System.Windows.Forms.TextBox tbShopCode;
        private System.Windows.Forms.Button btnShopUpdate;
        private System.Windows.Forms.Button btnShopAdd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwShop;
        private System.Windows.Forms.ColumnHeader shop_code;
        private System.Windows.Forms.ColumnHeader shop_name;
        private System.Windows.Forms.ColumnHeader printer_type_name;
        private System.Windows.Forms.ColumnHeader network_printer_name;
        private System.Windows.Forms.Label lblPrinterTypeTitle;
        private System.Windows.Forms.TextBox tbNetworkPrinterName;
        private System.Windows.Forms.Label lblNetworkPrinterName;
        private System.Windows.Forms.ComboBox cbPrinterType;
        private System.Windows.Forms.ColumnHeader printer_type_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNod1Delete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbNodName1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNodCode1;
        private System.Windows.Forms.Button btnNod1Update;
        private System.Windows.Forms.Button btnNod1Add;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvwNod1;
        private System.Windows.Forms.ColumnHeader nod_code1;
        private System.Windows.Forms.ColumnHeader nod_name1;
        private System.Windows.Forms.Button btnNod2Delete;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbNodName2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNodCode2;
        private System.Windows.Forms.Button btnNod2Update;
        private System.Windows.Forms.Button btnNod2Add;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvwNod2;
        private System.Windows.Forms.ColumnHeader nod_code2;
        private System.Windows.Forms.ColumnHeader nod_name2;
        private System.Windows.Forms.Label label8;
    }
}