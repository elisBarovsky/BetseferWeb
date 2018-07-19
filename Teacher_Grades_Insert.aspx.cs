using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teacher_Grades_Insert : System.Web.UI.Page
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

    protected void FillPupils(object sender, EventArgs e)
    {
        CreatePupilsListByClassCode();
    }

    protected void CreatePupilsListByClassCode()
    {
        tableGrades.Rows.Clear();
        string ClassTotalName = ChooseClassDLL.SelectedValue;
        Classes c = new Classes();
        string ClassCode = c.GetClassCodeAccordingToClassFullName(ClassTotalName);

        List<Dictionary<string, string>> pupils = new List<Dictionary<string, string>>();
        Users u = new Users();
        pupils = u.getPupilsByClassCodeGrades(ClassCode);
        string[] titles = new string[] {  "ת.ז.", "שם", "ציון" };
        TableRow tr = new TableRow();
        int counter = 0;
        for (int i = 0; i < 3; i++)
        {
            TableCell title = new TableCell();
            title.CssClass = "DDL_TD";
            title.Style.Add("font-weight", "bold");
            title.Text = titles[i];
            tr.Cells.Add(title);
        }
        tableGrades.Rows.Add(tr);

        for (int i = 0; i < pupils.Count; i++)
        {
            TableRow row = new TableRow();

            TableCell id = new TableCell();
            id.CssClass = "DDL_TD";
            id.ID = "id" + counter;
            id.Text = pupils[i]["UserId"];
            row.Cells.Add(id);

            TableCell name = new TableCell();
            name.CssClass = "DDL_TD";
            name.ID = "name" + counter;
            name.Text = pupils[i]["UserName"];
            row.Cells.Add(name);

            TableCell grade = new TableCell();
            grade.CssClass = "DDL_TD";
            grade.ID = "grade" + counter;
            TextBox tb = new TextBox();
            tb.ID = "gradeTB" + counter;
            tb.Attributes["type"] = "number";
            tb.Attributes["min"] = "0";
            tb.Attributes["max"] = "100";
            grade.Controls.Add(tb);
            row.Cells.Add(grade);


            tableGrades.Rows.Add(row);
            counter++;
        }
        tableGrades.DataBind();

    }


    protected void FillFirstItem(object sender, EventArgs e)
    {
        string value = "";

        if ((sender as DropDownList).ID == "ChooseClassDLL")
        {
            value = "בחר כיתה";
        }
        else value = "בחר מקצוע";

        (sender as DropDownList).Items.Insert(0, new ListItem(value, "0"));
    }

    protected void AddGrades_Click(object sender, EventArgs e)
    {
        string codeLesson = ChooseLessonsDLL.SelectedValue;
        string teacherId = Request.Cookies["UserID"].Value;
        string NewDate = date1.Value;
        string today = DateTime.Today.ToShortDateString();

        
        if (NewDate == "" || ChooseLessonsDLL.SelectedValue == "0" || ChooseClassDLL.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('לא ניתן להשאיר שדות רקים');", true);
            return;
        }

        string ExamDate = NewDate.Substring(8, 2) + "/" + NewDate.Substring(5, 2) + "/" + NewDate.Substring(0, 4);
        DateTime d = DateTime.Parse(ExamDate);

        if (DateTime.Today < d)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('אופס! תאריך הבחינה עוד לא הגיע');", true);
            return;
        }

        int num = 0;
        for (int i = 0; i < tableGrades.Rows.Count; i++)
        {
            string gradeID = "gradeTB" + (i - 1);
            string idID = "id" + (i - 1);
            int grade;
            if (IsGradeMiss())
            {
                grade = 0;
            }

            grade = int.Parse((tableGrades.Rows[i].Cells[2].FindControl(gradeID) as TextBox).Text);
            string pupilId = tableGrades.Rows[i].Cells[0].Text;
            Grades g = new Grades();
            //num += g.InsertGrade(pupilId, teacherId, codeLesson, ExamDate, grade);
        }

        if (num == (tableGrades.Rows.Count - 1))
        {
            ChooseClassDLL.SelectedValue = "0";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Succesesalert('ציונים נשמרו בהצלחה');", true);
            Users user = new Users();
            List <Users> userList= user.getUserList("ff","g","gg");

            string message = "נמאס לי מקוד!";
            string title = "דקלה נשמה";

            myPushNot pushNot = new myPushNot(message, title, "1", 7, "default");
            pushNot.RunPushNotification(userList, pushNot);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('נתקלנו בבעיה בשמירת הנתונים. אנא צור קשר עם שירות הלקוחות.');", true);
        }
    }

    public bool IsGradeMiss()
    {
        bool empty = false;

        for (int i = 1; i < tableGrades.Rows.Count; i++)
        {
            string gradeID = "gradeTB" + (i - 1);

            if ((tableGrades.Rows[i].Cells[0].FindControl(gradeID) as TextBox).Text == "")
            {
                empty = true;
                break;
            }
        }
        return empty;
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

    protected void ChooseLessonsDLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChooseClassDLL.Items.Clear();

        Dictionary<string, string> Classes = new Dictionary<string, string>();
        Teacher ClassesBySubject = new Teacher();
        string techerID = Request.Cookies["UserID"].Value;
        string lessonCode = ChooseLessonsDLL.SelectedValue;
        Classes = ClassesBySubject.FillClassOtAccordingTeacherIdAndSubjectCode(techerID, lessonCode);
        ChooseClassDLL.DataSource = Classes.Values;
        ChooseClassDLL.DataBind();
    }
}