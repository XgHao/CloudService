<%@ Page Language="C#" MasterPageFile="~/CsUser/common.master" AutoEventWireup="true" CodeFile="ChangeInfo.aspx.cs" Inherits="ChangeInfo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" Runat="Server">

    <table cellpadding="2" cellspacing="8" style="width: 33%; background-color: #D04F44;">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Text="修改个人信息"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" rowspan="3">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" ImageUrl="~/images/head/0.png" Width="100px" />
            </td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="height: 10px" align="left">
                <asp:Label ID="Label2" runat="server" Font-Size="13px" ForeColor="#EAB0AC" Text="用户名(UserName)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:TextBox ID="TextBox_Name" runat="server" Font-Size="Large" Height="26px" Width="99%" BackColor="#D04F44" BorderStyle="None" Font-Bold="True" ForeColor="#B6CFE0" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <asp:Label ID="Label3" runat="server" Font-Size="13px" ForeColor="#EAB0AC" Text="新密码(NewPassWord)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14" colspan="2">
                <asp:TextBox ID="TextBox_PW" runat="server" Font-Size="Large" Height="26px" Width="99%" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <asp:Label ID="Label4" runat="server" Font-Size="13px" ForeColor="#EAB0AC" Text="设置的密保问题(SecurityQuestion)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14" colspan="2">
                <asp:DropDownList ID="DDL_Que" runat="server" ForeColor="#666666" Width="99%">
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
            <td align="right" class="auto-style14" colspan="2">
                <asp:TextBox ID="TextBox_Ans" runat="server" Font-Size="Larger" Height="26px" Width="99%" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <asp:Label ID="Label6" runat="server" Font-Size="13px" ForeColor="#EAB0AC" Text="说点什么吧(IntroduceYouself)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14" colspan="2">
                <asp:TextBox ID="TextBox_Remark" runat="server" Font-Size="Larger" Height="26px" Width="99%" BackColor="#D04F44" BorderStyle="None" Font-Bold="True" ForeColor="#B6CFE0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="Button_Chan" runat="server" Text="修改信息" BackColor="#534378" BorderStyle="None" Font-Bold="True" Font-Size="Medium" ForeColor="White" Width="90px" OnClick="Button_Chan_Click" />
                </td>
        </tr>
        </table>

</asp:Content>

