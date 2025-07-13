using ClosedXML.Excel;
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
    public partial class frmReportMonthCoupon : Form
    {
        String yyyymm = "";


        List<String> list_coupon_link_no = new List<string>();
        int[] coupon_cnt;
        int[] coupon_amount;
        int amount_sum = 0;
        int cnt_sum = 0;

        int[] tot_cnt;
        int[] tot_amount;
        int amount_tot = 0;
        int cnt_tot = 0;


        public frmReportMonthCoupon()
        {
            InitializeComponent();
            initialize_the();

            thepos_app_log(1, this.Name, "open", "");

            //
            for (int i = 0; i < mGoodsList.Count; i++)
            {
                if (mGoodsList[i].coupon_link_no != "")
                {
                    list_coupon_link_no.Add(mGoodsList[i].coupon_link_no);
                }
            }


            //
            coupon_cnt = new int[list_coupon_link_no.Count];
            coupon_amount = new int[list_coupon_link_no.Count];

            tot_cnt = new int[list_coupon_link_no.Count];
            tot_amount = new int[list_coupon_link_no.Count];


            //
            //lvwList.Columns.Add("일자", 50, HorizontalAlignment.Left);

            lvwList.Columns.Add("수량", 50, HorizontalAlignment.Right);
            lvwList.Columns.Add("사용금액", 80, HorizontalAlignment.Right);

            for (int i = 0; i < list_coupon_link_no.Count; i++)
            {
                lvwList.Columns.Add("수량", 50, HorizontalAlignment.Right);
                lvwList.Columns.Add(get_goods_name_by_coupon_link_no(list_coupon_link_no[i]), 80, HorizontalAlignment.Right);
            }
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
            //
            for (int k = 0; k < list_coupon_link_no.Count; k++)
            {
                tot_cnt[k] = 0;
                tot_amount[k] = 0;
            }

            amount_tot = 0;
            cnt_tot = 0;


            //
            String sUrl = "reportMonthCert?siteId=" + mSiteId + "&bizDtMon=" + yyyymm;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["monthData"].ToString();
                    JArray arr = JArray.Parse(data);


                    //
                    for (int i = 0; i < arr.Count; i++)
                    {
                        amount_sum = 0;
                        cnt_sum = 0;

                        for (int idx = 0; idx < coupon_cnt.Length; idx++)
                        {
                            coupon_cnt[idx] = 0;
                            coupon_amount[idx] = 0;
                        }


                        String tdate = arr[i]["date"].ToString();

                        JArray dailyArr = (JArray)arr[i]["dailyArr"];

                        foreach (JObject coupon in dailyArr)
                        {
                            string link_no = (string)coupon["couponLinkNo"];
                            int cnt = (int)coupon["cnt"];
                            int amount = (int)coupon["amountCert"];

                            for (int idx = 0; idx < list_coupon_link_no.Count; idx++)
                            {
                                if (link_no == list_coupon_link_no[idx])
                                {
                                    coupon_cnt[idx] = cnt;
                                    coupon_amount[idx] += amount;
                                    amount_sum += amount;
                                    cnt_sum += cnt;
                                }
                            }
                        }


                        ListViewItem tItem = new ListViewItem(tdate.Substring(8, 2));
                        tItem.SubItems.Add(cnt_sum.ToString("N0"));
                        tItem.SubItems.Add(amount_sum.ToString("N0"));

                        for (int k = 0; k < list_coupon_link_no.Count; k++)
                        {
                            tItem.SubItems.Add(coupon_cnt[k].ToString("N0"));
                            tItem.SubItems.Add(coupon_amount[k].ToString("N0"));
                        }

                        lvwList.Items.Add(tItem);


                        // tot
                        cnt_tot += cnt_sum;
                        amount_tot += amount_sum;

                        for (int k = 0; k < list_coupon_link_no.Count; k++)
                        {
                            tot_cnt[k] += coupon_cnt[k];
                            tot_amount[k] += coupon_amount[k];
                        }
                    }

                    //
                    ListViewItem sItem = new ListViewItem("합계");
                    sItem.SubItems.Add(cnt_tot.ToString("N0"));
                    sItem.SubItems.Add(amount_tot.ToString("N0"));

                    for (int k = 0; k < list_coupon_link_no.Count; k++)
                    {
                        sItem.SubItems.Add(tot_cnt[k].ToString("N0"));
                        sItem.SubItems.Add(tot_amount[k].ToString("N0"));
                    }

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

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            if (lvwList.Items.Count == 0)
            {
                return;
            }

            //
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "TM_" + mSiteAlias + "_" + "월간 쿠폰사용내역" + "_" + lblYYYYMM.Text + ".xlsx";
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Save Excel File";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportListViewToExcel(lvwList, sfd.FileName, lblYYYYMM.Text);
                    MessageBox.Show("엑셀 파일로 저장되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


    }
}
