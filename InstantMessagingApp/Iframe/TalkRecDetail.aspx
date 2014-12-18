<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TalkRecDetail.aspx.cs" Inherits="InstantMessagingApp.TalkRecDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/CSS/AspNetPageStyle.css" rel="stylesheet" />
    <style>
        * {
            margin: 0px;
            padding: 0px;
        }

        body {
            background-color: #ebf2fa;
        }

        .talk_re_note {
            width: 267px;
            background-color: #ffffff;
            float: left;
            font-size: 12px;
        }

            .talk_re_note li {
                list-style: none;
                float: left;
                padding: 2px;
                width: 100%;
                height: 43px;
            }

        .otheruser_note p {
            color: #7bff3e;
            text-align: left;
            font-size: 12px;
        }

        .otheruser_note span {
            color: #424242;
            text-align: left;
            font-size: 11px;
        }


        .curruser_note p {
            color: #54A6D6;
            text-align: left;
            font-size: 12px;
        }

        .curruser_note span {
            color: #424242;
            text-align: left;
            font-size: 11px;
        }

        .talk_re_note a {
            margin-left: 10px;
            color: #54A6D6;
            text-decoration: underline;
        }

            .talk_re_note a:hover {
                color: #ff6a00;
                text-decoration: none;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="talk_re_note">
            <asp:Repeater ID="talkRP" runat="server">
                <ItemTemplate>
                    <%# Eval("SendUserID").ToString()==userInfo.UserID.ToString()?
                    "<li class=\"curruser_note\"><p>"+userInfo.UserName+" "+Eval("CreateDate").ToString()+"</p><span>"+Eval("Note").ToString()+"</span></li>"
                    :
                    "<li class=\"otheruser_note\"><p>"+hidReceiveUserName.Value+" "+Eval("CreateDate").ToString()+"</p><span>"+Eval("Note").ToString()+"</span></li>" %>
                </ItemTemplate>
            </asp:Repeater>

            <asp:Repeater ID="talkGroupRP" runat="server" Visible="false">
                <ItemTemplate>
                    <%# Eval("SendUserID").ToString()==userInfo.UserID.ToString()?
                    "<li class=\"curruser_note\"><p>"+userInfo.UserName+" "+Eval("CreateDate").ToString()+"</p><span>"+Eval("Note").ToString()+"</span></li>"
                    :
                    "<li class=\"otheruser_note\"><p>"+Eval("UserName").ToString()+" "+Eval("CreateDate").ToString()+"</p><span>"+Eval("Note").ToString()+"</span></li>" %>
                </ItemTemplate>
            </asp:Repeater>

            <asp:Repeater ID="newsRP" runat="server" Visible="false">
                <ItemTemplate>
                    <%# "<li class=\"otheruser_note\"><p>"+Eval("UserName").ToString()+" "+Eval("CreateDate").ToString()+"</p><span>"+Eval("Note").ToString()+"</span></li>" %>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <webdiyer:AspNetPager ID="Pager" CssClass="paginator" CurrentPageButtonClass="cpb"
            Width="100%" runat="server" OnPageChanged="Pager_PageChanged" FirstPageText="首页"
            HorizontalAlign="Right" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页"
            ShowMoreButtons="true" ShowCustomInfoSection="Left" CustomInfoTextAlign="Left" NumericButtonCount="3" ShowPrevNext="False" CustomInfoHTML="" CustomInfoSectionWidth="" ShowFirstLast="False">
        </webdiyer:AspNetPager>

        <asp:HiddenField ID="hidReceiveUserID" runat="server" />
        <asp:HiddenField ID="hidReceiveUserName" runat="server" />
        <asp:HiddenField ID="hidUserID" runat="server" />
    </form>
</body>
</html>
