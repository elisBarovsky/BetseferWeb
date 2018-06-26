$(document).ready(function () {
    var teacherId = localStorage.getItem("UserID");
    var z = getUserImg();
    var userName = localStorage.getItem("UserFullName");
    document.getElementById('imgUser').src = z;
    document.getElementById('imgUser1').src = z;
    document.getElementById('UserName').innerHTML = userName;

    LoadAllMessagesById(teacherId, DisplayMessages);
});

function getUserImg() {
    var img = localStorage.getItem("UserImg");
    return img;
};

//window.onload = function () {
//    document.getElementById('imgUser').src = getUserImg();
//};

function DisplayMessages(results) {

    res = $.parseJSON(results.d);

    $('#messagesTable').empty();

    var tableString = "";

    for (var i = 0; i < res.length; i++) {
        var objMessage = new Object();
        objMessage.MessageCode = res[i].MessageCode;
        objMessage.MessageDate = res[i].MessageDate;
        objMessage.SenderID = res[i].SenderID;
        objMessage.SenderName = res[i].SenderName;
        objMessage.SubjectMessage = res[i].SubjectMessage;
        objMessage.TheMessage = res[i].TheMessage;

        tableString += "<tr onclick = 'OpenMessage(" + JSON.stringify(objMessage) + ")'><td id = '" + res[i].MessageCode + "'></td><td class='mailbox-star'><a href='#'><i class='fa fa-star text-yellow'></i></a></td><td>" +
            res[i].MessageDate + "</td><td>" + res[i].SubjectMessage + "</td><td>" + res[i].SenderName + "</td></tr>";
    }
    $('#messagesTable').append(tableString);
};

var a = null;
function OpenMessage(obj) {
    localStorage.setItem("messageDetails", JSON.stringify(obj));
    var i = obj.MessageCode;
    UpdateMessageAsRead(i);
    a = window.open("OpenMessageWindow.html", "window", "toolbar=no,scrollbars=yes,resizable=yes,top=50%,left=25%,width=500,height=600,modal=yes");

    a.focus();
    document.onmousedown = a;
    document.onkeyup = a;
    document.onmousemove = a;
    //window.open.href = "OpenMessageWindow.html";
  //  window.location.href = "OpenMessageWindow.html";
};

function parent_disable() {
    if (a && !a.closed)
        a.focus();

}
//function SuccsiedUpdateMessage(results) {
//    var res = results.d;
//};