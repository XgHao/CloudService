<%@ Page Title="" Language="C#" MasterPageFile="~/CsUser/common.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" Runat="Server">
    <table class="auto-style3">
        <tr>
            <td style="width: 40px" rowspan="2" class="auto-style4">
                <asp:ImageButton ID="Head" runat="server" Height="45px" ImageUrl="~/images/system/adduser.png" Width="45px" />
            </td>
            <td style="height: 19px; " colspan="6" align="left">
                <asp:Label ID="Label_Time" runat="server" Text="Label" Font-Bold="True" ForeColor="#C84220" Font-Size="Larger"></asp:Label>
                <asp:Label ID="Label_Name" runat="server" Text="Label_ID" Font-Bold="True" ForeColor="#C84220" Font-Size="Larger"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 19px; width: 229px" align="left">
                <asp:Button ID="Button_Info" runat="server" BackColor="White" BorderStyle="None" ForeColor="#70B6BD" Text="[个人信息]" OnClick="Button_Info_Click" />
                <asp:Button ID="Button_Logout" runat="server" Text="[退出]" BackColor="White" BorderStyle="None" ForeColor="#70B6BD" OnClick="Button_Logout_Click" />
            </td>
            <td style="font-weight: 700; height: 19px; width: 80px">
                &nbsp;</td>
            <td style="font-weight: 700; height: 19px; width: 94px">&nbsp;</td>
            <td style="font-weight: 700; height: 19px; width: 76px;" align="left">
                &nbsp;</td>
            <td style="font-weight: 700; height: 19px; width: 94px" align="left" >
                &nbsp;</td>
            <td style="font-weight: 700; height: 19px" align="left">
                &nbsp;</td>
        </tr>
    </table>
    <table class="auto-style3">
        <tr>
            <td align="left" style="width: 55px; " rowspan="2">
                <asp:Label ID="Label1" runat="server" Text="公告" Font-Bold="True" Font-Size="XX-Large" ForeColor="#D04F44"></asp:Label>
            </td>
            <td colspan="3" style="height: 13px" align="right">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 10px" align="right">
                <asp:Label ID="Label20" runat="server" Text="MORE+" Font-Bold="True" ForeColor="#6EC6CE"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Image ID="Image2" runat="server" Height="9px" ImageUrl="~/images/bg/log.png" Width="100%" />
            </td>
        </tr>
        <tr>
            <td rowspan="6" style="width: 350px" align="left">
                <asp:Image ID="Image1" runat="server" Height="300px" ImageUrl="~/images/bg/top.png" />
            </td>
            <td align="left">
                <asp:Label ID="Label2" runat="server" Text="云服务器评价平台 今天正式开放 欢迎各位" Font-Bold="True" Font-Size="Large" ForeColor="#32636B"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="2018-07-09" Font-Bold="True" ForeColor="#6EC6CE"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label14" runat="server" Text="阅读(201)" ForeColor="#C38929"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 700px">
                <asp:Label ID="Label4" runat="server" Text="云服务器评价平台 今天正式开放 欢迎各位云服务器评价平台 今天正式开放 欢迎各位" Font-Bold="True" Font-Size="Large" ForeColor="#32636B"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" Text="2018-07-09" Font-Bold="True" ForeColor="#6EC6CE"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label15" runat="server" Text="阅读(201)" ForeColor="#C38929"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label5" runat="server" Text="云服务器评价平台 今天正式开" Font-Bold="True" Font-Size="Large" ForeColor="#32636B"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="2018-07-09" Font-Bold="True" ForeColor="#6EC6CE"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label16" runat="server" Text="阅读(201)" ForeColor="#C38929"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label6" runat="server" Text="云服务器评价平台 今天正式开放 欢迎各位云服务器评价平台 今天正" Font-Bold="True" Font-Size="Large" ForeColor="#32636B"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text="2018-07-09" Font-Bold="True" ForeColor="#6EC6CE"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label17" runat="server" Text="阅读(201)" ForeColor="#C38929"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label7" runat="server" Text="云服务器评" Font-Bold="True" Font-Size="Large" ForeColor="#32636B"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" Text="2018-07-09" Font-Bold="True" ForeColor="#6EC6CE"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label18" runat="server" Text="阅读(201)" ForeColor="#C38929"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label8" runat="server" Text="云服务器评价平" Font-Bold="True" Font-Size="Large" ForeColor="#32636B"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label13" runat="server" Text="2018-07-09" Font-Bold="True" ForeColor="#6EC6CE"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label19" runat="server" Text="阅读(201)" ForeColor="#C38929"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

