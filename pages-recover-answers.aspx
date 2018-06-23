<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pages-recover-answers.aspx.cs" Inherits="pages_recover_answers" %>

<!DOCTYPE html>
<html lang="en" dir="rtl">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>אימות</title>
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

  <script type="text/javascript">

           function Succesesalert(msg) {
            swal({
                title: 'בוצע!',
                text: msg,
                type: 'success',
                icon: "success",
                showConfirmButton: true
                });
                 setTimeout(function () {
                     window.location.href = "Admin_Add_Class.aspx";
                 }, 700);
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

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <body class="hold-transition login-page">
            <div class="login-box">
                <div class="login-box-body">
                    <h3 class="login-box-msg m-b-1">אימות</h3>
                    <p>אנא ענה על שאלות האימות שבחרת לצורך איפוס סיסמתך </p>
                    <form action="index.html" method="post">

                        <div class="form-group has-feedback">
                            <p ID="LabelSecurityQ1" contenteditable="false" runat="server"> </p>
                            <asp:Label  runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="TextBoxSecurityA1" runat="server" class="form-control sty1" placeholder="תשובה"></asp:TextBox>
                            <br />
                            <p ID="LabelSecurityQ2"  contenteditable="false" runat="server"> </p>
                            <asp:TextBox ID="TextBoxSecurityA2" runat="server" class="form-control sty1" placeholder="תשובה"></asp:TextBox>
                        </div>
                        <div>
                            <div class="col-xs-4 m-t-1">
                                <asp:Button ID="CheckAnswer" runat="server" Text="אימות תשובות" class="btn btn-primary btn-block btn-flat" OnClick="CheckAnswer_Click" />

                            </div>
                            <!-- /.col -->
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
