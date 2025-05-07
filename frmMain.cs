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
using System.Data.SQLite;
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
            thepos_app_log(2, "theposw1", "START.....", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);

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
            lblPosNo.Text = mPosNo;
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


            try
            {
                tbID.Text = get_registry_id();
                tbID.Tag = tbID.Text;
            }
            catch
            {
                MessageBox.Show("레지스트리 오류...", "thepos");
                return;
            }



            if (tbID.Text.Length == 4)
            {
                mTbKeyDisplayController = tbPW;
            }
            else
            {
                mTbKeyDisplayController = tbID;
            }


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
            mPosNo = "";
            mUserName = "";

            mSiteId = "";
            mSiteName = "";         // 매장명
            mSiteAlias = "";        // 매장명
            mCapName = "";          // 대표자명
            mRegistNo = "";         // 사업자번호
            mBizAddr = "";          // 주소
            mBizTelNo = "";         // 대표전화

            mTicketType = "";  // ""미사용, "PA"선불, "PD"후불
            mTicketMedia = "";  // 띠지BC   팔찌RF
            mVanCode = "";
            mCallCenterNo = "";

            mCornerType = "";  // 주문서 관리 - ""미사용, "E"단순일체형, "P"분리형

            mPosNo = "";
            mBizDate = "";

            mUserID = "";
            mUserName = "";

            lblSiteAlias.Text = "";
            lblSiteName.Text = "";
            lblPosNo.Text = "";
            lblUserName.Text = "";

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


            // 데이터 체크 임시
            //Form f = new frmCheckData();
            //f.Show();

        }


        private bool server_login()
        {
            // 
            if (tbID.Text == "1120" & tbPW.Text == "4089")
            {
                // 개발자 전용 로그인
                frmDevAdmin frm = new frmDevAdmin();
                DialogResult ret = frm.ShowDialog();

                if (ret == DialogResult.OK)  // Real
                {
                    lblIsTest.Visible = false;
                    return true;
                }
                else if (ret == DialogResult.Yes) // TEST
                {
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
                        mPosNo = mObj["posNo"].ToString();

                        //
                        thepos_app_log(2, this.Name, "login", "appVersion=" + mAppVersion + ", mac=" + mMacAddr);

                        return true;
                    }
                    else
                    {
                        String msg = mObj["resultMsg"].ToString();

                        thepos_app_log(3, this.Name, "login", "로그인오류. " + msg);

                        MessageBox.Show("로그인오류\n\n" + msg, "thepos");
                        return false;
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "login", "시스템오류. " + mErrorMsg);

                    //
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
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

            // 일반(서버) 테마 적용
            btnBusiness.Enabled = true;
            btnReports.Enabled = true;
            btnSupport.Enabled = true;

            panelLogin.Visible = false;

            lblSiteAlias.Text = mSiteAlias;
            lblSiteName.Text = mSiteName;
            lblPosNo.Text = mPosNo;
            lblUserName.Text = mUserName;
            lblCallCenterNo.Text = mCallCenterNo;

            save_registry_info();


            // 로그인여부
            mIsLogin = "Y";


            // sub screen
            if (mCustomerMonitor == "Y")
            {
                start_sub_screen();
            }


            // 마우스 커서
            if (mPosType == "POS" | mPosType == "POS-Ticket")
            {
                Cursor.Hide();
            }

        }



        private void sync_data_server_to_memory()
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
                            mVanCode = arr[0]["vanCode"].ToString();
                            mCallCenterNo = arr[0]["callCenterNo"].ToString();

                            // 알림톡
                            mAllimYn = arr[0]["allimYn"].ToString();
                            mAllimSenderProfile = arr[0]["senderProfile"].ToString();


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



            // 1-2. site_allim
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




            // 2. goodsGroup
            if (true)
            {
                String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String goods_group = mObj["goodsGroups"].ToString();
                        JArray arr = JArray.Parse(goods_group);

                        mGoodsGroup = new GoodsGroup[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mGoodsGroup[i].group_code = arr[i]["groupCode"].ToString();
                            mGoodsGroup[i].group_name = arr[i]["groupName"].ToString();
                            mGoodsGroup[i].soldout = arr[i]["soldout"].ToString();
                            mGoodsGroup[i].column = int.Parse(arr[i]["locateX"].ToString());
                            mGoodsGroup[i].row = int.Parse(arr[i]["locateY"].ToString());
                            mGoodsGroup[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                            mGoodsGroup[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("상품그룹정보 오류. goodsGroup\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 3. goodsItemAndGoods
            if (true)
            {
                String sUrl = "goodsItemAndGoods?siteId=" + mSiteId + "&posNo=" + mPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String goods_item = mObj["goodsItems"].ToString();
                        JArray arr = JArray.Parse(goods_item);

                        mGoodsItem = new GoodsItem[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mGoodsItem[i].group_code = arr[i]["groupCode"].ToString();
                            mGoodsItem[i].goods_code = arr[i]["goodsCode"].ToString();
                            mGoodsItem[i].goods_name = arr[i]["goodsName"].ToString();
                            mGoodsItem[i].shop_code = arr[i]["shopCode"].ToString();
                            mGoodsItem[i].amt = int.Parse(arr[i]["amt"].ToString());
                            mGoodsItem[i].online_coupon = arr[i]["onlineCoupon"].ToString();
                            mGoodsItem[i].ticket = arr[i]["ticketYn"].ToString();
                            mGoodsItem[i].taxfree = arr[i]["taxFree"].ToString();
                            mGoodsItem[i].cutout = arr[i]["cutout"].ToString();
                            mGoodsItem[i].soldout = arr[i]["soldout"].ToString();
                            mGoodsItem[i].allim = arr[i]["allim"].ToString();
                            mGoodsItem[i].column = int.Parse(arr[i]["locateX"].ToString());
                            mGoodsItem[i].row = int.Parse(arr[i]["locateY"].ToString());
                            mGoodsItem[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                            mGoodsItem[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());
                            mGoodsItem[i].option_template_id = arr[i]["optionTemplateId"].ToString();
                            mGoodsItem[i].coupon_link_no = arr[i]["couponLinkNo"].ToString();

                            // 면세상픔은 상품명앞에 *을 붙인다.
                            if (mGoodsItem[i].taxfree == "1")
                            {
                                mGoodsItem[i].goods_name = "*" + mGoodsItem[i].goods_name;
                            }
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


            // 5. 포스
            if (true)
            {
                String sUrl = "pos?siteId=" + mSiteId + "&posStatus=Y";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String pos = mObj["pos"].ToString();
                        JArray arr = JArray.Parse(pos);

                        mPosNoList = new String[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mPosNoList[i] = arr[i]["posNo"].ToString();

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


            // 6. setupPos
            if (true)
            {
                String sUrl = "setupPos?siteId=" + mSiteId + "&posNo=" + mPosNo;
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
                            
                            else if (arr[i]["setupCode"].ToString() == "TicketAddText") mTicketAddText = arr[i]["setupValue"].ToString();

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
                        }
                    }
                }
            }


            // 7. dcrFavorite
            if (true)
            {
                String sUrl = "dcrFavorite?siteId=" + mSiteId;
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
                String sUrl = "paymentConsole?siteId=" + mSiteId + "&posNo=" + mPosNo;
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

            if (ret == DialogResult.Yes)  // 로그아웃
            {
                //? 로그아웃 프로세스 필요

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

                isRunThread = false;

                Thread.Sleep(1000);

                this.Close();

            }
            else if (ret == DialogResult.Cancel)  // 종료
            {
                
            }

                
        }

        private void tbID_Click(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbID;
        }

        private void tbPW_Click(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbPW;
        }


        private String get_registry_id()
        {

            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("thepos");

            return reg.GetValue("ID", "").ToString();
        }



        private void save_registry_info()
        {

            String dID = tbID.Text;
            String tID = (tbID.Tag + "").ToString();

            if ( dID == tID)
            {
                return;
            }


            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("thepos");


            reg.SetValue("ID", dID);

        }



        private void lblSiteAlias_Click(object sender, EventArgs e)
        {
            sysadmin_pw_patern = "";
        }

        private void lblPosNoTitle_Click(object sender, EventArgs e)
        {
            sysadmin_pw_patern += "1";
        }

        private void lblUserNameTitle_Click(object sender, EventArgs e)
        {
            sysadmin_pw_patern += "2";
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
        }


        private bool check_server_status()
        {
            String sUrl = "testCall?siteId=" + mSiteId + "&posNo=" + mPosNo + "&testDt=" + get_today_date() + get_today_time();
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
