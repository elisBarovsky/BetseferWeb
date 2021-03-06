﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    Users User = new Users();
    List<string> l = new List<string>();
    Questions q = new Questions();
    Users u = new Users();

    protected void Page_Load()
    {
        if (!IsPostBack)
        {
       
        }
    }

    protected void SaveLoginCookie(string ID, string password)
    {
        Response.Cookies["UserID"].Value = ID;
        Response.Cookies["UserID"].Expires = DateTime.Now.AddMinutes(90);
        Response.Cookies["UserPassword"].Value = password;
        Response.Cookies["UserPassword"].Expires = DateTime.Now.AddMinutes(90);
        Response.Cookies["counter"].Value = 0.ToString();
        Response.Cookies["counter"].Expires = DateTime.Now.AddMinutes(90);
        Response.Cookies["IsSaveClicked"].Value = "false";
        Response.Cookies["IsSaveClicked"].Expires = DateTime.Now.AddMinutes(90);
        Response.Cookies["SelectedCodeClass"].Value = "";
        Response.Cookies["SelectedCodeClass"].Expires = DateTime.Now.AddMinutes(90);
    }

    protected void Login1_Authenticate(object sender, EventArgs e)
    {
        string UserID = IDTB.Text, password = passwordTB.Text;
        string isAlreadyLogin = User.IsAlreadyLogin(UserID, password);

        SaveLoginCookie(UserID, password);

        if (isAlreadyLogin != "")
        {
            if (!bool.Parse(isAlreadyLogin))
            {
                Response.Redirect("pages-security.aspx");
            }

            else
            {
                List<string> UserInfo = User.GetUserType(UserID, password);
                int UserType = int.Parse(UserInfo[0]);

                if (UserType == 1)
                {
                    Response.Redirect("AdminDashbord.html");
                }
                else if (UserType == 2)
                {
                    Response.Redirect("TeacherDashbord.html");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('התחבר דרך האפליקציה בבקשה');", true);
                }
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "Erroralert('תעודת הזהות ו/או הסיסמה שהקשת שגויה');", true);
        }
    }
}