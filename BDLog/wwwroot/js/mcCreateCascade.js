$(document).ready(function () {
    GetArea();
    $('#drpArea').change(function () {
        GetCell();
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