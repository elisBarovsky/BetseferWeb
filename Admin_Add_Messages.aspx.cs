using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void TypeMessageChoosen(object sender, EventArgs e)
    {
        string selected = messageTypeRBL.SelectedValue;
        if (selected == "private")
        {

        }
        else
        {

        }
    }

    protected void TypeUserChoosen(object sender, EventArgs e)
    {
        string selected = userTypeRBL.SelectedValue;
        if (selected == "parents")
        {

        }
        else
        {

        }
    }
}