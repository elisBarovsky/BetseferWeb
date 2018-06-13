using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_security : System.Web.UI.Page
{
    Users User = new Users();
    List<string> l = new List<string>();
    Questions q = new Questions();
    Users u = new Users();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        
        }
    }

    protected void UpdateQuestion(object sender, EventArgs e)
    {
        int q1 = int.Parse(DropDownList_Qlist1.SelectedItem.Value);
        string a1 = TextBox_answer1.Text;
        int q2 = int.Parse(DropDownList_Qlist2.SelectedItem.Value);
        string a2 = TextBox_answer2.Text;
        string id = Request.Cookies["UserID"].Value;

        if (a1 =="" || a2== "")
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('אחת או יותר מהתשובות ריקות, הקלד תשובותך')</script>");
        }
        else
        {
            int num = User.SaveQuestion(id, q1, a1, q2, a2);

            if (num > 0)
            {
                Users User2 = new Users();
                int result = User2.ChangeFirstLogin(id);
                Users User4 = new Users();
                switch (int.Parse(User4.GetUserType(id, Request.Cookies["UserPassword"].Value)))
                {
                    case 1:
                        Response.Redirect("AdminDashbord.html");
                        break;
                    case 2:
                        Response.Redirect("TeacherDashbord.html");
                        break;
                }
            }
        }
    }
    
    protected void CheckQ2(object sender, EventArgs e)
    {
        if (int.Parse(DropDownList_Qlist2.SelectedItem.Value) == int.Parse(DropDownList_Qlist1.SelectedItem.Value))
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('אסור 2 שאלות זהות, בחר שאלה אחרת')</script>");
        }
    }

    protected void FillFirstItem(object sender, EventArgs e)
    {
        string value = "";

        if ((sender as DropDownList).ID == "DropDownList_Qlist1")
        {
            value = "בחר שאלת הזדהות ראשונה";
        }
        else value = "בחר שאלת הזדהות שנייה";

        (sender as DropDownList).Items.Insert(0, new ListItem(value, "0"));
    }
}