using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using System.Net.Sockets;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Management;
using System.Collections;
using System.Drawing.Imaging;
using System.Threading;
using static thepos.ClsWin32Api;
using System.Diagnostics.Eventing.Reader;

namespace thepos
{
    public partial class frmMain : Form
    {
        public static Panel mPanelDivision;
        TextBox mTbKeyDisplayController;  // 공용컨트롤러

        String sysadmin_pw_patern = "";

        Thread threadSyncLink;

        bool mServerStatus = false;

        bool mNetworkState = false;
        bool mPrevNetworkState = false;

        bool isRunThread = true;


        public frmMain()
        {
            Screen[] scr = Screen.AllScreens;
            this.Location = scr[0].Bounds.Location;

            InitializeComponent();

            initialize_the();


#if DEBUG
            mBaseUri = uri_test;
#else
    mBaseUri = uri_real;
#endif


            //
            thepos_app_log(2, "theposw1", "start.....", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);

        }



        private void initialize_the()
        {

            mLblTheModeStatus = lblServerStatusTitle;

            mLblTheModeStatus.Visible = false;

            mPanelDivision = panelDivision;

            mPanelDivision.Width = 1024;
            mPanelDivision.Height = 768;
            mPanelDivision.Visible = false;


            clear_login_init();


            lblSiteAlias.Text = mSiteAlias;
            lblSiteName.Text = mSiteName;
            lblPosNo.Text = myPosNo;
            lblUserName.Text = mUserName;


            btnKey1.Click += (sender, args) => ClickedKey("1");
            btnKey2.Click += (sender, args) => ClickedKey("2");
            btnKey3.Click += (sender, args) => ClickedKey("3");
            btnKey4.Click += (sender, args) => ClickedKey("4");
            btnKey5.Click += (sender, args) => ClickedKey("5");
            btnKey6.Click += (sender, args) => ClickedKey("6");
            btnKey7.Click += (sender, args) => ClickedKey("7");
            btnKey8.Click += (sender, args) => ClickedKey("8");
            btnKey9.Click += (sender, args) => ClickedKey("9");
            btnKey0.Click += (sender, args) => ClickedKey("0");
            btnKeyBS.Click += (sender, args) => ClickedKey("BS");
            btnKeyClear.Click += (sender, args) => ClickedKey("Clear");



            //
            mTbKeyDisplayController = tbID;
            


            try
            {
                // 기동시 MAC값 구하기 및 보관
                var nics = NetworkInterface.GetAllNetworkInterfaces();
                var selectedNic = nics.First();
                mMacAddr = selectedNic.GetPhysicalAddress().ToString();
            }
            catch
            {
                MessageBox.Show("MAC초기화 오류...", "thepos");
                return;
            }



            // Session key 로그인관련 
            handler.CookieContainer = cookies;
            mHttpClient = new HttpClient(handler);

            //
            mBadges[0].badges_id = "";
            mBadges[1].badges_id = "new";
            mBadges[2].badges_id = "best";
            mBadges[3].badges_id = "pick";

            mBadges[0].badges_name = "";
            mBadges[1].badges_name = "NEW";
            mBadges[2].badges_name = "BEST";
            mBadges[3].badges_name = "사장픽";


        }

        private void frmMain_Shown(object sender, EventArgs e)
        {

            mNetworkState = NetworkInterface.GetIsNetworkAvailable();


            // 네트워크 상태 : 정상이미지를 보이기/숨기기
            pbNetworkConn.Visible = mNetworkState;
            pbNetworkDisconn.Visible = !mNetworkState;

            //
            tbID.Focus();

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //

        }


        private void SyncLink()
        {
            int loop_cnt = 0;
            int check_cnt = 0;

            while (isRunThread)
            {
                //
                Thread.Sleep(1000); // 1초

                loop_cnt++;


                if (loop_cnt >= 10)  // 10초
                {
                    check_cnt++;

                    mNetworkState = NetworkInterface.GetIsNetworkAvailable();

                    if (mPrevNetworkState != mNetworkState)
                    {
                        // 네트워크 상태 : 정상이미지를 보이기/숨기기
                        pbNetworkConn.BeginInvoke(new Action(() => pbNetworkConn.Visible = mNetworkState));
                        pbNetworkDisconn.BeginInvoke(new Action(() => pbNetworkDisconn.Visible = !pbNetworkConn.Visible));
                        mPrevNetworkState = mNetworkState;
                    }

                    if ((mNetworkState != mServerStatus) | (check_cnt >= 6 * 10))  // 10분
                    {
                        // 서버 테스트콜
                        mServerStatus = check_server_status();
                        lblServerStatusTitle.BeginInvoke(new Action(() => lblServerStatusTitle.Visible = !mServerStatus));
                        check_cnt = 0;
                    }

                    loop_cnt = 0;
                }
            }
        }


        private void start_sub_screen()
        {
            Screen[] scr = Screen.AllScreens;

            if (scr.Length > 1)
            {
                fSub = new frmSub();
                fSub.Location = scr[1].Bounds.Location; // 두번째 스크린에 뛰움
                fSub.Show();
            }
        }


        private void clear_login_init()
        {
            mSiteAlias = "";
            mSiteName = "";
            myPosNo = "";
            mUserName = "";

            mSiteId = "";
            mSiteName = "";         // 매장명
            mSiteAlias = "";        // 매장명
            mCapName = "";          // 대표자명
            mRegistNo = "";         // 사업자번호
            mBizAddr = "";          // 주소
            mBizTelNo = "";         // 대표전화

            mTicketType = "";  // ""미사용, "IN"입장전용, "PA"선불, "PD"후불
            mTicketMedia = "";  // 띠지BC   팔찌RF
            mVanCode = "";
            mCallCenterNo = "";

            mCornerType = "";  // 주문서 관리 - ""미사용, "E"단순일체형, "P"분리형

            mBizDate = "";

            mUserID = "";
            mUserName = "";

            lblSiteAlias.Text = "";
            lblSiteName.Text = "";
            lblPosNo.Text = "";
            lblUserName.Text = "";


            mPosLayoutType = "";  // S: 순차방식,  M: 좌표방식
        }


        private void ClickedKey(string sKey)
        {
            if (sKey == "BS")
            {
                if (mTbKeyDisplayController.Text.Length > 0)
                {
                    mTbKeyDisplayController.Text = mTbKeyDisplayController.Text.Substring(0, mTbKeyDisplayController.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                mTbKeyDisplayController.Text = "";
            }
            else
            {
                mTbKeyDisplayController.Text += sKey;
            }
        }


        private void btnKeyLogin_Click(object sender, EventArgs e)
        {

            mIsDevLogin = "";


            // 설치후 최초실행
            if (server_login())
            {
            }
            else
            {
                return;
            }

            // 영업일
            if (get_biz_date())
            {

            }
            else
            {
                return;
            }


            //
            ready_thepos();






            // SyncLink 쓰레드
            isRunThread = true;

            threadSyncLink = new Thread(SyncLink);
            threadSyncLink.Start();


            // 쿠폰인증용
            mHttpClientCoupon = new HttpClient();
            mHttpClientCoupon.DefaultRequestHeaders.TryAddWithoutValidation("authorization", mCouponMID);


            // sub screen
            if (mCustomerMonitor == "Y")
            {
                start_sub_screen();
            }



            // 데이터 체크 임시
            //Form f = new frmCheckData();
            //f.Show();

        }


        private bool server_login()
        {
            mIsDevLogin = "";

            mIsTestPayMode = "";

            // 
            if (tbID.Text == "2502" & tbPW.Text == "0106")
            {
                // 옵저버 전용 로그인
                frmObserverLogin frm = new frmObserverLogin();
                DialogResult ret = frm.ShowDialog();

                if (ret == DialogResult.OK)  // Real
                {
                    //
                    //mIsDevLogin = "Y";  // 옵저버는 로그를 남긴다.

                    lblIsTest.Visible = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (tbID.Text == "1120" & tbPW.Text == "4089")
            {
                // 개발자 전용 로그인
                frmDevAdmin frm = new frmDevAdmin();
                DialogResult ret = frm.ShowDialog();

                if (ret == DialogResult.OK)  // Real
                {
                    //
                    mIsDevLogin = "Y";  // 개발자 로그인은 로그를 남기지 않기위해

                    lblIsTest.Visible = false;
                    return true;
                }
                else if (ret == DialogResult.Yes) // TEST
                {
                    //
                    mIsDevLogin = "Y";  // 개발자 로그인은 로그를 남기지 않기위해

                    mIsTestPayMode = "Test";

                    lblIsTest.Visible = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                mBaseUri = uri_real;

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["userId"] = tbID.Text;
                parameters["userPw"] = SHA1HashCrypt(tbPW.Text);
                parameters["macAddr"] = mMacAddr;

                if (mRequestPost("login", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        mSiteId = mObj["siteId"].ToString();
                        mUserID = tbID.Text;
                        mUserName = mObj["userName"].ToString();
                        myPosNo = mObj["posNo"].ToString();
                        myShopCode = mObj["shopCode"].ToString();  //PG 포스그룹

                        //
                        thepos_app_log(2, this.Name, "login", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);

                        return true;
                    }
                    else
                    {
                        String msg = mObj["resultMsg"].ToString();

                        thepos_app_log(3, this.Name, "login", "로그인오류. " + msg + " appVersion=" + mAppVersion + ", mac=" + mMacAddr);

                        MessageBox.Show("로그인오류\n\n" + msg, "thepos");
                        return false;
                    }
                }
                else
                {
                    //
                    //thepos_app_log(3, this.Name, "login", "시스템오류. " + mErrorMsg + " appVersion=" + mAppVersion + ", mac=" + mMacAddr);
                    //thepos_app_log(3, this.Name, "login", "네트워크 오류 인터넷 연결을 확인바랍니다");
                    //
                    //MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    MessageBox.Show("네트워크 오류\n\n\n\n인터넷 연결을 확인바랍니다.\r\n" + mErrorMsg, "thepos");

                    return false;
                }
            }
        }

        bool get_biz_date()
        {
            // 개시마감 
            String biz_date = "";
            String biz_status = "";
            mBizDate = "";

            if (get_bizdate_status(ref biz_status, ref biz_date))
            {
                if (biz_status == "A")   // A영업중 F영업마감
                {
                    mBizDate = biz_date;
                    return true;
                }
                else  // F:마감 Y:집계완료 X:초기상태
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("개시마감관리 오류\n서버에서 정보를 읽어오지 못했습니다.", "thepos");
                return false;
            }
        }


        void ready_thepos()
        {

            // 서버 -> 메모리
            sync_data_server_to_memory();



            //
            /*
            for (int i = 0; i < mShop.Length; i++)
            {
                if (mShop[i].shop_code == myShopCode)
                {
                    myShopName = mShop[i].shop_name;
                }
            }
            */

            for (int i = 0; i < mPosGroupCodeList.Count; i++)
            {
                if (mPosGroupCodeList[i] == myShopCode)
                {
                    myShopName = mPosGroupNameList[i];
                }
            }


            // 일반(서버) 테마 적용
            panelLogin.Visible = false;

            lblSiteAlias.Text = mSiteAlias;
            lblSiteName.Text = mSiteName;
            lblShopName.Text = myShopName;
            lblPosNo.Text = myPosNo;
            lblUserName.Text = mUserName;
            lblCallCenterNo.Text = mCallCenterNo;


            // 로그인여부
            mIsLogin = "Y";


            // 마우스 커서
            if (mPosType == "POS" | mPosType == "POS-Ticket")
            {
                Cursor.Hide();
            }
            else
            {
                Cursor.Show();
            }

        }



        public void sync_data_server_to_memory()
        {
            // 1. 사이트
            if (true)
            {
                String sUrl = "site?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["sites"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            mSiteName = arr[0]["siteName"].ToString();
                            mSiteAlias = arr[0]["siteAlias"].ToString();
                            mRegistNo = arr[0]["registNo"].ToString();
                            mCapName = arr[0]["capName"].ToString();
                            mBizAddr = arr[0]["bizAddr"].ToString();
                            mBizTelNo = arr[0]["bizTelNo"].ToString();
                            mTicketType = arr[0]["ticketType"].ToString();
                            mTicketMedia = arr[0]["ticketMedia"].ToString();
                            mPointType = arr[0]["pointType"].ToString();
                            mVanCode = arr[0]["vanCode"].ToString();
                            mCallCenterNo = arr[0]["callCenterNo"].ToString();

                            // 알림톡
                            mAllimYn = arr[0]["allimYn"].ToString();
                            mAllimSenderProfile = arr[0]["senderProfile"].ToString();


                            // 
                            mPosLayoutType = arr[0]["posLayoutType"].ToString();



                            String image_str = arr[0]["billImage"].ToString();

                            if (image_str == "")
                            {
                                mByteLogoImage = null;
                            }
                            else
                            {
                                try
                                {
                                    byte[] mBillImageByte = Convert.FromBase64String(image_str);

                                    MemoryStream ms = new MemoryStream(mBillImageByte, 0, mBillImageByte.Length);
                                    ms.Write(mBillImageByte, 0, mBillImageByte.Length);

                                    Bitmap bitmap_bill = new Bitmap(ms);


                                    mByteLogoImage = GetImage(bitmap_bill, 400);
                                }
                                catch
                                {
                                    mByteLogoImage = null;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("사이트정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 6. setupPos
            if (true)
            {
                mBillPrinterPort = "";
                mBillPrinterSpeed = "";
                mMobileExchangeType = "";
                mPrintExchangeType = "";
                mTicketPrinterPort = "";
                mTicketPrinterSpeed = "";
                mPosType = "";
                mCustomerMonitor = "";
                mVanTID = "";
                mCouponMID = "";
                mTicketAddText = "";
                mBillAddText = "";
                mAppLogLevel = 4;
                mTheposColor = "#3380cc";


                String sUrl = "setupPos?siteId=" + mSiteId + "&posNo=" + myPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["setupPos"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["setupCode"].ToString() == "BillPrinterPort") mBillPrinterPort = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "BillPrinterSpeed") mBillPrinterSpeed = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "MobileExchangeType") mMobileExchangeType = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "PrintExchangeType") mPrintExchangeType = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "TicketPrinterPort") mTicketPrinterPort = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "TicketPrinterSpeed") mTicketPrinterSpeed = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "PosType") mPosType = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "CustomerMonitor") mCustomerMonitor = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "VanTID") mVanTID = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "CouponMID") mCouponMID = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "SubMonitorImage") mSubMonitorImage = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "TicketAddText") mTicketAddText = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "BillAddText") mBillAddText = arr[i]["setupValue"].ToString();

                            else if (arr[i]["setupCode"].ToString() == "AppLogLevel")
                            {
                                //  mLogLevel -  1: ALL  2: ERROR  3: NONE
                                String t_level = arr[i]["setupValue"].ToString();

                                if (t_level == "ALL") mAppLogLevel = 1;
                                else if (t_level == "IMPORTANT") mAppLogLevel = 2;
                                else if (t_level == "ERROR") mAppLogLevel = 3;
                                else if (t_level == "NONE") mAppLogLevel = 4;
                                else mAppLogLevel = 4;
                            }
                            else if (arr[i]["setupCode"].ToString() == "PosBaseColor")
                            {
                                if (arr[i]["setupValue"].ToString() != "")
                                {
                                    mTheposColor = arr[i]["setupValue"].ToString();
                                }

                            }
                        }
                    }
                }
            }



            // 1-2. site_allim
            if (true)
            { 
                mAllimSenderProfile = "";
                mAllimSenderProfileKey = "";
                mAllimSiteName = "";
                mAllimUserId = "";
                mAllimCorpCode = "";
                mAllimOrCode = "";
                mAllimCpCode = "";
                mAllimEtcCode = "";


                if (mAllimYn == "Y")
                {
                    String sUrl = "siteAllim?siteId=" + mSiteId;

                    if (mRequestGet(sUrl))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            String data = mObj["sites"].ToString();
                            JArray arr = JArray.Parse(data);

                            if (arr.Count > 0)
                            {
                                mAllimSenderProfile = arr[0]["senderProfile"].ToString();
                                mAllimSenderProfileKey = arr[0]["senderProfileKey"].ToString();
                                mAllimSiteName = arr[0]["siteName"].ToString();
                                mAllimUserId = arr[0]["allimUserId"].ToString();
                                mAllimCorpCode = arr[0]["allimCorpCode"].ToString();
                                mAllimOrCode = arr[0]["orAllimCode"].ToString();
                                mAllimCpCode = arr[0]["cpAllimCode"].ToString();
                                mAllimEtcCode = arr[0]["etcAllimCode"].ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("알림톡정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }
            }


            // 2-1. goodsGroup
            if (mPosLayoutType != "S")
            {
                String sUrl = "posGoodsGroup?siteId=" + mSiteId + "&shopCode=" + myShopCode;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["goodsGroups"].ToString();
                        JArray arr = JArray.Parse(data);

                        myGoodsGroup = new GoodsGroup[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            myGoodsGroup[i].group_code = arr[i]["groupCode"].ToString();
                            myGoodsGroup[i].group_name = arr[i]["groupName"].ToString();
                            myGoodsGroup[i].soldout = arr[i]["soldout"].ToString();
                            myGoodsGroup[i].cutout = arr[i]["cutout"].ToString();
                            myGoodsGroup[i].column = int.Parse(arr[i]["locateX"].ToString());
                            myGoodsGroup[i].row = int.Parse(arr[i]["locateY"].ToString());
                            myGoodsGroup[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                            myGoodsGroup[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());

                            String b_color = arr[i]["btnColor"].ToString();
                            if (b_color == "" | b_color == "null") b_color = mTheposColor;
                            myGoodsGroup[i].btn_color = b_color;
                        }
                    }
                    else
                    {
                        MessageBox.Show("상품그룹정보 오류. posGoodsGroup\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            // 2-2. goodsGroupSeq
            if (mPosLayoutType == "S")
            {
                String sUrl = "posGoodsGroupSeq?siteId=" + mSiteId + "&shopCode=" + myShopCode;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["goodsGroups"].ToString();
                        JArray arr = JArray.Parse(data);

                        myGoodsGroup = new GoodsGroup[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            myGoodsGroup[i].group_code = arr[i]["groupCode"].ToString();
                            myGoodsGroup[i].group_name = arr[i]["groupName"].ToString();
                            myGoodsGroup[i].soldout = arr[i]["soldout"].ToString();
                            myGoodsGroup[i].cutout = arr[i]["cutout"].ToString();
                            myGoodsGroup[i].layout_no = int.Parse(arr[i]["layoutNo"].ToString());

                            String b_color = arr[i]["btnColor"].ToString();
                            if (b_color == "" | b_color == "null") b_color = mTheposColor;
                            myGoodsGroup[i].btn_color = b_color;
                        }
                    }
                    else
                    {
                        MessageBox.Show("상품그룹정보 오류. posGoodsGroupSeq\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 3. goodsItem
            if (mPosLayoutType != "S")
            {
                String sUrl = "posGoodsItem?siteId=" + mSiteId + "&shopCode=" + myShopCode;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["goodsItems"].ToString();
                        JArray arr = JArray.Parse(data);

                        myGoodsItem = new GoodsItem[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            myGoodsItem[i].group_code = arr[i]["groupCode"].ToString();
                            myGoodsItem[i].goods_code = arr[i]["goodsCode"].ToString();

                            myGoodsItem[i].column = int.Parse(arr[i]["locateX"].ToString());
                            myGoodsItem[i].row = int.Parse(arr[i]["locateY"].ToString());
                            myGoodsItem[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                            myGoodsItem[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());

                            String b_color = arr[i]["btnColor"].ToString();

                            if (b_color.Length == 7)
                            {
                                myGoodsItem[i].btn_color = b_color;
                            }
                            else
                            {
                                myGoodsItem[i].btn_color = mTheposColor;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("상품정보 오류. posGoodsItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 3. goodsItemSeq 
            if (mPosLayoutType == "S")
            {
                String sUrl = "posGoodsItemSeq?siteId=" + mSiteId + "&shopCode=" + myShopCode;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["goodsItems"].ToString();
                        JArray arr = JArray.Parse(data);

                        myGoodsItem = new GoodsItem[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            myGoodsItem[i].group_code = arr[i]["groupCode"].ToString();
                            myGoodsItem[i].goods_code = arr[i]["goodsCode"].ToString();

                            myGoodsItem[i].layout_no = int.Parse(arr[i]["layoutNo"].ToString());

                            String b_color = arr[i]["btnColor"].ToString();

                            if (b_color.Length == 7)
                            {
                                myGoodsItem[i].btn_color = b_color;
                            }
                            else
                            {
                                myGoodsItem[i].btn_color = mTheposColor;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("상품정보 오류. myGoodsItemSeq\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }




            // 3. goods
            if (true)
            {
                String sUrl = "goods?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["goods"].ToString();
                        JArray arr = JArray.Parse(data);

                        mGoodsList.Clear();

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String t_goods_code = arr[i]["goodsCode"].ToString();

                            for (int k = 0; k < myGoodsItem.Length; k++)
                            {
                                if (myGoodsItem[k].goods_code == t_goods_code)
                                {
                                    myGoodsItem[k].goods_name = arr[i]["goodsName"].ToString();
                                    myGoodsItem[k].shop_code = arr[i]["shopCode"].ToString();
                                    myGoodsItem[k].nod_code1 = arr[i]["nodCode1"].ToString();
                                    myGoodsItem[k].nod_code2 = arr[i]["nodCode2"].ToString();
                                    myGoodsItem[k].amt = int.Parse(arr[i]["amt"].ToString());
                                    myGoodsItem[k].online_coupon = arr[i]["onlineCoupon"].ToString();
                                    myGoodsItem[k].ticket = arr[i]["ticketYn"].ToString();
                                    myGoodsItem[k].taxfree = arr[i]["taxFree"].ToString();
                                    myGoodsItem[k].cutout = arr[i]["cutout"].ToString();
                                    myGoodsItem[k].soldout = arr[i]["soldout"].ToString();
                                    myGoodsItem[k].allim = arr[i]["allim"].ToString();
                                    myGoodsItem[k].option_template_id = arr[i]["optionTemplateId"].ToString();
                                    //myGoodsItem[k].coupon_link_no = arr[i]["couponLinkNo"].ToString();
                                    //myGoodsItem[k].bar_code = arr[i]["barCode"].ToString();

                                    // 면세상픔은 상품명앞에 *을 붙인다.
                                    if (myGoodsItem[k].taxfree == "1")
                                    {
                                        myGoodsItem[k].goods_name = "*" + myGoodsItem[k].goods_name;
                                    }
                                }
                            }


                            //
                            Goods goods = new Goods();
                            goods.goods_code = arr[i]["goodsCode"].ToString();
                            goods.goods_name = arr[i]["goodsName"].ToString();
                            goods.amt = int.Parse(arr[i]["amt"].ToString());
                            goods.online_coupon = arr[i]["onlineCoupon"].ToString();
                            goods.ticket = arr[i]["ticketYn"].ToString();
                            goods.taxfree = arr[i]["taxFree"].ToString();
                            goods.shop_code = arr[i]["shopCode"].ToString();
                            goods.nod_code1 = arr[i]["nodCode1"].ToString();
                            goods.nod_code2 = arr[i]["nodCode2"].ToString();
                            goods.cutout = arr[i]["cutout"].ToString();
                            goods.soldout = arr[i]["soldout"].ToString();
                            goods.allim = arr[i]["allim"].ToString();
                            goods.bar_code = arr[i]["barCode"].ToString().Trim();
                            goods.coupon_link_no = arr[i]["couponLinkNo"].ToString();
                            mGoodsList.Add(goods);
                        }
                    }
                    else
                    {
                        MessageBox.Show("상품정보 오류. goodsItemAndGoods\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }





            // 3. goodsTicket
            if (true)
            {
                String sUrl = "goodsTicket?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["goods"].ToString();
                        JArray arr = JArray.Parse(data);

                        mGoodsTicket = new GoodsTicket[arr.Count + 1];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mGoodsTicket[i].goods_code = arr[i]["goodsCode"].ToString();
                            mGoodsTicket[i].available_minute = arr[i]["availableMinute"].ToString();
                            mGoodsTicket[i].is_charge = arr[i]["isCharge"].ToString();
                            mGoodsTicket[i].ot_free_minute = arr[i]["otFreeMinute"].ToString();
                            mGoodsTicket[i].ot_std_minute = arr[i]["otStdMinute"].ToString();
                            mGoodsTicket[i].ot_amt = arr[i]["otAmt"].ToString();
                            mGoodsTicket[i].link_goods_code = arr[i]["linkGoodsCode"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("옵션템플릿정보 오류. optionTemplate\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }



            // 3-1. optionTemplate
            if (true)
            {
                String sUrl = "optionTemplate?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["optionTemp"].ToString();
                        JArray arr = JArray.Parse(data);

                        mOptionTemplate = new OptionTemplate[arr.Count + 1];

                        mOptionTemplate[0].option_template_id = "";
                        mOptionTemplate[0].option_template_name = "";


                        for (int i = 0; i < arr.Count; i++)
                        {
                            mOptionTemplate[i+1].option_template_id = arr[i]["optionTemplateId"].ToString();
                            mOptionTemplate[i+1].option_template_name = arr[i]["optionTemplateName"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("옵션템플릿정보 오류. optionTemplate\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 3-2. tempOption
            if (true)
            {
                String sUrl = "tempOption?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["tempOption"].ToString();
                        JArray arr = JArray.Parse(data);

                        mTempOption = new TempOption[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mTempOption[i].option_template_id = arr[i]["optionTemplateId"].ToString();
                            mTempOption[i].option_id = arr[i]["optionId"].ToString();
                            mTempOption[i].option_seq = convert_number(arr[i]["optionSeq"].ToString());
                            mTempOption[i].is_turnoff = arr[i]["isTurnoff"].ToString();
                            mTempOption[i].next_option_id = arr[i]["nextOptionId"].ToString();
                            mTempOption[i].option_name = arr[i]["optionName"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("옵션정보 오류. tempOption\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 3-3. tempOptionItem
            if (true)
            {
                String sUrl = "tempOptionItem?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["optionItem"].ToString();
                        JArray arr = JArray.Parse(data);

                        mTempOptionItem = new TempOptionItem[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mTempOptionItem[i].option_template_id = arr[i]["optionTemplateId"].ToString();
                            mTempOptionItem[i].option_id = arr[i]["optionId"].ToString();
                            mTempOptionItem[i].option_item_id = arr[i]["optionItemId"].ToString();
                            mTempOptionItem[i].option_item_seq = convert_number(arr[i]["optionItemSeq"].ToString());
                            mTempOptionItem[i].link_option_id = arr[i]["linkOptionId"].ToString();
                            mTempOptionItem[i].option_item_name = arr[i]["optionItemName"].ToString();
                            mTempOptionItem[i].option_item_amt = convert_number(arr[i]["optionItemAmt"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("옵션정보 오류. tempOption\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 3-4.  goods



            // 4. 샵
            if (true)
            {
                String sUrl = "shop?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["shops"].ToString();
                        JArray arr = JArray.Parse(data);

                        // 업장콤보에 첫줄빈칸을 추가하기위함. -> 수정시  주문서/교환권 출력시 [코너 : 업장명] 출력생략부분을 확인해라!!
                        mShop = new Shop[arr.Count + 1];

                        mShop[0].shop_code = "";
                        mShop[0].shop_name = "";
                        mShop[0].printer_type = "";
                        mShop[0].network_printer_name = "";

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mShop[i+1].shop_code = arr[i]["shopCode"].ToString();
                            mShop[i+1].shop_name = arr[i]["shopName"].ToString();
                            mShop[i+1].printer_type = arr[i]["printerType"].ToString();
                            mShop[i+1].network_printer_name = arr[i]["networkPrinterName"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("샵정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            // 4-1. 분류1
            if (true)
            {
                String sUrl = "nod1?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["nod1s"].ToString();
                        JArray arr = JArray.Parse(data);

                        // 업장콤보에 첫줄빈칸을 추가하기위함. -> 수정시  주문서/교환권 출력시 [코너 : 업장명] 출력생략부분을 확인해라!!
                        mNod1 = new Nod1[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mNod1[i].shop_code = arr[i]["shopCode"].ToString();
                            mNod1[i].nod_code1 = arr[i]["nodCode1"].ToString();
                            mNod1[i].nod_name1 = arr[i]["nodName1"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("분류1 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            // 4-2. 분류2
            if (true)
            {
                String sUrl = "nod2?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["nod2s"].ToString();
                        JArray arr = JArray.Parse(data);

                        // 업장콤보에 첫줄빈칸을 추가하기위함. -> 수정시  주문서/교환권 출력시 [코너 : 업장명] 출력생략부분을 확인해라!!
                        mNod2 = new Nod2[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mNod2[i].shop_code = arr[i]["shopCode"].ToString();
                            mNod2[i].nod_code1 = arr[i]["nodCode1"].ToString();
                            mNod2[i].nod_code2 = arr[i]["nodCode2"].ToString();
                            mNod2[i].nod_name2 = arr[i]["nodName2"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("분류2 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }



            // 5-1. 포스그룹
            if (true)
            {
                mPosGroupCodeList.Clear();
                mPosGroupNameList.Clear();

                mPosGroupCodeList.Add("");
                mPosGroupNameList.Add("");


                String sUrl = "posGroup?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["posGroups"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mPosGroupCodeList.Add(arr[i]["posGroupCode"].ToString());
                            mPosGroupNameList.Add(arr[i]["posGroupName"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("포스그룹정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }




            // 5-2. 포스
            if (true)
            {
                mPosNoList.Clear();
                myPosNoList.Clear();


                String sUrl = "pos?siteId=" + mSiteId + "&posStatus=Y";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["pos"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["posNo"].ToString().Substring(0,1) == "0" | arr[i]["posNo"].ToString().Substring(0, 1) == "1")
                            {
                                //
                                mPosNoList.Add(arr[i]["posNo"].ToString());  // 사이트 전체 포스


                                if (arr[i]["shopCode"].ToString() == myShopCode)  //PG 포스그룹
                                {
                                    //
                                    myPosNoList.Add(arr[i]["posNo"].ToString());  // 내 포스그룹내 포스
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
            }


            // 7. dcrFavorite
            if (true)
            {
                String sUrl = "dcrFavorite?siteId=" + mSiteId + "&shopCode=" + myShopCode;  //PG 포스그룹
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String pos = mObj["dcr"].ToString();
                        JArray arr = JArray.Parse(pos);

                        mDCR = new DCR[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mDCR[i].dcr_code = arr[i]["dcrCode"].ToString();
                            mDCR[i].dcr_name = arr[i]["dcrName"].ToString();
                            mDCR[i].dcr_des = arr[i]["dcrDes"].ToString();
                            mDCR[i].dcr_type = arr[i]["dcrType"].ToString();
                            mDCR[i].dcr_value = Int32.Parse(arr[i]["dcrValue"].ToString());
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


            // 8. paymentConsole
            if (true)
            {
                String sUrl = "paymentConsole?siteId=" + mSiteId + "&posNo=" + myPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentConsoles"].ToString();
                        JArray arr = JArray.Parse(data);

                        mPayConsol = new PayConsol[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mPayConsol[i].column = int.Parse(arr[i]["locateX"].ToString());
                            mPayConsol[i].row = int.Parse(arr[i]["locateY"].ToString());
                            mPayConsol[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                            mPayConsol[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());
                            mPayConsol[i].code = arr[i]["buttonCode"].ToString();
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

            // 8. flowConsole
            if (true)
            {
                String sUrl = "flowConsole?siteId=" + mSiteId + "&posNo=" + myPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["flowConsoles"].ToString();
                        JArray arr = JArray.Parse(data);

                        mFlowConsol = new FlowConsol[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mFlowConsol[i].column = int.Parse(arr[i]["locateX"].ToString());
                            mFlowConsol[i].row = int.Parse(arr[i]["locateY"].ToString());
                            mFlowConsol[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                            mFlowConsol[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());
                            mFlowConsol[i].code = arr[i]["buttonCode"].ToString();
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

        }


        public static byte[] GetImage(Bitmap bill_image, int printWidth)
        {
            List<byte> byteList = new List<byte>();

            BitmapData data = GetBitmapData(bill_image, printWidth);


            BitArray dots = data.Dots;
            byte[] width = BitConverter.GetBytes(data.Width);

            int offset = 0;
            //byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            //byteList.Add(Convert.ToByte('@'));
            byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            byteList.Add(Convert.ToByte('3'));
            byteList.Add((byte)24);
            while (offset < data.Height)
            {
                byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
                byteList.Add(Convert.ToByte('*'));
                byteList.Add((byte)33);
                byteList.Add(width[0]);
                byteList.Add(width[1]);

                for (int x = 0; x < data.Width; ++x)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        byte slice = 0;
                        for (int b = 0; b < 8; ++b)
                        {
                            int y = (((offset / 8) + k) * 8) + b;
                            int i = (y * data.Width) + x;

                            bool v = false;
                            if (i < dots.Length)
                                v = dots[i];

                            slice |= (byte)((v ? 1 : 0) << (7 - b));
                        }
                        byteList.Add(slice);
                    }
                }
                offset += 24;
                byteList.Add(Convert.ToByte(0x0A));
            }
            byteList.Add(Convert.ToByte(0x1B));
            byteList.Add(Convert.ToByte('3'));
            byteList.Add((byte)30);
            return byteList.ToArray();
        }

        private static BitmapData GetBitmapData(Bitmap bill_image, int width)
        {
            using (var bitmap = bill_image)
            {
                var threshold = 127;
                var index = 0;
                double multiplier = width; // 이미지 width조정
                double scale = (double)(multiplier / (double)bitmap.Width);
                int xheight = (int)(bitmap.Height * scale);
                int xwidth = (int)(bitmap.Width * scale);
                var dimensions = xwidth * xheight;
                var dots = new BitArray(dimensions);

                for (var y = 0; y < xheight; y++)
                {
                    for (var x = 0; x < xwidth; x++)
                    {
                        var _x = (int)(x / scale);
                        var _y = (int)(y / scale);
                        var color = bitmap.GetPixel(_x, _y);
                        var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        dots[index] = (luminance < threshold);
                        index++;
                    }
                }

                return new BitmapData()
                {
                    Dots = dots,
                    Height = (int)(bitmap.Height * scale),
                    Width = (int)(bitmap.Width * scale)
                };
            }
        }


        private class BitmapData
        {
            public BitArray Dots
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }

            public int Width
            {
                get;
                set;
            }
        }




        // 판매관리
        private void btnSales_Click(object sender, EventArgs e)
        {
            // 영업상태
            // 영업중상태: 개시후 마감전
            // 영업마감상태 : 마감이후 개시전

            //
            thepos_app_log(1, this.Name, "btnSales", "");


            String biz_Status = "";
            String biz_date = "";

            if (get_bizdate_status(ref biz_Status, ref biz_date))
            {
                if (biz_Status == "A")   // A영업중 F영업마감
                {
                    // 영업중이면 그대로 판매관리로 진행
                    mBizDate = biz_date;

                    panelDivision.Visible = true;
                    panelDivision.Controls.Clear();

                    frmSales fForm = new frmSales() { TopLevel = false, TopMost = true };
                    panelDivision.Controls.Add(fForm);
                    fForm.Show();
                }
                else if (biz_Status == "F" | biz_Status == "Y" | biz_Status == "X")  // 마감, 집계완료, 초기상태
                {
                    MessageBox.Show("영업개시전입니다. 영업개시 입력바랍니다.", "thepos");
                    return;
                }
            }
            else
            {
                // 서버루틴에서 에러메시지 기표시...
                return;
            }

        }

        // 영업관리
        private void btnBusiness_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "btnBusiness", "");

            panelDivision.Visible = true;
            panelDivision.Controls.Clear();

            frmBusiness fForm = new frmBusiness() { TopLevel = false, TopMost = true };
            panelDivision.Controls.Add(fForm);
            fForm.Show();

        }

        // 매출관리
        private void btnReports_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "btnReports", "");

            panelDivision.Visible = true;
            panelDivision.Controls.Clear();

            frmReports fForm = new frmReports() { TopLevel = false, TopMost = true };
            panelDivision.Controls.Add(fForm);
            fForm.Show();

        }

        // 환경설정
        private void btnSetup_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "btnSetup", "");


            panelDivision.Visible = true;
            panelDivision.Controls.Clear();

            frmSetup fForm = new frmSetup() { TopLevel = false, TopMost = true };
            panelDivision.Controls.Add(fForm);
            fForm.Show();

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(2, this.Name, "btnClose", "Close. appVersion=" + mAppVersion + ", mac=" + mMacAddr);

            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "btnExit", "");


            frmExit fExit = new frmExit();
            DialogResult ret =  fExit.ShowDialog();

            //
            if (ret == DialogResult.Yes)
            {
                // 로그아웃
                isRunThread = false;

                clear_login_init();  // 초기화

                // 고객화면이 떠있으면 종료
                bool isSubForm = false;
                foreach (Form f in System.Windows.Forms.Application.OpenForms)
                {
                    if (f.Name == "frmSub")
                    {
                        isSubForm = true;
                    }
                }
                
                if (isSubForm)
                {
                    fSub.Close();
                }

                panelLogin.Visible = true;

            }
            else if (ret == DialogResult.OK)
            {
                // 종료
                isRunThread = false;

                Thread.Sleep(500);

                this.Close();

            }
            else if (ret == DialogResult.Abort)
            {
                // 원장로드
                //sync_data_server_to_memory();
                ready_thepos();

                MessageBox.Show("원장데이터 재로드 완료.", "thepos");

            }
            else if (ret == DialogResult.Cancel)
            {
                // 닫기
            }

        }

        private void tbID_Click(object sender, EventArgs e)
        {
            //mTbKeyDisplayController = tbID;
        }

        private void tbPW_Click(object sender, EventArgs e)
        {
            //mTbKeyDisplayController = tbPW;
        }

        private void tbPW_Enter(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbPW;
        }

        private void tbID_Enter(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbID;
        }

        private void lblSiteAlias_Click(object sender, EventArgs e)
        {
            sysadmin_pw_patern = "";
            lblUserNameTitle.ForeColor = System.Drawing.Color.White;
        }

        private void lblPosNoTitle_Click(object sender, EventArgs e)
        {
            sysadmin_pw_patern += "1";
        }

        private void lblUserNameTitle_Click(object sender, EventArgs e)
        {
            sysadmin_pw_patern += "2";

            if (sysadmin_pw_patern == "1122")
            {
                lblUserNameTitle.ForeColor = System.Drawing.Color.Gold;
            }
        }

        private void lblCallCenterNo_Click(object sender, EventArgs e)
        {

            //
            thepos_app_log(1, this.Name, "click admin", "");


            string mode = "";
            if (tbID.Text == "1120" & tbPW.Text == "4089")
            {
                mode = "Test";
            }




            frmSysAdmin frmSysAdmin = new frmSysAdmin(sysadmin_pw_patern, mode);
            //frmSysAdmin.ShowDialog();
            frmSysAdmin.Show();

            sysadmin_pw_patern = "";
            lblUserNameTitle.ForeColor = System.Drawing.Color.White;
        }


        private bool check_server_status()
        {
            String sUrl = "testCall?siteId=" + mSiteId + "&posNo=" + myPosNo + "&testDt=" + get_today_date() + get_today_time();
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        private void btnSupport_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "btnSupport", "");


            //원격지원
            System.Diagnostics.Process.Start("http://786.co.kr");
        }


        private void btnReqSupport_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "btnReqSupport", "원격지원");


            //원격지원
            System.Diagnostics.Process.Start("http://786.co.kr");
        }

        private void btnReqUser_Click(object sender, EventArgs e)
        {
            //
            thepos_app_log(1, this.Name, "btnReqUser", "");


            string mode = "";
            if (tbID.Text == "1120" & tbPW.Text == "4089")
            {
                mode = "Test";
            }
            else
            {
                mode = "Real";
            }

            frmReqUser fReqUser = new frmReqUser(mode);
            fReqUser.ShowDialog();
        }


    }
}
