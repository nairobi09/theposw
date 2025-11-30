using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

            TreeNode nodeShopTop = new TreeNode();
            nodeShopTop.Text = "상품 업장/분류";
            nodeShopTop.Tag = "TOP_SHOP";
            nodeSite.Nodes.Add(nodeShopTop);

            TreeNode nodeDivice = new TreeNode();
            nodeDivice.Text = "기기";
            nodeDivice.Tag = "TOP_DVCE";
            nodeSite.Nodes.Add(nodeDivice);

            TreeNode nodePosGroup = new TreeNode();
            nodePosGroup.Text = "포스";
            nodePosGroup.Tag = "TOP_PSGR";
            nodeSite.Nodes.Add(nodePosGroup);

            TreeNode nodeKioskGroup = new TreeNode();
            nodeKioskGroup.Text = "키오스크";
            nodeKioskGroup.Tag = "TOP_KSGP";
            nodeSite.Nodes.Add(nodeKioskGroup);



            TreeNode nodeOption = new TreeNode();
            nodeOption.Text = "옵션";
            nodeOption.Tag = "TOP_OPTN";
            nodeSite.Nodes.Add(nodeOption);

            TreeNode nodeDCR = new TreeNode();
            nodeDCR.Text = "할인";
            nodeDCR.Tag = "TOP_DCR_";
            nodeSite.Nodes.Add(nodeDCR);

            nodeSite.Expand();



            // 사용자
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
                        nodeUserList[k].ForeColor = Color.Gray;
                        nodeUser.Nodes.Add(nodeUserList[k]);
                    }
                    nodeUser.Expand();
                }
            }



            /*
            // 상품 업장/분류
            sUrl = "shop?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["shops"].ToString();
                    JArray arr = JArray.Parse(data);

                    shops = new shop[arr.Count];

                    for (int i = 0; i < arr.Count; i++) 
                    {
                        shops[i].shop_code = arr[i]["shopCode"].ToString();
                        shops[i].shop_name = arr[i]["shopName"].ToString();
                    }
                }
            }

            sUrl = "nod1?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["nod1s"].ToString();
                    JArray arr = JArray.Parse(data);

                    nod1s = new nod1[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        nod1s[i].shop_code = arr[i]["shopCode"].ToString();
                        nod1s[i].nod_code1 = arr[i]["nodCode1"].ToString();
                        nod1s[i].nod_name1 = arr[i]["nodName1"].ToString();
                    }
                }
            }

            sUrl = "nod2?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["nod2s"].ToString();
                    JArray arr = JArray.Parse(data);

                    nod2s = new nod2[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        nod2s[i].shop_code = arr[i]["shopCode"].ToString();
                        nod2s[i].nod_code1 = arr[i]["nodCode1"].ToString();
                        nod2s[i].nod_code2 = arr[i]["nodCode2"].ToString();
                        nod2s[i].nod_name2 = arr[i]["nodName2"].ToString();
                    }
                }
            }

            // goods
            sUrl = "goods?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(data);

                    goods = new good[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        goods[i].goods_code = arr[i]["goodsCode"].ToString();
                        goods[i].goods_name = arr[i]["goodsName"].ToString();
                        goods[i].shop_code = arr[i]["shopCode"].ToString();
                        goods[i].nod_code1 = arr[i]["nodCode1"].ToString();
                        goods[i].nod_code2 = arr[i]["nodCode2"].ToString();
                    }
                }
            }

            */




            //
            for (int shop_idx = 0; shop_idx < mShop.Length; shop_idx++)
            {
                TreeNode nodeShop = new TreeNode();
                nodeShop.Text = mShop[shop_idx].shop_name;
                nodeShop.Tag = "SHOP" + mShop[shop_idx].shop_code;
                nodeShop.ForeColor = Color.Red;
                nodeShopTop.Nodes.Add(nodeShop);

                for (int nod1_idx = 0; nod1_idx < mNod1.Length; nod1_idx++)
                {
                    if (mNod1[nod1_idx].shop_code == mShop[shop_idx].shop_code)
                    {
                        TreeNode nodeNod1 = new TreeNode();
                        nodeNod1.Text = mNod1[nod1_idx].nod_name1;
                        nodeNod1.Tag = "NOD1" + mNod1[nod1_idx].shop_code + mNod1[nod1_idx].nod_code1;
                        nodeNod1.ForeColor = Color.Blue;
                        nodeShop.Nodes.Add(nodeNod1);

                        for (int nod2_idx = 0; nod2_idx < mNod2.Length; nod2_idx++)
                        {
                            if (mNod2[nod2_idx].shop_code == mShop[shop_idx].shop_code & mNod2[nod2_idx].nod_code1 == mNod1[nod1_idx].nod_code1)
                            {
                                TreeNode nodeNod2 = new TreeNode();
                                nodeNod2.Text = mNod2[nod2_idx].nod_name2;
                                nodeNod2.Tag = "NOD2" + mNod2[nod2_idx].shop_code + mNod2[nod2_idx].nod_code1 + mNod2[nod2_idx].nod_code2;
                                nodeNod2.ForeColor = Color.Purple;
                                nodeNod1.Nodes.Add(nodeNod2);

                               // goods
                                for (int kk = 0; kk < mGoodsList.Count; kk++)
                                {
                                    if (mGoodsList[kk].shop_code == mNod2[nod2_idx].shop_code & mGoodsList[kk].nod_code1 == mNod2[nod2_idx].nod_code1 & mGoodsList[kk].nod_code2 == mNod2[nod2_idx].nod_code2)
                                    {
                                        TreeNode nodeGoods = new TreeNode();
                                        nodeGoods.Text = mGoodsList[kk].goods_name;
                                        nodeGoods.Tag = "GOOD" + mGoodsList[kk].goods_code;
                                        nodeGoods.ForeColor = Color.Gray;
                                        nodeNod2.Nodes.Add(nodeGoods);
                                    }
                                }
                            }
                        }

                        // goods
                        for (int kk = 0; kk < mGoodsList.Count; kk++)
                        {
                            if (mGoodsList[kk].shop_code == mNod1[nod1_idx].shop_code & mGoodsList[kk].nod_code1 == mNod1[nod1_idx].nod_code1 & mGoodsList[kk].nod_code2 == "")
                            {
                                TreeNode nodeGoods = new TreeNode();
                                nodeGoods.Text = mGoodsList[kk].goods_name;
                                nodeGoods.Tag = "GOOD" + mGoodsList[kk].goods_code;
                                nodeGoods.ForeColor = Color.Gray;
                                nodeNod1.Nodes.Add(nodeGoods);
                            }
                        }
                    }
                }

                // goods
                for (int kk = 0; kk < mGoodsList.Count; kk++)
                {
                    if (mGoodsList[kk].shop_code == mShop[shop_idx].shop_code & mGoodsList[kk].nod_code1 == "" & mGoodsList[kk].nod_code2 == "")
                    {
                        TreeNode nodeGoods = new TreeNode();
                        nodeGoods.Text = mGoodsList[kk].goods_name;
                        nodeGoods.Tag = "GOOD" + mGoodsList[kk].goods_code;
                        nodeGoods.ForeColor = Color.Gray;
                        nodeShop.Nodes.Add(nodeGoods);
                    }
                }

            }
            nodeShopTop.Expand();




            // 기기
            TreeNode nodeDivicePos = new TreeNode();
            nodeDivicePos.Text = "포스";
            nodeDivicePos.Tag = "DVCEPOS";
            nodeDivicePos.ForeColor = Color.Red;
            nodeDivice.Nodes.Add(nodeDivicePos);

            TreeNode nodeDiviceKiosk = new TreeNode();
            nodeDiviceKiosk.Text = "키오스크";
            nodeDiviceKiosk.Tag = "DVCEKIOSK";
            nodeDiviceKiosk.ForeColor = Color.Red;
            nodeDivice.Nodes.Add(nodeDiviceKiosk);

            TreeNode nodeDiviceTablet = new TreeNode();
            nodeDiviceTablet.Text = "테블릿";
            nodeDiviceTablet.Tag = "DVCETABLET";
            nodeDiviceTablet.ForeColor = Color.Red;
            nodeDivice.Nodes.Add(nodeDiviceTablet);

            TreeNode nodeDiviceMobile = new TreeNode();
            nodeDiviceMobile.Text = "모바일";
            nodeDiviceMobile.Tag = "DVCEMOBILE";
            nodeDiviceMobile.ForeColor = Color.Red;
            nodeDivice.Nodes.Add(nodeDiviceMobile);

            TreeNode nodeDiviceMobile2 = new TreeNode();
            nodeDiviceMobile2.Text = "모니터링";
            nodeDiviceMobile2.Tag = "DVCEMOBILE2";
            nodeDiviceMobile2.ForeColor = Color.Red;
            nodeDivice.Nodes.Add(nodeDiviceMobile2);


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

                        
                        if (nodePosList[i].Text.Substring(0,1) == "0") nodeDivicePos.Nodes.Add(nodePosList[i]);
                        else if (nodePosList[i].Text.Substring(0, 1) == "1") nodeDiviceKiosk.Nodes.Add(nodePosList[i]);
                        else if (nodePosList[i].Text.Substring(0, 1) == "2") nodeDiviceTablet.Nodes.Add(nodePosList[i]);
                        else if (nodePosList[i].Text.Substring(0, 1) == "3") nodeDiviceMobile.Nodes.Add(nodePosList[i]);
                        else if (nodePosList[i].Text.Substring(0, 1) == "4") nodeDiviceMobile2.Nodes.Add(nodePosList[i]);

                    }
                    nodeDivice.Expand();
                }
            }




            // 포스그룹
            TreeNode[] nodePosGoodsGroup = new TreeNode[mPosGroupCodeList.Count];


            for (int i = 1; i < mPosGroupCodeList.Count; i++)
            {
                nodePosGoodsGroup[i] = new TreeNode();
                nodePosGoodsGroup[i].Text = mPosGroupNameList[i];
                nodePosGoodsGroup[i].Tag = "PGSQ" + mPosGroupNameList[i];
                nodePosGoodsGroup[i].ForeColor = Color.Red;
                nodePosGroup.Nodes.Add(nodePosGoodsGroup[i]);

                // 상품그룹(순차)
                sUrl = "posGoodsGroupSeq?siteId=" + mSiteId + "&shopCode=" + mPosGroupCodeList[i];

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
                            nodeGoodsGroupList[k].Tag = "GDGR" + mPosGroupCodeList[i] + arr1[k]["groupCode"].ToString();
                            nodeGoodsGroupList[k].ForeColor = Color.Blue;
                            nodePosGoodsGroup[i].Nodes.Add(nodeGoodsGroupList[k]);

                            // 
                            sUrl = "posGoodsItemSeq?siteId=" + mSiteId + "&shopCode=" + mPosGroupCodeList[i] + "&groupCode=" + arr1[k]["groupCode"].ToString();
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
                                        nodeGoodsItemList[x].Text = get_goods_name(arr2[x]["goodsCode"].ToString());
                                        nodeGoodsItemList[x].Tag = "GDTM" + mPosGroupCodeList[i] + arr1[k]["groupCode"].ToString() + arr2[x]["goodsCode"].ToString();
                                        nodeGoodsItemList[x].ForeColor = Color.Gray;
                                        nodeGoodsGroupList[k].Nodes.Add(nodeGoodsItemList[x]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            nodePosGroup.Expand();



            //
            TreeNode[] optionTemplateList = new TreeNode[mOptionTemplate.Length];

            for (int i = 0; i < mOptionTemplate.Length; i++)
            {
                optionTemplateList[i] = new TreeNode();
                optionTemplateList[i].Text = mOptionTemplate[i].option_template_name;
                optionTemplateList[i].Tag = "OPTN" + mOptionTemplate[i].option_template_id;
                optionTemplateList[i].ForeColor = Color.Red;
                nodeOption.Nodes.Add(optionTemplateList[i]);
            }
                        

            //
            TreeNode[] nodeTempOptionList = new TreeNode[mTempOption.Length];

            for (int k = 0; k < mTempOption.Length; k++)
            {
                for (int i = 0; i < mOptionTemplate.Length; i++)
                {
                    if (mOptionTemplate[i].option_template_id == mTempOption[k].option_template_id)
                    {
                        nodeTempOptionList[k] = new TreeNode();
                        nodeTempOptionList[k].Text = mTempOption[k].option_name;
                        nodeTempOptionList[k].Tag = "TOPT" + mTempOption[k].option_template_id + mTempOption[k].option_id;
                        nodeTempOptionList[k].ForeColor = Color.Blue;
                        optionTemplateList[i].Nodes.Add(nodeTempOptionList[k]);
                    }
                }

            }

            //
            TreeNode[] nodeTempOptionItemList = new TreeNode[mTempOptionItem.Length];

            for (int x = 0; x < mTempOptionItem.Length; x++)
            {

                for (int k = 0; k < mTempOption.Length; k++)
                {
                    if (mTempOption[k].option_template_id == mTempOptionItem[x].option_template_id & mTempOption[k].option_id == mTempOptionItem[x].option_id)
                    {
                        nodeTempOptionItemList[x] = new TreeNode();
                        nodeTempOptionItemList[x].Text = mTempOptionItem[x].option_item_name;
                        nodeTempOptionItemList[x].Tag = "TOTM" + mTempOptionItem[x].option_template_id + mTempOptionItem[x].option_id + mTempOptionItem[x].option_item_id;
                        nodeTempOptionItemList[x].ForeColor = Color.Gray;
                        nodeTempOptionList[k].Nodes.Add(nodeTempOptionItemList[x]);
                    }
                }
            }



            nodeOption.Expand();



            //
            for (int shop_idx = 0; shop_idx < mShop.Length; shop_idx++)
            {
                TreeNode nodeShop = new TreeNode();
                nodeShop.Text = mShop[shop_idx].shop_name;
                nodeShop.Tag = "SHOP" + mShop[shop_idx].shop_code;
                nodeShop.ForeColor = Color.Red;
                nodeDCR.Nodes.Add(nodeShop);

                sUrl = "dcrFavorite?siteId=" + mSiteId + "&shopCode=" + mShop[shop_idx].shop_code;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["dcr"].ToString();
                        JArray arr = JArray.Parse(data);

                        TreeNode[] dcrList = new TreeNode[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            dcrList[i] = new TreeNode();
                            dcrList[i].Text = arr[i]["dcrName"].ToString();
                            dcrList[i].Tag = "DCR_" + arr[i]["dcrCode"].ToString();
                            dcrList[i].ForeColor = Color.Gray;
                            nodeShop.Nodes.Add(dcrList[i]);
                        }
                        nodeDCR.Expand();
                    }
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
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "NOD1")
            {
                String sUrl = "nod1?siteId=" + mSiteId + "&shopCode=" + selectedNode.Tag.ToString().Substring(4, 2) + "&nodCode1=" + selectedNode.Tag.ToString().Substring(6, 2);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["nod1s"].ToString();
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
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "NOD2")
            {
                String sUrl = "nod2?siteId=" + mSiteId + "&shopCode=" + selectedNode.Tag.ToString().Substring(4, 2) + "&nodCode1=" + selectedNode.Tag.ToString().Substring(6, 2) + "&nodCode2=" + selectedNode.Tag.ToString().Substring(8, 2);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["nod2s"].ToString();
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
                String sUrl = "pos?siteId=" + mSiteId + "&posNo=" + selectedNode.Tag.ToString().Substring(4, 2);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["pos"].ToString();
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

                // 빈줄
                ListViewItem lvItem0 = new ListViewItem();
                lvItem0.Text = " ";
                lvItem0.SubItems.Add(" ");
                lvwList.Items.Add(lvItem0);


                sUrl = "setupPos?siteId=" + mSiteId + "&posNo=" + selectedNode.Tag.ToString().Substring(4, 2);
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
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "GDGR")
            {
                String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + selectedNode.Tag.ToString().Substring(4, 2) + "&groupCode=" + selectedNode.Tag.ToString().Substring(6, 3);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["goodsGroups"].ToString();
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
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "GDTM")
            {
                String sUrl = "goodsItem?siteId=" + mSiteId + "&posNo=" + selectedNode.Tag.ToString().Substring(4, 2) + "&goodsGroup=" + selectedNode.Tag.ToString().Substring(6, 3) + "&goodsCode=" + selectedNode.Tag.ToString().Substring(9, 6);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["goodsItems"].ToString();
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
            else if (selectedNode.Tag.ToString().Substring(0, 4) == "DCR_")
            {
                String sUrl = "dcrFavorite?siteId=" + mSiteId + "&dcrCode=" + selectedNode.Tag.ToString().Substring(4, 4);
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["dcr"].ToString();
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
