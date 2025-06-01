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
            imgList.ImageSize = new Size(1, 30);
            lvwCoupon.SmallImageList = imgList;
            lvwCert.SmallImageList = imgList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.tbCouponNo.Leave -= new System.EventHandler(this.tbCouponNo_Leave);


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
            clear_info();



            couponTM p = new couponTM();
            int ret = p.requestTmCertView(t_coupon_no);

            if (ret == 0)
            {
                if (mObj["result"].ToString() == "1000")
                {

                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["msg"].ToString(), "thepos");
                    tbCouponNo.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("오류\n\n" + mErrorMsg, "thepos");
                tbCouponNo.Text = "";
                return;
            }


            // 다음 화면에서 에러날지 미리 해본다..
            try
            {
                String data = mObj["info"].ToString();
                JObject info = JObject.Parse(data);

                string coupon_no = info["barcode_no"].ToString();
                string ustate_code = info["ustate"].ToString();
                string coupon_name = info["cusitem"].ToString();
                string coupon_link_no = info["cusitemId"].ToString();   // 상품코드 매칭용   TM + 0000

                string goods_cnt = "1";

                string cus_nm = info["cusnm"].ToString();
                string cus_hp = info["cushp"].ToString();
                string exp_date = info["expdate"].ToString();

                string state = info["state"].ToString();
                string ch_name = info["cuschnm"].ToString();


                String goods_code = "";
                String goods_name = "";

                //
                int link_goods_idx = -1;
                for (int i = 0; i < mGoodsItem.Length; i++)
                {
                    if (coupon_link_no == mGoodsItem[i].coupon_link_no & mGoodsItem[i].ticket == "Y")
                    {
                        goods_code = mGoodsItem[i].goods_code;
                        goods_name = mGoodsItem[i].goods_name;

                        link_goods_idx = i;
                    }
                }

                if (link_goods_idx == -1)
                {
                    goods_code = "";
                    goods_name = "[미정]";
                }



                ListViewItem lvItem = new ListViewItem();


                // (0:취소 1: 사용, 2: 미사용)
                String ustate_name = "";
                if (ustate_code == "2")
                {
                    if (link_goods_idx == -1)
                    {
                        ustate_name = "사용불가";
                    }
                    else
                    {
                        ustate_name = "사용가능";
                    }
                }
                else if (ustate_code == "1")
                    ustate_name = "기사용티켓";
                else if (ustate_code == "0")
                    ustate_name = "취소티켓";
                else
                    ustate_name = "";



                //
                lvItem.Text = ustate_name;
                lvItem.SubItems.Add(coupon_no);
                lvItem.SubItems.Add(goods_name);
                lvItem.SubItems.Add(goods_cnt);
                lvItem.SubItems.Add(cus_hp);

                //
                lvItem.SubItems.Add(ustate_code);
                lvItem.SubItems.Add(state);
                lvItem.SubItems.Add(coupon_name);
                lvItem.SubItems.Add(coupon_link_no);
                lvItem.SubItems.Add(cus_nm);
                lvItem.SubItems.Add(exp_date);
                lvItem.SubItems.Add(ch_name);
                lvItem.SubItems.Add(goods_code);
                lvItem.SubItems.Add(link_goods_idx + "");

                //
                lvwCoupon.Items.Add(lvItem);

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

        private void clear_info()
        {
            lblState.Text = "";
            lblUstate.Text = "";

            lblCouponNo.Text = "";
            lblCouponName.Text = "";
            lblQty.Text = "";

            lblChName.Text = "";
            lblExpdate.Text = "";
            lblCusnm.Text = "";
            lblCushp.Text = "";

            lblGoodsName.Text = "";

        }


        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t_coupon_no = "";
            String t_coupon_link_no = "";
            int t_coupon_cnt = 1;




            if (lvwCoupon.SelectedItems.Count < 1)
            {
                clear_info();
                return;
            }


            lblState.Text = lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(state)].Text;
            lblUstate.Text = lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(ustate_name)].Text;

            lblCouponNo.Text = lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(coupon_no)].Text;
            lblCouponName.Text = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(coupon_name)].Text;
            lblQty.Text = lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(goods_cnt)].Text;

            lblChName.Text = lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(ch_name)].Text;
            lblExpdate.Text = lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(exp_date)].Text;
            lblCusnm.Text = lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(cus_nm)].Text;
            lblCushp.Text = lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(cus_hp)].Text;
            lblGoodsName.Text = lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(goods_name)].Text;

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (lvwCoupon.SelectedItems.Count == 0)
            {
                return;
            }


            // ustate_code == 2 & goods_code != ""
            if (lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(goods_code)].Text != "" & lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(state)].Text == "2")
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = "인증전";
                lvItem.SubItems.Add(lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(coupon_no)].Text);
                lvItem.SubItems.Add(lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(goods_name)].Text);
                lvItem.SubItems.Add(lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(goods_cnt)].Text);

                int t_goods_idx = int.Parse(lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(goods_idx)].Text);
                lvItem.SubItems.Add(mGoodsItem[t_goods_idx].amt + "");

                lvItem.SubItems.Add(lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(coupon_link_no)].Text);
                lvItem.SubItems.Add(lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(goods_code)].Text);
                lvItem.SubItems.Add("00"); // 00 인증전, 10 인증, 1X 인증오류 20 발권 2X 발권오류
                lvItem.SubItems.Add(lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(goods_idx)].Text);

                lvwCert.Items.Add(lvItem);

                // 삭제
                lvwCoupon.SelectedItems[0].Remove();
            }
        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            if (lvwCert.Items.Count == 0)
            {
                return;
            }
            
            // 영업일자 등 선체크 
            if (!isPreCheck(out String error_msg))
            {
                MessageBox.Show(error_msg, "thepos");
                return;
            }


            for (int i = 0; i < lvwCert.Items.Count; i++)
            {
                string t_coupon_no = lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(coupon_no2)].Text;

                couponTM p = new couponTM();
                int ret = p.requestTmCertAuth(t_coupon_no);

                if (ret == 0)
                {
                    if (mObj["result"].ToString() == "1000")
                    {
                        thepos_app_log(1, this.Name, "requestTmCertAuth()", "정상. coupon_no=" + t_coupon_no);

                        // 리스트뷰 상태변경
                        lvwCert.Items[i].Text = "인증";
                        lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(ticket_stat_code)].Text = "10";

                    }
                    else
                    {
                        String msg = mObj["msg"].ToString();
                        thepos_app_log(3, this.Name, "requestTmCertAuth()", "오류 " + msg + " coupon_no=" + t_coupon_no);

                        //MessageBox.Show("오류\n\n" + msg, "thepos");

                        // 리스트뷰 상태변경
                        lvwCert.Items[i].Text = "인증오류";
                        lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(ticket_stat_code)].Text = "1X";
                    }
                }
                else
                {
                    thepos_app_log(3, this.Name, "requestTmCertAuth()", mErrorMsg);

                    //MessageBox.Show(mErrorMsg, "thepos");

                    // 리스트뷰 상태변경
                    lvwCert.Items[i].Text = "인증오류";
                    lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(ticket_stat_code)].Text = "1X";
                }
            }


            // 
            all_order_pay_cert();

        }


        private void all_order_pay_cert()
        {
            bool isExist = false;

            for (int i = 0; i < lvwCert.Items.Count; i++)
            {
                if (lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(ticket_stat_code)].Text == "10")  // 인증
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


            for (int i = 0; i < lvwCert.Items.Count; i++)
            {
                if (lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(ticket_stat_code)].Text != "10")  // 1 인증승인 완료
                {
                    continue;
                }


                // 인증승인된 건만 아래로 진행

                int t_goods_idx = int.Parse(lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(goods_idx2)].Text);
                String t_coupon_no = lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(coupon_no2)].Text;
                int t_goods_cnt = int.Parse(lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(goods_cnt2)].Text);

                mOrderOptionItemList.Clear();
                MemOrderItem orderItem = new MemOrderItem();
                orderItem.option_name_description = "";   // 리스트뷰 상품항목 아랫줄에 표시
                orderItem.option_amt_description = "";    // 리스트뷰 단가항목 아랫줄에 표시
                orderItem.option_item_cnt = mOrderOptionItemList.Count;
                orderItem.option_no = "";
                orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..
                orderItem.order_no = mOrderItemList.Count + 1;
                orderItem.goods_code = mGoodsItem[t_goods_idx].goods_code.ToString();
                orderItem.goods_name = mGoodsItem[t_goods_idx].goods_name;
                orderItem.ticket = mGoodsItem[t_goods_idx].ticket;
                orderItem.taxfree = mGoodsItem[t_goods_idx].taxfree;
                orderItem.allim = mGoodsItem[t_goods_idx].allim;
                orderItem.cnt = t_goods_cnt;
                orderItem.amt = mGoodsItem[t_goods_idx].amt;
                orderItem.dcr_type = "";
                orderItem.dcr_des = "";
                orderItem.dcr_value = 0;
                orderItem.shop_code = mGoodsItem[t_goods_idx].shop_code;
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
                return; // 재로그인 요구
            }


            //  payment
            if (!SavePayment(1, "Cert", mNetAmount, dcAmount))
            {
                return;
            }


            //
            for (int i = 0; i < lvwCert.Items.Count; i++)
            {
                if (lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(ticket_stat_code)].Text != "10")  // 1 인증승인 완료
                {
                    continue;
                }

                String t_coupon_no = lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(coupon_no2)].Text;
                int t_goods_cnt = int.Parse(lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(goods_cnt2)].Text);
                int t_goods_amt = int.Parse(lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(goods_amt)].Text);


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
                mPaymentCert.coupon_link_no = "";

                // 결제 항목 저장
                if (!SavePaymentCert(mPaymentCert))
                {
                    return;
                }

            }




            int settel_amt = mNetAmount;


            // 티켓 저장
            int ticket_cnt = SaveTicketFlow("", mPayClass, "US", settel_amt);




            for (int i = 0; i < lvwCert.Items.Count; i++)
            {
                if (lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(ticket_stat_code)].Text != "10")  // 1 인증승인 완료
                {
                    continue;
                }

                lvwCert.Items[i].Text = "발권";
                lvwCert.Items[i].SubItems[lvwCert.Columns.IndexOf(ticket_stat_code)].Text = "20";
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





        private void tbCouponNo_Leave(object sender, EventArgs e)
        {
            tbCouponNo.Focus();
        }

        private void lvwCert_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPayClearSel_Click(object sender, EventArgs e)
        {
            if (lvwCert.SelectedItems.Count > 0)
            {
                lvwCert.SelectedItems[0].Remove();
            }

        }

        private void btnPayClearAll_Click(object sender, EventArgs e)
        {
            lvwCert.Items.Clear();
        }
    }
}
