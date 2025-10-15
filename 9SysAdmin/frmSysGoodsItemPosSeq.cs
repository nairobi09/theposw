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
using static thepos.frmSysGoodsItemPosSeq;
using static thepos.thePos;


namespace thepos
{
    public partial class frmSysGoodsItemPosSeq : Form
    {
        private int sortColumn = -1;

        String mSelectedPosGroupCode = "";
        String mSelectedGoodsGroupCode = "";

        private BindingList<object> selected_groupList = new BindingList<object>();
        private BindingList<object> source_groupList = new BindingList<object>();

        List<String> pos_no = new List<String>();
        List<String> pos_type = new List<String>();



        public struct GoodsItemSeq
        {
            public int item_seq;
            public String item_code;
            public String item_name;
            public int item_amt;
            public String item_color;
        }
        List<GoodsItemSeq> mGoodsItemSeq = new List<GoodsItemSeq>();



        public frmSysGoodsItemPosSeq()
        {
            InitializeComponent();

            initialize_the();



            for (int i = 0; i < mShop.Length; i++)
            {
                cbPosGroup.Items.Add(mShop[i].shop_name);
            }



            //
            cbShop.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }
            cbShop.SelectedIndex = 0;

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

            if (cbShop.SelectedIndex == -1)
            {
                return;
            }


            String sUrl = "goods?siteId=" + mSiteId + "&shopCode=" + mShop[cbShop.SelectedIndex].shop_code;

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


        private void cbShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedPosGroupCode = mPosGroupCodeList[cbPosGroup.SelectedIndex];


            String sUrl = "posGoodsGroupSeq?siteId=" + mSiteId + "&shopCode=" + mSelectedPosGroupCode;

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
                        cbGoodsGroup.DataSource = selected_groupList;
                        cbGoodsGroup.DisplayMember = "Text";
                        cbGoodsGroup.ValueMember = "Value";
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

        private void btnGroupView_Click(object sender, EventArgs e)
        {
            mSelectedPosGroupCode = mPosGroupCodeList[cbPosGroup.SelectedIndex];


            if (cbGoodsGroup.SelectedIndex >= 0)
            {
                mSelectedGoodsGroupCode = cbGoodsGroup.SelectedValue.ToString();
            }



            reload_server();
        }


        private void reload_server()
        {
            lvwGoodsLink.Items.Clear();

            mGoodsItemSeq.Clear();



            String sUrl = "posGoodsItemSeq?siteId=" + mSiteId + "&shopCode=" + mSelectedPosGroupCode + "&groupCode=" + mSelectedGoodsGroupCode;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    


                    for (int i = 0; i < arr.Count; i++)
                    {
                        GoodsItemSeq goods_items_seq = new GoodsItemSeq();

                        goods_items_seq.item_seq = convert_number(arr[i]["layoutNo"].ToString());
                        goods_items_seq.item_code = arr[i]["goodsCode"].ToString();
                        goods_items_seq.item_name = get_goods_name(arr[i]["goodsCode"].ToString());
                        goods_items_seq.item_amt = get_goods_amt(arr[i]["goodsCode"].ToString());
                        goods_items_seq.item_color = arr[i]["btnColor"].ToString();

                        mGoodsItemSeq.Add(goods_items_seq);

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





            // 정렬
            mGoodsItemSeq.Sort((a, b) => a.item_seq.CompareTo(b.item_seq));





            for (int i = 0; i < mGoodsItemSeq.Count; i++)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = mGoodsItemSeq[i].item_seq.ToString();
                lvItem.SubItems.Add(mGoodsItemSeq[i].item_name);
                lvItem.SubItems.Add(mGoodsItemSeq[i].item_amt + "");
                lvItem.SubItems.Add(mGoodsItemSeq[i].item_color);
                lvItem.Tag = mGoodsItemSeq[i].item_code;

                lvwGoodsLink.Items.Add(lvItem);
            }


        }


        private void btnLink_Click(object sender, EventArgs e)
        {
            if (lvwGoods.SelectedItems.Count == 0) { return; }


            if (mSelectedGoodsGroupCode == "")
            {
                MessageBox.Show("포스/상품 그룹 조회 해주세요.", "thepos");
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
            parameters["shopCode"] = mSelectedPosGroupCode;
            parameters["groupCode"] = mSelectedGoodsGroupCode;
            parameters["goodsCode"] = lvwGoods.SelectedItems[0].Tag.ToString();
            parameters["layoutNo"] = (lvwGoodsLink.Items.Count + 1).ToString();


            if (mRequestPost("posGoodsItemSeq", parameters))
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
            parameters["shopCode"] = mSelectedPosGroupCode;
            parameters["groupCode"] = mSelectedGoodsGroupCode;
            parameters["goodsCode"] = mSelectedGoodsCode;


            if (mRequestDelete("posGoodsItemSeq", parameters))
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
                parameters["shopCode"] = mSelectedPosGroupCode;
                parameters["groupCode"] = mSelectedGoodsGroupCode;
                parameters["goodsCode"] = lvwGoodsLink.Items[i].Tag.ToString();

                parameters["layoutNo"] = lvwGoodsLink.Items[i].Text;


                if (mRequestPatch("posGoodsItemSeq", parameters))
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

        private void lvwGoodsLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0)
            {
                tbColor.Text = "";
                btnColor.BackColor = ColorTranslator.FromHtml(tbColor.Text);

            }
            else
            {
                tbColor.Text = lvwGoodsLink.SelectedItems[0].SubItems[lvwGoodsLink.Columns.IndexOf(btn_color)].Text;

                btnColor.BackColor = ColorTranslator.FromHtml(tbColor.Text);

            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // 선택된 색상으로 폼의 배경색을 변경
                Color color = colorDialog.Color;

                string htmlColor = $"#{color.R:X2}{color.G:X2}{color.B:X2}";

                tbColor.Text = htmlColor;
                btnColor.BackColor = ColorTranslator.FromHtml(htmlColor);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = mSelectedPosGroupCode;
            parameters["groupCode"] = mSelectedGoodsGroupCode;
            parameters["goodsCode"] = lvwGoodsLink.SelectedItems[0].Tag.ToString();
            parameters["btnColor"] = tbColor.Text;
            


            if (mRequestPatch("posGoodsItemSeq", parameters))
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
        }
    }
}
