﻿using Newtonsoft.Json.Linq;
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

        String thisBizDt = "";


        public frmReportAllim()
        {
            InitializeComponent();

            initialize_the();
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


            cbShop.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }
            cbShop.SelectedIndex = 0;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            thisBizDt = dtpBizDate.Value.ToString("yyyyMMdd");

            String shop_code = "";

            if (cbShop.SelectedIndex > 0)
            {
                shop_code = mShop[cbShop.SelectedIndex - 1].shop_code;
            }


            lvwList.Items.Clear();


            String sUrl = "allim?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&shopCode=" + shop_code;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["allims"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem Item = new ListViewItem();
                        Item.Text = arr[i]["orderTime"].ToString();
                        Item.SubItems.Add(arr[i]["orderNo"].ToString());
                        Item.SubItems.Add(arr[i]["allimType"].ToString());
                        Item.SubItems.Add(arr[i]["allimTelNo"].ToString());
                        Item.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));
                        Item.SubItems.Add(arr[i]["orderDetail"].ToString());


                        lvwList.Items.Add(Item);
                    }

                }
                else
                {
                    MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. allim\n\n" + mErrorMsg, "thepos");
            }
        }
    }
}
