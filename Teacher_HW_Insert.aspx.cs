using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teacher_HW_Insert : System.Web.UI.Page
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
            UserImg.ImageUrl = "/Images/NoImg.png";
            UserImg1.ImageUrl = "/Images/NoImg.png";
        }
        else
        {
            UserImgimg.ImageUrl = UserInfo[6];
            UserImg.ImageUrl = UserInfo[6];
            UserImg1.ImageUrl = UserInfo[6];
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

    protected void AddUserBTN_Click(object sender, EventArgs e)
    {
        string ClassCode = "";
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        ClassCode = ChooseClassDLL.SelectedValue;
        Subject s = new Subject();
        string LessonsCode = s.GetSubjectCodeBySubjectName(ChooseLessonsDLL.SelectedValue);

        string newBDATe = date1.Value;

       // string date = DateTime.Today.ToShortDateString();
        string TeacherId = Request.Cookies["UserID"].Value;

        HomeWork HW = new HomeWork();
        Users u = new Users();
       
        if (newBDATe== "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תאריך לא יכול להיות ריק');", true);
            return;
        }

        string Bday = newBDATe.Substring(8, 2) + "/" + newBDATe.Substring(5, 2) + "/" + newBDATe.Substring(0, 4);

        int res1 = HW.InserHomeWork(LessonsCode, HomeWorkDesc.Text, TeacherId, ClassCode, Bday, ChangeHagashaCB.Checked);

        if (res1 == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('שיעורי בית נוספו בהצלחה'); location.href='Teacher_HW_Insert.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הייתה בעיה בהוספת שיעורי בית, בדוק נתונים');", true);
        }
    }

    protected void ChooseClassDLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        string classCode = ChooseClassDLL.SelectedItem.Value;
        Subject s = new Subject();
        Dictionary<string, string> l = s.GetSubjectsByClassCode(classCode);
        ChooseLessonsDLL.DataSource = l.Values;
        ChooseLessonsDLL.DataBind();
        ChooseLessonsDLL.Enabled = true;
    }

    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));
    }
}