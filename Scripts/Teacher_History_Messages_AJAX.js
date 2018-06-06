function LoadAllMessagesById(teacherId, DisplayMessages) {
    $.ajax({
        url: 'BetseferWS.asmx/GetMessagesByUserId',
        data: JSON.stringify({ 'userId': teacherId }),
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

function UpdateMessageAsRead(MessageCode, SuccsiedUpdateMessage) {
    $.ajax({
        url: 'BetseferWS.asmx/UpdateMessageAsRead',
        data: JSON.stringify({ 'MessageCode': MessageCode }),
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            SuccsiedUpdateMessage(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
    });
}

