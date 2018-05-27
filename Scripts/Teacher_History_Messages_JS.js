﻿$(document).ready(function () {
   // var teacherId = localStorage.getItem("UserID");
    UserFullInfo = new Object();
    UserFullInfo.Id = localStorage.getItem("UserID");
    GetUserInfo(UserFullInfo, DisplayUser);
   // LoadAllMessagesById(teacherId, DisplayMessages);
});

function DisplayUser(results) {

    res = $.parseJSON(results.d);

    UserImgimg.src = "";
    UserName.text = "";

};



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

function OpenMessage(obj) {
    localStorage.setItem("messageDetails", JSON.stringify(obj));
    var a = window.open("OpenMessageWindow.html", "", "toolbar=no,scrollbars=yes,resizable=yes,top=50%,left=25%,width=500,height=600");
    //window.open.href = "OpenMessageWindow.html";
  //  window.location.href = "OpenMessageWindow.html";
};
