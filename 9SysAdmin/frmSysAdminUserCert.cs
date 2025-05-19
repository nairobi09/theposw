using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace thepos._9SysAdmin
{
    public partial class frmSysAdminUserCert : Form
    {
        public frmSysAdminUserCert()
        {
            InitializeComponent();

            initial_the();
        }

        
        private void initial_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwList.SmallImageList = imgList;


            reload_server();


        }


        private void reload_server()
        {
            lvwList.Items.Clear();


            String sUrl = "user?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["users"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        if (arr[i]["userStatus"].ToString() == "Y")
                        {
                            lvItem.Text = "정상";
                        }
                        else
                        {
                            lvItem.Text = "대기";
                        }

                        lvItem.SubItems.Add(arr[i]["userId"].ToString());
                        lvItem.SubItems.Add(arr[i]["userAuth"].ToString());
                        lvItem.SubItems.Add(arr[i]["userName"].ToString());
                        lvItem.SubItems.Add(arr[i]["registDt"].ToString());
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


        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            // user 추가
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            
            parameters["userId"] = lvwList.SelectedItems[0].SubItems[1].Text.ToString();
            parameters["siteId"] = mSiteId;
            parameters["userStatus"] = "Y";
            parameters["userAuth"] = tbAuth.Text;
            parameters["registDt"] = get_today_date() + get_today_time();
            parameters["conCnt"] = "0";


            if (mRequestPatch("user", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 인증등록 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류. user\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류1\n\n" + mErrorMsg, "thepos");
                return;
            }


            reload_server();

        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            tbAuth.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(auth)].Text;
        }
    }
}