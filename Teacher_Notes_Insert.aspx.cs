using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teacher_Notes_Insert : System.Web.UI.Page
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

    protected void FillPupils()
    {
        string ClassCode = ChooseClassDLL.SelectedValue;

        Users Pupil = new Users();
        Dictionary<string, string> pupils = new Dictionary<string, string>();

        pupils = Pupil.getPupils(ClassCode);
        PupilsDLL.DataSource = pupils.Values;
        PupilsDLL.DataBind();
        Session["PupilsList"] = pupils;
        PupilsDLL.Enabled = true;
    }

    protected void FillNotes()
    {
        Dictionary<string, string> Notes = new Dictionary<string, string>();
        Notes PupilNote = new Notes();
        Notes = PupilNote.FillNotes();
        NotesDLL.DataSource = Notes.Values;
        NotesDLL.DataBind();
        Session["NotesList"] = Notes;
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

    protected void AddNotes_Click(object sender, EventArgs e)
    {
        if (ChooseClassDLL.SelectedValue != "0" && ChooseLessonsDLL.SelectedValue != "0" && PupilsDLL.SelectedValue != "0" && NotesDLL.SelectedValue != "0")
        {


            string date = DateTime.Today.ToShortDateString();
            string TeacherId = Request.Cookies["UserID"].Value;
            Dictionary<string, string> NotesList = new Dictionary<string, string>();
            NotesList = (Dictionary<string, string>)(Session["NotesList"]);

            Dictionary<string, string> PupilList = new Dictionary<string, string>();
            PupilList = (Dictionary<string, string>)(Session["PupilsList"]);

            string PupilID = KeyByValue(PupilList, PupilsDLL.SelectedValue);
            string NoteID = KeyByValue(NotesList, NotesDLL.SelectedValue);
            string LessonID = ChooseLessonsDLL.SelectedValue;

            Notes InsertPupilNote = new Notes();

            int res1 = InsertPupilNote.InsertNotes(PupilID, NoteID, date, TeacherId, LessonID, TNoteTB.Text);
            if (res1 == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Succesesalert('הערה נוספה בהצלחה');", true);

                string ClassCode = ChooseClassDLL.SelectedValue;
                //string PrivOrColec, string type, string ClassCode
                Users user = new Users();
                List<Users> userList = user.getUserList("Colective", "6", PupilID);

                string message = "התווספה הערת משמעת ב" + ChooseLessonsDLL.SelectedItem;
                string title = "הערת משמעת";

                myPushNot pushNot = new myPushNot(message, title, "1", 7, "default");
                pushNot.RunPushNotification(userList, pushNot);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('הייתה בעיה בהוספת הערת משמעת, בדוק נתונים');", true);
            }
        }

        else ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('נתונים חסרים, אנא מלא את כל השדות');", true);
    }

    protected void ChooseClasssDLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChooseLessonsDLL.Items.Clear();

        Dictionary<string, string> Lessons = new Dictionary<string, string>();
        Teacher ClassesBySubject = new Teacher();
        string techerID = Request.Cookies["UserID"].Value;
        string classCode = ChooseClassDLL.SelectedValue;
        Lessons = ClassesBySubject.FillLessonsAccordingTeacherIdAndClassCode(techerID, classCode);
        ChooseLessonsDLL.DataSource = Lessons;
        ChooseLessonsDLL.DataTextField = "value";
        ChooseLessonsDLL.DataValueField = "key";
        ChooseLessonsDLL.DataBind();
        ChooseLessonsDLL.Enabled = true;
        FillPupils();
    }

    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));

    }
}