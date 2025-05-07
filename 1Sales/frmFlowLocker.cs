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
    public partial class frmFlowLocker : Form
    {
        public frmFlowLocker()
        {
            InitializeComponent();
            initialize_the();

            //
            thepos_app_log(1, this.Name, "Open", "");

        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwList.SmallImageList = imgList;

            dtBusiness.Value = new DateTime(convert_number(mBizDate.Substring(0, 4)), convert_number(mBizDate.Substring(4, 2)), convert_number(mBizDate.Substring(6, 2)));






        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFlowLocker_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }
    }
}
