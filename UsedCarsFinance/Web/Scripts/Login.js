$(function () {
	$("#username").focus().textbox({
		required: true,
		width: "100%",
		height: "40px",
		prompt: "请输入用户名",
		iconCls: "icon-man",
		iconWidth: 38
	});

	$("#password").textbox({
		required: true,
		width: "100%",
		height: "40px",
		prompt: "请输入密码",
		type: "password",
		iconCls: "icon-lock",
		iconWidth: 38
	});

	$("#submit").linkbutton({
		width: "100%",
		height: "40px",
		text: "登录",
		iconCls: "icon-ok",
		onClick: Login
	});

	$(document).keydown(function (e) {
		if (e.keyCode == 13) {
			if (!$(".messager-window")[0]) {
				Login();
			}
		}
	});
});

function Login() {
	var isVaild = $("#login").form("validate");

	if (isVaild) {
		var username = $("#username").textbox("getValue");
		var password = $("#password").textbox("getValue");

		Loading("正在登录，请稍后...");

		$.ajax({
			async: false,
			data: { Username: username, Password: password },
			url: "api/User/SignIn",
			method: "POST",
			statusCode: {
				200: function (data) {
					location.href = "Index.html";
				},
				400: function (xhr) {
					$.messager.alert("登录失败!", xhr.responseJSON.Message, "info");
				}
			}
		});

		LoadEnd();
	} else {
		$.messager.alert("登录失败!", "用户名和密码不能为空!");
	}
}

function Loading(content) {
	$("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: "100%", height: $(window).height() }).appendTo("body");
	$("<div class=\"datagrid-mask-msg\"></div>").html(content).appendTo("body").css({ display: "block", left: ($(document.body).outerWidth(true) - 190) / 2, top: 400});
}

function LoadEnd() {
	$(".datagrid-mask").remove();
	$(".datagrid-mask-msg").remove();
}