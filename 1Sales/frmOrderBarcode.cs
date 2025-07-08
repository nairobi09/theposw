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

        private int sortColumn = -1;

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

            //
            thepos_app_log(2, this.Name, "바코드상품선택", "barcode=" + t_bar_code);

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


        private void frmOrderBarcode_FormClosed(object sender, FormClosedEventArgs e)
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

        private void lvwList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //?? 숫자컬럼(단가) Sorting 고려하기

            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                lvwList.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvwList.Sorting == SortOrder.Ascending)
                {
                    lvwList.Sorting = SortOrder.Descending;
                }
                else
                {
                    lvwList.Sorting = SortOrder.Ascending;
                }
            }


            lvwList.Sort();
            this.lvwList.ListViewItemSorter = new MyListViewComparer(e.Column, lvwList.Sorting);
        }

        class MyListViewComparer : IComparer
        {
            private int col; private SortOrder order; public MyListViewComparer() { col = 0; order = SortOrder.Ascending; }

            public MyListViewComparer(int column, SortOrder order) { col = column; this.order = order; }

            public int Compare(object x, object y)
            {
                int returnVal = -1; returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

                // Determine whether the sort order is descending. 
                if (order == SortOrder.Descending) returnVal *= -1; // Invert the value returned by String.Compare. 

                return returnVal;
            }
        }
    }
}
