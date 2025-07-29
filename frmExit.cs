using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static thepos.thePos;

namespace thepos
{
    public partial class frmExit : Form
    {
        public frmExit()
        {
            InitializeComponent();

            thepos_app_log(1, this.Name, "open", "");

            lblAppVersion.Text = thePos.mAppVersion;

        }



        private void btnLogout_Click(object sender, EventArgs e)
        {
            mIsLogin = "N";
            this.DialogResult = DialogResult.Yes;   // 로그아웃

            //
            thepos_app_log(2, this.Name, "로그아웃", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);

            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            mIsLogin = "N";
            this.DialogResult = DialogResult.OK;    // 종료

            //
            thepos_app_log(2, this.Name, "종료", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;    // 닫기

            thepos_app_log(1, this.Name, "닫기", "");

            Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;

            thepos_app_log(2, this.Name, "원장로드", "");

            Close();
        }
    }
}

