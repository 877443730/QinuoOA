// 导入Excel
function importExcel() {
    var file = $("#filed").val();
    if (file == null || file.length == 0) {
        alert("请先上传文件");
        return false;
    }
    $('#file-from').ajaxSubmit({
        type: 'post', // HTTP请求方式
        url: '/File/Fileds', // 请求的URL地址
        dataType: 'text',
        data: {
            projectname: s
        },
        success: function (data) {
            var d = eval('(' + data + ')');
            if (d == "上传失败请选择项目!") {
                layer.msg(d, {
                    icon: 5
                });
                return;
            } else if (d != "上传失败请选择项目!") {
                layer.msg("上传成功", {
                    icon: 1
                });
            }
        }
    });
}
function importExcel1() {
    var file = $("#filed1").val();
    if (file == null || file.length == 0) {
        alert("请先上传文件");
        return false;
    }
    $('#file-from2').ajaxSubmit({
        type: 'post', // HTTP请求方式
        url: '/File/Fileds1', // 请求的URL地址
        dataType: 'text',
        data: {
            projectname: s
        },
        success: function (data) {
            var d = eval('(' + data + ')');
            if (d == "上传失败请选择项目!") {
                layer.msg(d, {
                    icon: 5
                });
                return;
            } else if (d != "上传失败请选择项目!") {
                layer.msg("上传成功", {
                    icon: 1
                });
            }
        }
    });
}
function importExcel2() {
    var file = $("#filed2").val();
    if (file == null || file.length == 0) {
        alert("请先上传文件");
        return false;
    }
    $('#file-from3').ajaxSubmit({
        type: 'post', // HTTP请求方式
        url: '/File/Fileds2', // 请求的URL地址
        dataType: 'text',
        data: {
            projectname: s
        },
        success: function (data) {
            var d = eval('(' + data + ')');
            if (d == "上传失败请选择项目!") {
                layer.msg(d, {
                    icon: 5
                   
                });
                return;
            }
            else if (d != "上传失败请选择项目!") {
                layer.msg("上传成功", {
                    icon: 1
                });
            } 
        }
    });
}
function importExcel3() {
    var projectname = $("#projectname").val();
    var file = $("#fileds").val();
    if (file == null || file.length == 0) {
        alert("请先上传文件");
        return false;
    }
    $('#file-froms').ajaxSubmit({
        type: 'post', // HTTP请求方式
        url: '/File/Fileds3', // 请求的URL地址
        dataType: 'text',
        data: {
            projectname: projectname
        },
        success: function (data) {
            var d = eval('(' + data + ')');
            if (d == "上传失败请选择项目!") {
                layer.msg(d, {
                    icon: 5
                });
                return;
            }
            else if (d != "上传失败请选择项目!") {
                layer.msg("上传成功", {
                    icon: 1
                });
            }
        }
    });
}