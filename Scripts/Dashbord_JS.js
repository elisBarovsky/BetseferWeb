$(document).ready(function () {
    var Id = localStorage.getItem("UserID");
    var z = localStorage.getItem("UserImg");
    document.getElementById('imgUser').src = z;
    document.getElementById('UserImgimg').src = z;
    
    //LoadAllMessagesById(teacherId, DisplayMessages);
});
