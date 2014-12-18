<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="InstantMessagingApp.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/CSS/Style.css" rel="stylesheet" />
    <script src="JS/jquery-1.11.1.min.js"></script>
    <script src="JS/layer/layer.min.js" type="text/javascript"></script>
    <script src="JS/layer/extend/layer.ext.js" type="text/javascript"></script>
    <script type="text/javascript">
        
    </script>
    <link href="/JS/uploadify/uploadify.css" rel="stylesheet" />
    <script src="/JS/uploadify/swfobject.js"></script>
    <script src="/JS/uploadify/jquery.uploadify.min.js"></script>
    <script src="/JS/uploadify/uploadify.js"></script>
    <script src="/JS/IM.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <ul class="fm_main_menu">
            <%--<li><a>移动</a></li>
            <li><a>删除</a></li>--%>
        </ul>

        <div class="main">
            <div class="left">
                <div class="self">
                    <div class="self_pic">
                        <asp:Image ID="imgSelfUserPic" runat="server" ImageUrl="~/Image/userpic.png" Width="43px" Height="43px" />
                    </div>
                    <div class="self_name" runat="server" id="divSelfName">赵本山</div>
                </div>
                <div class="left_op">
                    <ul class="left_op_menu">
                        <li class="left_op_menu_li_selected" title="好友">
                            <img src="Image/leftmenu1.png" />
                        </li>
                        <li title="群">
                            <img src="Image/leftmenu2.png" />
                        </li>
                        <li title="聊天记录">
                            <img src="Image/leftmenu3.png" />
                        </li>
                        <li title="新闻">
                            <img src="Image/leftmenu4.png" />
                        </li>
                    </ul>
                    <div class="left_user">
                        <div class="searchadd">
                            <div class="searchadd_search">
                                <input style="background-color: transparent" />
                                <a>&nbsp;</a>
                            </div>
                            <div class="searchadd_add">
                                <img src="/Image/adduser.png" />
                            </div>
                        </div>
                        <div class="team" id="TeamListDIV" runat="server">
                            <%--<div class="team_item">
                                <div class="team_item_info">
                                    <img src="/Image/sanjian.png" />
                                    <span>好友</span>
                                </div>
                                <ul class="team_user">
                                    <li>
                                        <img src="/Image/userpic2.png" />
                                        <span>用户A</span>
                                    </li>
                                </ul>
                            </div>--%>
                        </div>
                        <div class="team" id="GroupListDIV" runat="server">
                            <%--<div class="team_item">
                                <div class="team_item_info">
                                    <img src="/Image/sanjian.png" />
                                    <span>好友</span>
                                </div>
                                <ul class="team_user">
                                    <li>
                                        <img src="/Image/userpic2.png" />
                                        <span>用户A</span>
                                    </li>
                                </ul>
                            </div>--%>
                        </div>
                        <div class="team" id="FoundListDIV" runat="server">
                            <div class="team_item">
                                <div class="team_item_info">
                                    <span>搜索结果</span>
                                </div>
                                <ul class="team_user">
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="right">
                <div id="file_upload">
                </div>
                <div id="talk">
                    <%--<div class="talk">
                        <ul class="talk_re_note">
                            <li class="otheruser_note">
                                <p>XXXX 2014-11-23 13:00</p>
                                <span>note</span>
                            </li>
                            <li class="curruser_note">
                                <p>XXXX 2014-11-23 13:00</p>
                                <span>note</span>
                            </li>
                        </ul>
                        <div class="talk_op">
                        </div>
                        <div class="talk_note"></div>
                        <div class="talk_run">
                            <button>关闭</button>
                            <button>发送</button>
                        </div>
                    </div>--%>
                </div>
                <ul class="talktab">
                    <%--<li>用户A</li>
                    <li class="talktab_li_selected">用户B</li>
                    <li>用户C</li>--%>
                </ul>
            </div>

            <div id="ULLayer">
            </div>
        </div>
        <div class="fm_main_queue">
            <div class="fm_main_queue_head">
                <span>上传完成</span>

                <a class="fm_main_queue_head_close"></a>
                <a class="fm_main_queue_head_max"></a>
                <a class="fm_main_queue_head_min"></a>
            </div>
            <div id="uploadfileQueue">
            </div>
        </div>

        <asp:HiddenField ID="hidID" runat="server" />
        <asp:HiddenField ID="hidReceiveID" runat="server" Value="6AC2AEED-DB26-4AD5-BEE8-292CEFEA9356" />

    </form>
</body>
</html>
