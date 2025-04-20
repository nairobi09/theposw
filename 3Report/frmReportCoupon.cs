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

namespace thepos._1Sales
{
    public partial class frmReportCoupon : Form
    {
        String thisBizDt = "";

        public frmReportCoupon()
        {
            InitializeComponent();
            initialize_the();
        }

        private void initialize_the()
        {

            dtpBizDate.Value = DateTime.Now;

            cbCoupon.Items.Clear();
            cbCoupon.Items.Add("테이블메니저");
            cbCoupon.SelectedIndex = 0;
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            thisBizDt = dtpBizDate.Value.ToString("yyyyMMdd");

            lvwList.Items.Clear();


            String sUrl = "paymentCert?siteId=" + mSiteId + "&bizDt=" + thisBizDt;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentCerts"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem sumItem = new ListViewItem();
                        sumItem.Text = arr[i]["vanCode"].ToString();
                        sumItem.SubItems.Add(arr[i]["couponNo"].ToString());
                        sumItem.SubItems.Add(arr[i]["couponLinkNo"].ToString());

                        //
                        int link_goods_idx = -1;
                        
                        String t_coupon_link_no = arr[i]["couponLinkNo"].ToString();



                        for (int k = 0; k < mGoodsItem.Length; k++)
                        {
                            if (t_coupon_link_no == mGoodsItem[k].coupon_link_no)
                            {
                                link_goods_idx = k;
                            }
                        }

                        String t_goods_code = "";
                        String t_goods_name = "";
                        if (link_goods_idx > -1)
                        {
                            t_goods_code = mGoodsItem[link_goods_idx].goods_code;
                            t_goods_name = mGoodsItem[link_goods_idx].goods_name;
                        }


                        sumItem.SubItems.Add("[" + t_goods_code + "] " + t_goods_name);

                        sumItem.SubItems.Add(arr[i]["cnt"].ToString());

                        sumItem.SubItems.Add(get_MMddHHmm(arr[i]["payDate"].ToString(), arr[i]["payTime"].ToString()));

                        lvwList.Items.Add(sumItem);

                    }
                }
            }

        }
    }
}
