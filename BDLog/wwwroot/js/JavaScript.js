$(document).ready(function () {
    GetArea();
    $('#drpCell').attr('disabled', true);
    $('#drpMc').attr('disabled', true);
    $('#drpArea').change(function () {
        $('#drpCell').attr('disabled', false);
        GetCell();
    });

    $('#drpCell').change(function () {
        $('#drpMc').attr('disabled', false);
        GetMc();
    });

});

function GetArea() {
    $.ajax({
        url: '/Home/GetAreaDrp',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#drpArea').append('<Option value=' + data.areaId + '>' + data.areaName + '</Option>');
            });
        }
    });
}

function GetCell() {
    var id = $('#drpArea').val();
    $('#drpCell').empty();
    $('#drpCell').append('<Option>--Válassz cellát--</Option>');
    $.ajax({
        url: '/Home/GetCellDrp?id=' + id,
        success: function (result) {
            $.each(result, function (i, data) {
                $('#drpCell').append('<Option value=' + data.cellId + '>' + data.cellName + '</Option>');
            });
        }
    });

}

function GetMc() {
    var id = $('#drpCell').val();
    $('#drpMc').empty();
    $('#drpMc').append('<Option>--Válassz gépet--</Option>');
    $.ajax({
        url: '/Home/GetMcDrp?id=' + id,
        success: function (result) {
            $.each(result, function (i, data) {
                $('#drpMc').append('<Option value=' + data.mcId + '>' + data.mcName + '</Option>');
            });
        }
    });
}