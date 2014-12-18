<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUsView.aspx.cs" Inherits="InstantMessagingApp.AboutUsView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        * {
            margin: 0px;
            padding: 0px;
            font-size: 16px;
            font-family: 'Microsoft YaHei';
        }

        body {
            background-color: #ebf2fa;
        }

        p {
            margin: 3px 8px;
        }

        a {
            color: #0094ff;
        }

            a:hover {
                color: #808080;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Repeater ID="rp" runat="server">
            <ItemTemplate>
                <p><a href="AboutUsDetail.aspx?ID=<%# Eval("ID") %>" target="_blank"><%# Eval("Title") %></a></p>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
