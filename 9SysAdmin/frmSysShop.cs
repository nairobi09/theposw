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
    public partial class frmSysShop : Form
    {

        String[] mPrinterTypeCode = new string[3];
        String[] mPrinterTypeName = new string[3];

        string selected_shop_code = "";
        string selected_nod_code1 = "";
        string selected_nod_code2 = "";


        public frmSysShop()
        {
            InitializeComponent();

            initialize_the();

            reload_shop();
        }


        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 24);

            lvwShop.SmallImageList = imgList;
            lvwShop.HideSelection = true;

            mPrinterTypeCode[0] = "";
            mPrinterTypeCode[1] = "N";
            mPrinterTypeCode[2] = "L";

            mPrinterTypeName[0] = "";
            mPrinterTypeName[1] = "업장 네트워크프린터";
            mPrinterTypeName[2] = "로걸 영수증프린터";


            cbPrinterType.Items.Clear();
            for (int i = 0; i < mPrinterTypeCode.Length; i++) 
            {
                cbPrinterType.Items.Add(mPrinterTypeName[i]);
            }

            cbPrinterType.SelectedIndex = 0;

        }


        private void reload_shop()
        {
            lvwShop.Items.Clear();

            tbShopCode.Text = "";
            tbShopName.Text = "";
            cbPrinterType.SelectedIndex = 0;
            tbNetworkPrinterName.Text = "";

            String sUrl = "shop?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["shops"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["shopCode"].ToString();
                        lvItem.SubItems.Add(arr[i]["shopName"].ToString());
                        lvItem.SubItems.Add(arr[i]["printerType"].ToString());
                        lvItem.SubItems.Add(get_printer_type_name(arr[i]["printerType"].ToString()));
                        lvItem.SubItems.Add(arr[i]["networkPrinterName"].ToString());

                        lvwShop.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("샵정보 오류. shop\n\n " + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            lvwNod1.Items.Clear();
            tbNodCode1.Text = "";
            tbNodName1.Text = "";

            lvwNod2.Items.Clear();
            tbNodCode2.Text = "";
            tbNodName2.Text = "";

        }

        private void reload_nod1()
        {
            lvwNod1.Items.Clear();
            tbNodCode1.Text = "";
            tbNodName1.Text = "";

            lvwNod2.Items.Clear();
            tbNodCode2.Text = "";
            tbNodName2.Text = "";


            String sUrl = "nod1?siteId=" + mSiteId + "&shopCode=" + selected_shop_code;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["nod1s"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["nodCode1"].ToString();
                        lvItem.SubItems.Add(arr[i]["nodName1"].ToString());
                        lvwNod1.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("분류1 정보 오류. shop\n\n " + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. nod1\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

        private void reload_nod2()
        {
            lvwNod2.Items.Clear();
            tbNodCode2.Text = "";
            tbNodName2.Text = "";

            String sUrl = "nod2?siteId=" + mSiteId + "&shopCode=" + selected_shop_code + "&nodCode1=" + selected_nod_code1;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["nod2s"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["nodCode2"].ToString();
                        lvItem.SubItems.Add(arr[i]["nodName2"].ToString());
                        lvwNod2.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("분류2 정보 오류. shop\n\n " + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. nod1\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

        //
        private void lvwShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwShop.SelectedItems.Count == 0) { return; }

            selected_shop_code = lvwShop.SelectedItems[0].SubItems[lvwShop.Columns.IndexOf(shop_code)].Text;
            selected_nod_code1 = "";
            selected_nod_code2 = "";

            tbShopCode.Text = lvwShop.SelectedItems[0].SubItems[lvwShop.Columns.IndexOf(shop_code)].Text;
            tbShopName.Text = lvwShop.SelectedItems[0].SubItems[lvwShop.Columns.IndexOf(shop_name)].Text;


            String code = lvwShop.SelectedItems[0].SubItems[lvwShop.Columns.IndexOf(printer_type_code)].Text;

            for (int i = 0; i < cbPrinterType.Items.Count; i++)
            {
                if (code == mPrinterTypeCode[i])
                {
                    cbPrinterType.SelectedIndex = i;
                }
            }

            tbNetworkPrinterName.Text = lvwShop.SelectedItems[0].SubItems[lvwShop.Columns.IndexOf(network_printer_name)].Text;

            //
            reload_nod1();
        }

        private void btnShopAdd_Click(object sender, EventArgs e)
        {
            if (tbShopCode.Text.Trim().Length != 2)
            {
                MessageBox.Show("업장코드 오류.", "thepos");
                return;
            }

            if (tbShopName.Text.Trim().Length < 1)
            {
                MessageBox.Show("업장명 오류.", "thepos");
                return;
            }

            if (cbPrinterType.SelectedIndex < 0)
            {
                MessageBox.Show("주문서출력 오류.", "thepos");
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = tbShopCode.Text.Trim();
            parameters["shopName"] = tbShopName.Text.Trim();
            parameters["printerType"] = mPrinterTypeCode[cbPrinterType.SelectedIndex];
            parameters["networkPrinterName"] = tbNetworkPrinterName.Text;


            if (mRequestPost("shop", parameters))  //? Add시 2개필들 누락되는것같음. 서버쪽 확인필요
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 등록 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("업장정보 오류. shop\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_shop();
        }

        private void btnShopUpdate_Click(object sender, EventArgs e)
        {
            if (lvwShop.SelectedItems.Count == 0) { return; }

            if (tbShopCode.Text.Trim().Length != 2)
            {
                MessageBox.Show("업장코드 오류.", "thepos");
                return;
            }

            if (tbShopName.Text.Trim().Length < 1)
            {
                MessageBox.Show("업장명 오류.", "thepos");
                return;
            }

            if (cbPrinterType.SelectedIndex < 0)
            {
                MessageBox.Show("주문서출력 오류.", "thepos");
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = tbShopCode.Text.Trim();
            parameters["shopName"] = tbShopName.Text.Trim();
            parameters["printerType"] = mPrinterTypeCode[cbPrinterType.SelectedIndex];
            parameters["networkPrinterName"] = tbNetworkPrinterName.Text;

            if (mRequestPatch("shop", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 수정 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류. shop\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_shop();
        }

        private void btnShopDelete_Click(object sender, EventArgs e)
        {
            if (lvwShop.SelectedItems.Count == 0) { return; }


            if (lvwNod1.Items.Count > 0) 
            {
                MessageBox.Show("하위항목이 있는 경우 삭제할 수 없습니다.", "thepos");
                return; 
            }



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = tbShopCode.Text.Trim();


            if (mRequestDelete("shop", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 삭제 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("업장정보 오류. shop\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_shop();

            tbShopCode.Text = "";
            tbShopName.Text = "";

        }

        String get_printer_type_name(String code)
        {
            for (int i = 0; i < mPrinterTypeCode.Length; i++)
            {
                if (mPrinterTypeCode[i] == code)
                {
                    return mPrinterTypeName[i];
                }
            }

            return code;
        }


        //
        private void lvwNod1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwNod1.SelectedItems.Count == 0) { return; }

            selected_nod_code1 = lvwNod1.SelectedItems[0].SubItems[lvwNod1.Columns.IndexOf(nod_code1)].Text;
            selected_nod_code2 = "";

            tbNodCode1.Text = lvwNod1.SelectedItems[0].SubItems[lvwNod1.Columns.IndexOf(nod_code1)].Text;
            tbNodName1.Text = lvwNod1.SelectedItems[0].SubItems[lvwNod1.Columns.IndexOf(nod_name1)].Text;

            //
            reload_nod2();
        }

        private void btnNod1Add_Click(object sender, EventArgs e)
        {
            if (tbNodCode1.Text.Trim().Length != 2)
            {
                MessageBox.Show("분류1코드 오류.", "thepos");
                return;
            }

            if (tbNodName1.Text.Trim().Length < 1)
            {
                MessageBox.Show("분류1명 오류.", "thepos");
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = selected_shop_code;
            parameters["nodCode1"] = tbNodCode1.Text.Trim();
            parameters["nodName1"] = tbNodName1.Text.Trim();

            if (mRequestPost("nod1", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 등록 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("분류1 정보 오류. nod1\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. nod1\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_nod1();

        }

        private void btnNod1Update_Click(object sender, EventArgs e)
        {
            if (lvwNod1.SelectedItems.Count == 0) { return; }

            if (tbNodCode1.Text.Trim().Length != 2)
            {
                MessageBox.Show("분류1코드 오류.", "thepos");
                return;
            }

            if (tbNodName1.Text.Trim().Length < 1)
            {
                MessageBox.Show("분류1명 오류.", "thepos");
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = selected_shop_code;
            parameters["nodCode1"] = selected_nod_code1;
            parameters["nodName1"] = tbNodName1.Text.Trim();

            if (mRequestPatch("nod1", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 수정 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류. nod1\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. nod1\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_nod1();
        }

        private void btnNod1Delete_Click(object sender, EventArgs e)
        {
            if (lvwNod1.SelectedItems.Count == 0) { return; }


            if (lvwNod2.Items.Count > 0)
            {
                MessageBox.Show("하위항목이 있는 경우 삭제할 수 없습니다.", "thepos");
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = selected_shop_code;
            parameters["nodCode1"] = selected_nod_code1;

            if (mRequestDelete("nod1", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 삭제 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("분류1정보 오류. nod1\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. nod1\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_nod1();
            tbNodCode1.Text = "";
            tbNodName1.Text = "";
        }


        //
        private void lvwNod2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwNod2.SelectedItems.Count == 0) { return; }


            selected_nod_code2 = lvwNod2.SelectedItems[0].SubItems[lvwNod2.Columns.IndexOf(nod_code2)].Text;

            tbNodCode2.Text = lvwNod2.SelectedItems[0].SubItems[lvwNod2.Columns.IndexOf(nod_code2)].Text;
            tbNodName2.Text = lvwNod2.SelectedItems[0].SubItems[lvwNod2.Columns.IndexOf(nod_name2)].Text;
        }

        private void btnNod2Add_Click(object sender, EventArgs e)
        {
            if (tbNodCode2.Text.Trim().Length != 2)
            {
                MessageBox.Show("분류2코드 오류.", "thepos");
                return;
            }

            if (tbNodName2.Text.Trim().Length < 1)
            {
                MessageBox.Show("분류2명 오류.", "thepos");
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = selected_shop_code;
            parameters["nodCode1"] = selected_nod_code1;
            parameters["nodCode2"] = tbNodCode2.Text.Trim();
            parameters["nodName2"] = tbNodName2.Text.Trim();

            if (mRequestPost("nod2", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 등록 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("분류2 정보 오류. nod1\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. nod1\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            reload_nod2();
        }

        private void btnNod2Update_Click(object sender, EventArgs e)
        {
            if (lvwNod2.SelectedItems.Count == 0) { return; }

            if (tbNodCode2.Text.Trim().Length != 2)
            {
                MessageBox.Show("분류2코드 오류.", "thepos");
                return;
            }

            if (tbNodName2.Text.Trim().Length < 1)
            {
                MessageBox.Show("분류2명 오류.", "thepos");
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = selected_shop_code;
            parameters["nodCode1"] = selected_nod_code1;
            parameters["nodCode2"] = selected_nod_code2;
            parameters["nodName2"] = tbNodName2.Text.Trim();

            if (mRequestPatch("nod2", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 수정 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류. nod2\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. nod2\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_nod2();
        }

        private void btnNod2Delete_Click(object sender, EventArgs e)
        {
            if (lvwNod2.SelectedItems.Count == 0) { return; }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = selected_shop_code;
            parameters["nodCode1"] = selected_nod_code1;
            parameters["nodCode2"] = selected_nod_code2;

            if (mRequestDelete("nod2", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 삭제 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("분류2정보 오류. nod1\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. nod2\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_nod2();
            tbNodCode2.Text = "";
            tbNodName2.Text = "";
        }

    }
}
