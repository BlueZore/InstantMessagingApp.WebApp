$(function () {
    $("#file_upload").uploadify({
        buttonText: '',
        //flash
        swf: "/JS/uploadify/uploadify.swf",
        //文件选择后的容器ID
        queueID: 'uploadfileQueue',
        uploader: '/Common/UploadHandler.ashx',
        multi: false,
        fileTypeDesc: '支持的格式：',
        fileTypeExts: '*.jpg;*.jpge;*.gif;*.png;*.docx;*.doc;*.rar;*.xlsx;*.xls;*.zip;*.txt;*.pdf',
        formData: { 'ReceiveID': $("#hidReceiveID").val(), 'UserID': $("#hidID").val(), 'Type': 1 },
        removeTimeout: 10,
        fileSizeLimit: '500MB',
        removeCompleted: true,
        width: 96,
        height: 28,
        //在config中设置下面的数值就可以上传大文件了呢！
        //<security>
        //    <requestFiltering>
        //        <requestLimits maxAllowedContentLength="1073741824" />
        //    </requestFiltering>
        //</security>
        //<httpRuntime executionTimeout="50000" maxRequestLength="1073741824" />

        //返回一个错误，选择文件的时候触发
        onSelectError: function (file, errorCode, errorMsg) {
            switch (errorCode) {
                case -100:
                    alert("上传的文件数量已经超出系统限制的" + $('#file_upload').uploadify('settings', 'queueSizeLimit') + "个文件！");
                    break;
                case -110:
                    alert("文件 [" + file.name + "] 大小超出系统限制的" + $('#file_upload').uploadify('settings', 'fileSizeLimit') + "K大小！");
                    break;
                case -120:
                    alert("文件 [" + file.name + "] 大小异常！");
                    break;
                case -130:
                    alert("文件 [" + file.name + "] 类型不正确！");
                    break;
            }
        },
        //检测FLASH失败调用
        onFallback: function () {
            alert("您未安装FLASH控件，无法上传图片！请安装FLASH控件后再试。");
        },
        onUploadStart: function (file) {
            $("#file_upload").uploadify("settings", "formData", { 'ReceiveID': $(".talk:visible").attr("talkID"), 'UserID': $("#hidID").val(), 'Type': $(".talk:visible").attr("talkType") });
            //alert($("#file_upload").uploadify("settings", "formData"));
        },
        //上传到服务器成功时，服务器返回相应信息到data里
        onUploadSuccess: function (file, data, response) {
            if (data != null) {
                var arr = data.split('|');
                if ($("[talkID='" + arr[0] + "']").size() > 0) {
                    var html = "<li class='otheruser_note'><p>" + $("#divSelfName").html() + " " + arr[3] + "</p> <span>" + ("<a href='" + arr[2] + "' target='_blank'>" + arr[1] + "</a>") + "</span></li>";

                    $("[talkID='" + arr[0] + "']").find(".talk_re_note").html($("[talkID='" + arr[0] + "']").find(".talk_re_note").html() + html);
                }
            }
        },
        //选择文件后向队列中添加每个上传任务时都会触发
        onSelect: function (file) {
            if ($(".fm_main_queue").is(":hidden")) {
                $(".fm_main_queue,#uploadfileQueue").show();
            }
        }
    });

    $(".fm_main_queue_head_min").click(function () {
        $("#uploadfileQueue,.fm_main_queue_head_min").hide();
        $(".fm_main_queue_head_max").show();
    });

    $(".fm_main_queue_head_max").click(function () {
        $("#uploadfileQueue,.fm_main_queue_head_min").show();
        $(this).hide();
    });

    $(".fm_main_queue_head_close").click(function () {
        $(".fm_main_queue,#uploadfileQueue,.fm_main_queue_head_max").hide();
        $(".fm_main_queue_head_min").show();
    });
});