using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace thepos._9SysAdmin
{
    public partial class frmSysSoldout : Form
    {
        private int sortColumn = -1;


        public frmSysSoldout()
        {
            InitializeComponent();

            for (int i = 0; i < myPosNoList.Count; i++)
            {
                cbPosNo.Items.Add(myPosNoList[i]);
            }
        }


        private void btnViewGoods_Click(object sender, EventArgs e)
        {
            reload_goods();
        }

        private void btnViewGroup_Click(object sender, EventArgs e)
        {
            reload_group();
        }


        private void reload_goods()
        {
            lvwGoodsList.Items.Clear();

            String sUrl = "goods?siteId=" + mSiteId + "&shopCode=" + myShopCode;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = get_shop_name(arr[i]["shopCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["goodsName"].ToString());
                        lvItem.SubItems.Add(arr[i]["amt"].ToString());

                        String t_soldout = arr[i]["soldout"].ToString();
                        if (t_soldout == "Y")
                        {
                            lvItem.SubItems.Add("Y");
                        }
                        else
                        {
                            lvItem.SubItems.Add("");
                        }

                        String t_cutout = arr[i]["cutout"].ToString();
                        if (t_cutout == "Y")
                        {
                            lvItem.SubItems.Add("Y");
                        }
                        else
                        {
                            lvItem.SubItems.Add("");
                        }

                        lvItem.Tag = arr[i]["goodsCode"].ToString();

                        lvwGoodsList.Items.Add(lvItem);

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


        private void reload_group()
        {
            lvwGroupList.Items.Clear();

            if (cbPosNo.SelectedIndex < 0)
            {
                return;
            }


            String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + myPosNoList[cbPosNo.SelectedIndex];

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsGroups"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = myPosNoList[cbPosNo.SelectedIndex];
                        lvItem.SubItems.Add(arr[i]["groupName"].ToString());

                        if (arr[i]["soldout"].ToString() == "Y")
                        {
                            lvItem.SubItems.Add("Y");
                        }
                        else
                        {
                            lvItem.SubItems.Add("");
                        }

                        if (arr[i]["cutout"].ToString() == "Y")
                        {
                            lvItem.SubItems.Add("Y");
                        }
                        else
                        {
                            lvItem.SubItems.Add("");
                        }

                        lvItem.Tag = arr[i]["groupCode"].ToString();

                        lvwGroupList.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("상품그룹정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

        private void lvwGoodsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGoodsList.SelectedItems.Count == 0)
            {
                cbGoodsSoldout.Checked = false;
                cbGoodsCutout.Checked = false;
                return; 
            }

            if (lvwGoodsList.SelectedItems[0].SubItems[lvwGoodsList.Columns.IndexOf(goods_soldout)].Text == "Y")
            {
                cbGoodsSoldout.Checked = true;
            }
            else
            {
                cbGoodsSoldout.Checked = false;
            }

            if (lvwGoodsList.SelectedItems[0].SubItems[lvwGoodsList.Columns.IndexOf(goods_cutout)].Text == "Y")
            {
                cbGoodsCutout.Checked = true;
            }
            else
            {
                cbGoodsCutout.Checked = false;
            }
        }

        private void lvwGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGroupList.SelectedItems.Count == 0)
            {
                cbGroupSoldout.Checked = false;
                cbGroupCutout.Checked = false;
                return;
            }

            if (lvwGroupList.SelectedItems[0].SubItems[lvwGroupList.Columns.IndexOf(group_soldout)].Text == "Y")
            {
                cbGroupSoldout.Checked = true;
            }
            else
            {
                cbGroupSoldout.Checked = false;
            }

            if (lvwGroupList.SelectedItems[0].SubItems[lvwGroupList.Columns.IndexOf(group_cutout)].Text == "Y")
            {
                cbGroupCutout.Checked = true;
            }
            else
            {
                cbGroupCutout.Checked = false;
            }
        }


        private void btnGoodsUpdate_Click(object sender, EventArgs e)
        {
            String t_soldout = "";
            String t_cutout = "";

            if (cbGoodsSoldout.Checked == true)
            {
                t_soldout = "Y";
            }
            else
            {
                t_soldout = "";
            }

            if (cbGoodsCutout.Checked == true)
            {
                t_cutout = "Y";
            }
            else
            {
                t_cutout = "";
            }

            if (lvwGoodsList.SelectedItems[0].SubItems[lvwGoodsList.Columns.IndexOf(goods_soldout)].Text == t_soldout & 
                lvwGoodsList.SelectedItems[0].SubItems[lvwGoodsList.Columns.IndexOf(goods_cutout)].Text == t_cutout)
            {
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = lvwGoodsList.SelectedItems[0].Tag.ToString();
            parameters["soldout"] = t_soldout;
            parameters["cutout"] = t_cutout;

            if (mRequestPatch("goods", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    // 화면 업데이트 -> 전체 reload하지 않는다...
                    lvwGoodsList.SelectedItems[0].SubItems[lvwGoodsList.Columns.IndexOf(goods_soldout)].Text = t_soldout;
                    lvwGoodsList.SelectedItems[0].SubItems[lvwGoodsList.Columns.IndexOf(goods_cutout)].Text = t_cutout;
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



        private void btnGroupUpdate_Click(object sender, EventArgs e)
        {
            String t_soldout = "";
            String t_cutout = "";

            if (cbGroupSoldout.Checked == true)
            {
                t_soldout = "Y";
            }
            else
            {
                t_soldout = "";
            }

            if (cbGroupCutout.Checked == true)
            {
                t_cutout = "Y";
            }
            else
            {
                t_cutout = "";
            }

            if (lvwGroupList.SelectedItems[0].SubItems[lvwGroupList.Columns.IndexOf(group_soldout)].Text == t_soldout &
                lvwGroupList.SelectedItems[0].SubItems[lvwGroupList.Columns.IndexOf(group_cutout)].Text == t_cutout)
            {
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = lvwGroupList.SelectedItems[0].Text;
            parameters["groupCode"] = lvwGroupList.SelectedItems[0].Tag.ToString();
            parameters["soldout"] = t_soldout;
            parameters["cutout"] = t_cutout;

            if (mRequestPatch("goodsGroup", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    // 화면 업데이트 -> 전체 reload하지 않는다...
                    lvwGroupList.SelectedItems[0].SubItems[lvwGroupList.Columns.IndexOf(group_soldout)].Text = t_soldout;
                    lvwGroupList.SelectedItems[0].SubItems[lvwGroupList.Columns.IndexOf(group_cutout)].Text = t_cutout;
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

        private void lvwGoodsList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //? 숫자컬럼(단가) Sorting 고려하기

            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                lvwGoodsList.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvwGoodsList.Sorting == SortOrder.Ascending)
                {
                    lvwGoodsList.Sorting = SortOrder.Descending;
                }
                else
                {
                    lvwGoodsList.Sorting = SortOrder.Ascending;
                }
            }


            lvwGoodsList.Sort();
            this.lvwGoodsList.ListViewItemSorter = new MyListViewComparer(e.Column, lvwGoodsList.Sorting);
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
