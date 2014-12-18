var setting = {
    data: {
        simpleData: {
            enable: true
        }
    },
    callback: {
        beforeClick: beforeClick
    }
};

function beforeClick(treeId, treeNode) {
    if (treeNode.level == 1) {
        $("iframe").attr("src", "TalkRecDetail.aspx?ReceiveUserID=" + treeNode.id + "&Type=" + treeNode.pId);
        return false;
    }
    return true;
}

$(function () {
    $.fn.zTree.init($("#treeDemo"), setting, eval($("#TreeData").val()));
});

