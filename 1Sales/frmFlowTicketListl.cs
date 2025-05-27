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

namespace theposw._1Sales
{
    public partial class frmFlowTicketListl : Form
    {

        String this_biz_date;
        String the_no;


        public frmFlowTicketListl(String this_biz_date, String the_no)
        {
            this.this_biz_date = this_biz_date;
            this.the_no = the_no;

            InitializeComponent();

            initialize_the();


            lblTitle.Text = "팀티켓 - " + the_no;


            //
            thepos_app_log(1, this.Name, "Open", "");


            load_ticket_list();


            // 최초 퇴장 대기
            btn_0123();

        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwList.SmallImageList = imgList;

        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            load_ticket_list();
        }


        private void load_ticket_list()
        {
            // 0 발권
            // 1 입장 - Blue or Red
            // 2 충전
            // 3 사용 
            // 4 퇴장 (정산전) - Black
            // 9 정산 (완료) - Gray

            String now_dt = get_today_date() + get_today_time();


            lvwList.Items.Clear();

            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + this_biz_date + "&theNo=" + the_no;
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
                        int gap_mm = 0;


                        // ■ 𖡖 ▶ ▷ ↺ ↻ ↻ ↺ ⟳ ⟲

                             if (tStat == "0") tStatName = "▷ 발권";
                        else if (tStat == "1") tStatName = "▶ 입장";
                        else if (tStat == "2") tStatName = "▶ 충전";
                        else if (tStat == "3") tStatName = "▶ 사용";
                        else if (tStat == "4") tStatName = "■ 퇴장";
                        else if (tStat == "9") tStatName = "□ 퇴장";
                        else                   tStatName = tStat;

                        //
                        item.Text = "";
                        item.SubItems.Add(ticket_no.Substring(14, 6) + "-" + ticket_no.Substring(20, 2));
                        item.SubItems.Add(tStatName);
                        item.SubItems.Add(get_goods_name(goods_code));

                        
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
                            DateTime dt1 = DateTime.ParseExact(now_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                            DateTime dt2 = DateTime.ParseExact(expect_exit_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

                            // 시간 차이 계산
                            TimeSpan diff = dt2 - dt1;

                            // hh:mm 형식으로 출력
                            gap_mm = (int)diff.TotalMinutes;

                            if (gap_mm > 0)
                            {
                                item.SubItems.Add(gap_mm + "분 남음");
                                item.ForeColor = Color.Blue;

                                //추가금액
                                item.SubItems.Add("");
                            }
                            else
                            {
                                // 음수라 절대값으로
                                gap_mm = Math.Abs(gap_mm);


                                item.SubItems.Add(gap_mm + "분 지남");
                                item.ForeColor = Color.Red;

                                //
                                int n_available_minute = get_goods_available_minute(goods_code);
                                int ot_mm = gap_mm - n_available_minute;

                                //추가금액
                                if (ot_mm > 0)
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
                            int ot_mm = gap_mm - n_available_minute;


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
                        else if (tStat == "9")   //  완료
                        {
                            // 퇴장
                            item.SubItems.Add(exit_dt.Substring(8, 2) + ":" + exit_dt.Substring(10, 2));

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

                        

                        lvwList.Items.Add(item);

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


        private void btnEntry_Click(object sender, EventArgs e)
        {
            if (lvwList.CheckedItems.Count < 1)
            {
                return;
            }

            //
            String ticket_input_dt = "";

            frmFlowTicketTime frm = new frmFlowTicketTime("Entry");
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
                parameters["bizDt"] = this_biz_date;
                parameters["ticketNo"] = lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text;
                parameters["entryDt"] = ticket_input_dt;
                parameters["flowStep"] = "1";  // 입장

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
            load_ticket_list();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            if (lvwList.CheckedItems.Count < 1)
            {
                return;
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
                parameters["bizDt"] = this_biz_date;
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
            load_ticket_list();

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
                    continue;
                }

                MemOrderItem orderItem = new MemOrderItem();

                orderItem.cnt = int.Parse(lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ot_cnt)].Text);
                orderItem.amt = int.Parse(lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ot_amt)].Text);

                if (orderItem.cnt * orderItem.amt == 0)
                {
                    continue;
                }


                int link_idx = -1;
                String link_code = lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(link_goods_code)].Text;

                for (int k = 0; k < mGoodsItem.Length; k++)
                {
                    if (mGoodsItem[k].goods_code == link_code)
                    {
                        link_idx = k;
                    }
                }

                if (link_idx == -1)
                {
                    continue;
                }


                //
                mOrderOptionItemList.Clear();
                orderItem.option_item_cnt = mOrderOptionItemList.Count;
                orderItem.option_no = "";
                orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..
                orderItem.option_name_description = "";   // 리스트뷰 상품항목 아랫줄에 표시
                orderItem.option_amt_description = "";    // 리스트뷰 단가항목 아랫줄에 표시

                //
                orderItem.order_no = mOrderItemList.Count + 1;
                orderItem.goods_code = mGoodsItem[link_idx].goods_code.ToString();
                orderItem.goods_name = mGoodsItem[link_idx].goods_name;
                orderItem.ticket = mGoodsItem[link_idx].ticket;
                orderItem.taxfree = mGoodsItem[link_idx].taxfree;
                orderItem.allim = mGoodsItem[link_idx].allim;

                orderItem.dcr_type = "";
                orderItem.dcr_des = "";
                orderItem.dcr_value = 0;
                orderItem.shop_code = mGoodsItem[link_idx].shop_code;
                orderItem.nod_code1 = mGoodsItem[link_idx].nod_code1;
                orderItem.nod_code2 = mGoodsItem[link_idx].nod_code2;

                //
                orderItem.ticket_no = lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text;

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
            }

            ReCalculateAmount();


            //
            Close();


        }



        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (lvwList.CheckedItems.Count < 1)
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
                parameters["bizDt"] = this_biz_date;
                parameters["ticketNo"] = lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text;
                parameters["settlementDt"] = ticket_input_dt;
                parameters["flowStep"] = "9";  // 입장

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
            load_ticket_list();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count < 1)
            {
                return;
            }


            if (mTicketMedia == "BC")  // 써멀|영수증
            {
                String ticket_no = lvwList.SelectedItems[0].Tag.ToString();
                String goods_code = lvwList.SelectedItems[0].SubItems[5].Text.ToString();

                print_bill_ticket(ticket_no, goods_code, 1, "");
            }
            else if (mTicketMedia == "TG")  // 전용|띠지
            {
                // 
            }
            else if (mTicketMedia == "RF")  // 팔찌|RF[예정]
            {
                // 
            }
        }

        private String get_expect_exit_dt(String goods_code, String entry_dt)
        {
            int minutesToAdd = get_goods_available_minute(goods_code);
            DateTime dateTime = DateTime.ParseExact(entry_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            dateTime = dateTime.AddMinutes(minutesToAdd);
            return dateTime.ToString("yyyyMMddHHmmss");
        }


        private int get_goods_available_minute(String goods_code)
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

        private int get_ot_cnt(int gap_mm, String goods_code)
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
                    ot_free_minute = mGoodsTicket[i].ot_free_minute; // 일반상품 0. 티켓상품 1
                    ot_std_minute = mGoodsTicket[i].ot_std_minute; // 과세품 0, 면세품 1
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
        private int get_ot_amt(String goods_code)
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

        private String get_link_goods_code(String goods_code)
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
            this.Close();
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
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

    }
}
