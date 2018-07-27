$(document).ready(function () {
    var Id = localStorage.getItem("UserID");
    var z = localStorage.getItem("UserImg");
    var userName = localStorage.getItem("UserFullName");
    document.getElementById('imgUser').src = z;
    document.getElementById('UserNameSpan').innerHTML = userName;

    obj = new Object()
    obj.Id = Id;
    obj.userType = "2";
    //var Date = new Date();
    //obj.weekDay = Date.getDay();

    LoadAllMessagesById(Id, DisplayMessages);

    LoadScheduleForToday(obj, DisplaySchedule);
    GetNumbersOfUsers(DisplayPieUsers);
    GetTeachersToSubjects(DisplayBarTeachersSubjects);
    GetTeacherNotePerMonth(Id, DisplayPaiNoteDate);
   GetAvgByClassesByTeacherID(Id, DisplayBarCharAvgGradesPerClass);
});

function DisplayPieUsers(results) {
    var res = $.parseJSON(results.d);

    new Chart(document.getElementById("pie-chart"), {
        type: 'pie',
        data: {
            labels:
                ['מנהלה', 'מורים', 'הורים', 'תלמידים'],
            datasets:
                [{
                    'label': 'מנהלה',
                    data:
                        [res[0], res[1], res[2], res[3]],
                    backgroundColor:
                        ['rgb(255, 99, 132)',
                            'rgb(54, 162, 235)',
                            'rgb(255, 205, 86)',
                            'rgb(211, 247, 6)']
                }]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'התפלגות משתמשים'
            }
        }
    });
}

function DisplayBarTeachersSubjects(results) {
    var res = $.parseJSON(results.d);
    var subjects = [];
    var numbers = [];
    var counter = 0;
    for (var i = 0; i < res.length; i++) {
        if (i < res.length / 2) {
            subjects[i] = res[i];
        }
        else {
            numbers[counter] = res[i];
            counter++;
        }
    }

    var ctx = document.getElementById('bar-chart').getContext('2d');
    var chart = new Chart(ctx, {
        // The type of chart we want to create
        type: 'horizontalBar',

        // The data for our dataset
        data: {
            labels: subjects,
            datasets: [{
                label: "מורים בכל מקצוע",
                backgroundColor: 'rgb(255, 105, 100)',
                borderColor: 'rgb(88, 103, 221)',
                data: numbers,
                fill: false

            }]
        },
        options: {
            scales: {
                xAxes: [{
                    ticks: {
                        beginAtZero: true,
                        stepSize: 1,
                    }
                }]
            },
            title: {
                display: true,
                text: 'פילוח מקצועות ומורים'
            }
        }
    });
}

function DisplayPaiNoteDate(results) {
    var res = $.parseJSON(results.d),
        monthList = [], amountList = [], counter = 0, coloR = [];

    for (var i = 0; i < res.length; i++) {
        if (i < res.length / 2) {
            monthList[i] = res[i];
        }
        else {
            amountList[counter] = res[i];
            counter++;
        }
    }   

    var dynamicColors = function () {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);
        return "rgb(" + r + "," + g + "," + b + ")";
    };

    for (var i in monthList) {
        coloR.push(dynamicColors());
    }

    new Chart(document.getElementById("pie-chart2"), {
        type: 'pie',
        data: {
            labels: monthList,
            datasets:
                [{
                    'label': 'כמות',
                    data: amountList,
                    backgroundColor: coloR
                }]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'מספר הערות משמעת לפי חודשים'
            }
        }
    });
}

function DisplayBarCharAvgGradesPerClass(results) {
    var res = $.parseJSON(results.d);
    var classes = [];
    var avgGrades = [];
    var counter = 0;
    for (var i = 0; i < res.length; i++) {
        if (i < res.length / 2) {
            classes[i] = res[i];
        }
        else {
            avgGrades[counter] = res[i];
            counter++;
        }
    }

    var ctx = document.getElementById('bar-chart2').getContext('2d');
    var chart = new Chart(ctx, {
        // The type of chart we want to create
        type: 'bar',

        // The data for our dataset
        data: {
            labels: classes,
            datasets: [{
                label: "ממוצע",
                backgroundColor: 'rgb(255, 105, 100)',
                borderColor: 'rgb(88, 103, 221)',
                data: avgGrades,
                fill: false
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true,
                        stepSize: 10,
                    }
                }]
            },
            title: {
                display: true,
                text: 'ממוצע ציונים בכיתות שלי'
            }
        }
    });
}

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
                title: "בעיית אבטחה",
                text: 'אתה עדיין משתמש בסיסמה הראשונית, תרצה להחליף אותה כעת?',
                icon: "info",
                buttons: ["כן", "לא"],
                dangerMode: true
            })
                .then((willDelete) => {
                    if (willDelete) {
                        swal("נזכיר לך שוב בהתחברות הבאה!");
                    } else {

                        var currentLocation = window.location;
                        var n = currentLocation['pathname'].search(/TeacherDashbord/);
                        //alert(currentLocation);
                        //alert(n);
                        if (n > 0) {
                            window.location.href = "SettingPage_Teacher.aspx";
                        }
                        else {

                            window.location.href = "SettingPage_Admin.aspx";
                        }
                       
                    }
                });
        }
        sessionStorage.setItem("Loged", 1);
    }
};