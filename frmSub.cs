using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;


namespace thepos
{
    public partial class frmSub : Form
    {
        public struct OrderItem
        {
            public int lv_order_no;             // 
            public String lv_goods_name;        // 상품name or 전체할인명("할인")
            public String lv_cnt;
            public String lv_amt;
            public String lv_dc_amount;         // 실할인금액
            public String lv_net_amount;        // 결제금액

            public String option_name_description;          // render를 통한 옵션 표시
            public String option_amt_description;          // render를 통한 옵션 표시

            public String lv_memo;
        }
        public static List<OrderItem> mOrrdeItemList = new List<OrderItem>();


        public frmSub()
        {
            InitializeComponent();

            initialize_the();


            // 기본 대기화면
            if (mSubMonitorImage.Length > 0)
            {

                try
                {
                    byte[] imgBytes = Convert.FromBase64String(mSubMonitorImage);
                    MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                    ms.Write(imgBytes, 0, imgBytes.Length);
                    picLogo.Image = System.Drawing.Image.FromStream(ms, true);
                }
                catch
                {

                }
            }
            
        }



        private void initialize_the()
        {
            lvwOrderItem.HideSelection = true;

            mPanelOrderInfo = panelOrderInfo;
            mSublvwOrderItem = lvwOrderItem;


            mSublblOrderAmount = lblOrderAmount;
            mSublblOrderAmountDC = lblOrderAmountDC;
            mSublblOrderAmountNet = lblOrderAmountNet;
            mSublblOrderAmountReceive = lblOrderAmountReceive;
            mSublblOrderAmountRest = lblOrderAmountRest;



            this.lv_name.Renderer = rendererName();
            this.lv_amt.Renderer = rendererAmt();
            this.lv_dc_amount.Renderer = rendererDcAmount();
        }

        public DescribedTaskRenderer rendererName()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "option_name_description";

            renderer.TitleFont = new Font(lvwOrderItem.Font.FontFamily, 15, FontStyle.Bold);
            renderer.DescriptionFont = new Font(lvwOrderItem.Font.FontFamily, 10, FontStyle.Regular);
            renderer.DescriptionColor = Color.Blue;
            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = -5;
            renderer.UseGdiTextRendering = true;

            return (renderer);
        }

        public DescribedTaskRenderer rendererAmt()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "option_amt_description";

            renderer.TitleFont = new Font(lvwOrderItem.Font.FontFamily, 15, FontStyle.Bold);
            renderer.DescriptionFont = new Font(lvwOrderItem.Font.FontFamily, 10, FontStyle.Regular);
            renderer.DescriptionColor = Color.Blue;
            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = -5;
            renderer.UseGdiTextRendering = false;

            return (renderer);
        }

        public DescribedTaskRenderer rendererDcAmount()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "option_dc_amount_description";

            renderer.TitleFont = new Font(lvwOrderItem.Font.FontFamily, 15, FontStyle.Bold);
            renderer.DescriptionFont = new Font(lvwOrderItem.Font.FontFamily, 10, FontStyle.Regular);
            renderer.DescriptionColor = Color.Blue;
            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = -5;
            renderer.UseGdiTextRendering = false;


            return (renderer);
        }

        private void frmSub_FormClosed(object sender, FormClosedEventArgs e)
        {
            fSub = null;
        }
    }
}
