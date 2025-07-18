﻿using System;
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
using System.Numerics;
using System.Diagnostics.Eventing.Reader;

namespace thepos
{
    public partial class frmFlowCharging : Form
    {
        TextBox saveKeyDisplay;

        public static ListView mLvwFlow;

        int mChargeAmt = 0;

        public frmFlowCharging()
        {
            InitializeComponent();
            initialize_the();

            //
            thepos_app_log(1, this.Name, "Open", "");

        }


        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 28);
            lvwFlow.SmallImageList = imgList;

            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbTicketNo;

            // 
            mPayClass = "CH"; // 충전 charge


            mLvwFlow = lvwFlow;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFlowCharging_FormClosed(object sender, FormClosedEventArgs e)
        {
            mClearSaleForm();
            

            mTbKeyDisplayController = saveKeyDisplay;
            mPayClass = "OR"; // 원복: order

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();

        }


        private void btnView_Click(object sender, EventArgs e)
        {

            String no = tbTicketNo.Text;


            if (no.Length != 22)
            {

                return;
            }



            view_flow(no);
        }


        public void view_flow(String t_no)
        {

            mOrderItemList.Clear();
            mLvwOrderItem.SetObjects(mOrderItemList);
            ReCalculateAmount();


            lvwFlow.Items.Clear();

            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + t_no;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        String ticket_no = arr[i]["ticketNo"].ToString();
                        String tStat = arr[i]["flowStep"].ToString();
                        String ticketing_dt = arr[i]["ticketingDt"].ToString();
                        String charge_dt = arr[i]["chargeDt"].ToString();
                        int point_charge = convert_number(arr[i]["pointCharge"].ToString());


                        if (tStat == "0") tStat = "접수";
                        else if (tStat == "1") tStat = "발권";
                        else if (tStat == "2") tStat = "충전";
                        else if (tStat == "3") tStat = "사용중";
                        else if (tStat == "4") tStat = "정산중";
                        else if (tStat == "9") tStat = "정산완료";

                        item.Text = tStat;
                        item.Tag = ticket_no;

                        item.SubItems.Add(get_goods_name(arr[i]["goodsCode"].ToString()));
                        item.SubItems.Add(ticket_no.Substring(14, 6) + "-" + ticket_no.Substring(20, 2));

                        String tStr = "";

                        if (charge_dt != "")
                        {
                            tStr = charge_dt.Substring(4, 2) + "-" +
                                   charge_dt.Substring(6, 2) + " " +
                                   charge_dt.Substring(8, 2) + ":" +
                                   charge_dt.Substring(10, 2);
                        }
                        item.SubItems.Add(tStr);

                        item.SubItems.Add(point_charge.ToString("N0"));

                        lvwFlow.Items.Add(item);


                        if (ticket_no == t_no)
                        {
                            lvwFlow.Items[i].Selected = true;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
            }
        }



        public static void review_flow(String t_no, int select_index)
        {
            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + t_no;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        ListViewItem item = new ListViewItem();
                        String ticket_no = arr[0]["ticketNo"].ToString();
                        String tStat = arr[0]["flowStep"].ToString();
                        String ticketing_dt = arr[0]["ticketingDt"].ToString();
                        String charge_dt = arr[0]["chargeDt"].ToString();
                        int point_charge = convert_number(arr[0]["pointCharge"].ToString());


                        if (tStat == "0") tStat = "접수";
                        else if (tStat == "1") tStat = "발권";
                        else if (tStat == "2") tStat = "충전";
                        else if (tStat == "3") tStat = "사용중";
                        else if (tStat == "4") tStat = "정산완료";

                        item.Text = tStat;
                        item.Tag = ticket_no;

                        item.SubItems.Add(get_goods_name(arr[0]["goodsCode"].ToString()));
                        item.SubItems.Add(ticket_no.Substring(14, 6) + "-" + ticket_no.Substring(20, 2));

                        String tStr = "";

                        if (charge_dt != "")
                        {
                            tStr = charge_dt.Substring(4, 2) + "-" +
                                   charge_dt.Substring(6, 2) + " " +
                                   charge_dt.Substring(8, 2) + ":" +
                                   charge_dt.Substring(10, 2);
                        }
                        item.SubItems.Add(tStr);

                        item.SubItems.Add(point_charge.ToString("N0"));

                        mLvwFlow.Items[select_index] = item;
                        item.Selected = true;
                        mLvwFlow.Select();
                        mLvwFlow.EnsureVisible(select_index);

                    }

                }
                else
                {
                    MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
            }
        }




        private void btnCharge_Click(object sender, EventArgs e)
        {

            if (lvwFlow.SelectedItems.Count == 0)
            {
                SetDisplayAlarm("W", "항목선택 요망.");
                return;
            }


            int charge_amt = convert_number(tbChargeAmt.Text);
            if (charge_amt < 1)
            {
                SetDisplayAlarm("W", "금액오류");
                return;
            }



            int flowstep = get_flowstep_by_ticketno(lvwFlow.SelectedItems[0].Tag.ToString());

            if (flowstep > 3) // 사용이상
            {
                MessageBox.Show("정산이후에는 포인트충전할 수 없습니다.", "thepos");
                return;
            }





            MemOrderItem orderItem = new MemOrderItem();

            int lv_idx = (frmSales.get_lvitem_idx("CHARGE"));  // 이미  동일 상품이 주문리스트뷰에 있는지

            if (lv_idx == -1)
            {

                String t_no = lvwFlow.SelectedItems[0].Tag.ToString();


                orderItem.goods_code = "CHARGE";
                orderItem.goods_name = "충전_" + t_no.Substring(14,6) + "-" + t_no.Substring(20, 2);
                orderItem.cnt = 1;
                orderItem.amt = charge_amt;
                orderItem.dc_amount = 0;
                orderItem.dcr_des = "";
                orderItem.dcr_type = "";
                orderItem.dcr_value = 0;
                orderItem.ticket = "";
                orderItem.pay_class = "CH";
                orderItem.ticket_no = lvwFlow.SelectedItems[0].Tag.ToString();
                orderItem.shop_code = "CHARGE";
                orderItem.option_item_cnt = 0;

                mOrderOptionItemList.Clear();
                orderItem.orderOptionItemList = mOrderOptionItemList.ToList();

                //
                replace_mem_order_item(ref orderItem, "add");

                mOrderItemList.Add(orderItem);
                mLvwOrderItem.SetObjects(mOrderItemList);

                mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].EnsureVisible();
                mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].Selected = true;

            }
            else
            {
                orderItem = mOrderItemList[lv_idx];

                orderItem.amt = charge_amt;

                // 
                replace_mem_order_item(ref orderItem, "update");

                mOrderItemList[lv_idx] = orderItem;

                mLvwOrderItem.SetObjects(mOrderItemList);

                mLvwOrderItem.Items[lv_idx].Selected = true;

            }

            mChargeAmt = 0;
            tbChargeAmt.Text = string.Empty;


            ReCalculateAmount();


        }

        private void btn10t_Click(object sender, EventArgs e)
        {
            mChargeAmt += 10000;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }

        private void btn50t_Click(object sender, EventArgs e)
        {
            mChargeAmt += 50000;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }

        private void btn100t_Click(object sender, EventArgs e)
        {
            mChargeAmt += 100000;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }

        private void btn1t_Click(object sender, EventArgs e)
        {
            mChargeAmt += 1000;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }

        private void btn5t_Click(object sender, EventArgs e)
        {
            mChargeAmt += 5000;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            mChargeAmt = 0;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }

        private void tbTicketNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                lvwFlow.Items.Clear();

                if (tbTicketNo.Text.Length != 22)
                {
                    SetDisplayAlarm("W", "티켓번호 오류.");
                    thepos_app_log(3, this.Name, "scanner", "skip. no=" + tbTicketNo.Text);
                    tbTicketNo.Text = "";
                    return;
                }

                String no = tbTicketNo.Text;

                //




                tbTicketNo.Clear();
                tbTicketNo.Focus();
            }
        }

        private void tbTicketNo_Leave(object sender, EventArgs e)
        {

        }
    }
}
