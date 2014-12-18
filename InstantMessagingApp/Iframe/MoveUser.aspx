<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoveUser.aspx.cs" Inherits="InstantMessagingApp.MoveUser" %>

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
            <asp:HiddenField ID="hidUserID" runat="server" />
            <asp:HiddenField ID="hidTeamID" runat="server" />
            好友：<asp:Label ID="lbUserName" runat="server"></asp:Label>
            <br />
            移动到：<asp:DropDownList ID="ddlTeam" runat="server" Width="150px"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSave" runat="server" Text="确定" OnClick="btnSave_Click" />
            <br />
            <asp:Label ID="lbError" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

