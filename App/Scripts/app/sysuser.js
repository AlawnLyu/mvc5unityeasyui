$(function () {
    $('#List').datagrid({
        url: '/SysUser/GetList',
        width: $(window).width() - 10,
        method: 'post',
        height: $(window).height() - 35,
        fitColumns: true,
        sortName: 'CreateTime',
        sortOrder: 'desc',
        idField: 'Id',
        pageSize: 15,
        pageList: [15, 20, 30, 40, 50],
        pagination: true,
        striped: true, //奇偶行是否区分
        singleSelect: true,//单选模式
        //rownumbers: true,//行号
        columns: [[
            { field: 'Id', title: '', width: 80, hidden: true },
            { field: 'UserName', title: '用户名', width: 80, sortable: true },
            { field: 'Password', title: '密码', width: 80, sortable: true, hidden: true },
            { field: 'TrueName', title: '真实姓名', width: 80, sortable: true },
            { field: 'Card', title: '', width: 80, sortable: true, hidden: true },
            { field: 'MobileNumber', title: '身份证', width: 80, sortable: true, hidden: true },
            { field: 'PhoneNumber', title: '手机号码', width: 80, sortable: true },
            { field: 'QQ', title: 'QQ', width: 80, sortable: true, hidden: true },
            { field: 'EmailAddress', title: '邮箱地址', width: 80, sortable: true, hidden: true },
            { field: 'OtherContact', title: '其他联系方式', width: 80, sortable: true, hidden: true },
            { field: 'Province', title: '省份', width: 80, sortable: true, hidden: true },
            { field: 'City', title: '城市', width: 80, sortable: true, hidden: true },
            { field: 'Village', title: '城镇', width: 80, sortable: true, hidden: true },
            { field: 'Address', title: '地址', width: 80, sortable: true, hidden: true },
            {
                field: 'Enable', title: '是否启用', width: 60, align: 'center', formatter: function (value) {
                    if (value) {
                        return "<img src='/Content/Images/icon/pass.png'/>";
                    } else {
                        return "<img src='/Content/Images/icon/no.png'/>";
                    }
                }
            },
            { field: 'CreateTime', title: '创建时间', width: 80, sortable: true },
            { field: 'CreatePerson', title: '创建人', width: 80, sortable: true },
            { field: 'Sex', title: '性别', width: 80, sortable: true, hidden: true },
            { field: 'Birthday', title: '生日', width: 80, sortable: true, hidden: true },
            { field: 'JoinDate', title: '加入日期', width: 80, sortable: true, hidden: true },
            { field: 'Marital', title: '婚姻', width: 80, sortable: true, hidden: true },
            { field: 'Political', title: '党派', width: 80, sortable: true, hidden: true },
            { field: 'Nationality', title: '民族', width: 80, sortable: true, hidden: true },
            { field: 'Native', title: '籍贯', width: 80, sortable: true, hidden: true },
            { field: 'School', title: '毕业学校', width: 80, sortable: true, hidden: true },
            { field: 'Professional', title: '就读专业', width: 80, sortable: true, hidden: true },
            { field: 'Degree', title: '学历', width: 80, sortable: true, hidden: true },
            { field: 'DepId', title: '部门', width: 80, sortable: true, hidden: true },
            { field: 'PosId', title: '职位', width: 80, sortable: true, hidden: true },
            { field: 'Expertise', title: '个人简介', width: 80, sortable: true, hidden: true },
            { field: 'JobState', title: '在职状况', width: 80, sortable: true, hidden: true },
            { field: 'Photo', title: '照片', width: 80, sortable: true, hidden: true },
            { field: 'Attach', title: '附件', width: 80, sortable: true, hidden: true },
        { field: 'Roles', title: '拥有角色', width: 80, sortable: true }
        ]]
    });
});
//ifram 返回
function frameReturnByClose() {
    $("#modalwindow").window('close');
}
function frameReturnByReload(flag) {
    if (flag)
        $("#List").datagrid('load');
    else
        $("#List").datagrid('reload');
}
function frameReturnByMes(mes) {
    $.messageBox5s('提示', mes);
}
$(function () {
    $("#btnCreate").click(function () {
        $("#modalwindow").html("<iframe width='100%' height='98%' frameborder='0'' src='/SysUser/Create'></iframe>");
        $("#modalwindow").window({ title: '新增', width: 700, height: 400, iconCls: 'icon-add' }).window('open');
    });
    $("#btnEdit").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $("#modalwindow").html("<iframe width='100%' height='99%'  frameborder='0' src='/SysUser/Edit?id=" + row.Id + "'></iframe>");
            $("#modalwindow").window({ title: '编辑', width: 700, height: 430, iconCls: 'icon-edit' }).window('open');
        } else { $.messageBox5s('提示', '请选择要操作的数据！'); }
    });
    $("#btnDetails").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $("#modalwindow").html("<iframe width='100%' height='98%' frameborder='0' src='/SysUser/Details?id=" + row.Id + "'></iframe>");
            $("#modalwindow").window({ title: '详细', width: 500, height: 300, iconCls: 'icon-details' }).window('open');
        } else { $.messageBox5s('提示', '请选择要操作的数据！'); }
    });
    $("#btnQuery").click(function () {
        var queryStr = $("#txtQuery").val();
        if (queryStr == null) {
            queryStr = "%";
        }
        $('#List').datagrid({
            url: '/SysUser/GetList?queryStr=' + encodeURI(queryStr)
        });

    });
    $("#btnDelete").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $.messager.confirm('提示', '您确定要删除所选数据吗？', function (r) {
                if (r) {
                    $.post("/SysUser/Delete?id=" + row.Id, function (data) {
                        if (data.type == 1)
                            $("#List").datagrid('load');
                        $.messageBox5s('提示', data.message);
                    }, "json");

                }
            });
        } else { $.messageBox5s('提示', '请选择要操作的数据！'); }
    });

    $("#btnAllot").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $("#modalwindow").html("<iframe width='100%'  height='100%' scrolling='auto' frameborder='0' src='/SysUser/GetRoleByUser?userId=" + row.Id + "'></iframe>");
            $("#modalwindow").window({ title: '分配角色', width: 720, height: 400, iconCls: 'icon-edit' }).window('open');
        } else { $.messageBox5s('提示', '请选择要操作的数据！'); }
    });
});