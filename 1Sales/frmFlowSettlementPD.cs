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
    public partial class frmFlowSettlementPD : Form
    {
        TextBox saveKeyDisplay;

        TicketFlow mThisTicketFlow = new TicketFlow();


        public frmFlowSettlementPD()
        {
            InitializeComponent();
            initialize_the();

            //
            thepos_app_log(1, this.Name, "Open", "");

        }


        private void initialize_the()
        {

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);


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


            view_point_usage(no);

            // 결제버튼
            mTableLayoutPanelPayControl.Enabled = false;

        }


        private void tbTicketNo_KeyDown(object sender, KeyEventArgs e)
        {
            String no = tbTicketNo.Text;

            if (no.Length != 22)
            {
                return;
            }


            view_point_usage(no);

            // 결제버튼
            mTableLayoutPanelPayControl.Enabled = false;
        }



        public void view_point_usage(String t_no)
        {

            lvwPoint.Items.Clear();


            String t_ticket_no = "";
            String t_bangle_no = "";



            if (mPointType != "PD") // 후불
            {
                MessageBox.Show("이 화면은 후불전용 정산화면입니다.\r\n포인트사용 후불설정이 되어있지 않습니다. 관리자에게 문의바랍니다.", "thepos");
                return;
            }


            String sUrl = "";

            if (mTicketMedia == "RF")  // 팔찌
            {
                sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&bangleNo=" + t_no;
            }
            else
            {
                sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + t_no;
            }

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count == 1)
                    {
                        t_ticket_no = arr[0]["ticketNo"].ToString();
                        t_bangle_no = arr[0]["bangleNo"].ToString();
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



            //





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


            String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + mThisTicketFlow.ticket_no;
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
                            mLvwOrderItem.SetObjects(mOrderItemList);
                        }
                    }

                    //
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
