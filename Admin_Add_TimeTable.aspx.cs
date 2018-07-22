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
            //if (Request.Cookies["SelectedCodeClass"].Value != "")
            //{
            //    string ClassCode= Request.Cookies["SelectedCodeClass"].Value;
            //    ddl_clasesAdd.SelectedValue = ClassCode;
            //    CreateEmptyTimeTable(ClassCode);
            //}
        }
    }

    public void LoadUser()
    {
        string AdminId = Request.Cookies["UserID"].Value;
        Users UserInfo_ = new Users();

        List<string> UserInfo = new List<string>();
        UserInfo = UserInfo_.GetUserInfo(AdminId);

        UserNameSpan.InnerText= UserInfo[1] + " " + UserInfo[2];
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
        string Value;

        if ((sender as DropDownList).ID == "ddl_clasesAdd" || (sender as DropDownList).ID == "ddl_clasesEdit")
        {
            Value = "בחר כיתה";
        }
        else Value = "-";
        (sender as DropDownList).Items.Insert(0, new ListItem(Value, "0"));
    }

    protected void CreateEmptyTimeTable(/*string ClaasCode*/)
    {
        Subject subject = new Subject();
        Users user = new Users();
        int counter = 1;

        FillDaysTitles();

        //rows ^
        for (int i = 0; i < 9; i++)
        {
            string[] hours = new string[] { "8:00-8:45", "8:45-9:30", "10:00-10:45", "10:45-11:30", "11:45-12:30", "12:30-13:15", "13:25-14:10", "14:15-15:00","15:00-15:45" };

            TableRow tr = new TableRow();

            TableCell lessonNumber = new TableCell();
            lessonNumber.Text = (i + 1).ToString() + " - "+ hours[i];
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
                string id = "";
                //if (ClaasCode=="")
                //{
                    id = "WeekDay_" + (j + 1).ToString() + "-lesson_" + (i + 1).ToString() + "-ChoosenClass_" + ddl_clasesAdd.SelectedItem.Value;
                //}
                //else
                //{
                //    id = "WeekDay_" + (j + 1).ToString() + "-lesson_" + (i + 1).ToString() + "-ChoosenClass_" + ClaasCode;
                //}
                onclickImg.Attributes.Add("onclick", "event.preventDefault(); window.open('Admin_New_TT_form.aspx?cellID=" + id + "', 'mynewwin', 'width=400,height=470')");
                cell.Controls.Add(onclickImg);

                Label info = new Label();

                TimeTable TT = new TimeTable();
                List<string> CellInfush = TT.GetCellInfo(DateTime.Today.ToShortDateString(),(j+1),(i+1), ddl_clasesAdd.SelectedItem.Value);

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

    protected void No_Option(object sender, EventArgs e)
    {
        TimeTable TT = new TimeTable();
        string classCode = Request.Cookies["SelectedCodeClass"].Value;
        TT.DeleteTempTT(DateTime.Today.ToShortDateString(), classCode);

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('מערכת לא נשמרה.'); ", true);
    }

    protected void ButtonPublish_Click(object sender, EventArgs e)
    {
        TimeTable TT = new TimeTable();

            int rowsAffected = TT.InsertTimeTable(DateTime.Today.ToShortDateString(), int.Parse(ddl_clasesAdd.SelectedItem.Value), true);
            if (rowsAffected > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Succesesalert('מערכת נשמרה ופורסמה בהצלחה'); ", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('קרתה תקלה בעת שמירת המערכת. נא צור קשר עם שירות הלקוחות בטלפון: 1-800-400-400');", true);
            }
    }

    protected void PreparePageToAddNew(object sender, EventArgs e)
    {
        //ButtonSave.Visible = true;
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

    protected void SelectedIndexChanged(object sender, EventArgs e)
    {
        CreateEmptyTimeTable();
    }

    protected void ddl_clasesAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        string count = Request.Cookies["counter"].Value;
        string IsSaveClicked = Request.Cookies["IsSaveClicked"].Value;

        Response.Cookies["SelectedCodeClass"].Value = ddl_clasesAdd.SelectedItem.Value;

        if (ddl_clasesAdd.SelectedItem.Text != "בחר כיתה" && count != "0" && IsSaveClicked == "false")
        {
            ModalPopupExtender1.Show();
            Response.Cookies["counter"].Value = 0.ToString();
           // Response.Cookies["IsSaveClicked"].Value = "false";
        }
        else
        {
            Response.Cookies["counter"].Value = 1.ToString(); 
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Cookies["IsSaveClicked"].Value = "true";

        TimeTable TT = new TimeTable();

        int rowsAffected = TT.InsertTimeTable(DateTime.Today.ToShortDateString(), int.Parse(ddl_clasesAdd.SelectedItem.Value), false);
        if (rowsAffected > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('מערכת נשמרה בהצלחה'); location.href='Admin_Add_TimeTable.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('קרתה תקלה בעת שמירת המערכת. נא צור קשר עם שירות הלקוחות בטלפון: 1-800-400-400');", true);
        }

    }
}