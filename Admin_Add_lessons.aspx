﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Add_lessons.aspx.cs" Inherits="Admin_Add_lessons" %>

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
                     window.location.href = "Admin_Add_lessons.aspx";
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
        <%--        <div class="user-panel">
                    <div class="image text-center"></div>
                    <div class="info">
                        <a href="#">ברוך הבא ☺</a>
                    </div>
                </div>--%>
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
                    <li class="active treeview"><a href="#"><i class="fa fa-briefcase"></i><span>ניהול מקצועות</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li class="active"><a href="Admin_Add_lessons.aspx"><i class="fa fa-plus"></i><span>הוספת מקצוע</span> </a>
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
                <h1>הוספת מקצוע</h1>
            </section>

            <!-- Main content -->
            <section class="content">
                <div class="info-box">
                    <form runat="server">
                        <table class="auto-style1" align="center">
                            <tr>
                                <td style="text-align: right">הזן שם מקצוע
                                </td>
                                <td style="text-align: right">
                                    <asp:TextBox ID="LessonsNameTB" class="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <br />
                                    <br />
                                    מקצועות קיימים
                                </td>
                                <td style="text-align: right">
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="DDLlessons" CssClass="form-control" Style="direction: rtl;" runat="server" DataSourceID="subjects" DataTextField="LessonName" DataValueField="CodeLesson" AutoPostBack="True"></asp:DropDownList>
                                    <asp:SqlDataSource ID="subjects" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [CodeLesson], [LessonName] FROM [Lessons] ORDER BY [LessonName]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <br />
                                    <br />
                                    אנא בחר מורים<br />המלמדים מקצוע זה
                                </td>
                                <td>
                                    <br />
                                    <br />
                                    <asp:Panel ID="checkBoxPanel" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList form-control">
                                        <asp:CheckBoxList ID="teachersSubject" runat="server" style="WIDTH:120px; HEIGHT:50px" DataSourceID="teachers" DataTextField="TeacherFullName" DataValueField="UserID"></asp:CheckBoxList>
                                        <asp:SqlDataSource ID="teachers" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT UserID, UserLName + ' ' + UserFName AS TeacherFullName FROM Users WHERE (CodeUserType = 2)"></asp:SqlDataSource>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right"></td>
                                <td style="text-align: right">
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Button ID="AddLessonsBTN" runat="server" CssClass="btn btn-outline-primary" Text="הוסף מקצוע" OnClick="AddLessonsBTN_Click" />
                                </td>
                            </tr>
                        </table>
                    </form>
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
