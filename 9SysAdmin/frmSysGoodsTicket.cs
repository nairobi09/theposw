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
    public partial class frmSysGoodsTicket : Form
    {

        String tSelectedGoodsCode = "";



        public frmSysGoodsTicket()
        {
            InitializeComponent();


        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //
            tSelectedGoodsCode = "";

            //
            get_goods();
            get_goodsTicket();

            tSelectedGoodsCode = "";
            lblSelectedGoodsName.Text = "";
        }

        private void get_goods()
        {

            lvwGoods.Items.Clear();

            //
            String sUrl = "goods?siteId=" + mSiteId + "&ticketYn=Y";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (arr[i]["ticketYn"].ToString() == "Y")
                        {
                            ListViewItem lvItem;
                            lvItem = new ListViewItem(arr[i]["goodsCode"].ToString());
                            lvItem.SubItems.Add(arr[i]["goodsName"].ToString());
                            lvwGoods.Items.Add(lvItem);
                        }
                    }
                }
            }
        }

        private void get_goodsTicket()
        {
            lvwGoodsTicket.Items.Clear();

            //
            String sUrl = "goodsTicket?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(arr[i]["goodsCode"].ToString());
                        lvItem.SubItems.Add(get_goods_name(arr[i]["goodsCode"].ToString()));
                        lvItem.SubItems.Add(arr[i]["availableMinute"].ToString());
                        lvItem.SubItems.Add(arr[i]["isCharge"].ToString());
                        lvItem.SubItems.Add(arr[i]["otFreeMinute"].ToString());
                        lvItem.SubItems.Add(arr[i]["otStdMinute"].ToString());
                        lvItem.SubItems.Add(arr[i]["otAmt"].ToString());
                        lvItem.SubItems.Add(arr[i]["linkGoodsCode"].ToString());
                        lvwGoodsTicket.Items.Add(lvItem);
                    }
                }
            }

            clear_console();

        }

        private void clear_console()
        {
            tbAvailableMinute.Text = "";
            cbIsCharge.Checked = false;
            tbOtFreeMinute.Text = "";
            tbOtStdMinute.Text = "";
            tbOtAmt.Text = "";
            tbLinkGoodsCode.Text = "";
            //
            tSelectedGoodsCode = "";
            lblSelectedGoodsName.Text = "";
        }


        private void btnGoodsLink_Click(object sender, EventArgs e)
        {
            if (lvwGoods.SelectedItems.Count == 0)
            {
                return;
            }

            tSelectedGoodsCode = lvwGoods.SelectedItems[0].Text;
            lblSelectedGoodsName.Text = lvwGoods.SelectedItems[0].SubItems[1].Text;
        }

        private void lvwGoodsTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            if (lvwGoodsTicket.SelectedItems.Count == 0)
            {
                return;
            }

            //
            tbAvailableMinute.Text = lvwGoodsTicket.SelectedItems[0].SubItems[lvwGoodsTicket.Columns.IndexOf(available_minute)].Text;

            if (lvwGoodsTicket.SelectedItems[0].SubItems[lvwGoodsTicket.Columns.IndexOf(is_charge)].Text == "Y")
            {
                cbIsCharge.Checked = true;
            }
            else
            {
                cbIsCharge.Checked = false;
            }

            tbOtFreeMinute.Text = lvwGoodsTicket.SelectedItems[0].SubItems[lvwGoodsTicket.Columns.IndexOf(ot_free_minute)].Text;
            tbOtStdMinute.Text = lvwGoodsTicket.SelectedItems[0].SubItems[lvwGoodsTicket.Columns.IndexOf(ot_std_minute)].Text;
            tbOtAmt.Text = lvwGoodsTicket.SelectedItems[0].SubItems[lvwGoodsTicket.Columns.IndexOf(ot_amt)].Text;
            tbLinkGoodsCode.Text = lvwGoodsTicket.SelectedItems[0].SubItems[lvwGoodsTicket.Columns.IndexOf(link_goods_code)].Text;

            //
            tSelectedGoodsCode = lvwGoodsTicket.SelectedItems[0].Text;
            lblSelectedGoodsName.Text = lvwGoodsTicket.SelectedItems[0].SubItems[1].Text;

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tSelectedGoodsCode == "")
            {
                MessageBox.Show("추가선택 오류.", "thepos");
                return;
            }

            if (!is_number(tbAvailableMinute.Text))
            {
                MessageBox.Show("이용시간(분) 오류.", "thepos");
                return;
            }

            if (tbOtFreeMinute.Text != "" & !is_number(tbOtFreeMinute.Text))
            {
                MessageBox.Show("초과무료이용시간(분) 오류.", "thepos");
                return;
            }

            if (tbOtStdMinute.Text != "" & !is_number(tbOtStdMinute.Text))
            {
                MessageBox.Show("초과이용기준시간(분) 오류.", "thepos");
                return;
            }

            if (tbOtAmt.Text != "" & !is_number(tbOtAmt.Text))
            {
                MessageBox.Show("초과이용기준당요금 오류.", "thepos");
                return;
            }

            if (tbLinkGoodsCode.Text != "" & !is_number(tbLinkGoodsCode.Text))
            {
                MessageBox.Show("연결상품코드 오류.", "thepos");
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = tSelectedGoodsCode;
            parameters["availableMinute"] = tbAvailableMinute.Text.Trim();

            if (cbIsCharge.Checked)
                parameters["isCharge"] = "Y";
            else
                parameters["isCharge"] = "";

            parameters["otFreeMinute"] = tbOtFreeMinute.Text;
            parameters["otStdMinute"] = tbOtStdMinute.Text;
            parameters["otAmt"] = tbOtAmt.Text;
            parameters["linkGoodsCode"] = tbLinkGoodsCode.Text;

            if (mRequestPost("goodsTicket", parameters))
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
            get_goodsTicket();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tSelectedGoodsCode == "")
            {
                MessageBox.Show("추가선택 오류.", "thepos");
                return;
            }

            if (!is_number(tbAvailableMinute.Text))
            {
                MessageBox.Show("이용시간(분) 오류.", "thepos");
                return;
            }

            if (tbOtFreeMinute.Text != "" & !is_number(tbOtFreeMinute.Text))
            {
                MessageBox.Show("초과무료이용시간(분) 오류.", "thepos");
                return;
            }

            if (tbOtStdMinute.Text != "" & !is_number(tbOtStdMinute.Text))
            {
                MessageBox.Show("초과이용기준시간(분) 오류.", "thepos");
                return;
            }

            if (tbOtAmt.Text != "" & !is_number(tbOtAmt.Text))
            {
                MessageBox.Show("초과이용기준당요금 오류.", "thepos");
                return;
            }

            if (tbLinkGoodsCode.Text != "" & !is_number(tbLinkGoodsCode.Text))
            {
                MessageBox.Show("연결상품코드 오류.", "thepos");
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = tSelectedGoodsCode;
            parameters["availableMinute"] = tbAvailableMinute.Text.Trim();

            if (cbIsCharge.Checked)
                parameters["isCharge"] = "Y";
            else
                parameters["isCharge"] = "";

            parameters["otFreeMinute"] = tbOtFreeMinute.Text;
            parameters["otStdMinute"] = tbOtStdMinute.Text;
            parameters["otAmt"] = tbOtAmt.Text;
            parameters["linkGoodsCode"] = tbLinkGoodsCode.Text;

            if (mRequestPatch("goodsTicket", parameters))
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
            get_goodsTicket();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tSelectedGoodsCode == "")
            {
                MessageBox.Show("추가선택 오류.", "thepos");
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = tSelectedGoodsCode;

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
            get_goodsTicket();
        }
    }
}
