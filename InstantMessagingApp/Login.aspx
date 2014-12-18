<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InstantMessagingApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div><%--登录中。。。--%>
            <asp:DropDownList ID="ddlUser" runat="server"></asp:DropDownList>
            <asp:Button ID="bntLine" runat="server" Text="上线" OnClick="bntLine_Click" />
        </div>
    </form>
</body>
</html>
