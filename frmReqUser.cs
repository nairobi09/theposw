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
using static thepos.thePos;

namespace thepos
{
    public partial class frmReqUser : Form
    {

        String Mode = "";

        public frmReqUser(String mode)
        {
            InitializeComponent();

            Mode = mode;

            if (Mode == "Test")
            {
                lblTitle.Text = "사용자계정신청 - Test";
            }

            //
            thepos_app_log(1, this.Name, "open", "");
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "close", ""); 

            Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (tbSiteId.Text.Length < 4)
            {
                MessageBox.Show("고객코드 입력오류.(4자리)", "thepos");
                return;
            }

            if (tbID.Text.Length < 4)
            {
                MessageBox.Show("ID 입력오류.(4자리)", "thepos");
                return;
            }

            if (tbID.Text == "0000" | tbID.Text == "1111" | tbID.Text == "1234" | tbID.Text == "1122")
            {
                MessageBox.Show("단순번호 사용불가", "thepos");
                return;
            }




            if (tbPW1.Text.Length < 4)
            {
                MessageBox.Show("비밀번호 입력오류.(4자리)", "thepos");
                return;
            }


            if (tbPW1.Text != tbPW2.Text)
            {
                MessageBox.Show("비밀번호 비교오류", "thepos");
                return;
            }

            if (tbName.Text.Length <1)
            {
                MessageBox.Show("담당자명 입력오휴", "thepos");
                return;
            }



            if (Mode == "Test")
            {
                mBaseUri = uri_test;
            }
            else
            {
                mBaseUri = uri_real;
            }


            // 사용자 등록 신청
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["userId"] = tbID.Text;
            parameters["userPw"] = SHA1HashCrypt(tbPW1.Text);//? SHA1 변경
            parameters["siteId"] = tbSiteId.Text;
            parameters["userName"] = tbName.Text;
            parameters["userAuth"] = "U";
            parameters["userStatus"] = "0";
            parameters["initDt"] = get_today_date() + get_today_time();
            parameters["registDt"] = "";
            parameters["lastDt"] = "";
            parameters["conCnt"] = "0";



            if (mRequestPost("user", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("등록신청완료\n\n" + "관리자의 인증후 사용가능합니다.", "thepos");
                    return;
                }
                else
                {
                    MessageBox.Show("등록신청오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
