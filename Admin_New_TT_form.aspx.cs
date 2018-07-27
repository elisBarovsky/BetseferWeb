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
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }
        objSenderID = ((System.Web.UI.Page)sender).ClientQueryString;
        
        if (!IsPostBack)
        {
            FillTeacherName();
        }
    }
  

    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));

    }

    protected void FillTeacherName()
    {
        int LessonNum = int.Parse(objSenderID.Substring(24, 1));
        int DayNum = int.Parse(objSenderID.Substring(15, 1));

        Dictionary<string, string> Lessons = new Dictionary<string, string>();
        TimeTable TeacherNotBusy = new TimeTable();
        Lessons = TeacherNotBusy.FillTeacherNotBusy(DayNum, LessonNum);
        TeachersDDL.DataSource = Lessons.Values;
        TeachersDDL.DataBind();
         Session["TeacherNotBusy"] = Lessons;
    }

    protected void AddClassBTN_Click(object sender, EventArgs e)
    {
        int LessonNum = int.Parse(objSenderID.Substring(24, 1));
        int DayNum = int.Parse(objSenderID.Substring(15, 1));
        int ClassNum = int.Parse(objSenderID.Substring(39, 2));
        int lessonCode = int.Parse(DDLlessons.SelectedItem.Value.ToString());

        Dictionary<string, string> TeacherNotBusy = new Dictionary<string, string>();
        TeacherNotBusy = (Dictionary<string, string>)(Session["TeacherNotBusy"]);

        string TeacherCode = KeyByValue(TeacherNotBusy, TeachersDDL.SelectedValue);

        TimeTable TT = new TimeTable();     

        int res=  TT.InsertTempTimeTable( DateTime.Today.ToShortDateString(), DayNum, LessonNum, lessonCode, TeacherCode, ClassNum);

        if (res==1)
        {
            string close = @"<script type='text/javascript'>
                                window.close();
                                window.opener.location.reload();
                                </script>";
            base.Response.Write(close);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('הייתה בעיה, נסה שנית.');", true);
        }
    }

    public static string KeyByValue(Dictionary<string, string> dict, string val)
    {
        string key = null;
        foreach (KeyValuePair<string, string> pair in dict)
        {
            if (pair.Value == val)
            {
                key = pair.Key;
                break;
            }
        }
        return key;
    }
}