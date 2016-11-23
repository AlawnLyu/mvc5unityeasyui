$(function () {
    $("#btnDetails").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {

            $("#modalwindow").html("<iframe width='100%' height='98%' frameborder='0' src='/SysLog/Details?id=" + row.Id + "'></iframe>");
            $("#modalwindow").window({ title: '详细', width: 500, height: 400, iconCls: 'icon-details' }).window('open');
        } else { $.messageBox5s('提示', '请选择要操作的行！'); }
    });

    $("#btnQuery").click(function () {
        var queryStr = $("#txtQuery").val();
        //如果查询条件为空默认查询全部
        if (queryStr == null) {
            queryStr = "%";
        }
        $('#List').datagrid({ url: '/SysLog/GetList?queryStr=' + encodeURI(queryStr) });
    });

    $('#List').datagrid({
        url: '/SysLog/GetList?queryStr=',
        width: $(window).width() - 10,
        methord: 'post',
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
        columns: [[
            { field: 'Id', title: 'ID', width: 40, hidden: true },
            { field: 'Operator', title: '操作人', width: 40 },
            { field: 'Message', title: '信息', width: 280 },
            { field: 'Result', title: '结果', width: 40, align: 'center' },
            { field: 'Type', title: '类型', width: 40, align: 'center' },
            { field: 'Module', title: '模块', width: 60, align: 'center' },
            { field: 'CreateTime', title: '添加时间', width: 65, align: 'center' }
        ]]
    });
});

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
