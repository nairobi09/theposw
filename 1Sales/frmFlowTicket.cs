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

namespace thepos
{
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

            
            String save_the_no = "";
            int entry_cnt = 0;
            String save_entry_dt = get_today_date() + get_today_time();

            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + this_biz_date + "&theNo=" + rTheNo + "&flowStep=01";   // flowStep=01 ->  0 or 1
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
                            item.SubItems.Add(save_entry_dt.Substring(8, 2) + ":" + save_entry_dt.Substring(10, 2));

                            // 퇴장시간 계산
                            item.SubItems.Add("");

                            // 남은시간 경과시간
                            item.SubItems.Add("30분 남음");

                            lvwList.Items.Add(item);

                            //
                            save_entry_dt = get_today_date() + get_today_time();
                            entry_cnt = 0;
                        }
                        
                        //
                        save_the_no = arr[i]["theNo"].ToString();
                        entry_cnt++;

                        if (Int32.Parse(save_entry_dt.Substring(6,8)) > Int32.Parse(arr[i]["entryDt"].ToString().Substring(6, 8)))
                        {
                            save_entry_dt = arr[i]["entryDt"].ToString();
                        }
                    }

                    //
                    ListViewItem item2 = new ListViewItem();
                    item2.Text = save_the_no;
                    item2.SubItems.Add(entry_cnt + "");
                    item2.SubItems.Add(save_entry_dt.Substring(8, 2) + ":" + save_entry_dt.Substring(10, 2));

                    // 퇴장시간 계산
                    item2.SubItems.Add("");

                    // 남은시간 경과시간
                    item2.SubItems.Add("30분 남음");

                    lvwList.Items.Add(item2);

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


            frmFlowTicketFlowDetail frm = new frmFlowTicketFlowDetail(this_biz_date, the_no);
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
    }
}
