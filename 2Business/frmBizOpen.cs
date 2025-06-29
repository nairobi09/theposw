using DocumentFormat.OpenXml.Vml.Office;
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
using static thepos.frmBusiness;
using static thepos.thePos;

namespace thepos
{
    public partial class frmBizOpen : Form
    {


        int cash_starting = 0;

        bool isNew = true;


        public frmBizOpen()
        {
            InitializeComponent();

            initialize_the();

            load_cash_starting();

            tbBizStartingCash.Text = cash_starting + "";


            //
            thepos_app_log(1, this.Name, "open", "");
        }


        private void initialize_the()
        {
            mTbKeyController = tbBizStartingCash;

            lblBizDate.Text = mBizDate.Substring(0,4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
            lblPosNo.Text = myPosNo;
            lblBizOpenUser.Text = mUserID.ToString() + " - " + mUserName.ToString();


        }


        private void load_cash_starting()
        {
            String sUrl = "reportDailyCash?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dailyCash"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        for (int i = 0; i < arr.Count; i++)
                        {
                            cash_starting = convert_number(arr[i]["startingCash"].ToString());

                            isNew = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }


        private void btnBizOpenInput_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = mBizDate;
            parameters["posNo"] = myPosNo;
            parameters["startingCash"] = tbBizStartingCash.Text;


            bool ret;

            if (isNew)
            {
                ret = mRequestPost("reportDailyCash", parameters);
            }
            else
            {
                ret = mRequestPatch("reportDailyCash", parameters);
            }

            if (ret)
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("준비금 입력 완료.", "thepos");
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

        }

    }
}
