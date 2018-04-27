using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_New_TT_form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        //{
        //    Response.Redirect("login.aspx");
        //}

        if (!IsPostBack)
        {
           // FillClassesOt();
          //  FillClassesNum();
        }
    }

    protected void AddClassBTN_Click(object sender, EventArgs e)
    {
        //string TotalClassName = OtClassDDL.SelectedValue + NumClassDDL.SelectedValue;
        //Classes IsExitss = new Classes();
        //List<string> ClassesTotalName = new List<string>();
        //ClassesTotalName = IsExitss.ClassesExites(OtClassDDL.SelectedValue, NumClassDDL.SelectedValue);
        //if (ClassesTotalName.Count() > 0)
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הכיתה קיימת, נסה מספר אחר.');", true);
        //}
        //else
        //{
        //    Classes InsertClass = new Classes();
        //    int res = InsertClass.InsertClass(OtClassDDL.SelectedValue, NumClassDDL.SelectedValue);
        //    if (res == 1)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הכיתה נוספה בהצלחה'); location.href='Admin_Add_Class.aspx';", true);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('עקב תקלה לא ניתן להוסיף מקצוע זה.<br/> אנא נסה מאוחר יותר. במידה והתקלה נמשכת אנא פנה לשירות הלקוחות.');", true);
        //    }
        //}
    }
}