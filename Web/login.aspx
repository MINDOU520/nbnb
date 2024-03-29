﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NBNB.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="loginbg img-responsive">
            <div class="loginbd">     
                <br />             
                <h2>用户登录</h2>     
                <table style="margin:auto;text-align:center;">     
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>           
                    <tr>
                        <td style="text-align:right"><strong>用户名：</strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control;" placeholder="请输入用户名"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right"><strong>密&nbsp;&nbsp;&nbsp;&nbsp;码：</strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control;" placeholder="请输入密码"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="*" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right"><strong>验证码：</strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCheckcode" runat="server" CssClass="form-control;" placeholder="请输入验证码"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="equiredFieldValidator1" runat="server" ControlToValidate="txtCheckcode" Display="Dynamic" ErrorMessage="*" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <img id="imgCode" alt="看不清，请点击我！" onclick="this.src=this.src+'?'" src="CheckCode.aspx"/>看不清？请点击我
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:CheckBox ID="save" runat="server" Text="记住密码" />
                            &nbsp <a href="findPassword.aspx" style="color:#808080;text-decoration:underline">忘记密码？</a>
                        </td>
                    </tr>                                   
                </table>
                <br />                
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登录" CssClass="btn btn-primary btn-lg" />
                <br />
                <br />
                <asp:Label ID="label1" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <p>还不是NBNB用户？<a href="Register.aspx">免费注册</a></p>
            </div>
        </div>
    </div>
</asp:Content>
