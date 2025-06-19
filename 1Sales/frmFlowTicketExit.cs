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
using static System.Windows.Forms.AxHost;
using System.Globalization;
using static thepos.frmSub;
using thepos;

namespace theposw._1Sales
{
    public partial class frmFlowTicketExit : Form
    {
        public static String this_the_no = "";

        public static ListView mLvwList;


        public frmFlowTicketExit()
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
            lvwList.SmallImageList = imgList;


            mLvwList = lvwList;



            // 화면 떴다.
            isFlowTicketExit = true;



            // 할인 즐겨찾기
            for (int i = 0; i < mDCR.Length; i++)
            {
                cbDCR.Items.Add(mDCR[i].dcr_name);
            }

            //
            if (mDCR.Length > 0) cbDCR.SelectedIndex = 0;

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            lvwList.Items.Clear();
            lblTheNo.Text = "";


            if (tbTicketNo.Text.Length < 20)
            {
                SetDisplayAlarm("W", "티켓번호 오류.");
                thepos_app_log(3, this.Name, "scanner", "skip. no=" + tbTicketNo.Text);
                return;
            }

            this_the_no = tbTicketNo.Text.Substring(0, 20);
            tbTicketNo.Text = "";

            load_ticket_list(this_the_no);

            btn_0123();

            lblTheNo.Text = this_the_no;
        }

        private void tbTicketNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                lvwList.Items.Clear();
                lblTheNo.Text = "";

                if (tbTicketNo.Text.Length < 20)
                {
                    SetDisplayAlarm("W", "티켓번호 오류.");
                    thepos_app_log(3, this.Name, "scanner", "skip. no=" + tbTicketNo.Text);
                    tbTicketNo.Text = "";
                    return;
                }

                this_the_no = tbTicketNo.Text.Substring(0, 20);

                load_ticket_list(this_the_no);

                btn_0123();

                lblTheNo.Text = this_the_no;

                tbTicketNo.Clear();
                tbTicketNo.Focus();

            }
        }


        public static void load_ticket_list()
        {
            load_ticket_list(this_the_no);
        }



        public static void load_ticket_list(String the_no)
        {
            // 0 발권
            // 1 입장 - Blue or Red
            // 2 충전
            // 3 사용 
            // 4 퇴장 (정산전) - Black
            // 8 취소        - Gray
            // 9 정산 (완료) - Gray


            mLvwList.Items.Clear();

            String now_dt = get_today_date() + get_today_time();

            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&theNo=" + the_no;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);


                    for (int i = 0; i < arr.Count; i++)
                    {
                        int n_ot_amt = 0;
                        int n_ot_cnt = 0;
                        int n_ot_amount = 0;

                        String tStatName = "";

                        ListViewItem item = new ListViewItem();
                        String ticket_no = arr[i]["ticketNo"].ToString();
                        String tStat = arr[i]["flowStep"].ToString();
                        String entry_dt = arr[i]["entryDt"].ToString();
                        String exit_dt = arr[i]["exitDt"].ToString();
                        String goods_code = arr[i]["goodsCode"].ToString();
                        String goods_cnt = arr[i]["goodsCnt"].ToString();
                        int gap_mm = 0;
                        int ot_mm = 0;


                        // ■ 𖡖 ▶ ▷ ↺ ↻ ↻ ↺ ⟳ ⟲

                        if (tStat == "0") tStatName = "▷ 발권";
                        else if (tStat == "1") tStatName = "▶ 입장";
                        else if (tStat == "2") tStatName = "▶ 충전";
                        else if (tStat == "3") tStatName = "▶ 사용";
                        else if (tStat == "4") tStatName = "■ 퇴장";
                        else if (tStat == "8") tStatName = "✕ 취소";
                        else if (tStat == "9") tStatName = "□ 완료";
                        else                   tStatName = tStat;

                        //
                        item.Text = "";
                        item.SubItems.Add(ticket_no.Substring(20, 2));
                        item.SubItems.Add(tStatName);
                        item.SubItems.Add(get_goods_name(goods_code));
                        item.SubItems.Add(goods_cnt);


                        if (entry_dt.Length == 14)
                        {
                            item.SubItems.Add(entry_dt.Substring(8, 2) + ":" + entry_dt.Substring(10, 2));
                        }
                        else
                        {
                            item.SubItems.Add("");
                        }



                        
                        if (tStat == "0" | tStat == "1" | tStat == "2" | tStat == "3")
                        {
                            // 퇴장 예상시간
                            string expect_exit_dt = get_expect_exit_dt(goods_code, entry_dt);
                            item.SubItems.Add(expect_exit_dt.Substring(8, 2) + ":" + expect_exit_dt.Substring(10, 2));

                            // 경과
                            DateTime dt_curr = DateTime.ParseExact(now_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

                            DateTime dt_entry = DateTime.ParseExact(entry_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

                            DateTime dt_exit = DateTime.ParseExact(expect_exit_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);


                            if (dt_curr < dt_exit)
                            {
                                // 남음
                                TimeSpan diff = dt_exit - dt_curr;
                                gap_mm = (int)diff.TotalMinutes;

                                item.SubItems.Add(gap_mm + "분 남음");
                                item.ForeColor = Color.Blue;

                                //추가금액
                                item.SubItems.Add("");
                            }
                            else
                            {
                                // 지남
                                TimeSpan diff = dt_curr - dt_entry;
                                gap_mm = (int)diff.TotalMinutes;

                                diff = dt_curr - dt_exit;
                                ot_mm = (int)diff.TotalMinutes;


                                item.SubItems.Add(ot_mm + "분 지남");
                                item.ForeColor = Color.Red;

                                n_ot_cnt = get_ot_cnt(gap_mm, goods_code);
                                n_ot_amt = get_ot_amt(goods_code);
                                n_ot_amount = n_ot_cnt * n_ot_amt;

                                item.SubItems.Add(n_ot_amount.ToString("N0"));

                            }


                        }
                        else if (tStat == "4")  // 퇴장
                        {
                            //퇴장
                            item.SubItems.Add(exit_dt.Substring(8, 2) + ":" + exit_dt.Substring(10, 2));

                            // 경과
                            DateTime dt1 = DateTime.ParseExact(entry_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                            DateTime dt2 = DateTime.ParseExact(exit_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

                            // 시간 차이 계산
                            TimeSpan diff = dt2 - dt1;
                            gap_mm = (int)diff.TotalMinutes;


                            //
                            int n_available_minute = get_goods_available_minute(goods_code);
                            ot_mm = gap_mm - n_available_minute;


                            if (ot_mm > 0)
                            {
                                item.SubItems.Add(ot_mm + "분");
                            }
                            else
                            {
                                item.SubItems.Add("");
                            }


                            //추가금액
                            if (gap_mm > 0)
                            {
                                n_ot_cnt = get_ot_cnt(gap_mm, goods_code);
                                n_ot_amt = get_ot_amt(goods_code);
                                n_ot_amount = n_ot_cnt * n_ot_amt;

                                item.SubItems.Add(n_ot_amount.ToString("N0"));
                            }
                            else
                            {
                                item.SubItems.Add("");
                            }

                            item.ForeColor = Color.Black;

                        }
                        else if (tStat == "8" | tStat == "9")   // 취소, 완료
                        {
                            // 퇴장
                            if (exit_dt == "")
                            {
                                item.SubItems.Add("");
                            }
                            else
                            {
                                item.SubItems.Add(exit_dt.Substring(8, 2) + ":" + exit_dt.Substring(10, 2));
                            }

                            // 경과시간
                            item.SubItems.Add("");

                            //추가금액
                            item.SubItems.Add("");

                            item.ForeColor = Color.Gray;
                        }


                        item.SubItems.Add(ticket_no);
                        item.SubItems.Add(tStat);
                        item.SubItems.Add(goods_code);  // goods_code
                        item.SubItems.Add(entry_dt);  // entry_dt
                        item.SubItems.Add(exit_dt);  // exit_dt
                        item.SubItems.Add(gap_mm + "");  // get_dt
                        item.SubItems.Add(n_ot_cnt + "");
                        item.SubItems.Add(n_ot_amt + "");
                        item.SubItems.Add(get_link_goods_code(goods_code));  // link_goods_code
                        item.Checked = false;



                        mLvwList.Items.Add(item);

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



                int n_ot_cnt = Int16.Parse(lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ot_cnt)].Text);
                int n_ot_amt = Int16.Parse(lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ot_amt)].Text);

                if (n_ot_cnt > 0 & n_ot_amt > 0)
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
                        thepos_app_log(1, this.Name, "퇴장", parameters["ticketNo"] +  " -> " + parameters["flowStep"]);

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
            }

            //
            load_ticket_list(this_the_no);

            btn_4();
        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            if (lvwList.CheckedItems.Count < 1)
            {
                return;
            }


            for (int i = 0; i < lvwList.CheckedItems.Count; i++)
            {
                if (lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text != "4")
                {
                    MessageBox.Show("선택한 항목중에 결제주문를 할 수 없는 건이 포함되어있습니다.", "thepos");
                    return;
                }
            }



            for (int i = 0; i < lvwList.CheckedItems.Count; i++)
            {
                if (lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text != "4")
                {
                    continue;
                }

                MemOrderItem orderItem = new MemOrderItem();

                int t_cnt = int.Parse(lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ot_cnt)].Text);
                int t_amt = int.Parse(lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ot_amt)].Text);

                if (t_cnt * t_amt == 0)
                {
                    continue;
                }


                int link_idx = -1;
                String link_code = lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(link_goods_code)].Text;

                for (int k = 0; k < mGoodsList.Count; k++)
                {
                    if (mGoodsList[k].goods_code == link_code)
                    {
                        link_idx = k;
                    }
                }

                if (link_idx == -1)
                {
                    continue;
                }

                orderItem.amt = t_cnt * t_amt;


                int num = 1;
                get_number(lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(goods_cnt)].Text, ref num);

                orderItem.cnt = num;


                //
                mOrderOptionItemList.Clear();
                orderItem.option_item_cnt = mOrderOptionItemList.Count;
                orderItem.option_no = "";
                orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..
                orderItem.option_name_description = "";   // 리스트뷰 상품항목 아랫줄에 표시
                orderItem.option_amt_description = "";    // 리스트뷰 단가항목 아랫줄에 표시

                //
                orderItem.order_no = mOrderItemList.Count + 1;
                orderItem.goods_code = mGoodsList[link_idx].goods_code.ToString();
                orderItem.goods_name = mGoodsList[link_idx].goods_name;
                orderItem.ticket = mGoodsList[link_idx].ticket;
                orderItem.taxfree = mGoodsList[link_idx].taxfree;
                orderItem.allim = mGoodsList[link_idx].allim;

                orderItem.dcr_type = "";
                orderItem.dcr_des = "";
                orderItem.dcr_value = 0;
                orderItem.shop_code = mGoodsList[link_idx].shop_code;
                orderItem.nod_code1 = mGoodsList[link_idx].nod_code1;
                orderItem.nod_code2 = mGoodsList[link_idx].nod_code2;

                //
                orderItem.ticket_no = lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text;
                orderItem.add_job = "TF4T9";   // 퇴장시 추가요금 결제

                //
                replace_mem_order_item(ref orderItem, "add");

                mOrderItemList.Add(orderItem);
                mLvwOrderItem.SetObjects(mOrderItemList);

                mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].EnsureVisible();
                mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].Selected = true;

                bool is_move = if_is_dcr_e_move_last();

                if (is_move)
                {
                    recalculate_dcr_e_dc_amount(mLvwOrderItem.Items.Count - 2);
                }
                else
                {
                    recalculate_dcr_e_dc_amount(mLvwOrderItem.Items.Count - 1);
                }

                //
                thepos_app_log(1, this.Name, "결제주문", "no=" + orderItem.ticket_no + " cnt=" + orderItem.cnt + "amt=" + orderItem.amt);

            }

            ReCalculateAmount();

        }



        private void btnDC_Click(object sender, EventArgs e)
        {
            // 

            if (cbDCR.SelectedIndex < 0)
            {
                MessageBox.Show("할인항목을 선택해주세요.", "thepos");
                return;
            }


            String code = mDCR[cbDCR.SelectedIndex].dcr_code;
            String name = mDCR[cbDCR.SelectedIndex].dcr_name;
            String des = mDCR[cbDCR.SelectedIndex].dcr_des;
            String type = mDCR[cbDCR.SelectedIndex].dcr_type;
            int value = mDCR[cbDCR.SelectedIndex].dcr_value;


            //
            if (des == "E")
            {

            }
            else
            {
                if (lvwList.CheckedItems.Count != 1)
                {
                    MessageBox.Show("할인대상 1건만 선택해야합니다.", "thepos");
                    return;
                }

                if (lvwList.CheckedItems[0].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text != "4")
                {
                    MessageBox.Show("할인적용을 할 수 없는 건입니다.", "thepos");
                    return;
                }
            }


            applyDCR(des, type, value, code, "[전체할인]", name);
        }


        void applyDCR(String des, String type, int value, String e_dcr_code, String e_dcr_name, String description_name)
        {



            if (des == "S")   // 선택항목 할인
            {
                String selected_ticket_no = lvwList.CheckedItems[0].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text;

                if (isExist_DCR("E"))
                {
                    MessageBox.Show("[전체할인]이 적용된 경우 선택할인 불가", "thepos");
                    return;
                }


                int target_idx = -1;

                for (int i = 0; mOrderItemList.Count > i; i++)
                {
                    if (mOrderItemList[i].ticket_no == selected_ticket_no)
                    {
                        target_idx = i;
                    }
                }

                if (target_idx == -1)
                {
                    thepos_app_log(3, this.Name, "할인적용", "오류. selected_ticket_no=" + selected_ticket_no);
                    MessageBox.Show("할인적용 오류.", "thepos");
                    return;
                }


                MemOrderItem orderItem = mOrderItemList[target_idx];
                orderItem.dcr_des = des;
                orderItem.dcr_type = type;
                orderItem.dcr_value = value;


                // 
                replace_mem_order_item(ref orderItem, "update");

                mOrderItemList[target_idx] = orderItem;
                mLvwOrderItem.SetObjects(mOrderItemList);
                mLvwOrderItem.Items[target_idx].Selected = true;

                ReCalculateAmount();

                thepos_app_log(1, this.Name, "할인", "선택 dcr_des=" + orderItem.dcr_des + " dcr_type=" + orderItem.dcr_type + " dcr_value=" + orderItem.dcr_value);



            }
            else if (des == "E")  // 전체할인
            {
                int t_dc_amount = 0;
                bool isExist_E = false;


                if (isExist_DCR("S"))
                {
                    SetDisplayAlarm("W", "[선택할인]이 적용된 경우 전체할인 불가.");
                    return;
                }


                int dcr_e_idx = get_lv_DCR("E");

                if (dcr_e_idx >= 0)  // 
                {
                    isExist_E = true;
                }


                if (type == "A")
                {
                    t_dc_amount = value;
                }
                else
                if (type == "R")
                {
                    int t_amount = 0;
                    for (int i = 0; i < mOrderItemList.Count; i++)
                    {
                        if (dcr_e_idx != i)  // 전체할인항목 레코드는 합계에서 제외
                        {
                            t_amount += ((mOrderItemList[i].amt + mOrderItemList[i].option_amt) * mOrderItemList[i].cnt);
                        }
                    }
                    t_dc_amount = (t_amount * value) / 100;
                }
                else return;



                MemOrderItem orderItem = new MemOrderItem();

                if (isExist_E == true)
                {
                    orderItem = mOrderItemList[dcr_e_idx];
                }


                mOrderOptionItemList.Clear();

                orderItem.option_item_cnt = mOrderOptionItemList.Count;
                orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..


                orderItem.dcr_des = des;
                orderItem.dcr_type = type;
                orderItem.dcr_value = value;
                orderItem.cnt = 1;
                orderItem.amt = 0;
                orderItem.option_amt = 0;
                orderItem.dc_amount = t_dc_amount;
                orderItem.net_amount = -t_dc_amount;
                orderItem.goods_code = e_dcr_code;  // 전체 할인코드
                orderItem.goods_name = e_dcr_name;
                orderItem.option_name_description = description_name;

                orderItem.shop_code = myShopCode;  //  포스 업장코드



                if (isExist_E == true)
                {
                    //
                    replace_mem_order_item(ref orderItem, "update");

                    mOrderItemList[dcr_e_idx] = orderItem;
                    mLvwOrderItem.SetObjects(mOrderItemList);

                    mLvwOrderItem.Items[dcr_e_idx].Selected = true;
                }
                else
                {
                    //
                    replace_mem_order_item(ref orderItem, "add");

                    mOrderItemList.Add(orderItem);
                    mLvwOrderItem.SetObjects(mOrderItemList);

                    mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].EnsureVisible();
                    mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].Selected = true;

                    //? 전체할인항목을 맨아래 추가후 -> 이후에도 맨아래줄을 유지할 수 있는 방안 필요.
                }

                ReCalculateAmount();

                //
                thepos_app_log(1, this.Name, "할인", "전체 dcr_des = " + orderItem.dcr_des + " dcr_type = " + orderItem.dcr_type + " dcr_value = " + orderItem.dcr_value);
            }
        }



        private void btnDCCancel_Click(object sender, EventArgs e)
        {
            //할인취소
            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                MemOrderItem orderItem = mOrderItemList[i];

                if (orderItem.dcr_des == "S")
                {
                    orderItem.dcr_des = "";
                    orderItem.dcr_type = "";
                    orderItem.dcr_value = 0;
                    orderItem.dc_amount = 0;

                    replace_mem_order_item(ref orderItem, "update");

                    mOrderItemList[i] = orderItem;

                    mLvwOrderItem.SetObjects(mOrderItemList);

                    ReCalculateAmount();

                    thepos_app_log(1, this.Name, "할인취소", "선택");
                }
                else if (orderItem.dcr_des == "E")
                {
                    mOrderItemList.RemoveAt(i);
                    mLvwOrderItem.SetObjects(mOrderItemList);

                    ReCalculateAmount();

                    thepos_app_log(1, this.Name, "할인취소", "전체");
                }
            }
        }



        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (lvwList.CheckedItems.Count < 1)
            {
                return;
            }


            for (int i = 0; i < lvwList.CheckedItems.Count; i++)
            {
                if (lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(flow_step_code)].Text == "9")
                {
                    MessageBox.Show("선택한 항목중에 강제종료처리를 할 수 없는 건이 포함되어 있습니다.", "thepos");
                    return;
                }
            }


            if (MessageBox.Show("선택한 항목 " + lvwList.CheckedItems.Count + "건을 강제종료 처리합니다.", "thwpos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
            else
            {
                return;
            }



            //
            String ticket_input_dt = "";

            frmFlowTicketTime frm = new frmFlowTicketTime("End");
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
                parameters["settlementDt"] = ticket_input_dt;
                parameters["flowStep"] = "9";  // 완료

                if (mRequestPatch("ticketFlow", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        //
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

            //
            load_ticket_list(this_the_no);
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwList.CheckedItems.Count != 1)
            {
                return;
            }


            if (mTicketMedia == "BC")  // 써멀|영수증
            {
                String t_ticket_no = lvwList.CheckedItems[0].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text.ToString();
                String t_goods_code = lvwList.CheckedItems[0].SubItems[lvwList.Columns.IndexOf(goods_code)].Text.ToString();

                print_bill_ticket(t_ticket_no, t_goods_code, 1, "");
            }
            else if (mTicketMedia == "TG")  // 전용|띠지
            {
                String t_ticket_no = lvwList.CheckedItems[0].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text.ToString();
                String t_goods_code = lvwList.CheckedItems[0].SubItems[lvwList.Columns.IndexOf(goods_code)].Text.ToString();
                String t_goods_name = lvwList.CheckedItems[0].SubItems[lvwList.Columns.IndexOf(goods_name)].Text.ToString();

                int t_goods_cnt = convert_number(lvwList.CheckedItems[0].SubItems[lvwList.Columns.IndexOf(goods_cnt)].Text.ToString(), 1);
                
                String t_datetime = lvwList.CheckedItems[0].SubItems[lvwList.Columns.IndexOf(entry_dt)].Text.ToString();
                int t_goods_amt = get_goods_amt(t_goods_code);

                print_label_ticket(t_ticket_no, t_datetime.Substring(0,8), t_datetime.Substring(8, 6), t_goods_code, t_goods_name, t_goods_cnt, t_goods_amt, "");

            }
            else if (mTicketMedia == "RF")  // 팔찌|RF[예정]
            {
                // 
            }
        }

        public static String get_expect_exit_dt(String goods_code, String entry_dt)
        {
            int minutesToAdd = get_goods_available_minute(goods_code);
            DateTime dateTime = DateTime.ParseExact(entry_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            dateTime = dateTime.AddMinutes(minutesToAdd);
            return dateTime.ToString("yyyyMMddHHmmss");
        }


        public static int get_goods_available_minute(String goods_code)
        {
            for (int i = 0; i < mGoodsTicket.Length; i++)
            {
                if (mGoodsTicket[i].goods_code == goods_code)
                {
                    if (is_number(mGoodsTicket[i].available_minute))
                    {
                        return Int16.Parse(mGoodsTicket[i].available_minute);
                    }
                }
            }

            return 0;
        }

        public static int get_ot_cnt(int gap_mm, String goods_code)
        {
            String is_charge = "";
            String available_minute = "";
            String ot_free_minute = "";
            String ot_std_minute = "";

            for (int i = 0; i < mGoodsTicket.Length; i++)
            {
                if (mGoodsTicket[i].goods_code == goods_code)
                {
                    is_charge = mGoodsTicket[i].is_charge;
                    available_minute = mGoodsTicket[i].available_minute;
                    ot_free_minute = mGoodsTicket[i].ot_free_minute;
                    ot_std_minute = mGoodsTicket[i].ot_std_minute;
                }
            }

            if (is_charge != "Y" | !is_number(ot_free_minute) | !is_number(ot_std_minute))
            {
                return 0;
            }

            int n_available_minute = Int16.Parse(available_minute);
            int n_ot_free_minute = Int16.Parse(ot_free_minute);

            //
            if (gap_mm < n_available_minute + n_ot_free_minute)
            {
                return 0;
            }

            //
            int n_ot_std_minute = Int16.Parse(ot_std_minute);
            int real_ot_minute = gap_mm - n_available_minute - n_ot_free_minute;
            int ot_cnt = (real_ot_minute + n_ot_std_minute - 1) / n_ot_std_minute;

            return ot_cnt;
        }
        public static int get_ot_amt(String goods_code)
        {
            String is_charge = "";
            String ot_amt = "";

            for (int i = 0; i < mGoodsTicket.Length; i++)
            {
                if (mGoodsTicket[i].goods_code == goods_code)
                {
                    is_charge = mGoodsTicket[i].is_charge;
                    ot_amt = mGoodsTicket[i].ot_amt;
                }
            }

            if (is_charge != "Y" | !is_number(ot_amt))
            {
                return 0;
            }


            int n_ot_amt = Int16.Parse(ot_amt);

            return n_ot_amt;
        }

        public static String get_link_goods_code(String goods_code)
        {
            String link_goods_code = "";


            for (int i = 0; i < mGoodsTicket.Length; i++)
            {
                if (mGoodsTicket[i].goods_code == goods_code)
                {
                    link_goods_code = mGoodsTicket[i].link_goods_code;
                }
            }

            return link_goods_code;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            thepos_app_log(1, this.Name, "close", "");
            this.Close();
        }


        private void btn0123_Click(object sender, EventArgs e)
        {
            btn_0123();
        }

        private void btn_0123()
        { 
            for (int i = 0;i < lvwList.Items.Count;i++)
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

        private void frmFlowTicketExit_FormClosed(object sender, FormClosedEventArgs e)
        {

            //
            isFlowTicketExit = false;


            frmSales.ConsoleEnable();

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }

        private void tbTicketNo_Leave(object sender, EventArgs e)
        {

        }
    }
}
