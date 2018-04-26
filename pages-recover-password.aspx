<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pages-recover-password.aspx.cs" Inherits="pages_recover_password" %>

<!DOCTYPE html>
<html lang="en" dir="rtl">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>איפוס סיסמה</title>
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

</head>
<body>
    <form id="form1" runat="server">
        <body class="hold-transition login-page">
            <div class="login-box">
                <div class="login-box-body">
                    <h3 class="login-box-msg m-b-1">איפוס סיסמה</h3>
                    <p>הקלדת את מספר תעודת הזהות שלך ואת תאריך הלידה לזיהוי </p>
                    <form action="index.html" method="post">

                        <div class="form-group has-feedback">
                            <asp:TextBox ID="TextBoxUserID" runat="server" MaxLength="10" class="form-control sty1" placeholder="תעודת זהות"></asp:TextBox>
                            <br />
                            <asp:DropDownList ID="DDLyear" runat="server" CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown"></asp:DropDownList>

                            /
                <asp:DropDownList ID="DDLmonth" runat="server" CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown"></asp:DropDownList>
                            /
           <asp:DropDownList ID="DDLday" runat="server" CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown"></asp:DropDownList>

                            <br />
                        </div>
                        <div>
                            <div class="col-xs-4 m-t-1">
                                <asp:Button ID="ButtonCheckUserExist" runat="server" class="btn btn-primary btn-block btn-flat" Text="בדיקת משתמש" OnClick="ButtonCheckUserExist_Click" />

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
