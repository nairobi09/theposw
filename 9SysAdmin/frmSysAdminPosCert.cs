using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace thepos._9SysAdmin
{
    public partial class frmSysAdminPosCert : Form
    {
        public frmSysAdminPosCert()
        {
            InitializeComponent();

            initial_the();

            reload_server();

        }

        private void initial_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 28);
            lvwList.SmallImageList = imgList;
        }


        private void reload_server()
        {
            lvwList.Items.Clear();

            String sUrl = "pos?siteId=" + mSiteId;
            //String sUrl = "pos?siteId=" + mSiteId + "&posStatus=0";

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["pos"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["posNo"].ToString();
                        lvItem.SubItems.Add(arr[i]["macAddr"].ToString());
                        lvItem.SubItems.Add(arr[i]["initDt"].ToString());

                        String stat = "";

                        if (arr[i]["posStatus"].ToString() == "0") stat = "접수";
                        else if (arr[i]["posStatus"].ToString() == "Y") stat = "정상등록";
                        else if (arr[i]["posStatus"].ToString() == "9") stat = "정지";

                        lvItem.SubItems.Add(stat);

                        lvItem.SubItems.Add(arr[i]["shopCode"].ToString());

                        lvItem.Tag = arr[i]["siteId"].ToString();

                        lvwList.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("포스정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }



        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            tbShopCode.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(shop_code)].Text;
            tbMAC.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(mac)].Text;

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) {  return; }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = lvwList.SelectedItems[0].Text;
            parameters["shopCode"] = tbShopCode.Text;
            parameters["macAddr"] = tbMAC.Text;
            parameters["posStatus"] = "Y";


            //? bizDt 추가요망
            if (mRequestPatch("pos", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 인증등록 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }


            reload_server();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            if (MessageBox.Show("삭제.", "thepos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
            else
            {
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = lvwList.SelectedItems[0].Text;

            //? bizDt 추가요망
            if (mRequestDelete("pos", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }


            reload_server();
        }

    }
}
