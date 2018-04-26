using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_recover_answers : System.Web.UI.Page
{
    Users User = new Users();
    List<string> l = new List<string>();
    Questions q = new Questions();
    Users u = new Users();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowQ();
        }
    }

    protected void ShowQ()
    {
        string userID = Request.Cookies["UserID"].Value;
        string Bday = Request.Cookies["Bday"].Value;
        l = User.GetUserSecurityDetailsByuserIDandBday(userID, Bday);

        LabelSecurityQ1.InnerText = l[0];
        LabelSecurityQ2.InnerText = l[2];
    }

    protected void CheckAnswer_Click(object sender, EventArgs e)
    {
        string userID = Request.Cookies["UserID"].Value;
        string Bday = Request.Cookies["Bday"].Value;
        l = User.GetUserSecurityDetailsByuserIDandBday(userID, Bday);

        string answer1 = TextBoxSecurityA1.Text;
        string answer2 = TextBoxSecurityA2.Text;

        if (l[1] == answer1 && l[3] == answer2)
        {
            Response.Redirect("pages-recover-changePass.aspx");
        }
        else
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('תשובה אחת או יותר שגויות, נסה שנית')</script>");
        }
    }
}