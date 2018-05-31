function LoadAllMessagesById(UserFullInfo, DisplayMessages) {
    $.ajax({
        url: 'BetseferWS.asmx/GetMessagesByUserId',
        data: JSON.stringify({ 'userId': UserFullInfo.Id }),
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


