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
    public partial class frmReportDayPos : Form
    {
        String thisBizDt = "";

        public frmReportDayPos()
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

            int net_amt = 0;
            int cash_amt = 0;
            int card_amt = 0;
            int easy_amt = 0;
            int cert_amt = 0;

            int tot_net_amt = 0;
            int tot_cash_amt = 0;
            int tot_card_amt = 0;
            int tot_easy_amt = 0;
            int tot_cert_amt = 0;



            thisBizDt = dtpBizDate.Value.ToString("yyyyMMdd");

            lvwList.Items.Clear();


            String sUrl = "reportDayPos?siteId=" + mSiteId + "&bizDt=" + thisBizDt;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayPos"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        net_amt = convert_number(arr[i]["netAmount"].ToString());
                        cash_amt = convert_number(arr[i]["amountCash"].ToString()) - convert_number(arr[i]["amountCashCncl"].ToString());
                        card_amt = convert_number(arr[i]["amountCard"].ToString()) - convert_number(arr[i]["amountCardCncl"].ToString());
                        easy_amt = convert_number(arr[i]["amountEasy"].ToString()) - convert_number(arr[i]["amountEasyCncl"].ToString());
                        cert_amt = convert_number(arr[i]["amountCert"].ToString()) - convert_number(arr[i]["amountCertCncl"].ToString());


                        ListViewItem Item = new ListViewItem();
                        Item.Text = arr[i]["posNo"].ToString();
                        Item.SubItems.Add(net_amt.ToString("N0"));
                        Item.SubItems.Add(cash_amt.ToString("N0"));
                        Item.SubItems.Add(card_amt.ToString("N0"));
                        Item.SubItems.Add(easy_amt.ToString("N0"));
                        Item.SubItems.Add(cert_amt.ToString("N0"));


                        lvwList.Items.Add(Item);

                        tot_net_amt += net_amt;
                        tot_cash_amt += cash_amt;
                        tot_card_amt += card_amt;
                        tot_easy_amt += easy_amt;
                        tot_cert_amt += cert_amt;
                    }

                    // 합계 표시
                    ListViewItem tItem = new ListViewItem();
                    tItem.Text = "[합계]";
                    tItem.SubItems.Add(tot_net_amt.ToString("N0"));
                    tItem.SubItems.Add(tot_cash_amt.ToString("N0"));
                    tItem.SubItems.Add(tot_card_amt.ToString("N0"));
                    tItem.SubItems.Add(tot_easy_amt.ToString("N0"));
                    tItem.SubItems.Add(tot_cert_amt.ToString("N0"));
                    lvwList.Items.Add(tItem);

                }
                else
                {
                    //MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. reportDayShop\n\n" + mErrorMsg, "thepos");
            }
        }
    }
}
