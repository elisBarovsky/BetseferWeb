﻿$(document).ready(function () {
    var Id = localStorage.getItem("UserID");
    var z = localStorage.getItem("UserImg");
    var userName = localStorage.getItem("UserFullName");
    document.getElementById('imgUser').src = z;
    document.getElementById('imgUser1').src = z;
    document.getElementById('UserName').innerHTML = userName;

    obj = new Object()
    obj.Id = Id;
    obj.userType = "2";
    //var Date = new Date();
    //obj.weekDay = Date.getDay();

    LoadAllMessagesById(Id, DisplayMessages);

    LoadScheduleForToday(obj, DisplaySchedule);
});

function DisplayMessages(results) {

    res = $.parseJSON(results.d);
    if (res.length === 0) {
        $('#noNewMessages').show();
        return;
    }
    else $('#noNewMessages').hide();

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
        objMessage.IconId = "icon" + i;

        tableString += "<tr style = 'color: black;' onclick = 'OpenMessage(" + JSON.stringify(objMessage) + ")'><td id = '" + res[i].MessageCode +
            "'></td><td class='mailbox-star'><a href='#'><i id = '" + objMessage.IconId +
            "' class='fa fa-envelope-o'></i></a></td><td>" + res[i].MessageDate + "</td><td>" +
            res[i].SubjectMessage + "</td><td>" + res[i].SenderName + "</td></tr>";
    }
    $('#messagesTable').append(tableString);
};
var a = null;

function OpenMessage(obj) {
    localStorage.setItem("messageDetails", JSON.stringify(obj));
    var i = obj.MessageCode, iconID = obj.IconId;
    UpdateMessageAsRead(i);
    $(iconID).removeClass('fa fa-envelope-o').addClass('fa fa-envelope-open-o');

    a = window.open("OpenMessageWindow.html", "window", "toolbar=no,scrollbars=yes,resizable=yes,top=50%,left=25%,width=500,height=600,modal=yes");

    a.focus();
    document.onmousedown = a;
    document.onkeyup = a;
    document.onmousemove = a;
};

function parent_disable() {
    if (a && !a.closed)
        a.focus();
}

function DisplaySchedule(results) {
    res = $.parseJSON(results.d);
    if (res.length === 0) {
        $('#noSchedule').show();
    }
    else {
        $('#noSchedule').hide();

        var tableString = "<tr><td colspan='2'>יום " + res[0].WeekDay +"</td></tr>";
        var day = res[0].WeekDay;
        var counter = 0;

        for (var i = 1; i < 10; i++) {

            if (counter < res.length && i.toString() === res[counter].ClassTimeCode) {
                tableString += "<tr><td> " + res[counter].lessonHours + "</td>";
            }
            else tableString += "<tr><td> - </td>";

            if (counter < res.length && i.toString() === res[counter].ClassTimeCode) {

                tableString += "<td>" + res[counter].LessonName + ", " + res[counter].ClassName + "</td>";
                counter++;
            }
            tableString += "</tr>";
        }
        $('#looze').append(tableString);
    }

    var AlreadyLogged = sessionStorage.getItem('Loged');
    if (AlreadyLogged != "1") {

        if (localStorage.getItem("PasswordTB") == '1234') {
            swal({
                position: 'top-end',
                type: 'error',
                icon: "error",
                title: 'בעיית אבטחה',
                text: 'אתה עדיין משתמש בסיסמה הראשונית, תחליף אותה בהגדרות כאמצעי זהירות',
                showConfirmButton: true,

            });
        }
        sessionStorage.setItem("Loged", 1);

    }
};