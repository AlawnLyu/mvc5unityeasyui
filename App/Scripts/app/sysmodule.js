$(function () {
    $('#List').treegrid({
        url: '/SysModule/GetList',
        width: $(window).width() - 270,
        method: 'post',
        height: $(window).height() - 35,
        fitColumns: true,
        treeField: 'Name',
        idField: 'Id',
        pagination: false,
        striped: true,
        singleSelect: true,
        //rownumbers:true,
        columns: [[
        { field: 'Id', title: '唯一标识', width: 120 },
        { field: 'Name', title: '名称', width: 220, sortable: true },
        { field: 'EnglishName', title: '英文名称', width: 80, sortable: true, hidden: true },
        { field: 'ParentId', title: '上级ID', width: 80, sortable: true },
        { field: 'Url', title: '链接地址', width: 80, sortable: true },
        { field: 'Iconic', title: '图标', widht: 80, sortable: true },
        { field: 'Sort', title: '排序号', widht: 80, sortable: true },
        { field: 'Remark', title: '说明', width: 80, sortable: true },
        {
            field: 'Enable', title: '是否启用', widht: 60, align: 'center', formatter: function (value) {
                if (value) {
                    return '<img src="/Content/Images/icon/pass.png"/>';
                }
                return '<img src="/Content/Images/icon/no.png"/>';
            }
        },
        { field: 'CreatePerson', title: '创建人', width: 80, sortable: true },
        { field: 'CreateTime', title: '创建时间', width: 120, sortable: true },
            {
                field: 'IsLast', title: '是否最后一项', width: 100, align: 'center', formatter: function (value) {
                    if (value) {
                        return "是";
                    }
                    return "否";
                }
            }
        ]],
        onClickRow: function (index, data) {
            var row = $('#List').treegrid('getSelected');
            if (row != null) {
                $('#OptList').datagrid({
                    url: '/SysModule/GetOptListByModule?mid=' + row.Id
                });
            }
        }
    });

    $('#OptList').datagrid({
        url: '/SysModule/GetOptListByModule',
        width: 255,
        method: 'post',
        height: $(window).height() - 35,
        fitColumns: true,
        sortName: 'Sort',
        sortOrder: 'asc',
        idField: 'Id',
        pageSize: 1000,
        pagination: false,
        striped: true,
        singleSelect: true,
        //rownumbers: true,
        columns: [[
            { field: 'Id', title: '', width: 80, hidden: true },
            { field: 'Name', title: '名称', width: 80, sortable: true },
            { field: 'KeyCode', title: '操作码', width: 80, sortable: true },
            { field: 'ModuleId', title: '所属模块', width: 80, sortable: true, hidden: true },
            {
                field: 'IsValid', title: '是否验证', width: 80, align: 'center', formatter: function (value) {
                    if (value) {
                        return "<img src='/Content/Images/icon/pass.png'/>";
                    }
                    return "<img src='/Content/Images/icon/no.png'/>";
                }
            },
            { field: 'Sort', title: '排序号', width: 80, sortable: true }
        ]]
    });

    //自动宽高
    $(window).resize(function () {
        $('#List').treegrid('resize', {
            width: $(window).width() - 270,
            height: $(window).height() - 35
        }).treegrid('resize', {
            width: $(window).width() - 270,
            height: $(window).height() - 35
        });
        $('#OptList').datagrid('resize', {
            height: $(window).height() - 35
        }).datagrid('resize', {
            height: $(window).height() - 35
        });
    });
});

//iframe 返回
function frameReturnByClose() {
    $("#modalwindow").window('close');
}
function frameReturnByReload(flag) {
    if (flag)
        $("#List").treegrid('reload');
    else
        $("#List").treegrid('load');
}
function frameReturnByReloadOpt(flag) {
    if (flag)
        $("#OptList").datagrid('load');
    else
        $("#OptList").datagrid('reload');
}
function frameReturnByMes(mes) {
    $.messageBox5s('提示', mes);
}

$(function () {
    $('#btnCreate').click(function () {
        var row = $('#List').treegrid('getSelected');
        $('#modalwindow').html('<iframe width="100%" height="99%" scrolling="no" frameborder="0" src="/SysModule/Create?id=' + (row == null ? "0" : row.Id) + '"></iframe>');
        $('#modalwindow').window({ title: '新增', width: 700, height: 400, iconCls: 'icon-add' }).window('open');
    });

    $('#btnEdit').click(function () {
        var row = $('#List').treegrid('getSelected');
        if (row != null) {
            $('#modalwindow').html('<iframe width="100%" height="99%" scrolling="no" frameborder="0" src="/SysModule/Edit?id=' + row.Id + '"></iframe>');
            $('#modalwindow').window({ title: '编辑', width: 700, height: 430, iconCls: 'icon-edit' }).window('open');
        } else {
            $.messageBox5s('提示', '请选择要操作的记录！');
        }
    });

    $('#btnDelete').click(function () {
        var row = $('#List').treegrid('getSelected');
        if (row != null) {
            $.messager.confirm('提示', '您确定要删除所选记录吗？', function (r) {
                if (r) {
                    $.post('/SysModule/Delete?id=' + row.Id, function (data) {
                        if (data.type == 1) {
                            $('#List').treegrid('reload');
                        }
                        $.messageBox5s('提示', data.message);
                    }, 'json');
                }
            });
        } else {
            $.messageBox5s('提示', '请选择要操作的记录！');
        }
    });

    $("#btnCreateOpt").click(function () {
        var row = $('#List').treegrid('getSelected');
        if (row != null) {
            if (row.IsLast) {
                $("#modalwindow").html("<iframe width='100%' height='99%'  frameborder='0' src='/SysModule/CreateOpt?moduleId=" + row.Id + "'></iframe>");
                $("#modalwindow").window({ title: '新增操作码', width: 500, height: 330, iconCls: 'icon-edit' }).window('open');

            } else {
                $.messageBox5s('提示', '只有最后一项的菜单才能设置操作码!');
            }

        } else {
            $.messageBox5s('提示', '请选择一个要赋予操作码的模块!');
        }
    });

    $("#btnDeleteOpt").click(function () {
        var row = $('#OptList').datagrid('getSelected');
        if (row != null) {
            $.messager.confirm('提示', '您确定要删除“' + row.Name + '”这个操作码？', function (r) {
                if (r) {
                    $.post("/SysModule/DeleteOpt?id=" + row.Id, function (data) {
                        if (data.type == 1) {
                            $("#OptList").datagrid('load');
                        }
                    }, "json");
                }
            });
        } else {
            $.messageBox5s('提示', '请选择一个要赋予操作码的模块!');
        }
    });
});