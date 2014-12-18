<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TalkRecView.aspx.cs" Inherits="InstantMessagingApp.TalkRecView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/JS/zTree/zTreeStyle.css" rel="stylesheet" />
    <link href="/JS/zTree/demo.css" rel="stylesheet" />
    <script src="../JS/zTree/jquery-1.4.4.min.js"></script>
    <script src="/JS/zTree/jquery.ztree.core-3.5.min.js"></script>
    <script src="/JS/zTree/Tree001.js"></script>
    <style>
        body {
            background-color: #ebf2fa;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="zTreeDemoBackground left">
            <asp:HiddenField ID="TreeData" runat="server" />
            <ul id="treeDemo" class="ztree"></ul>
        </div>

        <iframe width="300px" name="navvMain" id="navvMain" src="TalkRecDetail.aspx" frameborder="no" scrolling="auto" height="290px"></iframe>
    </form>
</body>
</html>
