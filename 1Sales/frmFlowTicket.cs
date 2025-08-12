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
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace theposw._1Sales
{
    public partial class frmFlowTicket : Form
    {

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

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.tbTicketNo.Leave -= new System.EventHandler(this.tbTicketNo_Leave);

            this.Close();
        }

        private void frmFlowTicket_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }

        private void tbTicketNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                lvwList.Items.Clear();

                if (tbTicketNo.Text.Length < 20)
                {
                    SetDisplayAlarm("W", "티켓번호 오류.");
                    thepos_app_log(3, this.Name, "scanner", "skip. no=" + tbTicketNo.Text);
                    tbTicketNo.Text = "";
                    return;
                }

                String no = tbTicketNo.Text.Substring(0, 20);

                get_flow_ticket_4(no);
                get_flow_ticket_0123(no);

                tbTicketNo.Clear();
                tbTicketNo.Focus();

            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            if (tbTicketNo.Text.Length < 20 & tbTicketNo.Text.Length > 0)
            {
                SetDisplayAlarm("W", "티켓번호 오류.");
                thepos_app_log(3, this.Name, "scanner", "skip. no=" + tbTicketNo.Text);
                return;
            }


            String no = "";
            
            if (tbTicketNo.Text.Length >= 20)
            {
                no = tbTicketNo.Text.Substring(0, 20);
            }

            get_flow_ticket(no);
        }

        private void get_flow_ticket(String rTheNo)
        {
            lvwList.Items.Clear();

            if (cbTicketAll.Checked)
            {
                get_flow_ticket_all(rTheNo);
            }
            else
            {
                get_flow_ticket_4(rTheNo);
                get_flow_ticket_0123(rTheNo);
            }

        }


        private void get_flow_ticket_0123(String rTheNo)
        {
            String now_dt = get_today_date() + get_today_time();

            String save_the_no = "";
            int entry_cnt = 0;

            String save_expect_exit_dt = "20991231235959";
            String entry_dt = "";

            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&theNo=" + rTheNo + "&flowStep=0123";   // flowStep=01 ->  0 or 1
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


                        // 수량
                        int num = 1;
                        get_number(arr[i]["goodsCnt"].ToString(), ref num);
                        entry_cnt += num;

                        //
                        String goods_code = arr[i]["goodsCode"].ToString();
                        entry_dt = arr[i]["entryDt"].ToString();

                        // 퇴장 예상시간
                        string expect_exit_dt = get_expect_exit_dt(goods_code, entry_dt);

                        if (Int32.Parse(save_expect_exit_dt.Substring(6, 8)) > Int32.Parse(expect_exit_dt.Substring(6, 8)))
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

        private void get_flow_ticket_4(String rTheNo)
        {
            String now_dt = get_today_date() + get_today_time();

            String save_the_no = "";
            int entry_cnt = 0;

            String save_exit_dt = "20250101000000";
            String entry_dt = "";

            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&theNo=" + rTheNo + "&flowStep=4";   // flowStep=01 ->  0 or 1
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
                            item.SubItems.Add(save_exit_dt.Substring(8, 2) + ":" + save_exit_dt.Substring(10, 2));

                            item.SubItems.Add("시간초과");
                            item.ForeColor = Color.Black;

                            lvwList.Items.Add(item);

                            //
                            save_exit_dt = "20250101000000";
                            entry_cnt = 0;
                        }

                        //
                        save_the_no = arr[i]["theNo"].ToString();
                        entry_cnt++;

                        String goods_code = arr[i]["goodsCode"].ToString();
                        entry_dt = arr[i]["entryDt"].ToString();

                        // 퇴장 예상시간
                        string exit_dt = arr[i]["exitDt"].ToString();

                        if (Int32.Parse(save_exit_dt.Substring(6, 8)) < Int32.Parse(exit_dt.Substring(6, 8)))
                        {
                            save_exit_dt = exit_dt;
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
                        item2.SubItems.Add(save_exit_dt.Substring(8, 2) + ":" + save_exit_dt.Substring(10, 2));

                        item2.SubItems.Add("추가요금");
                        item2.ForeColor = Color.Black;

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

        private void get_flow_ticket_all(String rTheNo)
        {
            String now_dt = get_today_date() + get_today_time();

            String save_the_no = "";
            int entry_cnt = 0;

            String save_flow_step = "9";
            String save_exit_dt = "20991231235959";
            String save_expect_exit_dt = "20991231235959";
            String entry_dt = "";

            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&theNo=" + rTheNo;   // flowStep = all
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

                            if (save_flow_step == "9")
                            {
                                // 퇴장시간
                                if (save_exit_dt == "")
                                {
                                    item.SubItems.Add("");
                                }
                                else
                                {
                                    item.SubItems.Add(save_exit_dt.Substring(8, 2) + ":" + save_exit_dt.Substring(10, 2));
                                }
                                item.ForeColor = Color.Gray;  // 완료 그레이
                            }
                            else if (save_flow_step == "8")
                            {
                                // 퇴장시간
                                if (save_exit_dt == "")
                                {
                                    item.SubItems.Add("");
                                }
                                else
                                {
                                    if (save_exit_dt == "20991231235959")
                                    {
                                        item.SubItems.Add("");
                                    }
                                    else
                                    {
                                        item.SubItems.Add(save_exit_dt.Substring(8, 2) + ":" + save_exit_dt.Substring(10, 2));
                                    }
                                }
                                item.SubItems.Add("취소");
                                item.ForeColor = Color.Gray;  // 취소 그레이
                            }
                            else if (save_flow_step == "4")
                            {
                                // 퇴장시간
                                item.SubItems.Add(save_exit_dt.Substring(8, 2) + ":" + save_exit_dt.Substring(10, 2));

                            }
                            else  //  save_flow_step == 0123
                            {
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
                            }

                            lvwList.Items.Add(item);

                            //
                            save_exit_dt = "20991231235959";
                            save_expect_exit_dt = "20991231235959";
                            entry_cnt = 0;
                            save_flow_step = "9";
                        }

                        //
                        save_the_no = arr[i]["theNo"].ToString();
                        entry_cnt++;

                        String goods_code = arr[i]["goodsCode"].ToString();
                        entry_dt = arr[i]["entryDt"].ToString();


                        if (Int32.Parse(save_flow_step) >= Int32.Parse(arr[i]["flowStep"].ToString()))
                        {
                            save_flow_step = arr[i]["flowStep"].ToString();

                            if (save_flow_step == "4" | save_flow_step == "9")
                            {
                                save_exit_dt = arr[i]["exitDt"].ToString();
                            }
                            else
                            {
                                // 퇴장 예상시간
                                string expect_exit_dt = get_expect_exit_dt(goods_code, entry_dt);

                                if (Int32.Parse(save_expect_exit_dt.Substring(6, 8)) > Int32.Parse(expect_exit_dt.Substring(6, 8)))
                                {
                                    save_expect_exit_dt = expect_exit_dt;
                                    entry_dt = arr[i]["entryDt"].ToString();
                                }
                            }
                        }
                    }



                    //
                    if (save_the_no != "")
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = save_the_no;
                        item.SubItems.Add(entry_cnt + "");
                        item.SubItems.Add(entry_dt.Substring(8, 2) + ":" + entry_dt.Substring(10, 2));


                        if (save_flow_step == "9")
                        {
                            // 퇴장시간
                            if (save_exit_dt == "")
                            {
                                item.SubItems.Add("");
                            }
                            else
                            {
                                item.SubItems.Add(save_exit_dt.Substring(8, 2) + ":" + save_exit_dt.Substring(10, 2));
                            }
                            item.ForeColor = Color.Gray;  // 완료 그레이
                        }
                        else if (save_flow_step == "8")
                        {
                            // 퇴장시간
                            if (save_exit_dt == "")
                            {
                                item.SubItems.Add("");
                            }
                            else
                            {
                                if (save_exit_dt == "20991231235959")
                                {
                                    item.SubItems.Add("");
                                }
                                else
                                {
                                    item.SubItems.Add(save_exit_dt.Substring(8, 2) + ":" + save_exit_dt.Substring(10, 2));
                                }
                            }
                            item.SubItems.Add("취소");
                            item.ForeColor = Color.Gray;  // 취소 그레이
                        }
                        else if (save_flow_step == "4")
                        {
                            // 퇴장시간
                            item.SubItems.Add(save_exit_dt.Substring(8, 2) + ":" + save_exit_dt.Substring(10, 2));
                        }
                        else  //  save_flow_step == 0123
                        {
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
                        }

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


        private void btnTicketDetail_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                return;
            }

            String the_no = lvwList.SelectedItems[0].Text.Substring(0, 20);

            frmFlowTicketList frm = new frmFlowTicketList(the_no);
            frm.ShowDialog();
        }



        private void tbTicketNo_Leave(object sender, EventArgs e)
        {
            //tbTicketNo.Focus();
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
            try
            {
                int minutesToAdd = get_goods_available_minute(goods_code);
                DateTime dateTime = DateTime.ParseExact(entry_dt, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                dateTime = dateTime.AddMinutes(minutesToAdd);
                return dateTime.ToString("yyyyMMddHHmmss");
            }
            catch
            {
                return "";
            }
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


    }
}
