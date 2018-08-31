function money() {
    var f = Math.round(document.getElementById("Totalmoney").value * 100) / 100;
    var s = f.toString();
    var rs = s.indexOf('.');
    if (rs < 0) {
        rs = s.length;
        s += '.';
    }
    while (s.length <= rs + 2) {
        s += '0';
        document.getElementById("Totalmoney").value = s;
        var totalmoney = s;
    }
    if (s == 0.00) {
        document.getElementById("Totalmoney").value = "";
    }
    //不含税金额
    document.getElementById("Notaxmoney").value = totalmoney - (totalmoney / 1.06 * 0.06).toFixed(2);
    if (document.getElementById("Notaxmoney").value == 0) {
        document.getElementById("Notaxmoney").value = "";
    }
    //预估毛利
    var fores= document.getElementById("Forecast").value
    fores = document.getElementById("Notaxmoney").value - document.getElementById("cost").value
    var fore = fores.toFixed(2);
    document.getElementById("Forecast").value = fore
    if (document.getElementById("Forecast").value == 0) {
        document.getElementById("Forecast").value = "";
    }
}