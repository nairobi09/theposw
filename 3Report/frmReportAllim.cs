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

namespace thepos
{
    public partial class frmReportAllim : Form
    {
        String yyyymm = "";


        public frmReportAllim()
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


            load_data();
        }


        private void load_data()
        {
            int sum_cnt = 0;

            String sUrl = "reportMonthAllim?siteId=" + mSiteId + "&bizDtMon=" + yyyymm;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dailyAllim"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        String tdate = arr[i]["bizDt"].ToString();
                        int cnt = (int)arr[i]["cnt"];

                        ListViewItem tItem = new ListViewItem(tdate.Substring(6, 2));
                        tItem.SubItems.Add(cnt.ToString("N0"));
                        lvwList.Items.Add(tItem);

                        sum_cnt += cnt;
                    }

                    //
                    ListViewItem sItem = new ListViewItem("합계");
                    sItem.SubItems.Add(sum_cnt.ToString("N0"));
                    lvwList.Items.Add(sItem);
                }
            }
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
