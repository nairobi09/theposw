﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static thepos.thePos;

namespace thepos
{
    internal class couponPM
    {
        //String PLACEM_URL = "https://gateway.sparo.cc/extra/kiosk/v1/";

        String TM_URL = "https://gateway.ticketmanager.ai/";
        String TM_KEY = "dae13182479f66cb1aab435aa28deb763bf1123e105bfcb6932d4e4e04a75499";
        String sUrl = "";
        String rcode = "";
        String rmsg = "";
        String rcnt = "";




        public int requestPmCertView(String tNo)
        {
            sUrl = TM_URL + "/extra/agency/v2/chorder/" + tNo;

            try
            {
                var baseAddress = new Uri(TM_URL);

                var httpClient = new HttpClient { BaseAddress = baseAddress };


                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", TM_KEY);


                var response = httpClient.GetAsync("extra/agency/v2/chorder/" + tNo).Result;


                

                String responseString = response.Content.ReadAsStringAsync().Result;


                JObject obj = JObject.Parse(responseString);

                if (obj["Code"].ToString() != "1000")
                {
                    MessageBox.Show(obj["Msg"].ToString(), "오류");
                    return -1;
                }



                String data = mObj["allims"].ToString();
                JArray arr = JArray.Parse(data);







                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(responseString);

                XmlNodeList nodes = xdoc.SelectNodes("/RESULT");
                foreach (XmlNode res in nodes)
                {
                    rcode = res.SelectSingleNode("RCODE").InnerText;
                    rmsg = res.SelectSingleNode("RMSG").InnerText;
                    rcnt = res.SelectSingleNode("RCNT").InnerText;
                }


                if (rcode == "E")
                {
                    MessageBox.Show(rmsg, "thepos");
                    return -1;
                }


                if (rcode != "S" | rcnt == "0")
                {
                    return -1;
                }


                nodes = xdoc.SelectNodes("/RESULT/ORDERS/ORDER");

                foreach (XmlNode order in nodes)
                {
                    CertOrder certOrder = new CertOrder();
                    certOrder.order_no = order.SelectSingleNode("ORDERNO").InnerText;
                    certOrder.coupon_no = order.SelectSingleNode("COUPONNO").InnerText;
                    certOrder.menu_code = order.SelectSingleNode("MENUCODE").InnerText;
                    certOrder.menu_name = order.SelectSingleNode("MENUNAME").InnerText;
                    certOrder.qty = convert_number(order.SelectSingleNode("QTY").InnerText);
                    certOrder.exp_date = order.SelectSingleNode("EXPDATE").InnerText;
                    certOrder.state = order.SelectSingleNode("STATE").InnerText;
                    certOrder.ustate = order.SelectSingleNode("USTATE").InnerText;
                    certOrder.cus_nm = order.SelectSingleNode("CUSNM").InnerText;
                    certOrder.cus_hp = order.SelectSingleNode("CUSHP").InnerText;
                    certOrder.cus_opt = order.SelectSingleNode("CUSOPT").InnerText;

                    if (certOrder.state == "예약완료" & certOrder.ustate == "2")  // 2 미사용
                        certOrder.is_usage = "Y";
                    else
                        certOrder.is_usage = "N";

                    mCertOrders.Add(certOrder);
                }
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return -1;
            }

            return 0;
        }




        public int requestPmCertAuth(String tCouponNo)
        {
            String sUrl = TM_URL + "req.php?pc=US&pval=" + tCouponNo + "&ch=" + mCouponChPM + "&fcno=POS_" + mPosNo;

            try
            {
                var response = mHttpClient.GetAsync(sUrl).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(responseString);


                XmlNodeList nodes = xdoc.SelectNodes("/RESULT");
                foreach (XmlNode res in nodes)
                {
                    rcode = res.SelectSingleNode("RCODE").InnerText;
                    rmsg = res.SelectSingleNode("RMSG").InnerText;
                }


                if (rcode == "S")  // 성공
                {
                    return 0;
                }
                else
                {
                    MessageBox.Show("쿠폰사용요청 실패응답. \r\n\r\n" + rmsg, "thepos");
                    return -1;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("아래 메시지를 관리자에게 전달바랍니다. \r\n\r\n" + ex.Message, "시스템오류");
                return -1;
            }

        }

        public int requestPmCertCancel(String tCouponNo)
        {
            String sUrl = TM_URL + "req.php?pc=RC&pval=" + tCouponNo + "&ch=" + mCouponChPM + "&fcno=POS_" + mPosNo;

            try
            {
                var response = mHttpClient.GetAsync(sUrl).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(responseString);


                XmlNodeList nodes = xdoc.SelectNodes("/RESULT");
                foreach (XmlNode res in nodes)
                {
                    rcode = res.SelectSingleNode("RCODE").InnerText;
                    rmsg = res.SelectSingleNode("RMSG").InnerText;
                }


                if (rcode == "S")  // 성공
                {
                    return 0;
                }
                else
                {
                    MessageBox.Show("쿠폰사용요청 실패응답. \r\n\r\n" + rmsg, "thepos");
                    return -1;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("아래 메시지를 관리자에게 전달바랍니다. \r\n\r\n" + ex.Message, "시스템오류");
                return -1;
            }

        }
    
    
        public int requestPmReportView(String from_dt, String to_dt)
        {

            mCertOrders.Clear();


            sUrl = TM_URL + "req.php?pc=CL&ch=" + mCouponChPM + "&fcno=POS_" + mPosNo + "&sdate=" + from_dt + "&edate=" + to_dt;

            try
            {
                var response = mHttpClient.GetAsync(sUrl).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(responseString);

                XmlNodeList nodes = xdoc.SelectNodes("/RESULT");
                foreach (XmlNode res in nodes)
                {
                    rcode = res.SelectSingleNode("RCODE").InnerText;
                    rmsg = res.SelectSingleNode("RMSG").InnerText;
                    rcnt = res.SelectSingleNode("RCNT").InnerText;
                }


                if (rcode == "E")
                {
                    MessageBox.Show(rmsg, "thepos");
                    return -1;
                }


                if (rcode != "S" | rcnt == "0")
                {
                    return -1;
                }


                nodes = xdoc.SelectNodes("/RESULT/ORDERS/ORDER");

                foreach (XmlNode order in nodes)
                {
                    CertOrder certOrder = new CertOrder();
                    certOrder.order_no = "";
                    certOrder.coupon_no = order.SelectSingleNode("COUPONNO").InnerText;
                    certOrder.menu_code = order.SelectSingleNode("MENUCODE").InnerText;
                    certOrder.menu_name = "";
                    certOrder.qty = convert_number(order.SelectSingleNode("QTY").InnerText);
                    certOrder.exp_date = order.SelectSingleNode("USEDATE").InnerText;   // 사용일자
                    certOrder.state = "";
                    certOrder.ustate = "";
                    certOrder.cus_nm = "";
                    certOrder.cus_hp = "";
                    certOrder.cus_opt = "";
                    certOrder.is_usage = "";

                    mCertOrders.Add(certOrder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "thepos");
                return -1;
            }

            return 0;
        }    
    
    
    
    }
}
