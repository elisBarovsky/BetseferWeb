using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Add_TimeTable : System.Web.UI.Page
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
       
        //ddl_clasesAdd_SelectedIndexChanged(sender, e);

    }

    public void LoadUser()
    {
        string AdminId = Request.Cookies["UserID"].Value;
        Users UserInfo_ = new Users();

        List<string> UserInfo = new List<string>();
        UserInfo = UserInfo_.GetUserInfo(AdminId);

        UserName.InnerText= UserInfo[1] + " " + UserInfo[2];
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

    protected void FillFirstItem(object sender, EventArgs e)
    {
        string Value;

        if ((sender as DropDownList).ID == "ddl_clasesAdd" || (sender as DropDownList).ID == "ddl_clasesEdit")
        {
            Value = "בחר כיתה";
        }
        else Value = "-";
        (sender as DropDownList).Items.Insert(0, new ListItem(Value, "0"));
    }

    protected void CreateEmptyTimeTable()
    {
        Subject subject = new Subject();
        Users user = new Users();
        int counter = 1;
        Dictionary<int, string> subjects = subject.getSubjects();
        Dictionary<string, string> teachers = user.GetTeachers();

        FillDaysTitles();

        //rows ^
        for (int i = 0; i < 9; i++)
        {
            TableRow tr = new TableRow();

            TableCell lessonNumber = new TableCell();
            lessonNumber.Text = (i + 1).ToString();
            lessonNumber.CssClass = "DDL_TD";
            tr.Cells.Add(lessonNumber);

            //the days <>
            for (int j = 0; j < 6; j++)
            {
                TableCell cell = new TableCell();
                cell.CssClass = "DDL_TD";

                ImageButton onclickImg = new ImageButton();
                onclickImg.ImageUrl = "Images/editIcon.png";
                onclickImg.Style.Add("height", "20px");  
                string id= "WeekDay_" + (j + 1).ToString() + "-lesson_" + (i + 1).ToString()+"-ChoosenClass_"+ ddl_clasesAdd.SelectedItem.Value;
                onclickImg.Attributes.Add("onclick", "event.preventDefault(); window.open('Admin_New_TT_form.aspx?cellID=" + id + "', 'mynewwin', 'width=600,height=600')");
                cell.Controls.Add(onclickImg);

                Label info = new Label();

                TimeTable TT = new TimeTable();
                List<string> CellInfush = TT.GetCellInfo(DateTime.Today.ToShortDateString(),(j+1),(i+1), int.Parse(ddl_clasesAdd.SelectedItem.Value));

                if (CellInfush.Count==0)
                {
                    info.Text = "";
                }
                else
                {
                    info.Text = CellInfush[0] + " " + CellInfush[1];
                }

                cell.Controls.Add(info);
                tr.Cells.Add(cell);
                counter++;
            }
         
            TimeTable.Rows.Add(tr);
        }
    }

    protected void FillDaysTitles()
    {
        string[] days = new string[] { "שיעור", "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי" };
        //TimeTable;
        TableRow tr = new TableRow();

        for (int i = 0; i < days.Length; i++)
        {
            TableCell cell = new TableCell();
            cell.CssClass = "bg-purple";
            cell.Text = days[i];
            tr.Cells.Add(cell);
        }
        TimeTable.Rows.Add(tr);
        TimeTable.DataBind();
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        TimeTable TT = new TimeTable();

        // List<Dictionary<string, string>> matrix = new List<Dictionary<string, string>>();
        //string classCode = ddl_clasesAdd.SelectedValue;
        //string CodeLesson; //מקצוע
        //string teacherID;
        //int counter = 1;
        //bool flag = false;
        //// rows - ^.
        //for (int i = 1; !flag && i < TimeTable.Rows.Count; i++)
        //{
        //    // cells - the days <>.
        //    for (int j = 1; j < TimeTable.Rows[i].Cells.Count; j++)
        //    {
        //        string subjectID = "DDLsubject" + counter;
        //        string TID = "DDLteacher" + counter;
        //        CodeLesson = (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as DropDownList).SelectedValue;
        //        teacherID = (TimeTable.Rows[i].Cells[j].FindControl(TID) as DropDownList).SelectedValue;
        //        if (CodeLesson == "0" && teacherID != "0")
        //        {
        //            flag = true;
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('לא ניתן להזין מורה ללא מקצוע נלמד.');", true);
        //        }
        //        else if (CodeLesson != "0" && teacherID == "0")
        //        {
        //            flag = true;
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('שים לב! לא ניתן להזין מקצוע ללא מורה.');", true);
        //        }
        //        else if (CodeLesson != "0" && teacherID != "0")
        //        {
        //            Dictionary<string, string> lessonInTimeTable = new Dictionary<string, string>();
        //            lessonInTimeTable.Add("classCode", classCode); //className
        //            lessonInTimeTable.Add("CodeWeekDay", j.ToString()); //numDay
        //            lessonInTimeTable.Add("ClassTimeCode", i.ToString()); //numLesson - 1 is the first lesson.
        //            lessonInTimeTable.Add("CodeLesson", CodeLesson);
        //            lessonInTimeTable.Add("TeacherID", teacherID);

        //            matrix.Add(lessonInTimeTable);
        //        }
        //        else
        //        {
        //            Dictionary<string, string> empty = new Dictionary<string, string>();
        //            empty.Add("classCode", "empty");
        //            matrix.Add(empty);
        //        }

        //        counter++;
        //    }
        // }
        //if (!flag)
        //{
      //  int setNewCode =;
            int rowsAffected = TT.InsertTimeTable(DateTime.Today.ToShortDateString(), int.Parse(ddl_clasesAdd.SelectedItem.Value), CheckBox1.Checked);
            if (rowsAffected > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('מערכת נשמרה בהצלחה'); location.href='Admin_Add_TimeTable.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('קרתה תקלה בעת שמירת המערכת. נא צור קשר עם שירות הלקוחות בטלפון: 1-800-400-400');", true);
            }

    }

    protected void PreparePageToUpdate(object sender, EventArgs e)
    {
        ButtonSave.Visible = false;
        ddl_clasesAdd.ClearSelection();
        ddl_clasesAdd.Visible = false;
        ClearTimeTable();
    }

    protected void PreparePageToAddNew(object sender, EventArgs e)
    {
        ButtonSave.Visible = true;
        ddl_clasesAdd.SelectedValue = "0";
        ddl_clasesAdd.Visible = true;
        ClearTimeTable();
    }

    protected void ClearTimeTable()
    {
        int counter = 1;
        for (int i = 1; i < TimeTable.Rows.Count; i++)
        {
            // cells - the days <>.
            for (int j = 1; j < TimeTable.Rows[i].Cells.Count; j++)
            {
                string subjectID = "DDLsubject" + counter;
                string TID = "DDLteacher" + counter;
                (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as DropDownList).SelectedValue = "0";
                (TimeTable.Rows[i].Cells[j].FindControl(TID) as DropDownList).SelectedValue = "0";

                counter++;
            }
        }

    }

    protected void FillTimeTableAccordingToClassCode(int classCode)
    {
        Subject subject = new Subject();
        //Users user = new Users();
        int counter = 1;
        TimeTable TT = new TimeTable();

        //TT from the DB
        List<Dictionary<string, string>> allLessons = TT.GetTimeTableAcordingToClassCode(classCode);
        //CreateEmptyTimeTable();
        //rows ^
        for (int i = 1; i < TimeTable.Rows.Count; i++)
        {

            for (int j = 1; j < TimeTable.Rows[i].Cells.Count; j++)
            {
                Dictionary<string, string> lessonInTT = ReturnIfLessonExsistsInTT(i, j, allLessons);
                string subjectID = "DDLsubject" + counter;
                string TID = "DDLteacher" + counter;

                if (lessonInTT.Count > 0)
                {

                    (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as DropDownList).SelectedValue = lessonInTT["CodeLesson"];
                    (TimeTable.Rows[i].Cells[j].FindControl(TID) as DropDownList).SelectedValue = lessonInTT["TeacherId"];
                }
                else
                {
                    (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as DropDownList).SelectedValue = "0";
                    (TimeTable.Rows[i].Cells[j].FindControl(TID) as DropDownList).SelectedValue = "0";
                }

                counter++;
            }

        }
    }

    protected Dictionary<string, string> ReturnIfLessonExsistsInTT(int lessonNumber, int weekDay, List<Dictionary<string, string>> TimeTable)
    {
        //return just the specific lesson if exists in row number and day.
        Dictionary<string, string> lessonInTT = new Dictionary<string, string>();

        for (int i = 0; i < TimeTable.Count; i++)
        {
            Dictionary<string, string> tempLesson = TimeTable[i];
            if (tempLesson["ClassTimeCode"] == lessonNumber.ToString() && tempLesson["CodeWeekDay"] == weekDay.ToString())
            {
                return lessonInTT = tempLesson;
            }
        }

        return lessonInTT;
    }

    protected void ddl_clasesAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        CreateEmptyTimeTable();
    }
}