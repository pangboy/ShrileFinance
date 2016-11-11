// 获取Url参数
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

// 禁用
function Disabled(selector) {
    selector = selector || "fieldset";

    $(selector).attr("disabled", "disabled");
    //$(selector + " select.easyui-combobox").combobox("disable");
}