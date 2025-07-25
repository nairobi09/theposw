﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;
using static thepos.frmMain;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using theposw;


//? 포스별 설정 항목

/*

 * 
 * 컴포트 : 영수증프린터, 라벨프린터 
 * 클라이언트유형? : PC, 포스, 키오스크 -> 마우스포인터 표시여부
 * 

*/

namespace thepos
{
    public partial class frmSetupPos : Form
    {
        struct Setup
        {
            public String code;
            public String name;
            public String value;
            public String memo;
        }
        Setup[] listSetup = new Setup[15];


        bool isAdd = false;


        public frmSetupPos()
        {
            InitializeComponent();

            initialize_the();

            Setup setupItem = new Setup();

            setupItem.code = "PosType";               setupItem.name = "기기유형";          setupItem.value = "";   setupItem.memo = "";    listSetup[0] = setupItem;
            setupItem.code = "CustomerMonitor";       setupItem.name = "고객용모니터사용";  setupItem.value = "";   setupItem.memo = "";    listSetup[1] = setupItem;
            
            setupItem.code = "MobileExchangeType";    setupItem.name = "모바일 교환권";      setupItem.value = "";   setupItem.memo = "";    listSetup[2] = setupItem;
            setupItem.code = "PrintExchangeType";     setupItem.name = "인쇄 교환권";        setupItem.value = "";   setupItem.memo = "";    listSetup[3] = setupItem;
            
            setupItem.code = "BillPrinterPort";       setupItem.name = "영수증프린터 포트";  setupItem.value = "";   setupItem.memo = "";    listSetup[4] = setupItem;
            setupItem.code = "BillPrinterSpeed";      setupItem.name = "영수증프린터 속도";  setupItem.value = "";   setupItem.memo = "";    listSetup[5] = setupItem;

            setupItem.code = "TicketPrinterPort";     setupItem.name = "티켓전용프린터 포트";    setupItem.value = "";   setupItem.memo = "";    listSetup[6] = setupItem;
            setupItem.code = "TicketPrinterSpeed";    setupItem.name = "티켓전용프린터 속도";    setupItem.value = "";   setupItem.memo = "COM인 경우";    listSetup[7] = setupItem;

            setupItem.code = "VanTID";                setupItem.name = "결제밴 T-ID";       setupItem.value = "";   setupItem.memo = "미입력시 밴결제모듈내 입력된 T-ID로 설정됩니다.\r\nKovan의 경우 필수입력항목입니다.";    listSetup[8] = setupItem;

            setupItem.code = "CouponMID";            setupItem.name = "온라인쿠폰 가맹점번호(MID)"; setupItem.value = ""; setupItem.memo = ""; listSetup[9] = setupItem;

            // 고객화면 이미지
            setupItem.code = "SubMonitorImage";       setupItem.name = "고객화면 이미지"; setupItem.value = ""; setupItem.memo = "300*700 jpg"; listSetup[10] = setupItem;

            // 티켓출력물 추가 텍스트
            setupItem.code = "TicketAddText";         setupItem.name = "티켓출력물 추가텍스트"; setupItem.value = ""; setupItem.memo = ""; listSetup[11] = setupItem;

            // 영수증출력물 추가 텍스트
            setupItem.code = "BillAddText";         setupItem.name = "영수증출력물 추가텍스트"; setupItem.value = ""; setupItem.memo = ""; listSetup[12] = setupItem;

            // 로그레벨 
            setupItem.code = "AppLogLevel";         setupItem.name = "로그레벨"; setupItem.value = ""; setupItem.memo = ""; listSetup[13] = setupItem;

            // 로그레벨 
            setupItem.code = "PosBaseColor";        setupItem.name = "메뉴기본컬러"; setupItem.value = ""; setupItem.memo = ""; listSetup[14] = setupItem;


            reload_setup_pos();

            //
            thepos_app_log(1, this.Name, "open", "");
        }



        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);

            lvwList.SmallImageList = imgList;
            lvwList.HideSelection = true;

            lblSiteName.Text = mSiteAlias;
            lblPosNo.Text = myPosNo;

        }


        private void reload_setup_pos()
        {

            String sUrl = "setupPos?siteId=" + mSiteId + "&posNo=" + myPosNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["setupPos"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        for (int j = 0; j < listSetup.Length; j++)
                        {
                            if (listSetup[j].code == arr[i]["setupCode"].ToString())
                            {
                                listSetup[j].value = arr[i]["setupValue"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("설정정보 오류. setupPos\n\n " + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. setupPos\n\n" + mErrorMsg, "thepos");
                return;
            }
            


            lvwList.Items.Clear();
            for (int i = 0; i < listSetup.Length; i++)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = listSetup[i].name;
                lvItem.SubItems.Add(listSetup[i].value);
                lvItem.SubItems.Add("");
                lvItem.SubItems.Add(listSetup[i].memo);
                lvItem.SubItems.Add("");
                lvItem.Tag = listSetup[i].code;
                lvwList.Items.Add(lvItem);
            }

        }



        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) return;


            String code = lvwList.SelectedItems[0].Tag.ToString();

            lblName.Text = lvwList.SelectedItems[0].Text;
            lblValue.Text = lvwList.SelectedItems[0].SubItems[1].Text.ToString();
            lblMemo.Text = lvwList.SelectedItems[0].SubItems[3].Text.ToString();

            cbValue.Visible = false;
            tbValue.Visible = false;
            panelImage.Visible = false;
            panelMultiText.Visible = false;


            cbValue.SelectedIndex = -1;

            
            if (code == listSetup[0].code)  // PosType
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add("");
                cbValue.Items.Add("POS");
                cbValue.Items.Add("PC");
                cbValue.Items.Add("KIOSK");
            }
            else if (code == listSetup[1].code)  // CustomerMonitor
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add(" ");
                cbValue.Items.Add("Y");
                cbValue.Items.Add("N");
            }
            else if (code == listSetup[2].code)  // 모바일 교환권
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add(" ");  // 출력없음
                cbValue.Items.Add("알림톡");  // 알림톡
                cbValue.Items.Add("알림톡-선택");  // 알림톡
            }
            else if (code == listSetup[3].code)  // 인쇄 교환권
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add(" ");  // 출력없음
                cbValue.Items.Add("로컬프린터");  // 영수증프린터
            }
            else if (code == listSetup[4].code | code == listSetup[6].code) // 
            {
                cbValue.Visible = true;

                cbValue.Items.Clear ();
                cbValue.Items.Add(" ");
                cbValue.Items.Add("USB");
                foreach (string s in SerialPort.GetPortNames())
                {
                    cbValue.Items.Add(s);
                }
            }
            else if (code == listSetup[5].code | code == listSetup[7].code) // BillPrinterPort TicketPrinterPort ScannerPort
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add(" ");
                cbValue.Items.Add("9600");
                cbValue.Items.Add("19200");
                cbValue.Items.Add("38400");
                cbValue.Items.Add("57600");
                cbValue.Items.Add("115200");
            }
            else if (code == listSetup[8].code | code == listSetup[9].code | code == listSetup[14].code)  // t-id, MID, 기본컬러
            {
                tbValue.Visible = true;

            }
            else if (code == listSetup[10].code)
            {
                panelImage.Visible = true;

                if (lvwList.SelectedItems[0].SubItems[1].Text.ToString().Trim() != "")
                {
                    try
                    {
                        byte[] imgBytes = Convert.FromBase64String(lvwList.SelectedItems[0].SubItems[1].Text.ToString());

                        MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                        ms.Write(imgBytes, 0, imgBytes.Length);

                        pbImage.Image = System.Drawing.Image.FromStream(ms, true);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    pbImage.Image = null;
                }
            }
            else if (code == listSetup[11].code | code == listSetup[12].code)
            {
                panelMultiText.Visible = true;

                tbMultiValue.Text = lblValue.Text;

            }
            else if (code == listSetup[13].code)
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add("ALL");
                cbValue.Items.Add("IMPORTANT"); // 로그인 로그아웃 종료
                cbValue.Items.Add("ERROR");
                cbValue.Items.Add("NONE");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbValue.Visible)
            {
                lvwList.SelectedItems[0].SubItems[2].Text = cbValue.Text;
                lvwList.SelectedItems[0].SubItems[4].Text = "변경";
            }
            else if (tbMultiValue.Visible)
            {
                lvwList.SelectedItems[0].SubItems[2].Text = tbMultiValue.Text;
                lvwList.SelectedItems[0].SubItems[4].Text = "변경";
            }
            else
            {
                lvwList.SelectedItems[0].SubItems[2].Text = tbValue.Text;
                lvwList.SelectedItems[0].SubItems[4].Text = "변경";
            }
                
            isAdd = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAdd == false) return;

            //
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                if (lvwList.Items[i].SubItems[4].Text == "변경")
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();

                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = myPosNo;
                    parameters["setupCode"] = lvwList.Items[i].Tag.ToString();
                    parameters["setupName"] = lvwList.Items[i].Text;

                    // 변경값
                    parameters["setupValue"] = lvwList.Items[i].SubItems[2].Text;

                    parameters["memo"] = "";

                    if (mRequestPost("setupPos", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {

                        }
                        else
                        {
                            MessageBox.Show("포스정보 오류. setupPos\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. setupPos\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }
            }

            //
            MessageBox.Show("포스정보 저장완료.", "thepos");

            


            isAdd = false;


            reload_setup_pos();


            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                if (lvwList.Items[i].Tag.ToString() == "PosType") mPosType = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "CustomerMonitor") mCustomerMonitor = lvwList.Items[i].SubItems[1].Text;

                else if (lvwList.Items[i].Tag.ToString() == "MobileExchangeType") mMobileExchangeType = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "PrintExchangeType") mPrintExchangeType = lvwList.Items[i].SubItems[1].Text;

                else if (lvwList.Items[i].Tag.ToString() == "BillPrinterPort") mBillPrinterPort = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "BillPrinterSpeed") mBillPrinterSpeed = lvwList.Items[i].SubItems[1].Text;
                
                else if (lvwList.Items[i].Tag.ToString() == "TicketPrinterPort") mTicketPrinterPort = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "TicketPrinterSpeed") mTicketPrinterSpeed = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "VanTID") mVanTID = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "CouponMID") mCouponMID = lvwList.Items[i].SubItems[1].Text;

                else if (lvwList.Items[i].Tag.ToString() == "SubMonitorImage") mSubMonitorImage = lvwList.Items[i].SubItems[1].Text;

                else if (lvwList.Items[i].Tag.ToString() == "TicketAddText") mTicketAddText = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "BillAddText") mBillAddText = lvwList.Items[i].SubItems[1].Text;

                else if (lvwList.Items[i].Tag.ToString() == "AppLogLevel")
                {
                    //  mLogLevel -  1: ALL  2: ERROR  3: NONE
                    String t_level = lvwList.Items[i].SubItems[1].Text;

                    if (t_level == "ALL") mAppLogLevel = 1;
                    else if (t_level == "IMPORTANT") mAppLogLevel = 2;
                    else if (t_level == "ERROR") mAppLogLevel = 3;
                    else if (t_level == "NONE") mAppLogLevel = 4;
                    else mAppLogLevel = 4;
                }
                else if (lvwList.Items[i].Tag.ToString() == "PosBaseColor") mTheposColor = lvwList.Items[i].SubItems[1].Text;
            }


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            reload_setup_pos();
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                string fileFullName = openFileDialog.FileName;

                System.Drawing.Image image = System.Drawing.Image.FromFile(fileFullName);
                this.pbImage.Image = image;


                if (pbImage.Image == null)
                {
                    tbValue.Text = "";
                }
                else
                {
                    var ms = new MemoryStream();
                    pbImage.Image.Save(ms, pbImage.Image.RawFormat);
                    tbValue.Text = Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.pbImage.Image = null;
            tbValue.Text = "";
        }

        private void frmSetupPos_FormClosed(object sender, FormClosedEventArgs e)
        {
            thepos_app_log(1, this.Name, "close", "");
        }

    }
}
