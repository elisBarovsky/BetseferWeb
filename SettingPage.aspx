<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SettingPage.aspx.cs" Inherits="pages_recover_changePass" %>

<!DOCTYPE html>
<html lang="en" dir="rtl">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>שינוי סיסמה</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">

    <!-- v4.0.0-alpha.6 -->
    <link rel="stylesheet" href="dist/bootstrap/css/bootstrap.min.css">

    <!-- Google Font -->
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet">

    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/style.css">
    <link rel="stylesheet" href="dist/css/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="dist/css/et-line-font/et-line-font.css">
    <link rel="stylesheet" href="dist/css/themify-icons/themify-icons.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
<![endif]-->
        <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
        <style>
        .container {
            display: inline-block;
            cursor: pointer;
            margin-top: 10px;
        }

        .bar1, .bar2, .bar3 {
            width: 35px;
            height: 5px;
            margin: 6px 2px;
            transition: 0.4s;
        }
    </style>
  <script type="text/javascript">

           function Succesesalert(msg) {
            swal({
                title: 'בוצע!',
                text: msg,
                type: 'success',
                icon: "success",
                showConfirmButton: true
                });
            
            };
     
            function Erroralert(msg) {
            swal({
                title: 'שגיאה!',
                text: msg,
                type: 'error',
                icon: "error",
                showConfirmButton: true
                });
                 //setTimeout(function () {
                 //    window.location.href = "login.aspx";
                 //}, 1000);
      };

      function Dashbord() {

    var type = localStorage.getItem("UserType");
    if (type == 'Teacher') {
        window.location = 'TeacherDashbord.html';
    }

    else {
        window.location = 'AdminDashbord.html';
    }
}
    </script>

</head>
<body>
       <div class="container" onclick="Dashbord()">
        <div class="bar1" style="background-color:palevioletred"></div>
        <div class="bar2" style="background-color:fuchsia"></div>
        <div class="bar3" style="background-color:deepskyblue"></div>
    </div>
    <form id="form1" runat="server">
        <body class="hold-transition login-page">
            <div class="login-box">
                <div class="login-box-body">
                    <h3 class="login-box-msg m-b-1">הגדרות</h3>
                    <p>בחר סיסמה חדשה והזן אותה פעמיים </p>
                    <form action="index.html" method="post">

                        <div class="form-group has-feedback">
                            <p ID="LabelSecurityQ1" contenteditable="false" runat="server"> </p>
                            <asp:Label  runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="Pass1" runat="server" TextMode="Password" class="form-control sty1" placeholder="הזן סיסמה"></asp:TextBox>
               <asp:RegularExpressionValidator ID="valPassword" runat="server" BorderStyle="Groove" Font-Size="Medium" ControlToValidate="Pass1"
                                                ErrorMessage="סיסמא צריכה להכיל לפחות 4 תוים" ValidationExpression=".{4}.*" />
                            <br />
                            <p ID="LabelSecurityQ2"  contenteditable="false" runat="server"> </p>
                            <asp:TextBox ID="Pass2" runat="server" class="form-control sty1" TextMode="Password" placeholder="הזן סיסמה בשנית"></asp:TextBox>
                        </div>
                          <div>
                            <div class="col-xs-4 m-t-1">
                  <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-block btn-flat" Text="שנה סיסמה" OnClick="ChangePasswordBTN" />

                            </div>
                            <!-- /.col -->
                              <br /><br />
                              <div class="col-xs-4 m-t-1">
                                  <fieldset class="form-group" runat="server">
                                                <label class="custom-file center-block block">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" class="custom-file-input" />
                                                    <span class="custom-file-control"></span>
                                                </label>
                                            </fieldset>
                  <asp:Button ID="Button2" runat="server" class="btn btn-primary btn-block btn-flat" Text="העלאת תמונה" OnClick="UploadImgBTN" />

                            </div>
                        </div>
                    </form>
                </div>
                <!-- /.login-box-body -->
            </div>
            <!-- /.login-box -->

            <!-- jQuery 3 -->
            <script src="dist/js/jquery.min.js"></script>

            <!-- v4.0.0-alpha.6 -->
            <script src="dist/bootstrap/js/bootstrap.min.js"></script>

            <!-- template -->
            <script src="dist/js/niche.js"></script>
    </form>
</body>
</html>
