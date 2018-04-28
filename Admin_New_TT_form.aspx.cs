using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_New_TT_form : System.Web.UI.Page
{
    string objSenderID;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        //{
        //    Response.Redirect("login.aspx");
        //}
        //  string id = Request["onclickImg.ID"];
        //object gfhgf = (Button)sender;

        objSenderID = ((System.Web.UI.Page)sender).ClientQueryString;
        
        if (!IsPostBack)
        {
           // FillClassesOt();
          //  FillClassesNum();
        }
    }

    protected void AddClassBTN_Click(object sender, EventArgs e)
    {
  



    }
}