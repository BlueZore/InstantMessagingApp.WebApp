<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUsDetail.aspx.cs" Inherits="InstantMessagingApp.AboutUsDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        body {
            background-color: #ebf2fa;
        }

        #lbTilte {
            width: 100%;
            text-align: center;
            font-size: 18px;
            color: #000;
            font-weight: bold;
        }

        #lbNote {
            width: 100%;
            font-size: 14px;
            color: #242323;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lbTilte" runat="server"></asp:Label>
        <hr />
        <asp:Label ID="lbNote" runat="server"></asp:Label>
    </form>
</body>
</html>
