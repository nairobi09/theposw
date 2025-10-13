using Newtonsoft.Json.Linq;
using PrinterUtility;
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
using System.Windows.Forms.DataVisualization.Charting;
using static thepos.frmBusiness;
using static thepos.thePos;

namespace thepos
{
    public partial class frmBizLastSettlement : Form
    {
        bool isNew = true;


        int cash_amount = 0;  // 현금매출금액
        int cash_amount_cncl = 0;  // 현금매출취소금액

        int cash_starting = 0;  // 준비금


        int cnt_50000 = 0;
        int cnt_10000 = 0;
        int cnt_5000 = 0;
        int cnt_1000 = 0;
        int cnt_500 = 0;
        int cnt_100 = 0;
        int cnt_50 = 0;
        int cnt_10 = 0;
        int amount_etc = 0;
        int amount_50000 = 0;
        int amount_10000 = 0;
        int amount_5000 = 0;
        int amount_1000 = 0;
        int amount_500 = 0;
        int amount_100 = 0;
        int amount_50 = 0;
        int amount_10 = 0;
        int amount_real_sum = 0;



        public static TextBox ptb50000;
        public static TextBox ptb10000;
        public static TextBox ptb5000;
        public static TextBox ptb1000;
        public static TextBox ptb500;
        public static TextBox ptb100;
        public static TextBox ptb50;
        public static TextBox ptb10;
        public static TextBox ptbEtc;



        public frmBizLastSettlement()
        {
            InitializeComponent();

            //
            thepos_app_log(1, this.Name, "open", "");


            initialize_the();


            load_cash_amount();  // 현금매출액 구하기
            lblCashAmount.Text = (cash_amount - cash_amount_cncl).ToString("N0");


            load_cash_info();  // 준비금 구하기
            lblCashStarting.Text = cash_starting.ToString("N0");

            calculate_cash_real();

        }


        private void initialize_the()
        {
            //
            lblBizDt.Text = mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);

            lblPosNo.Text = myPosNo;
            lblLoginName.Text = mUserName;



            ptb50000 = tb50000;
            ptb10000 = tb10000;
            ptb5000 = tb5000;
            ptb1000 = tb1000;
            ptb500 = tb500;
            ptb100 = tb100;
            ptb50 = tb50;
            ptb10 = tb10;
            ptbEtc = tbEtc;

        }

        private void calculate_cash_real()
        {
            amount_real_sum = amount_etc + amount_50000 + amount_10000 + amount_5000 + amount_1000 + amount_500 + amount_100 + amount_50 + amount_10;

            lblSum.Text = amount_real_sum.ToString("N0");

            lblCashReal.Text = amount_real_sum.ToString("N0");

            int int과부족 = amount_real_sum - (cash_amount - cash_amount_cncl + cash_starting);

            lblCashDiff.Text = int과부족.ToString("N0");

        }


        private void load_cash_amount()
        {
            String sUrl = "reportDayPos?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayPos"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        cash_amount = convert_number(arr[0]["amountCash"].ToString());
                        cash_amount_cncl = convert_number(arr[0]["amountCashCncl"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void load_cash_info()
        {
            String sUrl = "reportDailyCash?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dailyCash"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        cash_starting = convert_number(arr[i]["startingCash"].ToString());

                        cnt_50000 = convert_number(arr[i]["fiftyKCnt"].ToString());
                        cnt_10000 = convert_number(arr[i]["tenKCnt"].ToString());
                        cnt_5000 = convert_number(arr[i]["fiveKCnt"].ToString());
                        cnt_1000 = convert_number(arr[i]["oneKCnt"].ToString());
                        cnt_500 = convert_number(arr[i]["fiveHCnt"].ToString());
                        cnt_100 = convert_number(arr[i]["oneHCnt"].ToString());
                        cnt_50 = convert_number(arr[i]["fiftyCnt"].ToString());
                        cnt_10 = convert_number(arr[i]["tenCnt"].ToString());
                        amount_etc = convert_number(arr[i]["etcAmount"].ToString());


                        lblCashStarting.Text = cash_starting.ToString("N0");
                        tb50000.Text = cnt_50000.ToString();
                        tb10000.Text = cnt_10000.ToString();
                        tb5000.Text = cnt_5000.ToString();
                        tb1000.Text = cnt_1000.ToString();
                        tb500.Text = cnt_500.ToString();
                        tb100.Text = cnt_100.ToString();
                        tb50.Text = cnt_50.ToString();
                        tbEtc.Text = amount_etc.ToString();

                        isNew = false;

                    }
                }
                else if (mObj["resultCode"].ToString() == "601")
                {
                    // {\"resultCode\":\"601\",\"resultMsg\":\"조회 결과가 없습니다.\",\
                    return;
                }
                else
                {
                    MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }


        private void btnBizCloseInput_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = mBizDate;
            parameters["posNo"] = myPosNo;

            parameters["etcAmount"] = amount_etc + "";
            parameters["fiftyKCnt"] = cnt_50000 + "";
            parameters["tenKCnt"] = cnt_10000 + "";
            parameters["fiveKCnt"] = cnt_5000 + "";
            parameters["oneKCnt"] = cnt_1000 + "";
            parameters["fiveHCnt"] = cnt_500 + "";
            parameters["oneHCnt"] = cnt_100 + "";
            parameters["fiftyCnt"] = cnt_50 + "";
            parameters["tenCnt"] = cnt_10 + "";

            bool ret;

            if (isNew)
            {
                ret = mRequestPost("reportDailyCash", parameters);
            }
            else
            {
                ret = mRequestPatch("reportDailyCash", parameters);
            }

            if (ret)
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("시제 입력 완료.", "thepos");

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



            ///
            DialogResult dialogResult = MessageBox.Show("시제입력.\r\n\r\n정산 리포트를 출력할까요?", "thepos", MessageBoxButtons.OKCancel);


            if (dialogResult == DialogResult.OK)
            {
                load_card_data();

                load_pay_data();

                load_goods_data();



            }

        }



        private void load_card_data()
        {
            String sUrl = "reportDailyCardPos?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dailyArr"].ToString();
                    JArray arr = JArray.Parse(data);

                    List<String> card_name = new List<String>();
                    List<int> cnt = new List<int>();
                    List<int> amount = new List<int>();

                    int sum_cnt = 0;
                    int sum_amount = 0;


                    if (arr.Count > 0)
                    {

                        for (int i = 0; i < arr.Count; i++)
                        {
                            card_name.Add(arr[i]["cardName"].ToString());
                            cnt.Add(convert_number(arr[i]["cnt"].ToString()));
                            amount.Add(convert_number(arr[i]["amountCard"].ToString()));

                            sum_cnt += cnt[i];
                            sum_amount += amount[i];
                        }
                    }

                    //
                    String strPrint = make_print_card(card_name, cnt, amount, sum_cnt, sum_amount);
                    print_data(strPrint);

                    thepos_app_log(1, this.Name, "[카드사별 매출] 출력", "");

                }
                else
                {
                    MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

        private void load_pay_data()
        {
            String sUrl = "reportDayPos?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayPos"].ToString();
                    JArray arr = JArray.Parse(data);

                    int t_cash_cnt = 0;
                    int t_card_cnt = 0;
                    int t_easy_cnt = 0;
                    int t_cert_cnt = 0;

                    int t_cash_amount = 0;
                    int t_card_amount = 0;
                    int t_easy_amount = 0;
                    int t_cert_amount = 0;

                    int t_cash_cnt_cncl = 0;
                    int t_card_cnt_cncl = 0;
                    int t_easy_cnt_cncl = 0;
                    int t_cert_cnt_cncl = 0;

                    int t_cash_amount_cncl = 0;
                    int t_card_amount_cncl = 0;
                    int t_easy_amount_cncl = 0;
                    int t_cert_amount_cncl = 0;

                    int t_net_count = 0;
                    int t_net_amount = 0;


                    if (arr.Count > 0)
                    {
                        t_cash_cnt = convert_number(arr[0]["cntCash"].ToString());
                        t_card_cnt = convert_number(arr[0]["cntCard"].ToString());
                        t_easy_cnt = convert_number(arr[0]["cntEasy"].ToString());
                        t_cert_cnt = convert_number(arr[0]["cntCert"].ToString());

                        t_cash_amount = convert_number(arr[0]["amountCash"].ToString());
                        t_card_amount = convert_number(arr[0]["amountCard"].ToString());
                        t_easy_amount = convert_number(arr[0]["amountEasy"].ToString());
                        t_cert_amount = convert_number(arr[0]["amountCert"].ToString());

                        t_cash_cnt_cncl = convert_number(arr[0]["cntCashCncl"].ToString());
                        t_card_cnt_cncl = convert_number(arr[0]["cntCardCncl"].ToString());
                        t_easy_cnt_cncl = convert_number(arr[0]["cntEasyCncl"].ToString());
                        t_cert_cnt_cncl = convert_number(arr[0]["cntCertCncl"].ToString());

                        t_cash_amount_cncl = convert_number(arr[0]["amountCashCncl"].ToString());
                        t_card_amount_cncl = convert_number(arr[0]["amountCardCncl"].ToString());
                        t_easy_amount_cncl = convert_number(arr[0]["amountEasyCncl"].ToString());
                        t_cert_amount_cncl = convert_number(arr[0]["amountCertCncl"].ToString());

                        t_net_count = convert_number(arr[0]["netCount"].ToString());
                        t_net_amount = convert_number(arr[0]["netAmount"].ToString());
                    }

                    //
                    String strPrint = make_print_pay(t_cash_cnt, t_card_cnt, t_easy_cnt, t_cert_cnt, t_cash_amount, t_card_amount, t_easy_amount, t_cert_amount, t_cash_cnt_cncl, t_card_cnt_cncl, t_easy_cnt_cncl, t_cert_cnt_cncl, t_cash_amount_cncl, t_card_amount_cncl, t_easy_amount_cncl, t_cert_amount_cncl, t_net_count, t_net_amount);
                    print_data(strPrint);

                    thepos_app_log(1, this.Name, "[ 정 산 표 ] 출력", "");

                }
                else
                {
                    MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

        private void load_goods_data()
        {
            String sUrl = "reportDayPosGoods?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayPosGoods"].ToString();
                    JArray arr = JArray.Parse(data);

                    List<String> goods_name = new List<String>();
                    List<int> goods_cnt = new List<int>();
                    List<int> net_amount = new List<int>();

                    int sum_goods_cnt = 0;
                    int sum_goods_amount = 0;

                    for (int i = 0; i < arr.Count; i++)
                    {
                        goods_name.Add(get_goods_name(arr[i]["goodsCode"].ToString()));
                        goods_cnt.Add(convert_number(arr[i]["cnt"].ToString()));
                        net_amount.Add(convert_number(arr[i]["netAmount"].ToString()));

                        sum_goods_cnt += goods_cnt[i];
                        sum_goods_amount += net_amount[i];
                    }

                    //
                    String strPrint = make_print_goods(goods_name, goods_cnt, net_amount, sum_goods_cnt, sum_goods_amount);
                    print_data(strPrint);

                    thepos_app_log(1, this.Name, "[ 품목별 매출 ] 출력", "");
                }
                else
                {
                    MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }




        private String make_print_card(List<String> card_name, List<int> cnt, List<int> amount, int sum_cnt, int sum_amount)
        {
            String str_body = "";
            String str1 = "";
            String str2 = "";
            int space_cnt = 0;

            str_body += "[카드사별 매출]\r\n\r\n";


            str1 = "영업일: " + mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
            str2 = "POS No. " + myPosNo;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2;

            str_body += "------------------------------------------\r\n";  // 42

            space_cnt = 16 - encodelen("카드사명");
            str_body += "카드사명" + Space(space_cnt);
            space_cnt = 12 - encodelen("건수");
            str_body += Space(space_cnt) + "건수";
            space_cnt = 14 - encodelen("금액");
            str_body += Space(space_cnt) + "금액" + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42


            for (int i = 0; i < card_name.Count; i++)
            {
                space_cnt = 16 - encodelen(card_name[i]);
                str_body += card_name[i] + Space(space_cnt);

                space_cnt = 12 - encodelen(cnt[i].ToString("N0"));
                str_body += Space(space_cnt) + cnt[i].ToString("N0");

                space_cnt = 14 - encodelen(amount[i].ToString("N0"));
                str_body += Space(space_cnt) + amount[i].ToString("N0") + "\r\n";
            }

            str_body += "------------------------------------------\r\n";  // 42

            space_cnt = 16 - encodelen("합계");
            str_body += "합계" + Space(space_cnt);

            space_cnt = 12 - encodelen(sum_cnt.ToString("N0"));
            str_body += Space(space_cnt) + sum_cnt.ToString("N0");

            space_cnt = 14 - encodelen(sum_amount.ToString("N0"));
            str_body += Space(space_cnt) + sum_amount.ToString("N0") + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42


            String yyyymmdd = get_today_date();
            String hhmmss = get_today_time();

            str1 = "출력: " + yyyymmdd.Substring(0, 4) + "-" + yyyymmdd.Substring(4, 2) + "-" + yyyymmdd.Substring(6, 2) + " " + hhmmss.Substring(0, 2) + ":" + hhmmss.Substring(2, 2) + ":" + hhmmss.Substring(2, 2);
            str2 = "담당: " + mUserName;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2 + "\r\n";

            return str_body;
        }



        private String make_print_pay(int cash_cnt, int card_cnt, int easy_cnt, int cert_cnt, int cash_amount, int card_amount, int easy_amount, int cert_amount, int cash_cnt_cncl, int card_cnt_cncl, int easy_cnt_cncl, int cert_cnt_cncl, int cash_amount_cncl, int card_amount_cncl, int easy_amount_cncl, int cert_amount_cncl, int net_count, int net_amount)
        {
            String str_body = "";
            String str1 = "";
            String str2 = "";
            int space_cnt = 0;

            str_body += "[ 정 산 표 ]\r\n\r\n";


            str1 = "영업일: " + mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
            str2 = "POS No. " + myPosNo;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2;

            str_body += "------------------------------------------\r\n";  // 42

            str_body += "<결제집계내역>\r\n";
            str_body += "------------------------------------------\r\n";  // 42

            space_cnt = 16 - encodelen("종류");
            str_body += "종류" + Space(space_cnt);
            space_cnt = 12 - encodelen("건수");
            str_body += Space(space_cnt) + "건수";
            space_cnt = 14 - encodelen("금액");
            str_body += Space(space_cnt) + "금액" + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42


            space_cnt = 16 - encodelen("현금"); str_body += "현금" + Space(space_cnt);
            str1 = cash_cnt.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = cash_amount.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("카드"); str_body += "카드" + Space(space_cnt);
            str1 = card_cnt.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = card_amount.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("간편"); str_body += "간편" + Space(space_cnt);
            str1 = easy_cnt.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = easy_amount.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("쿠폰"); str_body += "쿠폰" + Space(space_cnt);
            str1 = cert_cnt.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = cert_amount.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";


            space_cnt = 16 - encodelen("현금취소"); str_body += "현금취소" + Space(space_cnt);
            str1 = cash_cnt_cncl.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = cash_amount_cncl.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("카드취소"); str_body += "카드취소" + Space(space_cnt);
            str1 = card_cnt_cncl.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = card_amount_cncl.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("간편취소"); str_body += "간편취소" + Space(space_cnt);
            str1 = easy_cnt_cncl.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = easy_amount_cncl.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            space_cnt = 16 - encodelen("쿠폰취소"); str_body += "쿠폰취소" + Space(space_cnt);
            str1 = cert_cnt_cncl.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = cert_amount_cncl.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42

            space_cnt = 16 - encodelen("결제합계"); str_body += "결제합계" + Space(space_cnt);
            str1 = net_count.ToString("N0"); space_cnt = 12 - encodelen(str1); str_body += Space(space_cnt) + str1;
            str2 = net_amount.ToString("N0"); space_cnt = 14 - encodelen(str2); str_body += Space(space_cnt) + str2 + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42


            int tax_amount = net_amount / 11;
            int supply_amount = net_amount - tax_amount;


            String str_amount = supply_amount.ToString("N0");
            space_cnt = 28 - encodelen("공급가액"); str_body += "공급가액" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;

            str_amount = tax_amount.ToString("N0");
            space_cnt = 28 - encodelen("부가세액"); str_body += "부가세액" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;

            str_amount = net_amount.ToString("N0");
            space_cnt = 28 - encodelen("실매출액"); str_body += "실매출액" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;


            str_body += "------------------------------------------\r\n";  // 42



            // 입력권종목록
            int cash_starting = 0;

            int cnt_50000 = 0;
            int cnt_10000 = 0;
            int cnt_5000 = 0;
            int cnt_1000 = 0;
            int cnt_500 = 0;
            int cnt_100 = 0;
            int cnt_50 = 0;
            int cnt_10 = 0;
            int amount_etc = 0;

            int real_cash_amount = 0;


            String sUrl = "reportDailyCash?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dailyCash"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        cash_starting = convert_number(arr[i]["startingCash"].ToString());

                        cnt_50000 = convert_number(arr[i]["fiftyKCnt"].ToString());
                        cnt_10000 = convert_number(arr[i]["tenKCnt"].ToString());
                        cnt_5000 = convert_number(arr[i]["fiveKCnt"].ToString());
                        cnt_1000 = convert_number(arr[i]["oneKCnt"].ToString());
                        cnt_500 = convert_number(arr[i]["fiveHCnt"].ToString());
                        cnt_100 = convert_number(arr[i]["oneHCnt"].ToString());
                        cnt_50 = convert_number(arr[i]["fiftyCnt"].ToString());
                        cnt_10 = convert_number(arr[i]["tenCnt"].ToString());
                        amount_etc = convert_number(arr[i]["etcAmount"].ToString());

                        real_cash_amount = amount_etc + (cnt_50000 * 50000) + (cnt_10000 * 10000) + (cnt_5000 * 5000) + (cnt_1000 * 1000) + (cnt_500 * 500) + (cnt_100 * 100) + (cnt_50 * 50) + (cnt_10 * 10);
                    }
                }
                else
                {
                    //MessageBox.Show("데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
            }



            // 현금매출액
            str_amount = (cash_amount - cash_amount_cncl).ToString("N0");
            space_cnt = 28 - encodelen("현금매출액"); str_body += "현금매출액" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;

            // 준비금
            str_amount = cash_starting.ToString("N0");
            space_cnt = 28 - encodelen("준비금"); str_body += "준비금" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;

            // 실현금액
            str_amount = real_cash_amount.ToString("N0");
            space_cnt = 28 - encodelen("실현금액"); str_body += "실현금액" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;


            // 현금 과부족
            str_amount = (real_cash_amount - (cash_amount - cash_amount_cncl + cash_starting)).ToString("N0");
            space_cnt = 28 - encodelen("현금과부족"); str_body += "현금과부족" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;


            str_body += "------------------------------------------\r\n\r\n";  // 42




            // 입력권종 합계
            str_body += "<입력권종목록>\r\n";
            str_body += "------------------------------------------\r\n";  // 42
            str_body += "권종                    수량          금액\r\n";  // 42
            str_body += "------------------------------------------\r\n";  // 42

            //
            space_cnt = 22 - encodelen("기타"); str_body += "기타" + Space(space_cnt);
            str_body += Space(6);
            space_cnt = 14 - encodelen(amount_etc + ""); str_body += Space(space_cnt) + amount_etc + "\r\n";
            //
            space_cnt = 22 - encodelen("50,000권"); str_body += "50,000권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_50000 + ""); str_body += Space(space_cnt) + cnt_50000;
            space_cnt = 14 - encodelen((cnt_50000 * 50000) + ""); str_body += Space(space_cnt) + (cnt_50000 * 50000) + "\r\n";
            //
            space_cnt = 22 - encodelen("10,000권"); str_body += "10,000권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_10000 + ""); str_body += Space(space_cnt) + cnt_10000;
            space_cnt = 14 - encodelen((cnt_10000 * 10000) + ""); str_body += Space(space_cnt) + (cnt_10000 * 10000) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("5,000권"); str_body += "5,000권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_5000 + ""); str_body += Space(space_cnt) + cnt_5000;
            space_cnt = 14 - encodelen((cnt_5000 * 5000) + ""); str_body += Space(space_cnt) + (cnt_5000 * 5000) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("1,000권"); str_body += "1,000권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_1000 + ""); str_body += Space(space_cnt) + cnt_1000;
            space_cnt = 14 - encodelen((cnt_1000 * 1000) + ""); str_body += Space(space_cnt) + (cnt_1000 * 1000) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("500권"); str_body += "500권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_500 + ""); str_body += Space(space_cnt) + cnt_500;
            space_cnt = 14 - encodelen((cnt_500 * 500) + ""); str_body += Space(space_cnt) + (cnt_500 * 500) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("100권"); str_body += "100권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_100 + ""); str_body += Space(space_cnt) + cnt_100;
            space_cnt = 14 - encodelen((cnt_100 * 100) + ""); str_body += Space(space_cnt) + (cnt_100 * 100) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("50권"); str_body += "50권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_50 + ""); str_body += Space(space_cnt) + cnt_50;
            space_cnt = 14 - encodelen((cnt_50 * 500) + ""); str_body += Space(space_cnt) + (cnt_50 * 50) + "" + "\r\n";
            //
            space_cnt = 22 - encodelen("10권"); str_body += "10권" + Space(space_cnt);
            space_cnt = 6 - encodelen(cnt_10 + ""); str_body += Space(space_cnt) + cnt_10;
            space_cnt = 14 - encodelen((cnt_10 * 10) + ""); str_body += Space(space_cnt) + (cnt_10 * 10) + "" + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42

            //
            str_amount = real_cash_amount.ToString("N0");
            space_cnt = 28 - encodelen("입력권종 합계"); str_body += "입력권종 합계" + Space(space_cnt);
            space_cnt = 14 - encodelen(str_amount); str_body += Space(space_cnt) + str_amount;

            str_body += "------------------------------------------\r\n";  // 42


            String yyyymmdd = get_today_date();
            String hhmmss = get_today_time();

            str1 = "출력: " + yyyymmdd.Substring(0, 4) + "-" + yyyymmdd.Substring(4, 2) + "-" + yyyymmdd.Substring(6, 2) + " " + hhmmss.Substring(0, 2) + ":" + hhmmss.Substring(2, 2) + ":" + hhmmss.Substring(2, 2);
            str2 = "담당: " + mUserName;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2 + "\r\n";

            return str_body;
        }


        private String make_print_goods(List<String> goods_name, List<int> cnt, List<int> amount, int sum_cnt, int sum_amount)
        {
            String str_body = "";
            String str1 = "";
            String str2 = "";
            int space_cnt = 0;

            str_body += "[ 품목별 매출 ]\r\n\r\n";


            str1 = "영업일: " + mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
            str2 = "POS No. " + myPosNo;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2 + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42

            space_cnt = 22 - encodelen("품 목 명");
            str_body += "품 목 명" + Space(space_cnt);
            space_cnt = 6 - encodelen("건수");
            str_body += Space(space_cnt) + "건수";
            space_cnt = 14 - encodelen("금액");
            str_body += Space(space_cnt) + "금액" + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42


            for (int i = 0; i < goods_name.Count; i++)
            {
                
                space_cnt = encodelen(goods_name[i]) + encodelen(cnt[i].ToString("N0"));

                if (space_cnt > 28)
                {
                    str_body += goods_name[i] + Space(42 - encodelen(goods_name[i])) + "\r\n";
                    str_body += Space(22) + Space(6 - encodelen(cnt[i].ToString("N0"))) + cnt[i].ToString("N0");
                }
                else
                {
                    str_body += goods_name[i] + Space(28 - space_cnt) + cnt[i].ToString("N0");
                }

                space_cnt = 14 - encodelen(amount[i].ToString("N0"));
                str_body += Space(space_cnt) + amount[i].ToString("N0") + "\r\n";

            }

            str_body += "------------------------------------------\r\n";  // 42


            space_cnt = encodelen("합계") + encodelen(sum_cnt.ToString("N0"));

            if (space_cnt > 28)
            {
                str_body += "합계" + Space(42 - encodelen("합계")) + "\r\n";
                str_body += Space(22) + Space(6 - encodelen(sum_cnt.ToString("N0"))) + sum_cnt.ToString("N0");
            }
            else
            {
                str_body += "합계" + Space(28 - space_cnt) + sum_cnt.ToString("N0");
            }

            space_cnt = 14 - encodelen(sum_amount.ToString("N0"));
            str_body += Space(space_cnt) + sum_amount.ToString("N0") + "\r\n";

            str_body += "------------------------------------------\r\n";  // 42



            String yyyymmdd = get_today_date();
            String hhmmss = get_today_time();

            str1 = "출력: " + yyyymmdd.Substring(0, 4) + "-" + yyyymmdd.Substring(4, 2) + "-" + yyyymmdd.Substring(6, 2) + " " + hhmmss.Substring(0, 2) + ":" + hhmmss.Substring(2, 2) + ":" + hhmmss.Substring(2, 2);
            str2 = "담당: " + mUserName;
            space_cnt = 42 - (encodelen(str1) + encodelen(str2));
            str_body += str1 + Space(space_cnt) + str2 + "\r\n";

            return str_body;
        }







        private void print_data(String strPrint)
        {

            try
            {
                const string ESC = "\u001B";
                const string InitializePrinter = ESC + "@";

                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();


                byte[] BytesValue = new byte[0];
                BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());

                //              
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());


                try
                {
                    SerialPort mySerialPort = new SerialPort();
                    mySerialPort.PortName = mBillPrinterPort;
                    mySerialPort.BaudRate = convert_number(mBillPrinterSpeed);
                    mySerialPort.Parity = Parity.None;
                    mySerialPort.StopBits = StopBits.One;
                    mySerialPort.DataBits = 8;
                    mySerialPort.Handshake = Handshake.None;

                    mySerialPort.Open();

                    mySerialPort.Write(BytesValue, 0, BytesValue.Length);
                    mySerialPort.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("프린터 출력 오류1.\r\n" + ex.Message);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("프린터 출력 오류2.");  // 파일이 이미 있으므로 만들 수 없습니다.
                return;
            }
        }


        private byte[] CutPage()
        {
            byte[] partial_cut = new byte[3] { 0x1D, 0x56, 0x00 };
            return partial_cut;
        }

        public static int encodelen(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        public static string Space(int count)
        {
            if (count < 1)
            {
                return "";
            }
            else
            {
                return new String(' ', count);
            }
        }



        private void tbEtc_TextChanged(object sender, EventArgs e)
        {
            amount_etc = convert_number(tbEtc.Text);
            calculate_cash_real();
        }

        private void tb50000_TextChanged(object sender, EventArgs e)
        {
            cnt_50000 = convert_number(tb50000.Text);
            amount_50000 = cnt_50000 * 50000;
            lbl50000.Text = amount_50000.ToString("N0");
            calculate_cash_real();
        }

        private void tb10000_TextChanged(object sender, EventArgs e)
        {
            cnt_10000 = convert_number(tb10000.Text);
            amount_10000 = cnt_10000 * 10000;
            lbl10000.Text = amount_10000.ToString("N0");
            calculate_cash_real();
        }

        private void tb5000_TextChanged(object sender, EventArgs e)
        {
            cnt_5000 = convert_number(tb5000.Text);
            amount_5000 = cnt_5000 * 5000;
            lbl5000.Text = amount_5000.ToString("N0");
            calculate_cash_real();
        }

        private void tb1000_TextChanged(object sender, EventArgs e)
        {
            cnt_1000 = convert_number(tb1000.Text);
            amount_1000 = cnt_1000 * 1000;
            lbl1000.Text = amount_1000.ToString("N0");
            calculate_cash_real();
        }

        private void tb500_TextChanged(object sender, EventArgs e)
        {
            cnt_500 = convert_number(tb500.Text);
            amount_500 = cnt_500 * 500;
            lbl500.Text = amount_500.ToString("N0");
            calculate_cash_real();
        }

        private void tb100_TextChanged(object sender, EventArgs e)
        {
            cnt_100 = convert_number(tb100.Text);
            amount_100 = cnt_100 * 100;
            lbl100.Text = amount_100.ToString("N0");
            calculate_cash_real();
        }

        private void tb50_TextChanged(object sender, EventArgs e)
        {
            cnt_50 = convert_number(tb50.Text);
            amount_50 = cnt_50 * 50;
            lbl50.Text = amount_50.ToString("N0");
            calculate_cash_real();
        }

        private void tb10_TextChanged(object sender, EventArgs e)
        {
            cnt_10 = convert_number(tb10.Text);
            amount_10 = cnt_10 * 10;
            lbl10.Text = amount_10.ToString("N0");
            calculate_cash_real();
        }



        private void tbEtc_Enter(object sender, EventArgs e)
        {
            tbEtc.SelectAll();
            mTbKeyController = tbEtc;
        }

        private void tb50000_Enter(object sender, EventArgs e)
        {
            tb50000.SelectAll();
            mTbKeyController = tb50000;
        }

        private void tb10000_Enter(object sender, EventArgs e)
        {
            tb10000.SelectAll();
            mTbKeyController = tb10000;
        }

        private void tb5000_Enter(object sender, EventArgs e)
        {
            tb5000.SelectAll();
            mTbKeyController = tb5000;
        }

        private void tb1000_Enter(object sender, EventArgs e)
        {
            tb1000.SelectAll();
            mTbKeyController = tb1000;
        }

        private void tb500_Enter(object sender, EventArgs e)
        {
            tb500.SelectAll();
            mTbKeyController = tb500;
        }

        private void tb100_Enter(object sender, EventArgs e)
        {
            tb100.SelectAll();
            mTbKeyController = tb100;
        }

        private void tb50_Enter(object sender, EventArgs e)
        {
            tb50.SelectAll();
            mTbKeyController = tb50;
        }

        private void tb10_Enter(object sender, EventArgs e)
        {
            tb10.SelectAll();
            mTbKeyController = tb10;
        }

        private void tb50000_MouseDown(object sender, MouseEventArgs e)
        {
            tb50000.SelectAll();
            mTbKeyController = tb50000;
        }

        private void tb10000_MouseDown(object sender, MouseEventArgs e)
        {
            tb10000.SelectAll();
            mTbKeyController = tb10000;
        }

        private void tb5000_MouseDown(object sender, MouseEventArgs e)
        {
            tb5000.SelectAll();
            mTbKeyController = tb5000;
        }

        private void tb1000_MouseDown(object sender, MouseEventArgs e)
        {
            tb1000.SelectAll();
            mTbKeyController = tb1000;
        }

        private void tb500_MouseDown(object sender, MouseEventArgs e)
        {
            tb500.SelectAll();
            mTbKeyController = tb500;
        }

        private void tb100_MouseDown(object sender, MouseEventArgs e)
        {
            tb100.SelectAll();
            mTbKeyController = tb100;
        }

        private void tb50_MouseDown(object sender, MouseEventArgs e)
        {
            tb50.SelectAll();
            mTbKeyController = tb50;
        }

        private void tb10_MouseDown(object sender, MouseEventArgs e)
        {
            tb10.SelectAll();
            mTbKeyController = tb10;
        }

        private void tbEtc_MouseDown(object sender, MouseEventArgs e)
        {
            tbEtc.SelectAll();
            mTbKeyController = tbEtc;
        }
    }
}
