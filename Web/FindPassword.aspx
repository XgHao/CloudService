<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindPassword.aspx.cs" Inherits="FindPW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
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
            width:100%;
        }
        .auto-style13 {
        }
        .auto-style14 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">
                    <asp:Image ID="Image7" runat="server" Height="750px" ImageUrl="~/images/bg/buttom.png" />
                </td>
                <td class="auto-style10">
                    <table cellpadding="2" cellspacing="8" class="auto-style11">
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Text="找回密码"></asp:Label>
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
                                <asp:TextBox ID="TextBox_Name" runat="server" Height="26px" Font-Size="Large" Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label3" runat="server" Font-Size="XX-Small" ForeColor="#EAB0AC" Text="新密码(PassWord)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14" align="right">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/system/key.png" Width="25px" Height="25px"/>
                            </td>
                            <td class="auto-style12">
                                <asp:TextBox ID="TextBox_PW" runat="server" Height="26px" Font-Size="Large" TextMode="Password" Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label5" runat="server" Font-Size="XX-Small" ForeColor="#EAB0AC" Text="确认新密码(RePassWord)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14" align="right">
                                <asp:Image ID="Image4" runat="server" ImageUrl="~/images/system/Rekey.png" Width="25px" Height="25px"/>
                            </td>
                            <td class="auto-style12">
                                <asp:TextBox ID="TextBox_RPW" runat="server" Height="26px" Font-Size="Large" TextMode="Password" Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                       <tr>
                            <td colspan="2" align="right">
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToCompare="TextBox_PW" ControlToValidate="TextBox_RPW" ForeColor="White">两次密码输入不同</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label4" runat="server" Font-Size="XX-Small" ForeColor="#EAB0AC" Text="验证密保问题(SecurityQuestion)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14" align="right" rowspan="2">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/system/Secure.png" Width="25px" Height="57px"/>
                            </td>
                            <td class="auto-style12">
                                <asp:DropDownList ID="DDL_Que" runat="server" ForeColor="#666666" Width="196px">
                                    <asp:ListItem Value="0">请选择密保问题</asp:ListItem>
                                    <asp:ListItem Value="我高中班主任的姓名是？">我高中班主任的姓名是？</asp:ListItem>
                                    <asp:ListItem Value="我最喜爱的老师的名字是？">我最喜爱的老师的名字是？</asp:ListItem>
                                    <asp:ListItem Value="我的初中班主任的名字是？">我的初中班主任的名字是？</asp:ListItem>
                                    <asp:ListItem Value="对我影响最大的人名字是？">对我影响最大的人名字是？</asp:ListItem>
                                    <asp:ListItem Value="我的出生地是？">我的出生地是？</asp:ListItem>
                                    <asp:ListItem Value="我母亲的生日是？">我母亲的生日是？</asp:ListItem>
                                    <asp:ListItem Value="我父亲的生日是？">我父亲的生日是？</asp:ListItem>
                                    <asp:ListItem Value="我母亲的姓名是？">我母亲的姓名是？</asp:ListItem>
                                    <asp:ListItem Value="我父亲的姓名是？">我父亲的姓名是？</asp:ListItem>
                                    <asp:ListItem Value="我配偶的生日是？">我配偶的生日是？</asp:ListItem>
                                    <asp:ListItem Value="我配偶的姓名是？">我配偶的姓名是？</asp:ListItem>
                                    <asp:ListItem Value="我最熟悉的童年好友是?">我最熟悉的童年好友是？</asp:ListItem>
                                    <asp:ListItem Value="我最熟悉的学校宿舍室友是？">我最熟悉的学校宿舍室友是？</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:TextBox ID="TextBox_Ans" runat="server" Width="99%" Height="26px" Font-Size="Larger" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Label ID="Label_Ser" runat="server" ForeColor="White" Text="密保信息错误" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13" align="right">
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageUrl="~/images/system/login.png" OnClick="ImageButton1_Click" Width="25px" />
                            </td>
                            <td class="auto-style13" align="right">
                                <asp:Button ID="Button_Reg" runat="server" Text="提交" BackColor="#FFE655" BorderStyle="None" Font-Bold="True" Font-Size="X-Large" ForeColor="White" OnClick="Button_Reg_Click" />
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
