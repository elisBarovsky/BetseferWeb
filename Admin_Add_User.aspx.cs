﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Add_User : System.Web.UI.Page
{
    Users u = new Users();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        //{
        //    Response.Redirect("login.aspx");
        //}

        if (!IsPostBack)
        {
            LoadUser();
            VisiblePupilFalse(false);
            VisibleTeacherFalse(false);
            VisibleParentFalse(false);
            AddUserBTN.Visible = false;
            FillNumChilds();
            HideChildTBID(false);
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


    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));
    }

    private void FillNumChilds()
    {
        List<int> NumChild = new List<int>();
        for (int i = 1; i < 7; i++)
        {
            NumChild.Add(i);
        }
        NumOfChildDDL.DataSource = NumChild;
        NumOfChildDDL.DataBind();
    }

    protected void UserTypeDLL_CheckedChanged(Object sender, EventArgs e)
    {
        Clear();
        if (UserTypeDLL.SelectedValue == "4")
        {
            VisiblePupilFalse(true);
            VisibleTeacherFalse(false);
            VisibleParentFalse(false);
            HideChildTBID(false);
        }
        else if (UserTypeDLL.SelectedValue == "2")
        {
            VisiblePupilFalse(false);
            VisibleTeacherFalse(true);
            VisibleParentFalse(false);
            HideChildTBID(false);
        }
        else if (UserTypeDLL.SelectedValue == "3")
        {
            VisibleParentFalse(true);
            VisibleTeacherFalse(false);
            VisiblePupilFalse(false);
            HideChildTBID(false);
        }
        else
        {
            VisibleTeacherFalse(false);
            VisiblePupilFalse(false);
            VisibleParentFalse(false);
            HideChildTBID(false);
        }
        AddUserBTN.Visible = true;
    }

    protected void VisiblePupilFalse(bool ans)
    {
        //GroupAgeLBL.Visible = ans;
        //GroupAgeDLL.Visible = ans;
        ClassOtDLL.Visible = ans;
        ClassLBL.Visible = ans;
    }

    protected void VisibleParentFalse(bool ans)
    {
        ChildIDLBL.Visible = ans;
        NumOfChildDDL.Visible = ans;
        NumChildLBL.Visible = ans;
        ChildI1DTB.Visible = ans;
    }

    protected void HideChildTBID(bool ans)
    {
        ChildI2DTB.Visible = ans;
        ChildI3DTB.Visible = ans;
        ChildI4DTB.Visible = ans;
        ChildI5DTB.Visible = ans;
        ChildI6DTB.Visible = ans;
    }

    protected void VisibleTeacherFalse(bool ans)
    {
        MainTeacher.Visible = ans;
        MainTeacherCB.Visible = ans;
    }

    protected void AddUserBTN_Click(object sender, EventArgs e)
    {
        string folderPath = Server.MapPath("~/Images/");
        string ImgPath = "";
        if (FileUpload1.FileName != "")
        {
            FileUpload1.SaveAs(folderPath + FileUpload1.FileName);
            ImgPath = "/Images/" + FileUpload1.FileName;
        }
        string newBDATe = date1.Value;
        if (newBDATe == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תאריך לא יכול להיות ריק');", true);
            return;
        }
        
        else if (ClassOtDLL.SelectedValue == "בחר")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('לא נבחרה כיתה.');", true);
            return;
        }
        string Bday = newBDATe.Substring(8, 2) + "/" + newBDATe.Substring(5, 2) + "/" + newBDATe.Substring(0, 4);
        Users NewUser = new Users(UserIDTB.Text, FNameTB.Text, LNameTB.Text, Bday, ImgPath, "", PasswordTB.Text, TelephoneNumberTB.Text, UserTypeDLL.SelectedValue);
        Administrator admin = new Administrator();
        int res1 = admin.AddUser(NewUser);
        if (res1 == 1)
        {
            if (UserTypeDLL.SelectedValue == "4")
            {
                Administrator a = new Administrator();
                int num = a.AddPupil(UserIDTB.Text, int.Parse(ClassOtDLL.SelectedValue));
            }
            else if (UserTypeDLL.SelectedValue == "2")
            {
                Administrator d = new Administrator();
                string IsMain = "0";
                if (MainTeacherCB.Checked) { IsMain = "1"; int num1 = d.AddClassTeacher(UserIDTB.Text, ClassOtDLL.SelectedItem.ToString()); }

                int num2 = d.AddTeacher(UserIDTB.Text, IsMain);
            }
            else if (UserTypeDLL.SelectedValue == "3")
            {
                //string[] ChildID = new string[int.Parse(NumOfChildDDL.SelectedValue)];
                string[] ChildID = new string[6];

                ChildID[0] = ChildI1DTB.Text;
                ChildID[1] = ChildI2DTB.Text;
                ChildID[2] = ChildI3DTB.Text;
                ChildID[3] = ChildI4DTB.Text;
                ChildID[4] = ChildI5DTB.Text;
                ChildID[5] = ChildI6DTB.Text;

                for (int i = 0; i < ChildID.Length; i++)
                {
                    if (ChildID[i] != "")
                    {
                        Users GetPupilClass = new Users();
                        string ChildCodeClass = GetPupilClass.GetPupilOtClass(ChildID[i]);
                        Administrator AddMoreThanOneChild = new Administrator();
                        AddMoreThanOneChild.AddParent(UserIDTB.Text, ChildID[i], ChildCodeClass);
                    }
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('משתמש נוסף בהצלחה'); location.href='Admin_Add_User.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הייתה בעיה בעדכון המשתמש, בדוק נתונים');", true);
        }
    }

    protected void Clear()
    {
        UserIDTB.Text = "";
        FNameTB.Text = "";
        LNameTB.Text = "";
        PasswordTB.Text = "";
        TelephoneNumberTB.Text = "";
        MainTeacherCB.Checked = false;
        ClassOtDLL.Visible = false;
        ClassLBL.Visible = false;
        ChildI1DTB.Text = "";
        ChildI2DTB.Text = "";
        ChildI3DTB.Text = "";
        ChildI4DTB.Text = "";
        ChildI5DTB.Text = "";
        ChildI6DTB.Text = "";
        ClassesWithoutMainTeacher.Visible = false;
    }

    protected void MainTeacherCB_CheckedChanged(object sender, EventArgs e)
    {
        if (MainTeacherCB.Checked)
        {
            ClassesWithoutMainTeacher.Visible = true;
            //ClassLBL.Visible = true;
        }
        else
        {
            ClassesWithoutMainTeacher.Visible = false;
            //ClassLBL.Visible = false;
        }
    }

    protected void NumOfChildDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (NumOfChildDDL.SelectedValue)
        {
            case "1":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = false;
                ChildI3DTB.Visible = false;
                ChildI4DTB.Visible = false;
                ChildI5DTB.Visible = false;
                ChildI6DTB.Visible = false;
                break;
            case "2":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = true;
                ChildI3DTB.Visible = false;
                ChildI4DTB.Visible = false;
                ChildI5DTB.Visible = false;
                ChildI6DTB.Visible = false;
                break;
            case "3":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = true;
                ChildI3DTB.Visible = true;
                ChildI4DTB.Visible = false;
                ChildI5DTB.Visible = false;
                ChildI6DTB.Visible = false;
                break;
            case "4":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = true;
                ChildI3DTB.Visible = true;
                ChildI4DTB.Visible = true;
                ChildI5DTB.Visible = false;
                ChildI6DTB.Visible = false;
                break;
            case "5":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = true;
                ChildI3DTB.Visible = true;
                ChildI4DTB.Visible = true;
                ChildI5DTB.Visible = true;
                ChildI6DTB.Visible = false;
                break;
            case "6":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = true;
                ChildI3DTB.Visible = true;
                ChildI4DTB.Visible = true;
                ChildI5DTB.Visible = true;
                ChildI6DTB.Visible = true;
                break;
        }
    }
}