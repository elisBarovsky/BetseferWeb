<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SettingPage_Admin.aspx.cs" Inherits="SettingPage_Admin" %>

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
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
<![endif]-->
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
                     window.location.href = "AdminDashbord.html";
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
                 //}, 2000);
            };

    </script>
    <style type="text/css">
        .auto-style1 {
            height: 184px;
        }

        .scrollingControlContainer
        {
            overflow-x: hidden;
            overflow-y: scroll;
        }

        .scrollingCheckBoxList
        {
            margin: 10px 0px 10px 10px;
            height: 110px;
        }
    </style>
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <div class="wrapper boxed-wrapper">
        <header class="main-header">
            <!-- Logo -->
            <a href="#" class="logo blue-bg">
                <!-- mini logo for sidebar mini 50x50 pixels -->
                <span class="logo-mini">
                    <img src="Images/BetseferLogo-n.png" alt=""></span>
                <!-- logo for regular state and mobile devices -->
                <span class="logo-lg">
                    <img src="Images/BetseferLogo_NN.png" alt=""></span> </a>
            <!-- Header Navbar: style can be found in header.less -->
            <nav class="navbar blue-bg navbar-static-top">
                <!-- Sidebar toggle button-->
                <ul class="nav navbar-nav pull-left">
                    <li><a class="sidebar-toggle" data-toggle="push-menu" href=""></a></li>
                </ul>
                <div class="navbar-custom-menu" runat="server">
                    <ul class="nav navbar-nav">
                        <!-- Messages: style can be found in dropdown.less-->
                        <li class="dropdown messages-menu">
                            <a href="AdminDashbord.html">
                                <i class="fa fa-home"></i>
                                <div class="notify"><span class="heartbit"></span><span class="point"></span></div>
                            </a>
                        </li>                      
                        <!-- User Account: style can be found in dropdown.less -->
                <li class="dropdown user user-menu p-ph-res">
                            <a  class="dropdown-toggle" data-toggle="dropdown">
                            <asp:Image ID="UserImg1" runat="server" class="user-image" />
                            <span class="hidden-xs"  runat="server" id="UserNameSpan" ></span></a>
                            <ul class="dropdown-menu right">
                                <li class="user-header right">
                                   <li><a href="SettingPage_Admin.aspx" class="text-right"> <i class="icon-gears"> </i> הגדרות משתמש</a></li>
                                <li><a href="login.aspx" class="text-right"> <i class="fa fa-power-off"></i> התנתק </a></li>
                                </li>
                               
                              </ul>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>

        <!-- Left side column. contains the logo and sidebar -->
        <aside class="main-sidebar">
            <!-- sidebar: style can be found in sidebar.less -->
            <section class="sidebar">
                   <!-- sidebar menu: : style can be found in sidebar.less -->
                <ul class="sidebar-menu" data-widget="tree">
                    <li class="treeview"><a href="#"><i class="fa fa-table"></i><span>מערכת שעות</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Admin_Add_TimeTable.aspx"><i class="fa fa-plus"></i><span>יצירת מערכת</span> </a>
                                <li><a href="Admin_Update_TimeTable.aspx"><i class="fa fa-edit"></i><span>עדכון מערכת</span> </a>
                                    <li><a href="Admin_Saved_TimeTable.aspx"><i class="fa fa-edit"></i><span>מערכות בתהליך</span> </a>
                        </ul>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-briefcase"></i><span>ניהול משתמשים</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Admin_Add_User.aspx"><i class="fa fa-plus"></i><span>הוספת משתמשים</span> </a>
                                <li><a href="Admin_Update_User.aspx"><i class="fa fa-edit"></i><span>עדכון משתמשים</span> </a>
                        </ul>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-briefcase"></i><span>ניהול כיתות</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Admin_Add_Class.aspx"><i class="fa fa-plus"></i><span>הוספת כיתה</span> </a>
                        </ul>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-briefcase"></i><span>ניהול מקצועות</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li ><a href="Admin_Add_lessons.aspx"><i class="fa fa-plus"></i><span>הוספת מקצוע</span> </a>
                        </ul>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-envelope-o "></i><span>הודעות</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Admin_History_Messages.html">הודעות נכנסות</a></li>
                            <li><a href="Admin_Add_Messages.html">הודעה חדשה</a></li>
                        </ul>
                    </li>
                </ul>
            </section>
            <!-- /.sidebar -->
        </aside>

        <!-- Content Wrapper. Contains page content -->
        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header sty-one">
                <h1>הגדרות</h1>
            </section>

            <!-- Main content -->
            <section class="content">
            <div class="info-box">
                <center> 
                <div class="login-box-body" style="width:400px">
                
                    <p>בחר סיסמה חדשה והזן אותה פעמיים </p>
                    <form method="post" runat="server">

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
                  <asp:Button ID="Button1" runat="server" class="btn btn-outline-primary" Width="250px" Text="שנה סיסמה" OnClick="ChangePasswordBTN" />

                            </div>
                            <!-- /.col -->
                              <br /><br />
                                 <p>בחר תמונת פרופיל חדשה  </p>
                              <div class="col-xs-4 m-t-1">
                                  <fieldset class="form-group" runat="server">
                                                <label class="custom-file center-block block">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" class="custom-file-input" />
                                                    <span class="custom-file-control"></span>
                                                </label>
                                            </fieldset>
                  <asp:Button ID="Button2" runat="server" class="btn btn-outline-primary" Width="250px" Text="העלאת תמונה" OnClick="UploadImgBTN" />

                            </div>
                        </div>
                    </form>
                </div></center>
                <!-- /.login-box-body -->
            </div>
            </section>
            <!-- /.content -->
        </div>
        <!-- /.content-wrapper -->
                 <footer >
    <div class="pull-left hidden-xs">Copyright © 2018 Ellis & Dikla. All rights reserved</div>
    </footer>
    </div>
    <!-- ./wrapper -->

    <!-- jQuery 3 -->
    <script src="dist/js/jquery.min.js"></script>

    <!-- v4.0.0-alpha.6 -->
    <script src="dist/bootstrap/js/bootstrap.min.js"></script>

    <!-- template -->
    <script src="dist/js/niche.js"></script>

</body>
</html>
