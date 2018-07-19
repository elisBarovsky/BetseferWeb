var path = "";
var isCordovaApp = document.URL.indexOf('http://') === -1 && document.URL.indexOf('https://') === -1;
if (isCordovaApp) {
    path = "https://proj.ruppin.ac.il/bgroup52/prod/";
}
else
    path = "";

function LoadSubjectsByTeacherID(teacherId, DisplaySubjects) {
    $.ajax({
        url: path + 'BetseferWS.asmx/LoadSubjectsByTeacherID',
        data: JSON.stringify({ 'teacherId': teacherId }),
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            DisplaySubjects(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
    });
}

function LoadClassesAccordingToTeacherIdAndSubject(teacherId, subject, DisplayClasses) {
    $.ajax({
        url: path + 'BetseferWS.asmx/LoadClassesAccordingToTeacherIdAndSubject',
        data: JSON.stringify({ 'teacherId': teacherId, 'subject': subject }),
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            DisplayClasses(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
    });
};

function LoadPupilsAccordingToClass(selectedClass, DisplayPupils) {
    $.ajax({
        url: path + 'BetseferWS.asmx/GetPupilsListByClassTotalName',
        data: JSON.stringify({ 'Class': selectedClass }),
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            DisplayPupils(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
    });
};

function SaveGradesAjax(pupilGrades, AfterSaveGrades) {
    $.ajax({
        url: path + 'BetseferWS.asmx/SaveClassGrades',
        data: JSON.stringify({ 'pupilGrades': pupilGrades }),
        type: 'POST',
        dataType: "json",
        contentType: 'application/json; charset = utf-8',
        success: function (results) {
            AfterSaveGrades(results);
        },
        error: function (request, error) {
            alert('Network error has occurred please try again!');
        }
    });
};

// 