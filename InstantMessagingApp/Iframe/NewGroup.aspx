<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewGroup.aspx.cs" Inherits="InstantMessagingApp.NewGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        * {
            margin: 0px;
            padding: 0px;
            font-size: 12px;
            font-family: 'Microsoft YaHei';
        }

        body {
            background-color: #ebf2fa;
        }

        .div_row {
            margin-left: 5px;
            margin-top: 4px;
        }

        #lbError {
            color: #ff0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_row">
            群：<asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
            <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" />
            <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />
            <br />
            <asp:Label ID="lbError" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
