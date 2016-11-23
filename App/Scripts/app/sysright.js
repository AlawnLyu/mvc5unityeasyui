$(function () {
    var curModuleId, curRoleId, curModuleName, curRoleName, curSystemId, curSystemName;//选择的模块ID,选中的角色ID，选中的模块名称，角色名称
    curRoleName = "?";
    curModuleName = "?";

    $('#roleList').datagrid({
        url: '/SysRight/GetRoleList',
        width: 420,
        method: 'post',
        height: $(window).height() - 35,
        fitColumns: true,
        sortName: 'CreateTime',
        sortOrder: 'desc',
        idField: 'Id',
        pageSize: 15,
        pageList: [15, 30, 50],
        pagination: true,
        striped: true,
        singleSelect: true,
        rownumbers: true,
        title: '角色列表',
        columns: [[
            { field: 'Id', title: '', width: 80, hidden: true },
            { field: 'Name', title: '角色组', width: 80, sortable: true },
                { field: 'Description', title: '说明', width: 80, sortable: true },
                { field: 'CreateTime', title: '创建时间', width: 80, sortable: true },
                { field: 'CreatePerson', title: '', width: 80, sortable: true, hidden: true }
        ]],
        onClickRow: function (index, data) {
            var row = $('#roleList').datagrid('getSelected');
            if (row != null) {
                curRoleName = row.Name;
                curRoleId = row.Id;
                $('#operateList').datagrid({
                    url: '/SysRight/GetRightByRoleAndModule?roleId=' + curRoleId + '&moduleId=' + curModuleId
                });
                $('#operateList').datagrid({ title: '角色组：' + curRoleName + '>>模块：' + curModuleName });
            }
        }
    });

    $('#moduleList').treegrid({
        url: '/SysRight/GetModuleList',
        width: 300,
        method: 'post',
        height: $(window).height() - 35,
        fitColumns: true,
        treeField: 'Name',
        idField: 'Id',
        pagination: false,
        striped: true,
        singleSelect: true,
        title: '模块列表',
        columns: [[
            { field: 'Id', title: '唯一标识', width: 120, hidden: true },
                { field: 'Name', title: '名称', width: 220, sortable: true },
                { field: 'EnglishName', title: '英文名称', width: 80, sortable: true, hidden: true },
                { field: 'ParentId', title: '上级Id', width: 80, sortable: true, hidden: true },
                { field: 'Url', title: '链接地址', width: 80, sortable: true, hidden: true },
                { field: 'Iconic', title: '图标', width: 80, sortable: true, hidden: true },
                { field: 'Sort', title: '排序号', width: 80, sortable: true, hidden: true },
                { field: 'Remark', title: '说明', width: 80, sortable: true, hidden: true },
                {
                    field: 'Enable', title: '是否启用', width: 60, align: 'center', formatter: function (value) {
                        if (value) {
                            return "<img src='/Content/Images/icon/pass.png'/>";
                        } else {
                            return "<img src='/Content/Images/icon/no.png'/>";
                        }
                    }, hidden: true
                },
                { field: 'CreatePerson', title: '创建人', width: 80, sortable: true, hidden: true },
                { field: 'CreateTime', title: '创建时间', width: 120, sortable: true, hidden: true },
                {
                    field: 'IsLast', title: '是否最后一项', align: 'center', width: 100, formatter: function (value) {
                        if (value) {
                            return "是";
                        } else {
                            return "否";
                        }
                    }, hidden: true
                }
        ]],
        onClickRow: function (index, data) {
            var row = $('#moduleList').treegrid('getSelected');
            if (row != null) {
                curModuleId = row.Id;
                curModuleName = row.Name;
                if (curRoleId == null && row.IsLast) {
                    $.messageBox5s('提示', "请再选择一个角色！");
                    return;
                }
                $('#operateList').datagrid({
                    url: '/SysRight/GetRightByRoleAndModule?roleId=' + curRoleId + '&moduleId=' + curModuleId
                });
                $('#operateList').datagrid({ title: '角色组：' + curRoleName + '>>模块：' + (row.IsLast ? curModuleName : "[请再选择最后菜单项]") });
            }
        }
    });

    $('#operateList').datagrid({
        url: '/SysRight/GetRightByRoleAndModule',
        width: $(window).width() - 736,
        method: 'post',
        height: $(window).height() - 35,
        ficColumns: true,
        sortName: 'CreateTime',
        sortOrder: 'desc',
        idField: 'Id',
        striped: true,
        singleSelect: true,
        title: '授权操作',
        //rownumbers: true,
        columns: [[
            { field: 'Ids', title: 'Ids', width: 80, hidden: true },
                { field: 'Name', title: '名称', width: 80, sortable: true },
                { field: 'KeyCode', title: '操作码', width: 80, sortable: true },
                {
                    field: 'IsValid', title: "<a href='#' title='选择'  onclick=\"SelAll();\"  ><img src='/Content/Images/icon/select.gif'></a>  <a href='#' title='反选'  onclick=\"UnSelAll();\"  ><img src='/Content/Images/icon/unselect.gif'></a>", align: 'center', width: 60, formatter: function (value) {
                        if (value) {
                            return "<input type='checkbox' checked='checked' value=" + value + " />";
                        } else {
                            return "<input type='checkbox' value=" + value + " />";
                        }
                    }
                },
                  { field: 'RightId', title: '模块ID', width: 80, sortable: true, hidden: true }
        ]]
    });

    $('#btnSave').click(function () {
        var updateRows = 0;
        //获取当前页的所有行
        var rows = $('#operateList').datagrid('getRows');
        for (var i = 0; i < rows.length; i++) {
            var setFlg = $('td[field="IsValid"] input').eq(i).prop('checked');
            //判断是否有做修改
            if (rows[i].IsValid != setFlg) {
                $.post('/SysRight/UpdateRight', {
                    "Id": rows[i].Ids,
                    "RightId": rows[i].RightId,
                    "KeyCode": rows[i].KeyCode,
                    "IsValid": setFlg
                }, 'json');
                updateRows++;
            }
        }
        if (updateRows > 0) {
            $.messageBox5s('提示', '保存成功！');
        } else {
            $.messageBox5s('提示', '没有作任何修改！');
        }
    });

    $(window).resize(function () {
        $('#operateList').datagrid('resize', {
            width: $(window).width() - 736,
            height: $(window).height() - 35
        }).datagrid('resize', {
            width: $(window).width() - 736,
            height: $(window).height() - 35
        });
        $('#moduleList,#roleList').datagrid('resize', {
            height: $(window).height() - 35
        }).datagrid('resize', {
            height: $(window).height() - 35
        });
    });
});

function SelAll() {
    $("td[field='IsValid'] input").prop("checked", true);
    $("#btnSave").trigger("click");
    return;
}
function UnSelAll() {
    $("td[field='IsValid'] input").prop("checked", false);
    $("#btnSave").trigger("click");
    return;
}