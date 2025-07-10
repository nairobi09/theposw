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
    public partial class frmReportMonthCoupon : Form
    {
        String yyyymm = "";


        List<String> coupon_link_no = new List<string>();
        int[] coupon_cnt;
        int[] coupon_amount;
        int coupon_amount_sum = 0;



        public frmReportMonthCoupon()
        {
            InitializeComponent();
            initialize_the();

            thepos_app_log(1, this.Name, "open", "");

            //
            for (int i = 0; i < mGoodsList.Count; i++)
            {
                if (mGoodsList[i].coupon_link_no != "")
                {
                    coupon_link_no.Add(mGoodsList[i].coupon_link_no);
                }
            }


            //
            coupon_cnt = new int[coupon_link_no.Count];
            coupon_amount = new int[coupon_link_no.Count];


            //
            for (int i = 0; i < coupon_link_no.Count; i++)
            {
                for (int k = 0; k < mGoodsList.Count; k++)
                {
                    if (mGoodsList[k].coupon_link_no == coupon_link_no[i])
                    {
                        lvwList.Columns.Add(mGoodsList[k].goods_name, 80, HorizontalAlignment.Right);
                    }
                }
            }
            


        }


        private void initialize_the()
        {
            String yyyymm = get_today_date().Substring(0, 6);
            lblYYYYMM.Text = yyyymm.Substring(0, 4) + "-" + yyyymm.Substring(4, 2);
        }



        private void btnView_Click(object sender, EventArgs e)
        {
            yyyymm = lblYYYYMM.Text.Replace("-", ""); ;

            lvwList.Items.Clear();

            load_data();
        }



        private void load_data()
        {

            
            
            
            //



        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            DateTime CurrMonth = Convert.ToDateTime(lblYYYYMM.Text + "-01");

            DateTime PrevMonth = CurrMonth.AddMonths(-1);

            lblYYYYMM.Text = PrevMonth.ToString("yyyy-MM");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DateTime CurrMonth = Convert.ToDateTime(lblYYYYMM.Text + "-01");

            DateTime NextMonth = CurrMonth.AddMonths(1);

            lblYYYYMM.Text = NextMonth.ToString("yyyy-MM");

        }
    }
}
