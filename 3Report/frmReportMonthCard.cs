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
"우리","17"
"롯데","33"
*/

namespace thepos
{
    public partial class frmReportMonthCard : Form
    {
        String yyyymm = "";

        public frmReportMonthCard()
        {
            InitializeComponent();
            initialize_the();

            thepos_app_log(1, this.Name, "open", "");
        }


        private void initialize_the()
        {
            String yyyymm = get_today_date().Substring(0, 6);
            lblYYYYMM.Text = yyyymm.Substring(0, 4) + "-" + yyyymm.Substring(4, 2);
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            yyyymm = lblYYYYMM.Text.Replace("-", ""); ;

            lvwList.Items.Clear();


            load_card_data();
        }


        private void load_card_data()
        {

            int sum_amount = 0;

            String[] card_code = new String[9] { "01", "02", "03", "06", "07", "08", "11", "17", "33" };
            int[] card_amount = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] card_amount_sum = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };


            String sUrl = "reportMonthCard?siteId=" + mSiteId + "&bizDtMon=" + yyyymm;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["monthData"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        int net_amount = 0;

                        for (int idx = 0; idx < card_code.Length; idx++)
                        {
                            card_amount[idx] = 0;
                        }

                        String tdate = arr[i]["date"].ToString();

                        JArray dailyArr = (JArray)arr[i]["dailyArr"];

                        foreach (JObject card in dailyArr)
                        {
                            string acq_code = (string)card["acqCode"];
                            int amount = (int)card["amountCard"];

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

                        ListViewItem tItem = new ListViewItem(tdate.Substring(8,2));
                        tItem.SubItems.Add(net_amount.ToString("N0"));

                        for (int k = 0; k < card_code.Length; k++)
                        {
                            tItem.SubItems.Add(card_amount[k].ToString("N0"));
                        }

                        lvwList.Items.Add(tItem);

                        sum_amount += net_amount;


                    }

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

                
            
            
            
            //



        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            DateTime CurrMonth = Convert.ToDateTime(lblYYYYMM.Text + "-01");

            DateTime PrevMonth = CurrMonth.AddMonths(-1);

            lblYYYYMM.Text = PrevMonth.ToString("yyyy-MM");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DateTime CurrMonth = Convert.ToDateTime(lblYYYYMM.Text + "-01");

            DateTime NextMonth = CurrMonth.AddMonths(1);

            lblYYYYMM.Text = NextMonth.ToString("yyyy-MM");

        }
    }
}
