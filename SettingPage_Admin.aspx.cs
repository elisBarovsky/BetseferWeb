using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SettingPage_Admin : System.Web.UI.Page
{
    Users User = new Users();
    List<string> l = new List<string>();
    Questions q = new Questions();
    Users u = new Users();

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

        UserNameSpan.InnerText = UserInfo[1] + " " + UserInfo[2];
        if (UserInfo[6] == "")
        {
            UserImg1.ImageUrl = "/Images/NoImg.png";
        }
        else
        {
            UserImg1.ImageUrl = UserInfo[6];
        }
    }

    protected void UploadImgBTN(object sender, EventArgs e)
    {
        string folderPath = Server.MapPath("~/Images/");

        string userID = Request.Cookies["UserID"].Value;
        FileUpload1.SaveAs(folderPath + FileUpload1.FileName);

        Users user = new Users();

        int res = user.UploadImg(userID, "Images/"+ FileUpload1.FileName);
        if (res >0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Succesesalert('התמונה הועלתה בהצלחה. תתעדכן בהתחברות הבאה שלך'); ", true);
        }
        else
        {
            Response.Write("<script LANGUAGE='JavaScript' >Erroralert('בעיה בהעלאת תמונה, נסה שנית מאוחר יותר או פנה לתמיכה')</script>");
        }
    }

    protected void ChangePasswordBTN(object sender, EventArgs e)
    {
        string userID = Request.Cookies["UserID"].Value;
        if (Pass1.Text == Pass2.Text)
        {
            int num = User.ChangePassword(userID, Pass1.Text);
            if (num > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Succesesalert('סיסמתך שונתה בהצלחה'); ", true);
            }
            else Response.Write("<script LANGUAGE='JavaScript' >Erroralert('סעקב בעיות טכניות לא ניתן לשמור את סיסמתך כרגע, אנא נסה במועד מאוחר יותר או פנה לשירות הלקוחות ' )</script>");
        }
        else
        {
            Response.Write("<script LANGUAGE='JavaScript' >Erroralert('הסיסמאות לא תואמות, נסה שנית')</script>");
        }
    }
}