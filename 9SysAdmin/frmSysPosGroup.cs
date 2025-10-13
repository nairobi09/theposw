using Newtonsoft.Json.Linq;
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

namespace thepos._9SysAdmin
{
    public partial class frmSysPosGroup : Form
    {


        string selected_shop_code = "";


        public frmSysPosGroup()
        {
            InitializeComponent();

            initialize_the();

            reload_pos_group();
        }


        private void initialize_the()
        {


        }


        private void reload_pos_group()
        {
            lvwPosGroup.Items.Clear();

            tbPosGroupCode.Text = "";
            tbPosGroupName.Text = "";

            String sUrl = "posGroup?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["posGroups"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["posGroupCode"].ToString();
                        lvItem.SubItems.Add(arr[i]["posGroupName"].ToString());

                        lvwPosGroup.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("포스그룹정보 오류. posGroup\n\n " + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. posGroup\n\n" + mErrorMsg, "thepos");
                return;
            }


        }


        //
        private void lvwPosGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPosGroup.SelectedItems.Count == 0) { return; }

            selected_shop_code = lvwPosGroup.SelectedItems[0].SubItems[lvwPosGroup.Columns.IndexOf(pos_group_code)].Text;


            tbPosGroupCode.Text = lvwPosGroup.SelectedItems[0].SubItems[lvwPosGroup.Columns.IndexOf(pos_group_code)].Text;
            tbPosGroupName.Text = lvwPosGroup.SelectedItems[0].SubItems[lvwPosGroup.Columns.IndexOf(pos_group_name)].Text;

        }

        private void btnPosGroupAdd_Click(object sender, EventArgs e)
        {
            if (tbPosGroupCode.Text.Trim().Length != 2)
            {
                MessageBox.Show("업장코드 오류.", "thepos");
                return;
            }

            if (tbPosGroupName.Text.Trim().Length < 1)
            {
                MessageBox.Show("업장명 오류.", "thepos");
                return;
            }




            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posGroupCode"] = tbPosGroupCode.Text.Trim();
            parameters["posGroupName"] = tbPosGroupName.Text.Trim();



            if (mRequestPost("posGroup", parameters))  //? Add시 2개필들 누락되는것같음. 서버쪽 확인필요
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 등록 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("포스그룹정보 오류. PosGroup\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. PosGroup\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_pos_group();
        }

        private void btnPosGroupUpdate_Click(object sender, EventArgs e)
        {
            if (lvwPosGroup.SelectedItems.Count == 0) { return; }

            if (tbPosGroupCode.Text.Trim().Length != 2)
            {
                MessageBox.Show("업장코드 오류.", "thepos");
                return;
            }

            if (tbPosGroupName.Text.Trim().Length < 1)
            {
                MessageBox.Show("업장명 오류.", "thepos");
                return;
            }



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posGroupCode"] = tbPosGroupCode.Text.Trim();
            parameters["posGroupName"] = tbPosGroupName.Text.Trim();


            if (mRequestPatch("posGroup", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 수정 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류. posGroup\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. posGroup\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_pos_group();
        }

        private void btnPosGroupDelete_Click(object sender, EventArgs e)
        {
            if (lvwPosGroup.SelectedItems.Count == 0) { return; }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posGroupCode"] = tbPosGroupCode.Text.Trim();


            if (mRequestDelete("posGroup", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 삭제 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("정보 오류. posGroup\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. posGroup\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_pos_group();

            tbPosGroupCode.Text = "";
            tbPosGroupName.Text = "";

        }


    }
}
