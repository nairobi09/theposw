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
using Newtonsoft.Json.Linq;

namespace thepos
{
    public partial class frmSysGoodsGroupPosSeq : Form
    {
        int max_groupcode = 100;  // 3자리

        String mSelectedPosGroupCode = "";

        List<String> pos_no = new List<String>();
        List<String> pos_type = new List<String>();


        public frmSysGoodsGroupPosSeq()
        {
            InitializeComponent();

            for (int i = 0; i < mPosGroupCodeList.Count; i++)
            {
                cbPosGroup.Items.Add(mPosGroupNameList[i]);
            }


            //get_posno();
            //get_posno_from_setupPos();

        }



        private void btnView_Click(object sender, EventArgs e)
        {
            if (cbPosGroup.SelectedIndex == -1) { return; }

            mSelectedPosGroupCode = mShop[cbPosGroup.SelectedIndex].shop_code;


            reload_server();

        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                tbGroupName.Text = "";

            }
            else
            {
                tbGroupName.Text = lvwList.SelectedItems[0].SubItems[1].Text;
                tbColor.Text = lvwList.SelectedItems[0].SubItems[2].Text;

                btnColor.BackColor = ColorTranslator.FromHtml(tbColor.Text);



            }
        }


        private void reload_server()
        {

            lvwList.Items.Clear();

            tbGroupName.Text = "";

            int[] group_seq;
            String[] group_code;
            String[] group_name;
            String[] group_color;



            String sUrl = "posGoodsGroupSeq?siteId=" + mSiteId + "&shopCode=" + mSelectedPosGroupCode;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsGroups"].ToString();
                    JArray arr = JArray.Parse(data);

                    group_seq = new int[arr.Count];
                    group_code = new String[arr.Count];
                    group_name = new String[arr.Count];
                    group_color = new String[arr.Count];


                    for (int i = 0; i < arr.Count; i++)
                    {
                        group_seq[i] = convert_number(arr[i]["layoutNo"].ToString());
                        group_code[i] = arr[i]["groupCode"].ToString();
                        group_name[i] = arr[i]["groupName"].ToString();
                        group_color[i] = arr[i]["btnColor"].ToString();

                        int code_num = 0;
                        if (get_number(arr[i]["groupCode"].ToString(), ref code_num))
                        {
                            if (max_groupcode < code_num)
                            {
                                max_groupcode = code_num;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("포스정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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


            while(!sort_complete)
            {
                sort_complete = true;
                for (int i = 0; i < group_seq.Length - 1; i++)
                {
                    if (group_seq[i] > group_seq[i+1])
                    {
                        temp_int = group_seq[i];
                        group_seq[i] = group_seq[i + 1];
                        group_seq[i + 1] = temp_int;

                        temp_str = group_code[i];
                        group_code[i] = group_code[i + 1];
                        group_code[i + 1] = temp_str;

                        temp_str = group_name[i];       
                        group_name[i] = group_name[i + 1];          
                        group_name[i + 1] = temp_str;

                        temp_str = group_color[i];
                        group_color[i] = group_color[i + 1];
                        group_color[i + 1] = temp_str;


                        sort_complete = false;
                    }
                }
            }


            for (int i = 0; i < group_seq.Length; i++)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = (i + 1).ToString();
                lvItem.SubItems.Add(group_name[i]);
                lvItem.SubItems.Add(group_color[i]);
                lvItem.Tag = group_code[i];

                lvwList.Items.Add(lvItem);

            }


            // 필드 초기화
            tbColor.Text = "";
            btnColor.BackColor = Color.White;




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

            lvwList.Items[idx - 1].Selected = true;
            lvwList.Select();



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

            lvwList.Items[idx + 1].Selected = true;
            lvwList.Select();

        }



        private void btnInput_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = mSelectedPosGroupCode;
            parameters["groupCode"] = (++max_groupcode).ToString();
            parameters["groupName"] = tbGroupName.Text;
            parameters["layoutNo"] = (lvwList.Items.Count + 1).ToString();
            parameters["btnColor"] = tbColor.Text;
            parameters["soldout"] = "";
            parameters["cutout"] = "";

            if (mRequestPost("posGoodsGroupSeq", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("그룹버튼 입력 완료.", "thepos");
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = mSelectedPosGroupCode;
            parameters["groupCode"] = lvwList.SelectedItems[0].Tag.ToString();
            parameters["groupName"] = tbGroupName.Text;
            parameters["layoutNo"] = lvwList.SelectedItems[0].Text;
            parameters["btnColor"] = tbColor.Text;


            if (mRequestPatch("posGoodsGroupSeq", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 그룹수정 완료.", "thepos");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = mSelectedPosGroupCode;
            parameters["groupCode"] = lvwList.SelectedItems[0].Tag.ToString();


            if (mRequestDelete("posGoodsGroupSeq", parameters))
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


            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["siteId"] = mSiteId;
                parameters["shopCode"] = mSelectedPosGroupCode;
                parameters["groupCode"] = lvwList.Items[i].Tag.ToString();

                parameters["layoutNo"] = lvwList.Items[i].Text;


                if (mRequestPatch("posGoodsGroupSeq", parameters))
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


            //
            //set_version_basic_db_change();


        }

        private void resort_listview_no()
        {
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                lvwList.Items[i].Text = (i + 1).ToString();
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
    }


}
