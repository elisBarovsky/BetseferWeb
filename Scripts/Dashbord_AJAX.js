var path = "";
var isCordovaApp = document.URL.indexOf('http://') === -1 && document.URL.indexOf('https://') === -1;
if (isCordovaApp) {
    path = "https://proj.ruppin.ac.il/bgroup52/prod/";
}
else path = "";

function LoadAllMessagesById(Id, DisplayMessages) {
    $.ajax({
        url: path+ 'BetseferWS.asmx/GetMessagesByUserIdUnread',
        data: JSON.stringify({ 'userId': Id }),
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            DisplayMessages(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
    });
}

function UpdateMessageAsRead(i) {
    $.ajax({
        url: path+ 'BetseferWS.asmx/SetMessageAsRead',
        data: JSON.stringify({ 'MessageCode': i }),
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {

        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
    });
}

function LoadScheduleForToday(obj, DisplaySchedule) {
    $.ajax({
        url: path+ 'BetseferWS.asmx/LoadScheduleForToday',
        data: JSON.stringify({ 'Id': obj.Id, 'userType': obj.userType }),
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            DisplaySchedule(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
    });
}

function GetNumbersOfUsers(DisplayPieUsers) {
    $.ajax({
        url: path + 'BetseferWS.asmx/GetNumbersOfUsersForPie',
        data: JSON.stringify({ }),
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            DisplayPieUsers(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
    });
}

function GetTeachersToSubjects(DisplayBarTeachersSubjects) {
    $.ajax({
        url: path + 'BetseferWS.asmx/GetTeachersToSubjectsBar',
        data: JSON.stringify({}),
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            DisplayBarTeachersSubjects(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
    });
}
