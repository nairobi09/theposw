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

namespace thepos
{
    public partial class frmReportDayShop : Form
    {
        String thisBizDt = "";


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

        private void btnView_Click(object sender, EventArgs e)
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



            thisBizDt = dtpBizDate.Value.ToString("yyyyMMdd");

            lvwList.Items.Clear();


            String sUrl = "reportDayShop?siteId=" + mSiteId + "&bizDt=" + thisBizDt;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayShops"].ToString();
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
                            if (save_nodcode2 != arr[i]["nodCode2"].ToString())
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

                                nod2_cnt = 0;
                                nod2_amount = 0;
                                nod2_dcAmount = 0;
                                nod2_netAmount = 0;
                            }

                            if (save_nodcode1 != arr[i]["nodCode1"].ToString())
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

                                nod1_cnt = 0;
                                nod1_amount = 0;
                                nod1_dcAmount = 0;
                                nod1_netAmount = 0;
                            }

                            if (save_shopcode != arr[i]["shopCode"].ToString())
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

                                shop_cnt = 0;
                                shop_amount = 0;
                                shop_dcAmount = 0;
                                shop_netAmount = 0;
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
                else
                {
                    //MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. reportDayShop\n\n" + mErrorMsg, "thepos");
            }
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {

            if (lvwList.Items.Count == 0)
            {
                return;
            }


            //
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = "TP_" + thisBizDt,
                Filter = "엑셀 파일 (*.xlsx)|*.xlsx",
                Title = "엑셀파일 저장"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportListViewToCsv(saveFileDialog.FileName);
                MessageBox.Show("저장 완료!");
            }
        }


        public void ExportListViewToCsv(string filePath)
        {

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sheet1");


            worksheet.Cell(1, 1).Value = lvwList.Columns[0].Text;
            worksheet.Cell(1, 2).Value = lvwList.Columns[1].Text;
            worksheet.Cell(1, 3).Value = lvwList.Columns[2].Text;
            worksheet.Cell(1, 4).Value = lvwList.Columns[3].Text;
            worksheet.Cell(1, 5).Value = lvwList.Columns[4].Text;

            worksheet.Column(1).Width = 20;
            worksheet.Column(2).Width = 10;
            worksheet.Column(3).Width = 20;
            worksheet.Column(4).Width = 20;
            worksheet.Column(5).Width = 20;


            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = lvwList.Items[i].Text;
                worksheet.Cell(i + 2, 2).Value = Int32.Parse(lvwList.Items[i].SubItems[1].Text.Replace(",", ""));
                worksheet.Cell(i + 2, 3).Value = Int32.Parse(lvwList.Items[i].SubItems[2].Text.Replace(",", ""));
                worksheet.Cell(i + 2, 4).Value = Int32.Parse(lvwList.Items[i].SubItems[3].Text.Replace(",", ""));
                worksheet.Cell(i + 2, 5).Value = Int32.Parse(lvwList.Items[i].SubItems[4].Text.Replace(",", ""));
            }



            workbook.SaveAs(filePath);


        }
    }
}
