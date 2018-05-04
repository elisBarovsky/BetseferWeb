<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_New_TT_form.aspx.cs" Inherits="Admin_New_TT_form" %>

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
        </header>
        <!-- Content Wrapper. Contains page content -->
        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header sty-one">
                <h1>עדכון מערכת</h1>
            </section>

            <!-- Main content -->
            <section class="content">
                <div class="info-box">
                    <form runat="server">
                        <table class="auto-style1" align="center">
                            <tr>
                                <td style="text-align: right">בחר מקצוע
                                </td>
                                <td style="text-align: right">
                                    <asp:DropDownList ID="DDLlessons" CssClass="form-control" Style="direction: rtl;" runat="server" DataSourceID="subjects" DataTextField="LessonName" DataValueField="CodeLesson" AutoPostBack="true" OnDataBound="FillFirstItem"></asp:DropDownList>
                                    <asp:SqlDataSource ID="subjects" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [CodeLesson], [LessonName] FROM [Lessons] ORDER BY [LessonName]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <br />
                                    <br />
                                    בחר מורה
                                </td>
                                <td style="text-align: right">
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="TeachersDDL" CssClass="form-control" data-toggle="dropdown" runat="server" DataSourceID="SqlDataSource1" DataTextField="TeacherName" DataValueField="TeacherID" AutoPostBack="true" OnDataBound="FillFirstItem"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT           ( dbo.Users.UserFName+ ' ' +dbo.Users.UserLName) as TeacherName, dbo.TeachersTeachesSubjects.CodeLessons, dbo.TeachersTeachesSubjects.TeacherID
FROM            dbo.Users INNER JOIN
                         dbo.TeachersTeachesSubjects ON dbo.Users.UserID = dbo.TeachersTeachesSubjects.TeacherID
where dbo.TeachersTeachesSubjects.CodeLessons=@LesCode">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDLlessons" Name="LesCode" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right"></td>
                                <td style="text-align: right">
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Button ID="AddClassBTN" runat="server" CssClass="btn btn-outline-primary" Text="הוסף למערכת" OnClick="AddClassBTN_Click" />
                                </td>
                            </tr>
                        </table>
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
