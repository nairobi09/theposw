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


namespace thepos
{
    public partial class frmFlowCert : Form
    {

        public frmFlowCert()
        {
            InitializeComponent();
            initialize_the();
        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwCoupon.SmallImageList = imgList;

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

            // 샘플 티켓 출력용 - 테스트
            //print_ticket("2501202504180186171301", "100004", "6976680442186471");


            view_reload();
        }


        private void view_reload()
        { 
            mClearSaleForm();


            if (tbCouponNo.Text.Trim() == "")
            {
                return;
            }


            //? 쿠폰업체 추가시 아래 구분필요
            if (mCouponMID == "")
            {
                MessageBox.Show("쿠픈판매 업체코드(MID) 미등록상태입니다.", "thepos");
                return;
            }


            lvwCoupon.Items.Clear();
            clear_info();



            couponTM p = new couponTM();
            int ret = p.requestPmCertView(tbCouponNo.Text);

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


            String data = mObj["info"].ToString();
            JObject info = JObject.Parse(data);

            string coupon_no = info["barcode_no"].ToString();
            string ustate_code = info["ustate"].ToString();
            string coupon_name = info["cusitem"].ToString();
            string coupon_link_no = info["cusitemId"].ToString();   // 상품코드 매칭용   TM + 0000

            string qty = "1";

            string cus_nm = info["cusnm"].ToString();
            string cus_hp = info["cushp"].ToString();
            string exp_date = info["expdate"].ToString();

            string state = info["state"].ToString();
            string ch_name = info["cuschnm"].ToString();


            ListViewItem lvItem = new ListViewItem();

            String ustate_name = "";

            // (1: 사용, 2: 미사용)
            if (ustate_code == "2")
                ustate_name = "사용가능";
            else if (ustate_code == "1")
                ustate_name = "기사용쿠폰";
            else
                ustate_name = "";


            lvItem.Text = ustate_name;
            lvItem.SubItems.Add(ustate_code);

            lvItem.SubItems.Add(coupon_no);

            lvItem.SubItems.Add(coupon_name);
            lvItem.SubItems.Add(coupon_link_no);
            lvItem.SubItems.Add(qty);

            lvItem.SubItems.Add(cus_nm);
            lvItem.SubItems.Add(cus_hp);
            lvItem.SubItems.Add(exp_date);
            lvItem.SubItems.Add(state);
            lvItem.SubItems.Add(ch_name);

            lvwCoupon.Items.Add(lvItem);


            //
            tbCouponNo.Text = "";

            btnCoupon.Enabled = false;

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

            int link_goods_idx = -1;


            mClearSaleForm();

            if (lvwCoupon.SelectedItems.Count < 1)
            {
                clear_info();
                return;
            }

            t_coupon_no = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(coupon_no)].Text;
            t_coupon_link_no = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(coupon_link_no)].Text;


            lblState.Text = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(state)].Text;
            lblUstate.Text = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(ustate_name)].Text;

            lblCouponNo.Text = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(coupon_no)].Text;
            lblCouponName.Text = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(coupon_name)].Text + " [" + lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(coupon_link_no)].Text + "]";
            lblQty.Text = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(qty)].Text;

            lblChName.Text = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(ch_name)].Text;
            lblExpdate.Text = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(exp_date)].Text;
            lblCusnm.Text = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(cus_nm)].Text;
            lblCushp.Text = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(cus_hp)].Text;





            //
            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (t_coupon_link_no == mGoodsItem[i].coupon_link_no)
                {
                    link_goods_idx = i;
                }
            }


            if (link_goods_idx == -1)
            {
                lblGoodsName.Text = "상품정보 연결 오류.";

                SetDisplayAlarm("W", "쿠폰에 해당하는 상품정보가 없습니다.\r\n관리자 문의바랍니다.");
                return;
            }
            else
            {
                lblGoodsName.Text = mGoodsItem[link_goods_idx].goods_name + " [" + mGoodsItem[link_goods_idx].goods_code + "]";


                // 주문 리스트뷰에 추가
                if (lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(ustate_code)].Text == "2")   // (1: 사용, 2: 미사용)
                {

                    t_coupon_link_no = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(coupon_link_no)].Text;
                    t_coupon_cnt = convert_number(lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(qty)].Text);




                    // 옵션항목 목록: frmOrderOption에서 채운다.
                    mOrderOptionItemList.Clear();

                    int order_cnt = 1;

                    if (mGoodsItem[link_goods_idx].option_template_id != "")
                    {
                        frmOrderOption fForm = new frmOrderOption(mGoodsItem[link_goods_idx]);
                        DialogResult ret = fForm.ShowDialog();

                        if (ret == DialogResult.Cancel)
                        {
                            return;
                        }

                        // 수량을 전역변수에서 받음 : fk30fgu9w04ufgw
                        order_cnt = mOrderCntInOption;

                    }



                    MemOrderItem orderItem = new MemOrderItem();


                    orderItem.option_name_description = "";   // 리스트뷰 상품항목 아랫줄에 표시
                    orderItem.option_amt_description = "";    // 리스트뷰 단가항목 아랫줄에 표시



                    //
                    orderItem.option_item_cnt = mOrderOptionItemList.Count;
                    orderItem.option_no = "";
                    orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..

                    orderItem.order_no = mOrderItemList.Count + 1;
                    orderItem.goods_code = mGoodsItem[link_goods_idx].goods_code.ToString();
                    orderItem.goods_name = mGoodsItem[link_goods_idx].goods_name;
                    orderItem.ticket = mGoodsItem[link_goods_idx].ticket;
                    orderItem.taxfree = mGoodsItem[link_goods_idx].taxfree;
                    orderItem.allim = mGoodsItem[link_goods_idx].allim;

                    orderItem.cnt = t_coupon_cnt;

                    orderItem.amt = mGoodsItem[link_goods_idx].amt;
                    //orderItem.option_amt    // 위에서 세팅

                    orderItem.dcr_type = "";
                    orderItem.dcr_des = "";
                    orderItem.dcr_value = 0;
                    orderItem.shop_code = mGoodsItem[link_goods_idx].shop_code;

                    orderItem.coupon_no = t_coupon_no;



                    //
                    replace_mem_order_item(ref orderItem, "add");

                    mOrderItemList.Add(orderItem);


                    mLvwOrderItem.SetObjects(mOrderItemList);

                    mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].EnsureVisible();
                    //mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].Selected = true;

                    ReCalculateAmount();

                    btnCoupon.Enabled = true;

                }
                else
                {
                    SetDisplayAlarm("W", "사용할 수 없는 쿠폰입니다.");
                    return;
                }
            }
        }


        private void btnCoupon_Click(object sender, EventArgs e)
        {
            // 영업일자 등 선체크 
            if (!isPreCheck(out String error_msg))
            {
                MessageBox.Show(error_msg, "thepos");
                return;
            }


            string t_coupon_no = lvwCoupon.Items[lvwCoupon.SelectedItems[0].Index].SubItems[lvwCoupon.Columns.IndexOf(coupon_no)].Text;

            couponTM p = new couponTM();
            int ret = p.requestPmCertAuth(t_coupon_no);

            if (ret == 0)
            {
                if (mObj["result"].ToString() == "1000")
                {
                    // 
                    order_pay_cert();


                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["msg"].ToString(), "thepos");
                    return;
                }
            }

        }





        private void order_pay_cert()
        { 
            //
            String ticketNo = "";


            if (mOrderItemList.Count == 0)
            {
                return;
            }


            if (mNetAmount < 0)
            {
                SetDisplayAlarm("W", "유효한 결제금액인지 확인요망.");
                return;
            }


            if (!get_amounts(out int t과세금액, out int t면세금액))
            {
                MessageBox.Show("과세금액, 면세금액 계산오류");
                return;
            }

            countup_the_no();



            //!
            int order_cnt = 0;
            int dcAmount = 0;


            // 리스트뷰 -> 메모리배열 생성 : [ 업장코드로 정렬 + 업장주문번호 부여 ]
            //MemOrderItem[] memOrderItemArr = getMemOrderItemArr(out dcAmount);

            set_shop_order_no_on_orderitem(out dcAmount);



            // orders, orderItem 
            order_cnt = SaveOrder(ticketNo);  // order. orderitem  ->  업장주문서 출력은 제외
            if (order_cnt == -1)
            {
                return; // 재로그인 요구
            }


            //  payment
            if (!SavePayment(1, "Cert", mNetAmount, dcAmount))
            {
                return;
            }


            PaymentCert mPaymentCert = new PaymentCert();
            mPaymentCert.site_id = mSiteId;
            mPaymentCert.biz_dt = mBizDate;
            mPaymentCert.pos_no = mPosNo;
            mPaymentCert.the_no = mTheNo;
            mPaymentCert.ref_no = mRefNo; // 

            mPaymentCert.pay_date = get_today_date();
            mPaymentCert.pay_time = get_today_time();
            mPaymentCert.pay_type = "M0";       // 결제구분 : 쿠폰인증(M0)
            mPaymentCert.tran_type = "A";       // 승인 A 취소 C
            mPaymentCert.pay_class = mPayClass;

            mPaymentCert.ticket_no = ticketNo;
            mPaymentCert.pay_seq = 1; // 
            mPaymentCert.tran_date = get_today_date() + get_today_time();
            mPaymentCert.amount = mNetAmount;    // 결제금액
            mPaymentCert.coupon_no = mOrderItemList[0].coupon_no;   //?  쿠폰인증 멀티 발권가능하도록 할것인가?
            mPaymentCert.is_cancel = "";         // 취소여부
            mPaymentCert.van_code = "TM";        // TM : 테이블메니저
            mPaymentCert.cnt = mOrderItemList[0].cnt;        
            mPaymentCert.coupon_link_no = lvwCoupon.SelectedItems[0].SubItems[lvwCoupon.Columns.IndexOf(coupon_link_no)].Text;

            // 결제 항목 저장
            if (!SavePaymentCert(mPaymentCert))
            {
                return;
            }


            SetDisplayAlarm("I", "쿠폰인증 주문완료.");



            int settel_amt = mNetAmount;


            // 티켓 저장
            int ticket_cnt = SaveTicketFlow(ticketNo, mPayClass, "US", settel_amt);

            if (ticket_cnt > 0)
            {

            }




            // 주문서 출력 : 업장용 + 고객용
            // 주문서 출력
            String[] order_no_from_to = new String[2];

            order_no_from_to[0] = "";
            order_no_from_to[1] = "";


            List<shop_order_pack> shopOrderPackList = new List<shop_order_pack>();

            order_no_from_to = print_order(ref shopOrderPackList);


            // 영수증 출력
            print_bill(mTheNo, "A", "", "00001", true, order_no_from_to); // cert



            //
            mClearSaleForm();

            lvwCoupon.Items.Clear();
            clear_info();

            //
            tbCouponNo.Text = "";


            //this.Close();

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
            parameters["vanCode"] = mPaymentCert.van_code; ;

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



        private void btnCouponCancel_Click(object sender, EventArgs e)
        {

        }

        private void tbCouponNo_Leave(object sender, EventArgs e)
        {
            tbCouponNo.Focus();
        }

    }
}
