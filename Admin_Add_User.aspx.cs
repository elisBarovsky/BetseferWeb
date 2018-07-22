using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Add_User : System.Web.UI.Page
{
    Users u = new Users();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            LoadUser();
            VisiblePupilFalse(false);
            VisibleTeacherFalse(false);
            AddUserBTN.Visible = false;
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


    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));
    }


    protected void UserTypeDLL_CheckedChanged(Object sender, EventArgs e)
    {
        Clear();
        if (UserTypeDLL.SelectedValue == "4")
        {
            VisiblePupilFalse(true);
            VisibleTeacherFalse(false);
        }
        else if (UserTypeDLL.SelectedValue == "2")
        {
            VisiblePupilFalse(false);
            VisibleTeacherFalse(true);
        }
        else if (UserTypeDLL.SelectedValue == "3")
        {
            VisibleTeacherFalse(false);
            VisiblePupilFalse(false);
        }
        else
        {
            VisibleTeacherFalse(false);
            VisiblePupilFalse(false);
        }
        AddUserBTN.Visible = true;
    }

    protected void VisiblePupilFalse(bool ans)
    {
        ClassOtDLL.Visible = ans;
        ClassLBL.Visible = ans;
    }

    protected void VisibleTeacherFalse(bool ans)
    {
        MainTeacher.Visible = ans;
        MainTeacherCB.Visible = ans;
    }

    protected void AddUserBTN_Click(object sender, EventArgs e)
    {
        string folderPath = Server.MapPath("~/Images/");
        string ImgPath = "";
        if (FileUpload1.FileName != "")
        {
            FileUpload1.SaveAs(folderPath + FileUpload1.FileName);
            ImgPath = "/Images/" + FileUpload1.FileName;
        }
        else
        {
            ImgPath = "/Images/NoImg.png";
        }
        string newBDATe = date1.Value;
        if (newBDATe == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('תאריך לא יכול להיות ריק');", true);
            return;
        }
        
        else if (ClassOtDLL.SelectedValue == "בחר")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('לא נבחרה כיתה.');", true);
            return;
        }
        string Bday = newBDATe.Substring(8, 2) + "/" + newBDATe.Substring(5, 2) + "/" + newBDATe.Substring(0, 4);
        Users NewUser = new Users(UserIDTB.Text, FNameTB.Text, LNameTB.Text, Bday, ImgPath, "", PasswordTB.Text, TelephoneNumberTB.Text, UserTypeDLL.SelectedValue);
        Administrator admin = new Administrator();
        int res1 = admin.AddUser(NewUser);
        if (res1 == 1)
        {
            if (UserTypeDLL.SelectedValue == "4")
            {
                Administrator a = new Administrator();
                int num = a.AddPupil(UserIDTB.Text, int.Parse(ClassOtDLL.SelectedValue));
            }
            else if (UserTypeDLL.SelectedValue == "2")
            {
                Administrator d = new Administrator();
                string IsMain = "0";
                if (MainTeacherCB.Checked) { IsMain = "1"; int num1 = d.AddClassTeacher(UserIDTB.Text, ClassOtDLL.SelectedItem.ToString()); }

                int num2 = d.AddTeacher(UserIDTB.Text, IsMain);
            }
            else if (UserTypeDLL.SelectedValue == "3")
            {
                
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Succesesalert('משתמש נוסף בהצלחה');", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('הייתה בעיה בעדכון המשתמש, בדוק נתונים');", true);
        }
    }

    protected void Clear()
    {
        UserIDTB.Text = "";
        FNameTB.Text = "";
        LNameTB.Text = "";
        PasswordTB.Text = "";
        TelephoneNumberTB.Text = "";
        MainTeacherCB.Checked = false;
        ClassOtDLL.Visible = false;
        ClassLBL.Visible = false;
        ClassesWithoutMainTeacher.Visible = false;
    }

    protected void MainTeacherCB_CheckedChanged(object sender, EventArgs e)
    {
        if (MainTeacherCB.Checked)
        {
            ClassesWithoutMainTeacher.Visible = true;
        }
        else
        {
            ClassesWithoutMainTeacher.Visible = false;
        }
    }
}