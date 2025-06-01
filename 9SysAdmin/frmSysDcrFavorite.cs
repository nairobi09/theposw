using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static thepos.thePos;

namespace thepos._1Sales
{
    public partial class frmSysDcrFavorite : Form
    {

        String thisShopCode = "";

        public frmSysDcrFavorite()
        {
            InitializeComponent();
            initialize_the();
        }


        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 28);

            lvwList.SmallImageList = imgList;
            lvwList.HideSelection = true;


            cbShopView.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShopView.Items.Add(mShop[i].shop_name);
            }

            cbShopView.SelectedIndex = 0;


            //
            cbDes.Items.Clear();
            cbDes.Items.Add("선택");
            cbDes.Items.Add("전체");

            cbType.Items.Clear();
            cbType.Items.Add("정액(W)");
            cbType.Items.Add("정율(%)");
        }


        private void btnView_Click(object sender, EventArgs e)
        {

            thisShopCode = "";

            if (cbShopView.SelectedIndex < 0)
            {
                return;
            }


            if (cbShopView.SelectedIndex == 0)
            {
                MessageBox.Show("업장을 선택해주세요", "thepos");
                return;
            }



            thisShopCode = mShop[cbShopView.SelectedIndex].shop_code;

            reload_server();
        }



        private void reload_server()
        {
            lvwList.Items.Clear();

            String sUrl = "dcrFavorite?siteId=" + mSiteId + "&shopCode=" + thisShopCode;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["dcr"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();

                        lvItem.Text = arr[i]["sortNo"].ToString();
                        lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));
                        lvItem.SubItems.Add(arr[i]["dcrCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["dcrName"].ToString());

                        lvItem.SubItems.Add(get_dcr_des_name(arr[i]["dcrDes"].ToString()));
                        lvItem.SubItems.Add(get_dcr_type_name(arr[i]["dcrType"].ToString()));

                        lvItem.SubItems.Add(arr[i]["dcrValue"].ToString());
                        lvItem.SubItems.Add(arr[i]["dcrDes"].ToString());
                        lvItem.SubItems.Add(arr[i]["dcrType"].ToString());

                        lvItem.SubItems.Add(arr[i]["shopCode"].ToString());

                        lvwList.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("할인즐겨찾기정보 오류. shop\n\n " + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            tbCode.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(code)].Text;
            tbName.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(name)].Text;

            cbDes.SelectedIndex = -1;
            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(des1)].Text == "S") cbDes.SelectedIndex = 0;
            else if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(des1)].Text == "E") cbDes.SelectedIndex = 1;

            cbType.SelectedIndex = -1;
            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(type1)].Text == "A") cbType.SelectedIndex = 0;
            else if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(type1)].Text == "R") cbType.SelectedIndex = 1;

            tbValue.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(value)].Text;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (check_data() == false)
            {
                MessageBox.Show("데이터 오류가 있습니다.", "thepos");
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = thisShopCode;
            parameters["sortNo"] = "0";
            parameters["dcrCode"] = tbCode.Text;
            parameters["dcrName"] = tbName.Text;

            //
            String dcr_des = "";
            if (cbDes.SelectedIndex == 0) dcr_des = "S";
            else if (cbDes.SelectedIndex == 1) dcr_des = "E";

            parameters["dcrDes"] = dcr_des;

            //
            String dcr_type = "";
            if (cbType.SelectedIndex == 0) dcr_type = "A";
            else if (cbType.SelectedIndex == 1) dcr_type = "R";

            parameters["dcrType"] = dcr_type;

            //
            parameters["dcrValue"] = tbValue.Text;

            if (mRequestPost("dcrFavorite", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("할인정보 입력오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

            MessageBox.Show("정상 저장 완료.", "thepos");

            reload_server();

            clear_console();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            if (check_data() == false)
            {
                MessageBox.Show("데이터 오류가 있습니다.", "thepos");
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = thisShopCode;
            parameters["dcrCode"] = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(code)].Text;
            parameters["sortNo"] = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(no)].Text;
            parameters["dcrName"] = tbName.Text;

            //
            String dcr_des = "";
            if (cbDes.SelectedIndex == 0) dcr_des = "S";
            else if (cbDes.SelectedIndex == 1) dcr_des = "E";

            parameters["dcrDes"] = dcr_des;

            //
            String dcr_type = "";
            if (cbType.SelectedIndex == 0) dcr_type = "A";
            else if (cbType.SelectedIndex == 1) dcr_type = "R";

            parameters["dcrType"] = dcr_type;

            //
            parameters["dcrValue"] = tbValue.Text;

            if (mRequestPatch("dcrFavorite", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("할인정보 수장오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

            MessageBox.Show("정상 저장 완료.", "thepos");

            reload_server();

            clear_console();

        }

        private bool check_data()
        {
            if (tbCode.Text.Trim().Length != 6) return false;

            if (tbCode.Text.Substring(0,2) != "DC") return false;


            if (tbName.Text.Trim().Length < 1) return false;
            if (cbDes.SelectedIndex < 0) return false;
            if (cbType.SelectedIndex < 0) return false;

            if (!is_number(tbValue.Text)) return false;

            int value = convert_number(tbValue.Text);

            if (value < 1) return false;

            if (cbType.SelectedIndex == 1)  // 정율
            {
                if (value > 100) return false;
            }

            return true;
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = thisShopCode;
            parameters["dcrCode"] = tbCode.Text;

            if (mRequestDelete("dcrFavorite", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("할인정보 삭제오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_server();

            clear_console();

        }

        private void clear_console()
        {
            tbCode.Text = "";
            tbName.Text = "";
            cbDes.SelectedIndex = -1;
            cbType.SelectedIndex = -1;
            tbValue.Text = "";
        }


        private void resort_listview_no()
        {
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                lvwList.Items[i].Text = (i + 1).ToString();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            resort_listview_no();



            // 차례로 순번 수정
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["siteId"] = mSiteId;
                parameters["shopCode"] = thisShopCode;
                parameters["dcrCode"] = lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(code)].Text;
                parameters["sortNo"] = lvwList.Items[i].Text;

                if (mRequestPatch("dcrFavorite", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("할인정보 수정오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            MessageBox.Show("정상 저장 완료.", "thepos");

            reload_server();

            clear_console();

            //
            //set_version_basic_db_change();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            if (lvwList.SelectedItems[0].Index == 0) { return; }


            ListViewItem items = new ListViewItem();

            items = lvwList.SelectedItems[0];
            int idx = lvwList.SelectedItems[0].Index;

            lvwList.Items[idx].Remove();
            lvwList.Items.Insert(idx - 1, items);

            lvwList.Items[idx-1].Selected = true;
            lvwList.Select();

            resort_listview_no();

        }

        private void btnDn_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            if (lvwList.SelectedItems[0].Index == lvwList.Items.Count - 1) { return; }


            ListViewItem items = new ListViewItem();

            items = lvwList.SelectedItems[0];
            int idx = lvwList.SelectedItems[0].Index;

            lvwList.Items[idx].Remove();
            lvwList.Items.Insert(idx + 1, items);

            lvwList.Items[idx+1].Selected = true;
            lvwList.Select();

            resort_listview_no();
        }


    }
}
