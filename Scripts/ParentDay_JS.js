﻿$(document).ready(function () {

    var userID = localStorage.getItem("UserID");

    IfMehanech_LoadParentDay(userID, ShowParentsDay);

    
});




function ShowParentsDay(results) {

    if (results === "no") { // this teacher don't has a main class

        $("#noMehanech").show();
        $("#parentsDayTable").hide();
        return;
    }

    res = $.parseJSON(results.d);

    if (res["ParentsDayDate"] === null) { // there is no parents day open
        $("#noMehanech").hide();
        $("#parentsDayTable").hide();

        var tr1 = document.createElement('tr');
        var td1 = document.createElement('td');
        var td2 = document.createElement('td');
        var text = document.createTextNode('בחר מועד:');
        var input = document.createElement('input');
        input.type = "date";
        input.className = "form-control";
        input.id = "parentsDayDate";

        td1.appendChild(text);
        td2.appendChild(input);
        tr1.appendChild(td1);
        tr1.appendChild(td2);

        $("#createNewDay").append(tr1);

        var tr2 = document.createElement('tr');
        var td3 = document.createElement('td');
        var td4 = document.createElement('td');
        var text = document.createTextNode('שעת התחלה:');
        var input = document.createElement('input');

        td3.appendChild(text);
        td4.appendChild(input);
        tr2.appendChild(td3);
        tr2.appendChild(td4);

        $("#createNewDay").append(tr2);

        var tr3 = document.createElement('tr');
        var td5 = document.createElement('td');
        var td6 = document.createElement('td');
        var text = document.createTextNode('שעת סיום:');
        var input = document.createElement('input');

        td5.appendChild(text);
        td6.appendChild(input);
        tr3.appendChild(td5);
        tr3.appendChild(td6);

        $("#createNewDay").append(tr3);

        var tr4 = document.createElement('tr');
        var td7 = document.createElement('td');
        var td8 = document.createElement('td');
        var text = document.createTextNode('משך פגישה:');
        var input = document.createElement('input');
        

        td7.appendChild(text);
        td8.appendChild(input);
        tr4.appendChild(td7);
        tr4.appendChild(td8);

        $("#createNewDay").append(tr4);
        
    return;
    }

    // show the existing parents day
    $("#parentsDayTable").show();
    $("#noMehanech").hide();
};

