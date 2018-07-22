$(document).ready(function () {
    var teacherId = localStorage.getItem("UserID");
    var z = getUserImg();
    var userName = localStorage.getItem("UserFullName");
    document.getElementById('imgUser').src = z;
    document.getElementById('UserNameSpan').innerHTML = userName;

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

        var objExam = new Object();
        objExam.examCode = res[i].examCode;
        objExam.subject = res[i].subject;
        objExam.date = res[i].date;
        objExam.className = res[i].className;

        str += "<tr onclick = 'OpenGrades(" + JSON.stringify(objExam) +
            ")'><td><i class='fa fa-star text-yellow'></i></td><td>" + res[i].date +
            "</td><td>" + res[i].subject + "</td><td>" + res[i].className + "</td></tr>";
    }
    $('#gradesTable').append(str);
};

function OpenGrades(objExam) {
    localStorage.setItem("examDetails", JSON.stringify(objExam));

    window.location.href = "OpenTestGradesWindow.html";
};