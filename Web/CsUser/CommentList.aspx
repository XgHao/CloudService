﻿<%@ Page Language="C#" MasterPageFile="~/CsUser/common.master" AutoEventWireup="true" CodeFile="CommentList.aspx.cs" Inherits="CommentList" Title="Untitled Page" %>
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
            <td style="font-weight: 700; height: 19px; width: 93px">
                <asp:Label ID="Label7" runat="server" Text="筛选服务商："></asp:Label>
            </td>
            <td style="font-weight: 700; height: 19px; width: 94px">
                <asp:DropDownList ID="DDL_CloudService" runat="server" Width="88px" DataSourceID="SqlDataSource2" DataTextField="CloudServiceName" DataValueField="CloudServiceName" >
    </asp:DropDownList>
            </td>
            <td style="font-weight: 700; height: 19px; width: 90px;" align="right">
                <asp:Label ID="Label6" runat="server" Text="筛选用户："></asp:Label>
            </td>
            <td style="font-weight: 700; height: 19px; width: 94px" align="left" >
                <asp:DropDownList ID="DDL_User" runat="server" Width="88px" DataSourceID="SqlDataSource4" DataTextField="UserName" DataValueField="UserName" >
    </asp:DropDownList>
            </td>
            <td style="font-weight: 700; height: 19px" align="left">
    <asp:Button ID="Button" runat="server" Text="查询" Width="50px" OnClick="btnSelect_Click" BackColor="#E83A0C" BorderStyle="None" Font-Bold="True" ForeColor="White" Height="20px" style="text-align: center" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="7" >

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" AllowPaging="True" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="Ctime" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnPageIndexChanging="GridView1_PageIndexChanging" OnDataBound="GridView1_DataBound" EnableModelValidation="True" ForeColor="#333333" GridLines="None" PageSize="12"  >
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                <Columns>
                    <asp:BoundField DataField="CloudServiceName" HeaderText="云服务器商" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Font-Bold="True" Font-Size="20px" Width="10%" Wrap="False" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Score" HeaderText="评分" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                    </asp:BoundField>

                    <asp:BoundField DataField="UserComment" HeaderText="评论" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Commenter" HeaderText="用户" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Font-Bold="True" Width="15%" Wrap="False" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Ctime" HeaderText="发表时间" />

                </Columns>
                <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
                <PagerSettings NextPageImageUrl="~/images/system/next.png" PreviousPageImageUrl="~/images/system/perl.png" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" Font-Size="23px"/>
                <AlternatingRowStyle BackColor="White" />
                <RowStyle BackColor="#E3EAEB" />
             </asp:GridView>

            </td>
        </tr>
    </table>     
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:classConnectionString %>"
        SelectCommand="SELECT [CloudServiceID], [CloudServiceName] FROM [CloudServiceList]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:classConnectionString %>"
        SelectCommand="SELECT [UserID], [UserName] FROM [CsUser]"></asp:SqlDataSource>
</asp:Content>

