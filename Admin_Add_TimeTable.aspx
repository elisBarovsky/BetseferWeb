﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Add_TimeTable.aspx.cs" Inherits="Admin_Add_TimeTable" %>

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
    <style>
        .modalBackground {
            /*background-color:Gray;*/
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        .pnlBackGround {
            position: fixed;
            top: 10%;
            left: 10px;
            width: 300px;
            height: 125px;
            text-align: center;
            background-color: White;
            border: solid 3px black;
            border-radius: 20px;
        }
    </style>
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
                    <li><a class="sidebar-toggle" data-toggle="push-menu" href="#"></a></li>
                </ul>
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
            <!-- sidebar: style can be found in sidebar.less -->
            <section class="sidebar">
                <div class="user-panel">
                    <div class="image text-center"></div>
                    <div class="info">
                        <a href="#">ברוך הבא ☺</a>
                    </div>
                </div>
                <!-- sidebar menu: : style can be found in sidebar.less -->
                <ul class="sidebar-menu" data-widget="tree">
                    <li class="treeview"><a href="AdminDashbord.aspx"><i class="fa fa-home"></i><span>דף הבית</span> </a>
                    </li>
                    <li class="active treeview"><a href="#"><i class="fa fa-table"></i><span>מערכת שעות</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li class="active"><a href="Admin_Add_TimeTable.aspx"><i class="fa fa-plus"></i><span>יצירת מערכת</span> </a>
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
                            <li><a href="Admin_Add_lessons.aspx"><i class="fa fa-plus"></i><span>הוספת מקצוע</span> </a>
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
                <h1>הוספת מערכת שעות</h1>
            </section>

            <!-- Main content -->
            <section class="content">
                <div class="info-box">
                    <form runat="server" autopostback="true">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="modalBackground" CancelControlID="Button4" runat="server" TargetControlID="lblstupid" PopupControlID="Panel1"></ajaxToolkit:ModalPopupExtender>
                             <asp:Label ID="lblstupid" runat="server" Text=""></asp:Label>
                                <asp:Panel ID="Panel1" runat="server" Width="400px" Height="180px" CssClass="pnlBackGround">
                                    <br />
                                    <div class="row">
                                        <div class="col-md-9">
                                            <p style="font-size: x-large;">האם ברצונך לשמור שינויים ?</p>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="row">
                                        <div class="col-md-4 col-md-offset-1" style="float: right; position: relative">
                                            <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="לא" OnClick="No_Option" />
                                        </div>
                                        <div class="col-md-4 col-md-offset-1" style="float: left; position: relative">
                                            <asp:Button ID="Button4" CssClass="btn btn-primary" runat="server" Text="כן" />
                                        </div>
                                    </div>

                                </asp:Panel>
<%--                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                            <ContentTemplate>--%>
                           
                                <div class="table-responsive">
                                    <div style="float: right; position: relative">
                                        <asp:DropDownList ID="ddl_clasesAdd" CssClass="form-control" data-toggle="dropdown" Style="direction: rtl;" runat="server" OnDataBound="FillFirstItem" DataSourceID="DSclassesForAdd" DataTextField="TotalName" DataValueField="ClassCode" AutoPostBack="true" OnSelectedIndexChanged="ddl_clasesAdd_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:SqlDataSource ID="DSclassesForAdd" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT ClassCode, TotalName FROM Class WHERE (ClassCode NOT IN (SELECT Class_1.ClassCode FROM Class AS Class_1 INNER JOIN Timetable ON Class_1.ClassCode = Timetable.ClassCode))"></asp:SqlDataSource>
                                    </div>
                                    <div style="float: right; position: relative; padding-right: 20px">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-outline-info" Text="אישור" OnClick="SelectedIndexChanged" />
                                    </div>

                                    <div style="float: left; position: relative; padding-bottom: 20px;">
                                        <asp:Button ID="ButtonPublish" CssClass="btn btn-outline-success" runat="server" Text="שמור ופרסם" Visible="true" OnClick="ButtonPublish_Click" />

                                    </div>
                                    <div style="float: left; position: relative; padding-left: 20px">
                                        <asp:Button ID="Button2" CssClass="btn btn-outline-primary" runat="server" Text="שמור" OnClick="Button2_Click" Visible="true" />

                                    </div>

                                    <div runat="server" id="AlertBox" class="alertBox" visible="false">
                                        <div runat="server" id="AlertBoxMessage"></div>
                                        <button onclick="closeAlert.call(this, event)">Ok</button>
                                    </div>
                                   
                                </div>
                                  <asp:Table ID="TimeTable" runat="server" align="center" class="table table-bordered table-striped" AutoPostBack="false" data-name="cool-table">
                                    </asp:Table>
<%--                            </ContentTemplate>
                            
                        </asp:UpdatePanel>--%>
                       
                    </form>
                </div>
            </section>
            <!-- /.content -->
        </div>
        <!-- /.content-wrapper -->
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
