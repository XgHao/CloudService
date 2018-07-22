<%@ Page Language="C#" MasterPageFile="~/CsUser/common.master" AutoEventWireup="true" CodeFile="CloudServiceInfo.aspx.cs" Inherits="CloudServiceInfo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" Runat="Server">
    <table class="auto-style3">
        <tr>
            <td style="width: 40px" rowspan="2" class="auto-style4">
                <asp:ImageButton ID="Head" runat="server" Height="45px" ImageUrl="~/images/system/adduser.png" Width="45px" />
            </td>
            <td style="height: 19px; " colspan="2" align="left">
                <asp:Label ID="Label_Time" runat="server" Text="详细信息&gt;" Font-Bold="True" ForeColor="#C84220" Font-Size="Larger"></asp:Label>
                <asp:Label ID="CloudService_Name" runat="server" Text="Label_ID" Font-Bold="True" ForeColor="#C84220" Font-Size="Larger"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 19px; width: 229px" align="left">
                <asp:Label ID="UserName" runat="server" Text="Label" BackColor="White" ForeColor="#29C6D6"></asp:Label>
                <asp:Button ID="Button_Dislike" runat="server" Text="[取消收藏]" BackColor="White" BorderStyle="None" ForeColor="#FF8A8A" OnClick="Button_Dislike_Click" />
            </td>
            <td style="font-weight: 700; height: 19px; ">
                <asp:Label ID="Label_ID" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="Label_USerID" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
 <table border="0px" cellpadding="0px" cellspacing="0px" style="border-color:#C1C1DB; width: 80%;">
            <tr>
                <td align="center" style="width: 251px; " rowspan="8" >
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/bg/right.png" Width="400px" />
                </td>
                <td align="center" style="width: 100px;" colspan="2" bgcolor="#2A6F75">
                    <asp:Label ID="Label1" runat="server" Text="Logo" Font-Bold="True" Font-Size="Larger" ForeColor="#FABF37"></asp:Label>
                </td>
                <td align="center" style="" bgcolor="#29C6D6" >
                    <asp:Image ID="Image_Logo" runat="server" Height="70px" Width="200px" />
                 </td>              
            </tr>
            <tr>
                <td  align="center" style="width: 100px;" colspan="2" bgcolor="#2A6F75">
                    <asp:Label ID="Label2" runat="server" Text="云服务商" Font-Bold="True" Font-Size="Larger" ForeColor="#FABF37" BorderColor="#2A6F75"></asp:Label></td>
                <td  align="center" style="" bgcolor="#29C6D6">
                    <asp:Label ID="lbl_Name" runat="server" Width="76px"  Font-Bold="True" Font-Size="Medium" ForeColor="#C84220"></asp:Label></td>
            </tr>
            <tr>
                <td  align="center" style="width: 100px;" colspan="2" bgcolor="#2A6F75">
                    <asp:Label ID="Label3" runat="server" Text="所属公司" Font-Bold="True" Font-Size="Larger" ForeColor="#FABF37"></asp:Label></td>
                <td align="center" style="" bgcolor="#29C6D6">
                    <asp:Label ID="lbl_Company" runat="server" Width="100%"  Font-Bold="True" Font-Size="Medium" ForeColor="#C84220"></asp:Label></td>
            </tr>
            <tr>
                <td  align="center" style="width: 100px;" colspan="2" bgcolor="#2A6F75">
                    <asp:Label ID="Label4" runat="server" Text="最新评论" Font-Bold="True" Font-Size="Larger" ForeColor="#FABF37"></asp:Label></td>
                <td  align="center" style="" bgcolor="#29C6D6">
                    <asp:Label ID="lbl_Comment" runat="server"  Font-Bold="True" Font-Size="Medium" ForeColor="#C84220"></asp:Label>
                 </td>
            </tr>
            <tr>
                <td  align="center" style="width: 100px" colspan="2" class="auto-style4" bgcolor="#2A6F75">
                    <asp:Label ID="Label5" runat="server" Text="联系地址" Font-Bold="True" Font-Size="Larger" ForeColor="#FABF37"></asp:Label></td>
                <td align="center" style="" bgcolor="#29C6D6">
                    <asp:Label ID="lbl_Address" runat="server" Text="lbl_Address"  Font-Bold="True" Font-Size="Medium" ForeColor="#C84220"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td  align="center" style="width: 100px;" colspan="2" bgcolor="#2A6F75">
                    <asp:Label ID="Label6" runat="server" Text="官方主页" Font-Bold="True" Font-Size="Larger" ForeColor="#FABF37"></asp:Label></td>
                <td  align="center" style="" bgcolor="#29C6D6">
                    <asp:Label ID="lbl_Website" runat="server"  Font-Bold="True" Font-Size="Medium" ForeColor="#C84220"></asp:Label>
                 </td>
            </tr>
     <tr>
                <td  align="center" style="width: 100px;" colspan="2" bgcolor="#2A6F75">
                    <asp:Label ID="Label8" runat="server" Text="服务商评分" Font-Bold="True" Font-Size="Larger" ForeColor="#FABF37"></asp:Label></td>
                <td  align="center" bgcolor="#29C6D6">
                    <asp:Label ID="Label_Score" runat="server"  Font-Bold="True" Font-Size="Medium" ForeColor="#C84220"></asp:Label>
                 </td>
            </tr>
            <tr  align="center">
                <td style="height: 25px; width:100px" bgcolor="#18343A" >
                    <asp:Button ID="CloudSerivceComment" runat="server" Text="更多评价" OnClick="CloudSerivceComment_Click" BackColor="#18343A" BorderStyle="None" Font-Bold="True" Font-Size="Medium" ForeColor="White" />
                    <br />
                </td>                
                <td colspan="2" style="height: 25px" bgcolor="#18343A" >
                    <asp:Button ID="CommentCs" runat="server" Text="我要评价" OnClick="CommentCs_Click" BackColor="#18343A" BorderStyle="None" Font-Bold="True" Font-Size="Medium" ForeColor="White" />
                </td>                
            </tr>
            
        </table>
    
 </div>
</asp:Content>

