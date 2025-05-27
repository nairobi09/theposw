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
using thepos._9SysAdmin;
using theposw._1Sales;
using System.Globalization;

namespace thepos
{

    // ↺


    public partial class frmFlowTicket : Form
    {
        String this_biz_date = "";

        public frmFlowTicket()
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
            
            dtBusiness.Value = new DateTime(convert_number(mBizDate.Substring(0,4)), convert_number(mBizDate.Substring(4,2)), convert_number(mBizDate.Substring(6,2)));




        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmFlowTicketing_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            this_biz_date = dtBusiness.Value.ToString("yyyyMMdd");


            get_flow_ticket("");
        }


        private void get_flow_ticket(String rTheNo)
        { 
            lvwList.Items.Clear();

            String now_dt = get_today_date() + get_today_time();

            String save_the_no = "";
            int entry_cnt = 0;

            String save_expect_exit_dt = "20991231235959";
            String entry_dt = "";

            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + this_biz_date + "&theNo=" + rTheNo + "&flowStep=0123";   // flowStep=01 ->  0 or 1
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        save_the_no = arr[0]["theNo"].ToString();
                    }


                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (arr[i]["theNo"].ToString() != save_the_no)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = save_the_no;
                            item.SubItems.Add(entry_cnt + "");
                            item.SubItems.Add(entry_dt.Substring(8, 2) + ":" + entry_dt.Substring(10, 2));

                            // 퇴장시간 계산
                            item.SubItems.Add(save_expect_exit_dt.Substring(8, 2) + ":" + save_expect_exit_dt.Substring(10, 2));

                            // 남은시간 경과시간
                            int gap_mm = get_diff_minute(now_dt, save_expect_exit_dt);

                            if (gap_mm > 0)
                            {
                                item.SubItems.Add(gap_mm + "분 남음");
                                item.ForeColor = Color.Blue;
                            }
                            else
                            {
                                item.SubItems.Add(Math.Abs(gap_mm) + "분 지남");
                                item.ForeColor = Color.Red;
                            }

                            lvwList.Items.Add(item);

                            //
                            save_expect_exit_dt = "20991231235959";
                            entry_cnt = 0;
                        }
                        
                        //
                        save_the_no = arr[i]["theNo"].ToString();
                        entry_cnt++;

                        String goods_code = arr[i]["goodsCode"].ToString();
                        entry_dt = arr[i]["entryDt"].ToString();

                        // 퇴장 예상시간
                        string expect_exit_dt = get_expect_exit_dt(goods_code, entry_dt); 

                        if (Int32.Parse(save_expect_exit_dt.Substring(6,8)) > Int32.Parse(expect_exit_dt.Substring(6, 8)))
                        {
                            save_expect_exit_dt = expect_exit_dt;
                            entry_dt = arr[i]["entryDt"].ToString();
                        }

                    }

                    //
                    if (save_the_no != "")
                    {
                        ListViewItem item2 = new ListViewItem();
                        item2.Text = save_the_no;
                        item2.SubItems.Add(entry_cnt + "");
                        item2.SubItems.Add(entry_dt.Substring(8, 2) + ":" + entry_dt.Substring(10, 2));

                        // 퇴장시간 계산
                        item2.SubItems.Add(save_expect_exit_dt.Substring(8, 2) + ":" + save_expect_exit_dt.Substring(10, 2));


                        // 남은시간 경과시간
                        int gap_mm = get_diff_minute(now_dt, save_expect_exit_dt);

                        if (gap_mm > 0)
                        {
                            item2.SubItems.Add(gap_mm + "분 남음");
                            item2.ForeColor = Color.Blue;
                        }
                        else
                        {
                            item2.SubItems.Add(Math.Abs(gap_mm) + "분 지남");
                            item2.ForeColor = Color.Red;
                        }

                        lvwList.Items.Add(item2);

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

        private void btnTicketDetail_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                return;
            }


            String the_no = lvwList.SelectedItems[0].Text.Substring(0,20);


            frmFlowTicketListl frm = new frmFlowTicketListl(this_biz_date, the_no);
            frm.ShowDialog();



        }

        private void tbTicketNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;


                if (tbTicketNo.Text.Length < 20)
                {
                    thepos_app_log(3, this.Name, "scanner", "skip. no=" + tbTicketNo.Text);
                    return;
                }


                String no = tbTicketNo.Text.Substring(0,20);

                get_flow_ticket(no);


                tbTicketNo.Clear();
                tbTicketNo.Focus();

            }
        }

        private void tbTicketNo_Leave(object sender, EventArgs e)
        {
            tbTicketNo.Focus();
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            ticket_monitor();
        }


        private void ticket_monitor()
        {
            lblClickTime.Text = "";

            lblActTheNoCnt.Text = "";
            lblTheNoCnt.Text = "";
            lblActTicketNoCnt.Text = "";
            lblTicketNoCnt.Text = "";

            String sUrl = "ticketFlowMonitor?siteId=" + mSiteId + "&bizDt=" + mBizDate;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["tmData"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        lblActTheNoCnt.Text = arr[0]["actTheNoCnt"].ToString();
                        lblTheNoCnt.Text = arr[0]["theNoCnt"].ToString();

                        lblActTicketNoCnt.Text = arr[0]["actTicketNoCnt"].ToString();
                        lblTicketNoCnt.Text = arr[0]["ticketNoCnt"].ToString();

                        lblClickTime.Text = get_today_time().Substring(0, 2) + ":" + get_today_time().Substring(2, 2);
                    }
                }
            }
        }



        private String get_expect_exit_dt(String goods_code, String entry_dt)
        {
            // 퇴장예상시간 구하기
            int minutesToAdd = get_goods_available_minute(goods_code);
            DateTime dateTime = DateTime.ParseExact(entry_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            dateTime = dateTime.AddMinutes(minutesToAdd);
            return dateTime.ToString("yyyyMMddHHmmss");
        }


        private int get_diff_minute(String now_dt, String expect_exit_dt)
        {
            // 경과
            DateTime dt1 = DateTime.ParseExact(now_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(expect_exit_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

            // 시간 차이 계산 (절대값으로)
            TimeSpan diff = dt2 - dt1;

            // hh:mm 형식으로 출력
            return (int)diff.TotalMinutes;
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

    }
}
