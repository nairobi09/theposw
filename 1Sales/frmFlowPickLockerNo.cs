using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.frmSales;
using static thepos.thePos;

namespace theposw._1Sales
{
    public partial class frmFlowPickLockerNo : Form
    {

        private List<MemOrderItem> orderItemList;
        public List<String> LockerNoList = new List<String>();


        Label[] lblGoodsName = new Label[10];
        TextBox[] tbLockerNo = new TextBox[10];

        int locker_cnt = 0;


        public frmFlowPickLockerNo(List<MemOrderItem> orderItemList)
        {
            InitializeComponent();

            lblGoodsName[0] = lblGoodsName00;
            lblGoodsName[1] = lblGoodsName01;
            lblGoodsName[2] = lblGoodsName02;
            lblGoodsName[3] = lblGoodsName03;
            lblGoodsName[4] = lblGoodsName04;
            lblGoodsName[5] = lblGoodsName05;
            lblGoodsName[6] = lblGoodsName06;
            lblGoodsName[7] = lblGoodsName07;
            lblGoodsName[8] = lblGoodsName08;
            lblGoodsName[9] = lblGoodsName09;

            tbLockerNo[0] = tbLockerNo00;
            tbLockerNo[1] = tbLockerNo01;
            tbLockerNo[2] = tbLockerNo02;
            tbLockerNo[3] = tbLockerNo03;
            tbLockerNo[4] = tbLockerNo04;
            tbLockerNo[5] = tbLockerNo05;
            tbLockerNo[6] = tbLockerNo06;
            tbLockerNo[7] = tbLockerNo07;
            tbLockerNo[8] = tbLockerNo08;
            tbLockerNo[9] = tbLockerNo09;


            this.orderItemList = orderItemList;


            for (int i = 0; i < orderItemList.Count; i++)
            {
                locker_cnt += orderItemList[i].cnt;
            }



            for (int i = 0; i < locker_cnt; i++)
            {
                lblGoodsName[i].Visible = true;
                tbLockerNo[i].Visible = true;
            }

            int locker_idx = 0;

            for (int i = 0; i < orderItemList.Count; i++)
            {
                for (int k = 0; k < orderItemList[i].cnt; k++)
                {
                    lblGoodsName[locker_idx].Text = orderItemList[i].goods_name;
                    locker_idx++;
                }
            }

        }


        private void btnOK_Click(object sender, EventArgs e)
        {

            LockerNoList.Clear();

            for (int i = 0; i < locker_cnt; i++)
            {
                if (tbLockerNo[i].Text.Length != 4)
                {
                    MessageBox.Show("락커번호 오류.", "thepos");
                    return;
                }
            }




            for (int i = 0; i < locker_cnt; i++)
            {
                if (!check_locker_no_ready(tbLockerNo[i].Text))
                {
                    return;
                }
            }


            for (int i = 0; i < locker_cnt; i++)
            {
                LockerNoList.Add(tbLockerNo[i].Text);
            }



            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private bool check_locker_no_ready(string no)
        {
            String sUrl = "locker?siteId=" + mSiteId + "&lockerNo=" + no;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["lockers"].ToString();
                    JArray arr = JArray.Parse(data);


                    if (arr.Count == 1)
                    {
                        String flow_step = arr[0]["flowStep"].ToString();

                        if (flow_step == "")
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("락커 이미 사용중. \n\n 락커번호=" + no, "thepos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("락커데이터 오류. \n\n 락커번호=" + no, "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("데이터 오류. locker\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("데이터 오류. locker", "thepos");
            }

            return false;
        }

    }
}
