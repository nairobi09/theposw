﻿using Microsoft.Win32;
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


        public frmMain()
        {
            Screen[] scr = Screen.AllScreens;
            this.Location = scr[0].Bounds.Location;

            InitializeComponent();

            initialize_font();

            initialize_the();

        }


        private void initialize_font()
        {
            //fontCollection.AddFontFile("Font\\Pretendard-Medium.ttf");
            //fontCollection.AddFontFile("Font\\TossProductSansTTF-Medium.ttf");
            fontCollection.AddFontFile("Font\\SpoqaHanSansNeo-Medium.ttf");


            font5 = new Font(fontCollection.Families[0], 5f);
            font8 = new Font(fontCollection.Families[0], 8f);
            font9 = new Font(fontCollection.Families[0], 9f);
            font10 = new Font(fontCollection.Families[0], 10f);
            font10bold = new Font(fontCollection.Families[0], 10f, FontStyle.Bold);
            font12 = new Font(fontCollection.Families[0], 12f);
            font12bold = new Font(fontCollection.Families[0], 12f, FontStyle.Bold);
            font13 = new Font(fontCollection.Families[0], 12f);
            font14 = new Font(fontCollection.Families[0], 14f);
            font16 = new Font(fontCollection.Families[0], 16f);
            font20 = new Font(fontCollection.Families[0], 20f);
            font24 = new Font(fontCollection.Families[0], 24f);



            btnClose.Font = font12;


            lblSiteAlias.Font = font16;
            lblSiteName.Font = font10;

            lblPosNoTitle.Font = font10;
            lblPosNo.Font = font10;

            lblUserNameTitle.Font = font10;
            lblUserName.Font = font9;

            lblLocalModeTitle.Font = font10;

            btnSales.Font = font14;
            btnBusiness.Font = font14;
            btnReports.Font = font14;
            btnSetup.Font = font12;
            btnSupport.Font = font12;
            btnExit.Font = font12;

            lblCallCenterNo.Font = font10;

            // 로그인

            lblID.Font = font10;
            lblPW.Font = font10;

            tbID.Font = font14;
            tbPW.Font = font14;

            btnKey1.Font = font14;
            btnKey2.Font = font14;
            btnKey3.Font = font14;
            btnKey4.Font = font14;
            btnKey5.Font = font14;
            btnKey6.Font = font14;
            btnKey7.Font = font14;
            btnKey8.Font = font14;
            btnKey9.Font = font14;
            btnKey0.Font = font14;
            btnKeyBS.Font = font14;
            btnKeyClear.Font = font14;
            btnKeyLogin.Font = font12;

            btnReqSupport.Font = font10;
            btnReqUser.Font = font10;

        }

        private void initialize_the()
        {

            mLblTheModeStatus = lblLocalModeTitle;

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


            // local DB
            String cs = "";

            try
            {
#if DEBUG
                var enviroment = System.Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
                cs = @"URI=file:" + projectDirectory + "\\local_theposm.db";

#else
                cs = @"URI=file:" + System.Windows.Forms.Application.StartupPath + "\\local_theposm.db";
#endif

                mConn = new SQLiteConnection(cs);
                mConn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB초기화 오류...\r\n" + ex.Message.ToString() + "\r\n" + cs, "thepos");
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
            
            synclink_log("-------------------------------------------");

            mNetworkState = NetworkInterface.GetIsNetworkAvailable();
            synclink_log("네트워크상태 : " + mNetworkState);

            //
            mPrevNetworkState = mNetworkState;


            // 네트워크 상태 : 정상이미지를 보이기/숨기기
            pbNetworkConn.Visible = NetworkInterface.GetIsNetworkAvailable();
            pbNetworkDisconn.Visible = !pbNetworkConn.Visible;

            // 서버 상태 : 최초 서버 테스트콜
            bool tServerStatus = check_server_status();
            if (tServerStatus == false)
            {
                change_mode_server_to_local();
                synclink_log("모드기동 : 로컬모드");
            }
            else if (tServerStatus == true)
            {
                change_mode_local_to_server();
                synclink_log("모드기동 : 서버모드");
            }



            // SyncLink 쓰레드
            threadSyncLink = new Thread(SyncLink);
            threadSyncLink.Start();

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            threadSyncLink.Abort();

            //synclink_log("SyncLink 쓰레드 종료");
        }


        private void SyncLink()
        {
            // 3가지 기능
            // 1. 테스트콜 -> 모드 자동전환
            // 2. 서버원장 자동다운로드
            // 3. 로컬레코드 자동업로드

            synclink_log("======  SyncLink 쓰레드 시작  ======");


            // 서버 테스트콜
            bool tServerStatus = check_server_status();


            // 인터벌 기준 5초 기준   ->  5초 * 12 = 1분
            mSyncLinkWaitCnt = 0;


            while (true)
            {
                //
                Thread.Sleep(1000 * 2); // XX초

                mSyncLinkWaitCnt++;


                mNetworkState = NetworkInterface.GetIsNetworkAvailable();
 
                if (mPrevNetworkState != mNetworkState) 
                {
                   // 네트워크 상태 : 정상이미지를 보이기/숨기기
                    pbNetworkConn.BeginInvoke(new Action(() => pbNetworkConn.Visible = mNetworkState));
                    pbNetworkDisconn.BeginInvoke(new Action(() => pbNetworkDisconn.Visible = !pbNetworkConn.Visible));

                    synclink_log("네트워크상태변경 : " + mPrevNetworkState + "-> " + mNetworkState);

                    mPrevNetworkState = mNetworkState;


                    if (mNetworkState == false)
                    {
                        // Server -> Local  체크없이 바로 Local로 전환!!!
                        tServerStatus = false;
                        change_mode_server_to_local();
                        synclink_log("모드전환 [서버 -> 로컬]");
                    }

                }


                
                if ((mNetworkState != tServerStatus) | (mSyncLinkWaitCnt >= 300 * 6))  // 1시간
                {
                    tServerStatus = check_server_status();

                    if (mTheMode == "Server" & tServerStatus == false)
                    {
                        // Server -> Local
                        change_mode_server_to_local();
                        synclink_log("모드전환 [서버 -> 로컬]");
                    }
                    else if (mTheMode == "Local" & tServerStatus == true)
                    {
                        // Local -> Server
                        change_mode_local_to_server();
                        synclink_log("모드전환 [로컬 -> 서버]");
                    }
                    else
                    {
                        // Skip
                    }
                }



                if (mSyncLinkWaitCnt >= 300 * 6) // 10 * 6분 = 1시간
                {
                    mSyncLinkWaitCnt = 0;

                    if (mTheMode == "Server")
                    {
                        if (mIsLogin == "Y")
                        {
                            // 1.서버원장 다운로드
                            String ver_server = get_version_server();
                            String ver_local = get_version_local();

                            if (ver_server == "" | ver_local == "")
                            {
                                // 에러
                                synclink_log("다운로드 : 원장버전체크 에러");
                            }
                            else
                            {
                                if (string.Compare(ver_server, ver_local) != 0)
                                {
                                    sync_data_server_to_local();
                                    synclink_log("다운로드 : 원장 " + ver_local + "-> " + ver_server);

                                    Thread.Sleep(1000 * 2); // XX초
                                }
                                else
                                {
                                    // 원장동일하면 Skip
                                    synclink_log("다운로드 : 원장동일 Skip");
                                }
                            }

                            // 2. 로컬레코드 업로드
                            int order_cnt = 0;
                            int record_cnt = get_local_record_cnt(out order_cnt);


                            if (record_cnt > 0)
                            {
                                synclink_log("업로드 : 대상건수 주문=" + order_cnt + " | 레코드=" + record_cnt);
                                int upload_cnt = upload_local_record();
                            }
                            else
                            {
                                // Skip
                                synclink_log("업로드 : 대상없음 Skip");
                            }
                        }
                        else
                        {
                            // 로그인전이면 skip
                            synclink_log("미로그인 Skip");
                        }
                    }
                    else if (mTheMode == "Local")
                    {
                        // 할일없음.
                        synclink_log("로컬모드 Skip");
                    }
                }
            }

        }



        private void change_mode_server_to_local()
        {
            mTheMode = "Local";

            // "로컬모드"
            lblLocalModeTitle.BeginInvoke(new Action(() => lblLocalModeTitle.Visible = true));
            // 로컬모드 테마 적용
            btnBusiness.BeginInvoke(new Action(() => btnBusiness.Enabled = false));
            btnReports.BeginInvoke(new Action(() => btnReports.Enabled = false));
            btnSupport.BeginInvoke(new Action(() => btnSupport.Enabled = false));
        }

        private void change_mode_local_to_server()
        {
            mTheMode = "Server";

            // "로컬모드"
            lblLocalModeTitle.BeginInvoke(new Action(() => lblLocalModeTitle.Visible = false));
            // 로컬모드 테마 적용
            btnBusiness.BeginInvoke(new Action(() => btnBusiness.Enabled = true));
            btnReports.BeginInvoke(new Action(() => btnReports.Enabled = true));
            btnSupport.BeginInvoke(new Action(() => btnSupport.Enabled = true));
        }

        public static String get_version_server()
        {

            //?? 버전파라메터만 수신할수 있도록.. 버전외 이미지 등은 제외
            String sUrl = "basicDbVer?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["sites"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        return arr[0]["basicDbVer"].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }


        public static String get_version_local()
        {
            String sql = "SELECT * FROM site";
            SQLiteDataReader dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                return dr["basicDbVer"].ToString();
            }

            return "0";

        }

        private int get_local_record_cnt(out int order_cnt)
        {
            order_cnt = 0;
            int record_cnt = 0;

            //
            String sql = "SELECT count(*) as cnt FROM orders";
            SQLiteDataReader dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                record_cnt += convert_number(dr["cnt"].ToString());
                order_cnt = record_cnt;
            }
            dr.Close();

            sql = "SELECT count(*) as cnt FROM orderItem";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                record_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();


            sql = "SELECT count(*) as cnt FROM orderOptionItem";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                record_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            //
            sql = "SELECT count(*) as cnt FROM payment";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                record_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            //
            sql = "SELECT count(*) as cnt FROM paymentCash";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                record_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            //
            sql = "SELECT count(*) as cnt FROM paymentCard";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                record_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            return record_cnt;

        }

        private int upload_local_record()
        {
            int cnt = 0;
            int upload_cnt = 0;
            int error_cnt = 0;

            // orders
            cnt = 0;
            String sql = "SELECT * FROM orders";
            SQLiteDataReader dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["orderDate"] = dr["orderDate"].ToString();
                parameters["orderTime"] = dr["orderTime"].ToString();
                parameters["tranType"] = dr["tranType"].ToString();
                parameters["cnt"] = dr["cnt"].ToString();
                parameters["isCancel"] = dr["isCancel"].ToString();

                if (mRequestPost("orders", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM orders WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);
                        cnt++;
                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }

            }
            dr.Close();

            upload_cnt += cnt;

            //
            synclink_log("업로드 : orders = " + cnt);
            Thread.Sleep(1000 * 1); // 1초


            // orderItem
            cnt = 0;
            sql = "SELECT * FROM orderItem";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["orderDate"] = dr["orderDate"].ToString();
                parameters["orderTime"] = dr["orderTime"].ToString();
                parameters["tranType"] = dr["tranType"].ToString();
                parameters["goodsCode"] = dr["goodsCode"].ToString();
                parameters["goodsName"] = dr["goodsName"].ToString();

                parameters["cnt"] = dr["cnt"].ToString();
                parameters["amt"] = dr["amt"].ToString();
                parameters["ticketYn"] = dr["ticketYn"].ToString();
                parameters["taxFree"] = dr["taxFree"].ToString();
                parameters["dcAmount"] = dr["dcAmount"].ToString();

                parameters["dcrType"] = dr["dcrType"].ToString();
                parameters["dcrDes"] = dr["dcrDes"].ToString();
                parameters["dcrValue"] = dr["dcrValue"].ToString();
                parameters["payClass"] = dr["payClass"].ToString();
                parameters["ticketNo"] = dr["ticketNo"].ToString();

                parameters["isCancel"] = dr["isCancel"].ToString();
                parameters["shopCode"] = dr["shopCode"].ToString();
                parameters["shopOrderNo"] = dr["shopOrderNo"].ToString();

                if (mRequestPost("orderItem", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM orderItem WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);
                        cnt++;
                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }
            }
            dr.Close();

            upload_cnt += cnt;

            //
            synclink_log("업로드 : orderItem = " + cnt);
            Thread.Sleep(1000 * 1); // 1초



            // orderOptionItem
            cnt = 0;
            sql = "SELECT * FROM orderOptionItem";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["optionNo"] = dr["optionNo"].ToString();

                parameters["orderDate"] = dr["orderDate"].ToString();
                parameters["orderTime"] = dr["orderTime"].ToString();

                parameters["goodsCode"] = dr["goodsCode"].ToString();

                parameters["optionCode"] = dr["optionCode"].ToString();
                parameters["optionItemNo"] = dr["optionItemNo"].ToString();
                parameters["optionItemName"] = dr["optionItemName"].ToString();

                parameters["cnt"] = dr["cnt"].ToString();
                parameters["amt"] = dr["amt"].ToString();
                parameters["isCancel"] = dr["isCancel"].ToString();

                if (mRequestPost("orderOptionItem", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM orderOptionItem WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);
                        cnt++;
                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }
            }
            dr.Close();

            upload_cnt += cnt;

            //
            synclink_log("업로드 : orderOptionItem = " + cnt);
            Thread.Sleep(1000 * 1); // 1초




            // payment
            cnt = 0;
            sql = "SELECT * FROM payment";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["payDate"] = dr["payDate"].ToString();
                parameters["payTime"] = dr["payTime"].ToString();
                parameters["tranType"] = dr["tranType"].ToString();
                parameters["payClass"] = dr["payClass"].ToString();
                parameters["billNo"] = dr["billNo"].ToString();

                parameters["netAmount"] = dr["netAmount"].ToString();
                parameters["amountCash"] = dr["amountCash"].ToString();
                parameters["amountCard"] = dr["amountCard"].ToString();
                parameters["amountEasy"] = dr["amountPoint"].ToString();
                parameters["amountPoint"] = dr["amountEasy"].ToString();
                parameters["amountCert"] = dr["amountCert"].ToString();

                parameters["dcAmount"] = dr["dcAmount"].ToString();
                parameters["isCancel"] = dr["isCancel"].ToString();

                if (mRequestPost("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM payment WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);
                        cnt++;
                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }
            }
            dr.Close();

            upload_cnt += cnt;

            //
            synclink_log("업로드 : payment = " + cnt);
            Thread.Sleep(1000 * 1); // 1초



            // paymentCash
            cnt = 0;
            sql = "SELECT * FROM paymentCash";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["payDate"] = dr["payDate"].ToString();
                parameters["payTime"] = dr["payTime"].ToString();
                parameters["payType"] = dr["payType"].ToString();
                parameters["tranType"] = dr["tranType"].ToString();
                parameters["payClass"] = dr["payClass"].ToString();

                parameters["ticketNo"] = dr["ticketNo"].ToString();
                parameters["paySeq"] = dr["paySeq"].ToString();
                parameters["tranDate"] = dr["tranDate"].ToString();
                parameters["amount"] = dr["amount"].ToString();
                parameters["receiptType"] = dr["receiptType"].ToString();

                parameters["issuedMethodNo"] = dr["issuedMethodNo"].ToString();
                parameters["authNo"] = dr["authNo"].ToString();
                parameters["tranSerial"] = dr["tranSerial"].ToString();
                parameters["isCancel"] = dr["isCancel"].ToString();
                parameters["vanCode"] = dr["vanCode"].ToString();

                if (mRequestPost("paymentCash", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM paymentCash WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);
                        cnt++;
                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }
            }
            dr.Close();

            upload_cnt += cnt;

            //
            synclink_log("업로드 : paymentCash = " + cnt);
            Thread.Sleep(1000 * 1); // 1초



            // paymentCard
            cnt = 0;
            sql = "SELECT * FROM paymentCard";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["payDate"] = dr["payDate"].ToString();
                parameters["payTime"] = dr["payTime"].ToString();
                parameters["payType"] = dr["payType"].ToString();
                parameters["tranType"] = dr["tranType"].ToString();
                parameters["payClass"] = dr["payClass"].ToString();

                parameters["ticketNo"] = dr["ticketNo"].ToString();
                parameters["paySeq"] = dr["paySeq"].ToString();
                parameters["tranDate"] = dr["tranDate"].ToString();
                parameters["amount"] = dr["amount"].ToString();
                parameters["taxAmount"] = dr["taxAmount"].ToString();

                parameters["freeAmount"] = dr["freeAmount"].ToString();
                parameters["serviceAmt"] = dr["serviceAmt"].ToString();
                parameters["tax"] = dr["tax"].ToString();
                parameters["install"] = dr["install"].ToString();
                parameters["authNo"] = dr["authNo"].ToString();

                parameters["cardNo"] = dr["cardNo"].ToString();
                parameters["cardName"] = dr["cardName"].ToString();
                parameters["isuCode"] = dr["isuCode"].ToString();
                parameters["acqCode"] = dr["acqCode"].ToString();
                parameters["merchantNo"] = dr["merchantNo"].ToString();

                parameters["tranSerial"] = dr["tranSerial"].ToString();
                parameters["signPath"] = dr["signPath"].ToString();
                parameters["giftChange"] = dr["giftChange"].ToString();
                parameters["isCancel"] = dr["isCancel"].ToString();
                parameters["vanCode"] = dr["vanCode"].ToString();
                parameters["isCup"] = dr["isCup"].ToString();

                if (mRequestPost("paymentCard", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM paymentCard WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);
                        cnt++;
                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }
            }
            dr.Close();

            upload_cnt += cnt;

            //
            synclink_log("업로드 : paymentCard = " + cnt);
            Thread.Sleep(1000 * 1); // 1초





            // paymentCert
            cnt = 0;
            sql = "SELECT * FROM paymentCert";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["payDate"] = dr["payDate"].ToString();
                parameters["payTime"] = dr["payTime"].ToString();
                parameters["payType"] = dr["payType"].ToString();
                parameters["tranType"] = dr["tranType"].ToString();
                parameters["payClass"] = dr["payClass"].ToString();

                parameters["ticketNo"] = dr["ticketNo"].ToString();
                parameters["paySeq"] = dr["paySeq"].ToString();
                parameters["tranDate"] = dr["tranDate"].ToString();
                parameters["amount"] = dr["amount"].ToString();

                parameters["couponNo"] = dr["coupondNo"].ToString();

                parameters["isCancel"] = dr["isCancel"].ToString();
                parameters["vanCode"] = dr["vanCode"].ToString();

                if (mRequestPost("paymentCert", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM paymentCert WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);
                        cnt++;
                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }
            }
            dr.Close();

            upload_cnt += cnt;

            //
            synclink_log("업로드 : paymentCash = " + cnt);
            Thread.Sleep(1000 * 1); // 1초






            if (error_cnt > 0)
            {
                synclink_log("업로드 : 오류 = " + error_cnt);
            }



            return upload_cnt;
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


            // 이사업자의 포스번호 목록
            //mPosNoList.Initialize();
            //mCornerCode.Initialize(); // 코너 코드
            //mCornerName.Initialize(); // 코너 명





            mUserID = "";
            mUserName = "";

            tbPW.Text = "";

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

            if (mTheMode == "Server")
            {
                server_login();

            }
            else if (mTheMode == "Local")
            {
                local_mode();
            }
            else
            {
                // 설치후 최초실행
                server_login();
            }


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


            // 데이터 체크 임시
            //Form f = new frmCheckData();
            //f.Show();

        }


        private void server_login()
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
                }
                else if (ret == DialogResult.Yes) // TEST
                {
                    lblIsTest.Visible = true;

                }
                else
                {
                    return;
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
                    }
                    else
                    {
                        MessageBox.Show("로그인오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + "RequestPost Login", "thepos");
                    return;
                }


            }




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


            //////////////////////////////////
            // 개시마감 
            String biz_date = "";
            String biz_status = "";
            mBizDate = "";

            if (get_bizdate_status(ref biz_status, ref biz_date))
            {
                if (biz_status == "A")   // A영업중 F영업마감
                {
                    mBizDate = biz_date;
                }
                else  // F:마감 Y:집계완료 X:초기상태
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("개시마감관리 오류\n서버에서 정보를 읽어오지 못했습니다.", "thepos");
                return;
            }
        }



        private void local_mode()
        {
            frmLocalModeInfo frm = new frmLocalModeInfo();
            frm.ShowDialog();

            if (!mReturn)
            {
                return;
            }

            mUserID = "";
            mUserName = "";
            mPosNo = "";


            //
            mPayClass = "OR";


            // 로컬DB -> 메모리 
            sync_data_local_to_memory();  // 함수내에서 mPosNo를 구한다.


            lblLocalModeTitle.Visible = true;  // 로컬모드 표시

            panelLogin.Visible = false;

            lblSiteAlias.Text = mSiteAlias;
            lblSiteName.Text = mSiteName;
            lblPosNo.Text = mPosNo;
            lblUserName.Text = "";
            lblCallCenterNo.Text = mCallCenterNo;

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

                            else if (arr[i]["setupCode"].ToString() == "CouponChPM") mCouponChPM = arr[i]["setupValue"].ToString();

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



        public void sync_data_server_to_local()
        {
            // 1. site -> 마지막에 다운. 에러감안한 버전관리


            // 2. goodsGroup
            if (true)
            {
                String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM goodsGroup");

                        //
                        String data = mObj["goodsGroups"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String siteId = arr[i]["siteId"].ToString();
                            String posNo = arr[i]["posNo"].ToString();
                            String groupCode = arr[i]["groupCode"].ToString();
                            String groupName = arr[i]["groupName"].ToString();
                            int locateX = int.Parse(arr[i]["locateX"].ToString());
                            int locateY = int.Parse(arr[i]["locateY"].ToString());
                            int sizeX = int.Parse(arr[i]["sizeX"].ToString());
                            int sizeY = int.Parse(arr[i]["sizeY"].ToString());
                            String soldout = arr[i]["soldout"].ToString();

                            // Insert
                            String sql = "INSERT INTO goodsGroup (siteId, posNo, groupCode, groupName, locateX, locateY, sizeX, sizeY, soldout) " +
                            "values ('" + siteId + "','" + posNo + "','" + groupCode + "','" + groupName + "'," + locateX + "," + locateY + "," + sizeX + "," + sizeY + ",'" + soldout + "')";
                            ret = sql_excute_local_db(sql);
                        }

                        synclink_log("다운로드 : goodsGroup = " + arr.Count);
                        Thread.Sleep(1000 * 1); // 1초
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
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
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM goodsItemAndGoods");

                        //
                        String data = mObj["goodsItems"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String siteId = arr[i]["siteId"].ToString();
                            String posNo = arr[i]["posNo"].ToString();
                            String groupCode = arr[i]["groupCode"].ToString();
                            String goodsCode = arr[i]["goodsCode"].ToString();
                            String goodsName = arr[i]["goodsName"].ToString();
                            String shopCode = arr[i]["shopCode"].ToString();
                            int amt = int.Parse(arr[i]["amt"].ToString());
                            String ticketYn = arr[i]["ticketYn"].ToString();
                            String taxFree = arr[i]["taxFree"].ToString();
                            String cutout = arr[i]["cutout"].ToString();
                            String soldout = arr[i]["soldout"].ToString();
                            int locateX = int.Parse(arr[i]["locateX"].ToString());
                            int locateY = int.Parse(arr[i]["locateY"].ToString());
                            int sizeX = int.Parse(arr[i]["sizeX"].ToString());
                            int sizeY = int.Parse(arr[i]["sizeY"].ToString());
                            String optionTemplateId = arr[i]["optionTemplateId"].ToString();

                            String sql = "INSERT INTO goodsItemAndGoods (siteId, posNo, groupCode, goodsCode, goodsName, shopCode, amt, ticketYn, taxFree, cutout, soldout, locateX, locateY, sizeX, sizeY, optionTemplateId) " +
                                "values ('" + siteId + "','" + posNo + "','" + groupCode + "','" + goodsCode + "','" + goodsName + "','" + shopCode + "'," + amt + ",'" + ticketYn + "','" + taxFree + "','" + cutout + "','" + soldout + "'," + locateX + "," + locateY + "," + sizeX + "," + sizeY + ",'" + optionTemplateId + "')";
                            ret = sql_excute_local_db(sql);
                        }

                        synclink_log("다운로드 : goodsItemAndGoods = " + arr.Count);
                        Thread.Sleep(1000 * 1); // 1초
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            // 3-0 optionTemplate
            if (true)
            {
                String sUrl = "optionTemplate?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM optionTemplate");

                        String strCnt = mObj["cnt"].ToString();
                        if (strCnt == "0")
                        {
                            synclink_log("다운로드 : optionTemplate => Skip...");
                        }
                        else
                        {
                            //
                            String data = mObj["optionTemp"].ToString();
                            JArray arr = JArray.Parse(data);

                            for (int i = 0; i < arr.Count; i++)
                            {
                                String siteId = arr[i]["siteId"].ToString();
                                String optionTemplateId = arr[i]["optionTemplateId"].ToString();
                                String optionTemplateName = arr[i]["optionTemplateName"].ToString();


                                String sql = "INSERT INTO optionTemplate (siteId, optionTemplateId, optionTemplateName) " +
                                    "values ('" + siteId + "','" + optionTemplateId + "','" + optionTemplateName + "')";
                                ret = sql_excute_local_db(sql);
                            }

                            synclink_log("다운로드 : optionTemplate = " + arr.Count);
                        }

                        Thread.Sleep(1000 * 1); // 1초
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



            // 3-1. tempOption
            if (true)
            {
                String sUrl = "tempOption?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM tempOption");

                        String strCnt = mObj["cnt"].ToString();
                        if (strCnt == "0")
                        {
                            synclink_log("다운로드 : tempOption => Skip...");
                        }
                        else
                        {
                            //
                            String data = mObj["tempOption"].ToString();
                            JArray arr = JArray.Parse(data);

                            for (int i = 0; i < arr.Count; i++)
                            {
                                String siteId = arr[i]["siteId"].ToString();
                                String optionTemplateId = arr[i]["optionTemplateId"].ToString();
                                String optionId = arr[i]["optionId"].ToString();
                                int optionSeq = int.Parse(arr[i]["optionSeq"].ToString());
                                String isTurnoff = arr[i]["isTurnoff"].ToString();
                                String nextOptionId = arr[i]["nextOptionId"].ToString();
                                String optionName = arr[i]["optionName"].ToString();
                                String optionNameEn = arr[i]["optionNameEn"].ToString();
                                String optionNameCh = arr[i]["optionNameCh"].ToString();
                                String optionNameJp = arr[i]["optionNameJp"].ToString();

                                String sql = "INSERT INTO tempOption (siteId, optionTemplateId, optionId, optionSeq, isTurnoff, nextOptionId, optionName, optionNameEn, optionNameCh, optionNameJp) " +
                                    "values ('" + siteId + "','" + optionTemplateId + "','" + optionId + "'," + optionSeq + ",'" + isTurnoff + "','" + nextOptionId + "','" + optionName + "','" + optionNameEn + "','" + optionNameCh + "','" + optionNameJp + "')";
                                ret = sql_excute_local_db(sql);
                            }

                            synclink_log("다운로드 : tempOption = " + arr.Count);
                        }

                        Thread.Sleep(1000 * 1); // 1초
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



            // 3-2. tempOptionItem
            if (true)
            {
                String sUrl = "tempOptionItem?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM tempOptionItem");

                        String strCnt = mObj["cnt"].ToString();
                        if (strCnt == "0")
                        {
                            synclink_log("다운로드 : tempOptionItem => Skip...");
                        }
                        else
                        {
                            //
                            String data = mObj["optionItem"].ToString();
                            JArray arr = JArray.Parse(data);

                            for (int i = 0; i < arr.Count; i++)
                            {
                                String siteId = arr[i]["siteId"].ToString();
                                String optionTemplateId = arr[i]["optionTemplateId"].ToString();
                                String optionId = arr[i]["optionId"].ToString();
                                String optionItemId = arr[i]["optionItemId"].ToString();
                                int optionItemSeq = int.Parse(arr[i]["optionItemSeq"].ToString());
                                String linkOptionId = arr[i]["linkOptionId"].ToString();
                                String optionItemName = arr[i]["optionItemName"].ToString();
                                String optionItemNameEn = arr[i]["optionItemNameEn"].ToString();
                                String optionItemNameCh = arr[i]["optionItemNameCh"].ToString();
                                String optionItemNameJp = arr[i]["optionItemNameJp"].ToString();
                                int optionItemAmt = int.Parse(arr[i]["optionItemAmt"].ToString());

                                String sql = "INSERT INTO tempOptionItem (siteId, optionTemplateId, optionId, optionItemId, optionItemSeq, linkOptionId, optionItemName, optionItemNameEn, optionItemNameCh, optionItemNameJp, optionItemAmt) " +
                                    "values ('" + siteId + "','" + optionTemplateId + "','" + optionId + "','" + optionItemId + "'," + optionItemSeq + ",'" + linkOptionId + "','" + optionItemName + "','" + optionItemNameEn + "','" + optionItemNameCh + "','" + optionItemNameJp + "'," + optionItemAmt + ")";
                                ret = sql_excute_local_db(sql);
                            }

                            synclink_log("다운로드 : tempOptionItem = " + arr.Count);
                        }
                        Thread.Sleep(1000 * 1); // 1초
                    }
                    else
                    {
                        MessageBox.Show("옵션아이템정보 오류. tempOptionItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }




            // 4. shop
            if (true)
            {
                String sUrl = "shop?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM shop");

                        //
                        String data = mObj["shops"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String siteId = arr[i]["siteId"].ToString();
                            string shopCode = arr[i]["shopCode"].ToString();
                            String shopName = arr[i]["shopName"].ToString();
                            String printerType = arr[i]["printerType"].ToString();
                            String networkPrinterName = arr[i]["networkPrinterName"].ToString();

                            String sql = "INSERT INTO shop (siteId, shopCode, shopName, printerType, networkPrinterName) " +
                                         "values ('" + siteId + "','" + shopCode + "','" + shopName + "','" + printerType + "','" + networkPrinterName + "')";
                            ret = sql_excute_local_db(sql);
                        }

                        synclink_log("다운로드 : shop = " + arr.Count);
                        Thread.Sleep(1000 * 1); // 1초

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            // 5. pos
            if (true)
            {
                String sUrl = "pos?siteId=" + mSiteId + "&posStatus=Y";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM pos");

                        //
                        String data = mObj["pos"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String siteId = arr[i]["siteId"].ToString();
                            String posNo = arr[i]["posNo"].ToString();
                            String macAddr = arr[i]["macAddr"].ToString();
                            String posStatus = arr[i]["posStatus"].ToString();

                            String sql = "INSERT INTO pos (siteId, posNo, macAddr, posStatus) " +
                                        "values ('" + siteId + "','" + posNo + "','" + macAddr + "','" + posStatus + "')";
                            ret = sql_excute_local_db(sql);
                        }
                        synclink_log("다운로드 : pos = " + arr.Count);
                        Thread.Sleep(1000 * 1); // 1초

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
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
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM setupPos");

                        //
                        String data = mObj["setupPos"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String siteId = arr[i]["siteId"].ToString();
                            String posNo = arr[i]["posNo"].ToString();
                            String setupCode = arr[i]["setupCode"].ToString();
                            String setupName = arr[i]["setupName"].ToString();
                            String setupValue = arr[i]["setupValue"].ToString();
                            String memo = arr[i]["memo"].ToString();

                            String sql = "INSERT INTO setupPos (siteId, posNo, setupCode, setupName, setupValue, memo) " +
                                    "values ('" + siteId + "','" + posNo + "','" + setupCode + "','" + setupName + "','" + setupValue + "','" + memo + "')";
                            ret = sql_excute_local_db(sql);
                        }
                        synclink_log("다운로드 : setupPos = " + arr.Count);
                        Thread.Sleep(1000 * 1); // 1초

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            // 7. dcrFavority
            if (true)
            {
                String sUrl = "dcrFavorite?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM dcrFavorite");

                        String strCnt = mObj["dcrCnt"].ToString();
                        if (strCnt == "0")
                        {
                            synclink_log("다운로드 : dcrFavorite => Skip...");
                        }
                        else
                        {
                            //
                            String data = mObj["dcr"].ToString();
                            JArray arr = JArray.Parse(data);

                            for (int i = 0; i < arr.Count; i++)
                            {
                                String siteId = arr[i]["siteId"].ToString();
                                int sortNo = int.Parse(arr[i]["sortNo"].ToString());
                                String dcrCode = arr[i]["dcrCode"].ToString();
                                String dcrName = arr[i]["dcrName"].ToString();
                                String dcrDes = arr[i]["dcrDes"].ToString();
                                String dcrType = arr[i]["dcrType"].ToString();
                                int dcrValue = int.Parse(arr[i]["dcrValue"].ToString());

                                String sql = "INSERT INTO dcrFavorite (siteId, sortNo, dcrCode, dcrName, dcrDes, dcrType, dcrValue) " +
                                        "values ('" + siteId + "'," + sortNo + ",'" + dcrCode + "','" + dcrName + "','" + dcrDes + "','" + dcrType + "'," + dcrValue + ")";
                                ret = sql_excute_local_db(sql);
                            }
                            synclink_log("다운로드 : dcrFavorite = " + arr.Count);
                        }

                        Thread.Sleep(1000 * 1); // 1초

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
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
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM paymentConsole");

                        String data = mObj["paymentConsoles"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String siteId = arr[i]["siteId"].ToString();
                            String posNo = arr[i]["posNo"].ToString();
                            String buttonCode = arr[i]["buttonCode"].ToString();
                            String buttonName = arr[i]["buttonName"].ToString();
                            int locateX = int.Parse(arr[i]["locateX"].ToString());
                            int locateY = int.Parse(arr[i]["locateY"].ToString());
                            int sizeX = int.Parse(arr[i]["sizeX"].ToString());
                            int sizeY = int.Parse(arr[i]["sizeY"].ToString());
                            String usage = arr[i]["usage"].ToString();

                            String sql = "INSERT INTO paymentConsole (siteId, posNo, buttonCode, buttonName, locateX, locateY, sizeX, sizeY, usage) " +
                                    "values ('" + siteId + "'," + posNo + ",'" + buttonCode + "','" + buttonName + "'," + locateX + "," + locateY + "," + sizeX + "," + sizeY + ",'" + usage + "')";
                            ret = sql_excute_local_db(sql);
                        }
                        synclink_log("다운로드 : paymentConsole = " + arr.Count);
                        Thread.Sleep(1000 * 1); // 1초

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            // 1. site -- 는 제일 마지막에.. 에러감안한 버전관리
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
                            String siteId = arr[0]["siteId"].ToString();
                            String siteName = arr[0]["siteName"].ToString();
                            String siteAlias = arr[0]["siteAlias"].ToString();
                            String registNo = arr[0]["registNo"].ToString();
                            String capName = arr[0]["capName"].ToString();
                            String bizAddr = arr[0]["bizAddr"].ToString();
                            String bizTelNo = arr[0]["bizTelNo"].ToString();
                            String ticketType = arr[0]["ticketType"].ToString();
                            String ticketMedia = arr[0]["ticketMedia"].ToString();
                            String vanCode = arr[0]["vanCode"].ToString();
                            String callCenterNo = arr[0]["callCenterNo"].ToString();
                            String basicDbVer = arr[0]["basicDbVer"].ToString();

                            // Delete
                            int ret = sql_excute_local_db("DELETE FROM site");

                            // Insert
                            String sql = "INSERT INTO site (siteId, siteName, siteAlias, registNo, capName, bizAddr, bizTelNo, ticketType, ticketMedia, vanCode, callCenterNo, basicDbVer) " +
                                         "values ('" + siteId + "','" + siteName + "','" + siteAlias + "','" + registNo + "','" + capName + "','" + bizAddr + "','" + bizTelNo + "','" + ticketType + "','" + ticketMedia + "','" + vanCode + "','" + callCenterNo + "','" + basicDbVer + "')";
                            ret = sql_excute_local_db(sql);
                        }
                        synclink_log("다운로드 : site = " + arr.Count);
                        Thread.Sleep(1000 * 1); // 1초

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            //
            //MessageBox.Show("다운로드 완료.", "thepos");

        }



        private void sync_data_local_to_memory ()
        {
            SQLiteDataReader dr;

            // 1. site
            if (true)
            {
                dr = sql_select_local_db("SELECT * FROM site");
                while (dr.Read())
                {
                    mSiteName = dr["siteName"].ToString();
                    mSiteAlias = dr["siteAlias"].ToString();
                    mRegistNo = dr["registNo"].ToString();
                    mCapName = dr["capName"].ToString();
                    mBizAddr = dr["bizAddr"].ToString();
                    mBizTelNo = dr["bizTelNo"].ToString();
                    mTicketType = dr["ticketType"].ToString();
                    mTicketMedia = dr["ticketMedia"].ToString();
                    mVanCode = dr["vanCode"].ToString();
                    mCallCenterNo = dr["callCenterNo"].ToString();
                }
                dr.Close();
            }


            // 2. goodsGroup
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM goodsGroup");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();


                mGoodsGroup = new GoodsGroup[rowcnt];

                dr = sql_select_local_db("SELECT * FROM goodsGroup");
                int i = 0;
                while (dr.Read())
                {
                    mGoodsGroup[i].group_code = dr["groupCode"].ToString();
                    mGoodsGroup[i].group_name = dr["groupName"].ToString();
                    mGoodsGroup[i].column = int.Parse(dr["locateX"].ToString());
                    mGoodsGroup[i].row = int.Parse(dr["locateY"].ToString());
                    mGoodsGroup[i].columnspan = int.Parse(dr["sizeX"].ToString());
                    mGoodsGroup[i].rowspan = int.Parse(dr["sizeY"].ToString());
                    mGoodsGroup[i].soldout = dr["soldout"].ToString();
                    i++;
                }
                dr.Close();
            }


            // 3. goodsItemAndGoods
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM goodsItemAndGoods");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mGoodsItem = new GoodsItem[rowcnt];


                dr = sql_select_local_db("SELECT * FROM goodsItemAndGoods");

                int i = 0;
                while (dr.Read())
                {
                    mGoodsItem[i].group_code = dr["groupCode"].ToString();
                    mGoodsItem[i].goods_code = dr["goodsCode"].ToString();
                    mGoodsItem[i].goods_name = dr["goodsName"].ToString();
                    mGoodsItem[i].shop_code = dr["shopCode"].ToString();
                    mGoodsItem[i].amt = int.Parse(dr["amt"].ToString());
                    mGoodsItem[i].ticket = dr["ticketYn"].ToString();
                    mGoodsItem[i].taxfree = dr["taxFree"].ToString();
                    mGoodsItem[i].cutout = dr["cutout"].ToString();
                    mGoodsItem[i].soldout = dr["soldout"].ToString();
                    mGoodsItem[i].column = int.Parse(dr["locateX"].ToString());
                    mGoodsItem[i].row = int.Parse(dr["locateY"].ToString());
                    mGoodsItem[i].columnspan = int.Parse(dr["sizeX"].ToString());
                    mGoodsItem[i].rowspan = int.Parse(dr["sizeY"].ToString());
                    mGoodsItem[i].option_template_id = dr["optionTemplateId"].ToString();

                    // 면세상픔은 상품명앞에 *을 붙인다.
                    if (mGoodsItem[i].taxfree == "1")
                    {
                        mGoodsItem[i].goods_name = "*" + mGoodsItem[i].goods_name;
                    }

                    i++;
                }
                dr.Close();
            }


            // 3-0. optionTemplate
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM optionTemplate");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mOptionTemplate = new OptionTemplate[rowcnt];

                dr = sql_select_local_db("SELECT * FROM optionTemplate");

                int i = 0;
                while (dr.Read())
                {
                    mOptionTemplate[i].option_template_id = dr["optionTemplateId"].ToString();
                    mOptionTemplate[i].option_template_name = dr["optionTemplateName"].ToString();

                    i++;
                }
                dr.Close();
            }

            // 3-1. tempOption
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM tempOption");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mTempOption = new TempOption[rowcnt];

                dr = sql_select_local_db("SELECT * FROM tempOption");

                int i = 0;
                while (dr.Read())
                {
                    mTempOption[i].option_template_id = dr["optionTemplateId"].ToString();
                    mTempOption[i].option_id = dr["optionId"].ToString();
                    mTempOption[i].option_seq = int.Parse(dr["optionSeq"].ToString());
                    mTempOption[i].is_turnoff = dr["isTurnoff"].ToString();
                    mTempOption[i].option_name = dr["optionName"].ToString();

                    i++;
                }
                dr.Close();
            }


            // 3-2. tempOptionItem
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM tempOptionItem");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mTempOptionItem = new TempOptionItem[rowcnt];

                dr = sql_select_local_db("SELECT * FROM tempOptionItem");

                int i = 0;
                while (dr.Read())
                {
                    mTempOptionItem[i].option_template_id = dr["optionTemplateId"].ToString();
                    mTempOptionItem[i].option_id = dr["optionId"].ToString();
                    mTempOptionItem[i].option_item_id = dr["optionItemId"].ToString();
                    mTempOptionItem[i].option_item_seq = int.Parse(dr["optionItemSeq"].ToString());
                    mTempOptionItem[i].link_option_id = dr["linkOptionId"].ToString();
                    mTempOptionItem[i].option_item_name = dr["optionItemName"].ToString();
                    mTempOptionItem[i].option_item_amt = int.Parse(dr["optionItemAmt"].ToString());

                    i++;
                }
                dr.Close();
            }



            // 4. shop
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM shop");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mShop = new Shop[rowcnt];


                dr = sql_select_local_db("SELECT * FROM shop");
                int i = 0;
                while (dr.Read())
                {
                    mShop[i].shop_code = dr["shopCode"].ToString();
                    mShop[i].shop_name = dr["shopName"].ToString();
                    mShop[i].printer_type = dr["printerType"].ToString();
                    mShop[i].network_printer_name = dr["networkPrinterName"].ToString();

                    i++;
                }
                dr.Close();
            }


            // 5. pos
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM pos");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mPosNoList = new String[rowcnt];


                dr = sql_select_local_db("SELECT * FROM pos");
                int i = 0;
                while (dr.Read())
                {
                    mPosNoList[i] = dr["posNo"].ToString();

                    // 내 포스번호 구하기
                    if (mMacAddr == dr["macAddr"].ToString())
                    {
                        mPosNo = dr["posNo"].ToString();
                    }

                    i++;
                }
                dr.Close();
            }


            // 6. setupPos
            if (true)
            {
                dr = sql_select_local_db("SELECT * FROM setupPos");
                int i = 0;
                while (dr.Read())
                {
                    if (dr["setupCode"].ToString() == "BillPrinterPort") mBillPrinterPort = dr["setupValue"].ToString();
                    else if (dr["setupCode"].ToString() == "BillPrinterSpeed") mBillPrinterSpeed = dr["setupValue"].ToString();
                    else if (dr["setupCode"].ToString() == "TicketPrinterPort") mTicketPrinterPort = dr["setupValue"].ToString();
                    else if (dr["setupCode"].ToString() == "TicketPrinterSpeed") mTicketPrinterSpeed = dr["setupValue"].ToString();
                    
                    else if (dr["setupCode"].ToString() == "MobileExchangeType") mMobileExchangeType = dr["setupValue"].ToString();
                    else if (dr["setupCode"].ToString() == "PrintExchangeType") mPrintExchangeType = dr["setupValue"].ToString();

                    else if (dr["setupCode"].ToString() == "PosType") mPosType = dr["setupValue"].ToString();
                    else if (dr["setupCode"].ToString() == "CustomerMonitor") mCustomerMonitor = dr["setupValue"].ToString();
                    else if (dr["setupCode"].ToString() == "CouponChPM") mCouponChPM = dr["setupValue"].ToString();
                    i++;
                }
                dr.Close();
            }


            // 7. dcrFavorite
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM dcrFavorite");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mDCR = new DCR[rowcnt];


                dr = sql_select_local_db("SELECT * FROM dcrFavorite");
                int i = 0;
                while (dr.Read())
                {
                    mDCR[i].dcr_code = dr["dcrCode"].ToString();
                    mDCR[i].dcr_name = dr["dcrName"].ToString();
                    mDCR[i].dcr_des = dr["dcrDes"].ToString();
                    mDCR[i].dcr_type = dr["dcrType"].ToString();
                    mDCR[i].dcr_value = Int32.Parse(dr["dcrValue"].ToString());
                    i++;
                }
                dr.Close();
            }


            // 8. paymentConsole
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM paymentConsole");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mPayConsol = new PayConsol[rowcnt];


                dr = sql_select_local_db("SELECT * FROM paymentConsole");
                int i = 0;
                while (dr.Read())
                {
                    mPayConsol[i].column = int.Parse(dr["locateX"].ToString());
                    mPayConsol[i].row = int.Parse(dr["locateY"].ToString());
                    mPayConsol[i].columnspan = int.Parse(dr["sizeX"].ToString());
                    mPayConsol[i].rowspan = int.Parse(dr["sizeY"].ToString());
                    mPayConsol[i].code = dr["buttonCode"].ToString();
                    i++;
                }
                dr.Close();
            }
        }




        // 판매관리
        private void btnSales_Click(object sender, EventArgs e)
        {
            // 영업상태
            // 영업중상태: 개시후 마감전
            // 영업마감상태 : 마감이후 개시전



            if (mTheMode == "Local")  // 로컬모드
            {
                // 영업일자 입력받은 그대로 사용... 
                //mBizDate = ;

                panelDivision.Visible = true;
                panelDivision.Controls.Clear();

                frmSales fForm = new frmSales() { TopLevel = false, TopMost = true };
                panelDivision.Controls.Add(fForm);
                fForm.Show();


            }
            else if (mTheMode == "Server")
            {
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
            else
            {

            }

        }

        // 영업관리
        private void btnBusiness_Click(object sender, EventArgs e)
        {
            panelDivision.Visible = true;
            panelDivision.Controls.Clear();

            frmBusiness fForm = new frmBusiness() { TopLevel = false, TopMost = true };
            panelDivision.Controls.Add(fForm);
            fForm.Show();

        }

        // 매출관리
        private void btnReports_Click(object sender, EventArgs e)
        {
            panelDivision.Visible = true;
            panelDivision.Controls.Clear();

            frmReports fForm = new frmReports() { TopLevel = false, TopMost = true };
            panelDivision.Controls.Add(fForm);
            fForm.Show();

        }

        // 환경설정
        private void btnSetup_Click(object sender, EventArgs e)
        {
            panelDivision.Visible = true;
            panelDivision.Controls.Clear();

            frmSetup fForm = new frmSetup() { TopLevel = false, TopMost = true };
            panelDivision.Controls.Add(fForm);
            fForm.Show();

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmExit fExit = new frmExit();
            DialogResult ret =  fExit.ShowDialog();

            if (ret == DialogResult.Yes)  // 로그아웃
            {
                //? 로그아웃 프로세스 필요


                clear_login_init();  // 초기화

                panelLogin.Visible = true;


            }
            else if (ret == DialogResult.Retry)
            {
                //??



            }
            else if (ret == DialogResult.OK)  // 종료
            {
                this.Close();
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
            frmSysAdmin frmSysAdmin = new frmSysAdmin(sysadmin_pw_patern);
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
                    synclink_log("server stat : true");
                    return true;
                }
                else
                {
                    synclink_log("server stat : false(1)");
                    return false;
                }
            }
            else
            {
                synclink_log("server stat : false(2)");
                return false;
            }
        }

        private void synclink_log(String msg)
        {
            // Insert
            String sql = "INSERT INTO syncLink (sl_date, sl_time, biz_dt, msg) " +
                         "values ('" + get_today_date() + "', '" + get_today_time() + "', '" + mBizDate + "', '" + msg + "')";
            int ret = sql_excute_local_db(sql);
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            //원격지원
            System.Diagnostics.Process.Start("https://367.co.kr/112/");
        }


        private void btnReqSupport_Click(object sender, EventArgs e)
        {
            //원격지원
            System.Diagnostics.Process.Start("https://367.co.kr/112/");
        }

        private void btnReqUser_Click(object sender, EventArgs e)
        {
            frmReqUser fReqUser = new frmReqUser();
            fReqUser.ShowDialog();
        }

    }
}
