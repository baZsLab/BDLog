$(document).ready(function () {
    GetArea();
    $('#drpArea').change(function () {       
        GetCell();
    });
    $('#drpCell').change(function () {        
        GetMc();
    });
    $('#drpMc').change(function () {
        GetUnit();
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

function GetUnit() {
    var id = $('#drpMc').val();
    $('#drpUnit').empty();
    $('#drpUnit').append('<Option>--Válassz gépegységet--</Option>');
    $.ajax({
        url: '/Home/GetMcUnitDrp?id=' + id,
        success: function (result) {
            $.each(result, function (i, data) {
                $('#drpUnit').append('<Option value=' + data.unitId + '>' + data.unitName + '</Option>');
            });
        }
    });
}