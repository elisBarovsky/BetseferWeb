using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Add_Class : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        //{
        //    Response.Redirect("login.aspx");
        //}

        if (!IsPostBack)
        {
            LoadUser();
            FillClassesOt();
            FillClassesNum();
        }
    }

    public void LoadUser()
    {
        string AdminId = Request.Cookies["UserID"].Value;
        Users UserInfo_ = new Users();

        List<string> UserInfo = new List<string>();
        UserInfo = UserInfo_.GetUserInfo(AdminId);

        UserName.InnerText = UserInfo[1] + " " + UserInfo[2];
        if (UserInfo[6] == "")
        {
            UserImgimg.ImageUrl = "/Images/NoImg.png";
            UserImg1.ImageUrl = "/Images/NoImg.png";
        }
        else
        {
            UserImgimg.ImageUrl = UserInfo[6];
            UserImg1.ImageUrl = UserInfo[6];
        }
    }

    protected void FillClassesOt()
    {
        List<string> ClassesOt = new List<string>();
        Classes ClassGrade = new Classes();
        ClassesOt = ClassGrade.GetClassesOt();
        OtClassDDL.DataSource = ClassesOt;
        OtClassDDL.DataBind();
        Session["ClassesOt"] = ClassesOt;
    }

    protected void FillClassesNum()
    {
        List<string> ClassNum = new List<string>();
        for (int i = 1; i <= 10; i++)
        {
            ClassNum.Add(i.ToString());
        }

        NumClassDDL.DataSource = ClassNum;
        NumClassDDL.DataBind();
        Session["ClassNum"] = ClassNum;
    }

    protected void AddClassBTN_Click(object sender, EventArgs e)
    {
        string TotalClassName = OtClassDDL.SelectedValue + NumClassDDL.SelectedValue;
        Classes IsExitss = new Classes();
        List<string> ClassesTotalName = new List<string>();
        ClassesTotalName = IsExitss.ClassesExites(OtClassDDL.SelectedValue, NumClassDDL.SelectedValue);
        if (ClassesTotalName.Count() > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הכיתה קיימת, נסה מספר אחר.');", true);
        }
        else
        {
            Classes InsertClass = new Classes();
            int res = InsertClass.InsertClass(OtClassDDL.SelectedValue, NumClassDDL.SelectedValue);
            if (res == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הכיתה נוספה בהצלחה'); location.href='Admin_Add_Class.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('עקב תקלה לא ניתן להוסיף מקצוע זה.<br/> אנא נסה מאוחר יותר. במידה והתקלה נמשכת אנא פנה לשירות הלקוחות.');", true);
            }
        }
    }
}