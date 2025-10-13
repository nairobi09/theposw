using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;


namespace thepos
{
    public partial class frmSysGoodsItemPosXY : Form
    {
        private int sortColumn = -1;

        String mSelectedShopCode = "";
        String mSelectedGroupCode = "";

        private BindingList<object> selected_groupList = new BindingList<object>();
        private BindingList<object> source_groupList = new BindingList<object>();


        List<String> pos_no = new List<String>();
        List<String> pos_type = new List<String>();


        public frmSysGoodsItemPosXY()
        {
            InitializeComponent();
            initialize_the();



            cbShop.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }


            //get_posno_from_setupPos();

            /*
            for (int i = 0; i < mPosNoList.Count; i++)
            {
                cbPosNo.Items.Add(mPosNoList[i]);
                cbSourcePosNo.Items.Add(mPosNoList[i]);
            }
            */


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


        private void cbShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedShopCode = mShop[cbShop.SelectedIndex].shop_code;


            String sUrl = "posGoodsGroup?siteId=" + mSiteId + "&shopCode=" + mSelectedShopCode;

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

                    if (arr.Count > 0)
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

            if (cbGroup.SelectedIndex < 0)
            {
                return;
            }


            mSelectedGroupCode = cbGroup.SelectedValue.ToString();

            reload_server();

            display_all_console();

        }

        private void reload_server()
        {
            lvwGoodsLink.Items.Clear();

            tbLocateX.Text = "";
            tbLocateY.Text = "";
            tbSizeX.Text = "";
            tbSizeY.Text = "";

            tableLayoutPanelItemSelected.Controls.Clear();


            String sUrl = "posGoodsItem?siteId=" + mSiteId + "&shopCode=" + mSelectedShopCode + "&groupCode=" + mSelectedGroupCode;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = get_goods_name(arr[i]["goodsCode"].ToString());
                        lvItem.SubItems.Add(get_goods_amt(arr[i]["goodsCode"].ToString()).ToString("N0"));
                        lvItem.SubItems.Add(arr[i]["locateX"].ToString());
                        lvItem.SubItems.Add(arr[i]["locateY"].ToString());
                        lvItem.SubItems.Add(arr[i]["sizeX"].ToString());
                        lvItem.SubItems.Add(arr[i]["sizeY"].ToString());
                        lvItem.SubItems.Add(arr[i]["btnColor"].ToString());
                        lvItem.Tag = arr[i]["goodsCode"].ToString();

                        lvwGoodsLink.Items.Add(lvItem);

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

        private void display_all_console()
        {
            tableLayoutPanelItem.Controls.Clear();

            for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
            {
                try
                {
                    int loc_x = convert_number(lvwGoodsLink.Items[i].SubItems[lvwGoodsLink.Columns.IndexOf(X)].Text);
                    int loc_y = convert_number(lvwGoodsLink.Items[i].SubItems[lvwGoodsLink.Columns.IndexOf(Y)].Text);
                    int sz_x = convert_number(lvwGoodsLink.Items[i].SubItems[lvwGoodsLink.Columns.IndexOf(W)].Text);
                    int sz_y = convert_number(lvwGoodsLink.Items[i].SubItems[lvwGoodsLink.Columns.IndexOf(H)].Text);
                    String btnColor = lvwGoodsLink.Items[i].SubItems[lvwGoodsLink.Columns.IndexOf(btn_color)].Text;

                    if (btnColor == "") btnColor = mTheposColor;

                    Button btnItem = new Button();
                    btnItem.FlatStyle = FlatStyle.Flat;
                    btnItem.ForeColor = Color.White;
                    btnItem.BackColor = ColorTranslator.FromHtml(btnColor);
                    btnItem.TabStop = false;
                    btnItem.Margin = new Padding(1, 1, 1, 1);
                    btnItem.Padding = new Padding(0, 0, 0, 0);
                    btnItem.Text = lvwGoodsLink.Items[i].Text + "\n" + lvwGoodsLink.Items[i].SubItems[1].Text;
                    btnItem.Dock = DockStyle.Fill;

                    if (sz_x == 1 | sz_y == 1) { btnItem.Font = new Font(btnItem.Font.FontFamily, 6); }
                    else if (sz_x == 2 & sz_y == 2) { btnItem.Font = new Font(btnItem.Font.FontFamily, 8); }
                    else if (sz_x >= 3 & sz_y >= 3) { btnItem.Font = new Font(btnItem.Font.FontFamily, 12); }
                    else { btnItem.Font = new Font(btnItem.Font.FontFamily, 8); }

                    tableLayoutPanelItem.Controls.Add(btnItem, loc_x, loc_y);
                    tableLayoutPanelItem.SetColumnSpan(btnItem, sz_x);
                    tableLayoutPanelItem.SetRowSpan(btnItem, sz_y);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류. display all console()\n\n" + ex.Message, "thepos");
                    return;
                }
            }
        }

        private void lvwGoodsLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0)
            {
                tbLocateX.Text = "";
                tbLocateY.Text = "";
                tbSizeX.Text = "";
                tbSizeY.Text = "";

                tbColor.Text = "";
                btnColor.BackColor = ColorTranslator.FromHtml(tbColor.Text);

                tableLayoutPanelItemSelected.Controls.Clear();
            }
            else
            {
                tbLocateX.Text = lvwGoodsLink.SelectedItems[0].SubItems[lvwGoodsLink.Columns.IndexOf(X)].Text;
                tbLocateY.Text = lvwGoodsLink.SelectedItems[0].SubItems[lvwGoodsLink.Columns.IndexOf(Y)].Text;
                tbSizeX.Text = lvwGoodsLink.SelectedItems[0].SubItems[lvwGoodsLink.Columns.IndexOf(W)].Text;
                tbSizeY.Text = lvwGoodsLink.SelectedItems[0].SubItems[lvwGoodsLink.Columns.IndexOf(H)].Text;

                tbColor.Text = lvwGoodsLink.SelectedItems[0].SubItems[lvwGoodsLink.Columns.IndexOf(btn_color)].Text;

                btnColor.BackColor = ColorTranslator.FromHtml(tbColor.Text);

                display_selected_console();
            }
        }


        private void display_selected_console()
        {
            tableLayoutPanelItemSelected.Controls.Clear();

            try
            {
                int locX = convert_number(tbLocateX.Text);
                int locY = convert_number(tbLocateY.Text);
                int szX = convert_number(tbSizeX.Text);
                int szY = convert_number(tbSizeY.Text);
                String btnColor = tbColor.Text;

                if (btnColor == "") btnColor = mTheposColor;

                Button btnGroupBlue = new Button();
                btnGroupBlue.FlatStyle = FlatStyle.Flat;
                btnGroupBlue.ForeColor = Color.White;
                btnGroupBlue.BackColor = ColorTranslator.FromHtml(btnColor);
                btnGroupBlue.TabStop = false;
                btnGroupBlue.Margin = new Padding(1, 1, 1, 1);
                btnGroupBlue.Padding = new Padding(0, 0, 0, 0);
                btnGroupBlue.Text = "";
                btnGroupBlue.Dock = DockStyle.Fill;

                if (szX == 1 | szY == 1) { btnGroupBlue.Font = new Font(btnGroupBlue.Font.FontFamily, 8); }
                else if (szX >= 3 & szY >= 2) { btnGroupBlue.Font = new Font(btnGroupBlue.Font.FontFamily, 16); }
                else { btnGroupBlue.Font = new Font(btnGroupBlue.Font.FontFamily, 10); }

                tableLayoutPanelItemSelected.Controls.Add(btnGroupBlue, locX, locY);
                tableLayoutPanelItemSelected.SetColumnSpan(btnGroupBlue, szX);
                tableLayoutPanelItemSelected.SetRowSpan(btnGroupBlue, szY);
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류. display selected console()\n\n" + ex.Message, "thepos");
                return;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0) { return; }

            if (!check_data())
            {
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = mSelectedShopCode;
            parameters["groupCode"] = mSelectedGroupCode;
            parameters["goodsCode"] = lvwGoodsLink.SelectedItems[0].Tag.ToString();
            parameters["locateX"] = tbLocateX.Text;
            parameters["locateY"] = tbLocateY.Text;
            parameters["sizeX"] = tbSizeX.Text;
            parameters["sizeY"] = tbSizeY.Text;
            parameters["btnColor"] = tbColor.Text;

            if (mRequestPatch("posGoodsItem", parameters))
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

            display_all_console();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0) { return; }

            if (MessageBox.Show("선택 상품연결정보를 삭제합니다.", "thwpos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
            else
            {
                return;
            }



            String mSelectedGoodsCode = lvwGoodsLink.SelectedItems[0].Tag.ToString();


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = mSelectedShopCode;
            parameters["groupCode"] = mSelectedGroupCode;
            parameters["goodsCode"] = mSelectedGoodsCode;


            if (mRequestDelete("posGoodsItem", parameters))
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

            display_all_console();

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
            parameters["locateX"] = "11";
            parameters["locateY"] = "11";
            parameters["sizeX"] = "1";
            parameters["sizeY"] = "1";
            parameters["btnColor"] = "";


            if (mRequestPost("posGoodsItem", parameters))
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

            display_all_console();


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

        private void btnApply_Click(object sender, EventArgs e)
        {
            apply_console();
        }

        private void apply_console()
        { 
            if (!check_data())
            {
                return;
            }

            display_selected_console();
        }


        private bool check_data()
        {
            int tNum = 0;
            int locX, locY, szX, szY;

            if (!get_number(tbLocateX.Text, ref tNum)) { MessageBox.Show("LocX 오류.", "thepos"); return false; }
            if (tNum > 11) { MessageBox.Show("LocX 오류.", "thepos"); return false; }
            locX = tNum;

            if (!get_number(tbLocateY.Text, ref tNum)) { MessageBox.Show("LocY 오류.", "thepos"); return false; }
            if (tNum > 11) { MessageBox.Show("LocY 오류.", "thepos"); return false; }
            locY = tNum;

            if (!get_number(tbSizeX.Text, ref tNum)) { MessageBox.Show("SizeX 오류.", "thepos"); return false; }
            if (tNum > 12) { MessageBox.Show("SizeX 오류.", "thepos"); return false; }
            szX = tNum;

            if (!get_number(tbSizeY.Text, ref tNum)) { MessageBox.Show("SizeY 오류.", "thepos"); return false; }
            if (tNum > 12) { MessageBox.Show("SizeY 오류.", "thepos"); return false; }
            szY = tNum;


            if (locX + szX > 12) { MessageBox.Show("X범위 오류.", "thepos"); return false; }
            if (locY + szY > 12) { MessageBox.Show("Y범위 오류.", "thepos"); return false; }


            if (tbColor.Text == "")
            {
                
            }
            else if (Regex.IsMatch(tbColor.Text, @"^#(?:[0-9A-Fa-f]{6}|[0-9A-Fa-f]{8})$"))
            {
                
            }
            else
            {
                MessageBox.Show("컬러값 오류.", "thepos");
                return false;
            }

            return true;
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

        private void tbColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String htmlColor = tbColor.Text;

                try
                {
                    btnColor.BackColor = ColorTranslator.FromHtml(htmlColor);
                }
                catch
                {
                    MessageBox.Show("컬러값 오류.", "thepos");
                    return;
                }
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
    }
}
