﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using PrinterUtility;
using Newtonsoft.Json.Linq;
using static thepos.thePos;
using static thepos.frmSales;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel.Composition.Primitives;
using System.Web.UI.WebControls.Expressions;
using System.Security.Policy;
using thepos._1Sales;

namespace thepos
{
    public partial class frmPayManager : Form
    {
        System.Windows.Forms.TextBox saveKeyDisplay;

        String selected_biz_date = "";
        String selected_pos_no = "";
        String selected_the_no = "";

        public static System.Windows.Forms.ListView mLvwPayManager;


        public frmPayManager()
        {
            InitializeComponent();

            initialize_the();

            //
            thepos_app_log(1, this.Name, "Open", "");

        }

        private void initialize_the()
        {
            //dtBusiness.Value = DateTime.Now;
            dtBizDt.Value = new DateTime(convert_number(mBizDate.Substring(0, 4)), convert_number(mBizDate.Substring(4, 2)), convert_number(mBizDate.Substring(6, 2)));

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 28);
            lvwPayManager.SmallImageList = imgList;
            lvwPayOrder.SmallImageList = imgList;

            cbPosNo.Items.Clear();

            cbPosNo.Items.Add("");

            for (int i = 0; i < myPosNoList.Count; i++)
            {
                cbPosNo.Items.Add(myPosNoList[i]);
            }

            cbPosNo.SelectedIndex = 0;


            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbTheNo;


            mPanelCancel.Width = 529;
            mPanelCancel.Height = 704;

            mLvwPayManager = lvwPayManager;

        }


        private void add_viewList(String t_theNo, String t_billNo, String t_payClass, String is_cash, String is_card, String is_point, String is_easy, String is_cert, String t_payDate, String t_payTime, String t_posNo, int t_netAmount, int t_dcAmount, String t_isCancel)
        {
            ListViewItem lvItem = new ListViewItem();

            lvItem.Tag = t_theNo;
            lvItem.Text = t_billNo;
            lvItem.SubItems.Add(get_pay_class_name(t_payClass));

            String pay_keep = "";

            if (is_cash != "1") is_cash = "0";
            if (is_card != "1") is_card = "0";
            if (is_point != "1") is_point = "0";
            if (is_easy != "1") is_easy = "0";
            if (is_cert != "1") is_cert = "0";


            pay_keep = is_cash + is_card + is_point + is_easy + is_cert;
            lvItem.SubItems.Add(get_pay_type_group_name(pay_keep));


            if (pay_keep == "00000")
            {
                pay_keep = "10001";
            }


            lvItem.SubItems.Add(get_MMddHHmm(t_payDate, t_payTime));
            lvItem.SubItems.Add(t_posNo);
            lvItem.SubItems.Add(t_netAmount.ToString("N0"));


            if (t_dcAmount > 0)
            {
                lvItem.SubItems.Add("Y");
            }
            else
            {
                lvItem.SubItems.Add("");
            }

            if (t_isCancel == "y")
                lvItem.SubItems.Add("취소:");
            else if (t_isCancel == "Y")
                lvItem.SubItems.Add("취소");
            else if (t_isCancel == "0")
                lvItem.SubItems.Add("취소중");
            else
                lvItem.SubItems.Add("");


            lvItem.SubItems.Add(pay_keep);
            lvItem.SubItems.Add(t_payClass);
            lvItem.SubItems.Add(t_isCancel);


            if (t_isCancel == "Y" | t_isCancel == "y")
            {
                lvItem.ForeColor = Color.Gray;
                lvItem.SubItems[1].ForeColor = Color.Gray;
                lvItem.SubItems[2].ForeColor = Color.Gray;
                lvItem.SubItems[3].ForeColor = Color.Gray;
                lvItem.SubItems[4].ForeColor = Color.Gray;
                lvItem.SubItems[5].ForeColor = Color.Gray;
                lvItem.SubItems[6].ForeColor = Color.Gray;
                lvItem.SubItems[7].ForeColor = Color.Gray;
                lvItem.SubItems[8].ForeColor = Color.Gray;
            }

            lvwPayManager.Items.Add(lvItem);

        }



        private void viewList(String biz_date, String pos_no, String the_no)
        { 
            lvwPayManager.Items.Clear();
            lvwPayOrder.Items.Clear();

            //!
            String sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + biz_date + "&shopCode=" + myShopCode + "&posNo=" + pos_no + "&theNo=" + the_no + "&tranType=A";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["payments"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        String t_theNo = arr[i]["theNo"].ToString();
                        String t_billNo = arr[i]["billNo"].ToString();
                        String t_payClass = arr[i]["payClass"].ToString();

                        String t_cash = arr[i]["isCash"].ToString();
                        String t_card = arr[i]["isCard"].ToString();
                        String t_point = arr[i]["isPoint"].ToString();
                        String t_easy = arr[i]["isEasy"].ToString();
                        String t_cert = arr[i]["isCert"].ToString();


                        String t_payDate = arr[i]["payDate"].ToString();
                        String t_payTime = arr[i]["payTime"].ToString();
                        String t_posNo = arr[i]["posNo"].ToString();
                        int t_netAmount = convert_number(arr[i]["netAmount"].ToString());
                        int t_dcAmount = convert_number(arr[i]["dcAmount"].ToString());
                        String t_isCancel = arr[i]["isCancel"].ToString();

                        add_viewList(t_theNo, t_billNo, t_payClass, t_cash, t_card, t_point, t_easy, t_cert, t_payDate, t_payTime, t_posNo, t_netAmount, t_dcAmount, t_isCancel);
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "viewList()", "데이터 오류. payment " + mObj["resultMsg"].ToString());

                    MessageBox.Show("데이터 오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                //
                thepos_app_log(3, this.Name, "viewList()", "시스템오류. payment " + mErrorMsg);

                MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
            }

        }


        public static void reviewList(String biz_date, String pos_no, String the_no, int select_index)
        {
            String t_theNo = "";
            String t_billNo = "";
            String t_payClass = "";

            String is_cash = "0";
            String is_card = "0";
            String is_point = "0";
            String is_easy = "0";
            String is_cert = "0";

            String t_payDate = "";
            String t_payTime = "";
            String t_posNo = "";
            int t_netAmount = 0;
            int t_dcAmount = 0;
            String t_isCancel = "";



            String sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + biz_date + "&posNo=" + pos_no + "&theNo=" + the_no + "&tranType=A";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["payments"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        t_theNo = arr[0]["theNo"].ToString();
                        t_billNo = arr[0]["billNo"].ToString();
                        t_payClass = arr[0]["payClass"].ToString();

                        is_cash = arr[0]["isCash"].ToString();
                        is_card = arr[0]["isCard"].ToString();
                        is_point = arr[0]["isPoint"].ToString();
                        is_easy = arr[0]["isEasy"].ToString();
                        is_cert = arr[0]["isCert"].ToString();

                        t_payDate = arr[0]["payDate"].ToString();
                        t_payTime = arr[0]["payTime"].ToString();
                        t_posNo = arr[0]["posNo"].ToString();
                        t_netAmount = convert_number(arr[0]["netAmount"].ToString());
                        t_dcAmount = convert_number(arr[0]["dcAmount"].ToString());
                        t_isCancel = arr[0]["isCancel"].ToString();
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, "frmPayManager", "reviewList()", "데이터 오류. payment " + mObj["resultMsg"].ToString());

                    MessageBox.Show("데이터 오류 payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                //
                thepos_app_log(3, "frmPayManager", "reviewList()", "시스템오류 payment " + mErrorMsg);

                MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
            }
            



            ListViewItem lvItem = new ListViewItem();

            lvItem.Tag = t_theNo;
            lvItem.Text = t_billNo;
            lvItem.SubItems.Add(get_pay_class_name(t_payClass));

            String pay_keep = "";

            if (is_cash != "1") is_cash = "0";
            if (is_card != "1") is_card = "0";
            if (is_point != "1") is_point = "0";
            if (is_easy != "1") is_easy = "0";
            if (is_cert != "1") is_cert = "0";


            pay_keep = is_cash + is_card + is_point + is_easy + is_cert;

            lvItem.SubItems.Add(get_pay_type_group_name(pay_keep));

            if (pay_keep == "00000")
            {
                pay_keep = "10001";
            }



            lvItem.SubItems.Add(get_MMddHHmm(t_payDate, t_payTime));
            lvItem.SubItems.Add(t_posNo);
            lvItem.SubItems.Add(t_netAmount.ToString("N0"));


            //
            if (t_dcAmount > 0)
                lvItem.SubItems.Add("Y");
            else
                lvItem.SubItems.Add("");

            //
            if (t_isCancel == "y")
                lvItem.SubItems.Add("취소:");
            else if (t_isCancel == "Y")
                lvItem.SubItems.Add("취소");
            else if (t_isCancel == "0")
                lvItem.SubItems.Add("취소중");
            else
                lvItem.SubItems.Add("");



            lvItem.SubItems.Add(pay_keep);
            lvItem.SubItems.Add(t_payClass);
            lvItem.SubItems.Add(t_isCancel);


            if (t_isCancel == "Y")
            {
                lvItem.ForeColor = Color.Gray;
                lvItem.SubItems[1].ForeColor = Color.Gray;
                lvItem.SubItems[2].ForeColor = Color.Gray;
                lvItem.SubItems[3].ForeColor = Color.Gray;
                lvItem.SubItems[4].ForeColor = Color.Gray;
                lvItem.SubItems[5].ForeColor = Color.Gray;
                lvItem.SubItems[6].ForeColor = Color.Gray;
                lvItem.SubItems[7].ForeColor = Color.Gray;
                lvItem.SubItems[8].ForeColor = Color.Gray;
            }

            mLvwPayManager.Items[select_index] = lvItem;
            lvItem.Selected = true;
            mLvwPayManager.Select();
            mLvwPayManager.EnsureVisible(select_index);

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();
            mTbKeyDisplayController = saveKeyDisplay;
            
            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }

        private void lvwPayManager_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvwPayManager.Columns[e.ColumnIndex].Width;
        }

        private void lvwPayManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count <= 0)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;

            // 취소된 건을 선택하면 취소전표를 출력한다.. 아래와 동일
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;


            String tran_type = "A";
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }

            view_list_pay_order(tTheNo, tran_type, pay_keep);
            
        }


        private void view_list_pay_order(String tTheNo, String tranType, String pay_keep)
        {
            lvwPayOrder.Items.Clear();

            //
            view_list_order(tTheNo, tranType);

            //
            view_list_pay(tTheNo, tranType, pay_keep);

        }


        private void view_list_order(String tTheNo, String tranType)
        {
            String sUrl = "";

            sUrl = "orderItem?siteId=" + mSiteId + "&theNo=" + tTheNo + "&bizDt=" + selected_biz_date + "&tranType=A";
            

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        //
                        ListViewItem lvItem = new ListViewItem();

                        String shop_order_no = arr[i]["shopOrderNo"].ToString();

                        if (shop_order_no.Length >= 4)
                            lvItem.Tag = "O";
                        else
                            lvItem.Tag = "";

                        lvItem.Text = arr[i]["shopOrderNo"].ToString();
                        lvItem.SubItems.Add(arr[i]["goodsName"].ToString());
                        lvItem.SubItems.Add(convert_number(arr[i]["cnt"].ToString()).ToString("N0"));
                        lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));
                        lvwPayOrder.Items.Add(lvItem);
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "view_list_order()", "주문 데이터 오류 " + mObj["resultMsg"].ToString());

                    MessageBox.Show("주문 데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                //
                thepos_app_log(3, this.Name, "view_list_order()", "시스템오류. orderItem " + mErrorMsg);

                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
            }
        }



        private void view_list_pay(String tTheNo, String tranType, String pay_keep)
        {
            String pay_keep_cash = pay_keep.Substring(0, 1);
            String pay_keep_card = pay_keep.Substring(1, 1);
            String pay_keep_point = pay_keep.Substring(2, 1);
            String pay_keep_easy = pay_keep.Substring(3, 1);
            String pay_keep_cert = pay_keep.Substring(4, 1);

            String sUrl = "";
            String pay_name = "";
            int pay_amount = 0;


            //! 현금결제
            if (pay_keep_cash == "1")
            {
                sUrl = "paymentCash?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=A" + "&bizDt=" + selected_biz_date;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCashs"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            
                            {
                                pay_name = get_pay_type_name(arr[i]["payType"].ToString());
                                pay_amount = convert_number(arr[i]["amount"].ToString());

                                if (tranType == "C")
                                    pay_amount = -pay_amount;

                                //
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Tag = "P";
                                lvItem.Text = "(결제)";
                                lvItem.SubItems.Add(pay_name);
                                lvItem.SubItems.Add(pay_amount.ToString("N0"));
                                lvItem.SubItems.Add("");
                                lvwPayOrder.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }


            //! 카드결제
            if (pay_keep_card == "1")
            {
                sUrl = "paymentCard?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=A" + "&bizDt=" + selected_biz_date;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCards"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            {
                                pay_name = get_pay_type_name(arr[i]["payType"].ToString());
                                pay_amount = convert_number(arr[i]["amount"].ToString());

                                if (tranType == "C")
                                    pay_amount = -pay_amount;

                                //
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Tag = "P";
                                lvItem.Text = "(결제)";
                                lvItem.SubItems.Add(pay_name);
                                lvItem.SubItems.Add(pay_amount.ToString("N0"));
                                lvItem.SubItems.Add("");
                                lvwPayOrder.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }


            //! 포인트
            if (pay_keep_point == "1")
            {
                sUrl = "paymentPoint?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=A" + "&bizDt=" + selected_biz_date;


                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentPoints"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            //? 포인트 취소인 경우 잘되는지 다시 확인바람
                            pay_name = get_pay_type_name(arr[i]["payType"].ToString());
                            pay_amount = convert_number(arr[i]["amount"].ToString());

                            if (tranType == "C")
                                pay_amount = -pay_amount;

                            //
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Tag = "P";
                            lvItem.Text = "(결제)";
                            lvItem.SubItems.Add(pay_name);
                            lvItem.SubItems.Add(pay_amount.ToString("N0"));
                            lvItem.SubItems.Add("");
                            lvwPayOrder.Items.Add(lvItem);
                        }
                    }
                }
            }


            // 간편결제
            if (pay_keep_easy == "1")
            {
                sUrl = "paymentEasy?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=A" + "&bizDt=" + selected_biz_date;


                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentEasys"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            
                            {
                                pay_name = get_pay_type_name(arr[i]["payType"].ToString());
                                pay_amount = convert_number(arr[i]["amount"].ToString());

                                if (tranType == "C")
                                    pay_amount = -pay_amount;

                                //
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Tag = "P";
                                lvItem.Text = "(결제)";
                                lvItem.SubItems.Add(pay_name);
                                lvItem.SubItems.Add(pay_amount.ToString("N0"));
                                lvItem.SubItems.Add("");
                                lvwPayOrder.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }

            //! 쿠폰인증
            if (pay_keep_cert == "1")
            {
                sUrl = "paymentCert?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=A" + "&bizDt=" + selected_biz_date;


                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCerts"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            
                            {
                                pay_name = get_pay_type_name(arr[i]["payType"].ToString());
                                pay_amount = convert_number(arr[i]["amount"].ToString());
                                String coupon_no = arr[i]["couponNo"].ToString();

                                if (tranType == "C")
                                    pay_amount = -pay_amount;

                                //
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Tag = "P";
                                lvItem.Text = "(결제)";
                                lvItem.SubItems.Add(pay_name + " " + coupon_no);
                                lvItem.SubItems.Add(pay_amount.ToString("N0"));
                                lvItem.SubItems.Add("");
                                lvwPayOrder.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }
        }



        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count < 1)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;


            // 취소된 건을 선택하면 취소전표를 출력한다.. 위와 동일
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;

            String tran_type = "A";
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }

            _print_bill(tTheNo, tran_type, "", pay_keep, false);

        }

        private void btnPrintBillex_Click(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count < 1)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;


            // 취소된 건을 선택하면 취소전표를 출력한다.. 위와 동일
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;

            String tran_type = "A";
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }

            _print_bill(tTheNo, tran_type, "Y", pay_keep, false);  // Y 상품정보제외

        }


        private void btnPrintBilldisp_Click(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count <= 0)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;

            // 취소된 건을 선택하면 취소전표를 출력한다.. 아래와 동일
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;



            String tran_type = "A";
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }



            //String str_bill = make_bill_header() + make_bill_body(tTheNo, tran_type, "", pay_keep) + make_bill_trailer();


            frmDisplayBill f = new frmDisplayBill(tTheNo, tran_type, pay_keep);
            f.ShowDialog();

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count < 1)
            {
                SetDisplayAlarm("W", "대상거래 선택요망.");
                return; 
            }

            String the_no = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;

            int select_idx = lvwPayManager.SelectedItems[0].Index;


            //
            mPanelCancel.Controls.Clear();
            mPanelCancel.Visible = true;

            Form fForm = new frmPayCancel(the_no, selected_pos_no, selected_biz_date, pay_keep, select_idx) { TopLevel = false, TopMost = true };

            mPanelCancel.Controls.Add(fForm);
            fForm.Show();

            mPanelCancel.BringToFront();

        }


        private void btnView_Click(object sender, EventArgs e)
        {
            //
            String the_no = tbTheNo.Text;

            if (the_no.Length >= 20)
            {
                the_no = the_no.Substring(0, 20);
            }
            else if (the_no.Length == 0)
            {

            }
            else
            {
                SetDisplayAlarm("I", "주문번호 입력오류: 20자리.");
                return;
            }


            selected_biz_date = dtBizDt.Value.ToString("yyyyMMdd");
            selected_pos_no = cbPosNo.Text;
            selected_the_no = the_no;
            

            viewList(selected_biz_date, selected_pos_no, selected_the_no);

            if (lvwPayManager.Items.Count == 1)
            {
                lvwPayManager.Items[0].Selected = true;
            }

        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            if (lvwPayOrder.SelectedItems.Count < 1)
            {
                SetDisplayAlarm("I", "주문항목 선택 필요.");
                return;
            }

            if (lvwPayOrder.SelectedItems[0].Tag.ToString() != "O")  // O 주문, P 결제
            {
                SetDisplayAlarm("I", "#주문번호가 포함된 주문건 선택 필요.");
                return;
            }



            String tran_type = "A";
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }


            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();




            shop_order_pack shopOrderPack = new shop_order_pack();

            List<order_pack> orderPackList = new List<order_pack>();
            order_pack orderPack = new order_pack();



            List<String> option_name_list = new List<String>();
            List<String> option_item_name_list = new List<String>();

            String t_order_no = lvwPayOrder.SelectedItems[0].Text;
            String t_shop_code = "";
            String t_order_dt = "";

            List<String> t_good_name = new List<String>();
            List<int> t_good_cnt = new List<int>();


            String sUrl = "";

            if (tran_type == "A")
            {
                sUrl = "orderItem?siteId=" + mSiteId + "&theNo=" + tTheNo + "&bizDt=" + selected_biz_date + "&tranType=" + tran_type;
            }
            else
            {
                sUrl = "orderItem?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=" + tran_type;
            }


            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (arr[i]["shopOrderNo"].ToString() == t_order_no)
                        {
                            t_shop_code = arr[i]["shopCode"].ToString();
                            t_order_dt = arr[i]["orderDate"].ToString() + arr[i]["orderTime"].ToString();

                            orderPack.goods_name = arr[i]["goodsName"].ToString();
                            orderPack.goods_cnt = convert_number(arr[i]["cnt"].ToString());
                            orderPack.nod_code1 = arr[i]["nodCode1"].ToString();


                            option_name_list.Clear();
                            option_item_name_list.Clear();

                            //
                            if (arr[i]["optionNo"].ToString() != "")
                            {
                                sUrl = "orderOptionItem?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&optionNo=" + arr[i]["optionNo"].ToString();
                                if (mRequestGet(sUrl))
                                {
                                    if (mObj["resultCode"].ToString() == "200")
                                    {
                                        String data2 = mObj["orderOptionItems"].ToString();
                                        JArray arr2 = JArray.Parse(data2);

                                        for (int k = 0; k < arr2.Count; k++)
                                        {
                                            option_name_list.Add(arr2[k]["optionName"].ToString());
                                            option_item_name_list.Add(arr2[k]["optionItemName"].ToString());
                                        }
                                    }
                                }
                            }

                            orderPack.option_name = option_name_list.ToList();
                            orderPack.option_item_name = option_item_name_list.ToList();
                            orderPackList.Add(orderPack);

                            shopOrderPack.order_no = t_order_no;
                            shopOrderPack.shop_code = t_shop_code;
                            shopOrderPack.order_dt = t_order_dt;
                            shopOrderPack.orderPackList = orderPackList;
                        }
                    }
                }
                else
                {
                    //
                    thepos_app_log(3, this.Name, "btnPrintOrder_Click()", "주문 데이터 오류 orderItem. " + mObj["resultMsg"].ToString());

                    MessageBox.Show("주문 데이터 오류. orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                //
                thepos_app_log(3, this.Name, "btnPrintOrder_Click()", "시스템오류. orderItem " + mErrorMsg);

                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                return;
            }

            
  
            if (tran_type == "A")
            {
                // 업장주문서 출력 -> shop 등록정보 프린터
                print_order_str("to_shop", "주문서[재발급]", shopOrderPack);

                // 주문교환권 출력 -> 영수증프린터
                print_order_str("to_local", "교환권[재발급]", shopOrderPack);
            }
            else
            {
                // 업장주문서 출력 -> shop 등록정보 프린터
                print_order_str("to_shop", "취소주문서[재발급]", shopOrderPack);

                //주문교환권 출력 -> 영수증프린터
                print_order_str("to_local", "취소교환권[재발급]", shopOrderPack);
            }

        }

        private void tbTheNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;


                String the_no = tbTheNo.Text;

                tbTheNo.Text = "";


                if (the_no.Length >= 20)
                {
                    selected_biz_date = dtBizDt.Value.ToString("yyyyMMdd");
                    selected_pos_no = cbPosNo.Text;
                    selected_the_no = the_no.Substring(0,20);

                    viewList(selected_biz_date, selected_pos_no, selected_the_no);

                    if (lvwPayManager.Items.Count == 1)
                    {
                        lvwPayManager.Items[0].Selected = true;
                    }
                }



            }

        }
    }
}
