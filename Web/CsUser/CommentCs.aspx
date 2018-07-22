<%@ Page Title="" Language="C#" MasterPageFile="~/CsUser/common.master" AutoEventWireup="true" CodeFile="CommentCs.aspx.cs" Inherits="CommentCs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" Runat="Server">
     <table class="auto-style3">
        <tr>
            <td style="width: 40px" rowspan="2" class="auto-style4">
                <asp:ImageButton ID="Head" runat="server" Height="45px" ImageUrl="~/images/system/adduser.png" Width="45px" />
            </td>
            <td style="height: 19px; " colspan="6" align="left">
                <asp:Label ID="Label_Comment" runat="server" Text="评价&gt;" Font-Bold="True" ForeColor="#C84220" Font-Size="Larger"></asp:Label>
                <asp:Label ID="CloudService_Name" runat="server" Text="Label_ID" Font-Bold="True" ForeColor="#C84220" Font-Size="Larger"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 19px; width: 229px" align="left">
                <asp:Label ID="User_Name" runat="server" Text="Label_ID" Font-Bold="True" ForeColor="#F7BC33"></asp:Label>
                <asp:Button ID="Button_Logout" runat="server" Text="    [退出]" BackColor="White" BorderStyle="None" ForeColor="#70B6BD" OnClick="Button_Logout_Click" />
            </td>
            <td style="font-weight: 700; height: 19px; width: 80px">
                &nbsp;</td>
            <td style="font-weight: 700; height: 19px; width: 94px">&nbsp;</td>
            <td style="font-weight: 700; height: 19px; width: 76px;" align="left">
                <asp:Label ID="Label_cloudserID" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="Label_score" runat="server" Text="0" Visible="False"></asp:Label>
            </td>
            <td style="font-weight: 700; height: 19px; width: 94px" align="left" >
                &nbsp;</td>
            <td style="font-weight: 700; height: 19px" align="left">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%" dir="ltr" frame="border" bgcolor="#D3B17D">
        <tr>
            <td bgcolor="White" style="height: 16px;" colspan="3">
                <asp:Label ID="lbl_Company" runat="server" Text="Label" Font-Bold="True" Font-Size="XX-Large" ForeColor="#32636B"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="White" style="width: 17%; height: 26px;">


                <asp:Label ID="Label" runat="server" Font-Bold="True" Font-Size="Larger" Text="快速评价"></asp:Label>


            </td>
            <td bgcolor="White" style="width: 54%; height: 26px;">
                <asp:RadioButton ID="RB1" runat="server" Text="响应慢" Font-Bold="True" />
                <asp:RadioButton ID="RB2" runat="server" Text="价格贵" Font-Bold="True"/>
                <asp:RadioButton ID="RB3" runat="server" Text="售后差" Font-Bold="True"/>
                <asp:RadioButton ID="RB4" runat="server" Text="不稳定" Font-Bold="True"/>
                <asp:RadioButton ID="RB5" runat="server" Text="功能少" Font-Bold="True"/>
                <asp:RadioButton ID="RB6" runat="server" Text="很全面" Font-Bold="True"/></td>
            <td bgcolor="White" style="height: 26px;">
                <asp:ImageButton ID="Score1" runat="server" Height="30px" ImageUrl="~/images/system/No.png" Width="30px" OnClick="Score1_Click" />
                <asp:ImageButton ID="Score2" runat="server" Height="30px" ImageUrl="~/images/system/No.png" Width="30px" OnClick="Score2_Click" />
                <asp:ImageButton ID="Score3" runat="server" Height="30px" ImageUrl="~/images/system/No.png" Width="30px" OnClick="Score3_Click" />
                <asp:ImageButton ID="Score4" runat="server" Height="30px" ImageUrl="~/images/system/No.png" Width="30px" OnClick="Score4_Click" />
                <asp:ImageButton ID="Score5" runat="server" Height="30px" ImageUrl="~/images/system/No.png" Width="30px" OnClick="Score5_Click" />
            </td>
        </tr>
        <tr>
            <td bgcolor="White" colspan="3">
                <asp:TextBox ID="TextBox_more" runat="server" Height="95px" Width="100%" Columns="2" TextMode="MultiLine" Font-Bold="False" Font-Size="X-Large" BackColor="White"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td bgcolor="White" colspan="2">
                <asp:Button ID="Button_Bold" runat="server" BackColor="White" BorderStyle="None" Font-Bold="True" Font-Size="Medium" ForeColor="Black" Height="22px" OnClick="Button_Bold_Click" Text="B" ToolTip="加粗" Width="22px" />
                <asp:Button ID="Button_Under" runat="server" BackColor="White" BorderStyle="None" Font-Bold="False" Font-Size="Medium" Font-Underline="True" ForeColor="Black" Height="22px" OnClick="Button_Under_Click" Text="U" ToolTip="下划线" Width="22px" />
                <asp:Button ID="Button_Italic" runat="server" BackColor="White" BorderStyle="None" Font-Bold="False" Font-Italic="True" Font-Size="Medium" Font-Underline="False" ForeColor="Black" Height="22px" OnClick="Button_Italic_Click" Text="I" ToolTip="斜体" Width="22px" />
                <asp:Button ID="Button_Clear" runat="server" BackColor="White" BorderStyle="None" Font-Bold="True" Font-Size="Medium" Font-Underline="False" ForeColor="Black" Height="22px" OnClick="Button_Clear_Click" Text="C" ToolTip="清空" Width="22px" />
                <asp:Button ID="Button_addF" runat="server" BackColor="White" BorderStyle="None" Font-Bold="False" Font-Size="16px" Font-Underline="False" ForeColor="Black" Height="22px" OnClick="Button_addF_Click" Text="A+" ToolTip="字体加大" Width="22px" />
                <asp:Button ID="Button_subF" runat="server" BackColor="White" BorderStyle="None" Font-Bold="False" Font-Size="16px" Font-Underline="False" ForeColor="Black" Height="22px" OnClick="Button_subF_Click" Text="A-" ToolTip="字体加大" Width="22px" />
            </td>
            <td bgcolor="White" align="right">
                <asp:Button ID="Comment" runat="server" BackColor="White" BorderStyle="None" Font-Bold="True" Font-Size="Large" OnClick="Cancel_Click" Text="提交评价" />
            </td>
        </tr>
    </table>
</asp:Content>

