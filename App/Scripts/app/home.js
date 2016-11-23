$(function () {
    $('#tab_menu-tabrefresh').click(function () {
        /*重新设置该标签*/
        var url = $('.tabs-panels .panel').eq($('.tabs-selected').index()).find('iframe').attr('src');
        $('.tabs-panels .panel').eq($('.tabs-selected').index()).find('iframe').attr('src', url);
    });

    $('#tab_menu-openFrame').click(function () {
        /*在新窗口打开该标签*/
        var url = $('.tabs-panels .panel').eq($('.tabs-selected').index()).find('iframe').attr('src');
        window.open(url);
    });

    $('#tab_menu-tabclose').click(function () {
        /*关闭当前*/
        var currtab_title = $('.tabs-selected .tabs-inner span').text();
        $('#mainTab').tabs('close', currtab_title);
        if ($('.tabs li').length == 0) {
            //open menu
            $('.layout-button-right').trigger('click');
        }
    });

    $('#tab_menu-tabcloseall').click(function () {
        /*全部关闭*/
        $('.tabs-inner span').each(function (i, n) {
            if ($(this).parent().next().is('.tabs-close')) {
                var t = $(n).text();
                $('#mainTab').tabs('close', t);
            }
        });
        //open menu
        $('.layout-button-right').trigger('click');
    });

    $('#tab_menu-tabcloseother').click(function () {
        /*关闭除当前之外的tab*/
        var currtab_title = $('.tabs-selected .tabs-inner span').text();
        $('.tabs-inner span').each(function (i, n) {
            if ($(this).parent().next().is('.tabs-close')) {
                var t = $(n).text();
                if (t != currtab_title) {
                    $('#mainTab').tabs('close', t);
                }
            }
        });
    });

    $('#tab_menu-tabcloseright').click(function () {
        /*关闭当前右侧的tab*/
        var nextall = $('.tabs-selected').nextAll();
        if (nextall.length == 0) {
            $.messager.alert('提示', '前面没有了！', 'warning');
            return false;
        }
        nextall.each(function (i, n) {
            if ($('a.tabs-close', $(n)).length > 0) {
                var t = $('a:ep(0) span', $(n)).text();
                $('#mainTab').tabs('close', t);
            }
        });
        return false;
    });

    $('#tab_menu-tabcloseleft').click(function () {
        /*关闭当前右侧的tab*/
        var prevall = $('.tabs-selected').prevAll();
        if (prevall.length == 0) {
            $.messager.alert('提示', '后面没有了！', 'warning');
            return false;
        }
        prevall.each(function (i, n) {
            if ($('a.tabs-close', $(n)).length > 0) {
                var t = $('a:ep(0) span', $(n)).text();
                $('#mainTab').tabs('close', t);
            }
        });
        return false;
    });

    var o = {
        showcheck: false,
        url: '/Home/GetTree',
        onnodeclick: function (item) {
            var tabTitle = item.text;
            var url = '../../' + item.value;
            var icon = item.Icon;
            if (!item.hasChildren) {
                addTab(tabTitle, url, icon);
            } else {
                $(this).parent().find('img').trigger('click');
            }
        }
    };

    $.post('/Home/GetTree', { 'id': '0' }, function (data) {
        if (data == '0') {
            window.location = '/Account';
        }
        o.data = data;
        $('#RightTree').treeview(o);
    }, 'json');
});

$(function () {
    /*为选项卡绑定右键*/
    $('.tabs li').bind('contextmenu', function (e) {
        /*选中当前触发事件的选项卡*/
        var subtitle = $(this).text();
        $('mainTab').tabs('select', subtitle);
        /*显示快捷菜单*/
        $('#tab_menu').menu('show', { left: e.pageX, top: e.pageY });
        /*屏蔽浏览器自带右键菜单*/
        return false;
    });
});

function addTab(subtitle, url, icon) {
    if (!$('#mainTab').tabs('exists', subtitle)) {
        $('#mainTab').tabs('add', {
            title: subtitle,
            content: createFrame(url),
            closable: true,
            icon: icon
        });
    } else {
        $('#mainTab').tabs('select', subtitle);
        $('#tab_menu-tabrefresh').trigger('click');
    }
    $('.layout-button-left').trigger('click');
}

function createFrame(url) {
    var s = '<iframe frameborder="0" src="' + url + '" scrolling="auto" style="width:100%;height:99%;"></iframe>';
    return s;
}

$(function () {
    $('.ui-skin-nav .li-skinitem span').click(function () {
        var theme = $(this).attr('rel');
        $.messager.alert('提示', '切换皮肤将重新加载系统', function (r) {
            if (r) {
                $.post('../../Home/SetThemes',
                    { value: theme },
                    function (data) {
                        window.location.reload();
                    }, 'json');
            }
        });
    });
});