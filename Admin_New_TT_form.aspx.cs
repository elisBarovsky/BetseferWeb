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

        }
    }

    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));

    }

    protected void AddClassBTN_Click(object sender, EventArgs e)
    {
        int LessonNum = int.Parse(objSenderID.Substring(24, 1));
        int DayNum = int.Parse(objSenderID.Substring(15, 1));
        int ClassNum = int.Parse(objSenderID.Substring(39, 2));
        int lessonCode = int.Parse(DDLlessons.SelectedItem.Value.ToString()); 
        string TeacherCode = TeachersDDL.SelectedItem.Value.ToString();

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
}