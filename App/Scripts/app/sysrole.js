$(function () {
    $('#List').datagrid({
        url: '/SysRole/GetList',
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
            { field: 'Id', title: 'ID', width: 80, hidden: true },
            { field: 'Name', title: '角色名称', width: 80, sortable: true },
            { field: 'Description', title: '说明', width: 80, sortable: true },
            { field: 'CreateTime', title: '创建时间', width: 80, sortable: true },
            { field: 'CreatePerson', title: '创建人', width: 80, sortable: true },
            { field: 'UserName', title: '属下管理员', width: 80, sortable: true }
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
    $("#btnExport").click(function () {
        $("#modalwindow").html("<iframe width='100%' height='98%' scrolling='no' frameborder='0'' src='/SysHelper/ReportControl'></iframe>");
        $("#modalwindow").window({ title: '导出', width: 320, height: 200, iconCls: 'icon-add' }).window('open');
    });
    $("#btnCreate").click(function () {
        $("#modalwindow").html("<iframe width='100%' height='98%' scrolling='no' frameborder='0'' src='/SysRole/Create'></iframe>");
        $("#modalwindow").window({ title: '新增', width: 700, height: 400, iconCls: 'icon-add' }).window('open');
    });
    $("#btnEdit").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $("#modalwindow").html("<iframe width='100%' height='99%'  frameborder='0' src='/SysRole/Edit?id=" + row.Id + "'></iframe>");
            $("#modalwindow").window({ title: '编辑', width: 700, height: 430, iconCls: 'icon-edit' }).window('open');
        } else { $.messageBox5s('提示', '请选择要操作的记录！'); }
    });
    $("#btnDetails").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $("#modalwindow").html("<iframe width='100%' height='98%' scrolling='no' frameborder='0' src='/SysRole/Details?id=" + row.Id + "'></iframe>");
            $("#modalwindow").window({ title: '详细', width: 500, height: 300, iconCls: 'icon-details' }).window('open');
        } else { $.messageBox5s('提示', '请选择要操作的记录！'); }
    });
    $("#btnQuery").click(function () {
        var queryStr = $("#txtQuery").val();
        if (queryStr == null) {
            queryStr = "%";
        }
        $('#List').datagrid({
            url: '/SysRole/GetList?queryStr=' + encodeURI(queryStr)
        });

    });
    $("#btnDelete").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $.messager.confirm('提示', '您确定要删除所选记录吗？', function (r) {
                if (r) {
                    $.post("/SysRole/Delete?id=" + row.Id, function (data) {
                        if (data.type == 1)
                            $("#List").datagrid('load');
                        $.messageBox5s('提示', data.message);
                    }, "json");

                }
            });
        } else { $.messageBox5s('提示', '请选择要操作的记录！'); }
    });
    $("#btnAllot").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $("#modalwindow").html("<iframe width='100%' height='100%' scrolling='no' frameborder='0' src='/SysRole/GetUserByRole?roleId=" + row.Id + "'></iframe>");
            $("#modalwindow").window({ title: '分配用户', width: 720, height: 400, iconCls: 'icon-edit' }).window('open');
        } else { $.messageBox5s('提示', '请选择一个需要分配用户的角色'); }
    });
});