using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static thepos.frmSales;
using static thepos.thePos;

namespace thepos._1Sales
{
    public partial class frmFlowLocker : Form
    {
        public frmFlowLocker()
        {
            InitializeComponent();
            initialize_the();

            //
            thepos_app_log(1, this.Name, "Open", "");

        }

        private void initialize_the()
        {


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFlowLocker_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            load_locker_list();
        }


        private void load_locker_list()
        { 
            lvwList.Items.Clear();

            String sUrl = "locker?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["lockers"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        String locker_no = arr[i]["lockerNo"].ToString();
                        String ticket_no = arr[i]["ticketNo"].ToString();
                        String flow_step = arr[i]["flowStep"].ToString();
                        String flow_dt = arr[i]["flowDt"].ToString();

                        ListViewItem item = new ListViewItem(locker_no);
                        item.SubItems.Add(get_flow_step_name(flow_step));

                        if (flow_step == "")
                        {
                            item.SubItems.Add("");
                        }
                        else
                        {
                            item.SubItems.Add(flow_dt.Substring(8, 2) + ":" + flow_dt.Substring(10, 2));
                        }
                            
                        item.SubItems.Add(ticket_no);

                        lvwList.Items.Add(item);
                    }
                }
            }
        }

        private void btnLorkerClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("고장등록외 전체 락커에 대해서 초기화합니다.", "thepos", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

            }
            else
            {
                return;
            }

            //
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                if (lvwList.Items[i].SubItems[1].Text != "")
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters["siteId"] = mSiteId;
                    parameters["lockerNo"] = lvwList.Items[i].Text;
                    parameters["ticketNo"] = "";
                    parameters["flowStep"] = "";
                    parameters["flowDt"] = "";

                    if (mRequestPatch("locker", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {

                        }
                        else
                        {
                            MessageBox.Show("오류. locker\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. locker\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }
            }

            //
            load_locker_list();
        }

    }
}
