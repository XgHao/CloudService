<%@ Page Language="C#" MasterPageFile="~/CsUser/common.master" AutoEventWireup="true" CodeFile="UserFavorite.aspx.cs" Inherits="UserFavorite" Title="Untitled Page" %>
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
            <td style="font-weight: 700; height: 19px; width: 100px;" align="right">
                &nbsp;</td>
            <td style="font-weight: 700; height: 19px; width: 94px" align="left" >
                &nbsp;</td>
            <td style="font-weight: 700; height: 19px" align="left">
                &nbsp;</td>
        </tr>
    </table>
    <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#E7E7FF"
        BorderWidth="3px" CellPadding="3" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" RepeatColumns="7" RepeatDirection="Horizontal" DataKeyField="CloudServiceID" OnItemCommand="DataList1_ItemCommand" Width="150px" BorderStyle="None" GridLines="Horizontal">
        <AlternatingItemStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <SelectedItemStyle BackColor="#738A9C" ForeColor="#F7F7F7" Font-Bold="True" />
        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <ItemTemplate>
            <table style="width: 200px; height: 144px">
                <tr>
                    <td style="width: 207px; height: 9px;" align="center">
                        <asp:ImageButton ID="ImageButton_logo" runat="server" Width="188px" Height="83px" ImageUrl='<%# Eval("Logo") %>' CommandArgument='<%#Eval("CloudServiceID") %>' CommandName="Edit" /></td>
                </tr>
                <tr>
                    <td style="width: 207px; height: 16px;" align="center">
                        <asp:Label ID="Label_csname" runat="server" Text='<%# Eval("CloudServiceName") %>' Width="62%" BackColor="#32636B" BorderStyle="None" Font-Bold="True" Height="25px" Font-Size="Large" ForeColor="White"></asp:Label>
                        <asp:Label ID="Label_time" runat="server" Text='<%# Eval("Ctime") %>' Font-Size="Smaller" ForeColor="#999999" Width="35%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 207px; height: 16px;" align="center">
                        <asp:TextBox ID="Label_cname" runat="server" Text='<%# Eval("Company") %>' Width="100%" BackColor="#E83A0C" BorderStyle="None" Height="18px" ForeColor="White" style="text-align: center" ReadOnly="True"></asp:TextBox></td>
                </tr>
            </table>
        </ItemTemplate>
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:DataList><br />
</asp:Content>

