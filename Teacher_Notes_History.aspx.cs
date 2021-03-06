﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teacher_Notes_History : System.Web.UI.Page
{
    Dictionary<string, string> List = new Dictionary<string, string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            LoadUser();
            hide(false);
            FillClasses();
            FillSubjects();
            FillNotes();
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

    protected void FilterNotes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (FilterNotes.SelectedValue == "1")//מקצוע
        {
            hide(false);
            ChooseLessonsDLL.Visible = true;
        }
        else if (FilterNotes.SelectedValue == "2")//סוג הערה
        {
            hide(false);
            NotesDLL.Visible = true;
        }
        else if (FilterNotes.SelectedValue == "3")//תלמיד
        {
            hide(false);
            ChooseClassDLL.Visible = true;
        }
        else//הכל
        {
            hide(false);
        }
    }

    protected void FillPupils(object sender, EventArgs e)
    {
        PupilsDLL.Visible = true;
        string ClassCode = "";
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        Classes = (Dictionary<string, string>)(Session["ClassesList"]);
        ClassCode = KeyByValue(Classes, ChooseClassDLL.SelectedValue);

        Users Pupil = new Users();
        Dictionary<string, string> pupils = new Dictionary<string, string>();

        pupils = Pupil.getPupils(ClassCode);
        PupilsDLL.DataSource = pupils.Values;
        PupilsDLL.DataBind();
        Session["PupilsList"] = pupils;
    }

    protected void FillNotes()
    {
        Dictionary<string, string> Notes = new Dictionary<string, string>();
        Notes PupilNote = new Notes();
        string teacherID = Request.Cookies["UserID"].Value;
        Notes = PupilNote.FillNotes();
        NotesDLL.DataSource = Notes.Values;
        NotesDLL.DataBind();
        Session["NotesList"] = Notes;
    }

    protected void FillClasses()
    {
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        string teacherID = Request.Cookies["UserID"].Value;
        Teacher t = new Teacher();
        Classes = t.FillClassOtAccordingTeacherId(teacherID);

        ChooseClassDLL.DataSource = Classes.Values;
        ChooseClassDLL.DataBind();
        Session["ClassesList"] = Classes;
    }

    protected void FillSubjects()
    {
        Dictionary<string, string> Lessons = new Dictionary<string, string>();
        Teacher t = new Teacher();
        string teacherID = Request.Cookies["UserID"].Value;
        Lessons = t.FillLessonsAccordingTeacherId(teacherID);
        ChooseLessonsDLL.DataSource = Lessons;
        ChooseLessonsDLL.DataTextField = "value";
        ChooseLessonsDLL.DataValueField = "key";
        ChooseLessonsDLL.DataBind();
        Session["LessonsList"] = Lessons;
    }

    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));

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

    public void hide(bool ans)
    {
        ChooseLessonsDLL.Visible = ans;
        NotesDLL.Visible = ans;
        PupilsDLL.Visible = ans;
        ChooseClassDLL.Visible = ans;
    }

    protected void FilterNotesBTN_Click(object sender, EventArgs e)
    {
        string FilterType = "";
        string ValueFilter = "";
        string teacherID = Request.Cookies["UserID"].Value;

        if (FilterNotes.SelectedValue == "0") //בחר
        {
            return;
        }
        if (FilterNotes.SelectedValue == "1")//מקצוע
        {
            List = (Dictionary<string, string>)(Session["LessonsList"]);
            FilterType = "dbo.GivenNotes.LessonsCode";
            ValueFilter = ChooseLessonsDLL.SelectedValue;
        }
        else if (FilterNotes.SelectedValue == "2")//הערת משמעת
        {
            List = (Dictionary<string, string>)(Session["NotesList"]);
            FilterType = "dbo.NoteType.CodeNoteType";
            ValueFilter = KeyByValue(List, NotesDLL.SelectedValue);
        }
        else if (FilterNotes.SelectedValue == "3")//תלמיד
        {
            List = (Dictionary<string, string>)(Session["PupilsList"]);
            FilterType = "dbo.Pupil.UserID";
            ValueFilter = KeyByValue(List, PupilsDLL.SelectedValue);
        }
        else//מורה
        {
            FilterType = "dbo.GivenNotes.TeacherID";
            ValueFilter = Request.Cookies["UserID"].Value;
        }

        Notes FilterNote = new Notes();
        
        DataTable dtt = new DataTable();
        dtt= FilterNote.FilterNotes(FilterType, ValueFilter, teacherID);

        if (dtt.Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('אין היסטוריית הערות משמעת שהוזנה על ידך עבור לפי הסינון והמקצוע שנבחר'); ", true);
            GridView1.DataSource = null;
        }
        else
        {
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                dtt.Rows[i][5] = dtt.Rows[i][5].ToString().Replace("<br />", "\n");
            }
            GridView1.DataSource = dtt;
        }      
        GridView1.DataBind();
    }
}