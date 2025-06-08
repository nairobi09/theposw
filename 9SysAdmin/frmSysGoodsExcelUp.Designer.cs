namespace theposw._9SysAdmin
{
    partial class frmSysGoodsExcelUp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStartGoodsCode = new System.Windows.Forms.TextBox();
            this.btnOpenExcel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpload);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbStartGoodsCode);
            this.panel1.Controls.Add(this.btnOpenExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(888, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 729);
            this.panel1.TabIndex = 1;
            // 
            // btnUpload
            // 
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.ForeColor = System.Drawing.Color.Red;
            this.btnUpload.Location = new System.Drawing.Point(8, 218);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(100, 40);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "업로드";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "시작상품코드";
            // 
            // tbStartGoodsCode
            // 
            this.tbStartGoodsCode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbStartGoodsCode.Location = new System.Drawing.Point(8, 175);
            this.tbStartGoodsCode.MaxLength = 6;
            this.tbStartGoodsCode.Name = "tbStartGoodsCode";
            this.tbStartGoodsCode.Size = new System.Drawing.Size(74, 26);
            this.tbStartGoodsCode.TabIndex = 2;
            this.tbStartGoodsCode.Text = "100001";
            // 
            // btnOpenExcel
            // 
            this.btnOpenExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenExcel.Location = new System.Drawing.Point(8, 25);
            this.btnOpenExcel.Name = "btnOpenExcel";
            this.btnOpenExcel.Size = new System.Drawing.Size(100, 40);
            this.btnOpenExcel.TabIndex = 0;
            this.btnOpenExcel.Text = "엑셀불러오기";
            this.btnOpenExcel.UseVisualStyleBackColor = true;
            this.btnOpenExcel.Click += new System.EventHandler(this.btnOpenExcel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(888, 729);
            this.dataGridView1.TabIndex = 2;
            // 
            // frmSysGoodsExcelUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frmSysGoodsExcelUp";
            this.Text = "상품정보 업로드";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpenExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStartGoodsCode;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}