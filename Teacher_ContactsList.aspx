<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teacher_ContactsList.aspx.cs" Inherits="Teacher_ContactsList" %>

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
                    <li class="treeview"><a href="Teacher_Dashbord.aspx"><i class="fa fa-home"></i><span>דף הבית</span> </a>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-table"></i><span>מערכת שעות</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Teacher_TimeTable.aspx"><i class="fa fa-plus"></i><span>צפייה</span> </a>
                        </ul>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-briefcase"></i><span>הערות משמעת</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Teacher_Notes_Insert.aspx"><i class="fa fa-plus"></i><span>הוספת הערה</span> </a>
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
                    <li class="active treeview"><a href="#"><i class="fa fa-briefcase"></i><span>דף קשר</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li class="active"><a href="Teacher_ContactsList.aspx"><i class="fa fa-plus"></i><span>צפייה</span> </a>
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
                            <li><a href="apps-mailbox.html">הודעות נכנסות</a></li>
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
                <h1>דף קשר</h1>

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
                                            <asp:DropDownList ID="ChooseClassDLL" CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown" Style="direction: rtl;" runat="server" OnDataBound="FillFirstItem"></asp:DropDownList>

                                        </td>
                                        <td>
                                            <label class="control-label">בחר קבוצה</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="FilterNotes" CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown" runat="server" RepeatDirection="Horizontal" Width="349px">
                                                <asp:ListItem Text="בחר" Value="0" />
                                                <asp:ListItem Text="הורים" Value="3" />
                                                <asp:ListItem Text="תלמידים" Value="4" />
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="TLBTN" runat="server" Text="צפה" CssClass="btn btn-outline-primary" OnClick="TLBTN_Click"  />
                                        </td>
                                    </tr>
                                </table>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView1" class="table table-bordered table-striped" HeaderStyle-CssClass="headerGW" runat="server" AllowPaging="True" BorderStyle="Dashed" HeaderStyle-HorizontalAlign="Right">
                                        <PagerStyle HorizontalAlign="Right" />
                                        <RowStyle HorizontalAlign="Right" />
                                    </asp:GridView>
                                </div>
                            </div>
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

    <!-- DataTable -->
    <script src="dist/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="dist/plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script>
        $(function () {
            $('#example1').DataTable()
            $('#example2').DataTable({
                'paging': true,
                'lengthChange': false,
                'searching': false,
                'ordering': true,
                'info': true,
                'autoWidth': false
            })
        })
    </script>

    <script src="dist/plugins/table-expo/filesaver.min.js"></script>
    <script src="dist/plugins/table-expo/xls.core.min.js"></script>
    <script src="dist/plugins/table-expo/tableexport.js"></script>
    <script>
        $("#GridView1").tableExport({ formats: ["xlsx", "xls"], });
    </script>
</body>
</html>
