using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.ClsWin32Api;
using static thepos.thePos;

namespace thepos
{
    public partial class frmObserverLogin : Form
    {
        public frmObserverLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnLoginDev_Click(object sender, EventArgs e)
        {
            if (tbSiteId.Text == "2501" | tbSiteId.Text == "2502" | tbSiteId.Text == "2503" | tbSiteId.Text == "2504")
            {

            }
            else
            {
                MessageBox.Show("사이트ID 오류", "thepos");
                return;
            }




            if (tbPinNo.Text != "20251231")
            {
                MessageBox.Show("PIN NO 오류", "thepos");
                return;
            }




            //mBaseUri = uri_test;
            mBaseUri = uri_real;


            // 로그인
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = tbSiteId.Text;
            parameters["posNo"] = tbPosNo.Text;

            if (mRequestPost("loginDev", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    mSiteId = tbSiteId.Text;
                    mUserID = "observer";
                    mUserName = "observer";
                    myPosNo = mObj["posNo"].ToString();
                    myShopCode = mObj["shopCode"].ToString();


                    //
                    thepos_app_log(2, this.Name, "옵저버로그인", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);

                    DialogResult = DialogResult.OK;  // REAL

                    Close();
                }
                else
                {
                    thepos_app_log(3, this.Name, "login", "로그인오류. " + mObj["resultMsg"].ToString());
                    MessageBox.Show("로그인오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                thepos_app_log(3, this.Name, "login", "시스템오류. " + mErrorMsg);
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
            }


        }



    }
}
