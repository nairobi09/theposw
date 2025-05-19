using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Presentation;
using static thepos.thePos;

namespace theposw._9SysAdmin
{
    public partial class frmSysAdminTree : Form
    {
        public frmSysAdminTree()
        {
            InitializeComponent();

            initialize_the();

            thepos_app_log(1, this.Name, "open", "");

        }


        private void initialize_the()
        {

            // siteId  - shopCode - pos    - goodsGroup - goods
            //                    - kiosk  - goodsGroup - goods
            //         - userId
            //         - goods
            //         - 
            tvwList.Nodes.Clear();

            // 0
            TreeNode nodeSite = new TreeNode();
            nodeSite.Text = mSiteAlias;
            nodeSite.Tag = "SITE";
            nodeSite.Expand();
            tvwList.Nodes.Add(nodeSite);


            //
            TreeNode nodeShop = new TreeNode();
            nodeShop.Text = "업장";
            nodeShop.Tag = "SHOP";
            nodeSite.Nodes.Add(nodeShop);

            //
            TreeNode nodeUser = new TreeNode();
            nodeUser.Text = "사용자";
            nodeUser.Tag = "USER";
            nodeSite.Nodes.Add(nodeUser);

            //
            TreeNode nodeGoods = new TreeNode();
            nodeGoods.Text = "상품";
            nodeGoods.Tag = "GOODS";
            nodeSite.Nodes.Add(nodeGoods);



            //
            for (int i = 0; i < mShop.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = mShop[i].shop_name;
                node.Tag = mShop[i].shop_code;
                nodeShop.Nodes.Add(node);
            }


            for (int i = 0; i < mPosNoList.Length; i++)
            {

            }




        }

        private void tvwList_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
