using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows.Forms;
using static thepos.thePos;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Drawing.Text;

namespace thepos
{
    public partial class frmReportDayShop : Form
    {
        String d_type = "";
        String d_str = "";


        public frmReportDayShop()
        {
            InitializeComponent();
            initialize_the();

            thepos_app_log(1, this.Name, "open", "");
        }

        private void initialize_the()
        {
            if (mBizDate == "")
            {

            }
            else
            {
                dtpBizDate.Value = new DateTime(convert_number(mBizDate.Substring(0, 4)), convert_number(mBizDate.Substring(4, 2)), convert_number(mBizDate.Substring(6, 2)));
            }
        }



        private void btnViewDay_Click(object sender, EventArgs e)
        {
            d_type = "Day";
            d_str = dtpBizDate.Value.ToString("yyyyMMdd");
            report_shop(d_str);
        }

        private void report_shop(String r_date)
        {
            lvwList.Items.Clear();

            String sUrl = "reportDayShop?siteId=" + mSiteId + "&bizDt=" + r_date + "&goodsName=" + tbKeyword.Text;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayShops"].ToString();
                    get_list(data);

                }
                else
                {
                    MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. reportDayShop\n\n" + mErrorMsg, "thepos");
            }


        }
                

        private void get_list(String data)
        {
            String save_nodcode2 = "";
            String save_nodcode1 = "";
            String save_shopcode = "";

            int cnt = 0;
            int amount = 0;
            int dcAmount = 0;
            int netAmount = 0;

            int nod2_cnt = 0;
            int nod2_amount = 0;
            int nod2_dcAmount = 0;
            int nod2_netAmount = 0;

            int nod1_cnt = 0;
            int nod1_amount = 0;
            int nod1_dcAmount = 0;
            int nod1_netAmount = 0;

            int shop_cnt = 0;
            int shop_amount = 0;
            int shop_dcAmount = 0;
            int shop_netAmount = 0;

            int tot_cnt = 0;
            int tot_amount = 0;
            int tot_dcAmount = 0;
            int tot_netAmount = 0;

            JArray arr = JArray.Parse(data);


            if (arr.Count > 0)
            {
                save_shopcode = arr[arr.Count - 1]["shopCode"].ToString();
                save_nodcode1 = arr[arr.Count - 1]["nodCode1"].ToString();
                save_nodcode2 = arr[arr.Count - 1]["nodCode2"].ToString();
            }



            for (int i = arr.Count - 1; i >= 0; i--)
            {
                cnt = convert_number(arr[i]["cnt"].ToString());
                amount = convert_number(arr[i]["amount"].ToString());
                dcAmount = convert_number(arr[i]["dcAmount"].ToString());
                netAmount = convert_number(arr[i]["netAmount"].ToString());


                if (save_shopcode != arr[i]["shopCode"].ToString() | save_nodcode1 != arr[i]["nodCode1"].ToString() | save_nodcode2 != arr[i]["nodCode2"].ToString())
                {

                    //
                    //if (save_shopcode == arr[i]["shopCode"].ToString() & save_nodcode1 == arr[i]["nodCode1"].ToString() & save_nodcode2 != arr[i]["nodCode2"].ToString())
                    if (save_nodcode2 != arr[i]["nodCode2"].ToString())
                    {
                        if (save_nodcode2 != "")
                        {
                            ListViewItem sItem = new ListViewItem();
                            sItem.Text = "[" + get_nod2_name(save_shopcode, save_nodcode1, save_nodcode2) + "]";
                            sItem.SubItems.Add(nod2_cnt.ToString("N0"));
                            sItem.SubItems.Add(nod2_amount.ToString("N0"));
                            sItem.SubItems.Add(nod2_dcAmount.ToString("N0"));
                            sItem.SubItems.Add(nod2_netAmount.ToString("N0"));
                            sItem.ForeColor = System.Drawing.Color.Purple;
                            sItem.SubItems[1].ForeColor = System.Drawing.Color.Purple;
                            sItem.SubItems[2].ForeColor = System.Drawing.Color.Purple;
                            sItem.SubItems[3].ForeColor = System.Drawing.Color.Purple;
                            sItem.SubItems[4].ForeColor = System.Drawing.Color.Purple;
                            lvwList.Items.Add(sItem);
                        }

                        nod2_cnt = 0; nod2_amount = 0; nod2_dcAmount = 0; nod2_netAmount = 0;
                    }

                    //if (save_shopcode == arr[i]["shopCode"].ToString() & save_nodcode1 != arr[i]["nodCode1"].ToString())
                    if (save_nodcode1 != arr[i]["nodCode1"].ToString())
                    {
                        if (save_nodcode1 != "")
                        {
                            ListViewItem sItem = new ListViewItem();
                            sItem.Text = "[" + get_nod1_name(save_shopcode, save_nodcode1) + "]";
                            sItem.SubItems.Add(nod1_cnt.ToString("N0"));
                            sItem.SubItems.Add(nod1_amount.ToString("N0"));
                            sItem.SubItems.Add(nod1_dcAmount.ToString("N0"));
                            sItem.SubItems.Add(nod1_netAmount.ToString("N0"));
                            sItem.ForeColor = System.Drawing.Color.Blue;
                            sItem.SubItems[1].ForeColor = System.Drawing.Color.Blue;
                            sItem.SubItems[2].ForeColor = System.Drawing.Color.Blue;
                            sItem.SubItems[3].ForeColor = System.Drawing.Color.Blue;
                            sItem.SubItems[4].ForeColor = System.Drawing.Color.Blue;
                            lvwList.Items.Add(sItem);
                        }

                        nod2_cnt = 0; nod2_amount = 0; nod2_dcAmount = 0; nod2_netAmount = 0;
                        nod1_cnt = 0; nod1_amount = 0; nod1_dcAmount = 0; nod1_netAmount = 0;
                    }

                    if (save_shopcode != arr[i]["shopCode"].ToString())
                    {
                        if (save_shopcode != "")
                        {
                            ListViewItem sItem = new ListViewItem();
                            sItem.Text = "[" + get_shop_name(save_shopcode) + "]";
                            sItem.SubItems.Add(shop_cnt.ToString("N0"));
                            sItem.SubItems.Add(shop_amount.ToString("N0"));
                            sItem.SubItems.Add(shop_dcAmount.ToString("N0"));
                            sItem.SubItems.Add(shop_netAmount.ToString("N0"));
                            sItem.ForeColor = System.Drawing.Color.Red;
                            sItem.SubItems[1].ForeColor = System.Drawing.Color.Red;
                            sItem.SubItems[2].ForeColor = System.Drawing.Color.Red;
                            sItem.SubItems[3].ForeColor = System.Drawing.Color.Red;
                            sItem.SubItems[4].ForeColor = System.Drawing.Color.Red;
                            lvwList.Items.Add(sItem);
                        }

                        nod2_cnt = 0; nod2_amount = 0; nod2_dcAmount = 0; nod2_netAmount = 0;
                        nod1_cnt = 0; nod1_amount = 0; nod1_dcAmount = 0; nod1_netAmount = 0;
                        shop_cnt = 0; shop_amount = 0; shop_dcAmount = 0; shop_netAmount = 0;
                    }
                }


                //
                ListViewItem Item = new ListViewItem();
                Item.Text = get_goods_name(arr[i]["goodsCode"].ToString());
                Item.SubItems.Add(cnt.ToString("N0"));
                Item.SubItems.Add(amount.ToString("N0"));
                Item.SubItems.Add(dcAmount.ToString("N0"));
                Item.SubItems.Add(netAmount.ToString("N0"));
                lvwList.Items.Add(Item);


                //
                nod2_cnt += cnt;
                nod2_amount += amount;
                nod2_dcAmount += dcAmount;
                nod2_netAmount += netAmount;

                nod1_cnt += cnt;
                nod1_amount += amount;
                nod1_dcAmount += dcAmount;
                nod1_netAmount += netAmount;

                shop_cnt += cnt;
                shop_amount += amount;
                shop_dcAmount += dcAmount;
                shop_netAmount += netAmount;

                tot_cnt += cnt;
                tot_amount += amount;
                tot_dcAmount += dcAmount;
                tot_netAmount += netAmount;


                save_shopcode = arr[i]["shopCode"].ToString();
                save_nodcode1 = arr[i]["nodCode1"].ToString();
                save_nodcode2 = arr[i]["nodCode2"].ToString();

            }

            //
            if (save_nodcode2 != "")
            {
                ListViewItem sItem = new ListViewItem();
                sItem.Text = "[" + get_nod2_name(save_shopcode, save_nodcode1, save_nodcode2) + "]";
                sItem.SubItems.Add(nod2_cnt.ToString("N0"));
                sItem.SubItems.Add(nod2_amount.ToString("N0"));
                sItem.SubItems.Add(nod2_dcAmount.ToString("N0"));
                sItem.SubItems.Add(nod2_netAmount.ToString("N0"));
                sItem.ForeColor = System.Drawing.Color.Purple;
                sItem.SubItems[1].ForeColor = System.Drawing.Color.Purple;
                sItem.SubItems[2].ForeColor = System.Drawing.Color.Purple;
                sItem.SubItems[3].ForeColor = System.Drawing.Color.Purple;
                sItem.SubItems[4].ForeColor = System.Drawing.Color.Purple;
                lvwList.Items.Add(sItem);
            }

            if (save_nodcode1 != "")
            {
                ListViewItem sItem = new ListViewItem();
                sItem.Text = "[" + get_nod1_name(save_shopcode, save_nodcode1) + "]";
                sItem.SubItems.Add(nod1_cnt.ToString("N0"));
                sItem.SubItems.Add(nod1_amount.ToString("N0"));
                sItem.SubItems.Add(nod1_dcAmount.ToString("N0"));
                sItem.SubItems.Add(nod1_netAmount.ToString("N0"));
                sItem.ForeColor = System.Drawing.Color.Blue;
                sItem.SubItems[1].ForeColor = System.Drawing.Color.Blue;
                sItem.SubItems[2].ForeColor = System.Drawing.Color.Blue;
                sItem.SubItems[3].ForeColor = System.Drawing.Color.Blue;
                sItem.SubItems[4].ForeColor = System.Drawing.Color.Blue;
                lvwList.Items.Add(sItem);
            }

            if (save_shopcode != "")
            {
                ListViewItem sItem = new ListViewItem();
                sItem.Text = "[" + get_shop_name(save_shopcode) + "]";
                sItem.SubItems.Add(shop_cnt.ToString("N0"));
                sItem.SubItems.Add(shop_amount.ToString("N0"));
                sItem.SubItems.Add(shop_dcAmount.ToString("N0"));
                sItem.SubItems.Add(shop_netAmount.ToString("N0"));
                sItem.ForeColor = System.Drawing.Color.Red;
                sItem.SubItems[1].ForeColor = System.Drawing.Color.Red;
                sItem.SubItems[2].ForeColor = System.Drawing.Color.Red;
                sItem.SubItems[3].ForeColor = System.Drawing.Color.Red;
                sItem.SubItems[4].ForeColor = System.Drawing.Color.Red;
                lvwList.Items.Add(sItem);
            }


            ListViewItem tItem = new ListViewItem();
            tItem.Text = "[전체]";
            tItem.SubItems.Add(tot_cnt.ToString("N0"));
            tItem.SubItems.Add(tot_amount.ToString("N0"));
            tItem.SubItems.Add(tot_dcAmount.ToString("N0"));
            tItem.SubItems.Add(tot_netAmount.ToString("N0"));
            lvwList.Items.Add(tItem);

        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {

            if (lvwList.Items.Count == 0)
            {
                return;
            }

            //
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "TP_" + mSiteAlias + "_" + d_type + " " + d_str + ".xlsx";
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Save Excel File";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportListViewToExcel(lvwList, sfd.FileName, dtpBizDate.Text);
                    MessageBox.Show("엑셀 파일로 저장되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



    }
}
