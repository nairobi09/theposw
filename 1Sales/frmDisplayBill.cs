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
using static thepos.frmSales;

namespace thepos._1Sales
{
    public partial class frmDisplayBill : Form
    {
        String theNo;
        String tranType;
        String payKeep;

        public frmDisplayBill(String the_no, String tran_type, String pay_keep)
        {
            InitializeComponent();

            //
            thepos_app_log(1, this.Name, "Open", "");


            theNo = the_no;
            tranType = tran_type;
            payKeep = pay_keep;


            String str_bill = make_bill_header() + make_bill_body(theNo, tranType, "", payKeep) + make_bill_trailer();


            lblLayoutBill.Text = "\r\n" + str_bill;

        }


        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            _print_bill(theNo, tranType, "", payKeep, false);
            Close();
        }

        private void btnPrintBillex_Click(object sender, EventArgs e)
        {
            _print_bill(theNo, tranType, "Y", payKeep, false);
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
    }

}
