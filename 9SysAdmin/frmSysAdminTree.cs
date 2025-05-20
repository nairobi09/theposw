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
using DocumentFormat.OpenXml.Office2019.Excel.RichData2;
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
            nodeUser.Tag = "TOP_USER";
            nodeSite.Nodes.Add(nodeUser);

            TreeNode nodeShop = new TreeNode();
            nodeShop.Text = "업장";
            nodeShop.Tag = "TOP_SHOP";
            nodeSite.Nodes.Add(nodeShop);

            TreeNode nodePos = new TreeNode();
            nodePos.Text = "포스";
            nodePos.Tag = "TOP_POS_";
            nodeSite.Nodes.Add(nodePos);

            TreeNode nodeOption = new TreeNode();
            nodeOption.Text = "옵션템플릿";
            nodeOption.Tag = "TOP_OPTN";
            nodeSite.Nodes.Add(nodeOption);

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
                        nodeUserList[k].Text = arr[k]["userName"].ToString();
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

                                    // 
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


            //
            sUrl = "optionTemplate?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["optionTemp"].ToString();
                    JArray arr = JArray.Parse(data);

                    TreeNode[] optionTemplateList = new TreeNode[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        optionTemplateList[i] = new TreeNode();
                        optionTemplateList[i].Text = arr[i]["optionTemplateName"].ToString();
                        optionTemplateList[i].Tag = "OPTN" + arr[i]["optionTemplateId"].ToString();
                        nodeOption.Nodes.Add(optionTemplateList[i]);

                        // 
                        sUrl = "tempOption?siteId=" + mSiteId + "&optionTemplateId=" + arr[i]["optionTemplateId"].ToString();
                        if (mRequestGet(sUrl))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                data = mObj["tempOption"].ToString();
                                JArray arr1 = JArray.Parse(data);

                                TreeNode[] nodeTempOptionList = new TreeNode[arr1.Count];

                                for (int k = 0; k < arr1.Count; k++)
                                {
                                    nodeTempOptionList[k] = new TreeNode();
                                    nodeTempOptionList[k].Text = arr1[k]["optionId"].ToString() + " " + arr1[k]["optionName"].ToString();
                                    nodeTempOptionList[k].Tag = "TOPT" + arr[i]["optionTemplateId"].ToString() + arr1[k]["optionId"].ToString();
                                    optionTemplateList[i].Nodes.Add(nodeTempOptionList[k]);

                                    // 상품
                                    sUrl = "tempOptionItem?siteId=" + mSiteId + "&optionTemplateId=" + arr[i]["optionTemplateId"].ToString() + "&optionId=" + arr1[k]["optionId"].ToString();
                                    if (mRequestGet(sUrl))
                                    {
                                        if (mObj["resultCode"].ToString() == "200")
                                        {
                                            data = mObj["optionItem"].ToString();
                                            JArray arr2 = JArray.Parse(data);

                                            TreeNode[] nodeTempOptionItemList = new TreeNode[arr2.Count];

                                            for (int x = 0; x < arr2.Count; x++)
                                            {
                                                nodeTempOptionItemList[x] = new TreeNode();
                                                nodeTempOptionItemList[x].Text = arr2[x]["optionItemId"].ToString() + " " + arr2[x]["optionItemName"].ToString();
                                                nodeTempOptionItemList[x].Tag = "TOTM" + arr[i]["optionTemplateId"].ToString() + arr1[k]["optionId"].ToString() + arr2[x]["optionItemId"].ToString();
                                                nodeTempOptionList[k].Nodes.Add(nodeTempOptionItemList[x]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    nodeOption.Expand();
                }

            }
        }



        private void tvwList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvwList.Items.Clear();

            TreeNode selectedNode = e.Node;

            if (selectedNode.Tag.ToString().Substring(0, 4) == "TOP_")
            {
                //
            }
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "SITE")
            {
                String sUrl = "site?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["sites"].ToString();
                        JArray arr = JArray.Parse(data);

                        foreach (JObject item in arr)
                        {
                            foreach (var property in item.Properties())
                            {
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Text = property.Name;
                                lvItem.SubItems.Add(property.Value.ToString());
                                lvwList.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "USER")
            {
                String sUrl = "user?siteId=" + mSiteId + "&userId=" + selectedNode.Tag.ToString().Substring(4, 4);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["users"].ToString();
                        JArray arr = JArray.Parse(data);

                        foreach (JObject item in arr)
                        {
                            foreach (var property in item.Properties())
                            {
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Text = property.Name;
                                lvItem.SubItems.Add(property.Value.ToString());
                                lvwList.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "SHOP")
            {
                String sUrl = "shop?siteId=" + mSiteId + "&shopCode=" + selectedNode.Tag.ToString().Substring(4, 2);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["shops"].ToString();
                        JArray arr = JArray.Parse(data);

                        foreach (JObject item in arr)
                        {
                            foreach (var property in item.Properties())
                            {
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Text = property.Name;
                                lvItem.SubItems.Add(property.Value.ToString());
                                lvwList.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "POS_")
            {
                String sUrl = "setupPos?siteId=" + mSiteId + "&posNo=" + selectedNode.Tag.ToString().Substring(4, 2);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["setupPos"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Text = arr[i]["setupCode"].ToString();
                            lvItem.SubItems.Add(arr[i]["setupValue"].ToString());
                            lvwList.Items.Add(lvItem);
                        }
                    }
                }
            }
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "GOOD")
            {
                String sUrl = "goods?siteId=" + mSiteId + "&goodsCode=" + selectedNode.Tag.ToString().Substring(4, 6);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["goods"].ToString();
                        JArray arr = JArray.Parse(data);

                        foreach (JObject item in arr)
                        {
                            foreach (var property in item.Properties())
                            {
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Text = property.Name;
                                lvItem.SubItems.Add(property.Value.ToString());
                                lvwList.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "OPTN")
            {
                String sUrl = "optionTemplate?siteId=" + mSiteId + "&optionTemplateId=" + selectedNode.Tag.ToString().Substring(4, 4);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["optionTemp"].ToString();
                        JArray arr = JArray.Parse(data);

                        foreach (JObject item in arr)
                        {
                            foreach (var property in item.Properties())
                            {
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Text = property.Name;
                                lvItem.SubItems.Add(property.Value.ToString());
                                lvwList.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "TOPT")
            {
                String sUrl = "tempOption?siteId=" + mSiteId + "&optionTemplateId=" + selectedNode.Tag.ToString().Substring(4, 4) + "&optionId=" + selectedNode.Tag.ToString().Substring(8, 2);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["tempOption"].ToString();
                        JArray arr = JArray.Parse(data);

                        foreach (JObject item in arr)
                        {
                            foreach (var property in item.Properties())
                            {
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Text = property.Name;
                                lvItem.SubItems.Add(property.Value.ToString());
                                lvwList.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "TOTM")
            {
                String sUrl = "tempOptionItem?siteId=" + mSiteId + "&optionTemplateId=" + selectedNode.Tag.ToString().Substring(4, 4) + "&optionId=" + selectedNode.Tag.ToString().Substring(8, 2) + "&optionItemId=" + selectedNode.Tag.ToString().Substring(10, 2);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["optionItem"].ToString();
                        JArray arr = JArray.Parse(data);

                        foreach (JObject item in arr)
                        {
                            foreach (var property in item.Properties())
                            {
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Text = property.Name;
                                lvItem.SubItems.Add(property.Value.ToString());
                                lvwList.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }
        }

    }
}
