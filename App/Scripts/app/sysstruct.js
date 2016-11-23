$(function () {
    $('#List').treegrid({
        url: '/SysStruct/GetList',
        width: $(window).width() - 10,
        methord: 'post',
        height: $(window).height() - 35,
        fitColumns: true,
        treeField: 'Name',
        idField: 'Id',
        pagination: false,
        striped: true,
        singleSelect: true,
        //rownumbers:true,
        columns: [[
            { field: 'Id', title: 'ID', width: 80, hidden: true },
            { field: 'Name', title: '名称', width: 80, sortable: true },
            { field: 'ParentId', title: '上级ID', width: 80, sortable: true },
            { field: 'Sort', title: '排序', width: 80, sortable: true },
            { field: 'Higher', title: '', width: 80, sortable: true, hidden: true },
            {
                field: 'Enable', title: '是否启用', widht: 60, align: 'center', formatter: function (value) {
                    if (value) {
                        return '<img src="/Content/Images/icon/pass.png"/>';
                    }
                    return '<img src="/Content/Images/icon/no.png"/>';
                }
            },
            { field: 'Remark', title: '说明', width: 80, sortable: true },
            { field: 'CreateTime', title: '创建时间', width: 80, sortable: true }
        ]]
    });
});
//ifram 返回
function frameReturnByClose() {
    $("#modalwindow").window('close');
}
function frameReturnByReload(flag) {
    if (flag)
        $("#List").treegrid('load');
    else
        $("#List").treegrid('reload');
}
function frameReturnByMes(mes) {
    $.messageBox5s('提示', mes);
}
$(function () {
    $("#btnCreate").click(function () {
        var row = $('#List').treegrid('getSelected');
        $('#modalwindow').html('<iframe width="100%" height="99%" scrolling="no" frameborder="0" src="/SysStruct/Create?id=' + (row == null ? "0" : row.Id) + '"></iframe>');
        $("#modalwindow").window({ title: '新增', width: 700, height: 400, iconCls: 'icon-add' }).window('open');
    });
    $("#btnEdit").click(function () {
        var row = $('#List').treegrid('getSelected');
        if (row != null) {
            $("#modalwindow").html("<iframe width='100%' height='99%'  frameborder='0' src='/SysStruct/Edit?id=" + row.Id + "'></iframe>");
            $("#modalwindow").window({ title: '编辑', width: 700, height: 430, iconCls: 'icon-edit' }).window('open');
        } else { $.messageBox5s('提示', '请选择要操作的记录'); }
    });
    $("#btnDelete").click(function () {
        var row = $('#List').treegrid('getSelected');
        if (row != null) {
            $.messager.confirm('提示', '您确定要删除所选记录吗？', function (r) {
                if (r) {
                    $.post("/SysStruct/Delete?id=" + row.Id, function (data) {
                        if (data.type == 1)
                            $("#List").treegrid('load');
                        $.messageBox5s('提示', data.message);
                    }, "json");

                }
            });
        } else { $.messageBox5s('提示', '请选择要操作的记录'); }
    });
});