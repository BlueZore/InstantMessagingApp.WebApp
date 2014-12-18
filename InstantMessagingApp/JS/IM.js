$(function () {
    //添加
    $(".searchadd_add").bind("click", function () {
        layer.tab({
            area: ['520px', '300px'],
            data: [
                { title: '添加好友', content: '<iframe src=\"Iframe/AddUser.aspx\" frameborder=\"no\" width=\"100%\" height=\"260px\" />' },
                { title: '添加群', content: '<iframe src=\"Iframe/AddGroup.aspx\" frameborder=\"no\" width=\"100%\" height=\"260px\" />' },
                { title: '新建组', content: '<iframe src=\"Iframe/NewTeam.aspx\" frameborder=\"no\" width=\"100%\" height=\"260px\" />' },
                { title: '新建群', content: '<iframe src=\"Iframe/GroupView.aspx\" frameborder=\"no\" width=\"100%\" height=\"260px\" />' }
            ]
        });
    });

    //用户组菜单
    $("#TeamListDIV .team_user:eq(0)").show();
    $("#TeamListDIV").delegate(".team_item_info", "click", function () {
        $(".team .team_user").hide();
        $(".team .team_item_info img").attr("src", "/Image/sanjian.png");
        $(this).next().show();
        $(this).find("img").attr("src", "/Image/sanjian2.png");
        return false;
    });

    //显示聊天窗口
    $("#TeamListDIV,#FoundListDIV").delegate("li", "dblclick", function () {
        //窗口
        $("#talk>div").hide();//talkType='1'单聊
        $(".talktab li").removeClass("talktab_li_selected");

        if ($("[talkID='" + $(this).attr("uID") + "']").size() > 0) {//查看是否已存在窗口
            $("[talkID='" + $(this).attr("uID") + "']").show();
            $("[talkTabID='" + $(this).attr("uID") + "']").addClass("talktab_li_selected");
            $("#talk,.uploadify").show();

            return;
        }

        var html = "<div class='talk' talkID='" + $(this).attr("uID") + "' talkType='1'><div class='talk_re_note'></div><div class='talk_op'></div><div class='talk_note'><textarea/></div><div class='talk_run'><button>关闭</button><button>发送</button></div></div>";
        $("#talk").append(html);
        $("#talk,.uploadify").show();

        //页签
        var tabValue = $(this).find("span").html();
        html = "<li class='talktab_li_selected' talkTabID='" + $(this).attr("uID") + "'>" + (tabValue.length > 3 ? tabValue.substring(0, 3) : tabValue) + "</li>";
        $(".talktab").append(html);
    });

    //显示群聊窗口
    $("#GroupListDIV").delegate(".team_item_info", "dblclick", function () {
        //窗口
        $("#talk>div").hide();//talkType='2'群聊
        $(".talktab li").removeClass("talktab_li_selected");

        if ($("[talkID='" + $(this).attr("gID") + "']").size() > 0) {//查看是否已存在窗口
            $("[talkID='" + $(this).attr("gID") + "']").show();
            $("[talkTabID='" + $(this).attr("gID") + "']").addClass("talktab_li_selected");
            $("#talk,.uploadify").show();

            return;
        }

        var html = "<div class='talk' talkID='" + $(this).attr("gID") + "' talkType='2'><div class='talk_re_note'></div><div class='talk_op'></div><div class='talk_note'><textarea/></div><div class='talk_run'><button>关闭</button><button>发送</button></div></div>";
        $("#talk").append(html);
        $("#talk,.uploadify").show();

        //页签
        var tabValue = $(this).find("span").html();
        html = "<li class='talktab_li_selected' talkTabID='" + $(this).attr("gID") + "'>" + (tabValue.length > 3 ? tabValue.substring(0, 3) : tabValue) + "</li>";
        $(".talktab").append(html);
    });

    //页签切换控制显示聊天窗口
    $(".talktab").delegate("li", "click", function () {
        $(".talktab li").removeClass("talktab_li_selected");
        $(this).addClass("talktab_li_selected");
        $("#talk>div").hide();
        $("#talk").find("[talkID='" + $(this).attr("talkTabID") + "']").show();
    });

    //移除通话
    $("#talk").delegate("button", "click", function () {
        var $talk = $(this).parents(".talk");
        var talkID = $talk.attr("talkID");
        switch ($(this).html()) {
            case "关闭":
                $("[talkID='" + talkID + "']").remove();
                $("[talkTabID='" + talkID + "']").remove();

                if ($("#talk>div").size() > 0) {//第一页签显示
                    $("#talk>div:eq(0)").show();
                    $(".talktab>li:eq(0)").addClass("talktab_li_selected");
                }
                else {//隐藏整个聊天窗口
                    $("#talk,.uploadify").hide();

                }
                break;
            case "发送"://支持单聊和群聊，通过talkType控制
                var $textArea = $talk.find("textarea");
                var note = $textArea.val();
                var talkType = $talk.attr("talkType");
                if ($.trim(note).length == 0) return false;//发空过滤
                $.ajax({
                    type: "post",
                    contentType: "application/json",
                    url: "/Common/Ajax.asmx/sendUserTalk",
                    data: "{SendUserID:'" + $("#hidID").val() + "',ReceiveUserID:'" + talkID + "',Type:'" + talkType + "',Note:'" + note + "'}",
                    dataType: "json",
                    success: function (result) {
                        if (result.d != "") {
                            var html = "<li class='curruser_note'><p>" + $("#divSelfName").html() + " " + result.d + "</p><span>" + note + "</span></li>";

                            $talk.find(".talk_re_note").html($(".talk_re_note").html() + html);
                            $talk.find(".talk_re_note").attr("scrollTop", "1000000");
                            $textArea.val("");
                        }
                    }
                });
                break;
        }
        return false;
    });

    //##########################################提示
    //提示关闭
    $("#ULLayer").delegate(".header a", "click", function () {
        $(this).parents(".ULLayer").remove();
        if ($(".ULLayer").size() == 0) { $("#ULLayer").hide(); }//判断是否要隐藏#ULLayer层
        return false;
    });

    //提示查看
    $("#ULLayer").delegate(".footer a", "click", function () {
        var ID = $(this).parents(".ULLayer").attr("newID");
        if (ID != undefined) {//消息
            var businessType = $(this).parents(".ULLayer").attr("BusinessType");
            var tmpSrc = "";
            switch (businessType) {//判断跳转页
                case "1": tmpSrc = "ConfirmUser"; break;
                case "2": tmpSrc = "ConfirmGroup"; break;
            }
            layer.tab({
                area: ['340px', '270px'],
                data: [
                    { title: '申请', content: '<iframe src=\"Iframe/' + tmpSrc + '.aspx?ID=' + ID + '\" frameborder=\"no\" width=\"100%\" height=\"270px\" />' }
                ]
            });
        }
        else {//聊天
            ID = $(this).parents(".ULLayer").attr("UL_talkID");
            if (ID != undefined) {
                var talkType = $(this).parents(".ULLayer").attr("UL_talkType");//区分群聊

                //窗口
                $("#talk>div").hide();
                var html = "<div class='talk' talkID='" + ID + "' talkType='" + talkType + "'><div class='talk_re_note'>加载中...</div><div class='talk_op'></div><div class='talk_note'><textarea/></div><div class='talk_run'><button>关闭</button><button>发送</button></div></div>";
                $("#talk").html($("#talk").html() + html);
                $("#talk,.uploadify").show();

                //页签
                $(".talktab li").removeClass("talktab_li_selected");
                html = "<li class='talktab_li_selected' talkTabID='" + ID + "'>" + $(this).parents(".ULLayer").attr("UL_talkName") + "</li>";
                $(".talktab").html($(".talktab").html() + html);


                $.ajax({
                    type: "post",
                    contentType: "application/json",
                    url: "/Common/Ajax.asmx/sendUserTalkRec",
                    data: "{SendUserID:'" + ID + "',ReceiveUserID:'" + $("#hidID").val() + "',TalkType:'" + talkType + "'}",
                    dataType: "json",
                    success: function (result) {
                        if (result.d != "") {

                            //加载聊天
                            var talkList = eval(result.d)[0].TalkList;
                            var html = "";
                            for (var i = 0; i < talkList.length; i++) {
                                var $talk = $("#talk").find("[talkID='" + ID + "']");
                                if ($talk.size() > 0) {//写入聊天窗口
                                    html += "<li class='otheruser_note'><p>" + talkList[i].SendUserName + " " + talkList[i].CreateDate + "</p> <span>" + talkList[i].Note + "</span></li>";

                                }
                            }
                            $talk.find(".talk_re_note").html(html);
                            $talk.find(".talk_re_note").attr("scrollTop", $talk.find(".talk_re_note").height());//控制显示内容距底
                        }
                    }
                });
            }
        }
        $(this).parents(".ULLayer").remove();
        if ($(".ULLayer").size() == 0) { $("#ULLayer").hide(); }//判断是否要隐藏#ULLayer层
        return false;
    });

    //切换左侧页签
    $(".left_op_menu").delegate("li", "click", function () {//切换左侧页签
        var $index = $(".left_op_menu li").index($(this));
        switch ($index) {
            case 0:
            case 1:
                $(".left_op_menu li").removeClass("left_op_menu_li_selected");
                $(".left_user .team").hide();
                $(".left_op_menu li:eq(" + $index + ")").addClass("left_op_menu_li_selected");
                $(".left_user .team:eq(" + $index + ")").show();
                break;
            case 2:
                layer.tab({
                    area: ['500px', '340px'],
                    data: [
                        { title: '聊天记录', content: '<iframe src=\"Iframe/TalkRecView.aspx\" frameborder=\"no\" width=\"100%\" height=\"330px\" />' }
                    ]
                });
                break;
            case 3:
                layer.tab({
                    area: ['500px', '340px'],
                    data: [
                        { title: '新闻', content: '<iframe src=\"Iframe/AboutUsView.aspx\" frameborder=\"no\" width=\"100%\" height=\"330px\" />' }
                    ]
                });
                break;
        }
    });

    //用户搜索
    $(".searchadd_search").delegate("a", "click", function () {
        var $userList = $("#TeamListDIV li");//好友集合
        var html = "";
        $("#FoundListDIV ul").html("");//清空结果
        var search = $.trim($(".searchadd_search input").val());
        if (search.length == 0) return false;//空不搜索
        $userList.each(function () {
            //alert($(this).find("span").html().indexOf(search));
            if ($(this).find("span").html().indexOf(search) > -1) {//好友核对
                html += "<li uid=\"" + $(this).attr("uid") + "\"><img width=\"17px\" height=\"17\" src=\"" + $(this).find("img").attr("src") + "\"><span>" + $(this).find("span").html() + "</span></li>";
            }
        });
        $("#FoundListDIV ul").html(html);
        $(".left_op_menu li").removeClass("left_op_menu_li_selected");
        $(".left_user .team").hide();
        $("#FoundListDIV,#FoundListDIV .team_user").show();
        return false;
    });


    var userIDSelected = "";
    var teamIDSelected = "";
    //组成员鼠标右键层
    $("#TeamListDIV").delegate("li", "contextmenu", function (e) {
        if (e.which == 3) {
            //获取序号
            userIDSelected = $(this).attr("uid");
            teamIDSelected = $(this).parents().prev().attr("tid");
            $(".fm_main_menu").css({ "margin-top": e.clientY - 5, "margin-left": e.clientX - 5, "height": 78 }).show();
            $(".fm_main_menu").html("<li><a>移动</a></li><li><a>删除</a></li><li><a>好友信息</a></li>");
        }
        return false;
    });

    //移动用户
    $(".fm_main_menu").delegate("li:eq(0)", "click", function (e) {
        switch ($(this).find("a").html()) {
            case "移动":
                layer.tab({
                    area: ['340px', '270px'],
                    data: [
                        { title: '移动用户', content: '<iframe src=\"Iframe/MoveUser.aspx?UserID=' + userIDSelected + '&TeamID=' + teamIDSelected + '\" frameborder=\"no\" width=\"100%\" height=\"270px\" />' }
                    ]
                });
                break;
            case "查看成员":
                layer.tab({
                    area: ['340px', '270px'],
                    data: [
                        { title: '查看成员', content: '<iframe src=\"Iframe/GroupMemberView.aspx?GroupID=' + groupIDSelected + '\" frameborder=\"no\" width=\"100%\" height=\"270px\" />' }
                    ]
                });
                break;
        }

    });

    //删除好友
    $(".fm_main_menu").delegate("li:eq(1)", "click", function (e) {
        if (confirm("确定删除？")) {
            $.ajax({
                type: "post",
                contentType: "application/json",
                url: "/Common/Ajax.asmx/DeleteUser",
                data: "{userID:'" + userIDSelected + "',teamID:'" + teamIDSelected + "'}",
                dataType: "json",
                success: function (result) {
                    if (result.d == "1") {
                        $("[uid='" + userIDSelected + "']").remove();
                        $(".fm_main_menu").hide();
                    }
                }
            });
        }
    });

    //好友信息
    $(".fm_main_menu").delegate("li:eq(2)", "click", function (e) {
        layer.tab({
            area: ['300px', '220px'],
            data: [
                { title: '好友信息', content: '<iframe src=\"Iframe/BaseUserView.aspx?UserID=' + userIDSelected + '\" frameborder=\"no\" width=\"100%\" height=\"220px\" />' }
            ]
        });
    });

    var groupIDSelected = "";
    //组成员鼠标右键层
    $("#GroupListDIV").delegate(".team_item_info", "contextmenu", function (e) {
        if (e.which == 3) {
            //获取序号
            groupIDSelected = $(this).attr("gid");
            $(".fm_main_menu").css({ "margin-top": e.clientY - 5, "margin-left": e.clientX - 5, "height": 26 }).show();
            $(".fm_main_menu").html("<li><a>查看成员</a></li>");
        }
        return false;
    });

    //鼠标移出菜单层，隐藏
    $("body").delegate(".fm_main_menu", "mouseleave", function () {
        $(".fm_main_menu").hide();
    });

    setInterval("getUserAboutNews()", 6000);

});

function getUserAboutNews() {
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "/Common/Ajax.asmx/getUserAboutNews",
        data: "{UserID:'" + $("#hidID").val() + "'}",
        dataType: "json",
        success: function (result) {
            if (result.d != "") {
                //加载消息
                var newsList = eval(result.d)[0].NewsList;
                var html = "";
                for (var i = 0; i < newsList.length; i++) {
                    html += "<ul class='ULLayer' newID='" + newsList[i].ID + "' sendID='" + newsList[i].SendUserID + "' BusinessType='" + newsList[i].BusinessType + "'><li class='header'><b>系统提醒</b><a><img src='/Image/close.png'/></a></li><li class='body'>" + newsList[i].Note + "，需要您的处理！</li><li class='footer'><a>查看</a></li></ul>";
                }
                if (html.length > 0) {
                    $("#ULLayer").html($("#ULLayer").html() + html);
                    $("#ULLayer").show();
                }

                //加载聊天
                var talkList = eval(result.d)[0].TalkList;
                html = "";
                for (var i = 0; i < talkList.length; i++) {
                    var $talk = $("#talk").find("[talkID='" + talkList[i].SendUserID + "']");
                    if ($talk.size() > 0) {//写入聊天窗口
                        html = "<li class='otheruser_note'><p>" + talkList[i].SendUserName + " " + talkList[i].CreateDate + "</p> <span>" + talkList[i].Note + "</span></li>";
                        $talk.find(".talk_re_note").html($talk.find(".talk_re_note").html() + html);
                    }
                    else {
                        if ($("[UL_talkID='" + talkList[i].SendUserID + "']").size() == 0) {//在ULLayer没有发送用户的提示，显示提示框
                            html += "<ul class='ULLayer' UL_talkID='" + talkList[i].SendUserID + "' UL_talkName='" + talkList[i].SendUserName + "' UL_talkType='1'><li class='header'><b>系统提醒</b><a><img src='/Image/close.png'/></a></li><li class='body'>“" + talkList[i].SendUserName + "”向你发出聊天申请！</li><li class='footer'><a>查看</a></li></ul>";
                            $("#ULLayer").html($("#ULLayer").html() + html);
                            $("#ULLayer").show();
                        }
                    }
                }

                //加载群聊
                var talkGroupList = eval(result.d)[0].TalkGroupList;
                html = "";
                for (var i = 0; i < talkGroupList.length; i++) {
                    var $talk = $("#talk").find("[talkID='" + talkGroupList[i].GroupID + "']");
                    if ($talk.size() > 0) {//写入聊天窗口
                        html = "<li class='otheruser_note'><p>" + talkGroupList[i].UserName + " " + talkGroupList[i].CreateDate + "</p> <span>" + talkGroupList[i].Note + "</span></li>";
                        $talk.find(".talk_re_note").html($talk.find(".talk_re_note").html() + html);
                    }
                    else {
                        if ($("[UL_talkID='" + talkGroupList[i].GroupID + "']").size() == 0) {//在ULLayer没有发送用户的提示，显示提示框
                            html += "<ul class='ULLayer' UL_talkID='" + talkGroupList[i].GroupID + "' UL_talkName='" + talkGroupList[i].GroupName + "' UL_talkType='2'><li class='header'><b>系统提醒</b><a><img src='/Image/close.png'/></a></li><li class='body'>“" + talkGroupList[i].GroupName + "”群有人聊天！</li><li class='footer'><a>查看</a></li></ul>";
                            $("#ULLayer").html($("#ULLayer").html() + html);
                            $("#ULLayer").show();
                        }
                    }
                }
            }
        }
    });
}

function addUserForTeam(userID, teamID, userName, pic) {
    if ($("[uid='" + userID + "']").size() == 0) {
        var html = "<li uid='" + userID + "'><img width='17px' height='17' src='/UpLoadFiles" + pic + "'><span>" + userName + "</span></li>";
        $("[tid='" + teamID + "']").next().append(html);
    }
}

function addGroup(groupID, groupName) {
    if ($("[gid='" + groupID + "']").size() == 0) {
        var html = "<div class='team_item'><div gid='" + groupID + "' class='team_item_info'><img src='Image/leftmenu2.png' style='margin-top: 3px;' /><span>" + groupName + "</span></div></div>";
        $("#GroupListDIV").append(html);
    }
}

function addTeam(teamID, teamName) {
    if ($("[tid='" + teamID + "']").size() == 0) {
        var html = "<div class='team_item'><div tid='" + teamID + "' class='team_item_info'><img src='/Image/sanjian.png'><span>" + teamName + "</span></div><ul class='team_user'></ul></div>";
        $("#TeamListDIV").append(html);
    }
}

function moveUser(teamID, userID) {
    var $uid = $("[uid='" + userID + "']");
    $("[uid='" + userID + "']").remove();
    $("[tid='" + teamID + "']").next().append($uid);
}