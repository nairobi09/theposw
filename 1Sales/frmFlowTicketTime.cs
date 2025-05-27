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



        public frmFlowTicketTime(String job)
        {
            InitializeComponent();

            labelCurrentTime.Text = "현재시간  :  " + get_today_time().Substring(0,2) + ":" + get_today_time().Substring(2,2);

            if (job == "Entry")
            {
                lblTitle.Text = "입장시간";
            }
            else if (job == "Exit")
            {
                lblTitle.Text = "퇴장시간";
            }
            else if (job == "Ebd")
            {
                lblTitle.Text = "완료시간";
            }
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
                panelManualTime.Enabled = true;

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
            else
            {
                panelManualTime.Enabled = false;

                cbHH.SelectedIndex = -1;
                cbMM.SelectedIndex = -1;
            }
        }
    }
}
