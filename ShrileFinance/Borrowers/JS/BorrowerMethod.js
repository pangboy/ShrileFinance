// 时间数据格式转换
function myformatter(date) {
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();
    return y.toString() + (m < 10 ? ('0' + m) : m).toString() + (d < 10 ? ('0' + d) : d).toString();
}
function myparser(s) {
    if (s != "") {
        var y = s.substring(0, 4);
        var m = s.substring(4, 6);
        var d = s.substring(6, 8);
        var s = Date.parse(y + "-" + m + "-" + d);
        return new Date(s);
    }
    else {
        return new Date();
    }
}

var _A = 0;
var _B = 0;
var _C = 0;
var _D = 0;
var _E = 0;
var _F = 0;
var _G = 0;
var _H = 0;
var _I = 0;

//减
function Minus(value) {
    var temp = "";
    var parent = $(value).parents("section")
    if (parent.attr("id") == "B" && _B >= 0) { _B--; temp = _B }
    else if (parent.attr("id") == "C" && _C >= 0) { _C--; temp = _C }
    else if (parent.attr("id") == "D" && _D >= 0) { _D--; temp = _D }
    else if (parent.attr("id") == "E" && _E >= 0) { _E--; temp = _E }
    else if (parent.attr("id") == "F" && _F >= 0) { _F--; temp = _F }
    else if (parent.attr("id") == "G" && _G >= 0) { _G--; temp = _G }
    else if (parent.attr("id") == "H" && _H >= 0) { _H--; temp = _H }
    else if (parent.attr("id") == "I" && _I >= 0) { _I--; temp = _I }
    else return;

    $(value).parents("section").children("fieldset:last").remove()

    //控制 - + 号按钮显示隐藏
    if ($(parent).attr("min") <= temp && $(parent).attr("max") == 1) {
        $(parent).children("div:first").find("a:first").show();
        $(parent).children("div:first").find("a:last").hide();
    }
    else if ($(parent).attr("min") >= temp && $(parent).attr("max") == "n") {
        $(parent).children("div:first").find("a:first").show();
        $(parent).children("div:first").find("a:last").hide();
    }
    else if ($(parent).attr("min") == 0 && $(parent).attr("max") == 1 && temp >= $(parent).attr("max")) {
        $(parent).children("div:first").find("a:first").show();
        $(parent).children("div:first").find("a:last").hide();
    }
    else if ($(parent).attr("min") == 1 && $(parent).attr("max") == "n" && temp <= $(parent).attr("min")) {
        $(parent).children("div:first").find("a:last").hide();
    }
}

//增加
function Add(templateId) {
    var temp = "";
    var parent = $("#" + templateId).parents('section')
    if (parent.attr("id") == "A") { _A++; temp = _A }
    if (parent.attr("id") == "B") { _B++; temp = _B }
    if (parent.attr("id") == "C") { _C++; temp = _C }
    if (parent.attr("id") == "D") { _D++; temp = _D }
    if (parent.attr("id") == "E") { _E++; temp = _E }
    if (parent.attr("id") == "F") { _F++; temp = _F }
    if (parent.attr("id") == "G") { _G++; temp = _G }
    if (parent.attr("id") == "H") { _H++; temp = _H }
    if (parent.attr("id") == "I") { _I++; temp = _I }
    if (parent.attr("id") == "J") { _J++; temp = _J }
    if (parent.attr("id") == "K") { _K++; temp = _K }

    //0~1次当次数大于1次时不在显示
    if ($(parent).attr("max") == 1 && $(parent).attr("max") < temp) {
        return;
    }

    //temp>0显示-
    if (temp > 0) {
        if ($(parent).attr("min") < temp && $(parent).attr("max") == "n") {
            $(parent).children("div:first").find("a:last").show();
        }
        if ($(parent).attr("min") == 0 && $(parent).attr("max") == 1 && temp >= $(parent).attr("max")) {
            $(parent).children("div:first").find("a:first").hide();
            $(parent).children("div:first").find("a:last").show();
        }
    }

    var template = document.querySelector("#" + parent.children("template").attr("id"));
    if (template) {
        var clone = document.importNode(template, true);
    }

    $('<fieldset>').attr({ "id": parent.attr("id") + "_" + temp }).append($(clone).html()).appendTo("#" + parent.attr("id"))

    // jQuery解析
    $.parser.parse("#" + parent.attr("id") + "_" + temp);
}

// 提交
function Submit() {
    var data = {};
    var section = $("#content").find("section");
    //序列化数据
    var temp;
    for (var i = 0; i < section.length; i++) {
        var fs = new Array();
        temp = $(section[i]).attr("id");
        var fieldset = $(section[i]).children("fieldset");
        for (var j = 0; j < fieldset.length; j++) {
            fs.push($(fieldset[j]).serializeJson())
        }
        data[temp] = fs;
    }
    var str = JSON.stringify(data);
    $("#content").children().children(":hidden").find(":input.validatebox-text").validatebox("disableValidation");
    if (!$("#content").form("validate")) {
        $.messager.show({ msg: "请填写剩下的必填内容!" });
        return false;
    }

    $.ajax({
        async: true,
        data: { value: str, InfoTypeId: infoTypeId, ReportId: reportId, recordID: recordID, messageTypeID: messageTypeId },
        method: "POST",
        url: "../api/DynamicLoad/PostMessageInfo",
        statusCode: {
            200: function (data) {
                if (data == "") {
                    // 禁用提交、保存草稿和清空草稿按钮
                    $("#submit").linkbutton("disable");
                    $("#temp").linkbutton("disable");
                    $("#clear").linkbutton("disable");
                    // 删除临时数据
                    DeleteTempRecord();
                    top.$.messager.show({ msg: "保存成功！" });
                    setTimeout(function () {
                        Cancel();
                    }, 1000);
                }
            },
            500: function (data) {
                $.messager.alert('错误', data.responseJSON.ExceptionMessage);
            },
            400: function (data) {
                $.messager.alert('错误', data.responseJSON.Message, "info");
            }
        }
    });
}

// 取消按钮
function Cancel() {
    window.opener.location.href = window.opener.location.href;
    window.close()
}

