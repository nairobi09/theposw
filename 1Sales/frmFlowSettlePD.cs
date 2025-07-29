using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theposw._1Sales;
using static System.Windows.Forms.AxHost;
using static thepos.frmSales;
using static thepos.frmSub;
using static thepos.thePos;

namespace thepos
{
    public partial class frmFlowSettlePD : Form
    {
        TextBox saveKeyDisplay;

        TicketFlow mThisTicketFlow = new TicketFlow();

        public static ListView mLvwList;


        // 정산결제시 주문테이블을 정산마킹Patch하기 위해 리스트로 전달하기 위해
        public static List<String> settle_the_no_list = new List<String>();
        public static List<String> settle_ticket_no_list = new List<String>();
        public static List<String> settle_locker_no_list = new List<String>();

        public static String this_locker_no = "";
        public static String this_ticket_no = "";

        public static String this_no = "";


        public frmFlowSettlePD()
        {
            InitializeComponent();
            initialize_the();

            //
            thepos_app_log(1, this.Name, "Open", "");

        }


        private void initialize_the()
        {
            mLvwList = lvwList;



            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 26);
            lvwList.SmallImageList = imgList;

            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbTicketNo;

            mPayClass = "ST"; // 정산 settement
        }



        private void btnView_Click(object sender, EventArgs e)
        {
            this_no = tbTicketNo.Text;

            if (this_no.Length != 22 & this_no.Length != 4)
            {
                return;
            }

            load_ticket_list(this_no);
            btn_0123();
        }


        private void tbTicketNo_KeyDown(object sender, KeyEventArgs e)
        {
            this_no = tbTicketNo.Text;

            if (this_no.Length != 22 & this_no.Length != 4)
            {
                return;
            }

            load_ticket_list(this_no);
            btn_0123();
        }


        public static void load_ticket_list(String t_no)
        {
            mLvwList.Items.Clear();


            String t_entry_dt = "";


            if (mPointType != "PD") // 후불
            {
                MessageBox.Show("이 화면은 후불전용 정산화면입니다.\r\n포인트사용 후불설정이 되어있지 않습니다. 관리자에게 문의바랍니다.", "thepos");
                return;
            }

            if (mTicketMedia == "RF")
            {
                this_ticket_no = get_ticket_no_by_locker_no(t_no);
            }
            else
            {
                this_ticket_no = t_no;
            }


            if (this_ticket_no.Length < 20)
            {
                return;
            }


            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&theNo=" + this_ticket_no.Substring(0, 20);

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


                        if (mTicketMedia == "RF")
                        {
                            lvItem.SubItems.Add(arr[i]["lockerNo"].ToString());
                        }
                        else
                        {
                            lvItem.SubItems.Add(arr[i]["ticketNo"].ToString().Substring(20, 2));
                        }



                        string step_flow = arr[i]["flowStep"].ToString();
                        String step_flow_name = "";

                        if (step_flow == "0") step_flow_name = "▷ 발권";
                        else if (step_flow == "1") step_flow_name = "▶ 입장";
                        else if (step_flow == "2") step_flow_name = "▶ 충전";
                        else if (step_flow == "3") step_flow_name = "▶ 사용";
                        else if (step_flow == "4") step_flow_name = "■ 퇴장";
                        else if (step_flow == "8") step_flow_name = "✕ 취소";
                        else if (step_flow == "9") step_flow_name = "□ 완료";
                        else step_flow_name = step_flow;

                        lvItem.SubItems.Add(step_flow_name);



                        lvItem.SubItems.Add(get_goods_name(arr[i]["goodsCode"].ToString()));

                        string entry_dt = arr[i]["entryDt"].ToString();
                        lvItem.SubItems.Add(entry_dt.Substring(8, 2) + ":" + entry_dt.Substring(10, 2));

                        int point_usage_cnt = convert_number(arr[i]["pointUsageCnt"].ToString());
                        int point_usage = convert_number(arr[i]["pointUsage"].ToString());
                        lvItem.SubItems.Add(point_usage_cnt.ToString("N0"));
                        lvItem.SubItems.Add(point_usage.ToString("N0"));
                        lvItem.SubItems.Add(arr[i]["ticketNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["flowStep"].ToString());

                        //
                        if (step_flow == "0" | step_flow == "1" | step_flow == "2" | step_flow == "3" | step_flow == "4")
                        {
                            lvItem.ForeColor = Color.Black;
                        }
                        else
                        {
                            lvItem.ForeColor = Color.Gray;
                        }

                        mLvwList.Items.Add(lvItem);

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


        }




        private void btnAddPay_Click(object sender, EventArgs e)
        {
            mOrderItemList.Clear();
            mLvwOrderItem.SetObjects(mOrderItemList);


            // 체크
            for (int fs = 0; fs < lvwList.Items.Count; fs++)
            {
                if (lvwList.Items[fs].Checked)
                {
                    if (lvwList.Items[fs].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text !="4")
                    {
                        MessageBox.Show("선택한 항목중에 결제추가를 할 수 없는 건이 포함되어있습니다.", "thepos");
                        return;
                    }
                }
            }




            settle_ticket_no_list.Clear();
            settle_locker_no_list.Clear();
            settle_the_no_list.Clear();


            //
            for (int fs = 0; fs < lvwList.Items.Count; fs++)
            {

                if (lvwList.Items[fs].Checked)
                {

                    string t_ticket_no = lvwList.Items[fs].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text;
                    string t_locker_no = lvwList.Items[fs].SubItems[lvwList.Columns.IndexOf(no)].Text;

                    //
                    settle_ticket_no_list.Add(t_ticket_no);
                    settle_locker_no_list.Add(t_locker_no);



                    String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + t_ticket_no;
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
                                    // the_no를 모은다.
                                    settle_the_no_list.Add(arr[i]["theNo"].ToString());


                                    //
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

            settle_the_no_list = settle_the_no_list.Distinct().ToList();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (lvwList.CheckedItems.Count < 1)
            {
                return;
            }

            for (int i = 0; i < lvwList.CheckedItems.Count; i++)
            {
                if (lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text != "0" &
                    lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text != "1" &
                    lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text != "2" &
                    lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text != "3")
                {
                    MessageBox.Show("선택한 항목중에 퇴장처리를 할 수 없는 건이 포함되어있습니다.", "thepos");
                    return;
                }
            }


            //
            String ticket_input_dt = "";

            frmFlowTicketTime frm = new frmFlowTicketTime("Exit");
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                ticket_input_dt = frm.return_datetime;
            }
            else
            {
                return;
            }


            for (int i = 0; i < lvwList.CheckedItems.Count; i++)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = mBizDate;
                parameters["ticketNo"] = lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text;
                parameters["exitDt"] = ticket_input_dt;

                int t_point_usage_cnt = convert_number(lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(point_usage_cnt)].Text); 


                if (t_point_usage_cnt > 0)
                {
                    parameters["flowStep"] = "4";  // 퇴장(결제전)
                }
                else
                {
                    parameters["flowStep"] = "9";  // 퇴장(완료)
                }


                if (mRequestPatch("ticketFlow", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        //
                        thepos_app_log(1, this.Name, "퇴장", parameters["ticketNo"] + " -> " + parameters["flowStep"]);

                    }
                    else
                    {
                        thepos_app_log(3, this.Name, "mRequestPatch", "티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString());
                        MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    thepos_app_log(3, this.Name, "mRequestPatch", "시스템오류. ticketFlow\n\n" + mErrorMsg);
                    MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
                    return;
                }



                //
                if (mTicketMedia == "RF")
                {
                    string t_locker_no = lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(no)].Text;
                    string t_ticket_no = lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text;

                    if (t_point_usage_cnt > 0)
                    {
                        set_locker_by_locker_no(t_locker_no, t_ticket_no, "4", get_today_date() + get_today_time());


                        // 정상 결제후 업데이트
                        thepos_app_log(1, this.Name, "락커 초기화 SKIP. 결제후 예정", "locker_no=" + t_locker_no);

                    }
                    else
                    {
                        // 락커 업데이트
                        set_locker_by_locker_no(t_locker_no, "", "", "");

                        thepos_app_log(1, this.Name, "락커초기화", "locker_bo=" + t_locker_no);
                    }
                }
            }

            //
            load_ticket_list(this_no);

            btn_4();
        }

        private void btn123_Click(object sender, EventArgs e)
        {
            btn_0123();
        }

        private void btn_0123()
        {
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                if (lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text == "0" |
                    lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text == "1" |
                    lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text == "2" |
                    lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text == "3")
                {
                    lvwList.Items[i].Checked = true;
                }
                else
                {
                    lvwList.Items[i].Checked = false;
                }
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btn_4();
        }

        private void btn_4()
        {
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                if (lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text == "4")
                {
                    lvwList.Items[i].Checked = true;
                }
                else
                {
                    lvwList.Items[i].Checked = false;
                }
            }
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
