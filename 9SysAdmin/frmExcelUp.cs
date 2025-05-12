using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace theposw._9SysAdmin
{
    public partial class frmExcelUp : Form
    {
        public frmExcelUp()
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

        private void btnUpload_Click(object sender, EventArgs e)
        {

            var dataList = new List<Dictionary<string, string>>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var rowData = new Dictionary<string, string>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string columnName = dataGridView1.Columns[cell.ColumnIndex].HeaderText;
                        string value = cell.Value?.ToString() ?? string.Empty;
                        rowData[columnName] = value;
                    }
                    dataList.Add(rowData);
                }
            }
        }
    }
}
