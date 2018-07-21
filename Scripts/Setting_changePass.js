$(document).ready(onDeviceReady);

user = new Object();
function onDeviceReady() {

    var files;
    user.Id = localStorage.getItem("UserID");

    $('input[type=file]').on('change', prepareUpload);
    function prepareUpload(event) {
        files = event.target.files;
    };
    $(':button').click(function () {
        var formData = new FormData();
        $.each(files, function (key, value) {
            formData.append(key, value);
            UserInfo.image = files[0].name;
        });
        alert(formData);
        $.ajax({
            url: 'BetseferWS.asmx/UploadImg',
            type: 'POST',
            data: JSON.stringify({ 'UserID': UserInfo.ID, 'Img': UserInfo.image }),
            //data: formData,
            success: function (data) {
                $('#result').html(data);
            },
            cache: false,
            contentType: false,
            processData: false
        });
    });

    $('body').fadeIn(500, function () {
        $('#CheckThePasswords').click(function () {
        pas1 = document.getElementById("pas1").value;
        pas2 = document.getElementById("pas2").value;

        if (pas1 === "" || pas2 === "") {

            swal({
                position: 'top-end',
                type: 'error',
                icon: "error",
                title: 'שגיאה ',
                text: "יש להזין את הסיסמה פעמיים",
                showConfirmButton: true,

            });

        }
        else if (pas1 === pas2) {
            user = new Object();
            user.Id = localStorage.getItem("UserID");
            user.password = pas1;
            SaveNewPassword(user, tellMeItsOk);
        }
        else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    icon: "error",
                    title: 'שגיאה ',
                    text: "הסיסמאות שהוזנו אינן תואמות",
                    showConfirmButton: true,

                });
                document.getElementById("pas1").value = "";
                document.getElementById("pas2").value = "";
              }
        });
    });
}

function tellMeItsOk(results) {
    res = $.parseJSON(results.d);
    if (res > 0) {
  
        swal({
            title: " סיסמתך שונתה בהצלחה!",
            icon: "success",
            showConfirmButton: false,
        });
        setTimeout(function () { ChangePage();}, 1000);
      
    }
    else {
        swal({
            position: 'top-end',
            icon: "error",
            type: 'error',
            title: 'תקלה ',
            text: "ארעה תקלה בעת שמירת הסיסמא. נא פנה לשירות הלקוחות",
            showConfirmButton: true,

        });
    }
}

function ChangePage() {

    var type = localStorage.getItem("UserType");
    if (type == 'Teacher') {
        window.location = 'TeacherDashbord.html';
    }
    else {
        window.location = 'AdminDashbord.html';
    }
}
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        //reader.onload = function (e) {
        //    $('#blah').attr('src', e.target.result);
        //}

        reader.readAsDataURL(input.files[0]);
    }
}

$("#imgInp").change(function () {
    readURL(this);
});

function uploadFile() {
    var frm = new FormData();
    frm.append('imageInput', input.files[0]);
    //$.ajax({
    //    url: "upload.php",
    //    type: "POST",
    //    data: formData,
    //    processData: false,
    //    contentType: false,
    //    success: function (response) {
    //        // .. do something
    //    },
    //    error: function (jqXHR, textStatus, errorMessage) {
    //        console.log(errorMessage); // Optional
    //    }
    //});
}