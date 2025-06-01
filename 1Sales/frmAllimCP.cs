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
using thepos;
using static thepos.thePos;
using static thepos.frmSales;
using thepos._1Sales;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;

namespace theposw
{
    public partial class frmAllimCP : Form
    {
        String thisBizDt = "";

        public frmAllimCP()
        {
            InitializeComponent();
            initialize_the();

            //
            thepos_app_log(1, this.Name, "Open", "");
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



            lvwOrderShop.Items.Clear();
            lvwOrderItem.Items.Clear();

            btnAllimSendCP.Enabled = false;
            btnAllimFinish.Enabled = false;



            String sUrl = "orderShop?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&shopCode=" + myShopCode;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderShops"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();

                        String allim_status_name = "";


                        if (arr[i]["orderAllimStatus"].ToString() == "0")
                        {
                            allim_status_name = "주문";
                            lvItem.ImageIndex = 0;

                            lvItem.ForeColor = Color.Blue;
                        }
                        else if (arr[i]["orderAllimStatus"].ToString() == "1")
                        {
                            allim_status_name = "발송";
                            lvItem.ImageIndex = 1;
                        }
                        else if (arr[i]["orderAllimStatus"].ToString() == "2")
                        {
                            allim_status_name = "완료";
                            lvItem.ImageIndex = -1;

                            lvItem.ForeColor = Color.Gray;
                        }
                        else
                        {
                            allim_status_name = "";
                        }

                        lvItem.Text = allim_status_name;

                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["shopOrderNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["orderTime"].ToString().Substring(0,2) + ":" + arr[i]["orderTime"].ToString().Substring(2, 2) + ":" + arr[i]["orderTime"].ToString().Substring(4, 2));
                        lvItem.SubItems.Add(arr[i]["cnt"].ToString());

                        String allim_type_name = "";
                        if (arr[i]["orderAllimType"].ToString() == "AT") allim_type_name = "알림톡";

                        lvItem.SubItems.Add(allim_type_name);

                        lvItem.SubItems.Add(arr[i]["orderAllimMemo"].ToString());
                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());
                        lvItem.SubItems.Add(arr[i]["orderAllimType"].ToString());
                        lvItem.SubItems.Add(arr[i]["orderAllimStatus"].ToString());
                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());

                        
                        lvwOrderShop.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderShop\n\n" + mErrorMsg, "thepos");
            }

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAllimCP_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();
            //mTbKeyDisplayController = saveKeyDisplay;

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }

        private void lvwOrderShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwOrderShop.SelectedItems.Count <= 0)
            {
                return;
            }

            String tTheNo = lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(the_no)].Text;
            String tShopOrderNo = lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(shop_order_no)].Text;
            //
            String tAllimTypeCode = lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(allim_type_code)].Text;
            String tAllimStatusCode = lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(allim_status_code)].Text;
            String tIsCancel = lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(cancel)].Text;



            //
            if (tAllimTypeCode.Equals("AT"))
            {
                if (tAllimStatusCode.Equals("0") | tAllimStatusCode.Equals("1"))
                {
                    if (tIsCancel.Equals("Y"))
                    {
                        btnAllimSendCP.Enabled = false;
                    }
                    else
                    {
                        btnAllimSendCP.Enabled = true;
                    }
                }
                else
                {
                    btnAllimSendCP.Enabled = false;
                }
            }
            else
            {
                btnAllimSendCP.Enabled = false;
            }


            //
            if (tAllimStatusCode.Equals("0") | tAllimStatusCode.Equals("1"))
            {
                btnAllimFinish.Enabled = true;
            }
            else
            {
                btnAllimFinish.Enabled = false;
            }



            //
            lvwOrderItem.Items.Clear();

            String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&shopOrderNo=" + tShopOrderNo + "&tranType=A";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["goodsName"].ToString();
                        lvItem.SubItems.Add(arr[i]["cnt"].ToString());
                        lvwOrderItem.Items.Add(lvItem);

                        //
                        String option_no = arr[i]["optionNo"].ToString();

                        if (option_no.Length > 0)
                        {
                            sUrl = "orderOptionItem?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&optionNo=" + option_no;
                            if (mRequestGet(sUrl))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                    data = mObj["orderOptionItems"].ToString();
                                    JArray arr2 = JArray.Parse(data);

                                    for (int k = 0; k < arr2.Count; k++)
                                    {
                                        ListViewItem lvItem2 = new ListViewItem();
                                        lvItem2.Text = "    " + arr2[k]["optionName"].ToString();
                                        lvItem2.SubItems.Add(arr2[k]["optionItemName"].ToString());
                                        lvItem2.SubItems[0].ForeColor = Color.Gray;
                                        lvwOrderItem.Items.Add(lvItem2);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류. orderOptionItem\n\n" + mErrorMsg, "thepos");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
            }

        }

 

        private void btnAllimSendCP_Click(object sender, EventArgs e)
        {
            if (lvwOrderShop.SelectedItems.Count <= 0)
            {
                return;
            }


            String tAllimTypeCode = lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(allim_type_code)].Text;


            if (tAllimTypeCode == "")
            {
                return;
            }




            String tTheNo = lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(the_no)].Text;
            String order_no = lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(shop_order_no)].Text;



            DialogResult ret = MessageBox.Show("선택건을 알림발송하시겠습니까?\r\n\r\n주문번호 : " + order_no, "알림발송", MessageBoxButtons.OKCancel);

            if (ret != DialogResult.OK ) 
            {
                return;
            }


            if (tAllimTypeCode == "AT")
            {
                String sUrl = "allim?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&theNo=" + tTheNo + "&shopCode=" + myShopCode;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["allims"].ToString();
                        JArray arr = JArray.Parse(data);

                        //
                        Dictionary<string, string> parameters = new Dictionary<string, string>();
                        parameters["siteId"] = mSiteId;
                        parameters["posNo"] = myPosNo;
                        parameters["bizDt"] = thisBizDt;
                        parameters["theNo"] = mTheNo;
                        parameters["senderProfile"] = arr[0]["senderProfile"].ToString(); ;
                        parameters["allimType"] = "CP";
                        parameters["allimTelNo"] = arr[0]["allimTelNo"].ToString(); ;
                        parameters["siteName"] = arr[0]["siteName"].ToString(); ;
                        parameters["orderDate"] = arr[0]["orderDate"].ToString();
                        parameters["orderTime"] = arr[0]["orderTime"].ToString();
                        parameters["orderNo"] = arr[0]["orderNo"].ToString();
                        parameters["shopCode"] = myShopCode;
                        parameters["orderDetail"] = " " + arr[0]["orderDetail"].ToString();

                        if (mRequestPost("allim", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                // orderItem UPDATE
                                parameters.Clear();
                                parameters["siteId"] = mSiteId;
                                parameters["bizDt"] = thisBizDt;
                                parameters["theNo"] = tTheNo;
                                parameters["shopOrderNo"] = arr[0]["orderNo"].ToString(); ;
                                parameters["orderAllimStatus"] = "1";   // 0주문 1알림발송 2완료

                                if (mRequestPatch("orderShop", parameters))
                                {
                                    if (mObj["resultCode"].ToString() == "200")
                                    {
                                        //
                                        // 리스트뷰 갱신

                                        lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(allim_status_name)].Text = "발송";
                                        lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(allim_status_code)].Text = "1";
                                        lvwOrderShop.SelectedItems[0].ImageIndex = 1;

                                        lvwOrderShop.SelectedItems[0].ForeColor = Color.Black;

                                    }
                                    else
                                    {
                                        MessageBox.Show("오류. orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                                    return;
                                }

                            }
                            else
                            {
                                MessageBox.Show("오류 allim\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. orderOptionItem\n\n" + mErrorMsg, "thepos");
                }
            }


            

        }

        private void btnAllimFinish_Click(object sender, EventArgs e)
        {
            String tTheNo = lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(the_no)].Text;
            String tOrderNo = lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(shop_order_no)].Text;


            DialogResult ret = MessageBox.Show("선택건을 완료처리하시겠습니까?\r\n\r\n주문번호 : " + tOrderNo, "완료처리", MessageBoxButtons.OKCancel);

            if (ret != DialogResult.OK)
            {
                return;
            }



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = thisBizDt;
            parameters["theNo"] = tTheNo;
            parameters["shopOrderNo"] = tOrderNo;
            parameters["orderAllimStatus"] = "2";   // 0주문 1알림발송 2완료

            if (mRequestPatch("orderShop", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //
                    // 리스트뷰 갱신

                    lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(allim_status_name)].Text = "완료";
                    lvwOrderShop.SelectedItems[0].SubItems[lvwOrderShop.Columns.IndexOf(allim_status_code)].Text = "2";
                    lvwOrderShop.SelectedItems[0].ImageIndex = 2;

                    lvwOrderShop.SelectedItems[0].ForeColor = Color.Gray;

                }
                else
                {
                    MessageBox.Show("오류. orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
