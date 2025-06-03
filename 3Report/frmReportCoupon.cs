using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using ClosedXML.Excel;

namespace thepos._1Sales
{
    public partial class frmReportCoupon : Form
    {
        String thisBizDt = "";

        public frmReportCoupon()
        {
            InitializeComponent();
            initialize_the();

            thepos_app_log(1, this.Name, "open", "");
        }

        private void initialize_the()
        {

            dtpBizDate.Value = DateTime.Now;

            cbCoupon.Items.Clear();
            cbCoupon.Items.Add("테이블메니저");
            cbCoupon.SelectedIndex = 0;
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            thisBizDt = dtpBizDate.Value.ToString("yyyyMMdd");

            lvwList.Items.Clear();

            int tot_cnt = 0;
            int tot_amount = 0;


            String sUrl = "paymentCert?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&isCancel=";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentCerts"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem sumItem = new ListViewItem();
                        sumItem.Text = arr[i]["vanCode"].ToString();
                        sumItem.SubItems.Add(arr[i]["couponNo"].ToString());
                        sumItem.SubItems.Add(arr[i]["couponLinkNo"].ToString());

                        //
                        String t_coupon_link_no = arr[i]["couponLinkNo"].ToString();

                        if (t_coupon_link_no != "")
                        {
                            int link_goods_idx = -1;
                            for (int k = 0; k < mGoodsItem.Length; k++)
                            {
                                if (t_coupon_link_no == mGoodsItem[k].coupon_link_no)
                                {
                                    link_goods_idx = k;
                                }
                            }

                            String t_goods_code = "";
                            String t_goods_name = "";
                            if (link_goods_idx > -1)
                            {
                                t_goods_code = mGoodsItem[link_goods_idx].goods_code;
                                t_goods_name = mGoodsItem[link_goods_idx].goods_name;
                            }
    
                            sumItem.SubItems.Add("[" + t_goods_code + "] " + t_goods_name);
                        }
                        else
                        {
                            sumItem.SubItems.Add("");
                        }


                        tot_cnt += Int32.Parse(arr[i]["cnt"].ToString());
                        tot_amount += Int32.Parse(arr[i]["amount"].ToString());

                        sumItem.SubItems.Add(arr[i]["cnt"].ToString());
                        sumItem.SubItems.Add(arr[i]["amount"].ToString());
                        sumItem.SubItems.Add(get_MMddHHmm(arr[i]["payDate"].ToString(), arr[i]["payTime"].ToString()));
                        lvwList.Items.Add(sumItem);

                    }

                    //
                    if (tot_cnt > 0)
                    {
                        ListViewItem sumItem = new ListViewItem();
                        sumItem.Text = "";
                        sumItem.SubItems.Add("합계");
                        sumItem.SubItems.Add("");
                        sumItem.SubItems.Add("");

                        sumItem.SubItems.Add(tot_cnt + "");
                        sumItem.SubItems.Add(tot_amount + "");
                        sumItem.SubItems.Add("");
                        lvwList.Items.Add(sumItem);
                    }


                }
            }

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
                sfd.FileName = "TM_" + mSiteAlias + "_" + dtpBizDate.Text + ".xlsx";
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Save Excel File";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportListViewToExcel(lvwList, sfd.FileName);
                    MessageBox.Show("엑셀 파일로 저장되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ExportListViewToExcel(ListView listView, string filePath)
        {
            
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(dtpBizDate.Text);

            // 헤더 작성
            for (int col = 0; col < listView.Columns.Count; col++)
            {
                worksheet.Cell(1, col + 1).Value = listView.Columns[col].Text;
            }

            // 데이터 작성
            for (int row = 0; row < listView.Items.Count; row++)
            {
                for (int col = 0; col < listView.Columns.Count; col++)
                {
                    worksheet.Cell(row + 2, col + 1).Value = listView.Items[row].SubItems[col].Text;
                }
            }

            // 파일 저장
            workbook.SaveAs(filePath);
        }

    }
}
