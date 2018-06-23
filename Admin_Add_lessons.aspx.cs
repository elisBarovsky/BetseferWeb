using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Add_lessons : System.Web.UI.Page
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


    protected void AddLessonsBTN_Click(object sender, EventArgs e)
    {
        Subject newS = new Subject();
        string newSubject = LessonsNameTB.Text;
        if (newS.IsExists(newSubject))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('המקצוע כבר קיים ברשימת המקצועות.');", true);
            return;
        }
        else if (newSubject == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('לא הוזן מקצוע.');", true);
            return;
        }
        else
        {
            int answer = newS.AddNewSubject(newSubject);
            if (answer > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Succesesalert('המקצוע נוסף בהצלחה');", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('עקב תקלה לא ניתן להוסיף מקצוע זה.<br/> אנא נסה מאוחר יותר. במידה והתקלה נמשכת אנא פנה לשירות הלקוחות.');", true);
            }
        }
    }
}