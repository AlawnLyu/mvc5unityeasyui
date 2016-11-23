$(function () {
    $('#btnCreate').click(function () {
        $('#modalwindow').html('<iframe width="100%" height="98%" scrolling="no" frameborder="0" src="/SysSample/Create"></iframe>');
        $('#modalwindow').window({ title: '新增', width: 700, height: 400, iconCls: 'icon-add' }).window('open');
    });

    $('#btnEdit').click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $('#modalwindow').html('<iframe width="100%" height="99%" scrolling="no" frameborder="0" src="/SysSample/Edit?id=' + row.Id + '&Ieguid=' + GetGuid() + '"></iframe>');
            $('#modalwindow').window({ title: '编辑', width: 700, height: 430, iconCls: 'icon-edit' }).window('open');
        } else {
            $.messageBox5s('提示', '请选择要操作的记录');
        }
    });

    $('#btnDetails').click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $('#modalwindow').html('<iframe width="100%" height="98%" scrolling="no" frameborder="0" src="/SysSample/Details?id=' + row.Id + '&Ieguid=' + GetGuid() + '"></iframe>');
            $('#modalwindow').window({ title: '详细', width: 500, height: 300, iconCls: 'icon-details' }).window('open');
        } else {
            $.messageBox5s('提示', '请选择要操作的记录');
        }
    });

    $('#btnDelete').click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $.messager.confirm('提示', '确定删除', function (r) {
                if (r) {
                    $.post('/SysSample/Delete?id=' + row.Id, function (data) {
                        if (data.type == 1)
                            frameReturnByReload(false);
                        $.messageBox5s('提示', data.message);
                    }, 'json');
                }
            });
        } else {
            $.messageBox5s('提示', '请选择要操作的记录');
        }
    });

    $('#btnQuery').click(function () {
        var queryStr = $('#txtQuery').val();
        if (queryStr == null) {
            queryStr = '%';
        }
        $('#List').datagrid({
            url: '/SysSample/GetList?queryStr=' + encodeURI(queryStr)
        });
    });

    $('#List').datagrid({
        url: '/SysSample/GetList?queryStr=',
        width: $(window).width() - 10,
        method: 'post',
        height: $(window).height() - 35,
        fitcolumns: true,
        sortName: 'Id',
        sortOrder: 'desc',
        idField: 'Id',
        pageSize: 15,
        pageList: [15, 30, 45],
        pagination: true,
        striped: true,
        singleSelect: true,
        rownumbers: true,
        columns: [[
            { field: 'Id', title: 'ID', width: 80, hidden: true },
            { field: 'Name', title: '名称', width: 120 },
            { field: 'Age', title: '年龄', width: 80, align: 'right' },
            { field: 'Bir', title: '生日', width: 80, align: 'right' },
            { field: 'Phote', title: '照片', width: 250 },
            { field: 'Note', title: '说明', width: 60, align: 'center' },
            { field: 'CreateTime', title: '创建时间', width: 60, align: 'center' }
        ]]
    });
});

function frameReturnByClose() {
    $('#modalwindow').window('close');
}

function frameReturnByReload(flag) {
    if (flag) {
        $('#List').datagrid('load');
    } else {
        $('#List').datagrid('reload');
    }
}

function frameReturnByMes(mes) {
    $.messageBox5s('提示', mes);
}

//生成唯一的GUID
function GetGuid() {
    var s4 = function () {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    };
    return s4() + s4() + s4() + "-" + s4();
}