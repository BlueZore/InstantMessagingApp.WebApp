<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmUser.aspx.cs" Inherits="InstantMessagingApp.ConfirmUser" %>

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
            margin-top: 20px;
            text-align: center;
        }

        #lbError {
            color: #ff0000;
        }
    </style>

    
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_row">
            <asp:Label ID="lbNews" runat="server" Font-Size="16px"></asp:Label>
            <br />
            <br />
            组：<asp:DropDownList ID="ddlTeam" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnOK" runat="server" Text="同意" OnClick="btnOK_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnReject" runat="server" Text="拒绝" OnClick="btnReject_Click" />
        </div>
    </form>
</body>
</html>
