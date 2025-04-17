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


namespace thepos
{
    public partial class frmScanner : Form
    {

        int scanLength;

        public frmScanner(int scan_length)
        {
            InitializeComponent();

            mIsScanOK = false;
            mScanString = "";
            
            //scanLength = scan_length;

            //tbScanning.MaxLength = scan_length;

        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            mScanString = "";
            mIsScanOK = false;
            Close();
        }

        private void tbScanning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mIsScanOK = true;
                mScanString = tbScanning.Text;
                Close();
            }
        }
    }
}
