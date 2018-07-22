<%@ Page Language="C#" MasterPageFile="~/CsUser/common.master" AutoEventWireup="true" CodeFile="CloudServiceComment.aspx.cs" Inherits="CloudServiceComment" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" Runat="Server">
    <table class="auto-style3">
        <tr>
            <td style="width: 40px" rowspan="2" class="auto-style4">
                <asp:ImageButton ID="Head" runat="server" Height="45px" ImageUrl="~/images/system/adduser.png" Width="45px" />
            </td>
            <td style="height: 19px; " colspan="6" align="left">
                <asp:Label ID="Label_cloudserviceName" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#C84220" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 19px; width: 229px" align="left">
                <asp:Label ID="Label_Name" runat="server" Text="Label_ID" Font-Bold="True" ForeColor="#70B6BD" Font-Size="Small"></asp:Label>
                <asp:Label ID="Label_Logout" runat="server" Text="[退出]" Font-Bold="True" ForeColor="#70B6BD" Font-Size="Small" OnDataBinding="Button_Logout_Click"></asp:Label>
            </td>
            <td style="font-weight: 700; height: 19px; width: 93px">
                &nbsp;</td>
            <td style="font-weight: 700; height: 19px; width: 94px">
                &nbsp;</td>
            <td style="font-weight: 700; height: 19px; width: 90px;" align="right">
                &nbsp;</td>
            <td style="font-weight: 700; height: 19px; width: 94px" align="left" >
                &nbsp;</td>
            <td style="font-weight: 700; height: 19px" align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="7" >

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" AllowPaging="True" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="Ctime" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnPageIndexChanging="GridView1_PageIndexChanging" OnDataBound="GridView1_DataBound" EnableModelValidation="True" ForeColor="#333333" GridLines="None" PageSize="12"  >
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <Columns>

                    <asp:BoundField DataField="Commenter" HeaderText="用户" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Font-Bold="True" Width="15%" Wrap="False" Font-Size="Larger" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Score" HeaderText="评分" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                    </asp:BoundField>

                    <asp:BoundField DataField="UserComment" HeaderText="评论" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Ctime" HeaderText="发表时间" />

                </Columns>
                <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
                <PagerSettings NextPageImageUrl="~/images/system/next.png" PreviousPageImageUrl="~/images/system/perl.png" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="23px"/>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
             </asp:GridView>

            </td>
        </tr>
    </table>     
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:classConnectionString %>"
        SelectCommand="SELECT [CloudServiceID], [CloudServiceName] FROM [CloudServiceList]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:classConnectionString %>"
        SelectCommand="SELECT [UserID], [UserName] FROM [CsUser]"></asp:SqlDataSource>
</asp:Content>

