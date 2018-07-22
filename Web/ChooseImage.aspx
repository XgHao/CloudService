<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChooseImage.aspx.cs" Inherits="ChooseImage" %>

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
            width: 518px;
            height: 666px;
        }
        .auto-style12 {
            width:100%;
            background-color: #D6EAE9;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">
                    <asp:Image ID="Image13" runat="server" Height="750px" ImageUrl="~/images/bg/buttom.png" />
                </td>
                <td >        
                    <table class="auto-style12">
                        <tr>
                            <td colspan="2" align="center" style="width: 200px; height: 100px; background-color: #D6EAE9">
                                <asp:Label ID="Label_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                                <asp:Label ID="Label_Table" runat="server" Text="Label" Visible="False"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#D04F44" Text="选择自己的头像" Font-Bold="True" Font-Size="XX-Large" Width="251px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color:#D6EAE9" align="center"> <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" ImageUrl="~/images/head/1.png" Width="100px" OnClick="ImageButton1_Click" /></td>
                            <td style="background-color:#D6EAE9" align="center"><asp:ImageButton ID="ImageButton2" runat="server" Height="100px" ImageUrl="~/images/head/2.png" Width="100px" OnClick="ImageButton2_Click" /></td>
                        </tr>
                        <tr>
                            <td style="background-color:#D6EAE9" align="center"><asp:ImageButton ID="ImageButton3" runat="server" Height="100px" ImageUrl="~/images/head/3.png" Width="100px" OnClick="ImageButton3_Click" /></td>
                            <td style="background-color:#D6EAE9" align="center"><asp:ImageButton ID="ImageButton4" runat="server" Height="100px" ImageUrl="~/images/head/4.png" Width="100px" OnClick="ImageButton4_Click" /></td>
                        </tr>
                        <tr>
                            <td style="background-color:#D6EAE9"align="center"><asp:ImageButton ID="ImageButton5" runat="server" Height="100px" ImageUrl="~/images/head/5.png" Width="100px" OnClick="ImageButton5_Click"/></td>
                            <td style="background-color:#D6EAE9"align="center"><asp:ImageButton ID="ImageButton6" runat="server" Height="100px" ImageUrl="~/images/head/6.png" Width="100px" OnClick="ImageButton6_Click"/></td>
                        </tr>
                        <tr>
                            <td style="background-color:#D6EAE9"align="center"><asp:ImageButton ID="ImageButton7" runat="server" Height="100px" ImageUrl="~/images/head/7.png" Width="100px" OnClick="ImageButton7_Click"/></td>
                            <td style="background-color:#D6EAE9"align="center"><asp:ImageButton ID="ImageButton8" runat="server" Height="100px" ImageUrl="~/images/head/8.png" Width="100px" OnClick="ImageButton8_Click"/></td>
                        </tr>
                        <tr>
                            <td style="background-color:#D6EAE9"align="center"><asp:ImageButton ID="ImageButton9" runat="server" Height="100px" ImageUrl="~/images/head/9.png" Width="100px" OnClick="ImageButton9_Click"/></td>
                            <td style="background-color:#D6EAE9"align="center"><asp:ImageButton ID="ImageButton10" runat="server" Height="100px" ImageUrl="~/images/head/10.png" Width="100px" OnClick="ImageButton10_Click"/></td>
                        </tr>
                        <tr>
                            <td style="background-color:#D6EAE9"align="center"><asp:ImageButton ID="ImageButton11" runat="server" Height="100px" ImageUrl="~/images/head/11.png" Width="100px" OnClick="ImageButton11_Click"/></td>
                            <td style="background-color:#D6EAE9"align="center"><asp:ImageButton ID="ImageButton12" runat="server" Height="100px" ImageUrl="~/images/head/12.png" Width="100px" OnClick="ImageButton12_Click"/></td>
                        </tr>
                        </table>
                    
                    </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
