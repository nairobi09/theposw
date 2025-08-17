using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using thepos._1Sales;
using thepos._9SysAdmin;
using theposw._9SysAdmin;
using static thepos.thePos;

namespace thepos
{
    public partial class frmSysAdmin : Form
    {
        String mThisButtonClick = "";
        String Mode = "";

        public frmSysAdmin(String in_patern, String mode)
        {
            InitializeComponent();


            if (mSiteId != "") // 로그인되었다면 panel보이기
            {
                panelAdminConsole.Visible = true;


                if (in_patern == "1122")
                {
                    panelCertConsole.Visible = true;
                }
            }
            else
            {
                if (mode == "Test")
                {
                    Mode = "Test";
                }
            }

            thepos_app_log(1, this.Name, "open", "");
        }


        private void btnPos_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Pos") return;

            mThisButtonClick = "Pos";
            panelView.Controls.Clear();

            frmSysAdminPos fSysAdmin = new frmSysAdminPos(Mode) { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnPosMac_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Mac") return;

            mThisButtonClick = "Mac";
            panelView.Controls.Clear();

            frmSysAdminPosCert fSysAdmin = new frmSysAdminPosCert() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "User") return;

            mThisButtonClick = "User";
            panelView.Controls.Clear();

            frmSysAdminUserCert fSysAdmin = new frmSysAdminUserCert() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysShop_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Shop") return;

            mThisButtonClick = "Shop";
            panelView.Controls.Clear();

            frmSysShop fSysAdmin = new frmSysShop() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysGoods_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Goods") return;

            mThisButtonClick = "Goods";
            panelView.Controls.Clear();

            frmSysGoods fSysAdmin = new frmSysGoods() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysOption_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Option") return;

            mThisButtonClick = "Option";
            panelView.Controls.Clear();

            frmSysOptionTemplate fSysAdmin = new frmSysOptionTemplate() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysGoodsTicket_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "GoodsTicket") return;

            mThisButtonClick = "GoodsTicket";
            panelView.Controls.Clear();

            frmSysGoodsTicket fSysAdmin = new frmSysGoodsTicket() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }




        //
        private void btnSysGoodsGroupPos_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "GoodsGroupPos") return;

            mThisButtonClick = "GoodsGroupPos";
            panelView.Controls.Clear();

            frmSysGoodsGroupPos fSysAdmin = new frmSysGoodsGroupPos() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysGoodsGroupKiosk_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "GoodsGroupKiosk") return;

            mThisButtonClick = "GoodsGroupKiosk";
            panelView.Controls.Clear();

            frmSysGoodsGroupKiosk fSysAdmin = new frmSysGoodsGroupKiosk() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysGoodsItemPos_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "GoodsItemPos") return;

            mThisButtonClick = "GoodsItemPos";
            panelView.Controls.Clear();

            frmSysGoodsItemPos fSysAdmin = new frmSysGoodsItemPos() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysGoodsItemKiosk_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "GoodsItemKiosk") return;

            mThisButtonClick = "GoodsItemKiosk";
            panelView.Controls.Clear();

            frmSysGoodsItemKiosk fSysAdmin = new frmSysGoodsItemKiosk() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }




        private void btnSysPayConsole_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "PayConsole") return;

            mThisButtonClick = "PayConsole";
            panelView.Controls.Clear();

            frmSysPayConsole fSysAdmin = new frmSysPayConsole() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }
        private void btnSysFlowConsole_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "FlowConsole") return;

            mThisButtonClick = "FlowConsole";
            panelView.Controls.Clear();

            frmSysFlowConsole fSysAdmin = new frmSysFlowConsole() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }


        private void btnSysSite_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Site") return;

            mThisButtonClick = "Site";
            panelView.Controls.Clear();

            frmSysSite fSysAdmin = new frmSysSite() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnDcrFavorite_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "DcrFavorite") return;

            mThisButtonClick = "DcrFavorite";
            panelView.Controls.Clear();

            frmSysDcrFavorite fSysAdmin = new frmSysDcrFavorite() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSoldout_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Soldout") return;

            mThisButtonClick = "Soldout";
            panelView.Controls.Clear();

            frmSysSoldout fSysAdmin = new frmSysSoldout() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Log") return;

            mThisButtonClick = "Log";
            panelView.Controls.Clear();

            frmSysAdminLog fSysAdmin = new frmSysAdminLog() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Tree") return;

            mThisButtonClick = "Tree";
            panelView.Controls.Clear();

            frmSysAdminTree fSysAdmin = new frmSysAdminTree() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void frmSysAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            thepos_app_log(1, this.Name, "close", "");
        }


    }
}
