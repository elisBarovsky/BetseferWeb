﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Update_User : System.Web.UI.Page
{
    string tempList = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        //{
        //    Response.Redirect("login.aspx");
        //}

        if (!IsPostBack)
        {
            LoadUser();
            VisiblePupil(false);
            VisibleOtherUsers(false);
            ClearAll();
            UpdateUserBTN.Visible = false;
        //    FillNumChilds();
            NumChildLBL.Visible = false;
          //  NumChildDDL.Visible = false;
            VisibleParent(false);
            ChoosenNumChildLBL.Visible = false;
          //  FillDays();
         //   FillMonth();
          //  FillYear();
            HideChildTBID(false);
        }
    }

    protected void HideChildTBID(bool ans)
    {
        ChildI2DTB.Visible = ans;
        ChildI3DTB.Visible = ans;
        ChildI4DTB.Visible = ans;
        ChildI5DTB.Visible = ans;
        ChildI6DTB.Visible = ans;
    }

    //private void FillNumChilds()
    //{
    //    List<int> NumChild = new List<int>();
    //    for (int i = 0; i < 7; i++)
    //    {
    //        NumChild.Add(i);
    //    }

    //    NumChildDDL.DataSource = NumChild;
    //    NumChildDDL.DataBind();
    //    ChoosenNumChildDDL.DataSource = NumChild;
    //    ChoosenNumChildDDL.DataBind();
    //}

    public void LoadUser()
    {
        string AdminId = Request.Cookies["UserID"].Value;
        Users UserInfo_ = new Users();

        List<string> UserInfo = new List<string>();
        UserInfo = UserInfo_.GetUserInfo(AdminId);

        UserName.InnerText= UserInfo[0] + " " + UserInfo[1];
        if (UserInfo[5] == "")
        {
           UserImgimg.ImageUrl = "/Images/NoImg.png";
            UserImg.ImageUrl = "/Images/NoImg.png";
            UserImg1.ImageUrl = "/Images/NoImg.png";
        }
        else
        {
            UserImgimg.ImageUrl = UserInfo[5];
            UserImg.ImageUrl = UserInfo[5];
            UserImg1.ImageUrl = UserInfo[5];
        }
    }


    protected void UserTypeDLL_CheckedChanged(object sender, EventArgs e)
    {
        ClearAll();
        if (UserTypeDLL.SelectedValue == "4")
        {
            VisiblePupil(true);
            VisibleOtherUsers(false);
            VisibleTeacherUsers(false);
            HideChildTBID(false);
            FillClasses();
        }
        else if (UserTypeDLL.SelectedValue == "2")
        {
            VisibleTeacherUsers(true);
            VisiblePupil(false);
            VisibleOtherUsers(true);
            HideChildTBID(false);
            FillUsers();
            tempList = "2";
        }
        else
        {
            if (UserTypeDLL.SelectedValue == "3") { VisibleParent(true); }
            VisibleTeacherUsers(false);
            VisiblePupil(false);
            HideChildTBID(false);
            VisibleOtherUsers(true);
            FillUsers();
        }
        UpdateUserBTN.Visible = true;
    }

    protected void FillPupils(object sender, EventArgs e)
    {
        string ClassCode = "";
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        Classes = (Dictionary<string, string>)(Session["ClassesList"]);
        ClassCode = KeyByValue(Classes, ClassOt1DLL.SelectedValue);

        Users Pupil = new Users();
        Dictionary<string, string> pupils = new Dictionary<string, string>();

        pupils = Pupil.getPupils(ClassCode);
        PupilDLL.DataSource = pupils.Values;
        PupilDLL.DataBind();
        Session["PupilsList"] = pupils;
    }

    protected void FillClasses()
    {
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        Users ClassesU = new Users();
        Classes = ClassesU.FillClassOt();
        ClassOt1DLL.DataSource = Classes.Values;
        ClassOt1DLL.DataBind();
        Session["ClassesList"] = Classes;
    }

    protected void FillUsers()
    {
        Users Users = new Users();
        Dictionary<string, string> UsersList = new Dictionary<string, string>();
        UsersList = Users.FillUsers(UserTypeDLL.SelectedValue);
        OtherUsersDLL.DataSource = UsersList.Values;
        OtherUsersDLL.DataBind();
        Session["UsersList"] = UsersList;
    }

    protected void UserChosed(object sender, EventArgs e)
    {
        string UserID = "";
        if (UserTypeDLL.SelectedValue == "4")
        {
            UserID = PupilDLL.SelectedValue;
            Users PupilGroupID = new Users();
            Dictionary<string, string> pupils = new Dictionary<string, string>();
            pupils = (Dictionary<string, string>)(Session["PupilsList"]);
            UserID = KeyByValue(pupils, UserID);
            ClassOt2DLL.SelectedValue = PupilGroupID.GetPupilOtClass(UserID);
        }
        else
        {
            UserID = OtherUsersDLL.SelectedValue;
            Dictionary<string, string> Users = new Dictionary<string, string>();
            Users = (Dictionary<string, string>)(Session["UsersList"]);
            UserID = KeyByValue(Users, UserID);
            if (UserTypeDLL.SelectedValue == "2")
            {

                Users TeacherChecked = new Users();
                bool IsMain = TeacherChecked.GetTeacherMain(UserID);

                if (IsMain)
                {
                    MainTeacherCB.Checked = true;
                    Class2LBL.Visible = true;
                    ClassOt2DLL.Visible = true;
                    Users TeacherMainClass = new Users();
                    ClassOt2DLL.SelectedValue = TeacherMainClass.GetTeacherMainClass(UserID);
                }
            }
            else if (UserTypeDLL.SelectedValue == "3")
            {
                Users QuntityChiled = new Users();
              //  NumChildDDL.Visible = true;
                NumChildLBL.Visible = true;
               // NumChildDDL.SelectedValue = QuntityChiled.GetNumChild(UserID);
            }
        }

        Users UserInfo_ = new Users();
        ImgUser.Visible = true;

        List<string> UserInfo = new List<string>();
        UserInfo = UserInfo_.GetUserInfo(UserID);

        UserIDTB.Text = UserID;
        FNameTB.Text = UserInfo[0];
        LNameTB.Text = UserInfo[1];
        BDAYtb.Text = UserInfo[2];

        PasswordTB.Text = UserInfo[3];
        TelephoneNumberTB.Text = UserInfo[4];

        if (UserInfo[5] == "")
        {
            ImgUser.ImageUrl = "/Images/NoImg.png";
        }
        else
        {
            ImgUser.ImageUrl = UserInfo[5];
        }
    }

    public string KeyByValue(Dictionary<string, string> dict, string val)
    {
        string key = null;
        if (dict == null & val == "")
        {
            if (UserTypeDLL.SelectedValue == "2")
            {
                dict = (Dictionary<string, string>)(Session["UsersList"]);
                val = UserIDTB.Text;
            }
        }
        foreach (KeyValuePair<string, string> pair in dict)
        {
            if (pair.Value == val)
            {
                key = pair.Key;
                break;
            }
        }
        return key;
    }

    //protected void FillTBofBdate(object sender, EventArgs e)
    //{
    //    BirthDateTB.Text = Calendar1.SelectedDate.ToShortDateString();
    //}

    protected void VisiblePupil(bool ans)
    {
        ChoosePupilLBL.Visible = ans;
        PupilDLL.Visible = ans;
        ClassOt1DLL.Visible = ans;
        Class1LBL.Visible = ans;
        Class2LBL.Visible = ans;
        ClassOt2DLL.Visible = ans;
    }

    protected void VisibleOtherUsers(bool ans)
    {
        OtherUsersDLL.Visible = ans;
        ChooseOtherUsers.Visible = ans;
    }

    protected void VisibleParent(bool ans)
    {
        UpdateChild.Visible = ans;
        ChoosenNumChildDDL.Visible = false;
    }

    protected void VisibleTeacherUsers(bool ans)
    {
        MainTeacher.Visible = ans;
        MainTeacherCB.Visible = ans;
    }

    protected void ClearAll()
    {
        UserIDTB.Text = "";
        FNameTB.Text = "";
        LNameTB.Text = "";
        PasswordTB.Text = "";
        TelephoneNumberTB.Text = "";
        ImgUser.ImageUrl = "";
        ImgUser.Visible = false;
        ChildIDLBL.Visible = false;
        MainTeacher.Visible = false;
        MainTeacherCB.Visible = false;
        MainTeacherCB.Checked = false;
        ChildI1DTB.Text = "";
        ChildI2DTB.Text = "";
        ChildI3DTB.Text = "";
        ChildI4DTB.Text = "";
        ChildI5DTB.Text = "";
        ChildI6DTB.Text = "";
        ChildI1DTB.Visible = false;
        ChildI2DTB.Visible = false;
        ChildI3DTB.Visible = false;
        ChildI4DTB.Visible = false;
        ChildI5DTB.Visible = false;
        ChildI6DTB.Visible = false;
        UpdateChild.Visible = false;
        NumChildLBL.Visible = false;
     //   NumChildDDL.Visible = false;
        ChoosenNumChildLBL.Visible = false;
        ChoosenNumChildDDL.Visible = false;
      //  ChoosenNumChildDDL.SelectedIndex = 0;
        UpdateChild.Checked = false;
        ChildIDLBL.Visible = false;
    }

    protected void UpdateUserBTN_Click(object sender, EventArgs e) //******************* להתאים עד הסוף שינויים
    {
        string folderPath = Server.MapPath("~/Images/");
        int res1 = 0;
        Users NewUser = new Users();

       // string newBDATe = date1.Value;

        if (BDAYtb.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תאריך לא יכול להיות ריק');", true);
            return;
        }

      //  string Bday = newBDATe.Substring(8, 2) + "/" + newBDATe.Substring(5, 2) + "/" + newBDATe.Substring(0, 4);

        if (FileUpload1.FileName == "")
        {
            res1 = NewUser.UpdateUser(UserIDTB.Text, FNameTB.Text, LNameTB.Text, BDAYtb.Text, "", "", PasswordTB.Text, TelephoneNumberTB.Text);
        }
        else
        {
            FileUpload1.SaveAs(folderPath + FileUpload1.FileName);
            res1 = NewUser.UpdateUser(UserIDTB.Text, FNameTB.Text, LNameTB.Text, BDAYtb.Text, "Images/" + FileUpload1.FileName, "", PasswordTB.Text, TelephoneNumberTB.Text);
        }                                                                                                                       //Images // להוריד ירוק כשיהיה לא בשרת

        if (res1 == 1)
        {
            if (UserTypeDLL.SelectedValue == "4")
            {
                Users PupilUser = new Users();
                int num = PupilUser.UpdatePupil(UserIDTB.Text, ClassOt2DLL.SelectedValue);
            }
            else if (UserTypeDLL.SelectedValue == "2")
            {
                Users TeacherUser = new Users();
                string IsMain = "0";
                if (MainTeacherCB.Checked)
                {
                    IsMain = "1";
                    List<string> Classes = TeacherUser.IsAlreadyMainTeacher(UserIDTB.Text);
                    if (Classes.Count > 0)
                    {
                        for (int i = 0; i < Classes.Count; i++)
                        {
                            Users TeacherDeleteClass = new Users();
                            TeacherDeleteClass.DeleteMainTeacherToClass(Classes[i]);
                        }
                    }
                    Users MainTeacherUpdateClass = new Users();
                    int res13 = MainTeacherUpdateClass.AddMainTeacherToClass(UserIDTB.Text, ClassOt2DLL.SelectedItem.ToString());
                }

                Users MainTeacherUserCheck = new Users();
                int res = MainTeacherUserCheck.UpdateTeacher(UserIDTB.Text, IsMain);
            }
            else if (UserTypeDLL.SelectedValue == "3")
            {
                if (UpdateChild.Checked)
                {
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
                            Users AddMoreThanOneChild = new Users();
                            AddMoreThanOneChild.UpdateParent(UserIDTB.Text, ChildID[i], ChildCodeClass);
                        }
                    }
                }
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('משתמש עודכן בהצלחה'); location.href='AUpdateUser.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הייתה בעיה בעדכון המשתמש, בדוק נתונים');", true);
        }
    }

    protected void MainTeacherCB_CheckedChanged(object sender, EventArgs e)
    {
        if (MainTeacherCB.Checked)
        {
            ClassOt2DLL.Visible = true;
        }
        else
        {
            ClassOt2DLL.Visible = false;
        }
    }

    protected void UpdateChild_CheckedChanged(object sender, EventArgs e)
    {
        if (UpdateChild.Checked)
        {
          //  NumChildDDL.Visible = true;
            ChoosenNumChildDDL.Visible = true;
            ChoosenNumChildLBL.Visible = true;
        }
        else
        {
            //NumChildDDL.Visible = false;
            ChoosenNumChildDDL.Visible = false;
            ChoosenNumChildLBL.Visible = false;
        }
    }

    protected void NumChildDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChildIDLBL.Visible = true;
        switch (ChoosenNumChildDDL.SelectedValue)
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

    //protected void FillDays()
    //{
    //    List<string> days = new List<string>();

    //    for (int i = 1; i <= 31; i++)
    //    {
    //        if (i < 10)
    //        {
    //            days.Add("0" + i.ToString());
    //        }
    //        else
    //        {
    //            days.Add(i.ToString());
    //        }
    //    }

    //    DDLday.DataSource = days;
    //    DDLday.DataBind();
    //    DDLday.Items.Insert(0, new ListItem("יום"));
    //}

    //protected void FillMonth()
    //{
    //    List<string> months = new List<string>();

    //    for (int i = 1; i <= 12; i++)
    //    {
    //        if (i < 10)
    //        {
    //            months.Add("0" + i.ToString());
    //        }
    //        else
    //        {
    //            months.Add(i.ToString());
    //        }
    //    }

    //    DDLmonth.DataSource = months;
    //    DDLmonth.DataBind();
    //    DDLmonth.Items.Insert(0, new ListItem("חודש"));
    //}

    //protected void FillYear()
    //{
    //    int year = 1930;
    //    List<string> years = new List<string>();

    //    for (int i = 0; year < 2011; i++, year++)
    //    {
    //        years.Add(year.ToString());
    //    }

    //    DDLyear.DataSource = years;
    //    DDLyear.DataBind();
    //    DDLyear.Items.Insert(0, new ListItem("שנה"));
    //}
}