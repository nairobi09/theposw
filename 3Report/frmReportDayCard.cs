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
using static thepos.thePos;


/*
"비씨","01"
"KB국민","02"
"하나","03"
"삼성","06"
"신한","07"
"현대","08"
"NH농협","10"
"우리","17"
"롯데","33"
*/

namespace thepos
{
    public partial class frmReportDayCard : Form
    {
        String thisBizDt = "";

        public frmReportDayCard()
        {
            InitializeComponent();
            initialize_the();

            thepos_app_log(1, this.Name, "open", "");
        }


        private void initialize_the()
        {

            if (mBizDate == "")
            {

            }
            else
            {
                dtpBizDate.Value = new DateTime(convert_number(mBizDate.Substring(0, 4)), convert_number(mBizDate.Substring(4, 2)), convert_number(mBizDate.Substring(6, 2)));
            }
            


        }

        private void btnView_Click(object sender, EventArgs e)
        {

            thisBizDt = dtpBizDate.Value.ToString("yyyyMMdd");

            lvwList.Items.Clear();


            load_card_data();
        }


        /*
        "비씨","01"
        "KB국민","02"
        "하나","03"
        "삼성","06"
        "신한","07"
        "현대","08"
        "우리","17"
        "롯데","33"
        */


        private void load_card_data()
        {


            int sum_amount = 0;

            String[] card_code = new String[9] { "01", "02", "03", "06", "07", "08", "11", "17", "33" };
            int[] card_amount = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] card_amount_sum = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };



            for (int pos_idx = 0; pos_idx < mPosNoList.Count; pos_idx++)
            {
                String sUrl = "reportDailyCardPos?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&posNo=" + mPosNoList[pos_idx];

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["dailyArr"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count > 0)
                        {
                            for (int idx = 0; idx < card_amount.Length; idx++)
                            {
                                card_amount[idx] = 0;
                            }

                            int net_amount = 0;

                            for (int i = 0; i < arr.Count; i++)
                            {
                                String acq_code = arr[i]["acqCode"].ToString();
                                int amount = convert_number(arr[i]["amountCard"].ToString());

                                for (int idx = 0; idx < card_code.Length - 1; idx++)
                                {
                                    if (acq_code == card_code[idx])
                                    {
                                        card_amount[idx] = amount;
                                        card_amount_sum[idx] += amount;
                                        net_amount += amount;
                                    }
                                }
                            }

                            ListViewItem tItem = new ListViewItem(mPosNoList[pos_idx]);
                            tItem.SubItems.Add(net_amount.ToString("N0"));

                            for (int i = 0; i < card_amount.Length; i++)
                            {
                                tItem.SubItems.Add(card_amount[i].ToString("N0"));
                            }

                            lvwList.Items.Add(tItem);

                            sum_amount += net_amount;

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

            //
            //
            ListViewItem sItem = new ListViewItem("합계");
            sItem.SubItems.Add(sum_amount.ToString("N0"));

            for (int i = 0; i < card_code.Length; i++)
            {
                sItem.SubItems.Add(card_amount_sum[i].ToString("N0"));
            }

            lvwList.Items.Add(sItem);




        }
    }
}
