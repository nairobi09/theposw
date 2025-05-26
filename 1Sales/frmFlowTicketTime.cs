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

namespace theposw._1Sales
{
    public partial class frmFlowTicketTime : Form
    {
        public string return_datetime { get; private set; }



        public frmFlowTicketTime()
        {
            InitializeComponent();
        }



        private void btnOK_Click(object sender, EventArgs e)
        {

            if (cbManualTime.Checked)
            {
                return_datetime = get_today_date() + cbHH.Text + cbMM.Text + "00";
            }
            else
            {
                return_datetime = get_today_date() + get_today_time();
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbManualTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbManualTime.Checked)
            {
                String hh = get_today_time().Substring(0, 2);
                String mm = get_today_time().Substring(2, 1) + "0";

                for (int i = 0; i < cbHH.Items.Count; i++)
                {
                    if (cbHH.Items[i].ToString() == hh)
                    {
                        cbHH.SelectedIndex = i;
                    }
                }

                for (int i = 0; i < cbMM.Items.Count; i++)
                {
                    if (cbMM.Items[i].ToString() == mm)
                    {
                        cbMM.SelectedIndex = i;
                    }
                }

            }
        }
    }
}
