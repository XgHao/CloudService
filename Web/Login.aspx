<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .tdborder{
            border-bottom: 1px solid #D04F44;
            border-bo
        }
        .auto-style1 {
            width: 90%;
            height: 100%;
        }
        .auto-style5 {
            width: 550px;
            height: 666px;
        }
        .auto-style10 {
            height: 666px;
        }
        .auto-style11 {
            width: 33%;
            background-color: #D04F44;
        }
        .auto-style12 {
        }
        .auto-style13 {
        }
        .auto-style14 {
            width: 11px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">
                    <asp:Image ID="Image3" runat="server" Height="750px" ImageUrl="~/images/bg/buttom.png" />
                </td>
                <td class="auto-style10">
                    <table cellpadding="2" cellspacing="8" class="auto-style11">
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Text="CVM评价系统"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label2" runat="server" Font-Size="XX-Small" ForeColor="#EAB0AC" Text="用户名(UserName)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style14">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/system/username.png" Width="25px" Height="25px"/>
                            </td>
                            <td class="auto-style12">
                                <asp:TextBox ID="TextBox_Name" runat="server" Height="26px" Font-Size="Large"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label3" runat="server" Font-Size="XX-Small" ForeColor="#EAB0AC" Text="密码(PassWord)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14" align="right">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/system/key.png" Width="25px" Height="25px"/>
                            </td>
                            <td class="auto-style12">
                                <asp:TextBox ID="TextBox_PW" runat="server" Height="26px" Font-Size="Large" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True" Font-Size="X-Small" ForeColor="#FFE033" RepeatDirection="Horizontal" Width="100%">
                                    <asp:ListItem Selected="True" Value="CsUser">用户</asp:ListItem>
                                    <asp:ListItem Value="Admin">管理员</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="Cook" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="White" Text="今天免登录" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13" align="right">
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageUrl="~/images/system/adduser.png" Width="25px" OnClick="ImageButton1_Click" />
                            </td>
                            <td class="auto-style13" align="right">
                                <asp:Button ID="Button_find" runat="server" align="left" BackColor="#D04F44" BorderStyle="None" Font-Bold="True" ForeColor="#66FFFF" Text="忘记密码" Height="16px" Width="65px" OnClick="Button_find_Click1" />
                                <asp:Button ID="Button_login" runat="server" Text="登录" BackColor="#FFE655" BorderStyle="None" Font-Bold="True" Font-Size="X-Large" ForeColor="White" OnClick="Button_login_Click" />
                            </td>                 
                        </tr>
                    </table>
                    </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
