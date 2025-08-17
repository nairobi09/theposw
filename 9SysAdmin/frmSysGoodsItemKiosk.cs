using Newtonsoft.Json.Linq;
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


namespace thepos._9SysAdmin
{
    public partial class frmSysGoodsItemKiosk : Form
    {
        private int sortColumn = -1;

        String mSelectedShopCode = "";
        String mSelectedGroupCode = "";

        private BindingList<object> selected_groupList = new BindingList<object>();
        private BindingList<object> source_groupList = new BindingList<object>();

        List<String> pos_no = new List<String>();
        List<String> pos_type = new List<String>();


        public frmSysGoodsItemKiosk()
        {
            InitializeComponent();

            initialize_the();



            for (int i = 0; i < mShop.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }



            //
            cbShopView.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShopView.Items.Add(mShop[i].shop_name);
            }
            cbShopView.SelectedIndex = 0;

        }



        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 28);

            lvwGoodsLink.SmallImageList = imgList;
            lvwGoodsLink.HideSelection = true;

        }


        private void btnShopView_Click(object sender, EventArgs e)
        {
            lvwGoods.Items.Clear();
            get_goods();
        }


        private void get_goods()
        {
            String tTicket, tTaxFree = "";

            if (cbShopView.SelectedIndex == -1)
            {
                return;
            }


            String sUrl = "goods?siteId=" + mSiteId + "&shopCode=" + mShop[cbShopView.SelectedIndex].shop_code;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (arr[i]["cutout"].ToString() != "Y")
                        {
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Text = arr[i]["goodsName"].ToString();
                            lvItem.SubItems.Add(arr[i]["amt"].ToString());
                            lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));
                            lvItem.SubItems.Add(get_nod1_name(arr[i]["shopCode"].ToString(), arr[i]["nodCode1"].ToString()));

                            lvItem.Tag = arr[i]["goodsCode"].ToString();

                            lvwGoods.Items.Add(lvItem);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        

        private void cbPosNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedShopCode = mShop[cbShop.SelectedIndex].shop_code;


            String sUrl = "kioskGoodsGroup?siteId=" + mSiteId + "&shopCode=" + mSelectedShopCode;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsGroups"].ToString();
                    JArray arr = JArray.Parse(data);

                    selected_groupList.Clear();
                    for (int i = 0; i < arr.Count; i++)
                    {
                        selected_groupList.Add(new { Text = arr[i]["groupName"].ToString(), Value = arr[i]["groupCode"].ToString() });
                    }

                    if (selected_groupList.Count > 0)
                    {
                        cbGroup.DataSource = selected_groupList;
                        cbGroup.DisplayMember = "Text";
                        cbGroup.ValueMember = "Value";
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            mSelectedShopCode = mShop[cbShop.SelectedIndex].shop_code;


            if (cbGroup.SelectedIndex >= 0)
            {
                mSelectedGroupCode = cbGroup.SelectedValue.ToString();
            }



            reload_server();
        }


        private void reload_server()
        {
            lvwGoodsLink.Items.Clear();

            int[] item_seq;
            String[] item_code;
            String[] item_name;
            int[] item_amt;


            String sUrl = "kioskGoodsItem?siteId=" + mSiteId + "&shopCode=" + mSelectedShopCode + "&groupCode=" + mSelectedGroupCode;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    item_seq = new int[arr.Count];
                    item_code = new String[arr.Count];
                    item_name = new String[arr.Count];
                    item_amt = new int[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        item_seq[i] = convert_number(arr[i]["layoutNo"].ToString());
                        item_code[i] = arr[i]["goodsCode"].ToString();
                        item_name[i] = get_goods_name(arr[i]["goodsCode"].ToString());
                        item_amt[i] = get_goods_amt(arr[i]["goodsCode"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }




            bool sort_complete = false;

            int temp_int = 0;
            String temp_str = "";


            while (!sort_complete)
            {
                sort_complete = true;
                for (int i = 0; i < item_seq.Length - 1; i++)
                {
                    if (item_seq[i] > item_seq[i + 1])
                    {
                        temp_int = item_seq[i];
                        item_seq[i] = item_seq[i + 1];
                        item_seq[i + 1] = temp_int;

                        temp_str = item_code[i];
                        item_code[i] = item_code[i + 1];
                        item_code[i + 1] = temp_str;

                        temp_str = item_name[i];
                        item_name[i] = item_name[i + 1];
                        item_name[i + 1] = temp_str;

                        temp_int = item_amt[i];
                        item_amt[i] = item_amt[i + 1];
                        item_amt[i + 1] = temp_int;

                        sort_complete = false;
                    }
                }
            }



            for (int i = 0; i < item_seq.Length; i++)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = (i + 1).ToString();
                lvItem.SubItems.Add(item_name[i]);
                lvItem.SubItems.Add(item_amt[i] + "");
                lvItem.Tag = item_code[i];

                lvwGoodsLink.Items.Add(lvItem);
            }


        }


        private void btnLink_Click(object sender, EventArgs e)
        {
            if (lvwGoods.SelectedItems.Count == 0) { return; }


            if (mSelectedGroupCode == "")
            {
                MessageBox.Show("포스 그룹 조회 해주세요.", "thepos");
                return;
            }


            for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
            {
                if (lvwGoods.SelectedItems[0].Tag.ToString() == lvwGoodsLink.Items[i].Tag.ToString())
                {
                    MessageBox.Show("이미 등록된 상품입니다.", "thepos");
                    return;
                }
            }


            String mSelectedGoodsCode = lvwGoods.SelectedItems[0].Tag.ToString();


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = mSelectedShopCode;
            parameters["groupCode"] = mSelectedGroupCode;
            parameters["goodsCode"] = lvwGoods.SelectedItems[0].Tag.ToString();
            parameters["layoutNo"] = (lvwGoodsLink.Items.Count + 1).ToString();


            if (mRequestPost("kioskGoodsItem", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }


            reload_server();



            //
            for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
            {
                if (lvwGoodsLink.Items[i].Tag.ToString() == mSelectedGoodsCode)
                {
                    lvwGoodsLink.Items[i].Selected = true; //
                    return;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0) { return; }


            String mSelectedGoodsCode = lvwGoodsLink.SelectedItems[0].Tag.ToString();

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = mSelectedShopCode;
            parameters["groupCode"] = mSelectedGroupCode;
            parameters["goodsCode"] = mSelectedGoodsCode;


            if (mRequestDelete("goodsItem", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            //set_version_basic_db_change();


            reload_server();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            resort_listview_no();


            for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["siteId"] = mSiteId;
                parameters["shopCode"] = mSelectedShopCode;
                parameters["groupCode"] = mSelectedGroupCode;
                parameters["goodsCode"] = lvwGoodsLink.Items[i].Tag.ToString();

                parameters["layoutNo"] = lvwGoodsLink.Items[i].Text;


                if (mRequestPatch("kioskGoodsItem", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            MessageBox.Show("저장완료", "thepos");

        }

        private void resort_listview_no()
        {
            for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
            {
                lvwGoodsLink.Items[i].Text = (i + 1).ToString();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0) { return; }

            if (lvwGoodsLink.SelectedItems[0].Index == 0) { return; }


            ListViewItem items = new ListViewItem();

            items = lvwGoodsLink.SelectedItems[0];
            int idx = lvwGoodsLink.SelectedItems[0].Index;

            lvwGoodsLink.Items[idx].Remove();
            lvwGoodsLink.Items.Insert(idx - 1, items);

            lvwGoodsLink.Items[idx - 1].Selected = true;
            lvwGoodsLink.Select();
        }

        private void btnDn_Click(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0) { return; }

            if (lvwGoodsLink.SelectedItems[0].Index == lvwGoodsLink.Items.Count - 1) { return; }


            ListViewItem items = new ListViewItem();

            items = lvwGoodsLink.SelectedItems[0];
            int idx = lvwGoodsLink.SelectedItems[0].Index;

            lvwGoodsLink.Items[idx].Remove();
            lvwGoodsLink.Items.Insert(idx + 1, items);

            lvwGoodsLink.Items[idx + 1].Selected = true;
            lvwGoodsLink.Select();
        }


        private void lvwGoods_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                lvwGoods.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvwGoods.Sorting == SortOrder.Ascending)
                {
                    lvwGoods.Sorting = SortOrder.Descending;
                }
                else
                {
                    lvwGoods.Sorting = SortOrder.Ascending;
                }
            }


            lvwGoods.Sort();
            this.lvwGoods.ListViewItemSorter = new MyListViewComparer(e.Column, lvwGoods.Sorting);
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
