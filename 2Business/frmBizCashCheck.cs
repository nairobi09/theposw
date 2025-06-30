using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static thepos.thePos;
using static thepos.frmBusiness;

namespace thepos
{
    public partial class frmBizCashCheck : Form
    {
        bool isNew = true;


        int cash_amount = 0;  // 현금매출금액
        int cash_amount_cncl = 0;  // 현금매출취소금액

        int cash_starting = 0;  // 준비금


        int cnt_50000 = 0;
        int cnt_10000 = 0;
        int cnt_5000 = 0;
        int cnt_1000 = 0;
        int cnt_500 = 0;
        int cnt_100 = 0;
        int cnt_50 = 0;
        int cnt_10 = 0;
        int amount_etc = 0;
        int amount_50000 = 0;
        int amount_10000 = 0;
        int amount_5000 = 0;
        int amount_1000 = 0;
        int amount_500 = 0;
        int amount_100 = 0;
        int amount_50 = 0;
        int amount_10 = 0;
        int amount_real_sum = 0;



        public frmBizCashCheck()
        {
            InitializeComponent();

            //
            thepos_app_log(1, this.Name, "open", "");



            initialize_the();


            //
            lblBizDt.Text = mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);


            load_cash_amount();  // 현금매출액 구하기
            lblCashAmount.Text = (cash_amount - cash_amount_cncl).ToString("N0");


            load_cash_info();  // 준비금 구하기
            lblCashStarting.Text = cash_starting.ToString("N0");


            calculate_cash_real();

        }


        private void initialize_the()
        {


        }

        private void calculate_cash_real()
        {
            amount_real_sum = amount_etc + amount_50000 + amount_10000 + amount_5000 + amount_1000 + amount_500 + amount_100 + amount_50 + amount_10;

            lblSum.Text = amount_real_sum.ToString("N0");

            lblCashReal.Text = amount_real_sum.ToString("N0");

            int int과부족 = amount_real_sum - (cash_amount + cash_starting);

            lblCashDiff.Text = int과부족.ToString("N0");

        }


        private void load_cash_amount()
        {
            String sUrl = "reportDayPos?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayPos"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        cash_amount = convert_number(arr[0]["amountCash"].ToString());
                        cash_amount_cncl = convert_number(arr[0]["amountCashCncl"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void load_cash_info()
        {
            String sUrl = "reportDailyCash?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dailyCash"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        cash_starting = convert_number(arr[i]["startingCash"].ToString());

                        cnt_50000 = convert_number(arr[i]["fiftyKCnt"].ToString());
                        cnt_10000 = convert_number(arr[i]["tenKCnt"].ToString());
                        cnt_5000 = convert_number(arr[i]["fiveKCnt"].ToString());
                        cnt_1000 = convert_number(arr[i]["oneKCnt"].ToString());
                        cnt_500 = convert_number(arr[i]["fiveHCnt"].ToString());
                        cnt_100 = convert_number(arr[i]["oneHCnt"].ToString());
                        cnt_50 = convert_number(arr[i]["fiftyCnt"].ToString());
                        cnt_10 = convert_number(arr[i]["tenCnt"].ToString());
                        amount_etc = convert_number(arr[i]["etcAmount"].ToString());


                        lblCashStarting.Text = cash_starting.ToString("N0");
                        tb50000.Text = cnt_50000.ToString();
                        tb10000.Text = cnt_10000.ToString();
                        tb5000.Text = cnt_5000.ToString();
                        tb1000.Text = cnt_1000.ToString();
                        tb500.Text = cnt_500.ToString();
                        tb100.Text = cnt_100.ToString();
                        tb50.Text = cnt_50.ToString();
                        tbEtc.Text = amount_etc.ToString();

                        isNew = false;

                    }
                }
                else
                {
                    //MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }


        private void btnBizCloseInput_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = mBizDate;
            parameters["posNo"] = myPosNo;

            parameters["etcAmount"] = amount_etc + "";
            parameters["fiftyKCnt"] = cnt_50000 + "";
            parameters["tenKCnt"] = cnt_10000 + "";
            parameters["fiveKCnt"] = cnt_5000 + "";
            parameters["oneKCnt"] = cnt_1000 + "";
            parameters["fiveHCnt"] = cnt_500 + "";
            parameters["oneHCnt"] = cnt_100 + "";
            parameters["fiftyCnt"] = cnt_50 + "";
            parameters["tenCnt"] = cnt_10 + "";

            bool ret;

            if (isNew)
            {
                ret = mRequestPost("reportDailyCash", parameters);
            }
            else
            {
                ret = mRequestPatch("reportDailyCash", parameters);
            }

            if (ret)
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("시제 입력 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }



        private void tbEtc_TextChanged(object sender, EventArgs e)
        {
            amount_etc = convert_number(tbEtc.Text);
            calculate_cash_real();
        }

        private void tb50000_TextChanged(object sender, EventArgs e)
        {
            cnt_50000 = convert_number(tb50000.Text);
            amount_50000 = cnt_50000 * 50000;
            lbl50000.Text = amount_50000.ToString("N0");
            calculate_cash_real();
        }

        private void tb10000_TextChanged(object sender, EventArgs e)
        {
            cnt_10000 = convert_number(tb10000.Text);
            amount_10000 = cnt_10000 * 10000;
            lbl10000.Text = amount_10000.ToString("N0");
            calculate_cash_real();
        }

        private void tb5000_TextChanged(object sender, EventArgs e)
        {
            cnt_5000 = convert_number(tb5000.Text);
            amount_5000 = cnt_5000 * 5000;
            lbl5000.Text = amount_5000.ToString("N0");
            calculate_cash_real();
        }

        private void tb1000_TextChanged(object sender, EventArgs e)
        {
            cnt_1000 = convert_number(tb1000.Text);
            amount_1000 = cnt_1000 * 1000;
            lbl1000.Text = amount_1000.ToString("N0");
            calculate_cash_real();
        }

        private void tb500_TextChanged(object sender, EventArgs e)
        {
            cnt_500 = convert_number(tb500.Text);
            amount_500 = cnt_500 * 500;
            lbl500.Text = amount_500.ToString("N0");
            calculate_cash_real();
        }

        private void tb100_TextChanged(object sender, EventArgs e)
        {
            cnt_100 = convert_number(tb100.Text);
            amount_100 = cnt_100 * 100;
            lbl100.Text = amount_100.ToString("N0");
            calculate_cash_real();
        }

        private void tb50_TextChanged(object sender, EventArgs e)
        {
            cnt_50 = convert_number(tb50.Text);
            amount_50 = cnt_50 * 50;
            lbl50.Text = amount_50.ToString("N0");
            calculate_cash_real();
        }

        private void tb10_TextChanged(object sender, EventArgs e)
        {
            cnt_10 = convert_number(tb10.Text);
            amount_10 = cnt_10 * 10;
            lbl10.Text = amount_10.ToString("N0");
            calculate_cash_real();
        }



        private void tbEtc_Enter(object sender, EventArgs e)
        {
            tbEtc.SelectAll();
            mTbKeyController = tbEtc;
        }

        private void tb50000_Enter(object sender, EventArgs e)
        {
            tb50000.SelectAll();
            mTbKeyController = tb50000;
        }

        private void tb10000_Enter(object sender, EventArgs e)
        {
            tb10000.SelectAll();
            mTbKeyController = tb10000;
        }

        private void tb5000_Enter(object sender, EventArgs e)
        {
            tb5000.SelectAll();
            mTbKeyController = tb5000;
        }

        private void tb1000_Enter(object sender, EventArgs e)
        {
            tb1000.SelectAll();
            mTbKeyController = tb1000;
        }

        private void tb500_Enter(object sender, EventArgs e)
        {
            tb500.SelectAll();
            mTbKeyController = tb500;
        }

        private void tb100_Enter(object sender, EventArgs e)
        {
            tb100.SelectAll();
            mTbKeyController = tb100;
        }

        private void tb50_Enter(object sender, EventArgs e)
        {
            tb50.SelectAll();
            mTbKeyController = tb50;
        }

        private void tb10_Enter(object sender, EventArgs e)
        {
            tb10.SelectAll();
            mTbKeyController = tb10;
        }

        private void tb50000_MouseDown(object sender, MouseEventArgs e)
        {
            tb50000.SelectAll();
            mTbKeyController = tb50000;
        }

        private void tb10000_MouseDown(object sender, MouseEventArgs e)
        {
            tb10000.SelectAll();
            mTbKeyController = tb10000;
        }

        private void tb5000_MouseDown(object sender, MouseEventArgs e)
        {
            tb5000.SelectAll();
            mTbKeyController = tb5000;
        }

        private void tb1000_MouseDown(object sender, MouseEventArgs e)
        {
            tb1000.SelectAll();
            mTbKeyController = tb1000;
        }

        private void tb500_MouseDown(object sender, MouseEventArgs e)
        {
            tb500.SelectAll();
            mTbKeyController = tb500;
        }

        private void tb100_MouseDown(object sender, MouseEventArgs e)
        {
            tb100.SelectAll();
            mTbKeyController = tb100;
        }

        private void tb50_MouseDown(object sender, MouseEventArgs e)
        {
            tb50.SelectAll();
            mTbKeyController = tb50;
        }

        private void tb10_MouseDown(object sender, MouseEventArgs e)
        {
            tb10.SelectAll();
            mTbKeyController = tb10;
        }

        private void tbEtc_MouseDown(object sender, MouseEventArgs e)
        {
            tbEtc.SelectAll();
            mTbKeyController = tbEtc;
        }
    }
}
