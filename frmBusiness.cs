using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;
using static thepos.frmMain;
using static thepos.frmBizLastSettlement;


namespace thepos
{
    public partial class frmBusiness : Form
    {

        public static TextBox mTbKeyController;



        String mThisButtonClick = "";


        public frmBusiness()
        {
            InitializeComponent();

            initialize_the();

            thepos_app_log(1, this.Name, "open", "");

        }



        private void initialize_the()
        {

            btnKey1.Click += (sender, args) => ClickedKey("1");
            btnKey2.Click += (sender, args) => ClickedKey("2");
            btnKey3.Click += (sender, args) => ClickedKey("3");
            btnKey4.Click += (sender, args) => ClickedKey("4");
            btnKey5.Click += (sender, args) => ClickedKey("5");
            btnKey6.Click += (sender, args) => ClickedKey("6");
            btnKey7.Click += (sender, args) => ClickedKey("7");
            btnKey8.Click += (sender, args) => ClickedKey("8");
            btnKey9.Click += (sender, args) => ClickedKey("9");
            btnKey0.Click += (sender, args) => ClickedKey("0");
            btnKeyBS.Click += (sender, args) => ClickedKey("BS");
            btnKeyClear.Click += (sender, args) => ClickedKey("Clear");
            btnKeyTab.Click += (sender, args) => ClickedKey("Tab");

        }

        private void ClickedKey(string sKey)
        {

            if (mTbKeyController == null) return;

            if (sKey == "BS")
            {
                if (mTbKeyController.SelectionLength > 0)
                {
                    // 선택된 텍스트 삭제
                    int selStart = mTbKeyController.SelectionStart;
                    string newText = mTbKeyController.Text.Remove(selStart, mTbKeyController.SelectionLength);
                    mTbKeyController.Text = newText;

                    // 커서 위치 재설정
                    mTbKeyController.SelectionStart = selStart;
                }


                if (mTbKeyController.Text.Length > 0)
                {
                    mTbKeyController.Text = mTbKeyController.Text.Substring(0, mTbKeyController.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                mTbKeyController.Text = "";
            }
            else if (sKey == "Tab")
            {
                if (mThisButtonClick != "BizLastSettlementClose")
                {
                    return;
                }


                if (mTbKeyController.Name == "tb50000")
                {
                    mTbKeyController = ptb10000;
                }
                else if (mTbKeyController.Name == "tb10000")
                {
                    mTbKeyController = ptb5000;
                }
                else if (mTbKeyController.Name == "tb5000")
                {
                    mTbKeyController = ptb1000;
                }
                else if (mTbKeyController.Name == "tb1000")
                {
                    mTbKeyController = ptb500;
                }
                else if (mTbKeyController.Name == "tb500")
                {
                    mTbKeyController = ptb100;
                }
                else if (mTbKeyController.Name == "tb100")
                {
                    mTbKeyController = ptb50;
                }
                else if (mTbKeyController.Name == "tb50")
                {
                    mTbKeyController = ptb10;
                }
                else if (mTbKeyController.Name == "tb10")
                {
                    mTbKeyController = ptbEtc;
                }
                else if (mTbKeyController.Name == "tbEtc")
                {
                    mTbKeyController = ptb50000;
                }


                mTbKeyController.Focus();



            }
            else
            {
                if (mTbKeyController.SelectionLength > 0)
                {
                    // 선택된 텍스트 삭제
                    int selStart = mTbKeyController.SelectionStart;
                    string newText = mTbKeyController.Text.Remove(selStart, mTbKeyController.SelectionLength);
                    mTbKeyController.Text = newText;

                    // 커서 위치 재설정
                    mTbKeyController.SelectionStart = selStart;
                }

                mTbKeyController.Text += sKey;
            }
        }




        // 메뉴버튼

        // 준비금
        private void btnBizOpen_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "BizOpen") return;

            mThisButtonClick = "BizOpen";
            panelBiz.Controls.Clear();

            frmBizOpen fBiz = new frmBizOpen() { TopLevel = false, TopMost = true };
            panelBiz.Controls.Add(fBiz);
            fBiz.Show();
        }

        // 시제점검 xx
        private void btnCashCheck_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "BizCashCheck") return;

            mThisButtonClick = "BizCashCheck";
            panelBiz.Controls.Clear();

            frmBizCashCheck fBiz = new frmBizCashCheck() { TopLevel = false, TopMost = true };
            panelBiz.Controls.Add(fBiz);
            fBiz.Show();
        }


        // 정산 xx
        private void btnBizSettlement_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "BizClose") return;

            mThisButtonClick = "BizClose";
            panelBiz.Controls.Clear();

            frmBizSettlement fBiz = new frmBizSettlement() { TopLevel = false, TopMost = true };
            panelBiz.Controls.Add(fBiz);
            fBiz.Show();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            thepos_app_log(1, this.Name, "close", "");

            Close();

            mPanelDivision.Visible = false;
        }

        // 마감정산
        private void btnBizLastSettlement_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "BizLastSettlementClose") return;

            mThisButtonClick = "BizLastSettlementClose";
            panelBiz.Controls.Clear();

            frmBizLastSettlement fBiz = new frmBizLastSettlement() { TopLevel = false, TopMost = true };
            panelBiz.Controls.Add(fBiz);
            fBiz.Show();
        }
    }
}
