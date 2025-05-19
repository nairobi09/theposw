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
using DocumentFormat.OpenXml.Presentation;
using Newtonsoft.Json.Linq;
using static thepos.thePos;

namespace theposw._9SysAdmin
{
    public partial class frmSysAdminTree : Form
    {
        public frmSysAdminTree()
        {
            InitializeComponent();

            thepos_app_log(1, this.Name, "open", "");
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            get_tree_data();
        }


        private void get_tree_data()
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
            tvwList.Nodes.Add(nodeSite);

            //
            TreeNode nodeUser = new TreeNode();
            nodeUser.Text = "사용자";
            nodeUser.Tag = "TOPUSER";
            nodeSite.Nodes.Add(nodeUser);

            TreeNode nodeShop = new TreeNode();
            nodeShop.Text = "업장";
            nodeShop.Tag = "TOPSHOP";
            nodeSite.Nodes.Add(nodeShop);

            TreeNode nodePos = new TreeNode();
            nodePos.Text = "포스";
            nodePos.Tag = "TOPPOS_";
            nodeSite.Nodes.Add(nodePos);

            nodeSite.Expand();


            //
            String sUrl = "user?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["users"].ToString();
                    JArray arr = JArray.Parse(pos);

                    TreeNode[] nodeUserList = new TreeNode[arr.Count];

                    for (int k = 0; k < arr.Count; k++)
                    {
                        nodeUserList[k] = new TreeNode();
                        nodeUserList[k].Text = "[" + arr[k]["userId"].ToString() + "] " + arr[k]["userName"].ToString();
                        nodeUserList[k].Tag = "USER" + arr[k]["userId"].ToString();
                        nodeUser.Nodes.Add(nodeUserList[k]);
                    }
                    nodeUser.Expand();
                }
            }


            //
            sUrl = "shop?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["shops"].ToString();
                    JArray arr = JArray.Parse(data);

                    TreeNode[] nodeShopList = new TreeNode[arr.Count];

                    for (int i = 1; i < arr.Count; i++)
                    {
                        nodeShopList[i] = new TreeNode();
                        nodeShopList[i].Text = arr[i]["shopName"].ToString();
                        nodeShopList[i].Tag = "SHOP" + arr[i]["shopCode"].ToString();
                        nodeShop.Nodes.Add(nodeShopList[i]);


                        sUrl = "goods?siteId=" + mSiteId + "&shopCode=" + arr[i]["shopCode"].ToString();
                        if (mRequestGet(sUrl))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                String pos = mObj["goods"].ToString();
                                JArray arr1 = JArray.Parse(pos);

                        
                                TreeNode[] nodeGoodsList = new TreeNode[arr1.Count];

                                for (int k = 0; k < arr1.Count; k++)
                                {
                                    nodeGoodsList[k] = new TreeNode();
                                    nodeGoodsList[k].Text = arr1[k]["goodsName"].ToString();
                                    nodeGoodsList[k].Tag = "GOOD" + arr1[k]["goodsCode"].ToString();
                                    nodeShopList[i].Nodes.Add(nodeGoodsList[k]);
                                }
                            }
                        }
                        nodeShop.Expand();
                    }
                }
            }



            //
            sUrl = "pos?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["pos"].ToString();
                    JArray arr = JArray.Parse(pos);

                    TreeNode[] nodePosList = new TreeNode[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        nodePosList[i] = new TreeNode();
                        nodePosList[i].Text = arr[i]["posNo"].ToString();
                        nodePosList[i].Tag = "POS_" + arr[i]["posNo"].ToString();
                        nodePos.Nodes.Add(nodePosList[i]);

                        // 상품그룹
                        sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + arr[i]["posNo"].ToString();
                        if (mRequestGet(sUrl))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                String goods_group = mObj["goodsGroups"].ToString();
                                JArray arr1 = JArray.Parse(goods_group);

                                TreeNode[] nodeGoodsGroupList = new TreeNode[arr1.Count];

                                for (int k = 0; k < arr1.Count; k++)
                                {
                                    nodeGoodsGroupList[k] = new TreeNode();
                                    nodeGoodsGroupList[k].Text = arr1[k]["groupName"].ToString();
                                    nodeGoodsGroupList[k].Tag = "GRUP" + arr1[k]["groupCode"].ToString();
                                    nodePosList[i].Nodes.Add(nodeGoodsGroupList[k]);

                                    // 상품
                                    sUrl = "goodsItemAndGoods?siteId=" + mSiteId + "&posNo=" + arr[i]["posNo"].ToString() + "&groupCode=" + arr1[k]["groupCode"].ToString();
                                    if (mRequestGet(sUrl))
                                    {
                                        if (mObj["resultCode"].ToString() == "200")
                                        {
                                            String goodsItems = mObj["goodsItems"].ToString();
                                            JArray arr2 = JArray.Parse(goodsItems);

                                            TreeNode[] nodeGoodsItemList = new TreeNode[arr2.Count];

                                            for (int x = 0; x < arr2.Count; x++)
                                            {
                                                nodeGoodsItemList[x] = new TreeNode();
                                                nodeGoodsItemList[x].Text = arr2[x]["goodsName"].ToString();
                                                nodeGoodsItemList[x].Tag = "GOOD" + arr2[x]["goodsCode"].ToString();
                                                nodeGoodsGroupList[k].Nodes.Add(nodeGoodsItemList[x]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    nodePos.Expand();
                }

            }


        }



        private void tvwList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvwList.Items.Clear();


            //
            TreeNode selectedNode = e.Node;



            if (selectedNode.Tag.ToString().Substring(0, 3) == "TOP")
            {
                //
            }

            else if (selectedNode.Tag.ToString().Substring(0, 4) == "SITE")
            {
                
            }
            else if (selectedNode.Tag.ToString().Substring(0,4) == "USER")
            {

            }
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "SHOP")
            {

            }
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "POS_")
            {

            }
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "GOOD")
            {

            }


        }

    }
}
