﻿$(document).ready(onDeviceReady);


function onDeviceReady() {
    document.getElementById("Q1").innerHTML = localStorage.getItem("QQ1") + "?";

    document.getElementById("Q2").innerHTML = localStorage.getItem("QQ2") + "?";


 
    $('#CheckMyAns').click(function () {
        ans1 = document.getElementById("ans11").value;
        ans2 = document.getElementById("ans21").value;
        q1 = localStorage.getItem("ans1");
        q2 = localStorage.getItem("ans2");

        if (ans1 === "" || ans2 === "") {

            swal({
                position: 'top-end',
                type: 'error',
                icon: "error",
                title: 'שגיאה- עליך לענות על שתי השאלות',
                showConfirmButton: true,

            });
         
        }
        else if (q1 === ans1 && q2 === ans2) {
            document.location.href = "pages-recover-changePass.html";
        }
    });


}