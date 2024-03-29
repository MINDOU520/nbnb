﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NBNB.Master" AutoEventWireup="true" CodeBehind="Zhanbao.aspx.cs" Inherits="Web.Zhanbao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="container">
        <div style="clear: both; margin-bottom: 30px; overflow: hidden;">
            <div style="width: 100%; margin-top: 15px; border-radius: 3px; padding-top: 10px; overflow: hidden;">                    
                <div style="float: left; position: relative; width:100%; border-bottom: 2px solid #e3e3e5; overflow: hidden; font-size: 15px; color: #555555; font-family: 'Microsoft YaHei';">
                    <div style=" float: left; width: 12%;overflow: hidden;" onclick="titleClick(1)">
                        <asp:HyperLink ID="kcLink" runat="server" CssClass="ch" Text="战报资讯" NavigateUrl="#" Font-Names="微软雅黑" Font-Size="16" Font-Underline="false"></asp:HyperLink>
                    </div>
                    <div style="position: absolute; right: 5px; bottom: 2px; font-size: 15px; color: #555555; font-family: 'Microsoft YaHei'; text-align: right;">
                        当前位置：
                        <asp:HyperLink ID="HyperLink1" runat="server" Text="首页/" NavigateUrl="~/WebForm1.aspx" Font-Underline="false" ForeColor="#555555"></asp:HyperLink>
                        <asp:Label ID="Label2" runat="server" Text="战报资讯" ForeColor="SteelBlue"></asp:Label>
                    </div>
                </div>
            </div>
            <div style="padding: 10px;">
                <asp:ListView ID="NewsListView" runat="server" >              
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server">
                            <div id="itemPlaceholder" runat="server"></div>
                        </div>
                        <div style="width: 100%; margin-top: 20px; text-align:center; background-color: #ececec;">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="8">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="true" FirstPageText="首页" NextPageText="下一页" PreviousPageText="上一页" LastPageText="尾页" />
                                    <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="current" />
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ShowNextPageButton="true" NextPageText="下一页" PreviousPageText="上一页"  ShowPreviousPageButton="false" FirstPageText="首页" LastPageText="尾页" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div style="font-family: 'Microsoft YaHei'; border-bottom: 1px dashed #e3e3e5; padding: 5px; overflow: hidden;">
                            <div style="float: left; padding: 5px; width: 80%;">
                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="微软雅黑" ToolTip='<%#"点击查看："+ Eval("z_title") %>' Font-Size="12" NavigateUrl='<%#"~/ZhanbaoDetail.aspx?id="+Eval("z_id") %>' ForeColor="#2b2b2b" Font-Underline="false" Text='<%#Eval("z_title") %>'></asp:HyperLink>
                            </div>
                            <div style="float: right; padding: 5px; width: 12%;">
                                <asp:Label ID="Label1" runat="server" Font-Names="微软雅黑" Font-Size="10" Text='<%#String.Format("{0:yyyy-MM-dd hh:mm}",Eval("z_time")) %>' ForeColor="gray"></asp:Label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
