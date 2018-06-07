using System;
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
            ChildDDL.Visible = false;
            //  NumChildDDL.Visible = false;
            VisibleParent(false);
            //ChoosenNumChildLBL.Visible = false;
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

    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));
    }

    protected void FillFirstItemChildrenList(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("תלמידים", "0"));
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
            //UserImg.ImageUrl = "/Images/NoImg.png";
            UserImg1.ImageUrl = "/Images/NoImg.png";
        }
        else
        {
            UserImgimg.ImageUrl = UserInfo[6];
            //UserImg.ImageUrl = UserInfo[6];
            UserImg1.ImageUrl = UserInfo[6];
        }
    }

    protected void FillChildren(object sender, EventArgs e)
    {
        Dictionary<string, string> Children = new Dictionary<string, string>();
        Dictionary<string, string> Children2 = new Dictionary<string, string>();
        Users c = new Users();
        Parent p = new Parent(UserIDTB.Text);

        Children = p.ChildrenToDictionary();

        ChildDDL.DataSource = Children;
        ChildDDL.DataValueField = "key";
        ChildDDL.DataTextField = "value";
        ChildDDL.DataBind();
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
                //NumChildLBL.Visible = true;
                // NumChildDDL.SelectedValue = QuntityChiled.GetNumChild(UserID);
                //FillChildren();
            }
        }

        Users UserInfo_ = new Users();
        ImgUser.Visible = true;

        List<string> UserInfo = new List<string>();
        UserInfo = UserInfo_.GetUserInfo(UserID);

        UserIDTB.Text = UserID;
        FNameTB.Text = UserInfo[1];
        LNameTB.Text = UserInfo[2];
        BDAYtb.Text = UserInfo[3];

        PasswordTB.Text = UserInfo[4];
        TelephoneNumberTB.Text = UserInfo[5];

        if (UserInfo[5] == "")
        {
            ImgUser.ImageUrl = "/Images/NoImg.png";
        }
        else
        {
            ImgUser.ImageUrl = UserInfo[6];
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
        ChildDDL.Visible = ans;
        //UpdateChild.Visible = ans;
        //ChoosenNumChildDDL.Visible = false;
        DeleteChild.Visible = ans;
        AddChild.Visible = ans;
        SaveChild.Visible = false;
    }

    protected void VisibleTeacherUsers(bool ans)
    {
        MainTeacher.Visible = ans;
        MainTeacherCB.Visible = ans;
    }

    protected void ClearAll()
    {
        BDAYtb.Text = "";
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
        //UpdateChild.Visible = false;
        //NumChildLBL.Visible = false;
     //   NumChildDDL.Visible = false;
        //ChoosenNumChildLBL.Visible = false;
        //ChoosenNumChildDDL.Visible = false;
      //  ChoosenNumChildDDL.SelectedIndex = 0;
        //UpdateChild.Checked = false;
        ChildIDLBL.Visible = false;
    }

    protected void UpdateUserBTN_Click(object sender, EventArgs e) //******************* להתאים עד הסוף שינויים
    {
        string folderPath = Server.MapPath("~/Images/");
        int res1 = 0;
        Administrator NewUser = new Administrator();


        // string newBDATe = date1.Value;

        if (BDAYtb.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תאריך לא יכול להיות ריק');", true);
            return;
        }

        //  string Bday = newBDATe.Substring(8, 2) + "/" + newBDATe.Substring(5, 2) + "/" + newBDATe.Substring(0, 4);

        //string day = DDLday.SelectedValue, month = DDLmonth.SelectedValue, year = DDLyear.SelectedValue;
        //string Bday = day + "/" + month + "/" + year;
        //if (day == "יום" || month == "חודש" || year == "שנה")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תאריך הלידה לא יכול להיות ריק');", true);
        //    return;
        //}

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
                Administrator PupilUser = new Administrator();
                int num = PupilUser.UpdatePupil(UserIDTB.Text, ClassOt2DLL.SelectedValue);
            }
            else if (UserTypeDLL.SelectedValue == "2")
            {
                Administrator TeacherUser = new Administrator();
                string IsMain = "0";
                if (MainTeacherCB.Checked)
                {
                    IsMain = "1";
                    List<string> Classes = TeacherUser.IsAlreadyMainTeacher(UserIDTB.Text);
                    if (Classes.Count > 0)
                    {
                        for (int i = 0; i < Classes.Count; i++)
                        {
                            Administrator TeacherDeleteClass = new Administrator();
                            TeacherDeleteClass.DeleteMainTeacherToClass(Classes[i]);
                        }
                    }
                    Administrator MainTeacherUpdateClass = new Administrator();
                    int res13 = MainTeacherUpdateClass.AddMainTeacherToClass(UserIDTB.Text, ClassOt2DLL.SelectedItem.ToString());
                }

                Administrator MainTeacherUserCheck = new Administrator();
                int res = MainTeacherUserCheck.UpdateTeacher(UserIDTB.Text, IsMain);
            }
            else if (UserTypeDLL.SelectedValue == "3")
            {
                //if (UpdateChild.Checked)
                //{
                //    string[] ChildID = new string[6];

                //    ChildID[0] = ChildI1DTB.Text;
                //    ChildID[1] = ChildI2DTB.Text;
                //    ChildID[2] = ChildI3DTB.Text;
                //    ChildID[3] = ChildI4DTB.Text;
                //    ChildID[4] = ChildI5DTB.Text;
                //    ChildID[5] = ChildI6DTB.Text;

                //    for (int i = 0; i < ChildID.Length; i++)
                //    {
                //        if (ChildID[i] != "")
                //        {
                //            Users GetPupilClass = new Users();
                //            string ChildCodeClass = GetPupilClass.GetPupilOtClass(ChildID[i]);
                //            Administrator AddMoreThanOneChild = new Administrator();
                //            AddMoreThanOneChild.UpdateParent(UserIDTB.Text, ChildID[i], ChildCodeClass);
                //        }
                //    }
                //}
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('משתמש עודכן בהצלחה'); location.href='Admin_Update_User.aspx';", true);
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
            Class2LBL.Visible = true;
        }
        else
        {
            ClassOt2DLL.Visible = false;
            Class2LBL.Visible = false;
        }
    }

    protected void AddNewChild(object sender, EventArgs e)
    {
        TBaddNewChild.Visible = true;
    }

    protected void DeleteChildFunction(object sender, EventArgs e)
    {
        string childID = ChildDDL.SelectedValue;
        if (childID == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('לא נבחר ילד למחיקה');", true);
            return;
        }
        else
        {
            Parent p = new Parent();

            int answer = p.DeleteChild(UserIDTB.Text, childID);
            if (answer > 0)
            {
                ChildDDL.DataBind();
            }
        }
    }



    protected void UpdateChild_CheckedChanged(object sender, EventArgs e)
    {
        //if (UpdateChild.Checked)
        //{
        //  //  NumChildDDL.Visible = true;
        //    //ChoosenNumChildDDL.Visible = true;
        //    //ChoosenNumChildLBL.Visible = true;
        //}
        //else
        {
            //NumChildDDL.Visible = false;
            //ChoosenNumChildDDL.Visible = false;
            //ChoosenNumChildLBL.Visible = false;
        }
    }

    //protected void NumChildDDL_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ChildIDLBL.Visible = true;
    //    switch (ChoosenNumChildDDL.SelectedValue)
    //    {
    //        case "1":
    //            ChildI1DTB.Visible = true;
    //            ChildI2DTB.Visible = false;
    //            ChildI3DTB.Visible = false;
    //            ChildI4DTB.Visible = false;
    //            ChildI5DTB.Visible = false;
    //            ChildI6DTB.Visible = false;
    //            break;
    //        case "2":
    //            ChildI1DTB.Visible = true;
    //            ChildI2DTB.Visible = true;
    //            ChildI3DTB.Visible = false;
    //            ChildI4DTB.Visible = false;
    //            ChildI5DTB.Visible = false;
    //            ChildI6DTB.Visible = false;
    //            break;
    //        case "3":
    //            ChildI1DTB.Visible = true;
    //            ChildI2DTB.Visible = true;
    //            ChildI3DTB.Visible = true;
    //            ChildI4DTB.Visible = false;
    //            ChildI5DTB.Visible = false;
    //            ChildI6DTB.Visible = false;
    //            break;
    //        case "4":
    //            ChildI1DTB.Visible = true;
    //            ChildI2DTB.Visible = true;
    //            ChildI3DTB.Visible = true;
    //            ChildI4DTB.Visible = true;
    //            ChildI5DTB.Visible = false;
    //            ChildI6DTB.Visible = false;
    //            break;
    //        case "5":
    //            ChildI1DTB.Visible = true;
    //            ChildI2DTB.Visible = true;
    //            ChildI3DTB.Visible = true;
    //            ChildI4DTB.Visible = true;
    //            ChildI5DTB.Visible = true;
    //            ChildI6DTB.Visible = false;
    //            break;
    //        case "6":
    //            ChildI1DTB.Visible = true;
    //            ChildI2DTB.Visible = true;
    //            ChildI3DTB.Visible = true;
    //            ChildI4DTB.Visible = true;
    //            ChildI5DTB.Visible = true;
    //            ChildI6DTB.Visible = true;
    //            break;
    //    }
    //}

    protected void SaveNewChildToParent(object sender, EventArgs e)
    {
        string childID = TBaddNewChild.Text,
            parentID = UserIDTB.Text;

        Users child = new Users();
        Parent p = new Parent();

        string answer = child.IsStudentUserNotThisParentYet(childID, parentID);
        switch (answer)
        {
            case "userTypeNotStudent":
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תלמיד לא קיים במערכת');", true);
                return;
            case "everythingGood":
                int num = p.SaveChildAndParent(parentID, childID);
                if (num > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תלמיד נוסף בהצלחה');", true);
                }
                else ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('עקב תקלה לא ניתן להוסיף תלמיד להורה');", true);
                ChildDDL.DataBind();
                TBaddNewChild.Text = "";
                TBaddNewChild.Visible = false;
                break;
            case "connectionExists":
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תלמיד כבר משוייך להורה');", true);
                return;
        }
    }
}