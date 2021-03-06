﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teacher_HW_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }
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
        //string LessonsCode = s.GetSubjectCodeBySubjectName(ChooseLessonsDLL.SelectedValue);
        string LessonsCode = ChooseLessonsDLL.SelectedValue;

        string newBDATe = date1.Value;

       // string date = DateTime.Today.ToShortDateString();
        string TeacherId = Request.Cookies["UserID"].Value;

        HomeWork HW = new HomeWork();
        Users u = new Users();
       
        if (newBDATe== "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('תאריך לא יכול להיות ריק');", true);
            return;
        }
        string todaydate = "";
        if (DateTime.Today.Month<10)
        {
            todaydate = DateTime.Today.Day + "/0" + DateTime.Today.Month + "/" + DateTime.Today.Year;

        }
        else
        {
            todaydate = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year ;
        }
        string Bday = newBDATe.Substring(8, 2) + "/" + newBDATe.Substring(5, 2) + "/" + newBDATe.Substring(0, 4);

        int res1 = HW.InserHomeWork(LessonsCode, HomeWorkDesc.Text, TeacherId, ClassCode, Bday, ChangeHagashaCB.Checked, todaydate);

        if (res1 == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Succesesalert('שיעורי בית נוספו בהצלחה'); ", true);

            //string PrivOrColec, string type, string ClassCode
            Users user = new Users();
            List<Users> userList = user.getUserList("Colective","4", ClassCode);

            string message = "נוספו שיעורי בית ב" + ChooseLessonsDLL.SelectedItem;
            string title = "שיעורי בית";

            myPushNot pushNot = new myPushNot(message, title, "1", 7, "default");
            pushNot.RunPushNotification(userList, pushNot);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('הייתה בעיה בהוספת שיעורי בית, בדוק נתונים');", true);
        }
    }

    protected void ChooseClassDLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        string classCode = ChooseClassDLL.SelectedItem.Value;
        Subject s = new Subject();
        string teacherID = Request.Cookies["UserID"].Value;
       
        Dictionary<string, string> Lessons = new Dictionary<string, string>();
        Teacher ClassesBySubject = new Teacher();
        Lessons = ClassesBySubject.FillLessonsAccordingTeacherIdAndClassCode(teacherID, classCode);
        ChooseLessonsDLL.DataSource = Lessons;
        ChooseLessonsDLL.DataTextField = "value";
        ChooseLessonsDLL.DataValueField = "key";
        ChooseLessonsDLL.DataBind();
    }

    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));
    }
}