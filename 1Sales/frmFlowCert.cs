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
using static thepos.frmSales;
using System.Security.Policy;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using static thepos.frmSub;
using System.Collections;
using System.Numerics;
using static System.Windows.Forms.AxHost;
using static thepos.ClsWin32Api;
using System.Xml.Linq;


namespace thepos
{
    public partial class frmFlowCert : Form
    {

        public frmFlowCert()
        {
            InitializeComponent();
            initialize_the();

            //
            thepos_app_log(1, this.Name, "Open", "");

        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 26);
            lvwCoupon.SmallImageList = imgList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {


            // 주문리스트뷰를 클리어
            mOrderItemList.Clear();
            mLvwOrderItem.SetObjects(mOrderItemList);
            ReCalculateAmount();

            // 닫기
            this.Close();
        }

        private void frmFlowCert_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }


        private void tbCouponNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                
                view_reload();

                tbCouponNo.Clear();
                tbCouponNo.Focus();
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            //
            view_reload();
        }


        private void view_reload()
        { 

            String t_coupon_no = tbCouponNo.Text;

            if (t_coupon_no == "")
            {
                return;
            }


            //? 쿠폰업체 추가시 아래 구분필요
            if (mCouponMID == "")
            {
                //
                thepos_app_log(3, this.Name, "view_reload()", "쿠픈판매 업체코드(MID) 미등록상태입니다.");

                MessageBox.Show("쿠픈판매 업체코드(MID) 미등록상태입니다.", "thepos");
                return;
            }


            lvwCoupon.Items.Clear();


            couponTM p = new couponTM();
            int ret = p.requestTmCertView(t_coupon_no);

            if (ret == 0)
            {
                if (mObj["result"].ToString() == "1000")
                {

                }
                else
                {
                    thepos_app_log(3, this.Name, "requestTmCertView()", "오류 " + mObj["msg"].ToString() + " no=" + t_coupon_no);
                    MessageBox.Show("오류\n\n" + mObj["msg"].ToString(), "thepos");
                    tbCouponNo.Text = "";
                    return;
                }
            }
            else
            {
                thepos_app_log(3, this.Name, "requestTmCertView()", "오류 " + mErrorMsg + " no=" + t_coupon_no);
                MessageBox.Show("오류\n\n" + mErrorMsg, "thepos");
                tbCouponNo.Text = "";
                return;
            }



            try
            {
                String data = mObj["info"].ToString();
                JArray info = JArray.Parse(data);

                for (int i = 0; i < info.Count; i++)
                {
                    string coupon_no = info[i]["barcode_no"].ToString();
                    string view_state_code = info[i]["ustate"].ToString();
                    string view_state_str = info[i]["state"].ToString();  //  예약완료 or 취소
                    string coupon_name = info[i]["cusitem"].ToString();
                    string coupon_link_no = info[i]["cusitemId"].ToString();
                    string cus_nm = info[i]["cusnm"].ToString();
                    string cus_hp = info[i]["cushp"].ToString();
                    string exp_date = info[i]["expdate"].ToString();
                    string ch_name = info[i]["cuschnm"].ToString();
                    string goods_cnt = "1";


                    String goods_code = "";
                    String goods_name = "";

                    //
                    int link_goods_idx = -1;
                    for (int k = 0; k < myGoodsItem.Length; k++)
                    {
                        if (coupon_link_no == myGoodsItem[k].coupon_link_no & myGoodsItem[k].ticket == "Y")
                        {
                            goods_code = myGoodsItem[k].goods_code;
                            goods_name = myGoodsItem[k].goods_name;
                            link_goods_idx = k;
                        }
                    }

                    if (link_goods_idx == -1)
                    {
                        goods_code = "";
                        goods_name = "[미정]";
                    }


                    //
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Checked = false;
                    lvItem.ForeColor = Color.Gray;


                    // (0:취소 1: 사용, 2: 미사용)
                    String state_name = "";
                    
                    String auth_state_code = "X";   //   X 사용불가,  0 (인증전) 1 인증 2 발권 


                    if (view_state_code == "2")   /// 결국 "2"만 정상.-> 쿠폰사용가능
                    {
                        if (view_state_str == "예약완료")
                        {
                            if (link_goods_idx == -1)
                            {
                                state_name = "사용불가";
                                view_state_code = "9";
                                
                            }
                            else
                            {
                                state_name = "사용가능";
                                auth_state_code = "0";
                                lvItem.ForeColor = Color.Blue;
                                lvItem.Checked = true;
                            }
                        }
                        else if (view_state_str == "취소")
                        {
                            state_name = "취소";
                            view_state_code = "9";
                            auth_state_code = "0";
                        }
                        else
                        {
                            state_name = "사용불가";
                            view_state_code = "9";
                            auth_state_code = "0";
                        }

                    }
                    else if (view_state_code == "1")
                        state_name = "기사용티켓";
                    else if (view_state_code == "0")
                        state_name = "취소티켓";
                    else
                        state_name = "기타(" + view_state_code + ")";


                    //
                    lvItem.Text = "";  // checkbox
                    lvItem.SubItems.Add(state_name);
                    lvItem.SubItems.Add(coupon_no);
                    lvItem.SubItems.Add(goods_name);
                    lvItem.SubItems.Add(goods_cnt);
                    lvItem.SubItems.Add(cus_hp);
                    //
                    lvItem.SubItems.Add(view_state_code);
                    lvItem.SubItems.Add(auth_state_code);                // auth_state_code 0 X Y
                    lvItem.SubItems.Add(coupon_name);
                    lvItem.SubItems.Add(coupon_link_no);
                    lvItem.SubItems.Add(cus_nm);
                    lvItem.SubItems.Add(exp_date);
                    lvItem.SubItems.Add(ch_name);
                    lvItem.SubItems.Add(goods_code);
                    lvItem.SubItems.Add(link_goods_idx + "");

                    //
                    lvwCoupon.Items.Add(lvItem);

                    thepos_app_log(1, this.Name, "view_reload()", state_name + " "  + coupon_no + " "  + goods_name + " "  + cus_hp);

                }

            }
            catch (Exception e)
            {
                //
                thepos_app_log(3, this.Name, "requestTmCertView()", "쿠폰조회중에 오류가 발생했습니다. " + e.Message);

                MessageBox.Show("오류\n\n" + "쿠폰조회중에 오류가 발생했습니다.\r\n" + e.Message, "thepos");

                return;
            }

            //
            tbCouponNo.Text = "";

        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            if (lvwCoupon.Items.Count == 0)
            {
                return;
            }
            
            // 영업일자 등 선체크 
            if (!isPreCheck(out String error_msg))
            {
                MessageBox.Show(error_msg, "thepos");
                return;
            }



            //

            for (int i = 0; i < lvwCoupon.Items.Count; i++)
            {
                if (lvwCoupon.Items[i].Checked & 
                    lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(auth_state_code)].Text == "0")
                {
                    string t_coupon_no = lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(coupon_no)].Text;

                    couponTM p = new couponTM();
                    int ret = p.requestTmCertAuth(t_coupon_no);

                    if (ret == 0)
                    {
                        if (mObj["result"].ToString() == "1000")
                        {
                            thepos_app_log(1, this.Name, "requestTmCertAuth()", "인증. no=" + t_coupon_no);

                            lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(state_name)].Text = "인증";
                            lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(auth_state_code)].Text = "1";   // 0인증전 1인증 2발권
                        }
                        else
                        {
                            String msg = mObj["msg"].ToString();
                            thepos_app_log(3, this.Name, "requestTmCertAuth()", "인증거절 " + msg + " no=" + t_coupon_no);

                            lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(state_name)].Text = "인증거절";
                            lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(auth_state_code)].Text = "X";   // 0 X Y
                        }
                    }
                    else
                    {
                        thepos_app_log(3, this.Name, "requestTmCertAuth()", "인증오류 " + mErrorMsg + " no=" + t_coupon_no);

                        lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(state_name)].Text = "인증오류";
                        lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(auth_state_code)].Text = "X";   // 0 X Y
                    }
                }
            }


            // 
            coupon_pay_cert();

        }


        private void coupon_pay_cert()
        {
            bool isExist = false;

            for (int i = 0; i < lvwCoupon.Items.Count; i++)
            {
                if (lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(auth_state_code)].Text == "1")  // 인증
                {
                    isExist = true;
                }
            }

            if (!isExist)
            { 
                return; 
            }



            //
            countup_the_no();

            mOrderItemList.Clear();


            for (int i = 0; i < lvwCoupon.Items.Count; i++)
            {
                if (lvwCoupon.Items[i].Checked == false |
                    lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(auth_state_code)].Text != "1")  // 1 인증승인 완료
                {
                    continue;
                }


                // 인증승인된 건만 아래로 진행

                int t_goods_idx = int.Parse(lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(goods_idx)].Text);
                String t_coupon_no = lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(coupon_no)].Text;
                int t_goods_cnt = int.Parse(lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(goods_cnt)].Text);

                mOrderOptionItemList.Clear();
                MemOrderItem orderItem = new MemOrderItem();
                orderItem.option_name_description = "";   // 리스트뷰 상품항목 아랫줄에 표시
                orderItem.option_amt_description = "";    // 리스트뷰 단가항목 아랫줄에 표시
                orderItem.option_item_cnt = mOrderOptionItemList.Count;
                orderItem.option_no = "";
                orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..
                orderItem.order_no = mOrderItemList.Count + 1;
                orderItem.goods_code = myGoodsItem[t_goods_idx].goods_code.ToString();
                orderItem.goods_name = myGoodsItem[t_goods_idx].goods_name;
                orderItem.ticket = myGoodsItem[t_goods_idx].ticket;
                orderItem.taxfree = myGoodsItem[t_goods_idx].taxfree;
                orderItem.allim = myGoodsItem[t_goods_idx].allim;
                orderItem.cnt = t_goods_cnt;
                orderItem.amt = myGoodsItem[t_goods_idx].amt;
                orderItem.dcr_type = "";
                orderItem.dcr_des = "";
                orderItem.dcr_value = 0;
                orderItem.shop_code = myGoodsItem[t_goods_idx].shop_code;
                orderItem.coupon_no = t_coupon_no;
                mOrderItemList.Add(orderItem);
                //
                mNetAmount += orderItem.cnt * orderItem.amt;
            }
            

            //!
            int order_cnt = 0;
            int dcAmount = 0;


            // 리스트뷰 -> 메모리배열 생성 : [ 업장코드로 정렬 + 업장주문번호 부여 ]
            //MemOrderItem[] memOrderItemArr = getMemOrderItemArr(out dcAmount);

            set_shop_order_no_on_orderitem(out dcAmount);



            // orders, orderItem 
            order_cnt = SaveOrder("");  // 
            if (order_cnt == -1)
            {
                //return; // 재로그인 요구
            }


            //  payment
            if (!SavePayment(1, "Cert", mNetAmount, dcAmount))
            {
                //return;
            }


            //
            for (int i = 0; i < lvwCoupon.Items.Count; i++)
            {
                if (lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(auth_state_code)].Text != "1")  // 1 인증승인 완료
                {
                    continue;
                }

                String t_coupon_no = lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(coupon_no)].Text;
                int t_goods_cnt = int.Parse(lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(goods_cnt)].Text);

                int t_goods_idx = int.Parse(lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(goods_idx)].Text);
                int t_goods_amt = myGoodsItem[t_goods_idx].amt;

                String t_coupon_link_no = lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(coupon_link_no)].Text;


                PaymentCert mPaymentCert = new PaymentCert();
                mPaymentCert.site_id = mSiteId;
                mPaymentCert.biz_dt = mBizDate;
                mPaymentCert.pos_no = myPosNo;
                mPaymentCert.the_no = mTheNo;
                mPaymentCert.ref_no = mRefNo; // 

                mPaymentCert.pay_date = get_today_date();
                mPaymentCert.pay_time = get_today_time();
                mPaymentCert.pay_type = "M0";       // 결제구분 : 쿠폰인증(M0)
                mPaymentCert.tran_type = "A";       // 승인 A 취소 C
                mPaymentCert.pay_class = mPayClass;

                mPaymentCert.ticket_no = "";
                mPaymentCert.pay_seq = i; // 
                mPaymentCert.tran_date = get_today_date() + get_today_time();
                mPaymentCert.amount = t_goods_cnt * t_goods_amt;    // 결제금액
                mPaymentCert.coupon_no = t_coupon_no;
                mPaymentCert.is_cancel = "";         // 취소여부
                mPaymentCert.van_code = "TM";        // TM : 테이블메니저
                mPaymentCert.cnt = 1;
                mPaymentCert.coupon_link_no = t_coupon_link_no;

                // 결제 항목 저장
                if (!SavePaymentCert(mPaymentCert))
                {
                    return;
                }

            }




            int settel_amt = mNetAmount;


            // 티켓 저장
            int ticket_cnt = SaveTicketFlow("", mPayClass, "US", settel_amt);




            for (int i = 0; i < lvwCoupon.Items.Count; i++)
            {
                if (lvwCoupon.Items[i].Checked &
                    lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(auth_state_code)].Text == "1")
                {
                    lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(state_name)].Text = "인증발권";
                    lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(auth_state_code)].Text = "2";    // 2 발권

                    lvwCoupon.Items[i].ForeColor = Color.Black;

                    thepos_app_log(1, this.Name, "coupon_pay_cert()", "인증발권 no=" + lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(coupon_no)].Text);
                }
            }



            // 주문서 출력 : 업장용 + 고객용
            // 주문서 출력
            /*
            String[] order_no_from_to = new String[2];

            order_no_from_to[0] = "";
            order_no_from_to[1] = "";

            List<shop_order_pack> shopOrderPackList = new List<shop_order_pack>();

            order_no_from_to = print_order(ref shopOrderPackList);


            // 영수증 출력
            print_bill(mTheNo, "A", "", "00001", true, order_no_from_to); // cert
            */


        }


        private bool SavePaymentCert(PaymentCert mPaymentCert)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Clear();
            parameters["siteId"] = mPaymentCert.site_id;
            parameters["posNo"] = mPaymentCert.pos_no;
            parameters["bizDt"] = mPaymentCert.biz_dt;
            parameters["theNo"] = mPaymentCert.the_no;
            parameters["refNo"] = mPaymentCert.ref_no;

            parameters["payDate"] = mPaymentCert.pay_date;
            parameters["payTime"] = mPaymentCert.pay_time;
            parameters["payType"] = mPaymentCert.pay_type;
            parameters["tranType"] = mPaymentCert.tran_type;
            parameters["payClass"] = mPaymentCert.pay_class;

            parameters["ticketNo"] = mPaymentCert.ticket_no;
            parameters["paySeq"] = mPaymentCert.pay_seq + "";
            parameters["tranDate"] = mPaymentCert.tran_date;
            parameters["amount"] = mPaymentCert.amount + "";

            parameters["couponNo"] = mPaymentCert.coupon_no;
            parameters["isCancel"] = mPaymentCert.is_cancel;
            parameters["vanCode"] = mPaymentCert.van_code;

            parameters["couponLinkNo"] = mPaymentCert.coupon_link_no;
            parameters["cnt"] = mPaymentCert.cnt + "";


            if (mRequestPost("paymentCert", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류 paymentCert\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류 paymentCert\n\n" + mErrorMsg, "thepos");
                return false;
            }

            return true;

        }




        private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwCoupon.Items.Count; i++)
            {
                if (lvwCoupon.Items[i].SubItems[lvwCoupon.Columns.IndexOf(view_state_code)].Text == "2")
                {
                    lvwCoupon.Items[i].Checked = true;
                }
                else
                {
                    lvwCoupon.Items[i].Checked = false;
                }
            }
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwCoupon.Items.Count; i++)
            {
                lvwCoupon.Items[i].Checked = false;
            }
        }
    }
}
