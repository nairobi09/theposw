using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using PrinterUtility.EscPosBemaCommands;
using static System.Net.Mime.MediaTypeNames;
using static thepos.thePos;

namespace theposw._9SysAdmin
{
    public partial class frmSysGoodsExcelUp : Form
    {
        String[] goods_column = new String[19];


        String goodsCode = "";
        String goodsName = "";
        String goodsNameEN = "";
        String goodsNameCH = "";
        String goodsNameJP = "";

        String goodsNotice = "";

        String onlineCoupon = "";
        String ticketYn = "";
        String taxFree = "";
        String cutout = "";
        String soldout = "";
        String allim = "";

        String amt = "";

        String shopCode = "";
        String optionTemplateId = "";
        String badgesId = "";
        String memo = "";
        String couponLinkNo = "";

        String imagePath = "";

        String barCode = "";
        String nodCode1 = "";

        //
        int int_goods_code = 0;



        public frmSysGoodsExcelUp()
        {
            InitializeComponent();


            goods_column[0] = "goodsName";
            goods_column[1] = "goodsNameEn";
            goods_column[2] = "goodsNameCh";
            goods_column[3] = "goodsNameJp";
            goods_column[4] = "amt";
            goods_column[5] = "ticketYn";
            goods_column[6] = "onlineCoupon";
            goods_column[7] = "couponLinkNo";
            goods_column[8] = "barCode";
            goods_column[9] = "taxFree";
            goods_column[10] = "cutout";
            goods_column[11] = "soldout";
            goods_column[12] = "allim";
            goods_column[13] = "imagePath";
            goods_column[14] = "shopCode";
            goods_column[15] = "optionTemplateId";
            goods_column[16] = "goodsNotice";
            goods_column[17] = "badgesId";
            goods_column[18] = "memo";



        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    DataTable dt = LoadExcelFile(filePath);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private DataTable LoadExcelFile(string path)
        {
            var dt = new DataTable();

            using (var workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheets.Worksheet(1); // 첫 번째 시트
                bool firstRow = true;
                foreach (var row in worksheet.RowsUsed())
                {
                    if (firstRow)
                    {
                        foreach (var cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                            
                        firstRow = false;
                    }
                    else
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (var cell in row.Cells())
                            dt.Rows[dt.Rows.Count - 1][i++] = cell.Value.ToString();
                    }
                }
            }

            return dt;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            int_goods_code = Convert.ToInt32(tbStartGoodsCode.Text);


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //
                {
                    goodsCode = int_goods_code + "";
                    goodsName = "";
                    goodsNameEN = "";
                    goodsNameCH = "";
                    goodsNameJP = "";
                    goodsNotice = "";
                    onlineCoupon = "";
                    ticketYn = "";
                    taxFree = "";
                    cutout = "";
                    soldout = "";
                    allim = "";
                    amt = "";
                    shopCode = "";
                    optionTemplateId = "";
                    badgesId = "";
                    memo = "";
                    couponLinkNo = "";
                    imagePath = "";
                    barCode = "";
                    nodCode1 = "";
                }

                if (!row.IsNewRow)
                {
                    var rowData = new Dictionary<string, string>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string columnName = dataGridView1.Columns[cell.ColumnIndex].HeaderText;

                        if (columnName == "goodsName") { goodsName = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "goodsNameEN") { goodsNameEN = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "goodsNameCH") { goodsNameCH = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "goodsNameJP") { goodsNameJP = cell.Value?.ToString() ?? string.Empty; }

                        else if (columnName == "Notice") { goodsNotice = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "barCode") { barCode = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "onlineCoupon") { onlineCoupon = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "ticketYn") { ticketYn = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "taxFree") { taxFree = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "cutout") { cutout = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "soldout") { soldout = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "allim") { allim = cell.Value?.ToString() ?? string.Empty; }

                        else if (columnName == "amt") { amt = cell.Value?.ToString() ?? string.Empty; }

                        else if (columnName == "shopCode") { shopCode = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "optionTemplateId") { optionTemplateId = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "badgesId") { badgesId = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "memo") { memo = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "couponLinkNo") { couponLinkNo = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "imagePath") { imagePath = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "nodCode1") { nodCode1 = cell.Value?.ToString() ?? string.Empty; }

                    }

                    //
                    Dictionary<string, string> parameter = new Dictionary<string, string>();
                    parameter["siteId"] = mSiteId;
                    parameter["goodsCode"] = goodsCode;

                    parameter["goodsName"] = goodsName;
                    parameter["goodsNameEN"] = goodsNameEN;
                    parameter["goodsNameCH"] = goodsNameCH;
                    parameter["goodsNameJP"] = goodsNameJP;

                    parameter["goodsNotice"] = goodsNotice;
                    parameter["barCode"] = barCode;
                    parameter["onlineCoupon"] = onlineCoupon;
                    parameter["ticketYn"] = ticketYn;
                    parameter["taxFree"] = taxFree;
                    parameter["cutout"] = cutout;
                    parameter["soldout"] = soldout;
                    parameter["allim"] = allim;
                    parameter["amt"] = amt;
                    parameter["shopCode"] = shopCode;
                    parameter["optionTemplateId"] = optionTemplateId;
                    parameter["badgesId"] = badgesId;
                    parameter["memo"] = memo;
                    parameter["couponLinkNo"] = couponLinkNo;
                    parameter["imagePath"] = imagePath;

                    parameter["nodCode1"] = nodCode1;
                    parameter["nodCode2"] = "";

                    //
                    if (mRequestPost("goods", parameter))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            //MessageBox.Show("등록 완료.", "thepos");
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

                }

                int_goods_code++;
            }

            MessageBox.Show("등록 완료.", "thepos");

        }

    }
}
