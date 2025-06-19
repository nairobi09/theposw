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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static thepos.thePos;



namespace thepos._1Sales
{
    public partial class frmSysFlowConsole : Form
    {
        String mSelectedPosNo = "";




        public frmSysFlowConsole()
        {
            InitializeComponent();

            initialize_the();
        }


        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 24);

            lvwConsole.SmallImageList = imgList;
            lvwConsole.HideSelection = true;

            lvwConsoleLink.SmallImageList = imgList;
            lvwConsoleLink.HideSelection = true;


            for (int i = 0; i < mPosNoList.Count; i++)
            {
                comboPosNo.Items.Add(mPosNoList[i]);
            }

        }


        private void btnView_Click(object sender, EventArgs e)
        {

            mSelectedPosNo = comboPosNo.SelectedItem.ToString();

            reload_server();

            display_all_console();



        }


        private void reload_server()
        {
            lvwConsoleLink.Items.Clear();

            tbLocateX.Text = "";
            tbLocateY.Text = "";
            tbSizeX.Text = "";
            tbSizeY.Text = "";

            tableLayoutPanelFlowControlSelected.Controls.Clear();




            String sUrl = "flowConsole?siteId=" + mSiteId + "&posNo=" + mSelectedPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["flowConsoles"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["buttonName"].ToString();
                        lvItem.SubItems.Add(arr[i]["locateX"].ToString());
                        lvItem.SubItems.Add(arr[i]["locateY"].ToString());
                        lvItem.SubItems.Add(arr[i]["sizeX"].ToString());
                        lvItem.SubItems.Add(arr[i]["sizeY"].ToString());
                        lvItem.Tag = arr[i]["buttonCode"].ToString();

                        lvwConsoleLink.Items.Add(lvItem);

                    }
                }
                else
                {
                    MessageBox.Show("정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
            tableLayoutPanelFlowControl.Controls.Clear();

            for (int i = 0; i < lvwConsoleLink.Items.Count; i++)
            {
                try
                {
                    Button btnItem = new Button();
                    btnItem.FlatStyle = FlatStyle.Flat;
                    btnItem.ForeColor = Color.White;
                    btnItem.BackColor = Color.Gray;
                    btnItem.TabStop = false;
                    btnItem.Margin = new Padding(2, 2, 2, 2);
                    btnItem.Padding = new Padding(0, 0, 0, 0);

                    String button_name = "";
                    if (lvwConsoleLink.Items[i].Tag.ToString() == "ALLIM") { button_name = "알림"; }
                    if (lvwConsoleLink.Items[i].Tag.ToString() == "COUPON") { button_name = "쿠폰"; }
                    if (lvwConsoleLink.Items[i].Tag.ToString() == "CHARGING") { button_name = "충전"; }
                    if (lvwConsoleLink.Items[i].Tag.ToString() == "SETTLEMENT") { button_name = "정산"; }
                    if (lvwConsoleLink.Items[i].Tag.ToString() == "TICKET") { button_name = "티켓"; }
                    if (lvwConsoleLink.Items[i].Tag.ToString() == "TICKETEXIT") { button_name = "빠른퇴장"; }
                    if (lvwConsoleLink.Items[i].Tag.ToString() == "LOCKER") { button_name = "락커"; }
                    if (lvwConsoleLink.Items[i].Tag.ToString() == "PAYMANAGER") { button_name = "결제내역관리"; }

                    btnItem.Text = button_name;

                    btnItem.Dock = DockStyle.Fill;

                    int loc_x = convert_number(lvwConsoleLink.Items[i].SubItems[lvwConsoleLink.Columns.IndexOf(locX)].Text);
                    int loc_y = convert_number(lvwConsoleLink.Items[i].SubItems[lvwConsoleLink.Columns.IndexOf(locY)].Text);
                    int sz_x = convert_number(lvwConsoleLink.Items[i].SubItems[lvwConsoleLink.Columns.IndexOf(szX)].Text);
                    int sz_y = convert_number(lvwConsoleLink.Items[i].SubItems[lvwConsoleLink.Columns.IndexOf(szY)].Text);

                    if (sz_x == 1) { btnItem.Font = new Font(btnItem.Font.FontFamily, 9); }
                    else if (sz_x >= 3 & sz_y >= 2) { btnItem.Font = new Font(btnItem.Font.FontFamily, 20); ; }
                    else { btnItem.Font = new Font(btnItem.Font.FontFamily, 14); }

                    tableLayoutPanelFlowControl.Controls.Add(btnItem, loc_x, loc_y);
                    tableLayoutPanelFlowControl.SetColumnSpan(btnItem, sz_x);
                    tableLayoutPanelFlowControl.SetRowSpan(btnItem, sz_y);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류. display all console()\n\n" + ex.Message, "thepos");
                    return;
                }

            }

        }

        private void lvwConsoleLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwConsoleLink.SelectedItems.Count == 0)
            {
                tbLocateX.Text = "";
                tbLocateY.Text = "";
                tbSizeX.Text = "";
                tbSizeY.Text = "";

                tableLayoutPanelFlowControlSelected.Controls.Clear();
            }
            else
            {
                tbLocateX.Text = lvwConsoleLink.SelectedItems[0].SubItems[lvwConsoleLink.Columns.IndexOf(locX)].Text;
                tbLocateY.Text = lvwConsoleLink.SelectedItems[0].SubItems[lvwConsoleLink.Columns.IndexOf(locY)].Text;
                tbSizeX.Text = lvwConsoleLink.SelectedItems[0].SubItems[lvwConsoleLink.Columns.IndexOf(szX)].Text;
                tbSizeY.Text = lvwConsoleLink.SelectedItems[0].SubItems[lvwConsoleLink.Columns.IndexOf(szY)].Text;

                display_selected_console();
            }
        }


        private void display_selected_console()
        {
            tableLayoutPanelFlowControlSelected.Controls.Clear();

            try
            {
                int locX = convert_number(tbLocateX.Text);
                int locY = convert_number(tbLocateY.Text);
                int szX = convert_number(tbSizeX.Text);
                int szY = convert_number(tbSizeY.Text);

                Button btnGroupBlue = new Button();

                btnGroupBlue.FlatStyle = FlatStyle.Flat;
                btnGroupBlue.ForeColor = Color.White;
                btnGroupBlue.BackColor = Color.FromArgb(68, 87, 96);
                btnGroupBlue.TabStop = false;
                btnGroupBlue.Margin = new Padding(2, 2, 2, 2);
                btnGroupBlue.Padding = new Padding(0, 0, 0, 0);


                String button_name = "";
                if (lvwConsoleLink.SelectedItems[0].Tag.ToString() == "ALLIM") { button_name = "알림"; }
                if (lvwConsoleLink.SelectedItems[0].Tag.ToString() == "COUPON") { button_name = "쿠폰"; }
                if (lvwConsoleLink.SelectedItems[0].Tag.ToString() == "CHARGING") { button_name = "충전"; }
                if (lvwConsoleLink.SelectedItems[0].Tag.ToString() == "SETTLEMENT") { button_name = "정산"; }
                if (lvwConsoleLink.SelectedItems[0].Tag.ToString() == "TICKET") { button_name = "티켓"; }
                if (lvwConsoleLink.SelectedItems[0].Tag.ToString() == "TICKETEXIT") { button_name = "빠른퇴장"; }
                if (lvwConsoleLink.SelectedItems[0].Tag.ToString() == "LOCKER") { button_name = "락커"; }
                if (lvwConsoleLink.SelectedItems[0].Tag.ToString() == "CAGE") { button_name = "케이지"; }
                if (lvwConsoleLink.SelectedItems[0].Tag.ToString() == "PAYMANAGER") { button_name = "결제내역관리"; }

                btnGroupBlue.Text = button_name;

                btnGroupBlue.Dock = DockStyle.Fill;

                if (szX == 1) { btnGroupBlue.Font = new Font(btnGroupBlue.Font.FontFamily, 9); }
                else if (szX >= 3 & szY >= 2) { btnGroupBlue.Font = new Font(btnGroupBlue.Font.FontFamily, 20); }
                else { btnGroupBlue.Font = new Font(btnGroupBlue.Font.FontFamily, 14); }


                tableLayoutPanelFlowControlSelected.Controls.Add(btnGroupBlue, locX, locY);
                tableLayoutPanelFlowControlSelected.SetColumnSpan(btnGroupBlue, szX);
                tableLayoutPanelFlowControlSelected.SetRowSpan(btnGroupBlue, szY);
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류. display selected console()\n\n" + ex.Message, "thepos");
                return;
            }

        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            if (lvwConsole.SelectedItems.Count == 0) { return; }


            if (mSelectedPosNo == "")
            {
                MessageBox.Show("포스 조회 해주세요.", "thepos");
                return;
            }


            for (int i = 0; i < lvwConsoleLink.Items.Count; i++)
            {
                if (lvwConsole.SelectedItems[0].Tag.ToString() == lvwConsoleLink.Items[i].Tag.ToString())
                {
                    MessageBox.Show("이미 등록된 항목입니다.", "thepos");
                    return;
                }
            }


            String mSelectedGoodsCode = lvwConsole.SelectedItems[0].Tag.ToString();


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["buttonName"] = lvwConsole.SelectedItems[0].Text;
            parameters["buttonCode"] = lvwConsole.SelectedItems[0].Tag.ToString();
            parameters["locateX"] = "1";
            parameters["locateY"] = "5";
            parameters["sizeX"] = "1";
            parameters["sizeY"] = "1";


            if (mRequestPost("flowConsole", parameters))
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
            for (int i = 0; i < lvwConsoleLink.Items.Count; i++)
            {
                if (lvwConsoleLink.Items[i].Tag.ToString() == mSelectedGoodsCode)
                {
                    lvwConsoleLink.Items[i].Selected = true; //
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
            if (tNum > 1) { MessageBox.Show("LocX 오류.", "thepos"); return false; }
            locX = tNum;

            if (!get_number(tbLocateY.Text, ref tNum)) { MessageBox.Show("LocY 오류.", "thepos"); return false; }
            if (tNum > 5) { MessageBox.Show("LocY 오류.", "thepos"); return false; }
            locY = tNum;

            if (!get_number(tbSizeX.Text, ref tNum)) { MessageBox.Show("SizeX 오류.", "thepos"); return false; }
            if (tNum > 2) { MessageBox.Show("SizeX 오류.", "thepos"); return false; }
            szX = tNum;

            if (!get_number(tbSizeY.Text, ref tNum)) { MessageBox.Show("SizeY 오류.", "thepos"); return false; }
            if (tNum > 6) { MessageBox.Show("SizeY 오류.", "thepos"); return false; }
            szY = tNum;


            if (locX + szX > 2) { MessageBox.Show("X범위 오류.", "thepos"); return false; }
            if (locY + szY > 6) { MessageBox.Show("Y범위 오류.", "thepos"); return false; }

            return true;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwConsoleLink.SelectedItems.Count == 0) { return; }

            if (MessageBox.Show("선택 항목정보를 삭제합니다.", "thwpos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
            else
            {
                return;
            }



            String mSelectedbuttonCode = lvwConsoleLink.SelectedItems[0].Tag.ToString();



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["buttonCode"] = mSelectedbuttonCode;


            if (mRequestDelete("flowConsole", parameters))
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwConsoleLink.SelectedItems.Count == 0) { return; }


            if (!check_data())
            {
                return;
            }



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["buttonCode"] = lvwConsoleLink.SelectedItems[0].Tag.ToString();
            parameters["locateX"] = tbLocateX.Text;
            parameters["locateY"] = tbLocateY.Text;
            parameters["sizeX"] = tbSizeX.Text;
            parameters["sizeY"] = tbSizeY.Text;


            if (mRequestPatch("flowConsole", parameters))
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


    }
}
