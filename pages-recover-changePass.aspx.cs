using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_recover_changePass : System.Web.UI.Page
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

    protected void ChangePasswordBTN(object sender, EventArgs e)
    {
        string userID = Request.Cookies["UserID"].Value;
        if (Pass1.Text == Pass2.Text)
        {
            int num = User.ChangePassword(userID, Pass1.Text);
            if (num > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Succesesalert('סיסמתך שונתה בהצלחה'); ", true);
            }
            else Response.Write("<script LANGUAGE='JavaScript' >Erroralert('סעקב בעיות טכניות לא ניתן לשמור את סיסמתך כרגע, אנא נסה במועד מאוחר יותר או פנה לשירות הלקוחות ' )</script>");
        }
        else
        {
            Response.Write("<script LANGUAGE='JavaScript' >Erroralert('הסיסמאות לא תואמות, נסה שנית')</script>");
        }
    }
}