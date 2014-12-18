<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InitData.aspx.cs" Inherits="InstantMessagingApp.InitData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        * {
            padding: 0px;
            margin: 0px;
            font-size: 12px;
            font-family: 'Microsoft YaHei';
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbDefault" runat="server" Text="初始一个好友组"></asp:Label>
            <br />
            <asp:Button ID="txtInit" runat="server" Text="初始用户信息" OnClick="txtInit_Click" />
            <br />
            <asp:Label ID="lblResult" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:GridView ID="gv" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="90%" ShowFooter="false">
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="35px" HorizontalAlign="Center" />
                <RowStyle ForeColor="#000066" Height="35px" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="UserName" FooterText="用户名" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
