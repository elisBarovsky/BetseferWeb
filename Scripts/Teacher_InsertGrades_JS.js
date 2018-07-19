$(document).ready(function () {
    $('#ChooseClassLBL').hide();
    $('#ChooseClassDLL').hide();
    $('#save').hide();
    var teacherId = localStorage.getItem("UserID");
    var z = getUserImg();
    var userName = localStorage.getItem("UserFullName");
    document.getElementById('imgUser').src = z;
    document.getElementById('imgUser1').src = z;
    document.getElementById('UserName').innerHTML = userName;

    LoadSubjectsByTeacherID(teacherId, DisplaySubjects);
});

function getUserImg() {
    var img = localStorage.getItem("UserImg");
    return img;
};

function DisplaySubjects(results) {
    res = $.parseJSON(results.d);
    $('#DDLsubjectsAccordingToTeacherID').empty();

    var dynamicLy = "<option value='0'>בחר</option>";
    $('#DDLsubjectsAccordingToTeacherID').append(dynamicLy);

    for (var i = 0; i < res.length; i++) {
        dynamicLy = " <option value='" + res[i] + "' style='text- align:right'>" + res[i] + "</option> ";
        $('#DDLsubjectsAccordingToTeacherID').append(dynamicLy);
    }
};

function SubjectSelected() {
    var subject = $('#DDLsubjectsAccordingToTeacherID').val();
    if (subject !== "בחר") {
        LoadClassesAccordingToTeacherIdAndSubject(localStorage.getItem("UserID"), subject, DisplayClasses);
    }
};

function DisplayClasses(results) {
    res = $.parseJSON(results.d);
    $('#ChooseClassDLL').empty();
    $('#ChooseClassLBL').show();
    $('#ChooseClassDLL').show();
    
    var dynamicLy = "<option value='0'>בחר</option>";
    $('#ChooseClassDLL').append(dynamicLy);

    for (var i = 0; i < res.length; i++) {
        dynamicLy = " <option value='" + res[i] + "' style='text- align:right'>" + res[i] + "</option> ";
        $('#ChooseClassDLL').append(dynamicLy);
    }
};

function ClassSelected() {
    var selectedClass = $('#ChooseClassDLL').val();
    if (selectedClass !== "בחר") {
        LoadPupilsAccordingToClass(selectedClass, DisplayPupils);
    }
};

function DisplayPupils(results) {
    res = $.parseJSON(results.d);
    $('#pupilList').empty();
    var tableString = "<tr><td>ת.ז.</td><td>שם</td><td>ציון</td></tr>";

    for (var i = 0; i < res.length; i++) {
        var pupil = new Object();
        pupil.UserID = res[i].UserID;
        pupil.FullName = res[i].FullName;

        tableString += "<tr><td>" + pupil.UserID + "</td><td>" + res[i].FullName + "</td><td>" +
            "<input type='number' pattern='[0–9]' maxlength='3' min='0' max='100' required class = 'grades' id = '" + pupil.UserID + "'></input></td></tr>";
    }
    $('#pupilList').append(tableString);
    $('#save').show();
};

function SaveGrades() {
    var grades = $(".grades"), pupilGrades = [], subject = $('#DDLsubjectsAccordingToTeacherID').val(),
        date = $('#date1').val();
    if (date === "dd/mm/yyyy" || date === "") {
        //alert("לא נבחר תאריך");
        swal({
            title: "אופס",
            text: "לא נבחר תאריך",
            icon: "warning",
        });
        return;
    }

    var dateDifferentFormat = date.split('-');
    date = dateDifferentFormat[2] + "/" + dateDifferentFormat[1] + "/" + dateDifferentFormat[0];
    var d = new Date(),
        today = d.getDate() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear();

    if (date > today) { //check if the date that selected was passed.
        swal({
            title: "אופס",
            text: "נבחר תאריך עתידי",
            icon: "warning",
        });
        //alert("נבחר תאריך עתידי");
        return;
    }
        

    for (var i = 0; i < grades.length; i++) {
        var grade = new Object();
        grade.subject = subject;
        grade.date = date;
        grade.teacherID = localStorage.getItem("UserID");
        grade.pupilID = grades[i].id;

        var plus, minus, point;
        plus = grades[i].value.includes("+");
        minus = grades[i].value.includes("-");
        point = grades[i].value.includes(".");

        if (grades[i].value === "" || grades[i].value > 100 || grades[i].value < 0 || plus || minus || point) {
            //alert("הנתונים לא תקינים. יש לשים לב שהוזנו מספרים בלבד!");
            swal({
                title: "נתונים לא תקינים",
                text: "יש לשים לב שהוזנו מספרים בלבד בין 0 ל-100",
                icon: "warning",
            });
            return;
        }

        grade.grade = grades[i].value;

        pupilGrades.push(grade);
    }

    SaveGradesAjax(pupilGrades, AfterSaveGrades);
};

function AfterSaveGrades(results) {
    res = $.parseJSON(results.d);
    if (res == 1) {
        //swal("", "ציונים הוזנו בהצלחה", "success");
        document.getElementById('date1').value = "";
        $('#pupilList').empty();
        $('#ChooseClassDLL').empty();
        $('#ChooseClassLBL').hide();
        $('#ChooseClassDLL').hide();
        $('#save').hide();
        LoadSubjectsByTeacherID(localStorage.getItem("UserID"), DisplaySubjects);
    }
    else {
        alert("נתקלנו בבעיה בשמירת הציונים, נא נסה שנית");
    }
};