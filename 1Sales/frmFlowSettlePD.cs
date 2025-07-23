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
using static thepos.frmSales;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;
using static thepos.frmSub;

namespace thepos
{
    public partial class frmFlowSettlePD : Form
    {
        TextBox saveKeyDisplay;

        TicketFlow mThisTicketFlow = new TicketFlow();


        public frmFlowSettlePD()
        {
            InitializeComponent();
            initialize_the();

            //
            thepos_app_log(1, this.Name, "Open", "");

        }


        private void initialize_the()
        {

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 26);
            lvwList.SmallImageList = imgList;


            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbTicketNo;

            mPayClass = "ST"; // 정산 settement


            // 결제버튼
            mTableLayoutPanelPayControl.Enabled = false;

        }



        private void btnView_Click(object sender, EventArgs e)
        {
            String no = tbTicketNo.Text;

            if (no.Length != 22 & no.Length != 4)
            {
                return;
            }


            view_flow_step(no);

            // 결제버튼
            mTableLayoutPanelPayControl.Enabled = false;

        }


        private void tbTicketNo_KeyDown(object sender, KeyEventArgs e)
        {
            String no = tbTicketNo.Text;

            if (no.Length != 22 & no.Length != 4)
            {
                return;
            }


            view_flow_step(no);

            // 결제버튼
            mTableLayoutPanelPayControl.Enabled = false;
        }



        public void view_flow_step(String t_no)
        {

            lvwList.Items.Clear();


            String t_ticket_no = "";
            String t_entry_dt = "";


            if (mPointType != "PD") // 후불
            {
                MessageBox.Show("이 화면은 후불전용 정산화면입니다.\r\n포인트사용 후불설정이 되어있지 않습니다. 관리자에게 문의바랍니다.", "thepos");
                return;
            }

            if (mTicketMedia == "RF")
            {
                t_ticket_no = get_ticket_no_by_locker_no(t_no);
            }
            else
            {
                t_ticket_no = t_no;
            }


            if (t_ticket_no.Length < 20)
            {
                return;
            }


            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&theNo=" + t_ticket_no.Substring(0, 20);

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        
                        lvItem.Text = "";

                        string step_flow = arr[i]["flowStep"].ToString();

                        lvItem.SubItems.Add(get_flow_step_name(step_flow));

                        if (mTicketMedia == "RF")
                        {
                            lvItem.SubItems.Add(arr[i]["lockerNo"].ToString());
                        }
                        else
                        {
                            lvItem.SubItems.Add(arr[i]["ticketNo"].ToString().Substring(20, 2));
                        }

                        lvItem.SubItems.Add(get_goods_name(arr[i]["goodsCode"].ToString()));

                        string entry_dt = arr[i]["entryDt"].ToString();
                        lvItem.SubItems.Add(entry_dt.Substring(8, 2) + ":" + entry_dt.Substring(10, 2));

                        int point_usage_cnt = convert_number(arr[i]["pointUsageCnt"].ToString());
                        int point_usage = convert_number(arr[i]["pointUsage"].ToString());
                        lvItem.SubItems.Add(point_usage_cnt.ToString("N0"));
                        lvItem.SubItems.Add(point_usage.ToString("N0"));
                        lvItem.SubItems.Add(arr[i]["ticketNo"].ToString());

                        //
                        if (step_flow == "3")
                        {
                            lvItem.ForeColor = Color.Black;
                            lvItem.Checked = true;
                        }
                        else
                        {
                            lvItem.ForeColor = Color.Gray;
                            lvItem.Checked = false;
                        }

                        lvwList.Items.Add(lvItem);

                    }

                }
                else
                {
                    MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
                return;
            }


        }


        private void get_order_items()
        { 
            // 
                string sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + "";

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["orderItems"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            //
                            string order_time = arr[i]["orderTime"].ToString();
                            string goods_name = arr[i]["goodsName"].ToString();
                            int goods_cnt = convert_number(arr[i]["cnt"].ToString());
                            int goods_amt = convert_number(arr[i]["amt"].ToString());
                            int option_amt = convert_number(arr[i]["optionAmt"].ToString());
                            int goods_amount = goods_cnt * (goods_amt + option_amt);

                            String option_no = arr[i]["optionNo"].ToString();



                            //
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Text = "";  // checkbox
                            lvItem.SubItems.Add(order_time.Substring(0,2) + ":" + order_time.Substring(2, 2));
                            lvItem.SubItems.Add(goods_name);
                            lvItem.SubItems.Add(goods_cnt.ToString("N0"));
                            lvItem.SubItems.Add(goods_amount.ToString("N0"));
                            lvwList.Items.Add(lvItem);


                            //
                            //
                            MemOrderItem orderItem = new MemOrderItem();
                            orderItem.option_name_description = "";   // 리스트뷰 상품항목 아랫줄에 표시
                            orderItem.option_amt_description = "";    // 리스트뷰 단가항목 아랫줄에 표시


                            mOrderOptionItemList.Clear();


                            if (option_no != "")
                            {
                                sUrl = "orderOptionItem?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&optionNo=" + option_no;

                                if (mRequestGet(sUrl))
                                {
                                    if (mObj["resultCode"].ToString() == "200")
                                    {
                                        String data1 = mObj["orderOptionItems"].ToString();
                                        JArray arr1 = JArray.Parse(data1);

                                        for (int k = 0; k < arr1.Count; k++)
                                        {
                                            orderOptionItem orderOptionItem = new orderOptionItem();
                                            orderOptionItem.option_item_no = convert_number(arr1[k]["optionItemNo"].ToString());
                                            orderOptionItem.option_item_name = arr1[k]["optionItemName"].ToString();
                                            orderOptionItem.option_code = arr1[k]["optionCode"].ToString();
                                            orderOptionItem.option_name = arr1[k]["optionName"].ToString();
                                            orderOptionItem.amt = convert_number(arr1[k]["amt"].ToString());

                                            mOrderOptionItemList.Add(orderOptionItem);
                                        }
                                    }
                                }
                            }

                            if (mOrderOptionItemList.Count > 0)
                            {
                                for (int k = 0; k < mOrderOptionItemList.Count; k++)
                                {
                                    orderItem.option_name_description += " " + mOrderOptionItemList[k].option_item_name;
                                    orderItem.option_amt += (int)mOrderOptionItemList[k].amt;
                                }
                            }

                            //
                            if (mOrderOptionItemList.Count > 0)
                            {
                                orderItem.option_amt_description = orderItem.option_amt.ToString("N0");
                            }
                            else
                            {
                                orderItem.option_amt_description = "";
                            }

                            //
                            orderItem.option_item_cnt = mOrderOptionItemList.Count;
                            orderItem.option_no = option_no;
                            orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..

                            orderItem.order_no = mOrderItemList.Count + 1;
                            orderItem.goods_code = arr[i]["goodsCode"].ToString();
                            orderItem.goods_name = arr[i]["goodsName"].ToString();
                            orderItem.ticket = arr[i]["ticketYn"].ToString();
                            orderItem.taxfree = arr[i]["taxFree"].ToString();
                            orderItem.allim = arr[i]["allim"].ToString();

                            orderItem.cnt = goods_cnt;
                            orderItem.amt = goods_amt;

                            orderItem.dcr_type = arr[i]["dcrType"].ToString();
                            orderItem.dcr_des = arr[i]["dcrDes"].ToString();
                            orderItem.dcr_value = convert_number(arr[i]["dcrValue"].ToString());
                            orderItem.shop_code = arr[i]["shopCode"].ToString();
                            orderItem.nod_code1 = arr[i]["nodCode1"].ToString();
                            orderItem.nod_code2 = arr[i]["nodCode2"].ToString();

                            //
                            replace_mem_order_item(ref orderItem, "add");

                            mOrderItemList.Add(orderItem);
                            
                        }

                        mLvwOrderItem.SetObjects(mOrderItemList);
                        ReCalculateAmount();
                    }
                }




        }








        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFlowSettlement_FormClosed(object sender, FormClosedEventArgs e)
        {
            mClearSaleForm();

            mTbKeyDisplayController = saveKeyDisplay;
            mPayClass = "OR"; // 원복: order

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();

            // 결제버튼
            mTableLayoutPanelPayControl.Enabled = true;


        }




        private void btnAddPay_Click(object sender, EventArgs e)
        {
            mOrderItemList.Clear();
            mLvwOrderItem.SetObjects(mOrderItemList);


            for (int fs = 0; fs < lvwList.Items.Count; fs++)
            {

                if (lvwList.Items[fs].Checked)
                {

                    string t_no = lvwList.Items[fs].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text;

                    String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + t_no;
                    if (mRequestGet(sUrl))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            String data = mObj["orderItems"].ToString();
                            JArray arr = JArray.Parse(data);

                            for (int i = 0; i < arr.Count; i++)
                            {
                                if (arr[i]["payClass"].ToString() == "US" & (arr[i]["isCancel"].ToString() != "Y" & arr[i]["isCancel"].ToString() != "y"))
                                {
                                    MemOrderItem orderItem = new MemOrderItem();

                                    orderItem.goods_code = arr[i]["goodsCode"].ToString();
                                    orderItem.goods_name = arr[i]["goodsName"].ToString();
                                    orderItem.cnt = convert_number(arr[i]["cnt"].ToString());
                                    orderItem.amt = convert_number(arr[i]["amt"].ToString());
                                    orderItem.option_amt = convert_number(arr[i]["optionAmt"].ToString());
                                    orderItem.dc_amount = convert_number(arr[i]["dcAmount"].ToString());
                                    orderItem.dcr_des = arr[i]["dcrDes"].ToString();
                                    orderItem.dcr_type = arr[i]["dcrType"].ToString();
                                    orderItem.dcr_value = convert_number(arr[i]["dcrValue"].ToString());
                                    orderItem.ticket = arr[i]["ticketYn"].ToString();
                                    orderItem.taxfree = arr[i]["taxFree"].ToString();
                                    orderItem.pay_class = arr[i]["payClass"].ToString();
                                    orderItem.ticket_no = arr[i]["ticketNo"].ToString();
                                    orderItem.shop_code = arr[i]["shopCode"].ToString();
                                    orderItem.option_no = arr[i]["optionNo"].ToString();

                                    //
                                    //orderItem.add_job = "TF4T9";   // 퇴장시 추가요금 결제
                                    orderItem.add_job = "ST_PD_POINT_2_PAY";   // 후불정산 결제시 주문+결제 별도로직 치리 

                                    List<orderOptionItem> orderOptionItemList = new List<orderOptionItem>();

                                    orderOptionItem orderOptionItem = new orderOptionItem();


                                    if (arr[i]["optionNo"].ToString() != "")
                                    {
                                        sUrl = "orderOptionItem?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&optionNo=" + arr[i]["optionNo"].ToString();
                                        if (mRequestGet(sUrl))
                                        {
                                            if (mObj["resultCode"].ToString() == "200")
                                            {
                                                String data2 = mObj["orderOptionItems"].ToString();
                                                JArray arr2 = JArray.Parse(data2);

                                                for (int k = 0; k < arr2.Count; k++)
                                                {
                                                    orderOptionItem.option_item_no = convert_number(arr2[k]["optionItemNo"].ToString());
                                                    orderOptionItem.option_item_name = arr2[k]["optionItemName"].ToString();
                                                    orderOptionItem.option_code = arr2[k]["optionCode"].ToString();
                                                    orderOptionItem.option_name = arr2[k]["optionName"].ToString();
                                                    orderOptionItem.amt = convert_number(arr2[k]["amt"].ToString());

                                                    orderOptionItemList.Add(orderOptionItem);

                                                    orderItem.option_name_description += " " + arr2[k]["optionItemName"].ToString();
                                                }

                                                orderItem.orderOptionItemList = orderOptionItemList;
                                                orderItem.option_item_cnt = mOrderOptionItemList.Count;

                                                //
                                                if (orderOptionItemList.Count > 0)
                                                {
                                                    orderItem.option_amt_description = orderItem.option_amt.ToString("N0");
                                                }
                                                else
                                                {
                                                    orderItem.option_amt_description = "";
                                                }


                                            }
                                            else
                                            {
                                                MessageBox.Show("결제데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
                                        }
                                    }

                                    //
                                    replace_mem_order_item(ref orderItem, "add");

                                    mOrderItemList.Add(orderItem);

                                }
                            }

                            //
                            mLvwOrderItem.SetObjects(mOrderItemList);

                            ReCalculateAmount();

                            // 결제버튼
                            mTableLayoutPanelPayControl.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("결제데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
                    }


                }
            }

        }
    }
}
