namespace thepos._9SysAdmin
{
    partial class frmSysPosGroup
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
            this.btnPosGroupDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPosGroupName = new System.Windows.Forms.TextBox();
            this.lblGoodsAmtTitle = new System.Windows.Forms.Label();
            this.lblGoodsNameTitle = new System.Windows.Forms.Label();
            this.tbPosGroupCode = new System.Windows.Forms.TextBox();
            this.btnPosGroupUpdate = new System.Windows.Forms.Button();
            this.btnPosGroupAdd = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwPosGroup = new System.Windows.Forms.ListView();
            this.pos_group_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pos_group_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPosGroupDelete
            // 
            this.btnPosGroupDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPosGroupDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosGroupDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPosGroupDelete.ForeColor = System.Drawing.Color.White;
            this.btnPosGroupDelete.Location = new System.Drawing.Point(484, 576);
            this.btnPosGroupDelete.Name = "btnPosGroupDelete";
            this.btnPosGroupDelete.Size = new System.Drawing.Size(90, 34);
            this.btnPosGroupDelete.TabIndex = 55;
            this.btnPosGroupDelete.TabStop = false;
            this.btnPosGroupDelete.Text = "삭제";
            this.btnPosGroupDelete.UseVisualStyleBackColor = false;
            this.btnPosGroupDelete.Click += new System.EventHandler(this.btnPosGroupDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPosGroupName);
            this.groupBox1.Controls.Add(this.lblGoodsAmtTitle);
            this.groupBox1.Controls.Add(this.lblGoodsNameTitle);
            this.groupBox1.Controls.Add(this.tbPosGroupCode);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(202, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 166);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // tbPosGroupName
            // 
            this.tbPosGroupName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPosGroupName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbPosGroupName.Location = new System.Drawing.Point(87, 55);
            this.tbPosGroupName.MaxLength = 16;
            this.tbPosGroupName.Name = "tbPosGroupName";
            this.tbPosGroupName.Size = new System.Drawing.Size(151, 23);
            this.tbPosGroupName.TabIndex = 1;
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
            this.lblGoodsAmtTitle.Text = "그룹명";
            // 
            // lblGoodsNameTitle
            // 
            this.lblGoodsNameTitle.AutoSize = true;
            this.lblGoodsNameTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsNameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGoodsNameTitle.Location = new System.Drawing.Point(18, 32);
            this.lblGoodsNameTitle.Name = "lblGoodsNameTitle";
            this.lblGoodsNameTitle.Size = new System.Drawing.Size(35, 14);
            this.lblGoodsNameTitle.TabIndex = 43;
            this.lblGoodsNameTitle.Text = "코드";
            // 
            // tbPosGroupCode
            // 
            this.tbPosGroupCode.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPosGroupCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbPosGroupCode.Location = new System.Drawing.Point(87, 25);
            this.tbPosGroupCode.MaxLength = 2;
            this.tbPosGroupCode.Name = "tbPosGroupCode";
            this.tbPosGroupCode.Size = new System.Drawing.Size(151, 23);
            this.tbPosGroupCode.TabIndex = 0;
            // 
            // btnPosGroupUpdate
            // 
            this.btnPosGroupUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPosGroupUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosGroupUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPosGroupUpdate.ForeColor = System.Drawing.Color.White;
            this.btnPosGroupUpdate.Location = new System.Drawing.Point(484, 522);
            this.btnPosGroupUpdate.Name = "btnPosGroupUpdate";
            this.btnPosGroupUpdate.Size = new System.Drawing.Size(90, 48);
            this.btnPosGroupUpdate.TabIndex = 52;
            this.btnPosGroupUpdate.TabStop = false;
            this.btnPosGroupUpdate.Text = "수정";
            this.btnPosGroupUpdate.UseVisualStyleBackColor = false;
            this.btnPosGroupUpdate.Click += new System.EventHandler(this.btnPosGroupUpdate_Click);
            // 
            // btnPosGroupAdd
            // 
            this.btnPosGroupAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPosGroupAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosGroupAdd.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPosGroupAdd.ForeColor = System.Drawing.Color.White;
            this.btnPosGroupAdd.Location = new System.Drawing.Point(484, 469);
            this.btnPosGroupAdd.Name = "btnPosGroupAdd";
            this.btnPosGroupAdd.Size = new System.Drawing.Size(90, 48);
            this.btnPosGroupAdd.TabIndex = 53;
            this.btnPosGroupAdd.TabStop = false;
            this.btnPosGroupAdd.Text = "추가";
            this.btnPosGroupAdd.UseVisualStyleBackColor = false;
            this.btnPosGroupAdd.Click += new System.EventHandler(this.btnPosGroupAdd_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(205, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(63, 14);
            this.lblTitle.TabIndex = 51;
            this.lblTitle.Text = "포스그룹";
            // 
            // lvwPosGroup
            // 
            this.lvwPosGroup.BackColor = System.Drawing.SystemColors.Window;
            this.lvwPosGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pos_group_code,
            this.pos_group_name});
            this.lvwPosGroup.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwPosGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwPosGroup.FullRowSelect = true;
            this.lvwPosGroup.GridLines = true;
            this.lvwPosGroup.HideSelection = false;
            this.lvwPosGroup.Location = new System.Drawing.Point(202, 51);
            this.lvwPosGroup.MultiSelect = false;
            this.lvwPosGroup.Name = "lvwPosGroup";
            this.lvwPosGroup.Size = new System.Drawing.Size(395, 377);
            this.lvwPosGroup.TabIndex = 50;
            this.lvwPosGroup.TabStop = false;
            this.lvwPosGroup.UseCompatibleStateImageBehavior = false;
            this.lvwPosGroup.View = System.Windows.Forms.View.Details;
            this.lvwPosGroup.SelectedIndexChanged += new System.EventHandler(this.lvwPosGroup_SelectedIndexChanged);
            // 
            // pos_group_code
            // 
            this.pos_group_code.Text = "코드";
            this.pos_group_code.Width = 47;
            // 
            // pos_group_name
            // 
            this.pos_group_name.Text = "그룹명";
            this.pos_group_name.Width = 100;
            // 
            // frmSysPosGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.btnPosGroupDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPosGroupUpdate);
            this.Controls.Add(this.btnPosGroupAdd);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvwPosGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysPosGroup";
            this.Text = "frmSysShop";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPosGroupDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbPosGroupName;
        private System.Windows.Forms.Label lblGoodsAmtTitle;
        private System.Windows.Forms.Label lblGoodsNameTitle;
        private System.Windows.Forms.TextBox tbPosGroupCode;
        private System.Windows.Forms.Button btnPosGroupUpdate;
        private System.Windows.Forms.Button btnPosGroupAdd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwPosGroup;
        private System.Windows.Forms.ColumnHeader pos_group_code;
        private System.Windows.Forms.ColumnHeader pos_group_name;
    }
}