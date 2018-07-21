<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Update_User.aspx.cs" Inherits="Admin_Update_User" %>

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
                window.location.href = "Admin_Update_User.aspx";
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
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <asp:Image ID="UserImg1" runat="server" class="user-image" />
                                <span class="hidden-xs"></span></a>
                            <ul class="dropdown-menu right">
                                <li class="user-header right">
                                    <div class="pull-left user-img" runat="server">
                                        <asp:Image ID="UserImgimg" runat="server" class="img-responsive" />
                                    </div>
                                </li>
                                <li><a href="#" class="view-link text-right">
                                    <h2 class="view-link text-right" id="UserName" runat="server"><small></small></h2>
                                </a></li>
                                <li><a href="#" class="view-link text-right">הגדרות משתמש  <i class="icon-gears"></i></a></li>
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
                    <li class="treeview"><a href="#"><i class="fa fa-table"></i><span>מערכת שעות</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Admin_Add_TimeTable.aspx"><i class="fa fa-plus"></i><span>יצירת מערכת</span> </a>
                                <li><a href="Admin_Update_TimeTable.aspx"><i class="fa fa-edit"></i><span>עדכון מערכת</span> </a>
                                    <li><a href="Admin_Saved_TimeTable.aspx"><i class="fa fa-edit"></i><span>מערכות בתהליך</span> </a>

                        </ul>
                    </li>
                    <li class="active treeview"><a href="#"><i class="fa fa-briefcase"></i><span>ניהול משתמשים</span> <span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span></a>
                        <ul class="treeview-menu">
                            <li><a href="Admin_Add_User.aspx"><i class="fa fa-plus"></i><span>הוספת משתמשים</span> </a>
                                <li class="active"><a href="Admin_Update_User.aspx"><i class="fa fa-edit"></i><span>עדכון משתמשים</span> </a>
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
                <h1>עדכון משתמש</h1>

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
                                            <asp:Label ID="Label1" class="control-label" runat="server" Text="סוג משתמש"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="UserTypeDLL" CssClass="form-control" runat="server" DataSourceID="SqlDataSource2" OnDataBound="FillFirstItem" OnSelectedIndexChanged="UserTypeDLL_CheckedChanged" DataTextField="CodeUserName" DataValueField="CodeUserType" AutoPostBack="true" RepeatDirection="Horizontal"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT * FROM [UserType]"></asp:SqlDataSource>
                                        </td>
                                        <td>
                                            <asp:Label ID="Class1LBL" class="control-label" runat="server" Text=" בחר כיתה"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ClassOt1DLL" Style="direction: rtl;" runat="server" CssClass="form-control" data-toggle="dropdown" AutoPostBack="true" OnSelectedIndexChanged="FillPupils"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [ClassCode], [TotalName] FROM [Class] order by TotalName"></asp:SqlDataSource>
                                        </td>

                                        <td>
                                            <asp:Button ID="UpdateUserBTN" runat="server" CssClass="btn btn-outline-primary" Text="עדכן משתמש" OnClick="UpdateUserBTN_Click" />

                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="ChoosePupilLBL" runat="server" Text="בחר תלמיד"></asp:Label>
                                            <asp:Label ID="ChooseOtherUsers" runat="server" Text="בחר משתמש"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="PupilDLL" Style="direction: rtl;" runat="server" CssClass="form-control" data-toggle="dropdown" OnSelectedIndexChanged="UserChosed" AutoPostBack="true"></asp:DropDownList>
                                            <asp:DropDownList ID="OtherUsersDLL" Style="direction: rtl;" runat="server" CssClass="form-control" data-toggle="dropdown" OnSelectedIndexChanged="UserChosed" AutoPostBack="true"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td class="auto-style2"></td>
                                        <td></td>
                                        <td></td>

                                    </tr>
                                    <tr>
                                        <td>שם משפחה</td>
                                        <td>
                                            <asp:TextBox ID="LNameTB" runat="server" required="required" class="form-control"></asp:TextBox></td>
                                        <td>שם פרטי</td>
                                        <td>
                                            <asp:TextBox ID="FNameTB" runat="server" required="required" class="form-control"></asp:TextBox></td>
                                        <td>
                                            <div style="position: fixed;">
                                                <asp:Image ID="ImgUser" runat="server" class="img-circle img-responsive" Style="width: 200px; height: 300px;" />

                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>תעודת זהות</td>
                                        <td>
                                            <asp:TextBox ID="UserIDTB" runat="server" required="required" class="form-control" OnPreRender="FillChildren"></asp:TextBox></td>
                                        <td>תאריך לידה</td>
                                        <td>
                                            <asp:TextBox ID="BDAYtb" ReadOnly value="" class="form-control" runat="server" required="required"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>טלפון 
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TelephoneNumberTB" runat="server" required="required" class="form-control"></asp:TextBox>
                                        </td>
                                        <td>תמונה</td>
                                        <td>
                                            <fieldset class="form-group" runat="server">
                                                <label class="custom-file center-block block">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" class="custom-file-input" />
                                                    <span class="custom-file-control"></span>
                                                </label>
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>סיסמה</td>
                                        <td>
                                            <asp:TextBox ID="PasswordTB" runat="server" required="required" class="form-control"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="MainTeacher" runat="server" Text=" האם מחנך"></asp:Label>
                                            <asp:DropDownList ID="ChildDDL" runat="server" CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown" OnDataBound="FillFirstItemChildrenList"></asp:DropDownList>
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="DeleteChild" OnClick="DeleteChildFunction" Visible="false" runat="server"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="AddChild" OnClick="AddNewChild" Visible="false" runat="server"><i class="fa fa-bathtub"></i></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="TBaddNewChild" runat="server" Visible="false" OnDataBound="FillFirstItem" CssClass="btn btn-default dropdown-toggle"></asp:DropDownList>
                                            <asp:CheckBox ID="MainTeacherCB" runat="server" AutoPostBack="true" OnCheckedChanged="MainTeacherCB_CheckedChanged" />
                                            <asp:Button ID="SaveChild" runat="server" Text="הוסף" Visible="false" OnClick="SaveNewChildToParent" class="btn btn-outline-primary"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="ChildIDLBL" runat="server" Text=" הזן תעודת זהות"></asp:Label>
                                            <asp:Label ID="Class2LBL" runat="server" Text=" בחר כיתה"></asp:Label>

                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ClassOt2DLL" Style="direction: rtl;" runat="server" CssClass="form-control" data-toggle="dropdown" DataSourceID="SqlDataSource3" DataTextField="TotalName" DataValueField="ClassCode" AutoPostBack="false" OnSelectedIndexChanged="FillPupils"></asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
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
