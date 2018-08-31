
function getCookie(name) { //获取cookie  
    var aCookie = document.cookie.split('; ');
    for (var i = 0; i < aCookie.length; i++) {
        var aName = aCookie[i].split('=');
        if (aName[0] == name) {
            return aName[1];
        }
        return '';
    }
} 
function setCookie(name, value, iDate) {
    var oDate = new Date();
    oDate.setDate(oDate.getDate() + iDate);
    document.cookie = name + '=' + value + ';path=/;expires=' + oDate;
}
