using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theposw._9SysAdmin;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static thepos.thePos;


namespace thepos._9SysAdmin
{
    public partial class frmSysGoods : Form
    {
        private BindingList<object> shopList = new BindingList<object>();



        private int sortColumn = -1;


        String sv_goodsName = "";
        String sv_goodsNameEN = "";
        String sv_goodsNameCH = "";
        String sv_goodsNameJP = "";
        String sv_goodsNotice = "";
        String sv_barcode = "";

        String sv_amt = "";
        String sv_shopCode = "";
        String sv_nodCode1 = "";
        String sv_nodCode2 = "";

        String sv_online_coupon = "";
        String sv_ticketYn = "";
        String sv_taxFree = "";
        String sv_cutout = "";
        String sv_soldout = "";
        String sv_allim = "";
        String sv_option_template_id = "";
        String sv_badges_id = "";
        String sv_memo = "";
        String sv_coupon_link_no = "";
        String ch_imagePath = "";




        List<Nod1> thisNod1 = new List<Nod1>();

        List<Nod2> thisNod2 = new List<Nod2>();




        public frmSysGoods()
        {
            InitializeComponent();

            //initialize_font();
            initialize_the();


        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (cbShopView.SelectedIndex < 0) 
            { 
                cbShopView.SelectedIndex = 0; 
            }

            reload_all();
        }



        private void initialize_the()
        {
            lvwList.HideSelection = true;

            //
            cbShopView.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShopView.Items.Add(mShop[i].shop_name);
            }

            cbShopView.SelectedIndex = 0;


            //
            cbShop.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }
            cbShop.SelectedIndex = 0;


            //
            cbNod1.Items.Clear();
            cbNod1.Items.Add("");

            cbNod2.Items.Clear();
            cbNod2.Items.Add("");



            // 옵션은 자주 변경을 예상하여 상품화면띄울때마다 옵션정보 로드한다...

            // 3-1. optionTemplate
            if (false)
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
                            mOptionTemplate[i + 1].option_template_id = arr[i]["optionTemplateId"].ToString();
                            mOptionTemplate[i + 1].option_template_name = arr[i]["optionTemplateName"].ToString();
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


            cbOptionTemplate.Items.Clear();
            for (int i = 0; i < mOptionTemplate.Length; i++)
            {
                cbOptionTemplate.Items.Add(mOptionTemplate[i].option_template_name);
            }



            cbBadges.Items.Clear();
            for (int i = 0; i < mBadges.Length; i++)
            {
                cbBadges.Items.Add(mBadges[i].badges_name);
            }

        }

        private void clear_console()
        {
            tbGoodsName.Text = "";
            tbGoodsNameEN.Text = "";
            tbGoodsNameCH.Text = "";
            tbGoodsNameJP.Text = "";

            tbGoodsNotice.Text = "";

            tbGoodsName.Tag = "";
            tbGoodsAmt.Text = "";
            cbShop.SelectedIndex = -1;
            cbTicket.SelectedIndex = 0;
            cbTaxFree.Checked = false;
            cbCutout.Checked = false;

            tbMemo.Text = "";
            tbCouponLinkNo.Text = "";
            pbImage.Image = null;
        }


        private void reload_all()
        {
            lvwList.Items.Clear();

            clear_console();

            String tOnlineCoupon, tTicket, tTaxFree, tCutout, tSoldout, tAllim = "";

            String sUrl = "goods?siteId=" + mSiteId + "&imageYn=Y" + "&shopCode=" + mShop[cbShopView.SelectedIndex].shop_code;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem;

                        if (arr[i]["imagePath"].ToString() == "")
                            lvItem = new ListViewItem(arr[i]["goodsName"].ToString());
                        else
                            lvItem = new ListViewItem(arr[i]["goodsName"].ToString(), 0);  // image index = 0

                        lvItem.SubItems.Add(arr[i]["goodsNameEn"].ToString());
                        lvItem.SubItems.Add(arr[i]["goodsNameCh"].ToString());
                        lvItem.SubItems.Add(arr[i]["goodsNameJp"].ToString());

                        // goodscode
                        lvItem.SubItems.Add(arr[i]["goodsCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["amt"].ToString());  // 5

                        lvItem.SubItems.Add(arr[i]["shopCode"].ToString());
                        lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));

                        lvItem.SubItems.Add(arr[i]["nodCode1"].ToString());
                        lvItem.SubItems.Add(get_nod1_name(arr[i]["shopCode"].ToString(), arr[i]["nodCode1"].ToString()));

                        lvItem.SubItems.Add(arr[i]["nodCode2"].ToString());        // 10
                        lvItem.SubItems.Add(get_nod2_name(arr[i]["shopCode"].ToString(), arr[i]["nodCode1"].ToString(), arr[i]["nodCode2"].ToString()));

                        lvItem.SubItems.Add(arr[i]["optionTemplateId"].ToString());
                        lvItem.SubItems.Add(get_option_template_name(arr[i]["optionTemplateId"].ToString()));


                        tTicket = "";
                        tTaxFree = "";
                        tCutout = "";
                        tSoldout = "";
                        tAllim = "";
                        tOnlineCoupon = "";

                        if (arr[i]["ticketYn"].ToString() == "Y") tTicket = "Y";
                        else 
                        if (arr[i]["ticketYn"].ToString() == "Ys") tTicket = "Ys";
                        else tTicket = "";

                        if (arr[i]["taxFree"].ToString() == "Y") tTaxFree = "Y";
                        if (arr[i]["cutout"].ToString() == "Y") tCutout = "Y";          // 15
                        if (arr[i]["soldout"].ToString() == "Y") tSoldout = "Y";
                        if (arr[i]["allim"].ToString() == "Y") tAllim = "Y";
                        if (arr[i]["onlineCoupon"].ToString() == "Y") tOnlineCoupon = "Y";

                        lvItem.SubItems.Add(tTicket);
                        lvItem.SubItems.Add(tTaxFree);
                        lvItem.SubItems.Add(tCutout);
                        lvItem.SubItems.Add(tSoldout);
                        lvItem.SubItems.Add(tAllim);
                        lvItem.SubItems.Add(tOnlineCoupon);

                        lvItem.SubItems.Add(arr[i]["couponLinkNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["barCode"].ToString());

                        lvItem.SubItems.Add(arr[i]["badgesId"].ToString());                     // 20
                        lvItem.SubItems.Add(get_badges_name(arr[i]["badgesId"].ToString()));

                        lvItem.SubItems.Add(arr[i]["goodsNotice"].ToString());
                        lvItem.SubItems.Add(arr[i]["memo"].ToString());




                        if (tCutout == "Y")  // 중지
                        {
                            lvItem.ForeColor = Color.LightGray;
                            lvItem.SubItems[1].ForeColor = Color.LightGray;
                            lvItem.SubItems[2].ForeColor = Color.LightGray;
                            lvItem.SubItems[3].ForeColor = Color.LightGray;
                            lvItem.SubItems[4].ForeColor = Color.LightGray;
                            lvItem.SubItems[5].ForeColor = Color.LightGray;
                        }
                        else if (tSoldout == "Y")  // 품절
                        {
                            lvItem.ForeColor = Color.Red;
                            lvItem.SubItems[1].ForeColor = Color.Red;
                            lvItem.SubItems[2].ForeColor = Color.Red;
                            lvItem.SubItems[3].ForeColor = Color.Red;
                            lvItem.SubItems[4].ForeColor = Color.Red;
                            lvItem.SubItems[5].ForeColor = Color.Red;
                        }
                        else
                        {
                            lvItem.ForeColor = Color.Black;
                            lvItem.SubItems[1].ForeColor = Color.Black;
                            lvItem.SubItems[2].ForeColor = Color.Black;
                            lvItem.SubItems[3].ForeColor = Color.Black;
                            lvItem.SubItems[4].ForeColor = Color.Black;
                            lvItem.SubItems[5].ForeColor = Color.Black;
                        }


                        lvItem.Tag = arr[i]["imagePath"].ToString();



                        lvwList.Items.Add(lvItem);


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


        private ListViewItem reload_select(string code)
        {
            String tOnlineCoupon, tTicket, tTaxFree, tCutout, tSoldout, tAllim = "";

            String sUrl = "goods?siteId=" + mSiteId + "&goodsCode=" + code + "&imageYn=Y";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(pos);

                    if (arr.Count > 0)
                    {
                        ListViewItem lvItem;

                        if (arr[0]["imagePath"].ToString() == "")
                            lvItem = new ListViewItem(arr[0]["goodsName"].ToString());
                        else
                            lvItem = new ListViewItem(arr[0]["goodsName"].ToString(), 0);  // image index = 0

                        lvItem.SubItems.Add(arr[0]["goodsNameEn"].ToString());
                        lvItem.SubItems.Add(arr[0]["goodsNameCh"].ToString());
                        lvItem.SubItems.Add(arr[0]["goodsNameJp"].ToString());

                        // goodscode
                        lvItem.SubItems.Add(arr[0]["goodsCode"].ToString());
                        lvItem.SubItems.Add(arr[0]["amt"].ToString());

                        lvItem.SubItems.Add(arr[0]["shopCode"].ToString());
                        lvItem.SubItems.Add(get_shop_name(arr[0]["shopCode"].ToString()));

                        lvItem.SubItems.Add(arr[0]["nodCode1"].ToString());
                        lvItem.SubItems.Add(get_nod1_name(arr[0]["shopCode"].ToString(), arr[0]["nodCode1"].ToString()));

                        lvItem.SubItems.Add(arr[0]["nodCode2"].ToString());
                        lvItem.SubItems.Add(get_nod2_name(arr[0]["shopCode"].ToString(), arr[0]["nodCode1"].ToString(), arr[0]["nodCode2"].ToString()));

                        lvItem.SubItems.Add(arr[0]["optionTemplateId"].ToString());
                        lvItem.SubItems.Add(get_option_template_name(arr[0]["optionTemplateId"].ToString()));

                        tTicket = "";
                        tTaxFree = "";
                        tCutout = "";
                        tSoldout = "";
                        tAllim = "";
                        tOnlineCoupon = "";

                        if (arr[0]["ticketYn"].ToString() == "Y") tTicket = "Y";
                        else if (arr[0]["ticketYn"].ToString() == "Ys") tTicket = "Ys";
                        else tTicket = "";


                        if (arr[0]["taxFree"].ToString() == "Y") tTaxFree = "Y";
                        if (arr[0]["cutout"].ToString() == "Y") tCutout = "Y";
                        if (arr[0]["soldout"].ToString() == "Y") tSoldout = "Y";
                        if (arr[0]["allim"].ToString() == "Y") tAllim = "Y";
                        if (arr[0]["onlineCoupon"].ToString() == "Y") tOnlineCoupon = "Y";


                        lvItem.SubItems.Add(tTicket);
                        lvItem.SubItems.Add(tTaxFree);
                        lvItem.SubItems.Add(tCutout);
                        lvItem.SubItems.Add(tSoldout);
                        lvItem.SubItems.Add(tAllim);
                        lvItem.SubItems.Add(tOnlineCoupon);

                        lvItem.SubItems.Add(arr[0]["couponLinkNo"].ToString());
                        lvItem.SubItems.Add(arr[0]["barCode"].ToString());

                        lvItem.SubItems.Add(arr[0]["badgesId"].ToString());
                        lvItem.SubItems.Add(get_badges_name(arr[0]["badgesId"].ToString()));

                        lvItem.SubItems.Add(arr[0]["goodsNotice"].ToString());
                        lvItem.SubItems.Add(arr[0]["memo"].ToString());



                        if (tCutout == "Y")  // 중지
                        {
                            lvItem.ForeColor = Color.LightGray;
                            lvItem.SubItems[1].ForeColor = Color.LightGray;
                            lvItem.SubItems[2].ForeColor = Color.LightGray;
                            lvItem.SubItems[3].ForeColor = Color.LightGray;
                            lvItem.SubItems[4].ForeColor = Color.LightGray;
                            lvItem.SubItems[5].ForeColor = Color.LightGray;
                        }
                        else if (tSoldout == "Y")  // 품절
                        {
                            lvItem.ForeColor = Color.Red;
                            lvItem.SubItems[1].ForeColor = Color.Red;
                            lvItem.SubItems[2].ForeColor = Color.Red;
                            lvItem.SubItems[3].ForeColor = Color.Red;
                            lvItem.SubItems[4].ForeColor = Color.Red;
                            lvItem.SubItems[5].ForeColor = Color.Red;
                        }
                        else
                        {
                            lvItem.ForeColor = Color.Black;
                            lvItem.SubItems[1].ForeColor = Color.Black;
                            lvItem.SubItems[2].ForeColor = Color.Black;
                            lvItem.SubItems[3].ForeColor = Color.Black;
                            lvItem.SubItems[4].ForeColor = Color.Black;
                            lvItem.SubItems[5].ForeColor = Color.Black;
                        }

                        lvItem.Tag = arr[0]["imagePath"].ToString();


                        return lvItem;

                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return null;
            }

            return null;

        }


        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            tbGoodsName.Tag = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(goodscode)].Text;  // code

            tbGoodsName.Text = lvwList.SelectedItems[0].Text;
            tbGoodsNameEN.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(goodsnameEN)].Text;
            tbGoodsNameCH.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(goodsnameCH)].Text;
            tbGoodsNameJP.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(goodsnameJP)].Text;

            tbGoodsNotice.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(notice)].Text;
            tbBarCode.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(barcode)].Text;


            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(online_coupon)].Text == "Y")
                cbCoupon.Checked = true;
            else
                cbCoupon.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(ticket)].Text == "Y")
                cbTicket.SelectedIndex = 1;
            else if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(ticket)].Text == "Ys")
                cbTicket.SelectedIndex = 2;
            else
                cbTicket.SelectedIndex = 0;

            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(taxfree)].Text == "Y")
                cbTaxFree.Checked = true;
            else
                cbTaxFree.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(cutout)].Text == "Y")
                cbCutout.Checked = true;
            else
                cbCutout.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(soldout)].Text == "Y")
                cbSoldout.Checked = true;
            else
                cbSoldout.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(allim)].Text == "Y")
                cbAllim.Checked = true;
            else
                cbAllim.Checked = false;

            //
            tbGoodsAmt.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(amt)].Text;

            
            //
            String shop_code = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(shopcode)].Text;

            cbShop.SelectedIndex = -1;
            for (int i = 0; i < mShop.Length; i++)
            {
                if (mShop[i].shop_code == shop_code)
                {
                    cbShop.SelectedIndex = i;
                }
            }

            //
            Task.Delay(100);

            //
            String nod_code1 = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(nodcode1)].Text;

            for (int i = 0; i < thisNod1.Count; i++)
            {
                if (thisNod1[i].nod_code1 == nod_code1)
                {
                    cbNod1.SelectedIndex = i;
                }
            }

            //
            Task.Delay(100);

            //
            String nod_code2 = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(nodcode2)].Text;

            for (int i = 0; i < thisNod2.Count; i++)
            {
                if (thisNod2[i].nod_code2 == nod_code2)
                {
                    cbNod2.SelectedIndex = i;
                }
            }




            //

            String id = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(option_id)].Text;

            if (id == "")
            {
                cbOptionTemplate.SelectedIndex = -1;
            }
            else
            {
                for (int i = 0; i < mOptionTemplate.Length; i++)
                {
                    if (mOptionTemplate[i].option_template_id == id)
                    {
                        cbOptionTemplate.SelectedIndex = i;
                    }
                }
            }


            // 배지
            id = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(badges_id)].Text;

            for (int i = 0; i < mBadges.Length; i++)
            {
                if (mBadges[i].badges_id == id)
                {
                    cbBadges.SelectedIndex = i;
                }
            }



            tbMemo.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(memo)].Text;
            tbCouponLinkNo.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(coupon_link_no)].Text;

            pbImage.Image = null;

            if (lvwList.SelectedItems[0].Tag.ToString().Trim() != "")
            {
                try
                {
                    byte[] imgBytes = Convert.FromBase64String(lvwList.SelectedItems[0].Tag.ToString());
                
                    MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                    ms.Write(imgBytes, 0, imgBytes.Length);

                    pbImage.Image = System.Drawing.Image.FromStream(ms, true);
                }
                catch
                {

                }
            }


            // 보관
            sv_goodsName = tbGoodsName.Text;
            sv_goodsNameEN = tbGoodsNameEN.Text;
            sv_goodsNameCH = tbGoodsNameCH.Text;
            sv_goodsNameJP = tbGoodsNameJP.Text;

            sv_goodsNotice = tbGoodsNotice.Text;

            sv_amt = tbGoodsAmt.Text;
            sv_shopCode = cbShop.SelectedIndex + "";
            sv_nodCode1 = cbNod1.SelectedIndex + "";
            sv_nodCode1 = cbNod2.SelectedIndex + "";

            sv_online_coupon = cbCoupon.Checked + "";
            sv_ticketYn = cbTicket.SelectedIndex + "";
            sv_taxFree = cbTaxFree.Checked + "";
            sv_cutout = cbCutout.Checked + "";
            sv_soldout = cbSoldout.Checked + "";
            sv_allim = cbAllim.Checked + "";

            sv_option_template_id = cbOptionTemplate.SelectedIndex + "";
            sv_badges_id = cbBadges.SelectedIndex + "";

            sv_memo = tbMemo.Text;
            sv_coupon_link_no = tbCouponLinkNo.Text;
            ch_imagePath = "0";

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            if (tbGoodsName.Text.Trim().Length == 0) 
            {
                MessageBox.Show("상품명 오류.", "thepos");
                return;  
            }


            if (!is_number(tbGoodsAmt.Text.Trim()))
            {
                MessageBox.Show("상품단가 오류.", "thepos");
                return;
            }

            if (cbShop.SelectedIndex == -1)
            {
                MessageBox.Show("샵(업장) 선택 오류.", "thepos");
                return;
            }



            if (tbGoodsName.Text.Trim() != lvwList.SelectedItems[0].Text.Trim())
            {
                DialogResult ret = MessageBox.Show("상품명 변경 : " + lvwList.SelectedItems[0].Text.Trim() + " -> " + tbGoodsName.Text.Trim() + " ", "thepos", MessageBoxButtons.OKCancel);

                if (ret == DialogResult.Cancel)
                {
                    return;
                }
            }




            //
            String select_goodscode = tbGoodsName.Tag.ToString();
            int select_index = lvwList.SelectedItems[0].Index;



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = select_goodscode;

            // 변경된 항목만 파라메터에 넣는다.
            // 
            if (sv_goodsName != tbGoodsName.Text.Trim())
                parameters["goodsName"] = tbGoodsName.Text.Trim();

            if (sv_goodsNameEN != tbGoodsNameEN.Text.Trim())
                parameters["goodsNameEn"] = tbGoodsNameEN.Text.Trim();

            if (sv_goodsNameCH != tbGoodsNameCH.Text.Trim())
                parameters["goodsNameCh"] = tbGoodsNameCH.Text.Trim();

            if (sv_goodsNameJP != tbGoodsNameJP.Text.Trim())
                parameters["goodsNameJp"] = tbGoodsNameJP.Text.Trim();

            // notice
            if (sv_goodsNotice != tbGoodsNotice.Text.Trim())
                parameters["goodsNotice"] = tbGoodsNotice.Text.Trim();

            // barCode
            if (sv_barcode != tbBarCode.Text.Trim())
                parameters["barCode"] = tbBarCode.Text.Trim();




            //
            if (sv_online_coupon != cbCoupon.Checked + "")
            {
                if (cbCoupon.Checked)
                    parameters["onlineCoupon"] = "Y";
                else
                    parameters["onlineCoupon"] = "";
            }

            //
            if (sv_ticketYn != cbTicket.SelectedIndex + "")
            {
                if (cbTicket.SelectedIndex == 1)
                    parameters["ticketYn"] = "Y";
                else if (cbTicket.SelectedIndex == 2)
                    parameters["ticketYn"] = "Ys";
                else
                    parameters["ticketYn"] = "N";
            }

            //
            if (sv_taxFree != cbTaxFree.Checked + "")
            {
                if (cbTaxFree.Checked)
                    parameters["taxFree"] = "Y";
                else
                    parameters["taxFree"] = "";
            }

            //
            if (sv_cutout != cbCutout.Checked + "")
            {
                if (cbCutout.Checked)
                    parameters["cutout"] = "Y";
                else
                    parameters["cutout"] = "";
            }

            //
            if (sv_soldout != cbSoldout.Checked + "")
            {
                if (cbSoldout.Checked)
                    parameters["soldout"] = "Y";
                else
                    parameters["soldout"] = "";
            }

            //
            if (sv_allim != cbAllim.Checked + "")
            {
                if (cbAllim.Checked)
                    parameters["allim"] = "Y";
                else
                    parameters["allim"] = "";
            }


            //
            if (sv_amt != tbGoodsAmt.Text)
                parameters["amt"] = tbGoodsAmt.Text;

            //
            if (cbShop.SelectedIndex == -1) cbShop.SelectedIndex = 0;
            if (cbNod1.SelectedIndex == -1) cbNod1.SelectedIndex = 0;
            if (cbNod2.SelectedIndex == -1) cbNod2.SelectedIndex = 0;


            if (sv_shopCode != cbShop.SelectedIndex + "")
                parameters["shopCode"] = mShop[cbShop.SelectedIndex].shop_code;

            if (sv_nodCode1 != cbNod1.SelectedIndex + "")
                parameters["nodCode1"] = thisNod1[cbNod1.SelectedIndex].nod_code1;

            if (sv_nodCode2 != cbNod2.SelectedIndex + "")
                parameters["nodCode2"] = thisNod2[cbNod2.SelectedIndex].nod_code2;




            //
            if (sv_option_template_id != cbOptionTemplate.SelectedIndex + "")
            {
                if (cbOptionTemplate.SelectedIndex > -1)
                {
                    parameters["optionTemplateId"] = mOptionTemplate[cbOptionTemplate.SelectedIndex].option_template_id;
                }
                else
                {
                    parameters["optionTemplateId"] = "";
                }
            }


            // 배지
            if (sv_badges_id != cbBadges.SelectedIndex + "")
            {
                if (cbBadges.SelectedIndex > -1)
                {
                    parameters["badgesId"] = mBadges[cbBadges.SelectedIndex].badges_id;
                }
                else
                {
                    parameters["badgesId"] = "";
                }
            }


            //
            if (sv_memo != tbMemo.Text)
                parameters["memo"] = tbMemo.Text;

            if (sv_coupon_link_no != tbCouponLinkNo.Text)
                parameters["couponLinkNo"] = tbCouponLinkNo.Text;


            //
            if (ch_imagePath == "1")
            {
                if (pbImage.Image == null)
                {
                    parameters["imagePath"] = "";
                }
                else
                {
                    var ms = new MemoryStream();
                    pbImage.Image.Save(ms, pbImage.Image.RawFormat);
                    parameters["imagePath"] = Convert.ToBase64String(ms.ToArray());
                }
            }


            //
            if (mRequestPatch("goods", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    
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


            //
            ListViewItem lvItem = reload_select(select_goodscode);

            if (lvItem != null)
            {
                lvwList.Items[select_index] = lvItem;
                lvItem.Selected = true;
                lvwList.Select();
                lvwList.EnsureVisible(select_index);
            }

            //
            //set_version_basic_db_change();


            //MessageBox.Show("정상 수정 완료.", "thepos");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (tbGoodsName.Text.Trim().Length == 0)
            {
                MessageBox.Show("상품명 오류.", "thepos");
                return;
            }

            if (!is_number(tbGoodsAmt.Text.Trim()))
            {
                MessageBox.Show("상품단가 오류.", "thepos");
                return;
            }

            
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                if (lvwList.Items[i].Text.Trim() == tbGoodsName.Text.Trim())
                {
                    MessageBox.Show("동일한 상품명이 이미 있습니다..", "thepos");
                    return;
                }
            }


            if (cbShop.SelectedIndex == -1) return;



            String new_goodscode = "";

            // goodsCode를 가장 큰값을 서버에 물어본다.
            String sUrl = "requestGoodsCode?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String date = mObj["goodsCodes"].ToString();
                    JArray arr = JArray.Parse(date);
                    new_goodscode = arr[0]["goodsCode"].ToString();
                }
                else
                {
                    thepos_app_log(3, this.Name, "btnAdd_Click()", "상품신규등록 시스템 채번오류. url=" + sUrl + " result_msg = " + mObj["resultMsg"].ToString());
                    MessageBox.Show("상품신규등록 시스템 채번오류.\r\n시스템 관리자 문의바랍니다.", "thepos");
                    return;
                }
            }
            else
            {
                thepos_app_log(3, this.Name, "btnAdd_Click()", "상품신규등록 시스템 채번오류. url=" + sUrl);
                MessageBox.Show("상품신규등록 시스템 채번오류.\r\n시스템 관리자 문의바랍니다.", "thepos");
                return;
            }




            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = new_goodscode;

            parameters["goodsName"] = tbGoodsName.Text.Trim();
            parameters["goodsNameEN"] = tbGoodsNameEN.Text.Trim();
            parameters["goodsNameCH"] = tbGoodsNameCH.Text.Trim();
            parameters["goodsNameJP"] = tbGoodsNameJP.Text.Trim();

            parameters["goodsNotice"] = tbGoodsNotice.Text.Trim();

            parameters["barCode"] = tbBarCode.Text.Trim();


            if (cbCoupon.Checked)
                parameters["onlineCoupon"] = "Y";
            else
                parameters["onlineCoupon"] = "";

            if (cbTicket.SelectedIndex == 1)
                parameters["ticketYn"] = "Y";
            else if (cbTicket.SelectedIndex == 2)
                parameters["ticketYn"] = "Ys";
            else
                parameters["ticketYn"] = "N";

            if (cbTaxFree.Checked)
                parameters["taxFree"] = "Y";
            else
                parameters["taxFree"] = "N";

            if (cbCutout.Checked)
                parameters["cutout"] = "Y";
            else
                parameters["cutout"] = "N";

            if (cbSoldout.Checked)
                parameters["soldout"] = "Y";
            else
                parameters["soldout"] = "N";

            if (cbAllim.Checked)
                parameters["allim"] = "Y";
            else
                parameters["allim"] = "N";

            parameters["amt"] = tbGoodsAmt.Text;

            //
            parameters["shopCode"] = mShop[cbShop.SelectedIndex].shop_code;
            parameters["nodCode1"] = thisNod1[cbNod1.SelectedIndex].nod_code1;
            parameters["nodCode2"] = thisNod2[cbNod2.SelectedIndex].nod_code2;


            //
            if (cbOptionTemplate.SelectedIndex > -1)
            {
                parameters["optionTemplateId"] = mOptionTemplate[cbOptionTemplate.SelectedIndex].option_template_id;
            }
            else
            {
                parameters["optionTemplateId"] = "";
            }


            // 배지
            if (cbBadges.SelectedIndex > -1)
            {
                parameters["badgesId"] = mBadges[cbBadges.SelectedIndex].badges_id;
            }
            else
            {
                parameters["badgesId"] = "";
            }


            parameters["memo"] = tbMemo.Text;
            parameters["couponLinkNo"] = tbCouponLinkNo.Text;

            if (pbImage.Image == null)
            {
                parameters["imagePath"] = "";
            }
            else
            {
                var ms = new MemoryStream();
                pbImage.Image.Save(ms, pbImage.Image.RawFormat);
                parameters["imagePath"] = Convert.ToBase64String(ms.ToArray());
            }



            if (mRequestPost("goods", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 등록 완료.", "thepos");
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


            //
            ListViewItem lvItem = reload_select(new_goodscode);

            if (lvItem != null)
            {
                lvItem.Selected = true;
                lvwList.Items.Add(lvItem);
                lvwList.Select();

                lvwList.EnsureVisible(lvwList.Items.Count - 1);
            }

            //
            //set_version_basic_db_change();

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            if (MessageBox.Show("선택 상품을 삭제합니다.\n연결된 상품정보가 있을경우 사용체크 제외로 수정하세요.", "thwpos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
            else
            {
                return;
            }


            int select_index = lvwList.SelectedItems[0].Index;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = tbGoodsName.Tag.ToString();


            if (mRequestDelete("goods", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 삭제 완료.", "thepos");
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

            // 
            lvwList.Items[select_index].Remove();

            //
            //set_version_basic_db_change();

            clear_console();

        }


        private void lvwList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //?? 숫자컬럼(단가) Sorting 고려하기

            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                lvwList.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvwList.Sorting == SortOrder.Ascending)
                {
                    lvwList.Sorting = SortOrder.Descending;
                }
                else
                {
                    lvwList.Sorting = SortOrder.Ascending; 
                }
            }

            
            lvwList.Sort();
            this.lvwList.ListViewItemSorter = new MyListViewComparer(e.Column, lvwList.Sorting);
        }

        class MyListViewComparer : IComparer
        {
            private int col; private SortOrder order; public MyListViewComparer() { col = 0; order = SortOrder.Ascending; }

            public MyListViewComparer(int column, SortOrder order) { col = column; this.order = order; }

            public int Compare(object x, object y)
            {
                int returnVal = -1; returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

                // Determine whether the sort order is descending. 
                if (order == SortOrder.Descending) returnVal *= -1; // Invert the value returned by String.Compare. 

                return returnVal;
            }
        }


        private void pbImage_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                string fileFullName = openFileDialog.FileName;

                System.Drawing.Image image = System.Drawing.Image.FromFile(fileFullName);
                this.pbImage.Image = image;

                ch_imagePath = "1";
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            pbImage.Image = null;
            ch_imagePath = "1";
        }

        private void btnExcelUp_Click(object sender, EventArgs e)
        {
            frmSysGoodsExcelUp frm = new frmSysGoodsExcelUp();
            frm.ShowDialog();
        }

        private void cbShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbShop.SelectedIndex < 0)
            {
                return;
            }


            //
            cbNod1.Items.Clear();
            thisNod1.Clear();
            Nod1 tNod1 = new Nod1();
            tNod1.shop_code = "";
            tNod1.nod_code1 = "";
            tNod1.nod_name1 = "";
            thisNod1.Add(tNod1);


            //
            cbNod2.Items.Clear();
            thisNod2.Clear();
            Nod2 tNod2 = new Nod2();
            tNod2.shop_code = "";
            tNod2.nod_code1 = "";
            tNod2.nod_code2 = "";
            tNod2.nod_name2 = "";
            thisNod2.Add(tNod2);


            //
            String tShopCode = mShop[cbShop.SelectedIndex].shop_code;

            if (cbShop.SelectedIndex > 0)
            {
                for (int i = 0; i < mNod1.Length; i++)
                {
                    if (mNod1[i].shop_code == tShopCode)
                    {
                        thisNod1.Add(mNod1[i]);
                    }
                }                
            }


            //
            for (int i = 0;i < thisNod1.Count; i++)
            {
                cbNod1.Items.Add(thisNod1[i].nod_name1);
            }

            cbNod1.SelectedIndex = 0;


        }

        private void cbNod1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNod1.SelectedIndex < 0)
            {
                return;
            }

            //
            cbNod2.Items.Clear();
            thisNod2.Clear();
            Nod2 tNod2 = new Nod2();
            tNod2.shop_code = "";
            tNod2.nod_code1 = "";
            tNod2.nod_code2 = "";
            tNod2.nod_name2 = "";
            thisNod2.Add(tNod2);


            String shop_code = thisNod1[cbNod1.SelectedIndex].shop_code;
            String nod_code1 = thisNod1[cbNod1.SelectedIndex].nod_code1;

            if (cbNod1.SelectedIndex > 0)
            {
                for (int i = 0; i < mNod2.Length; i++)
                {
                    if (mNod2[i].shop_code == shop_code & mNod2[i].nod_code1 == nod_code1)
                    {
                        thisNod2.Add(mNod2[i]);
                    }
                }
            }


            //
            for (int i = 0; i < thisNod2.Count; i++)
            {
                cbNod2.Items.Add(thisNod2[i].nod_name2);
            }

            cbNod2.SelectedIndex = 0;

        }
    }
}
