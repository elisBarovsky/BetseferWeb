using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_New_TT_form : System.Web.UI.Page
{
    string objSenderID;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        //{
        //    Response.Redirect("login.aspx");
        //}
        //  string id = Request["onclickImg.ID"];
        //object gfhgf = (Button)sender;

        objSenderID = ((System.Web.UI.Page)sender).ClientQueryString;
        
        if (!IsPostBack)
        {
           // FillClassesOt();
          //  FillClassesNum();
        }
    }

    protected void AddClassBTN_Click(object sender, EventArgs e)
    {
        int LessonNum = int.Parse(objSenderID.Substring(24, 1));
        int DayNum = int.Parse(objSenderID.Substring(15, 1));
        int lessonCode = int.Parse(DDLlessons.SelectedItem.Value.ToString()); 
        string TeacherCode = TeachersDDL.SelectedItem.Value.ToString();

        //int TimeTableCode, int CodeWeekDay, int ClassTimeCode, int CodeLesson, string TeacherId
        TimeTable TT = new TimeTable();
       

        int res=  TT.InsertTempTimeTable( DateTime.Today.ToShortDateString(), DayNum, LessonNum, lessonCode, TeacherCode);

        if (res==1)
        {
            string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                window.opener.location.reload();
                                </script>";
            base.Response.Write(close);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הייתה בעיה, נסה שנית.');", true);
        }
    }
}