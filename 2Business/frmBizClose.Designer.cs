namespace thepos
{
    partial class frmBizClose
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
            this.lvwGoods = new System.Windows.Forms.ListView();
            this.goods_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwCard = new System.Windows.Forms.ListView();
            this.card_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.card_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.card_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwPay = new System.Windows.Forms.ListView();
            this.pay_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblLoginName = new System.Windows.Forms.Label();
            this.lblPosNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBizOpenUserTitle = new System.Windows.Forms.Label();
            this.lblBizDate = new System.Windows.Forms.Label();
            this.lblAmountCashTitle = new System.Windows.Forms.Label();
            this.btnPrintCard = new System.Windows.Forms.Button();
            this.btnPrintPay = new System.Windows.Forms.Button();
            this.btnPrintGoods = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(17, 19);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblTitle.Size = new System.Drawing.Size(766, 40);
            this.lblTitle.TabIndex = 128;
            this.lblTitle.Text = "정산";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwGoods
            // 
            this.lvwGoods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.goods_name,
            this.goods_cnt,
            this.goods_amount});
            this.lvwGoods.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwGoods.FullRowSelect = true;
            this.lvwGoods.GridLines = true;
            this.lvwGoods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwGoods.HideSelection = false;
            this.lvwGoods.Location = new System.Drawing.Point(488, 77);
            this.lvwGoods.MultiSelect = false;
            this.lvwGoods.Name = "lvwGoods";
            this.lvwGoods.Size = new System.Drawing.Size(291, 522);
            this.lvwGoods.TabIndex = 165;
            this.lvwGoods.UseCompatibleStateImageBehavior = false;
            this.lvwGoods.View = System.Windows.Forms.View.Details;
            // 
            // goods_name
            // 
            this.goods_name.Text = "품목명";
            this.goods_name.Width = 140;
            // 
            // goods_cnt
            // 
            this.goods_cnt.Text = "수량";
            this.goods_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.goods_cnt.Width = 40;
            // 
            // goods_amount
            // 
            this.goods_amount.Text = "금액";
            this.goods_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.goods_amount.Width = 90;
            // 
            // lvwCard
            // 
            this.lvwCard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.card_name,
            this.card_cnt,
            this.card_amount});
            this.lvwCard.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwCard.FullRowSelect = true;
            this.lvwCard.GridLines = true;
            this.lvwCard.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwCard.HideSelection = false;
            this.lvwCard.Location = new System.Drawing.Point(20, 192);
            this.lvwCard.MultiSelect = false;
            this.lvwCard.Name = "lvwCard";
            this.lvwCard.Size = new System.Drawing.Size(213, 407);
            this.lvwCard.TabIndex = 166;
            this.lvwCard.UseCompatibleStateImageBehavior = false;
            this.lvwCard.View = System.Windows.Forms.View.Details;
            // 
            // card_name
            // 
            this.card_name.Text = "카드사";
            // 
            // card_cnt
            // 
            this.card_cnt.Text = "수량";
            this.card_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.card_cnt.Width = 40;
            // 
            // card_amount
            // 
            this.card_amount.Text = "금액";
            this.card_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.card_amount.Width = 90;
            // 
            // lvwPay
            // 
            this.lvwPay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pay_name,
            this.pay_cnt,
            this.pay_amount});
            this.lvwPay.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwPay.FullRowSelect = true;
            this.lvwPay.GridLines = true;
            this.lvwPay.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPay.HideSelection = false;
            this.lvwPay.Location = new System.Drawing.Point(248, 77);
            this.lvwPay.MultiSelect = false;
            this.lvwPay.Name = "lvwPay";
            this.lvwPay.Size = new System.Drawing.Size(223, 522);
            this.lvwPay.TabIndex = 167;
            this.lvwPay.UseCompatibleStateImageBehavior = false;
            this.lvwPay.View = System.Windows.Forms.View.Details;
            // 
            // pay_name
            // 
            this.pay_name.Text = "결제";
            // 
            // pay_cnt
            // 
            this.pay_cnt.Text = "수량";
            this.pay_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pay_cnt.Width = 50;
            // 
            // pay_amount
            // 
            this.pay_amount.Text = "금액";
            this.pay_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pay_amount.Width = 90;
            // 
            // lblLoginName
            // 
            this.lblLoginName.BackColor = System.Drawing.Color.LightGray;
            this.lblLoginName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLoginName.ForeColor = System.Drawing.Color.Black;
            this.lblLoginName.Location = new System.Drawing.Point(120, 145);
            this.lblLoginName.Margin = new System.Windows.Forms.Padding(0);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Padding = new System.Windows.Forms.Padding(5);
            this.lblLoginName.Size = new System.Drawing.Size(113, 30);
            this.lblLoginName.TabIndex = 173;
            this.lblLoginName.Text = "0";
            this.lblLoginName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPosNo
            // 
            this.lblPosNo.BackColor = System.Drawing.Color.LightGray;
            this.lblPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNo.ForeColor = System.Drawing.Color.Black;
            this.lblPosNo.Location = new System.Drawing.Point(120, 111);
            this.lblPosNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosNo.Name = "lblPosNo";
            this.lblPosNo.Padding = new System.Windows.Forms.Padding(5);
            this.lblPosNo.Size = new System.Drawing.Size(113, 30);
            this.lblPosNo.TabIndex = 172;
            this.lblPosNo.Text = "0";
            this.lblPosNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Peru;
            this.label1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 30);
            this.label1.TabIndex = 171;
            this.label1.Text = "포스번호";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBizOpenUserTitle
            // 
            this.lblBizOpenUserTitle.BackColor = System.Drawing.Color.Peru;
            this.lblBizOpenUserTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizOpenUserTitle.ForeColor = System.Drawing.Color.White;
            this.lblBizOpenUserTitle.Location = new System.Drawing.Point(21, 145);
            this.lblBizOpenUserTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblBizOpenUserTitle.Name = "lblBizOpenUserTitle";
            this.lblBizOpenUserTitle.Size = new System.Drawing.Size(94, 30);
            this.lblBizOpenUserTitle.TabIndex = 170;
            this.lblBizOpenUserTitle.Text = "담당자";
            this.lblBizOpenUserTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBizDate
            // 
            this.lblBizDate.BackColor = System.Drawing.Color.LightGray;
            this.lblBizDate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizDate.ForeColor = System.Drawing.Color.Black;
            this.lblBizDate.Location = new System.Drawing.Point(120, 77);
            this.lblBizDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblBizDate.Name = "lblBizDate";
            this.lblBizDate.Padding = new System.Windows.Forms.Padding(5);
            this.lblBizDate.Size = new System.Drawing.Size(113, 30);
            this.lblBizDate.TabIndex = 169;
            this.lblBizDate.Text = "0";
            this.lblBizDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmountCashTitle
            // 
            this.lblAmountCashTitle.BackColor = System.Drawing.Color.Peru;
            this.lblAmountCashTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAmountCashTitle.ForeColor = System.Drawing.Color.White;
            this.lblAmountCashTitle.Location = new System.Drawing.Point(21, 77);
            this.lblAmountCashTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblAmountCashTitle.Name = "lblAmountCashTitle";
            this.lblAmountCashTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblAmountCashTitle.Size = new System.Drawing.Size(94, 30);
            this.lblAmountCashTitle.TabIndex = 168;
            this.lblAmountCashTitle.Text = "영업일자";
            this.lblAmountCashTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrintCard
            // 
            this.btnPrintCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintCard.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrintCard.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnPrintCard.Location = new System.Drawing.Point(72, 623);
            this.btnPrintCard.Name = "btnPrintCard";
            this.btnPrintCard.Size = new System.Drawing.Size(120, 40);
            this.btnPrintCard.TabIndex = 174;
            this.btnPrintCard.Text = "출력";
            this.btnPrintCard.UseVisualStyleBackColor = false;
            this.btnPrintCard.Click += new System.EventHandler(this.btnPrintCard_Click);
            // 
            // btnPrintPay
            // 
            this.btnPrintPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPay.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrintPay.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnPrintPay.Location = new System.Drawing.Point(310, 623);
            this.btnPrintPay.Name = "btnPrintPay";
            this.btnPrintPay.Size = new System.Drawing.Size(120, 40);
            this.btnPrintPay.TabIndex = 175;
            this.btnPrintPay.Text = "출력";
            this.btnPrintPay.UseVisualStyleBackColor = false;
            // 
            // btnPrintGoods
            // 
            this.btnPrintGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintGoods.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrintGoods.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnPrintGoods.Location = new System.Drawing.Point(580, 623);
            this.btnPrintGoods.Name = "btnPrintGoods";
            this.btnPrintGoods.Size = new System.Drawing.Size(120, 40);
            this.btnPrintGoods.TabIndex = 176;
            this.btnPrintGoods.Text = "출력";
            this.btnPrintGoods.UseVisualStyleBackColor = false;
            // 
            // frmBizClose
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.btnPrintGoods);
            this.Controls.Add(this.btnPrintPay);
            this.Controls.Add(this.btnPrintCard);
            this.Controls.Add(this.lblLoginName);
            this.Controls.Add(this.lblPosNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBizOpenUserTitle);
            this.Controls.Add(this.lblBizDate);
            this.Controls.Add(this.lblAmountCashTitle);
            this.Controls.Add(this.lvwPay);
            this.Controls.Add(this.lvwCard);
            this.Controls.Add(this.lvwGoods);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBizClose";
            this.Text = "frmBizClose";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwGoods;
        private System.Windows.Forms.ColumnHeader goods_name;
        private System.Windows.Forms.ColumnHeader goods_cnt;
        private System.Windows.Forms.ColumnHeader goods_amount;
        private System.Windows.Forms.ListView lvwCard;
        private System.Windows.Forms.ColumnHeader card_name;
        private System.Windows.Forms.ColumnHeader card_cnt;
        private System.Windows.Forms.ColumnHeader card_amount;
        private System.Windows.Forms.ListView lvwPay;
        private System.Windows.Forms.ColumnHeader pay_name;
        private System.Windows.Forms.ColumnHeader pay_cnt;
        private System.Windows.Forms.ColumnHeader pay_amount;
        private System.Windows.Forms.Label lblLoginName;
        private System.Windows.Forms.Label lblPosNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBizOpenUserTitle;
        private System.Windows.Forms.Label lblBizDate;
        private System.Windows.Forms.Label lblAmountCashTitle;
        private System.Windows.Forms.Button btnPrintCard;
        private System.Windows.Forms.Button btnPrintPay;
        private System.Windows.Forms.Button btnPrintGoods;
    }
}