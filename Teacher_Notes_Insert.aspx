<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teacher_Notes_Insert.aspx.cs" Inherits="Teacher_Notes_Insert" %>

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
    <%--   <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>--%>
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <div class="wrapper boxed-wrapper">
        <header class="main-header">
            <!-- Logo -->
            <a href="login.aspx" class="logo blue-bg">
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
                <!-- search form -->
                <!--</div>-->
                <div class="navbar-custom-menu" runat="server">
                    <ul class="nav navbar-nav">
                        <!-- Messages: style can be found in dropdown.less-->
                        <li class="dropdown messages-menu"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-envelope-o"></i>
                            <div class="notify"><span class="heartbit"></span><span class="point"></span></div>
                        </a>
                            <ul class="dropdown-menu">
                                <li class="header">You have 4 new messages</li>
                                <li>
                                    <ul class="menu">
                                        <li><a href="#">
                                            <div class="pull-left" runat="server">
                                                <asp:Image ID="UserImg" runat="server" class="img-circle" />
                                                <span class="profile-status online pull-right"></span>
                                            </div>
                                            <h4 id="UserNameplace">Alex C. Patton</h4>
                                            <p>I've finished it! See you so...</p>
                                            <p><span class="time">9:30 AM</span></p>
                                        </a></li>
                                        <li><a href="#">
                                            <div class="pull-left">
                                                <img src="dist/img/img3.jpg" class="img-circle" alt="User Image">
                                                <span class="profile-status offline pull-right"></span>
                                            </div>
                                            <h4>Nikolaj S. Henriksen</h4>
                                            <p>I've finished it! See you so...</p>
                                            <p><span class="time">10:15 AM</span></p>
                                        </a></li>
                                        <li><a href="#">
                                            <div class="pull-left">
                                                <img src="dist/img/img2.jpg" class="img-circle" alt="User Image">
                                                <span class="profile-status away pull-right"></span>
                                            </div>
                                            <h4>Kasper S. Jessen</h4>
                                            <p>I've finished it! See you so...</p>
                                            <p><span class="time">8:45 AM</span></p>
                                        </a></li>
                                        <li><a href="#">
                                            <div class="pull-left">
                                                <img src="dist/img/img4.jpg" class="img-circle" alt="User Image">
                                                <span class="profile-status busy pull-right"></span>
                                            </div>
                                            <h4>Florence S. Kasper</h4>
                                            <p>I've finished it! See you so...</p>
                                            <p><span class="time">12:15 AM</span></p>
                                        </a></li>
                                    </ul>
                                </li>
                                <li class="footer"><a href="#">View All Messages</a></li>
                            </ul>
                        </li>
                        <!-- Notifications: style can be found in dropdown.less -->
                        <li class="dropdown messages-menu"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-bell-o"></i>
                            <div class="notify"><span class="heartbit"></span><span class="point"></span></div>
                        </a>
                            <ul class="dropdown-menu">
                                <li class="header">התראות</li>
                                <li>
                                    <ul class="menu">
                                        <li><a href="#">
                                            <div class="pull-left icon-circle red"><i class="icon-lightbulb"></i></div>
                                            <h4>Alex C. Patton</h4>
                                            <p>I've finished it! See you so...</p>
                                            <p><span class="time">9:30 AM</span></p>
                                        </a></li>
                                        <li><a href="#">
                                            <div class="pull-left icon-circle blue"><i class="fa fa-coffee"></i></div>
                                            <h4>Nikolaj S. Henriksen</h4>
                                            <p>I've finished it! See you so...</p>
                                            <p><span class="time">1:30 AM</span></p>
                                        </a></li>
                                        <li><a href="#">
                                            <div class="pull-left icon-circle green"><i class="fa fa-paperclip"></i></div>
                                            <h4>Kasper S. Jessen</h4>
                                            <p>I've finished it! See you so...</p>
                                            <p><span class="time">9:30 AM</span></p>
                                        </a></li>
                                        <li><a href="#">
                                            <div class="pull-left icon-circle yellow"><i class="fa  fa-plane"></i></div>
                                            <h4>Florence S. Kasper</h4>
                                            <p>I've finished it! See you so...</p>
                                            <p><span class="time">11:10 AM</span></p>
                                        </a></li>
                                    </ul>
                                </li>
                                <li class="footer"><a href="#">ראיתי את כל ההתראות</a></li>
                            </ul>
                        </li>
                        <!-- User Account: style can be found in dropdown.less -->
                        <li class="dropdown user user-menu p-ph-res"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                            <asp:Image ID="UserImg1" runat="server" class="user-image" />
                            <span class="hidden-xs"></span></a>
                            <ul class="dropdown-menu right">
                                <li class="user-header right">
                                    <div class="pull-left user-img" runat="server">
                                        <asp:Image ID="UserImgimg" runat="server" class="img-responsive" />
                                    </div>
                                    <p class="text-left" id="UserName" runat="server"><small>some mail</small> </p>
                                    <div class="view-link text-right"><a href="#">צפה בפרופיל</a> </div>
                                </li>
                                <li><a href="#" class="view-link text-right">הגדרות משתמש  <i class="icon-gears"></i></a></li>
                                <li role="separator" class="divider"></li>
                                <li><a href="login.aspx" class="view-link text-right">התנתק  <i class="fa fa-power-off"></i></a></li>
                             </ul>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>

        <!-- Left side column. contains the logo and sidebar -->
        <aside class="main-sidebar">
             <div class="user-panel">
                    <div class="image text-center"></div>
                    <div class="info">
                        <a href="#">ברוך הבא ☺</a>
                    </div>
                </div>
            <!-- sidebar: style can be found in sidebar.less -->
            <section class="sidebar">
                <!-- sidebar menu: : style can be found in sidebar.less -->
                <ul class="sidebar-menu" data-widget="tree">
                    <li class="treeview"><a href="Teacher_Dashbord.html"><i class="fa fa-home"></i><span>דף הבית</span> </a>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-table"></i><span>מערכת שעות</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Teacher_TimeTable.aspx"><i class="fa fa-plus"></i><span>צפייה</span> </a>
                        </ul>
                    </li>
                    <li class="active treeview"><a href="#"><i class="fa fa-briefcase"></i><span>הערות משמעת</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li class="active"><a href="Teacher_Notes_Insert.aspx"><i class="fa fa-plus"></i><span>הוספת הערה</span> </a>
                                <li><a href="Teacher_Notes_History.aspx"><i class="fa fa-edit"></i><span>צפייה</span> </a>
                        </ul>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-briefcase"></i><span>שיעורי בית</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Teacher_HW_Insert.aspx"><i class="fa fa-plus"></i><span>הוספת שיעורים</span> </a>
                                <li><a href="Teacher_HW_History.aspx"><i class="fa fa-plus"></i><span>צפייה ועדכון</span> </a>
                        </ul>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-briefcase"></i><span>ציונים</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Teacher_Grades_Insert.aspx"><i class="fa fa-plus"></i><span>הוספת ציונים</span> </a>
                                <li><a href="#.aspx"><i class="fa fa-plus"></i><span>עדכון</span> </a>
                        </ul>
                    </li>
                   <li class="treeview"><a href="#"><i class="fa fa-briefcase"></i><span>דף קשר</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li ><a href="Teacher_ContactsList.aspx"><i class="fa fa-plus"></i><span>צפייה</span> </a>
                        </ul>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-briefcase"></i><span>לוח שנה</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-briefcase"></i><span>יום הורים</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="#.aspx"><i class="fa fa-plus"></i><span>יצירה</span> </a>
                                <li><a href="#.aspx"><i class="fa fa-plus"></i><span>צפייה ועדכון</span> </a>
                        </ul>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-envelope-o "></i><span>הודעות</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Teacher_History_Messages.html">הודעות נכנסות</a></li>
                            <li><a href="Teacher_Add_Messages.html">הודעה חדשה</a></li>
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
                <h1>הוספת הערות משמעת</h1>

            </section>

            <!-- Main content -->
            <section class="content">
                <div class="info-box">
                    <form runat="server">
                        <div class="card-body">
                            <div class="row">
                                <table class="table" align="center">
                                    <tr>
                                        <td>
                                            <label class="control-label">בחר כיתה</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ChooseClassDLL" CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown" Style="direction: rtl;" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ChooseClasssDLL_SelectedIndexChanged" DataSourceID="DDLclassesAccordingTeacherId" DataTextField="TotalName" DataValueField="ClassCode" OnDataBound="FillFirstItem"></asp:DropDownList>
                                            <asp:SqlDataSource ID="DDLclassesAccordingTeacherId" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT distinct dbo.Class.ClassCode, dbo.Class.TotalName
FROM dbo.Timetable INNER JOIN  dbo.Class ON dbo.Timetable.ClassCode = dbo.Class.ClassCode AND dbo.Timetable.ClassCode = dbo.Class.ClassCode INNER JOIN dbo.TimetableLesson ON Timetable.TimeTableCode = dbo.TimetableLesson.TimeTableCode
where  dbo.TimetableLesson.TeacherId =@TID">
                                                <SelectParameters>
                                                    <asp:CookieParameter CookieName="UserID" Name="TID" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                        <td>
                                            <label class="control-label">בחר מקצוע</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ChooseLessonsDLL" CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown" Style="direction: rtl;" runat="server" AutoPostBack="True" OnDataBound="FillFirstItem" Enabled="false"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="control-label">בחר תלמיד</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="PupilsDLL" CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown" Style="direction: rtl;" runat="server" Enabled="false"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <label class="control-label">בחר הערת משמעת</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="NotesDLL" CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown" Style="direction: rtl;" runat="server"></asp:DropDownList>
                                        </td>

                                    </tr>
                                </table>                   
                                <div class="col-md-12">
                                    <div class="form-group has-feedback">
                                        <label class="control-label">הערת המורה</label>
                                        <asp:TextBox ID="TNoteTB" runat="server" CssClass="form-control" TextMode="MultiLine" Height="52px" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <br />
                        <div align="center">
                            <asp:Button ID="AddNotes" runat="server" CssClass="btn btn-outline-primary" Text="הוסף הערת משמעת" OnClick="AddNotes_Click" />
                        </div>
                    </form>
                </div>
            </section>

            <!-- /.content -->
        </div>
        <!-- /.content-wrapper -->
        <%-- <footer class="main-footer">
    <div class="pull-left hidden-xs">Copyright © 2018 Ellis & Dikla. All rights reserved</div>
    </footer>--%>
    </div>
    <!-- ./wrapper -->

    <!-- jQuery 3 -->
    <script src="dist/js/jquery.min.js"></script>

    <!-- v4.0.0-alpha.6 -->
    <script src="dist/bootstrap/js/bootstrap.min.js"></script>

    <!-- template -->
    <script src="dist/js/niche.js"></script>

    <!-- Chartjs JavaScript -->
    <script src="dist/plugins/chartjs/chart.min.js"></script>
    <script src="dist/plugins/chartjs/chart-int.js"></script>

    <!-- Chart Peity JavaScript -->
    <script src="dist/plugins/peity/jquery.peity.min.js"></script>
    <script src="dist/plugins/functions/jquery.peity.init.js"></script>

    <%--  <div class="w3-sidebar w3-bar-block w3-card w3-dark-grey w3-xlarge" style="width: 10%; right: 0;">
            <h3 class="w3-bar-item"></h3>
            <a href="Admin.aspx" class="w3-bar-item w3-button"><i class="fa fa-home" style="padding-left: 50%"></i></a>
            <a href="ATimeTable.aspx" class="w3-bar-item w3-button w3-hover-green" style="text-align: right">מערכת שעות</a>
            <a href="AdminMasseges.aspx" class="w3-bar-item w3-button w3-hover-blue" style="text-align: right">הודעות</a>
            <a href="AAddNewUser.aspx" class="w3-bar-item w3-button w3-hover-red" style="text-align: right">ניהול משתמשים</a>
            <a href="AAddClasses.aspx" class="w3-bar-item w3-button w3-hover-blue" style="text-align: right">ניהול כיתות</a>
            <a href="AAddLessons.aspx" class="w3-bar-item w3-button w3-hover-red" style="text-align: right">ניהול מקצועות</a>
            <a href="Login.aspx" class="w3-bar-item w3-button"><i class="fa fa-sign-out" style="padding-left: 50%"></i></a>

        </div>


        <div style="margin-right: 10%">

            <div class="w3-container w3-dark-grey" style="height: 50px">
                <img src="Images/Betsefer.png" style="padding-top: 5px; height: 50px">
            </div>

            <br />
            <br />
            <br />--%>

    <%--</div>--%>
</body>
</html>
