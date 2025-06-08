using System;
using System.Collections;
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
using System.Drawing.Text;

namespace thepos
{
    public partial class frmOrderBarcode : Form
    {
        //thepos the = new thepos();

        public frmOrderBarcode()
        {
            InitializeComponent();

            //
            thepos_app_log(1, this.Name, "Open", "");

            initialize_the();


        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 28);
            lvwList.SmallImageList = imgList;
            lvwList.HideSelection = true;

            //
            cbShop.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }

            cbShop.SelectedIndex = 0;

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count < 1) return;

            String t_bar_code = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(bar_code)].Text;


            order_goods_barcode(t_bar_code);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwWaiting_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvwList.Columns[e.ColumnIndex].Width;
        }

        private void frmOrderWaiting_FormClosed(object sender, FormClosedEventArgs e)
        {
            mPanelMiddle.Visible = false;

            ConsoleEnable();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            String shop_code = mShop[cbShop.SelectedIndex].shop_code;
            

            lvwList.Items.Clear();

            for (int i = 0; i < mGoodsList.Count; i++)
            {
                if ((mGoodsList[i].shop_code == shop_code | shop_code == "") & mGoodsList[i].bar_code != "")
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = get_shop_name(mGoodsList[i].shop_code);
                    item.SubItems.Add(mGoodsList[i].bar_code);
                    item.SubItems.Add(mGoodsList[i].goods_name);
                    item.SubItems.Add(mGoodsList[i].amt.ToString("N0"));
                    item.SubItems.Add(mGoodsList[i].goods_code);
                    lvwList.Items.Add(item);
                }
            }

        }
    }
}
