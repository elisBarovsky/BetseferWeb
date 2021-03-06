﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teacher_ContactsList : System.Web.UI.Page
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
            FillClasses();
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
    protected void FillClasses()
    {
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        Teacher ClassesAccordingToTeacherID = new Teacher();
        string teacherID = Request.Cookies["UserID"].Value;
        Classes = ClassesAccordingToTeacherID.FillClassOtAccordingTeacherId(teacherID);
        ChooseClassDLL.DataSource = Classes.Values;
        ChooseClassDLL.DataBind();
        Session["ClassesList"] = Classes;
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

    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));

    }

    protected void TLBTN_Click(object sender, EventArgs e)
    {
        if (ChooseClassDLL.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('עליך לבחור כיתה');", true);
            return;
        }
        if (FilterNotes.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('עליך לבחור קבוצה');", true);
            return;
        }
        string UserTypeFilter = FilterNotes.SelectedValue;

        Dictionary<string, string> List = new Dictionary<string, string>();
        List = (Dictionary<string, string>)(Session["ClassesList"]);
        string ClassFilter = KeyByValue(List, ChooseClassDLL.SelectedValue); ;

        TelphoneList TL = new TelphoneList();
        GridView1.DataSource = TL.FilterTelphoneList(UserTypeFilter, ClassFilter);
        GridView1.DataBind();
    }
}