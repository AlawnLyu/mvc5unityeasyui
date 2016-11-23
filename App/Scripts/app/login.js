$(function () {
    $('#LoginSys').click(function () {
        LoginSys();
    });

    $('#UserName').keydown(function (e) {
        var currkey = e.which;
        if (currkey == 13) {
            LoginSys();
            return false;
        }
    });

    $('#Password').keydown(function (e) {
        var currkey = e.which;
        if (currkey == 13) {
            LoginSys();
            return false;
        }
    });

    $('#ValidateCode').keydown(function (e) {
        var currkey = e.which;
        if (currkey == 13) {
            LoginSys();
            return false;
        }
    });
});

function LoginSys() {
    $('#mes').html('');
    $('#UserName').removeClass('input-validation-error');
    $('#Password').removeClass('input-validation-error');
    //$('#ValidateCode').removeClass('input-validation-error');

    if ($.trim($('#UserName').val()) == '') {
        $('#UserName').addClass('input-validation-error').focus();
        $('#mes').html('用户名不能为空！');
    }
    if ($.trim($('#Password').val()) == '') {
        $('#Password').addClass('input-validation-error').focus();
        $('#mes').html('密码不能为空！');
    }
    //if ($.trim($('#ValidateCode').val()) == '') {
    //    $('#ValidateCode').addClass('input-validation-error').focus();
    //    $('#mes').html('验证码不能为空！');
    //}

    $('#Loading').show();

    $.post('/Account/Login', { UserName: $("#UserName").val(), Password: $("#Password").val() },
            function (data) {

                if (data.type == "1") {
                    window.location = "/Home/Index";
                } else {
                    $("#mes").html(data.message);
                }
                $("#Loading").hide();
            }, "json");
    return false;
}