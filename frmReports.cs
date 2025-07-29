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
using static thepos.frmMain;
using thepos._1Sales;

namespace thepos
{
    public partial class frmReports : Form
    {
        String mThisButtonClick = "";


        public frmReports()
        {
            InitializeComponent();

            //
            thepos_app_log(1, this.Name, "open", "");
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "close", "");

            Close();

            mPanelDivision.Visible = false;
        }

        private void btnReportDayPos_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "DayPos") return;

            mThisButtonClick = "DayPos";
            panelReport.Controls.Clear();

            frmReportDayPos fBiz = new frmReportDayPos() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportDayShop_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "DayShop") return;

            mThisButtonClick = "DayShop";
            panelReport.Controls.Clear();

            frmReportDayShop fBiz = new frmReportDayShop() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportMonthShop_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "MonthShop") return;

            mThisButtonClick = "MonthShop";
            panelReport.Controls.Clear();

            frmReportMonthShop fBiz = new frmReportMonthShop() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }


        private void btnReportDayDetail_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "DayDetail") return;

            mThisButtonClick = "DayDetail";
            panelReport.Controls.Clear();

            frmReportDayDetail fBiz = new frmReportDayDetail() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }



        private void btnReportCalendar1_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Calemdar1") return;

            mThisButtonClick = "Calemdar1";
            panelReport.Controls.Clear();

            frmReportCalendar1 fBiz = new frmReportCalendar1() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportChart1_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Chart1") return;

            mThisButtonClick = "Chart1";
            panelReport.Controls.Clear();

            frmReportChart1 fBiz = new frmReportChart1() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }


        private void btnReportList1_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "List1") return;

            mThisButtonClick = "List1";
            panelReport.Controls.Clear();

            frmReportList1 fBiz = new frmReportList1() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportShopOreder_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "ShopOrder") return;

            mThisButtonClick = "ShopOrder";
            panelReport.Controls.Clear();

            frmReportShopOrder fBiz = new frmReportShopOrder() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }


        private void btnReportAllim_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Allim") return;

            mThisButtonClick = "Allim";
            panelReport.Controls.Clear();

            frmReportAllim fBiz = new frmReportAllim() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportDayCard_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "DayCard") return;

            mThisButtonClick = "DayCard";
            panelReport.Controls.Clear();

            frmReportDayCard fBiz = new frmReportDayCard() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportMonthCard_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "MonthCard") return;

            mThisButtonClick = "MonthCard";
            panelReport.Controls.Clear();

            frmReportMonthCard fBiz = new frmReportMonthCard() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportDayCoupon_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "DayCoupon") return;

            mThisButtonClick = "DayCoupon";
            panelReport.Controls.Clear();

            frmReportDayCoupon fBiz = new frmReportDayCoupon() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportMonthCoupon_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "MonthCoupon") return;

            mThisButtonClick = "MonthCoupon";
            panelReport.Controls.Clear();

            frmReportMonthCoupon fBiz = new frmReportMonthCoupon() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportDayPointNotSettle_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "DayPointNotSettle") return;

            mThisButtonClick = "DayPointNotSettle";
            panelReport.Controls.Clear();

            frmReportDayPointNotSettle fBiz = new frmReportDayPointNotSettle() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }
    }
}
