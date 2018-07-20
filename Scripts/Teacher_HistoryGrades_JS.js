$(document).ready(function () {
    var teacherId = localStorage.getItem("UserID");
    var z = getUserImg();
    var userName = localStorage.getItem("UserFullName");
    document.getElementById('imgUser').src = z;
    document.getElementById('imgUser1').src = z;
    document.getElementById('UserName').innerHTML = userName;

    LoadTestsGradesByTeacherID(teacherId, DisplayTests);
});

function getUserImg() {
    var img = localStorage.getItem("UserImg");
    return img;
};

function DisplayTests(results) {
    res = $.parseJSON(results.d);
    var str = "";
    for (var i = 0; i < res.length; i++) {

        var objTest = new Object();

        str += "<tr onclick = 'OpenGrades(" + res[i].examCode +
            ")'><td><i class='fa fa-star text-yellow'></i></td><td>" + res[i].date +
            "</td><td>" + res[i].subject + "</td><td>" + res[i].className + "</td></tr>";
    }
    $('#gradesTable').append(str);
};

function OpenGrades(examCode) {
    localStorage.setItem("examCode", examCode);

    window.location.href = "OpenTestGradesWindow.html";
};