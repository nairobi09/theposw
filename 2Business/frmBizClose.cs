using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.MsForms;
using DocumentFormat.OpenXml.Vml.Office;
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
using thepos._1Sales;
using static thepos.thePos;

namespace thepos
{
    public partial class frmBizClose : Form
    {


        public frmBizClose()
        {
            InitializeComponent();

            initialize_the();

            load_card_data();

            load_pay_data();

            load_goods_data();



            //
            thepos_app_log(1, this.Name, "open", "");

        }


        private void initialize_the()
        {
            lblBizDate.Text = "";
            lblPosNo.Text = myPosNo;
            lblLoginName.Text = mUserName;

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

                    if (arr.Count > 0)
                    {
                        int sum_cnt = 0;
                        int sum_amount = 0;

                        for (int i = 0; i < arr.Count; i++)
                        {
                            ListViewItem tItem = new ListViewItem();
                            tItem.Text = arr[i]["cardName"].ToString();

                            int cnt = convert_number(arr[i]["cnt"].ToString());
                            int amount = convert_number(arr[i]["amountCard"].ToString());

                            sum_cnt += cnt;
                            sum_amount += amount;

                            tItem.SubItems.Add(cnt.ToString("N0"));
                            tItem.SubItems.Add(amount.ToString("N0"));

                            lvwCard.Items.Add(tItem);
                        }

                        ListViewItem sItem = new ListViewItem();
                        sItem.Text = "합계";
                        sItem.SubItems.Add(sum_cnt.ToString("N0"));
                        sItem.SubItems.Add(sum_amount.ToString("N0"));
                        lvwCard.Items.Add(sItem);
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


        private void load_pay_data()
        {
            String sUrl = "reportDayPos?siteId=" + mSiteId + "&bizDt=" + mBizDate;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayPos"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (arr[i]["posNo"].ToString() == myPosNo)
                        {
                            int cash_cnt = convert_number(arr[i]["cntCash"].ToString());
                            int card_cnt = convert_number(arr[i]["cntCard"].ToString());
                            int easy_cnt = convert_number(arr[i]["cntEasy"].ToString());
                            int cert_cnt = convert_number(arr[i]["cntCert"].ToString());
                            int net_cnt = cash_cnt + card_cnt + easy_cnt + cert_cnt;

                            int cash_amount = convert_number(arr[i]["amountCash"].ToString());
                            int card_amount = convert_number(arr[i]["amountCard"].ToString());
                            int easy_amount = convert_number(arr[i]["amountEasy"].ToString());
                            int cert_amount = convert_number(arr[i]["amountCert"].ToString());
                            int net_amount = convert_number(arr[i]["netAmount"].ToString());

                            ListViewItem sItem;

                            sItem = new ListViewItem();
                            sItem.Text = "현금";
                            sItem.SubItems.Add(cash_cnt.ToString("N0"));
                            sItem.SubItems.Add(cash_amount.ToString("N0"));
                            lvwPay.Items.Add(sItem);

                            sItem = new ListViewItem();
                            sItem.Text = "카드";
                            sItem.SubItems.Add(card_cnt.ToString("N0"));
                            sItem.SubItems.Add(card_amount.ToString("N0"));
                            lvwPay.Items.Add(sItem);

                            sItem = new ListViewItem();
                            sItem.Text = "간편";
                            sItem.SubItems.Add(easy_cnt.ToString("N0"));
                            sItem.SubItems.Add(easy_amount.ToString("N0"));
                            lvwPay.Items.Add(sItem);

                            sItem = new ListViewItem();
                            sItem.Text = "쿠폰";
                            sItem.SubItems.Add(cert_cnt.ToString("N0"));
                            sItem.SubItems.Add(cert_amount.ToString("N0"));
                            lvwPay.Items.Add(sItem);

                            sItem = new ListViewItem();
                            sItem.Text = "합계";
                            sItem.SubItems.Add(net_cnt.ToString("N0"));
                            sItem.SubItems.Add(net_amount.ToString("N0"));
                            lvwPay.Items.Add(sItem);

                        }
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


        private void load_goods_data()
        {
            String sUrl = "reportDayPosGoods?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + myPosNo;
            
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayPosGoods"].ToString();
                    JArray arr = JArray.Parse(data);

                    ListViewItem sItem;
                    int sum_goods_cnt = 0;
                    int sum_goods_amount = 0;

                    for (int i = 0; i < arr.Count; i++)
                    {
                        String goods_code = arr[i]["goodsCode"].ToString();
                        int goods_cnt = convert_number(arr[i]["cnt"].ToString());
                        int net_amount = convert_number(arr[i]["netAmount"].ToString());

                        sum_goods_cnt += goods_cnt;
                        sum_goods_amount += net_amount;

                        sItem = new ListViewItem();
                        sItem.Text = get_goods_name(goods_code);
                        sItem.SubItems.Add(goods_cnt.ToString("N0"));
                        sItem.SubItems.Add(net_amount.ToString("N0"));
                        lvwGoods.Items.Add(sItem);
                    }

                    sItem = new ListViewItem();
                    sItem.Text = "합계";
                    sItem.SubItems.Add(sum_goods_cnt.ToString("N0"));
                    sItem.SubItems.Add(sum_goods_amount.ToString("N0"));
                    lvwGoods.Items.Add(sItem);

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

        private void btnPrintCard_Click(object sender, EventArgs e)
        {
            if (mBillPrinterPort.Trim().Length == 0)
            {
                MessageBox.Show("프린터 미설정으로 출력불가");
                return;
            }


            String strPrint = make_print_card();



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
            return new String(' ', count);
        }


        private String make_print_card()
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


            for (int i = 0; i < lvwCard.Items.Count; i++)
            {
                String card_name = lvwCard.Items[i].Text;
                String cnt = lvwCard.Items[i].SubItems[1].Text;
                String amount = lvwCard.Items[i].SubItems[2].Text;

                space_cnt = 16 - encodelen(card_name);
                str_body += card_name + Space(space_cnt);

                space_cnt = 12 - encodelen(cnt);
                str_body += Space(space_cnt) + cnt;

                space_cnt = 14 - encodelen(amount);
                str_body += Space(space_cnt) + amount + "\r\n";
            }

            str_body += "------------------------------------------\r\n";  // 42


            String yyyymmdd = get_today_date();
            String hhmmss = get_today_time();

            str_body += "출력 : " + yyyymmdd.Substring(0, 4) + "-" + yyyymmdd.Substring(4, 2) + "-" + yyyymmdd.Substring(6, 2) + " ";
            str_body += hhmmss.Substring(0, 2) + ":" + hhmmss.Substring(2, 2) + ":" + hhmmss.Substring(2, 2) + "\r\n";

            return str_body;
        }
    }
}
