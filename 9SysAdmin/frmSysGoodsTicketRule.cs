using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static thepos.thePos;

namespace theposw._9SysAdmin
{
    public partial class frmSysGoodsTicketRule : Form
    {

        String tSelectedRuleCode = "";



        public frmSysGoodsTicketRule()
        {
            InitializeComponent();


        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //
            tSelectedRuleCode = "";

            //
            get_goodsTicketRule();

            tSelectedRuleCode = "";

        }



        private void get_goodsTicketRule()
        {
            lvwRule.Items.Clear();

            //
            String sUrl = "ticketRule?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["rules"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(arr[i]["ticketRuleCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["ticketRuleName"].ToString());
                        lvItem.SubItems.Add(arr[i]["availableMinute"].ToString());
                        lvItem.SubItems.Add(arr[i]["isCharge"].ToString());
                        lvItem.SubItems.Add(arr[i]["otFreeMinute"].ToString());
                        lvItem.SubItems.Add(arr[i]["otStdMinute"].ToString());
                        lvItem.SubItems.Add(arr[i]["otAmt"].ToString());
                        lvItem.SubItems.Add(arr[i]["linkGoodsCode"].ToString());
                        lvwRule.Items.Add(lvItem);
                    }
                }
            }

            clear_console();

        }

        private void clear_console()
        {
            tbCode.Text = "";
            tbName.Text = "";
            tbAvailableMinute.Text = "";
            cbIsCharge.Checked = false;
            tbOtFreeMinute.Text = "";
            tbOtStdMinute.Text = "";
            tbOtAmt.Text = "";
            tbLinkGoodsCode.Text = "";
            //
            tSelectedRuleCode = "";

        }

        private void lvwRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            if (lvwRule.SelectedItems.Count == 0)
            {
                return;
            }

            //
            tbCode.Text = lvwRule.SelectedItems[0].SubItems[lvwRule.Columns.IndexOf(code)].Text;
            tbName.Text = lvwRule.SelectedItems[0].SubItems[lvwRule.Columns.IndexOf(name)].Text;


            tbAvailableMinute.Text = lvwRule.SelectedItems[0].SubItems[lvwRule.Columns.IndexOf(available_minute)].Text;

            if (lvwRule.SelectedItems[0].SubItems[lvwRule.Columns.IndexOf(is_charge)].Text == "Y")
            {
                cbIsCharge.Checked = true;
            }
            else
            {
                cbIsCharge.Checked = false;
            }

            tbOtFreeMinute.Text = lvwRule.SelectedItems[0].SubItems[lvwRule.Columns.IndexOf(ot_free_minute)].Text;
            tbOtStdMinute.Text = lvwRule.SelectedItems[0].SubItems[lvwRule.Columns.IndexOf(ot_std_minute)].Text;
            tbOtAmt.Text = lvwRule.SelectedItems[0].SubItems[lvwRule.Columns.IndexOf(ot_amt)].Text;
            tbLinkGoodsCode.Text = lvwRule.SelectedItems[0].SubItems[lvwRule.Columns.IndexOf(link_goods_code)].Text;

            //
            tSelectedRuleCode = lvwRule.SelectedItems[0].Text;


        }



        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!is_number(tbAvailableMinute.Text))
            {
                MessageBox.Show("이용시간(분) 오류.", "thepos");
                return;
            }

            if (!is_number(tbOtFreeMinute.Text))
            {
                MessageBox.Show("초과무료이용시간(분) 오류.", "thepos");
                return;
            }

            if (!is_number(tbOtStdMinute.Text))
            {
                MessageBox.Show("초과이용기준시간(분) 오류.", "thepos");
                return;
            }

            if (Int16.Parse(tbOtStdMinute.Text) == 0)
            {
                MessageBox.Show("초과이용기준시간(분) 오류. 0이상 유효", "thepos");
                return;
            }


            if (!is_number(tbOtAmt.Text))
            {
                MessageBox.Show("초과이용기준당요금 오류.", "thepos");
                return;
            }

            if (tbLinkGoodsCode.Text.Length != 6)
            {
                MessageBox.Show("연결상품코드 오류.", "thepos");
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["ticketRuleCode"] = tbCode.Text.Trim();
            parameters["ticketRuleName"] = tbName.Text.Trim();
            parameters["availableMinute"] = tbAvailableMinute.Text.Trim();

            if (cbIsCharge.Checked)
                parameters["isCharge"] = "Y";
            else
                parameters["isCharge"] = "";

            parameters["otFreeMinute"] = tbOtFreeMinute.Text;
            parameters["otStdMinute"] = tbOtStdMinute.Text;
            parameters["otAmt"] = tbOtAmt.Text;
            parameters["linkGoodsCode"] = tbLinkGoodsCode.Text;

            if (mRequestPost("ticketRule", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 등록 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류. goodsTicket\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. goodsTicket\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            get_goodsTicketRule();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tSelectedRuleCode == "")
            {
                return;
            }


            if (!is_number(tbAvailableMinute.Text))
            {
                MessageBox.Show("이용시간(분) 오류.", "thepos");
                return;
            }

            if (!is_number(tbOtFreeMinute.Text))
            {
                MessageBox.Show("초과무료이용시간(분) 오류.", "thepos");
                return;
            }

            if (!is_number(tbOtStdMinute.Text))
            {
                MessageBox.Show("초과이용기준시간(분) 오류.", "thepos");
                return;
            }
            
            if (Int16.Parse(tbOtStdMinute.Text) == 0)
            {
                MessageBox.Show("초과이용기준시간(분) 오류. 0이상 유효", "thepos");
                return;
            }



            if (!is_number(tbOtAmt.Text))
            {
                MessageBox.Show("초과이용기준당요금 오류.", "thepos");
                return;
            }

            if (tbLinkGoodsCode.Text.Length != 6)
            {
                MessageBox.Show("연결상품코드 오류.", "thepos");
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["ticketRuleCode"] = tSelectedRuleCode;
            parameters["ticketRuleName"] = tbName.Text.Trim();
            parameters["availableMinute"] = tbAvailableMinute.Text.Trim();

            if (cbIsCharge.Checked)
                parameters["isCharge"] = "Y";
            else
                parameters["isCharge"] = "";

            parameters["otFreeMinute"] = tbOtFreeMinute.Text;
            parameters["otStdMinute"] = tbOtStdMinute.Text;
            parameters["otAmt"] = tbOtAmt.Text;
            parameters["linkGoodsCode"] = tbLinkGoodsCode.Text;

            if (mRequestPatch("ticketRule", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 등록 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류. goodsTicket\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. goodsTicket\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            get_goodsTicketRule();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tSelectedRuleCode == "")
            {
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["ticketRuleCode"] = tSelectedRuleCode;

            if (mRequestDelete("goodsTicket", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 삭제 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류. goodsTicket\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. goodsTicket\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            get_goodsTicketRule();
        }
    }
}
