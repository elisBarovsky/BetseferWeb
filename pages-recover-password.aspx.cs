using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_recover_password : System.Web.UI.Page
{
    Users User = new Users();
    List<string> l = new List<string>();
    Questions q = new Questions();
    Users u = new Users();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDays();
            FillMonth();
            FillYear();
        }
    }

    protected void FillDays()
    {
        List<string> days = new List<string>();

        for (int i = 1; i <= 31; i++)
        {
            if (i < 10)
            {
                days.Add("0" + i.ToString());
            }
            else
            {
                days.Add(i.ToString());
            }
        }

        DDLday.DataSource = days;
        DDLday.DataBind();
        DDLday.Items.Insert(0, new ListItem("יום"));
    }

    protected void FillMonth()
    {
        List<string> months = new List<string>();

        for (int i = 1; i <= 12; i++)
        {
            if (i < 10)
            {
                months.Add("0" + i.ToString());
            }
            else
            {
                months.Add(i.ToString());
            }
        }

        DDLmonth.DataSource = months;
        DDLmonth.DataBind();
        DDLmonth.Items.Insert(0, new ListItem("חודש"));
    }

    protected void FillYear()
    {
        int year = 1930;
        List<string> years = new List<string>();

        for (int i = 0; year < 2011; i++, year++)
        {
            years.Add(year.ToString());
        }

        DDLyear.DataSource = years;
        DDLyear.DataBind();
        DDLyear.Items.Insert(0, new ListItem("שנה"));
    }

    protected void ButtonCheckUserExist_Click(object sender, EventArgs e)
    {
        string userID = TextBoxUserID.Text;
        string day = DDLday.SelectedValue, month = DDLmonth.SelectedValue, year = DDLyear.SelectedValue;
        string Bday = day + "/" + month + "/" + year;

        Response.Cookies["UserID"].Value = userID;
        Response.Cookies["UserID"].Expires = DateTime.Now.AddMinutes(90);

        Response.Cookies["Bday"].Value = Bday;
        Response.Cookies["Bday"].Expires = DateTime.Now.AddMinutes(90);

        if (day == "יום" || month == "חודש" || year == "שנה")
        {
            Response.Write("<script LANGUAGE='JavaScript' >Erroralert('תאריך הלידה לא יכול להיות ריק')</script>");
            return;
        }
        else if (!u.IsLegalBday(day, month))
        {
            Response.Write("<script LANGUAGE='JavaScript' >Erroralert('תאריך הלידה לא חוקי')</script>");
            return;
        }
        l = User.GetUserSecurityDetailsByuserIDandBday(userID, Bday);

        if (l.Count() == 0)
        {
            Response.Write("<script LANGUAGE='JavaScript' >Erroralert('תאריך הלידה ו/או תעודת הזהות שגויים')</script>");
        }
        else
        {
            Response.Redirect("pages-recover-answers.aspx");
        }
    }
}