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
    public partial class frmFlowTicketFlowDetail : Form
    {

        String this_biz_date;
        String the_no;


        public frmFlowTicketFlowDetail(String this_biz_date, String the_no)
        {
            this.this_biz_date = this_biz_date;
            this.the_no = the_no;

            InitializeComponent();

            initialize_the();

            load_ticket_datail();

        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwList.SmallImageList = imgList;

        }

        private void load_ticket_datail()
        {
            // 0 발권
            // 1 입장
            // 2 충전
            // 3 사용"
            // 4 퇴장
            // 9 정산

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
                        String tStatName = "";

                        ListViewItem item = new ListViewItem();
                        String ticket_no = arr[i]["ticketNo"].ToString();
                        String tStat = arr[i]["flowStep"].ToString();
                        String entry_dt = arr[i]["entryDt"].ToString();
                        String exit_dt = arr[i]["exitDt"].ToString();
                        String goods_code = arr[i]["goodsCode"].ToString();
                        int gap_mm = 0;
                        int ot_amount = 0;


                        if (tStat == "0") tStatName = "발권";
                        else if (tStat == "1") tStatName = "입장";
                        else if (tStat == "2") tStatName = "충전";
                        else if (tStat == "3") tStatName = "사용";
                        else if (tStat == "4") tStatName = "퇴장";
                        else if (tStat == "9") tStatName = "정산";
                        else tStatName = tStat;

                        //
                        item.Text = ticket_no.Substring(6);
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


                        // 퇴장예정시간 계산 
                        if (tStat == "0" | tStat == "1" | tStat == "2" | tStat == "3")
                        {
                            int minutesToAdd = get_goods_available_minute(goods_code);

                            DateTime dateTime = DateTime.ParseExact(entry_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                            dateTime = dateTime.AddMinutes(minutesToAdd);
                            string expect_exit_dt = dateTime.ToString("yyyyMMddHHmmss");

                            item.SubItems.Add(expect_exit_dt.Substring(8, 2) + ":" + expect_exit_dt.Substring(10, 2));

                            // 경과
                            DateTime dt1 = DateTime.ParseExact(now_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                            DateTime dt2 = DateTime.ParseExact(expect_exit_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

                            // 시간 차이 계산 (절대값으로)
                            TimeSpan diff = dt2 - dt1;

                            // hh:mm 형식으로 출력
                            gap_mm = (int)diff.TotalMinutes;

                            if (gap_mm > 0)
                            {
                                item.SubItems.Add(gap_mm + "분 남음");
                            }
                            else
                            {
                                item.SubItems.Add(Math.Abs(gap_mm) + "분 지남");
                            }

                            //추가금액
                            item.SubItems.Add("");

                        }
                        else if (tStat == "4")  // 퇴장
                        {
                            //퇴장
                            item.SubItems.Add(exit_dt.Substring(8, 2) + ":" + exit_dt.Substring(10, 2));

                            // 경과
                            DateTime dt1 = DateTime.ParseExact(entry_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                            DateTime dt2 = DateTime.ParseExact(exit_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

                            // 시간 차이 계산 (절대값으로)
                            TimeSpan diff = dt2 - dt1;
                            gap_mm = (int)diff.TotalMinutes;

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
                                ot_amount = get_ot_amt(gap_mm, goods_code);
                                item.SubItems.Add(ot_amount.ToString("N0"));
                            }
                            else
                            {
                                item.SubItems.Add("");
                            }

                        }
                        else if (tStat == "9")   // 정산-완료
                        {
                            // 퇴장
                            item.SubItems.Add(exit_dt.Substring(8, 2) + ":" + exit_dt.Substring(10, 2));

                            // 경과시간
                            item.SubItems.Add("");

                            //추가금액
                            item.SubItems.Add("");
                        }



                        item.SubItems.Add(ticket_no);
                        item.SubItems.Add(tStat);
                        item.SubItems.Add(goods_code);  // goods_code
                        item.SubItems.Add(entry_dt);  // entry_dt
                        item.SubItems.Add(exit_dt);  // exit_dt
                        item.SubItems.Add(gap_mm + "");  // get_dt
                        item.SubItems.Add(ot_amount + "");
                        item.SubItems.Add(get_link_goods_code(goods_code));  // link_goods_code

                        item.Checked = true;

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

            String now_dt = get_today_date() + get_today_time();

            for (int i = 0; i < lvwList.CheckedItems.Count; i++)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = this_biz_date;
                parameters["ticketNo"] = lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text;
                parameters["entryDt"] = now_dt;
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
            load_ticket_datail();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            if (lvwList.CheckedItems.Count < 1)
            {
                return;
            }

            String now_dt = get_today_date() + get_today_time();

            for (int i = 0; i < lvwList.CheckedItems.Count; i++)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = this_biz_date;
                parameters["ticketNo"] = lvwList.CheckedItems[i].SubItems[lvwList.Columns.IndexOf(ticket_no)].Text;
                parameters["exitDt"] = now_dt;
                parameters["flowStep"] = "4";  // 퇴장

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
            load_ticket_datail();
        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count < 1)
            {
                return;
            }

            MemOrderItem orderItem = new MemOrderItem();





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


        private int get_ot_amt(int gap_mm, String goods_code)
        {
            String is_charge = "";
            String ot_free_minute = "";
            String ot_std_minute = "";
            String ot_amt = "";
            String link_goods_code = "";


            for (int i = 0; i < mGoodsTicket.Length; i++)
            {
                if (mGoodsTicket[i].goods_code == goods_code)
                {
                    is_charge = mGoodsTicket[i].is_charge;
                    ot_free_minute = mGoodsTicket[i].ot_free_minute; // 일반상품 0. 티켓상품 1
                    ot_std_minute = mGoodsTicket[i].ot_std_minute; // 과세품 0, 면세품 1
                    ot_amt = mGoodsTicket[i].ot_amt;
                    link_goods_code = mGoodsTicket[i].link_goods_code;
                }
            }

            if (is_charge != "Y" | !is_number(ot_free_minute) | !is_number(ot_std_minute) | !is_number(ot_amt))
            {
                return 0;
            }


            int n_ot_free_minute = Int16.Parse(ot_free_minute);
            int n_ot_std_minute = Int16.Parse(ot_std_minute);
            int n_ot_amt = Int16.Parse(ot_amt);


            int real_ot_minute = gap_mm - n_ot_free_minute;

            int ot_cnt = (real_ot_minute + n_ot_std_minute - 1) / n_ot_std_minute;

            return ot_cnt * n_ot_amt;
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

    }
}
