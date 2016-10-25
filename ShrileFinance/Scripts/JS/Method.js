
//判断是否是子类
function OnSelect(value) {
    if (value.children != undefined) {
        alert('请选择子类！');
        return false;
    }
}

// 不可编辑下拉框onChange事件
function SpecialOnSelect() {
    //当选择业务种类类型时候
    var count = $('fieldset .easyui-combobox');//下拉框个数
    var countData = $('fieldset .easyui-datebox');//时间控件个数
    var countInput = $('fieldset .easyui-textbox');//文本框个数
    var businessType = $(this).combobox('getValue');
    var PanretMetaCode = $(this).attr("meta_code")
    var OldID = "";
    var parentID = "";
    //状态为信用卡
    for (var i = 0; i < countData.length; i++) {
        if ($(countData[i]).attr("meta_code") == '2103') {
            if (businessType == 2) {
                $(countData[i]).textbox('setValue', '20991231').textbox("readonly", true);//选择信用卡时到期日期为20991231
            } else {
                $(countData[i]).textbox('setValue', '').textbox("readonly", false);
            }
        }
    }
    for (var i = 0; i < countInput.length; i++) {
        //选择信用卡时逾期31-60天未归还贷款本金 填0        //选择信用卡时逾期61-90天未归还贷款本金 填0     //选择信用卡时逾期91-180天未归还贷款本金 填0   //逾期180天以上未归还贷款本金 填0
        if ($(countInput[i]).attr("meta_code") == '1113' || $(countInput[i]).attr("meta_code") == '1115' || $(countInput[i]).attr("meta_code") == '1117' || $(countInput[i]).attr("meta_code") == '1119') {
            businessType == 2 ? $(countInput[i]).textbox('setValue', '0').textbox("readonly", true) : $(countInput[i]).textbox('setValue', '').textbox("readonly", false);
        }
        else if ($(countInput[i]).attr("meta_code") == '4101' || $(countInput[i]).attr("meta_code") == '4105') {
            businessType == 2 ? $(countInput[i]).textbox('setValue', 'C').textbox('readonly', true) : $(countInput[i]).textbox('setValue', '').textbox('readonly', false);
        }
        else { continue }
    }
    for (var i = 0; i < count.length; i++) {
        if ($(count[i]).attr("meta_code") == '7109') {
            OldID = $(count[i]).attr("id");
            parentID = $(count[i]).parents("fieldset").attr("id");
        }
        else if ($(count[i]).attr("meta_code") == '7111') {
            OldID = $(count[i]).attr("id");
            parentID = $(count[i]).parents("fieldset").attr("id");
        }
        else if ($(count[i]).attr("meta_code") == '4111') {
            OldID = $(count[i]).attr("id");
            parentID = $(count[i]).parents("fieldset").attr("id");
        }
        else {
            continue;
        }
        $.ajax({
            async: false,
            method: "GET",
            data: { MetaCode: $(count[i]).attr("meta_code"), PanretMetaCode: PanretMetaCode, BusinessType: businessType },
            url: "../api/Method/ComboLoad",
            statusCode: {
                200: function (data) {
                    $("#" + parentID + " #" + OldID + "").combobox("clear").combobox("loadData", data);
                }
            }
        })
    }

}

//动态加载下拉框中的数据
function ComboOnselect() {
    var OldID = this.id;//ID
    var ID = this.id.substring(1, this.id.length);//去掉段标识的ID
    var ParentID = $(this).parents("fieldset").attr("id")
    $.ajax({
        async: true,
        method: "GET",
        data: { SegmentRulesID: ID },
        url: "../api/Method/ComboInfoLoad",
        statusCode: {
            200: function (data) {
                $("#" + ParentID + " #" + OldID + "").combobox("loadData", data);
            }
        }
    })
}
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
    else if (parent.attr("id") == "J" && _J >= 0) { _J--; temp = _J }
    else if (parent.attr("id") == "K" && _K >= 0) { _K--; temp = _K }
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
    $('<fieldset>').attr({ "id": parent.attr("id") + "_" + temp }).append(clone.children).appendTo("#" + parent.attr("id"))
    $.parser.parse("#" + parent.attr("id") + "_" + temp);
    var aa = $("#" + parent.attr("id") + "_" + temp + " select");
    for (var i = 0; i < aa.length; i++) {
        if (aa[i].id == "D29" || aa[i].id == "D27" || aa[i].id == "F530" || $(aa[i]).attr("meta_code") == '3141' || $(aa[i]).attr("meta_code") == '7111' || $(aa[i]).attr("meta_code") == '7109') { }//去掉combotree的选项以及去掉个人中的带条件筛选的
        else if ($(aa[i]).attr("meta_code") == '7515') {
            ChangeType($(aa[i]))
        }
        else {
            ComboboxLoad(parent.attr("id") + "_" + temp, aa[i].id);
        }
    }
}

//通用的下拉框加载
function ComboboxLoad(fleidsetID, segmentRulesID) {
    $("#" + fleidsetID + " #" + segmentRulesID + "").combobox({
        method: "GET",
        queryParams: { SegmentRulesID: segmentRulesID.substring(1, segmentRulesID.length) },
        url: '../api/Method/ComboInfoLoad',
        valueField: 'value',
        textField: 'text'
    });
}


