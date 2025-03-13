namespace theposw
{
    partial class frmAllimCP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllimCP));
            this.shop_order_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwOrderShop = new System.Windows.Forms.ListView();
            this.allim_status_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shop_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.order_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.allim_type_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hhp_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.allim_type_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.allim_status_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.the_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shop_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lbl1 = new System.Windows.Forms.Label();
            this.dtpBizDate = new System.Windows.Forms.DateTimePicker();
            this.lbl2 = new System.Windows.Forms.Label();
            this.amount_card = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.amount_etc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbShop = new System.Windows.Forms.ComboBox();
            this.cnt_item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwOrderItem = new System.Windows.Forms.ListView();
            this.btnAllimSendCP = new System.Windows.Forms.Button();
            this.panelback = new System.Windows.Forms.Panel();
            this.btnAllimFinish = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelback.SuspendLayout();
            this.SuspendLayout();
            // 
            // shop_order_no
            // 
            this.shop_order_no.Text = "주문#";
            this.shop_order_no.Width = 50;
            // 
            // lvwOrderShop
            // 
            this.lvwOrderShop.BackColor = System.Drawing.Color.White;
            this.lvwOrderShop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.allim_status_name,
            this.shop_name,
            this.shop_order_no,
            this.order_time,
            this.cnt,
            this.allim_type_name,
            this.hhp_no,
            this.cancel,
            this.allim_type_code,
            this.allim_status_code,
            this.the_no,
            this.shop_code});
            this.lvwOrderShop.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwOrderShop.ForeColor = System.Drawing.Color.Black;
            this.lvwOrderShop.FullRowSelect = true;
            this.lvwOrderShop.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwOrderShop.HideSelection = false;
            this.lvwOrderShop.Location = new System.Drawing.Point(20, 141);
            this.lvwOrderShop.MultiSelect = false;
            this.lvwOrderShop.Name = "lvwOrderShop";
            this.lvwOrderShop.Size = new System.Drawing.Size(482, 284);
            this.lvwOrderShop.SmallImageList = this.imageList;
            this.lvwOrderShop.TabIndex = 44;
            this.lvwOrderShop.UseCompatibleStateImageBehavior = false;
            this.lvwOrderShop.View = System.Windows.Forms.View.Details;
            this.lvwOrderShop.SelectedIndexChanged += new System.EventHandler(this.lvwOrderShop_SelectedIndexChanged);
            // 
            // allim_status_name
            // 
            this.allim_status_name.Text = "상태";
            this.allim_status_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.allim_status_name.Width = 50;
            // 
            // shop_name
            // 
            this.shop_name.Text = "업장";
            this.shop_name.Width = 50;
            // 
            // order_time
            // 
            this.order_time.Text = "주문시간";
            this.order_time.Width = 70;
            // 
            // cnt
            // 
            this.cnt.Text = "항목수";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cnt.Width = 55;
            // 
            // allim_type_name
            // 
            this.allim_type_name.Text = "타입";
            // 
            // hhp_no
            // 
            this.hhp_no.Text = "TEL";
            // 
            // cancel
            // 
            this.cancel.DisplayIndex = 9;
            this.cancel.Text = "취소";
            // 
            // allim_type_code
            // 
            this.allim_type_code.DisplayIndex = 7;
            this.allim_type_code.Text = "";
            this.allim_type_code.Width = 0;
            // 
            // allim_status_code
            // 
            this.allim_status_code.DisplayIndex = 8;
            this.allim_status_code.Text = "";
            this.allim_status_code.Width = 0;
            // 
            // the_no
            // 
            this.the_no.Text = "the_no";
            this.the_no.Width = 0;
            // 
            // shop_code
            // 
            this.shop_code.Text = "shop_code";
            this.shop_code.Width = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ic_step_order.png");
            this.imageList.Images.SetKeyName(1, "ic_step_allim.png");
            this.imageList.Images.SetKeyName(2, "ic_step_finish.png");
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lbl1.Location = new System.Drawing.Point(12, 13);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(53, 12);
            this.lbl1.TabIndex = 71;
            this.lbl1.Text = "영업일자";
            // 
            // dtpBizDate
            // 
            this.dtpBizDate.CalendarFont = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBizDate.Location = new System.Drawing.Point(14, 30);
            this.dtpBizDate.Name = "dtpBizDate";
            this.dtpBizDate.Size = new System.Drawing.Size(100, 23);
            this.dtpBizDate.TabIndex = 68;
            this.dtpBizDate.TabStop = false;
            this.dtpBizDate.Value = new System.DateTime(2023, 5, 19, 0, 0, 0, 0);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lbl2.Location = new System.Drawing.Point(121, 13);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(29, 12);
            this.lbl2.TabIndex = 69;
            this.lbl2.Text = "업장";
            // 
            // amount_card
            // 
            this.amount_card.Text = "금액";
            this.amount_card.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount_card.Width = 80;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnView.Location = new System.Drawing.Point(369, 13);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 40);
            this.btnView.TabIndex = 72;
            this.btnView.TabStop = false;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Gold;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(463, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 43;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Gold;
            this.lblTitle.Font = new System.Drawing.Font("굴림체", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 39);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "주문알림";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // amount_etc
            // 
            this.amount_etc.Text = "기타";
            this.amount_etc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount_etc.Width = 40;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbShop);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.dtpBizDate);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(20, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 67);
            this.panel1.TabIndex = 77;
            // 
            // cbShop
            // 
            this.cbShop.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbShop.FormattingEnabled = true;
            this.cbShop.Location = new System.Drawing.Point(123, 30);
            this.cbShop.Name = "cbShop";
            this.cbShop.Size = new System.Drawing.Size(92, 24);
            this.cbShop.TabIndex = 94;
            this.cbShop.TabStop = false;
            // 
            // cnt_item
            // 
            this.cnt_item.Text = "수량/옵션";
            this.cnt_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cnt_item.Width = 100;
            // 
            // name
            // 
            this.name.Text = "상품/옵션명";
            this.name.Width = 180;
            // 
            // lvwOrderItem
            // 
            this.lvwOrderItem.BackColor = System.Drawing.Color.White;
            this.lvwOrderItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.cnt_item});
            this.lvwOrderItem.Font = new System.Drawing.Font("굴림체", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwOrderItem.ForeColor = System.Drawing.Color.Black;
            this.lvwOrderItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwOrderItem.HideSelection = false;
            this.lvwOrderItem.Location = new System.Drawing.Point(20, 433);
            this.lvwOrderItem.MultiSelect = false;
            this.lvwOrderItem.Name = "lvwOrderItem";
            this.lvwOrderItem.Size = new System.Drawing.Size(329, 252);
            this.lvwOrderItem.TabIndex = 80;
            this.lvwOrderItem.TabStop = false;
            this.lvwOrderItem.UseCompatibleStateImageBehavior = false;
            this.lvwOrderItem.View = System.Windows.Forms.View.Details;
            // 
            // btnAllimSendCP
            // 
            this.btnAllimSendCP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnAllimSendCP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllimSendCP.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAllimSendCP.ForeColor = System.Drawing.Color.White;
            this.btnAllimSendCP.Location = new System.Drawing.Point(355, 433);
            this.btnAllimSendCP.Name = "btnAllimSendCP";
            this.btnAllimSendCP.Size = new System.Drawing.Size(146, 80);
            this.btnAllimSendCP.TabIndex = 48;
            this.btnAllimSendCP.TabStop = false;
            this.btnAllimSendCP.Text = "알림\r\n발송하기";
            this.btnAllimSendCP.UseVisualStyleBackColor = false;
            this.btnAllimSendCP.Click += new System.EventHandler(this.btnAllimSendCP_Click);
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.btnAllimFinish);
            this.panelback.Controls.Add(this.lvwOrderItem);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.btnAllimSendCP);
            this.panelback.Controls.Add(this.lvwOrderShop);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 4;
            // 
            // btnAllimFinish
            // 
            this.btnAllimFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnAllimFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllimFinish.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAllimFinish.ForeColor = System.Drawing.Color.White;
            this.btnAllimFinish.Location = new System.Drawing.Point(355, 519);
            this.btnAllimFinish.Name = "btnAllimFinish";
            this.btnAllimFinish.Size = new System.Drawing.Size(146, 80);
            this.btnAllimFinish.TabIndex = 81;
            this.btnAllimFinish.TabStop = false;
            this.btnAllimFinish.Text = "완료\r\n";
            this.btnAllimFinish.UseVisualStyleBackColor = false;
            this.btnAllimFinish.Click += new System.EventHandler(this.btnAllimFinish_Click);
            // 
            // frmAllimCP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAllimCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmAllimCP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAllimCP_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelback.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader shop_order_no;
        private System.Windows.Forms.ListView lvwOrderShop;
        private System.Windows.Forms.ColumnHeader order_time;
        private System.Windows.Forms.ColumnHeader cnt;
        private System.Windows.Forms.ColumnHeader allim_status_name;
        private System.Windows.Forms.ColumnHeader allim_type_code;
        private System.Windows.Forms.ColumnHeader allim_status_code;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DateTimePicker dtpBizDate;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.ColumnHeader amount_card;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader amount_etc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader cnt_item;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ListView lvwOrderItem;
        private System.Windows.Forms.Button btnAllimSendCP;
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.ComboBox cbShop;
        private System.Windows.Forms.ColumnHeader hhp_no;
        private System.Windows.Forms.ColumnHeader shop_name;
        private System.Windows.Forms.ColumnHeader allim_type_name;
        private System.Windows.Forms.ColumnHeader cancel;
        private System.Windows.Forms.ColumnHeader the_no;
        private System.Windows.Forms.ColumnHeader shop_code;
        private System.Windows.Forms.Button btnAllimFinish;
        private System.Windows.Forms.ImageList imageList;
    }
}