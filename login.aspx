<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html lang="en" dir="rtl">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
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
    <script src="Scripts/Login_AJAX.js"></script>
    <script type="text/javascript">

        function SaveUserIdInLocalStorage() {
            var id = document.getElementById("IDTB").value;
            localStorage.setItem("UserID", id);

            GetUserImgWeb(id, SaveUserImg);
            GetUserFullName(id, SaveUserFullName);
            //GetUserType(id, SaveUserType);
        };

        function SaveUserImg(results) {
            res = $.parseJSON(results.d);
            localStorage.setItem("UserImg", res);
        };

        function SaveUserFullName(results) {
            res = $.parseJSON(results.d);
            localStorage.setItem("UserFullName", res);
        };

        //function SaveUserType(results) {
        //    res = $.parseJSON(results.d);
        //    localStorage.setItem("UserType", res);
        //}
            

    </script>
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div class="login-box" style="float: inherit">
               <div>
          <img src="Images/Betsefer.png" alt="" class="img-responsive">
        </div>
          
            <div class="login-box-body">
                <form action="login.aspx" method="post">
                    <div class="form-group has-feedback">
              <asp:TextBox ID="IDTB" runat="server" MaxLength="10" class="form-control sty1" placeholder="תעודת זהות"></asp:TextBox>
               <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="IDTB" ErrorMessage="User Name is required." ForeColor="White" ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group has-feedback">

                  <asp:TextBox ID="passwordTB" runat="server" type="password" class="form-control sty1" placeholder="סיסמה"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="passwordTB" ErrorMessage="Password is required." ForeColor="blue" ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>

                    </div>
                    <div>
                        <div class="col-xs-8">
                            <div class="checkbox icheck">
                                <label>
                                    <input type="checkbox"> זכור אותי</label>
                                <a href="pages-recover-password.aspx" runat="server" class="pull-left"><i class="fa fa-lock"></i>? שכחת סיסמה
                                </a>
                            </div>
                        </div>
                        <!-- /.col -->
                        <div class="col-xs-4 m-t-1">
               <asp:Button ID="ButtonCheckUserExist" runat="server" class="btn btn-primary btn-block btn-flat" Text="התחבר" OnClientClick="javascript:SaveUserIdInLocalStorage();" OnClick="Login1_Authenticate"/>

                        </div>
                        <!-- /.col -->
                    </div>
                </form>
                <%--  <div class="social-auth-links text-center">
      <p>- OR -</p>
      <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i> Sign in using
      Facebook</a> <a href="#" class="btn btn-block btn-social btn-google btn-flat"><i class="fa fa-google-plus"></i> Sign in using
      Google+</a> </div>--%>
                <!-- /.social-auth-links -->

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
