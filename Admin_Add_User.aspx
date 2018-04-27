<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Add_User.aspx.cs" Inherits="Admin_Add_User" %>

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
                        <li class="dropdown user user-menu p-ph-res"><a href="#" class="dropdown-toggle" data-toggle="dropdown" >
                            <asp:Image ID="UserImg1" runat="server" class="user-image" />
                            <span class="hidden-xs"></span></a>
                            <ul class="dropdown-menu right" style="float:right">
                                <li class="user-header right">
                                    <div class="pull-left user-img" runat="server">
                                        <asp:Image ID="UserImgimg" runat="server" class="img-responsive" />
                                    </div>
                                    <p class="text-left" id="UserName" runat="server"><small>some mail</small> </p>
                                    <div class="view-link text-right"><a href="#">צפה בפרופיל</a> </div>
                                </li>
                                <li ><a href="#" class="view-link text-right">הפרופיל שלי   <i class="icon-profile-male" ></i></a></li>
                                <li><a href="#" class="view-link text-right">הודעות   <i class="icon-envelope"></i></a></li>
                                <li role="separator" class="divider"></li>
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
                <!-- sidebar menu: : style can be found in sidebar.less -->
                <ul class="sidebar-menu" data-widget="tree">
                    <li class="treeview"><a href="AdminDashbord.aspx"><i class="fa fa-home"></i><span>דף הבית</span> </a>
                    </li>
                    <li class="treeview"><a href="#"><i class="fa fa-table"></i><span>מערכת שעות</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Admin_Add_TimeTable.aspx"><i class="fa fa-plus"></i><span>יצירת מערכת</span> </a>
                                <li><a href="Admin_Update_TimeTable.aspx"><i class="fa fa-edit"></i><span>עדכון מערכת</span> </a>
                        </ul>
                    </li>
                    <li class="active treeview"><a href="#"><i class="fa fa-briefcase"></i><span>ניהול משתמשים</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li class="active"><a href="Admin_Add_User.aspx"><i class="fa fa-plus"></i><span>הוספת משתמשים</span> </a>
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
                            <li><a href="apps-mailbox.html">הודעות נכנסות</a></li>
                            <li><a href="apps-compose-mail.html">הודעה חדשה</a></li>
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
                <h1>הוספת משתמש</h1>
            </section>

            <!-- Main content -->
            <section class="content">
                <div class="info-box" runat="server">
                    <form runat="server">
                        <div class="card-body">
                            <div class="row">
                                <table class="table" align="center">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="סוג משתמש"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="UserTypeDLL" runat="server" CssClass="form-control" data-toggle="dropdown" OnSelectedIndexChanged="UserTypeDLL_CheckedChanged" DataSourceID="SqlDataSource2" DataTextField="CodeUserName" DataValueField="CodeUserType" AutoPostBack="true" RepeatDirection="Horizontal"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT * FROM [UserType]"></asp:SqlDataSource>
                                        </td>
                                        <td>

                                        </td>
                                        <td>

                                        </td>

                                        <td>
                            <asp:Button ID="AddUserBTN" runat="server" CssClass="btn btn-outline-primary" Text="הוסף משתמש" OnClick="AddUserBTN_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>שם משפחה</td>
                                        <td>
                                            <asp:TextBox ID="LNameTB" runat="server" required="required" class="form-control"></asp:TextBox>
                                        </td>

                                        <td>שם פרטי</td>
                                        <td>
                                            <asp:TextBox ID="FNameTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>תעודת זהות</td>
                                        <td>
                                            <asp:TextBox ID="UserIDTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="UserIDTB"
                                                ErrorMessage="מצחיקול! הזן בשדה רק מספרים." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                        </td>

                                        <td>תאריך לידה</td>
                                        <td>

                                            <div class="form-group" runat="server">
                                                <input class="form-control" id="date1" type="date" runat="server">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>תמונה</td>
                                        <td>
                                            <fieldset class="form-group" runat="server">
                                                <label class="custom-file center-block block">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" class="custom-file-input" />
                                                    <span class="custom-file-control"></span>
                                                </label>
                                            </fieldset>

                                        </td>
                                        <td>
                                            <asp:Label ID="ClassLBL" runat="server" Text=" בחר כיתה"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ClassOtDLL" Style="direction: rtl;" runat="server" CssClass="form-control" data-toggle="dropdown" DataSourceID="SqlDataSource3" DataTextField="TotalName" DataValueField="ClassCode" OnLoad="FillFirstItem"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [ClassCode], [TotalName] FROM [Class]"></asp:SqlDataSource>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>טלפון</td>
                                        <td>
                                            <asp:TextBox ID="TelephoneNumberTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="TelephoneNumberTB"
                                                ErrorMessage="מצחיקול! הזן בשדה רק מספרים." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                            <br />
                                        </td>
                                        <td>סיסמה</td>
                                        <td>
                                            <asp:TextBox ID="PasswordTB" runat="server" required="required" class="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="PasswordTB"
                                                ErrorMessage="סיסמא חייבת להכיל לפחות 4 תוים." ValidationExpression=".{4}.*" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="MainTeacher" runat="server" Text=" האם מחנך"></asp:Label>
                                        </td>
                                        <td>
                                                                                <asp:CheckBox ID="MainTeacherCB" runat="server" AutoPostBack="true" OnCheckedChanged="MainTeacherCB_CheckedChanged" />

                                            <%--<asp:DropDownList ID="NumOfChildDDL" Style="direction: rtl;" runat="server" AutoPostBack="true" CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown" OnSelectedIndexChanged="NumOfChildDDL_SelectedIndexChanged"></asp:DropDownList>--%></td>

                                        <td>
                                            <%--<asp:Label ID="ChildIDLBL" runat="server" Text=" :הזן תעודת זהות ילד"></asp:Label>--%>
                                        </td>
                                        <td>
                                            <%--         

                                    <asp:TextBox ID="ChildI1DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox><br />
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI1DTB"
                                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                    <asp:TextBox ID="ChildI2DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox><br />
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI2DTB"
                                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                    <asp:TextBox ID="ChildI3DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox><br />
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI3DTB"
                                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                    <asp:TextBox ID="ChildI4DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox><br />
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI4DTB"
                                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                    <asp:TextBox ID="ChildI5DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox><br />
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI5DTB"
                                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                    <asp:TextBox ID="ChildI6DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI6DTB"
                                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />--%>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="NumChildLBL" runat="server" Text="מספר ילדים רשומים"></asp:Label>

                                <asp:DropDownList ID="NumOfChildDDL" Style="direction: rtl;" runat="server" AutoPostBack="true" CssClass="form-control" data-toggle="dropdown" OnSelectedIndexChanged="NumOfChildDDL_SelectedIndexChanged"></asp:DropDownList></td>

                               
                                    <asp:Label ID="ChildIDLBL" runat="server" Text=" :הזן תעודת זהות ילד"></asp:Label>

                                <asp:TextBox ID="ChildI1DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox><br />
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI1DTB"
                                    ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                <asp:TextBox ID="ChildI2DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox><br />
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI2DTB"
                                    ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                <asp:TextBox ID="ChildI3DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox><br />
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI3DTB"
                                    ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                <asp:TextBox ID="ChildI4DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox><br />
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI4DTB"
                                    ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                <asp:TextBox ID="ChildI5DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox><br />
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI5DTB"
                                    ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                                <asp:TextBox ID="ChildI6DTB" runat="server" required="required" MaxLength="10" class="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="ChildI6DTB"
                                    ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                            </div>
                        </div>
                        <div class="tab-pane p-20" id="Pupil" role="tabpanel" runat="server">
                            <div class="pad-20" runat="server">
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

    <!-- Chartjs JavaScript -->
    <script src="dist/plugins/chartjs/chart.min.js"></script>
    <script src="dist/plugins/chartjs/chart-int.js"></script>

    <!-- Chart Peity JavaScript -->
    <script src="dist/plugins/peity/jquery.peity.min.js"></script>
    <script src="dist/plugins/functions/jquery.peity.init.js"></script>
</body>
</html>
