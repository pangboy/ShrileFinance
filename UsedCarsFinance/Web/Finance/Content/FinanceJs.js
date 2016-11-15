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

// Json序列化
$.fn.serializeJson = function () {
    var obj = {};
    var array = this.serializeArray();

    var selector = this.selector;

    if (!!window.ActiveXObject || "ActiveXObject" in window) {
        array = $(this).parents("form").serializeArray();

        array = $.map(array, function (val) {
            if ($("[name=" + val.name + "]").parents(selector).length)
                return val;
        });
    }

    $.each(array, function (i, e) {
        if (obj[e.name] !== undefined) {
            if (!obj[e.name].push) {
                obj[e.name] = [obj[e.name]];
            }
            obj[e.name].push(e.value || '');
        } else {
            obj[e.name] = e.value || '';
        }
    });

    return obj;
};

// fieldset 数据序列化工厂（type: text or table）
function FieldsetSerializeFactory(name, type) {
    if (name == null || type == null || $.inArray(type, ["text", "table"]) == -1) {
        return null;
    }

    var json = new Object();

    if ($("fieldset[name=" + name + "]").length > 0) {
        if (type == "text") {
            // 序列化 text
            json = $("fieldset[name=" + name + "]").serializeJson();
        }
        else {
            // 序列化 table
            var json = $("fieldset[name=" + name + "]").find("[id=" + name + "_dg" + "]").datagrid("getRows");
        }
    }

    return json;
}

// fieldset 数据加载工厂（type: text or table）
function FieldsetLoadDateFactory(name, type, data) {
    if (name == null || type == null || $.inArray(type, ["text", "table"]) == -1 || !data) {
        return null;
    }

    if ($("fieldset[name=" + name + "]").length > 0) {
        if (type == "text") {
            // 加载数据 text
            $("fieldset[name=" + name + "]").form('load', data);
        }
        else {
            // 加载数据 table
            $(data).each(function (index, item) {
                // 加载数据 table
                $("fieldset[name=" + name + "]").find("[id=" + name + "_dg" + "]").datagrid('appendRow', item);;
            });
        }
    }

    return data;
}
