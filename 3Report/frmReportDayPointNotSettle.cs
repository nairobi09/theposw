using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace thepos
{
    public partial class frmReportDayPointNotSettle : Form
    {
        String thisBizDt = "";

        public frmReportDayPointNotSettle()
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
            lvwOrder.Items.Clear();


            string sUrl = "paymentPoint?siteId=" + mSiteId + "&bizDt=" + thisBizDt;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentPoints"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();

                        lvItem.Tag = arr[i]["theNo"].ToString();
                        lvItem.Text = arr[i]["theNo"].ToString().Substring(14,6);
                        lvItem.SubItems.Add(arr[i]["lockerNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());

                        string pay_dt = arr[i]["payTime"].ToString();
                        lvItem.SubItems.Add(pay_dt.Substring(0,2) + ":" + pay_dt.Substring(2, 2) + ":" + pay_dt.Substring(4, 2));

                        lvItem.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));
                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());
                        lvItem.SubItems.Add(arr[i]["isSettlement"].ToString());



                        lvwList.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("데이터 오류. paymentCash\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                return;
            }




        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count <= 0)
            {
                return;
            }


            lvwOrder.Items.Clear();

            String tTheNo = lvwList.SelectedItems[0].Tag.ToString();


            // order
            String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&pointTheNo=" + tTheNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        int cnt = convert_number(arr[i]["cnt"].ToString());
                        int amt = convert_number(arr[i]["amt"].ToString());
                        int option_amt = convert_number(arr[i]["optionAmt"].ToString());
                        int dc_amt = convert_number(arr[i]["dcAmount"].ToString());
                        int net_amt = ((amt + option_amt) * cnt) - dc_amt;
                        String dcr_des = arr[i]["dcrDes"].ToString();
                        String dcr_type = arr[i]["dcrType"].ToString();
                        String dcr_value = arr[i]["dcrValue"].ToString();

                        ListViewItem lvItem = new ListViewItem();
                        //lvItem.Text = (i + 1).ToString();
                        lvItem.Text = arr[i]["shopOrderNo"].ToString();
                        lvItem.SubItems.Add(arr[i]["goodsName"].ToString());
                        lvItem.SubItems.Add(amt.ToString("N0"));
                        lvItem.SubItems.Add(cnt.ToString("N0"));
                        lvItem.SubItems.Add(dc_amt.ToString("N0"));
                        lvItem.SubItems.Add(net_amt.ToString("N0"));

                        String memo = "";
                        if (dcr_type == "R")
                        {
                            memo += dcr_value + "%";
                        }
                        else if (dcr_type == "A")
                        {
                            memo += "₩" + dcr_value;
                        }

                        lvItem.SubItems.Add(memo);

                        lvwOrder.Items.Add(lvItem);

                        
                        // 옵션아이템 보기
                        if (arr[i]["optionNo"].ToString() != "")
                        {
                            sUrl = "orderOptionItem?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&optionNo=" + arr[i]["optionNo"].ToString();
                            if (mRequestGet(sUrl))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                    String data2 = mObj["orderOptionItems"].ToString();
                                    JArray arr2 = JArray.Parse(data2);

                                    String t_option_name = "";

                                    for (int k = 0; k < arr2.Count; k++)
                                    {
                                        t_option_name += arr2[k]["optionItemName"].ToString() + " ";
                                    }

                                    ListViewItem lvItem2 = new ListViewItem();
                                    lvItem2.Text = "";
                                    lvItem2.SubItems.Add("- " + t_option_name);
                                    lvItem2.SubItems.Add(option_amt.ToString("N0"));
                                    lvItem2.SubItems.Add("");
                                    lvItem2.SubItems.Add("");
                                    lvItem2.SubItems.Add("");
                                    lvItem2.SubItems.Add("");

                                    lvwOrder.Items.Add(lvItem2);

                                }
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("데이터 오류. orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                return;
            }




        }
    }
}
