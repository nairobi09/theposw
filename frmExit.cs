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
        }



        private void btnLogout_Click(object sender, EventArgs e)
        {
            mIsLogin = "N";
            this.DialogResult = DialogResult.Yes;   // 로그아웃

            //
            thepos_app_log(2, this.Name, "Logout", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);

            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            mIsLogin = "N";
            this.DialogResult = DialogResult.OK;    // 종료

            //
            thepos_app_log(2, this.Name, "Close", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;    // 취소

            thepos_app_log(1, this.Name, "close", "");

            Close();
        }

    }
}

