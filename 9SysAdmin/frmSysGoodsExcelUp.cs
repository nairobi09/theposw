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
using static System.Net.Mime.MediaTypeNames;
using static thepos.thePos;

namespace theposw._9SysAdmin
{
    public partial class frmSysGoodsExcelUp : Form
    {
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

        //String imagePath = "";



        public frmSysGoodsExcelUp()
        {
            InitializeComponent();
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
                            dt.Columns.Add(cell.Value.ToString());
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

        private void btnConversion_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var rowData = new Dictionary<string, string>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string columnName = dataGridView1.Columns[cell.ColumnIndex].HeaderText;

                             if (columnName == "goodsCode")     { goodsCode = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "goodsName")     { goodsName = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "goodsNameEN")   { goodsNameEN = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "goodsNameCH")   { goodsNameCH = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "goodsNameJP")   { goodsNameJP = cell.Value?.ToString() ?? string.Empty; }

                        else if (columnName == "Notice")        { goodsNotice = cell.Value?.ToString() ?? string.Empty; }

                        else if (columnName == "onlineCoupon")  { onlineCoupon = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "ticketYn")      { ticketYn = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "taxFree")       { taxFree = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "cutout")        { cutout = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "soldout")       { soldout = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "allim")         { allim = cell.Value?.ToString() ?? string.Empty; }

                        else if (columnName == "amt")           { amt = cell.Value?.ToString() ?? string.Empty; }

                        else if (columnName == "shopCode")      { shopCode = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "optionTemplateId")  { optionTemplateId = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "badgesId")      { badgesId = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "memo")          { memo = cell.Value?.ToString() ?? string.Empty; }
                        else if (columnName == "couponLinkNo")  { couponLinkNo = cell.Value?.ToString() ?? string.Empty; }
                        //else if (columnName == "imagePath")     { imagePath = cell.Value?.ToString() ?? string.Empty; }
                    }

                    //




                }
            }




            //

            int max_goodscode = 100000;


            max_goodscode++;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = max_goodscode.ToString();

            parameters["goodsName"] = "";
            parameters["goodsNameEN"] = "";
            parameters["goodsNameCH"] = "";
            parameters["goodsNameJP"] = "";

            parameters["goodsNotice"] = "";

            parameters["onlineCoupon"] = "N";
            parameters["ticketYn"] = "N";
            parameters["taxFree"] = "N";
            parameters["cutout"] = "N";
            parameters["soldout"] = "N";
            parameters["allim"] = "N";

            parameters["amt"] = amt;

            parameters["shopCode"] = "";
            parameters["optionTemplateId"] = "";
            parameters["badgesId"] = "";
            parameters["memo"] = "";
            parameters["couponLinkNo"] = "";

            parameters["imagePath"] = "";

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

        }

    }
}
