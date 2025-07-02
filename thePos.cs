﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PrinterUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Security.Policy;
using System.Collections;
using System.IO;
using static BrightIdeasSoftware.ObjectListView;

/* 
 
로그인 정보



"userId": "1111",
"userPw": "ARyUXzDOLLr8RS85hA8CVpMznEI=",
"macAddr": "D85ED3776002"

 



// ▲ △ ◀ ◁ ▶ ▷ ▼ ▽  <＋－＜＞↵ ↵ ⏎  ＋ ＜＞ △	▲	▽	▼ ⪤ □ × × ◻ ■ ▽ ◇ △ ▯ ▭ ▬ ▮ ◆ ◇ □ ◪  ₩ ◆ ⁜ ⁘ ⌂ □ ■ ◆ ◇
// (*‿*✿) ٩(✪ꀾ⍟༶)و/// ♡◟(●•ᴗ•●)◞♡ ◄:•D .ᐟ ヾ(・ᆺ・✿)ﾉﾞ φ(◎◎ヘ)  ☑☆★☘︎ ☁︎ ⚑ 🟨 
// ð ✕ ◈ ◆ ⬅ 〈 ˂
// Music Title In Here
// 0:00 ━━●─── 4:00
// ⇆      ◁ ❚▮▮||||||||❚ ▷     ↻       ▮    원화기호: ₩


 

## 영수증 프린터 에러

" 파일이 이미 있으므로 만들수 없습니다."

- USB포트 문제 -> 특정포트는 잘 됨. 무슨 드라이버를 갈았더니 되는것 같았음.
- NVCAT 에이전트의 프린터포트 설정과는 상관없음.


 */


namespace thepos
{
    public class thePos
    {

        // 배포시 버전관리 - 로그와 연동

        public static String mAppVersion = "TPW1-2025-012";   // 

        public static String mTheposColor = "#3380cc";
        //public static String mTheposColor = "#808080";




        public struct CardTemp
        {
            public int amount;
            public string card_no;
            public string auth_no;
            public string install;
            public string card_name;
            public string isu_code;
        }



        // //////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // 로그인후 다운로드되어야할 환경값들
        //

        // //////////////////////////////////////////////////////////////////////////////////////////
        // 사이트 설정값
        public static String mSiteId = "";
        public static String mSiteName;         // 매장명
        public static String mSiteAlias;        // 매장명
        public static String mCapName;          // 대표자명
        public static String mRegistNo;         // 사업자번호
        public static String mBizAddr;          // 주소
        public static String mBizTelNo;         // 대표전화

        // (후불) 발권  사용  정산 [락커]
        // (선불) 발권 [충전] 사용  정산
        public static String mTicketType;   //발권형태: ""미사용, "PA"선불, "PD"후불// 발권형태 : 선불형 AP-advanced payment  후불형 DP-deferred payment
        public static String mTicketMedia;  // 띠지BC   팔찌RF
        public static String mVanCode = "";


        // 알림톡
        public static String mAllimYn = "";
        public static String mAllimSenderProfile = "";
        public static String mAllimSenderProfileKey = "";
        public static String mAllimSiteName = "";
        public static String mAllimUserId = "";
        public static String mAllimCorpCode = "";
        public static String mAllimOrCode = "";
        public static String mAllimCpCode = "";
        public static String mAllimEtcCode = "";



        // 콜센터 연락처
        public static String mCallCenterNo = "";
        public static String mServerDbVer = "";


        public static String myShopCode = "";       // 내 업장코드
        public static String myShopName = "";       // 내 업장명

        public static String myPosNo = "";                              // 내 포스번호
        public static List<String> myPosNoList = new List<string>();    // Site내+내업장내 포스번호 목록   0~ 1~
        public static List<String> mPosNoList = new List<string>();     // Site내 포스번호 목록

        //
        public static String mUserAuth = "";       //  내 사용자권한 : U or A



        // 주문서 - 상품정보 필드관리
        //? 코너타입은 사이트별 or 포스별??
        public static String mCornerType;  // 주문서 관리 - ""미사용, "E"단순일체형, "P"분리형
        public static String[] mCornerCode; // 코너 코드
        public static String[] mCornerName; // 코너 명


        // 영수증 출력 상단 이미지
        public static byte[] mByteLogoImage;

        public static String mLanguage = ""; // KR EN CH


        // //////////////////////////////////////////////////////////////////////////////////////////
        /// 포스 설정값 <summary>
        /// 포스 설정값
        public static string mClientType = "";  // PC:PC, POS:포스, KIOSK:키오스크




        // //////////////////////////////////////////////////////////////////////////////////////////
        // 실행시 로컬 생성데이터
        public static String mBizDate = "";
        public static String mMacAddr = "";
        public static String mTheNo = "";  // 결제단위
        public static String mRefNo = "";  // 주문단위 입장단위

        // 실행중 로컬 운영
        public static String mScanString;
        public static bool mIsScanOK;


        public static string mUserID = "";
        public static string mUserName = "";


        public static CookieContainer cookies = new CookieContainer();
        public static HttpClientHandler handler = new HttpClientHandler();
        public static HttpClient mHttpClient;

        public static HttpClient mHttpClientCoupon;


        public static String mBaseUri = "http://211.45.170.55:8080/";
        public static String uri_real = "http://211.45.170.55:8080/";
        public static String uri_test = "http://211.42.156.219:8080/";




        public static frmSub fSub;
        public static Panel mPanelOrderInfo;
        public static BrightIdeasSoftware.ObjectListView mSublvwOrderItem;

        public static Label mSublblOrderAmount;
        public static Label mSublblOrderAmountDC;
        public static Label mSublblOrderAmountNet;
        public static Label mSublblOrderAmountReceive;
        public static Label mSublblOrderAmountRest;



        // //////////////////////////////////////////////////////////////////////////////////////////
        // 로컬 + 서버

        public struct DCR
        {
            public string dcr_code;
            public string dcr_name;
            public string dcr_des;
            public string dcr_type;
            public int dcr_value;
        }
        public static DCR[] mDCR;


        public struct PayConsol
        {
            public string code; // CASH, CARD, COMPLEX, CERT, EASY
                                // 현금  카드   복합결제  인증   간편결제
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }
        public static PayConsol[] mPayConsol;

        public struct FlowConsol
        {
            public string code;
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }
        public static FlowConsol[] mFlowConsol;


        public struct Badges
        {
            public string badges_id;
            public string badges_name;
        }
        public static Badges[] mBadges = new Badges[4];


        public struct OptionTemplate
        {
            public string option_template_id;
            public string option_template_name;
        }
        public static OptionTemplate[] mOptionTemplate;


        public struct TempOption
        {
            public string option_template_id;
            public string option_id;
            public int option_seq;
            public string is_turnoff;
            public string next_option_id;
            public string option_name;
            public string option_name_en;
            public string option_name_ch;
            public string option_name_jp;
        }
        public static TempOption[] mTempOption;


        public struct TempOptionItem
        {
            public string option_template_id;
            public string option_id;
            public string option_item_id;
            public int option_item_seq;
            public string link_option_id;
            public string option_item_name;
            public string option_item_name_en;
            public string option_item_name_ch;
            public string option_item_name_jp;
            public int option_item_amt;
        }
        public static TempOptionItem[] mTempOptionItem;




        public struct Shop
        {
            public string shop_code;
            public string shop_name;
            public string printer_type;
            public string network_printer_name;
        }
        public static Shop[] mShop;


        public struct Nod1
        {
            public string shop_code;
            public string nod_code1;
            public string nod_name1;
        }
        public static Nod1[] mNod1;
        

        public struct Nod2
        {
            public string shop_code;
            public string nod_code1;
            public string nod_code2;
            public string nod_name2;
        }
        public static Nod2[] mNod2;




        public struct GoodsGroup
        {
            public string group_code;
            public string group_name;
            public string soldout;
            public string cutout;
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
            public String btn_color;
        }
        public static GoodsGroup[] myGoodsGroup;


        public struct GoodsItem
        {
            public string group_code;
            public string goods_code;
            public string goods_name;
            public int amt;
            public String online_coupon;
            public String ticket; // 일반상품 0. 티켓상품 1
            public String taxfree; // 과세품 0, 면세품 1
            public String shop_code;
            public String nod_code1;
            public String nod_code2;
            public String cutout;   // 중지
            public String soldout;  // Y품절
            public String allim;
            public String option_template_id;
            public String coupon_link_no;
            //public String bar_code;

            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
            public String btn_color;
        }
        public static GoodsItem[] myGoodsItem;


        public struct GoodsTicket
        {
            public string goods_code;
            public string available_minute;
            public String is_charge;
            public String ot_free_minute;
            public String ot_std_minute;
            public String ot_amt;
            public String link_goods_code;
        }
        public static GoodsTicket[] mGoodsTicket;



        public struct Goods
        {
            public string goods_code;
            public string goods_name;
            public int amt;
            public String online_coupon;
            public String ticket; // 일반상품 0. 티켓상품 1
            public String taxfree; // 과세품 0, 면세품 1
            public String shop_code;
            public String nod_code1;
            public String nod_code2;
            public String cutout;   // 중지
            public String soldout;  // Y품절
            public String allim;
            public String bar_code;
        }
        public static List<Goods> mGoodsList = new List<Goods>();






        /*
        public struct GoodsOption
        {
            public string goods_code;
            public string option_code;
            public int option_seq;
            public string option_name;
        }
        public static GoodsOption[] mGoodsOption;

        public struct GoodsOptionItem
        {
            public string goods_code;
            public string option_code;
            public int option_item_no;
            public string option_item_name;
            public int option_item_amt;
        }
        public static GoodsOptionItem[] mGoodsOptionItem;
        */





        // 로컬
        public struct MemOrder
        {
            public int order_no;        // 대기번호 [대기]을 위해
            public DateTime dt;         // 대기일시
            public int cnt;             // 항목수
            public int amount;          // 합계
        }
        public static List<MemOrder> listWaiting = new List<MemOrder>();

        public struct MemOrderItem
        {
            public int lv_order_no;             // 
            public String lv_goods_name;        // 상품name or 전체할인명("할인")
            public String lv_cnt;
            public String lv_amt;
            public String lv_dc_amount;         // 실할인금액
            public String lv_net_amount;        // 결제금액
            
            public String option_name_description;          // render를 통한 옵션 표시
            public String option_amt_description;          // render를 통한 옵션 표시
            public String option_dc_amount_description;          // render를 통한 옵션 표시

            public int option_item_cnt;  
            public String option_no;   // option_item 연결번호
            public List<orderOptionItem> orderOptionItemList;

            public int order_no;                // 대기번호 [대기]을 위해

            public String goods_code;           // 상품code(6) or 전체할인코드고정("EDC")
            public String goods_name;           // 상품name or 전체할인명("할인")

            public int cnt;
            public int amt;                     // 상품단가
            public int option_amt;              // 옵션단가
            public int dc_amount;               // 실할인금액
            public int net_amount;              // 결제금액

            public String ticket;
            public String taxfree;
            public String allim;
            public String shop_code;
            public String nod_code1;
            public String nod_code2;

            public String dcr_code;     // 
            public String dcr_type;     // type - "A" : 정액, "R" : 정율 
            public String dcr_des;      // 전체"E", 선택"S"
            public int dcr_value;       // 할인금액 or 할인율
            public String pay_class;
            public String ticket_no;     // 충전, 사용인경우
            public String add_job;       // 특수 예외작업용 : ex 최장시 추가용금 결제
            public String shop_order_no;

            public String coupon_no;

            public String lv_memo;
        }
        public static List<MemOrderItem> listWaitingItem = new List<MemOrderItem>();

        // 메인 주문아이템리스트
        public static List<MemOrderItem> mOrderItemList = new List<MemOrderItem>();


        public struct orderOptionItem
        {
            public String option_code;
            public String option_name;
            public int option_item_no;
            public String option_item_name;
            public int amt;
        }
        public static List<orderOptionItem> mOrderOptionItemList = new List<orderOptionItem>();

        public static int mOrderCntInOption = 1;



        public struct shop_order_pack
        {
            public string shop_code;
            public string order_no;
            public string order_dt;
            public List<order_pack> orderPackList;
        }

        public struct order_pack
        {
            public string goods_code;
            public string allim;
            public string goods_name;
            public int goods_cnt;
            public string nod_code1;  //???? 키벤저스 F&B 레스토랑 만 주문서 출력을 위해서 nod_code1=41 만 출력
            public List<string> option_name;
            public List<string> option_item_name;
        }

        public static List<shop_order_pack> shopOrderPackList = new List<shop_order_pack>();



        // 서버
        public struct dbOrder
        {
            public String site_id;
            public String biz_dt;       // yyyyMMdd
            public String pos_no;
            public String the_no;       // 
            public String ref_no;       // 
            public String tran_type;
            public String order_date;
            public String order_time;
            public int cnt;             // 항목수
            public String is_cancel;    // Y
        }
        public static List<dbOrder> listOrder = new List<dbOrder>();



        // 서버
        public struct Payment
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public String shop_code;
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String tran_type;    // 승인 A, 취소 C
            public String pay_class;    // Order 0, charge 1, settlement 2
            public String bill_no;    // 4자리 
            public int net_amount;
            public int amount_cash;
            public int amount_card;
            public int amount_easy;
            public int amount_point;
            public int amount_cert;
            public String is_cash;
            public String is_card;
            public String is_easy;
            public String is_point;
            public String is_cert;

            public int dc_amount;       // 할인금액
            public String is_cancel;   // 취소여부 : 미취소"", 취소중0, 취소1
        }
        public static List<Payment> mPayments = new List<Payment>();

        public struct PaymentCard
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 신용카드(C1), 임의등록(C0)
            public String tran_type;    // 승인 A 취소 C
            public String pay_class;
            public String ticket_no;
            public int pay_seq;
            public String tran_date;
            public int amount;          // 결제금액 과세금액 면세금액 봉사료 세금
            public int tax_amount;
            public int tfree_amount;
            public int service_amount;
            public int tax;

            public String install;      // 할부개월 00 03
            public String auth_no;      // 승인번호
            public String card_no;      // 카드번호
            public String card_name;    // 카드종류
            public String isu_code;     // 발급사코드
            public String acq_code;     // 매입사코드
            public String merchant_no;  // 가맹점번호
            public String tran_serial;  // tran_serial -> 취소시 tid입력
            public String sign_path;
            public int gift_change;     // 기프트 잔액
            public String is_cancel;    // 취소여부 : "" or "1"
            public String van_code;
            public String is_cup;
        }
        public static List<PaymentCard> mPaymentCards = new List<PaymentCard>();

        public struct PaymentCash
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 신용카드(C1), 임의등록(C0)
            public String tran_type;    // 승인 A 취소 C
            public String pay_class;
            public String ticket_no;
            public int pay_seq;
            public String tran_date;
            public int amount;          // 결제금액
            public String receipt_type; // 현금영수증 : 개인 소득공제 1 사업자 지출증빙 2
            public String issued_method_no;  // 현금영수증 고객 식별번호
            public String auth_no;      // 승인번호
            public String tran_serial;          // tran_serial -> 취소시 tid입력
            public String is_cancel;    // 취소여부
            public String van_code;
        }
        public static List<PaymentCash> mPaymentCashs = new List<PaymentCash>();


        public struct PaymentEasy
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 간편결제(ㄸ1)
            public String tran_type;    // 승인 A 취소 C
            public String pay_class;
            public String ticket_no;
            public int pay_seq;
            public String tran_date;
            public int amount;          // 결제금액 과세금액 면세금액 봉사료 세금
            public int tax_amount;
            public int tfree_amount;
            public int service_amount;
            public int tax;

            public String install;      // 할부개월 00 03
            public String auth_no;      // 승인번호
            public String card_no;      // 카드번호
            public String card_name;    // 카드종류
            public String isu_code;     // 발급사코드
            public String acq_code;     // 매입사코드
            public String merchant_no;  // 가맹점번호
            public String tran_serial;  // tran_serial -> 취소시 tid입력
            public String sign_path;
            public int gift_change;     // 기프트 잔액
            public String is_cancel;    // 취소여부 : "" or "1"
            public String van_code;

            public String pay_type2;  // KKP

            public String barcode_no;
        }
        public static List<PaymentEasy> mPaymentEasys = new List<PaymentEasy>();


        public struct PaymentPoint           // 선불 포인트 사용
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 포인트 선불(PA), 후불(PD)
            public String tran_type;    // 승인 A 취소 C
            public String pay_class;
            public String ticket_no;
            public String usage_no;
            public int amount;
            public String is_cancel;
        }
        public static List<PaymentPoint> mPaymentPoints = new List<PaymentPoint>();


        public struct PaymentCert
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 신용카드(C1), 임의등록(C0)
            public String tran_type;    // 승인 A 취소 C
            public String pay_class;
            public String ticket_no;

            public int pay_seq;
            public String tran_date;
            public int amount;          // 결제금액
            public String coupon_no;    // 
            public String is_cancel;    // 취소여부
            public String van_code;

            public int cnt;
            public String coupon_link_no;

        }
        public static List<PaymentCert> mPaymentCerts = new List<PaymentCert>();

        /*

        public struct CertOrder
        {
            public string state;
            public string ustaten;
            public string order_no;
            public string coupon_no;
            public string menu_code;
            public string menu_name;
            public int qty;
            public string exp_date;

            public string ustate;
            public string cus_nm;
            public string cus_hp;
            public string cus_opt;

            public string is_usage;
        }
        public static List<CertOrder> mCertOrders = new List<CertOrder>();

        */


        // 발권상품(Order), 인증(Cert)시점 -> TicketFlow 레코드 생성(초기값)
        public struct TicketFlow
        {
            public String site_id;
            public String biz_dt;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위

            public String ticket_no;
            public String ticketing_dt;   // 발권일시
            public String charge_dt;      // 충전일시
            public String settlement_dt;  // 정산일시

            public int point_charge_cnt;        // 충전횟수
            public int point_usage_cnt;         // 사용횟수

            public int point_charge;        // 충전금액
            public int point_usage;         // 사용금액(누적)

            public int settle_point_charge;        // 충전금액
            public int settle_point_usage;         // 사용금액(누적)

            public String goods_code;
            public String flow_step;      // 진행상황 : 접수0 - 발급1 - *충전2 - 사용3 - 정산(완료)4 : 사용중인 경우 locker close, 정산완료 locker open.

            public String locker_no;        // 추가
            public String open_locker;      // 락커 수동 설정 : 0 폐쇄(기본값), 1 개방
                                            // 정산완료  or 수동 개방상태 -> 락커오픈
        }
        public static List<TicketFlow> mTicketFlowList = new List<TicketFlow>();



        //public static String mTheMode = "";  // Server Local


        public static String mIsLogin = "N";


        public static String mPayClass = "OR"; // order

        public static Boolean mReturn = false;
        public static string mErrorMsg = "";

        public static JObject mObj = new JObject();


        //
        //public static int mSyncLinkWaitCnt = 0;



        // 포스별 설정
        public static String mPosType = ""; // 기종 : POS PC KIOSK
        public static String mCustomerMonitor = "";  // Y N

        public static String mMobileExchangeType = "";  // 모바일교환권 
        public static String mPrintExchangeType = "";  // 인쇄교환권 

        public static String mBillPrinterPort = "";
        public static String mBillPrinterSpeed = "";

        public static String mTicketPrinterPort = "";
        public static String mTicketPrinterSpeed = "";


        public static String mVanTID = "";    // 결제밴 T-ID

        // 앞으로 쿠폰 채널 
        public static String mCouponMID = "";   // 플레이스엠 쿠폰 채널 부여 번호      "3590";

        public static String mSubMonitorImage = "";   
        public static String mTicketAddText = "";
        public static String mBillAddText = "";

        // 로그
        public static int mAppLogLevel = 1;
        // log_input :  1(info), 2(IMPORTANT), 3(error만)   >=  app_log_level :  1(ALL), 2(IMPORTANT), 3(ERROR), 4(NONE)



        //Local DB
        //public static SQLiteConnection mConn;

        public static Label mLblTheModeStatus;

        //
        public static String mIsDevLogin = "";


        public static String mIsTestPayMode = "";   // TEST LOGIN



        // 빠른퇴장 화면이 떠있는지 보자...
        public static bool isFlowTicketExit = false;





        public static String get_MMddHHmm(String d, String t)
        {
            return d.Substring(4, 2) + "-" + d.Substring(6, 2) + " " + t.Substring(0, 2) + ":" + t.Substring(2, 2);
        }

        public static String get_today_date()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        public static String get_today_time()
        {
            return DateTime.Now.ToString("HHmmss");
        }



        public static String get_pay_class_name(String code)
        {
            String name = "";
            if (code == "OR") name = "구매";
            else if (code == "CH") name = "충전";
            else if (code == "US")
            {
                if (mTicketType == "PA") name = "선불";
                else if (mTicketType == "PD") name = "후불";
                else name = code;
            }
            else if (code == "ST") name = "정산:";
            else name = code;

            return name;
        }



        public static String get_pay_type_group_name(String group)
        {
            //is_cash + is_card + is_point + is_easy;
            if (group == "10000") return "현금";
            else if (group == "01000") return "카드";
            else if (group == "00100") return "포인트";
            else if (group == "00010") return "간편";
            else if (group == "00001") return "쿠폰";
            else if (group == "00000") return "";
            else return "복합";
        }


        public static String get_pay_type_name(String code)
        {
            String name = "";
            if (code == "C1") name = "카드승인결제";
            else if (code == "C0") name = "카드임의등록";
            else if (code == "R0") name = "단순현금";
            else if (code == "R1") name = "현금영수증";
            else if (code == "R9") name = "임의등록";
            else if (code == "PA") name = "포인트선불";
            else if (code == "PD") name = "포인트후불";
            else if (code == "E1") name = "간편";
            else if (code == "M0") name = "쿠폰";
            else name = code;

            return name;
        }

        public static String get_tran_type_name(String code)
        {
            String name = "";
            if (code == "A") name = "승인";
            else if (code == "C") name = "취소";
            else name = code;

            return name;
        }


        public static String get_ticket_type_name(String code)
        {
            String name = "";
            if (code == "PA") name = "선불";
            else if (code == "PD") name = "후불";
            else name = code;

            return name;
        }


        public static String get_receipt_type_name(String code)
        {
            String name = "";
            if (code == "1") name = "개인소득공제";
            else if (code == "2") name = "사업지출증빙";
            else if (code == "3") name = "자진발급";
            else name = code;

            return name;
        }



        public static String get_dcr_des_name(String code)
        {
            String name = "";
            if (code == "E") name = "전체";
            else if (code == "S") name = "선택";
            else name = code;

            return name;
        }

        public static String get_dcr_type_name(String code)
        {
            String name = "";
            if (code == "A") name = "정액(W)";
            else if (code == "R") name = "정율(%)";
            else name = code;

            return name;
        }

        public static String get_is_cancel_name(String code)
        {
            String name = "";
            if (code == "1") name = "취소중";
            else if (code == "Y") name = "취소됨";
            else name = code;

            return name;
        }


        public static int get_goods_amt(String code)
        {
            for (int i = 0; i < mGoodsList.Count; i++)
            {
                if (mGoodsList[i].goods_code == code)
                {
                    return mGoodsList[i].amt;
                }
            }

            return 0;
        }


        public static String get_goods_name(String code)
        {
            if (code == "DCRE")
            {
                return "할인";
            }

            if (code.Substring(0,2) == "DC")
            {
                for (int i = 0; i < mDCR.Length; i++)
                {
                    if (mDCR[i].dcr_code == code)
                    {
                        return mDCR[i].dcr_name;
                    }
                }
                return "할인";
            }
            

            if (code == "CHARGE")
                return "충전";


            
            for (int i = 0; i < mGoodsList.Count; i++)
            {
                if (mGoodsList[i].goods_code == code)
                {
                    return mGoodsList[i].goods_name;
                }
            }

            return code;
        }


        public static String get_option_template_name(String template_id)
        {

            for (int i = 0; i < mOptionTemplate.Length; i++)
            {
                if (mOptionTemplate[i].option_template_id == template_id)
                {
                    return mOptionTemplate[i].option_template_name;
                }
            }

            return template_id;
        }

        public static String get_badges_name(String badgese_id)
        {
            for (int i = 0; i < mBadges.Length; i++)
            {
                if (mBadges[i].badges_id == badgese_id)
                {
                    return mBadges[i].badges_name;
                }
            }

            return badgese_id;

        }


        public static String get_shop_name(String shop_code)
        {
            if (shop_code == "CHARGE")
                return "충전";


            for (int i = 0; i < mShop.Length; i++)
            {
                if (mShop[i].shop_code == shop_code)
                {
                    return mShop[i].shop_name;
                }
            }

            return shop_code;
        }

        public static String get_nod1_name(String shop_code, String nod_code1)
        {
            if (nod_code1 == "")
            {
                return "";
            }

            for (int i = 0; i < mNod1.Length; i++)
            {
                if (mNod1[i].shop_code == shop_code & mNod1[i].nod_code1 == nod_code1)
                {
                    return mNod1[i].nod_name1;
                }
            }

            return nod_code1;
        }

        public static String get_nod2_name(String shop_code, String nod_code1, String nod_code2)
        {
            if (nod_code2 == "")
            {
                return "";
            }

            for (int i = 0; i < mNod2.Length; i++)
            {
                if (mNod2[i].shop_code == shop_code & mNod2[i].nod_code1 == nod_code1 & mNod2[i].nod_code2 == nod_code2)
                {
                    return mNod2[i].nod_name2;
                }
            }

            return nod_code2;
        }

        public static bool is_number(String str)
        {
            int tNum;
            if (int.TryParse(str, out tNum))
            {
                return true;
            }

            return false;
        }

        public static bool get_number(String str, ref int num)
        {
            if (int.TryParse(str, out num))
            {
                return true;
            }

            return false;
        }

        public static int convert_number(String str)
        {
            int out_number;
            if (int.TryParse(str.Replace(",", ""), out out_number))
            {
                return out_number;
            }

            return -1;
        }

        public static int convert_number(String str, int return_num)
        {
            int out_number;
            if (int.TryParse(str.Replace(",", ""), out out_number))
            {
                return out_number;
            }

            return return_num;
        }


        public static bool mRequestGet(String sUrl)
        {
            try
            {
                var response = mHttpClient.GetAsync(mBaseUri + sUrl).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }

        public static bool mRequestPost(String sUrl, Dictionary<string, string> parameters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = mHttpClient.PostAsync(mBaseUri + sUrl, data).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }


        public static bool mRequestPatch(String sUrl, Dictionary<string, string> parameters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, mBaseUri + sUrl);
                request.Content = data;


                var response = mHttpClient.SendAsync(request).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }

        public static bool mRequestDelete(String sUrl, Dictionary<string, string> parameters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var method = new HttpMethod("DELETE");
                var request = new HttpRequestMessage(method, mBaseUri + sUrl);
                request.Content = data;


                var response = mHttpClient.SendAsync(request).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }


        public static string SHA1HashCrypt(string val)
        {
            //고정로직
            byte[] data = Encoding.ASCII.GetBytes(val);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);
            return Convert.ToBase64String(result);
        }


        public static bool get_bizdate_status(ref String biz_status, ref String biz_date)
        {
            String sUrl = "bizDateLast?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String cnt = mObj["bizDateCnt"].ToString();

                    if (cnt == "0")
                    {
                        biz_date = "";
                        biz_status = "X";
                    }
                    else
                    {
                        String data = mObj["bizDate"].ToString();
                        JArray arr = JArray.Parse(data);

                        biz_date = arr[0]["bizDt"].ToString();
                        biz_status = arr[0]["bizStatus"].ToString();
                    }
                    return true;

                }
                else
                {
                    MessageBox.Show("영업개시마감 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    //MessageBox.Show("영업개시마감 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return false;
            }

        }


        public static void xxx_set_version_basic_db_change()
        {
            // 1단계 테이블이 변경될 경우 버전을 업데이트한다...
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["basicDbVer"] = get_today_date() + get_today_time();

            if (mRequestPatch("site", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("오류. site\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. site\n\n" + mErrorMsg, "thepos");
                return;
            }
        }


        public static void thepos_app_log(int log_input, String form_name, String form_action, string form_memo)
        {
            //  log_input
            //  1 : 단순로그
            //  2 : 로그인 등
            //  3 : error - 에러

            //  mLogLevel 
            // 1 : ALL
            // 2 : INFO  - 로그인 로그아웃 종료
            // 3 : ERROR
            // 4 : NONE



            // 개발자로그인은 앱로그를 안남긴다.
            if (mIsDevLogin == "Y")
            {
                if (mIsTestPayMode == "Test")
                {
                    //

                }
                else
                {
                    return;
                }
            }



            //
            if (log_input >= mAppLogLevel)
            {
                try
                {
                    String sUrl = "theposAppLog";

                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters["logDate"] = get_today_date();
                    parameters["logTime"] = get_today_time();
                    parameters["logLevel"] = log_input + "";
                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = myPosNo;
                    parameters["formName"] = form_name;
                    parameters["formAction"] = form_action;
                    parameters["formMemo"] = form_memo;

                    var json = JsonConvert.SerializeObject(parameters);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = mHttpClient.PostAsync(mBaseUri + sUrl, data).Result;

                    //var responseContent = response.Content;
                    //string responseString = responseContent.ReadAsStringAsync().Result;

                }
                catch (Exception e)
                {
                    //
                }
            }
        }
    }
}
