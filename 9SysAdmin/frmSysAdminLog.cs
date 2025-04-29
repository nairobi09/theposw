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
    public partial class frmSysAdminLog : Form
    {
        public frmSysAdminLog()
        {
            InitializeComponent();

            initial_the();
        }

        
        private void initial_the()
        {


        }


        private void btnView_Click(object sender, EventArgs e)
        {

            reload_server();


        }


        private void reload_server()
        {
            lvwList.Items.Clear();

            String t_date = dtpBizDate.Value.ToString("yyyyMMdd");

            String sUrl = "theposAppLog?logDate=" + t_date + "&siteId=" + tbSiteId.Text + "&posNo=" + tbPosNo.Text + "&logTime=" + tbFromTime.Text;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String rdata = mObj["appLogs"].ToString();
                    JArray arr = JArray.Parse(rdata);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["logDate"].ToString();
                        lvItem.SubItems.Add(arr[i]["logTime"].ToString());
                        lvItem.SubItems.Add(arr[i]["siteId"].ToString());
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["formName"].ToString());
                        lvItem.SubItems.Add(arr[i]["formAction"].ToString());
                        lvItem.SubItems.Add(arr[i]["formMemo"].ToString());

                        if (arr[i]["logLevel"].ToString() == "2")
                        {
                            lvItem.ForeColor = Color.Blue;
                        }
                        else if (arr[i]["logLevel"].ToString() == "3")
                        {
                            lvItem.ForeColor = Color.Red;
                        }

                        lvwList.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("로그정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

    }
}