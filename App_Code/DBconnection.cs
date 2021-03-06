﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DBconnection
/// </summary>
public class DBconnection
{
    public SqlDataAdapter da;
    public DataTable dt;

    SqlConnection con = new SqlConnection();

    public DBconnection()
    {

    }

    public SqlConnection connect(String conString)
    {
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = CommandSTR;
        cmd.CommandTimeout = 10;
        cmd.CommandType = System.Data.CommandType.Text;
        return cmd;
    }

    public int DeleteChild(string parentID, string childID)
    {
        String selectSTR = "DELETE FROM dbo.PupilsParent where [ParentID] = '" + parentID + "' and [PupilID] = '" + childID + "'";
        return ExecuteNonQuery(selectSTR);

    }

    public string GetClassCodeByUserID(string UserID) 
    {
        String selectSTR = "select CodeClass from Pupil where UserID='"+ UserID + "'";
        string CodeClass = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                CodeClass = dr["CodeClass"].ToString();
            }
            return CodeClass;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public Dictionary<string, string> GetClassCodeAndParentIDByPupilID(string UserID) 
    {
        String selectSTR = "select ParentID,codeClass from PupilsParent where PupilID='"+ UserID + "'";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            Dictionary<string, string> ClassAndParent = new Dictionary<string, string>(); // keep the ids of the senders

            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                ClassAndParent.Add("ParentID", dr["ParentID"].ToString());
                ClassAndParent.Add("codeClass", dr["codeClass"].ToString());
            }
            return ClassAndParent;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    public string GetClassCodeAccordingToClassFullName(string classTotalName)
    {
        String selectSTR = "SELECT ClassCode FROM Class where TotalName  = '" + classTotalName + "'";
        string codeClass = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                codeClass = dr["ClassCode"].ToString();
            }
            return codeClass;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Dictionary<string, string>> GetMessagesByUserId(string userId)
    {
        string type = GetUserTypeById(userId), selectSTR = "SELECT MessageCode, MessageDate, SenderID, " +
            " TheMessage, SubjectMessage FROM Messages where recipientID  = '" + userId +
            "' order by MessageCode desc";
        if (type == "3")
        {

        }

        List<Dictionary<string, string>> messages = new List<Dictionary<string, string>>();

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            Dictionary<string, string> messagesSenders = new Dictionary<string, string>(); // keep the ids of the senders

            while (dr.Read())
            {
                string value = "";
                messagesSenders.TryGetValue(dr["SenderID"].ToString(), out value);
                if (value != "exists") // the sender not exists yet
                {
                    messagesSenders.Add(dr["SenderID"].ToString(), "exists");

                    Dictionary<string, string> d = new Dictionary<string, string>();

                    d.Add("MessageCode", dr["MessageCode"].ToString());
                    d.Add("MessageDate", dr["MessageDate"].ToString());
                    d.Add("SenderID", dr["SenderID"].ToString());
                    d.Add("SubjectMessage", dr["SubjectMessage"].ToString());
                    d.Add("TheMessage", dr["TheMessage"].ToString());

                    messages.Add(d);
                }

            }
            string SenderName;

            for (int i = 0; i < messages.Count; i++)
            {
                SenderName = GetSenderNameBySenderID(messages[i]["SenderID"]);
                messages[i].Add("SenderName", SenderName);
            }

            return messages;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Dictionary<string, string>> GetMessagesByUserIdUnread(string userId)
    {
        string type = GetUserTypeById(userId), selectSTR = "SELECT MessageCode, MessageDate, SenderID, " +
            " TheMessage, SubjectMessage FROM Messages where recipientID  = '" + userId +
            "' and IsReadByRecipient is null order by MessageCode desc";
        if (type == "3")
        {

        }

        List<Dictionary<string, string>> messages = new List<Dictionary<string, string>>();

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            Dictionary<string, string> messagesSenders = new Dictionary<string, string>(); // keep the ids of the senders

            while (dr.Read())
            {
                string value = "";
                messagesSenders.TryGetValue(dr["SenderID"].ToString(), out value);
                if (value != "exists") // the sender not exists yet
                {
                    messagesSenders.Add(dr["SenderID"].ToString(), "exists");

                    Dictionary<string, string> d = new Dictionary<string, string>();

                    d.Add("MessageCode", dr["MessageCode"].ToString());
                    d.Add("MessageDate", dr["MessageDate"].ToString());
                    d.Add("SenderID", dr["SenderID"].ToString());
                    d.Add("SubjectMessage", dr["SubjectMessage"].ToString());
                    d.Add("TheMessage", dr["TheMessage"].ToString());

                    messages.Add(d);
                }

            }
            string SenderName;

            for (int i = 0; i < messages.Count; i++)
            {
                SenderName = GetSenderNameBySenderID(messages[i]["SenderID"]);
                messages[i].Add("SenderName", SenderName);
            }

            return messages;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetUserFullName(string Id)
    {
        string selectSTR = "SELECT UserFName + ' ' + UserLName as UserName " +
            " FROM Users where UserID  = '" + Id + "'",
            UserName = "";

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                UserName = dr["UserName"].ToString();
            }

            return UserName;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetSenderNameBySenderID(string SenderID)
    {
        string selectSTR = "select UserFName + ' ' + UserLName as SenderName from Users where UserID = '" + SenderID + "'";

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string SenderName = "";
            while (dr.Read())
            {
                SenderName = dr["SenderName"].ToString();
            }
            return SenderName;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetSenderImgBySenderID(string SenderID)
    {
        string selectSTR = "select UserImg from Users where UserID = '" + SenderID + "'";

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string SenderIMG = "";
            while (dr.Read())
            {
                SenderIMG = dr["UserImg"].ToString();
            }
            return SenderIMG;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Messages> GetAllConversation(string SenderID, string RecipientID)
    {
        string selectSTR = "SELECT MessageCode, MessageDate, SenderID, " +
         " recipientID, (select UserFName + ' ' + UserLName from Users where UserID = '" + RecipientID + "') as RecipientName, " +
         " TheMessage, SubjectMessage FROM Messages where SenderID  = '" + SenderID + "' and recipientID = '" + RecipientID +
         "' or SenderID  = '" + RecipientID + "' and recipientID = '" + SenderID + "' order by MessageCode"; ;

        List<Messages> messages = new List<Messages>();

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Messages m = new Messages();

                m.MessageDate = dr["MessageDate"].ToString();
                m.SenderID = dr["SenderID"].ToString();
                m.RecipientID = dr["recipientID"].ToString();
                //m.SenderName = dr["SenderName"].ToString();
                m.RecipientName = dr["RecipientName"].ToString();
                m.Subject = dr["SubjectMessage"].ToString();
                m.Content = dr["TheMessage"].ToString();

                messages.Add(m);
            }

            string SenderName, SenderIMG;

            for (int i = 0; i < messages.Count; i++)
            {
                SenderName = GetSenderNameBySenderID(messages[i].SenderID);
                SenderIMG = GetSenderImgBySenderID(messages[i].SenderID);

                messages[i].SenderName = SenderName;
                messages[i].SenderIMG = SenderIMG;

            }
            return messages;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> GetUserType(string UserID, string password)
    {
        String selectSTR = "SELECT CodeUserType,PushRegID  FROM Users where UserID  = '" + UserID + "' and LoginPassword  = '" + password + "'";
        List<string> UserInfo = new List<string>();
        string type, RegID;
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                type = dr["CodeUserType"].ToString();
                UserInfo.Add(type);
                RegID = dr["PushRegID"].ToString();
                UserInfo.Add(RegID);

            }
            return UserInfo;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetUserTypeById(string UserID)
    {
        String selectSTR = "SELECT CodeUserType  FROM Users where UserID  = '" + UserID + "'";
        string type = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                type = dr["CodeUserType"].ToString();
            }
            return type;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public bool IsExists(string newSubject)
    {
        String selectSTR = "SELECT count(LessonName) FROM Lessons where LessonName  = '" + newSubject + "'";
        int countRow = 0;
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                countRow = int.Parse(dr[0].ToString());
            }

            if (countRow > 0)
            {
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public int AddNewSubject(string newSubject)
    {
        String cStr = "INSERT INTO [dbo].[Lessons]  (LessonName) VALUES ('" + newSubject + "')";
        return ExecuteNonQuery(cStr);
    }

    public string GetPupilGroup(string UserID)
    {
        String selectSTR = "SELECT CodePgroup  FROM Pupil where UserID  = '" + UserID + "'";
        string CodePgroup = "";

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                CodePgroup = dr["CodePgroup"].ToString();
            }
            return CodePgroup;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetPupilOtClass(string UserID)
    {
        String selectSTR = "SELECT  dbo.Class.ClassCode FROM dbo.Class INNER JOIN  dbo.Pupil ON dbo.Class.ClassCode = dbo.Pupil.CodeClass where  dbo.Pupil.UserID='" + UserID + "'";
        string ClassCode = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                ClassCode = dr["ClassCode"].ToString();
            }
            return ClassCode;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public bool GetTeacherMain(string UserID)
    {
        String selectSTR = "SELECT IsMainTeacher  FROM Teachers where TeacherID  = '" + UserID + "'";
        bool Checked = false;
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Checked = bool.Parse(dr["IsMainTeacher"].ToString());
            }
            return Checked;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetTeacherMainClass(string UserID)
    {
        String selectSTR = "SELECT ClassCode  FROM Class where MainTeacherID  = '" + UserID + "'";
        string ClassCode = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                ClassCode = dr["ClassCode"].ToString();
            }
            return ClassCode;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> GetUserInfo(string UserID)
    {
        string ID, UserFName, UserLName, BirthDate, UserImg, UserPassword, PhoneNumber;
        String selectSTR = "select * from [dbo].[Users] where UserID  = '" + UserID + "'";
        List<string> UserInfo = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                ID = dr["UserID"].ToString();
                UserInfo.Add(ID);
                UserFName = dr["UserFName"].ToString();
                UserInfo.Add(UserFName);
                UserLName = dr["UserLName"].ToString();
                UserInfo.Add(UserLName);
                BirthDate = dr["BirthDate"].ToString();
                UserInfo.Add(BirthDate);
                UserPassword = dr["LoginPassword"].ToString();
                UserInfo.Add(UserPassword);
                PhoneNumber = dr["PhoneNumber"].ToString();
                UserInfo.Add(PhoneNumber);
                UserImg = dr["UserImg"].ToString();
                UserInfo.Add(UserImg);
            }
            return UserInfo;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> GetUserSecurityDetailsByuserIDandBday(string userID, string Bday)
    {
        List<string> l = new List<string>();
        l = GetSecurityInfo(1, userID, Bday).Concat(GetSecurityInfo(2, userID, Bday)).ToList();
        return l;
    }

    public List<string> GetSecurityInfo(int numQ, string id, string bDay)
    {
        string str = "";
        SqlCommand cmd;
        List<string> l = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            switch (numQ)
            {
                case 1:
                    str = "SELECT dbo.SecurityQ.SecurityQInfo, dbo.Users.SecurityQ1Answer FROM dbo.SecurityQ " +
                "INNER JOIN dbo.Users ON dbo.SecurityQ.CodeSecurityQ = dbo.Users.SecurityQ1Code " +
                "where dbo.Users.UserID = '" + id + "' and dbo.Users.BirthDate ='" + bDay + "'";

                    cmd = new SqlCommand(str, con);
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (dr.Read())
                    {
                        string Q1 = dr["SecurityQInfo"].ToString();
                        l.Add(Q1);
                        string answer1 = dr["SecurityQ1Answer"].ToString();
                        l.Add(answer1);
                    }
                    break;
                case 2:
                    str = "SELECT dbo.SecurityQ.SecurityQInfo, dbo.Users.SecurityQ2Answer FROM dbo.SecurityQ " +
                "INNER JOIN dbo.Users ON dbo.SecurityQ.CodeSecurityQ = dbo.Users.SecurityQ2Code " +
                "where dbo.Users.UserID = '" + id + "' and dbo.Users.BirthDate ='" + bDay + "'";

                    cmd = new SqlCommand(str, con);
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (dr.Read())
                    {
                        string Q2 = dr["SecurityQInfo"].ToString();
                        l.Add(Q2);
                        string answer2 = dr["SecurityQ2Answer"].ToString();
                        l.Add(answer2);
                    }
                    break;
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }// 
    }

    public int ChangePassword(string userID, string Password)
    {
        string cStr = "update[dbo].[Users] set[LoginPassword] = ('" + Password + "') WHERE UserID = '" + userID + "'";
        return ExecuteNonQuery(cStr);
    }

    public int PushUpdateRegId(string userID, string RegID)
    {
        string cStr = "update[dbo].[Users] set[PushRegID] = ('" + RegID + "') WHERE UserID = '" + userID + "'";
        return ExecuteNonQuery(cStr);
    }

    public List<string> GetClassesOt()
    {
        String selectSTR = "select distinct [OtClass] from [dbo].[Class]";
        string Ot;
        List<string> l = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Ot = dr["OtClass"].ToString();
                l.Add(Ot);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> ClassesExites(string ClassOt, string ClassNum)
    {
        String selectSTR = "select [TotalName] from [dbo].[Class] where [TotalName] = '" + ClassOt + ClassNum + "'";
        string Ot;
        List<string> l = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Ot = dr["TotalName"].ToString();
                l.Add(Ot);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetClassNameByCodeClass(int codeClass)
    {
        String selectSTR = "select [TotalName] from [dbo].[Class] where [ClassCode] = " + codeClass;
        string className = "";
        SqlConnection conNameClass = new SqlConnection();
        try
        {
            conNameClass = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, conNameClass);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                className = dr[0].ToString();
            }
            return className;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (conNameClass != null)
            {
                conNameClass.Close();
            }
        }
    }

    public List<string> GetClassesFullName()
    {
        String selectSTR = "select distinct [TotalName], [OtClass], [NumClass] from [dbo].[Class] order by OtClass, NumClass";
        string Ot;
        List<string> l = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Ot = dr["TotalName"].ToString();
                l.Add(Ot);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public int InsertClass(string ClassOt, string ClassNum)
    {
        string cStr = "INSERT INTO [dbo].[Class]  ([OtClass], [NumClass], [MainTeacherID], [TotalName]) VALUES ('" + ClassOt + "', '" + ClassNum + "',null,'" + ClassOt + ClassNum + "')";
        return ExecuteNonQuery(cStr);
    }

    public string IsAlreadyLogin(string UserID, string password)
    {
        String selectSTR = "select alreadyLogin from Users where UserID = '" + UserID + "' and LoginPassword = '" + password + "'";
        string isAlreadyLogin = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                isAlreadyLogin = dr["alreadyLogin"].ToString();
            }
            return isAlreadyLogin;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Questions> GetQuestions()
    {
        List<Questions> questions = new List<Questions>();

        String selectSTR = "select * from SecurityQ";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Questions q = new Questions();
                q.SecurityCode = int.Parse(dr["CodeSecurityQ"].ToString());
                q.SecurityInfo = dr["SecurityQInfo"].ToString();
                questions.Add(q);
            }
            return questions;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public int SaveQuestion(string id, int q1, string a1, int q2, string a2)
    {
        String cStr = "update Users set SecurityQ1Code = " + q1 + ", SecurityQ1Answer = '" + a1 + "', SecurityQ2Code=" + q2 + ",SecurityQ2Answer='" + a2 + "'  where UserID = '" + id + "'";
        return ExecuteNonQuery(cStr); // execute the command   
    }

    public int UpdateStatusTT(string classCode, bool publish)
    {
        String cStr = "UPDATE [dbo].[Timetable]  SET [IsPublish] ='" + publish + "'WHERE [ClassCode]=" + classCode;
        return ExecuteNonQuery(cStr); // execute the command   
    }

    public int AddUser(Users NewUser)
    {
        string cStr = "INSERT INTO [dbo].[Users] ([UserID],[UserFName],[UserLName],[BirthDate],[UserImg],[LoginPassword],[PhoneNumber],[CodeUserType],[SecurityQ1Code],[SecurityQ1Answer],[alreadyLogin],[SecurityQ2Code],[SecurityQ2Answer])" +
                     " VALUES('" + NewUser.UserID1 + "','" + NewUser.UserFName1 + "','" + NewUser.UserLName1 + "','" + NewUser.BirthDate1 + "','" + NewUser.UserImg1 + "','" + NewUser.UserPassword1 + "','" + NewUser.PhoneNumber1 + "','" + NewUser.CodeUserType1 + "' , null, null, 0, null, null)";
        return ExecuteNonQuery(cStr);
    }

    public int InsertTimeTable(string date, int classCode, bool publish)
    {
        int num = 0;
        try
        {
            using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Betsefer"].ConnectionString))
            {
                using (var cmd = new SqlCommand("UpdateTimeTable", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@classCode", classCode);
                    cmd.Parameters.AddWithValue("@publish", publish);
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                        }
                        num = 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return num;
    }

    public int InsertTempTimeTable(string date, int CodeWeekDay, int ClassTimeCode, int CodeLesson, string TeacherId, int ClassNum)
    {
        string cStr;
        int num = 0;

        cStr = "INSERT INTO [dbo].[TempTimetableLesson] ([dateString],[CodeWeekDay],[ClassTimeCode],[CodeLesson],[TeacherId],[CodeChoosenClass]) values ('" + date + "'," + CodeWeekDay + "," + ClassTimeCode + "," + CodeLesson + ",'" + TeacherId + "'," + ClassNum + ")";

        num = ExecuteNonQuery(cStr);

        return num;
    }

    public int InsertUpdateTimeTable(string TimeTableCode, int CodeWeekDay, int ClassTimeCode, int CodeLesson, string TeacherId)
    {
        string cStr;
        int num = 0;

        cStr = "INSERT INTO [dbo].[TimetableLesson] ([TimeTableCode],[CodeWeekDay],[ClassTimeCode],[CodeLesson],[TeacherId]) values ('" + TimeTableCode + "'," + CodeWeekDay + "," + ClassTimeCode + "," + CodeLesson + ",'" + TeacherId + "')";

        num = ExecuteNonQuery(cStr);

        return num;
    }

    public int GetLastTimeTableCode()
    {
        int TTC = 0;
        String cStr = "select max(TimeTableCode) from dbo.TimeTable";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                TTC = int.Parse(dr[0].ToString());
            }
            return TTC;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public int UpdateUser(string userID, string userFName, string userLName, string birthDate, string userImg, string userName, string userPassword, string phoneNumber)
    {
        string cStr;
        if (userImg == "")
        {
            cStr = "Update Users set [UserID]='" + userID + "',[UserFName]='" + userFName + "',[UserLName]='" + userLName + "',[BirthDate]='" + birthDate + "',[LoginPassword]='" + userPassword + "',[PhoneNumber]='" + phoneNumber + "' where [UserID]='" + userID + "'";
        }
        else
        {
            cStr = "Update Users set [UserID]='" + userID + "',[UserFName]='" + userFName + "',[UserLName]='" + userLName + "',[BirthDate]='" + birthDate + "',[UserImg]='" + userImg + "',[LoginPassword]='" + userPassword + "',[PhoneNumber]='" + phoneNumber + "' where [UserID]='" + userID + "'";
        }
        return ExecuteNonQuery(cStr); // execute the command   
    }

    public int AddPupil(string UserID, int classNumber)
    {
        String cStr = "INSERT INTO [dbo].[Pupil]([UserID],[CodeClass])  VALUES ('" + UserID + "'," + classNumber + ")";
        return ExecuteNonQuery(cStr);
    }

    public string GetNumChild(string UserID)
    {
        String cStr = "select count([ParentID]) as num from [dbo].[PupilsParent] where [ParentID]='" + UserID + "'";
        string NumChilds = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                NumChilds = dr["num"].ToString();
            }
            return NumChilds;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> GetCellInfoUPDATE(string TableCode, int WeekDay, int LessonNum)
    {
        String cStr = "select ([UserFName]+' '+[UserLName]) as FullName from [dbo].[Users] where [UserID]=(select  [TeacherId] from [dbo].[TimetableLesson] where [TimeTableCode] ='" + TableCode + "' and [CodeWeekDay]=" + WeekDay + " and [ClassTimeCode]=" + LessonNum + ") union " +
                        "select [LessonName] from [dbo].[Lessons] where [CodeLesson]=(select CodeLesson from [dbo].[TimetableLesson] where [TimeTableCode] ='" + TableCode + "' and [CodeWeekDay]=" + WeekDay + " and [ClassTimeCode]=" + LessonNum + ") ";
        List<string> listInfo = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                string info = dr["FullName"].ToString();
                listInfo.Add(info);
            }
            return listInfo;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> GetCellInfo(string date, int WeekDay, int LessonNum, string ClassNum)
    {
        String cStr = "select ([UserFName]+' '+[UserLName]) as FullName from [dbo].[Users] where [UserID]=(select  [TeacherId] from [dbo].[TempTimetableLesson] where [dateString] ='" + date + "' and [CodeWeekDay]=" + WeekDay + " and [ClassTimeCode]=" + LessonNum + "and CodeChoosenClass='" + ClassNum + "') union " +
                        "select [LessonName] from [dbo].[Lessons] where [CodeLesson]=(select CodeLesson from [dbo].[TempTimetableLesson] where [dateString] ='" + date + "' and [CodeWeekDay]=" + WeekDay + " and [ClassTimeCode]=" + LessonNum + " and CodeChoosenClass='" + ClassNum + "')";
        List<string> listInfo = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                string info = dr["FullName"].ToString();
                listInfo.Add(info);
            }
            return listInfo;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public int UpdatePupil(string userID, string ClassOt)
    {
        string cStr = "UPDATE[dbo].[Pupil] set [CodeClass]='" + ClassOt + "' where [UserID]='" + userID + "'";
        return ExecuteNonQuery(cStr);
    }

    public int AddTeacher(string UserID, string IsMain)
    {
        string cStr = "INSERT INTO [dbo].[Teachers] ([TeacherID] ,[IsMainTeacher]) VALUES ('" + UserID + "' ,'" + IsMain + "')";
        return ExecuteNonQuery(cStr);
    }

    public int UpdateTeacher(string UserID, string IsMain)
    {
        string cStr = "UPDATE [dbo].[Teachers]  SET [IsMainTeacher] = '" + IsMain + "' where [TeacherID]='" + UserID + "'";
        return ExecuteNonQuery(cStr);
    }

    public int UpdateClassTeacher(string UserID, string ClassOt)
    {
        string cStr = "UPDATE [dbo].[Class] SET [MainTeacherID] = '" + UserID + "' where [TotalName]='" + ClassOt + "'";
        return ExecuteNonQuery(cStr);
    }

    public int AddParent(string ParentID, string PupilID, string ChildCodeClass)
    {
        string cStr = "INSERT INTO [dbo].[PupilsParent] ([ParentID] ,[PupilID],[codeClass]) VALUES ('" + ParentID + "' ,'" + PupilID + "'," + ChildCodeClass + ")";
        return ExecuteNonQuery(cStr);
    }

    public int UpdateParent(string ParentID, string PupilID, string ChildCodeClass)
    {
        string cStr = "INSERT INTO [dbo].[PupilsParent] ([ParentID] ,[PupilID],[codeClass]) VALUES ('" + ParentID + "' ,'" + PupilID + "'," + ChildCodeClass + ")";
        return ExecuteNonQuery(cStr);
    }

    public int ChangeFirstLogin(string id)
    {
        string cStr = "update Users set alreadyLogin = 1  where UserID = '" + id + "'";
        return ExecuteNonQuery(cStr);
    }

    public int AddMainTeacherToClass(string id, string OtClass)
    {
        string cStr = "update Class set MainTeacherID = '" + id + "'  where TotalName = '" + OtClass + "'";
        return ExecuteNonQuery(cStr);
    }

    public int DeleteMainTeacherToClass(string TotalClassName)
    {
        string DeletePrevieusClassTeacher = "update Class set MainTeacherID = null where TotalName = '" + TotalClassName + "'";
        return ExecuteNonQuery(DeletePrevieusClassTeacher);
    }

    public List<string> IsAlreadyMainTeacher(string id)
    {
        String cStr = "select [TotalName] from Class where MainTeacherID= '" + id + "'";
        string ClassOt;
        List<string> l = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                ClassOt = dr["TotalName"].ToString();
                l.Add(ClassOt);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public Dictionary<string, string> getPupils(string classCode)
    {
        String selectSTR = "SELECT   dbo.Users.UserID,(dbo.Users.UserLName + ' ' + dbo.Users.UserFName)AS PupilName" +
           "  FROM dbo.Pupil INNER JOIN   dbo.Users ON dbo.Pupil.UserID = dbo.Users.UserID   where dbo.Pupil.CodeClass='" + classCode + "'";
        string UserID, UserName;
        Dictionary<string, string> l = new Dictionary<string, string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            l.Add("1", "בחר תלמיד");
            while (dr.Read())
            {
                UserID = dr["UserID"].ToString();
                UserName = dr["PupilName"].ToString();
                l.Add(UserID, UserName);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Dictionary<string, string>> getPupilsByClassCodeDictionary(string classCode)
    {
        String selectSTR = "SELECT   dbo.Users.UserID,(dbo.Users.UserLName + ' ' + dbo.Users.UserFName)AS PupilName" +
           "  FROM dbo.Pupil INNER JOIN   dbo.Users ON dbo.Pupil.UserID = dbo.Users.UserID   where dbo.Pupil.CodeClass='" + classCode + "'";

        List<Dictionary<string, string>> l = new List<Dictionary<string, string>>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("UserId", dr["UserID"].ToString());
                d.Add("PupilName", dr["PupilName"].ToString());
                l.Add(d);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Dictionary<string, string>> getPupilsByClassCodeGrades(string ClassCode)
    {
        String selectSTR = "SELECT   dbo.Users.UserID,(dbo.Users.UserLName + ' ' + dbo.Users.UserFName)AS PupilName" +
        "  FROM dbo.Pupil INNER JOIN   dbo.Users ON dbo.Pupil.UserID = dbo.Users.UserID   where dbo.Pupil.CodeClass='" + ClassCode + "'";


        List< Dictionary<string, string>> l = new List<Dictionary<string, string>>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Dictionary<string, string> p = new Dictionary<string, string>();
                p["UserId"] = dr["UserID"].ToString();
                p["UserName"] = dr["PupilName"].ToString();

                l.Add(p);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }

    }
    public List<Dictionary<string, string>> getPupilsTeachersParents(string TeacherID)
    {
        String selectSTR = "SELECT   dbo.Users.UserID,(dbo.Users.UserLName + ' ' + dbo.Users.UserFName) AS 'FullName'" +
           "  FROM dbo.Pupil INNER JOIN    dbo.Users ON dbo.Pupil.UserID = dbo.Users.UserID  where CodeClass in (SELECT distinct dbo.Timetable.ClassCode FROM  dbo.Timetable INNER JOIN " +
           "  dbo.TimetableLesson ON dbo.Timetable.TimeTableCode = dbo.TimetableLesson.TimeTableCode where dbo.TimetableLesson.TeacherId='" + TeacherID + "')" +
           " union " +
           " SELECT UserID, (dbo.Users.UserFName+' '+ dbo.Users.UserLName) as 'FullName'" +
             "  FROM dbo.PupilsParent INNER JOIN dbo.Users ON dbo.PupilsParent.ParentID = dbo.Users.UserID where CodeClass in (SELECT distinct dbo.Timetable.ClassCode FROM  dbo.Timetable INNER JOIN " +
            "  dbo.TimetableLesson ON dbo.Timetable.TimeTableCode = dbo.TimetableLesson.TimeTableCode where dbo.TimetableLesson.TeacherId='" + TeacherID + "')" +
            " union " +
            "   select UserID, (UserFName+' '+ UserLName) as 'FullName' from Users   where CodeUserType=2 and UserID <> '"+ TeacherID + "' ";

        List < Dictionary<string, string>> l = new List<Dictionary<string, string>>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Dictionary<string, string> p = new Dictionary<string, string>();
                p["UserId"] = dr["UserID"].ToString();
                p["UserName"] = dr["FullName"].ToString();

                l.Add(p);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Dictionary<string, string>> getPupilsAndTeachers(string PupilId)
    {
        String selectSTR = "SELECT   dbo.Users.UserID,(dbo.Users.UserLName + ' ' + dbo.Users.UserFName) AS PupilName FROM dbo.Pupil INNER JOIN  dbo.Users ON " +
           "  dbo.Pupil.UserID = dbo.Users.UserID  where CodeClass =(select codeClass from dbo.Pupil where UserID = '"+ PupilId + "')" +
           " union " +
           " select UserID,(UserLName + ' ' +UserFName) AS PupilName from dbo.Users where UserID in(select dbo.TimetableLesson.TeacherId " +
             "  FROM  dbo.Timetable INNER JOIN  dbo.TimetableLesson ON dbo.Timetable.TimeTableCode = dbo.TimetableLesson.TimeTableCode where " +
            "  dbo.Timetable.ClassCode =(select codeClass from dbo.Pupil where UserID = '"+ PupilId + "'))";

        List<Dictionary<string, string>> l = new List<Dictionary<string, string>>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Dictionary<string, string> p = new Dictionary<string, string>();
                p["UserId"] = dr["UserID"].ToString();
                p["UserName"] = dr["PupilName"].ToString();

                l.Add(p);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Dictionary<string, string>> getParentsAndTeachers(string PupilId)
    {
        String selectSTR = "SELECT  distinct   dbo.Users.UserID, dbo.Users.UserLName + ' ' + dbo.Users.UserFName AS PupilName FROM  dbo.Users INNER JOIN dbo.PupilsParent ON " +
           "   dbo.Users.UserID = dbo.PupilsParent.ParentID where  dbo.PupilsParent.codeClass= (select codeClass from dbo.Pupil where UserID = '"+ PupilId + "') " +
           " union " +
           " select UserID,(UserLName + ' ' +UserFName) AS PupilName from dbo.Users where UserID in(select dbo.TimetableLesson.TeacherId " +
             "  FROM  dbo.Timetable INNER JOIN  dbo.TimetableLesson ON dbo.Timetable.TimeTableCode = dbo.TimetableLesson.TimeTableCode where " +
            "  dbo.Timetable.ClassCode =(select codeClass from dbo.Pupil where UserID = '" + PupilId + "'))";

        List<Dictionary<string, string>> l = new List<Dictionary<string, string>>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Dictionary<string, string> p = new Dictionary<string, string>();
                p["UserId"] = dr["UserID"].ToString();
                p["UserName"] = dr["PupilName"].ToString();

                l.Add(p);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> getPupilsIdByClassCode(string classCode)
    {

        String selectSTR = "SELECT   dbo.Users.UserID FROM dbo.Pupil INNER JOIN " +
            "dbo.Users ON dbo.Pupil.UserID = dbo.Users.UserID   where dbo.Pupil.CodeClass='" + classCode + "'";

        List<string> l = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                l.Add(dr["UserID"].ToString());
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public Dictionary<string, string> GetTeachers()
    {
        String selectSTR = "SELECT UserID, UserFName + ' ' + UserLName AS FullName FROM Users WHERE (CodeUserType = 2)";
        string UserID, TeacherFullName;
        Dictionary<string, string> l = new Dictionary<string, string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            l.Add("0", "-");
            while (dr.Read())
            {
                UserID = dr["UserID"].ToString();
                TeacherFullName = dr["FullName"].ToString();
                l.Add(UserID, TeacherFullName);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Dictionary<string, string>> GetTeachers2()
    {
        String selectSTR = "SELECT UserID, UserFName + ' ' + UserLName AS FullName FROM Users WHERE (CodeUserType = 2)";
        List<Dictionary<string, string>> l = new List<Dictionary<string, string>>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("UserId", dr["UserID"].ToString());
                d.Add("FullName", dr["FullName"].ToString());
                l.Add(d);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> GetTeachersIds()
    {
        String selectSTR = "SELECT UserID FROM Users WHERE (CodeUserType = 2)";
        List<string> l = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                l.Add(dr["UserID"].ToString());
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public Dictionary<string, string> FillUsers(string CodeUserType)
    {
        String selectSTR = "SELECT(UserLName+' '+ UserFName) as UserName, UserID" +
           " FROM dbo.Users where CodeUserType='" + CodeUserType + "'";
        string UserID, UserName;
        Dictionary<string, string> l = new Dictionary<string, string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            l.Add("1", "בחר משתמש");
            while (dr.Read())
            {
                UserID = dr["UserID"].ToString();
                UserName = dr["UserName"].ToString();
                l.Add(UserID, UserName);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public Dictionary<int, string> GetSubjects()
    {
        String selectSTR = "SELECT DISTINCT * FROM [Lessons] ORDER BY [LessonName]";
        int SubjectID;
        string SubjectName;
        Dictionary<int, string> l = new Dictionary<int, string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            l.Add(0, "-");
            while (dr.Read())
            {
                SubjectID = int.Parse(dr["CodeLesson"].ToString());
                SubjectName = dr["LessonName"].ToString();
                l.Add(SubjectID, SubjectName);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> getSubjectsByPupilId(string Id)
    {
        String selectSTR = "SELECT dbo.TimetableLesson.CodeLesson, dbo.Lessons.LessonName " +
            "FROM dbo.Timetable INNER JOIN dbo.Class ON dbo.Timetable.ClassCode = dbo.Class.ClassCode INNER JOIN " +
            "dbo.Pupil ON dbo.Class.ClassCode = dbo.Pupil.CodeClass INNER JOIN dbo.TimetableLesson ON " +
            "dbo.Timetable.TimeTableCode = dbo.TimetableLesson.TimeTableCode INNER JOIN dbo.Lessons ON " +
            "dbo.TimetableLesson.CodeLesson = dbo.Lessons.CodeLesson where dbo.Pupil.UserID = '" + Id + "'";

        List<string> l = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                string SubjectName = dr["LessonName"].ToString();
                l.Add(SubjectName);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetTeacherNameByID(string TeacherId)
    {
        String selectSTR = "SELECT UserFName + ' ' + UserLName FROM Users where UserId = '" + TeacherId + "'";
        string teacherName = "";

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                teacherName = dr[0].ToString();
            }

            return teacherName;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public Dictionary<string, string> FillClassOtWithoutMainTheacher()
    {
        String selectSTR = "SELECT ClassCode,TotalName FROM Class where MainTeacherID is null order by TotalName";
        string ClassCode, TotalName;
        Dictionary<string, string> l = new Dictionary<string, string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            l.Add("0", "בחר");
            while (dr.Read())
            {
                ClassCode = dr["ClassCode"].ToString();
                TotalName = dr["TotalName"].ToString();
                l.Add(ClassCode, TotalName);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }

    }
    public Dictionary<string, string> FillClassOt()
    {
        String selectSTR = "SELECT ClassCode,TotalName FROM Class order by TotalName";
        string ClassCode, TotalName;
        Dictionary<string, string> l = new Dictionary<string, string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            l.Add("0", "בחר");
            while (dr.Read())
            {
                ClassCode = dr["ClassCode"].ToString();
                TotalName = dr["TotalName"].ToString();
                l.Add(ClassCode, TotalName);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public Dictionary<string, string> FillTeacherNotBusy(int WeekDay, int LessonNum )
    {
        String selectSTR = "select [UserID],[UserFName]+' '+ [UserLName] as FullName from [dbo].[Users] where [CodeUserType]=2 and [UserID] not in (select [TeacherId] from [dbo].[TimetableLesson] " +
                           " where [CodeWeekDay] = "+WeekDay+" and [ClassTimeCode] = "+ LessonNum+" union select [TeacherId] from [dbo].[TempTimetableLesson] where [CodeWeekDay] = "+ WeekDay+" and [ClassTimeCode] = "+ LessonNum+" )";
        string UserID, TotalName;
        Dictionary<string, string> l = new Dictionary<string, string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                UserID = dr["UserID"].ToString();
                TotalName = dr["FullName"].ToString();
                l.Add(UserID, TotalName);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    //--------------------------------------------------------------------------------------------------
    // This method returns number of rows affected
    //--------------------------------------------------------------------------------------------------
    public int ExecuteNonQuery(string str)
    {
        SqlCommand cmd;
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex);
        }

        try
        {
            cmd = CreateCommand(str, con);
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Dictionary<string, string>> GetTimeTableAcordingToClassCode(int classCode) //webService
    {
        //keep just one time table for a class. no history.
        List<Dictionary<string, string>> TT = new List<Dictionary<string, string>>();
        SqlCommand cmd; string cStr;
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            cStr = "select [dbo].[TimetableLesson].TimeTableCode, [dbo].[TimetableLesson].CodeWeekDay, [dbo].[TimetableLesson].ClassTimeCode, [dbo].[TimetableLesson].CodeLesson, [dbo].[TimetableLesson].TeacherId from [dbo].[TimetableLesson] inner join[dbo].[Timetable] on[dbo].[TimetableLesson].TimeTableCode = [dbo].[Timetable].TimeTableCode where[dbo].[Timetable].ClassCode = " + classCode +
                " order by [dbo].[TimetableLesson].ClassTimeCode";
            cmd = CreateCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Dictionary<string, string> lesson = new Dictionary<string, string>();
                lesson.Add("TimeTableCode", dr["TimeTableCode"].ToString());
                lesson.Add("CodeWeekDay", dr["CodeWeekDay"].ToString());
                lesson.Add("ClassTimeCode", dr["ClassTimeCode"].ToString());
                lesson.Add("CodeLesson", dr["CodeLesson"].ToString());
                lesson.Add("TeacherId", dr["TeacherId"].ToString());

                TT.Add(lesson);
            }
            return TT;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Dictionary<string, string>> GetTimeTableAcordingToClassCodeForMobile(int classCode) //webService
    {
        //keep just one time table for a class. no history.
        List<Dictionary<string, string>> TT = new List<Dictionary<string, string>>();
        SqlCommand cmd; string cStr;
        cStr = "select [dbo].[TimetableLesson].TimeTableCode, [dbo].[TimetableLesson].CodeWeekDay, [dbo].[TimetableLesson].ClassTimeCode, [dbo].[TimetableLesson].CodeLesson, [dbo].[TimetableLesson].TeacherId from [dbo].[TimetableLesson] inner join[dbo].[Timetable] on[dbo].[TimetableLesson].TimeTableCode = [dbo].[Timetable].TimeTableCode where[dbo].[Timetable].ClassCode = " + classCode +
            " order by [dbo].[TimetableLesson].ClassTimeCode";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            cmd = CreateCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Dictionary<string, string> lesson = new Dictionary<string, string>();
                lesson.Add("TimeTableCode", dr["TimeTableCode"].ToString());
                lesson.Add("CodeWeekDay", dr["CodeWeekDay"].ToString());
                lesson.Add("ClassTimeCode", dr["ClassTimeCode"].ToString());
                string subjectCode = dr["CodeLesson"].ToString();
                Subject s = new Subject();
                //המרה של הקוד מקצוע לשם מקצוע
                string subjectName = s.GetSubjectNameBySubjectCode(subjectCode);
                lesson.Add("CodeLesson", subjectName);
                string teacherId = dr["TeacherId"].ToString();
                Users t = new Users();
                //המרה של הת.ז. מורה לשם מורה
                string teacherName = t.GetUserFullNameByID(teacherId);
                lesson.Add("TeacherId", teacherName);
                TT.Add(lesson);
            }
            return TT;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetSubjectNameBySubjectCode(string subjectCode)
    {
        SqlCommand cmd; string cStr, lessonName = "";
        cStr = "select LessonName from Lessons where CodeLesson = " + int.Parse(subjectCode);
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            cmd = CreateCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                lessonName = dr[0].ToString();
            }
            return lessonName;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Dictionary<string, string>> GetValuesTimeTableAcordingToClassCode(int classCode)
    {
        List<Dictionary<string, string>> TT = new List<Dictionary<string, string>>();
        SqlCommand cmd; string cStr;
        cStr = "select [dbo].[TimetableLesson].TimeTableCode, [dbo].[TimetableLesson].CodeWeekDay, [dbo].[TimetableLesson].ClassTimeCode, [dbo].[TimetableLesson].CodeLesson, [dbo].[TimetableLesson].TeacherId from [dbo].[TimetableLesson] inner join[dbo].[Timetable] on[dbo].[TimetableLesson].TimeTableCode = [dbo].[Timetable].TimeTableCode where[dbo].[Timetable].ClassCode = " + classCode;
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            cmd = CreateCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Dictionary<string, string> lesson = new Dictionary<string, string>();
                lesson.Add("TimeTableCode", dr["TimeTableCode"].ToString());
                lesson.Add("CodeWeekDay", dr["CodeWeekDay"].ToString());
                lesson.Add("ClassTimeCode", dr["ClassTimeCode"].ToString());
                lesson.Add("CodeLesson", dr["CodeLesson"].ToString());
                lesson.Add("TeacherId", dr["TeacherId"].ToString());

                TT.Add(lesson);
            }
            return TT;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public bool IsClassHasTimeTable(string classCode)
    {
        int num = 0;
        String selectSTR = "SELECT count(TimeTableCode) FROM Timetable where ClassCode = " + classCode;
        bool ans = false;
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                num = int.Parse(dr[0].ToString());
            }

            if (num > 0)
            {
                ans = true;
            }
            return ans;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }


    public int DeleteTimeTableLessons(string classCode)
    {
        String selectSTR = "DELETE T2 FROM dbo.TimetableLesson as T2 INNER JOIN dbo.Timetable as T1 ON T2.TimeTableCode = T1.TimeTableCode where T1.ClassCode = " + classCode;
        return ExecuteNonQuery(selectSTR);
    }

    public int DeleteTimeTable(string classCode) //
    {
        String selectSTR = "DELETE FROM dbo.Timetable where ClassCode = " + classCode;
        return ExecuteNonQuery(selectSTR);
    }

    public int DeleteTempTT(string date, string classcode)
    {
        String selectSTR = "DELETE FROM dbo.TempTimetableLesson where [dateString] = '" + date + "'[CodeChoosenClass] = " + classcode;
        return ExecuteNonQuery(selectSTR);
    }

    public int DeleteTT(string classCode)
    {
        int num = 0;
        try
        {
            using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Betsefer"].ConnectionString))
            {
                using (var cmd = new SqlCommand("DeleteTempTT", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@classCode", classCode);
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                        }
                        num = 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return num;
    }

    public string GetCellInfoUPDATECodeTable(string ClassCode)
    {
        String selectSTR = "select [TimeTableCode]  from [dbo].[Timetable] where [ClassCode]=" + ClassCode;
        string TableCode = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                TableCode = dr[0].ToString();
            }
            return TableCode;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetLessonNameByLessonCode(string lessonCode)
    {
        String selectSTR = "SELECT LessonName FROM Lessons where CodeLesson = " + lessonCode;
        string lessonName = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                lessonName = dr[0].ToString();
            }
            return lessonName;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    
    public DataTable GetsubjectsByClassandTeacherID(string TeacherID, string ClassCode)
    {
        String selectSTR = "SELECT  distinct dbo.Lessons.CodeLesson,dbo.Lessons.LessonName FROM  dbo.Timetable INNER JOIN  dbo.TimetableLesson ON dbo.Timetable.TimeTableCode "+
                           " = dbo.TimetableLesson.TimeTableCode INNER JOIN  dbo.Class ON dbo.Timetable.ClassCode = dbo.Class.ClassCode AND dbo.Timetable.ClassCode = dbo.Class.ClassCode " +
                            "  INNER JOIN  dbo.Lessons ON dbo.TimetableLesson.CodeLesson = dbo.Lessons.CodeLesson where dbo.TimetableLesson.TeacherId = '"+ TeacherID + "' and dbo.Class.TotalName = '"+ ClassCode + "' ";
        DataTable dtt = new DataTable();
        DataSet ds;

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con); // create the data adapter
            ds = new DataSet("HWCountDS");
            daa.Fill(ds);
            return dtt = ds.Tables[0];
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public Dictionary<string, string> GetSubjectsByClassCode(string classCode)
    {
        String selectSTR = "SELECT distinct dbo.Lessons.CodeLesson, dbo.Lessons.LessonName FROM dbo.Timetable " +
            "INNER JOIN dbo.Class ON dbo.Timetable.ClassCode = dbo.Class.ClassCode AND " +
            "dbo.Timetable.ClassCode = dbo.Class.ClassCode INNER JOIN dbo.TimetableLesson ON " +
            "dbo.Timetable.TimeTableCode = dbo.TimetableLesson.TimeTableCode INNER JOIN dbo.Lessons " +
            "ON dbo.TimetableLesson.CodeLesson = dbo.Lessons.CodeLesson where dbo.Class.ClassCode = " + classCode;
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Dictionary<string, string> d = new Dictionary<string, string>();
            while (dr.Read())
            {
                string lessonCode = dr["CodeLesson"].ToString();
                string lessonName = dr["LessonName"].ToString();
                d.Add(lessonCode, lessonName);
            }
            return d;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetUserIDByFullName(string FullName)
    {
        String selectSTR = "select USerID from [dbo].[Users] where  UserFName + ' ' + UserLName ='"+ FullName + "'";
        string Name = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Name = dr[0].ToString();
            }
            return Name;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }

    }
    public string GetUserFullNameByID(string TeacherId)
    {
        String selectSTR = "SELECT UserFName + ' ' + UserLName FROM Users where UserId = '" + TeacherId + "'";
        string Name = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Name = dr[0].ToString();
            }
            return Name;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> GetPupilIdByParentId(string UserId)
    {
        String selectSTR = "SELECT dbo.PupilsParent.PupilID FROM dbo.UserType INNER JOIN " +
                         "dbo.Users ON dbo.UserType.CodeUserType = dbo.Users.CodeUserType INNER JOIN " +
                         "dbo.PupilsParent ON dbo.Users.UserID = dbo.PupilsParent.ParentID " +
                         "where dbo.PupilsParent.ParentID ='" + UserId + "'";
        List<string> PupilId = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                PupilId.Add(dr[0].ToString());
            }
            return PupilId;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> GetParentsIdsByPupilId(string pupilID)
    {
        List<string> parents = new List<string>();

        String selectSTR = "SELECT dbo.PupilsParent.ParentID FROM dbo.UserType INNER JOIN " +
                            "dbo.Users ON dbo.UserType.CodeUserType = dbo.Users.CodeUserType INNER JOIN " +
                            "dbo.PupilsParent ON dbo.Users.UserID = dbo.PupilsParent.ParentID " +
                            "where dbo.PupilsParent.PupilID = '" + pupilID + "'";

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                parents.Add(dr[0].ToString());
            }
            return parents;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Dictionary<string, string>> getParentsByClassCode(string classCode)
    {
        List<Dictionary<string, string>> parents = new List<Dictionary<string, string>>();

        String selectSTR = "SELECT UserID, (dbo.Users.UserFName+' '+ dbo.Users.UserLName) as 'FullName'" +
                               " FROM dbo.PupilsParent INNER JOIN dbo.Users ON dbo.PupilsParent.ParentID = dbo.Users.UserID" +
                               " where dbo.PupilsParent.codeClass = '" + classCode + "'";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("UserId", dr["UserID"].ToString());
                d.Add("FullName", dr["FullName"].ToString());
                parents.Add(d);
            }
            return parents;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> getParentsAndPupilsIdByClassCode(string classCode)
    {
        List<string> parents = new List<string>();

        String selectSTR = "SELECT UserID FROM dbo.PupilsParent INNER JOIN dbo.Users ON dbo.PupilsParent.ParentID =" +
            " dbo.Users.UserID where dbo.PupilsParent.codeClass = ( select ClassCode from [dbo].[Class] where TotalName='"+ classCode + "') union" +
            "  SELECT dbo.Users.UserID FROM dbo.Pupil INNER JOIN dbo.Users ON dbo.Pupil.UserID = dbo.Users.UserID where dbo.Pupil.codeClass = ( select ClassCode from [dbo].[Class] where TotalName='"+ classCode + "')";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                parents.Add(dr["UserID"].ToString());
            }
            return parents;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> getParentsIdByClassCode(string classCode)
    {
        List<string> parents = new List<string>();

        String selectSTR = "SELECT UserID FROM dbo.PupilsParent INNER JOIN dbo.Users ON dbo.PupilsParent.ParentID =" +
            " dbo.Users.UserID where dbo.PupilsParent.codeClass = '" + classCode + "'";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                parents.Add(dr["UserID"].ToString());
            }
            return parents;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string IsStudentUserNotThisParentYet(string childID, string parentID)
    {
        String STRcheckIfConnectionExists = "SELECT count(ParentID) from PupilsParent where ParentID = '" + parentID +
            "' and PupilID = '" + childID + "'",
            answer = "";
        int numConnections = -1;

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        
        try
        {
            SqlCommand cmd = new SqlCommand(STRcheckIfConnectionExists, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                numConnections = int.Parse(dr[0].ToString());
            }

            if (numConnections == 0)
            {
                answer = "everythingGood";
            }
            else if (numConnections > 0)
            {
                answer = "connectionExists";
            }
            return answer;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public int SaveChildAndParent(string parentID, string childID)
    {
        string codeClass = GetPupilOtClass(childID);
        String cStr = "INSERT INTO [dbo].[PupilsParent] VALUES ('" + parentID + "', '" + childID + "', '" + codeClass + "')";
        return ExecuteNonQuery(cStr);
    }

    public int SendPrivateMessage(string SenderID, string RecieientID, string Subject, string content)
    {
        string contentToHtml = content.Replace("\n", "<br />");
        string tipulBeGeresh = contentToHtml.Replace("'", "''");
        string dateTime = "";
        if (DateTime.Today.Month < 10)
        {
            dateTime = DateTime.Today.Day + "/0" + DateTime.Today.Month + "/" + DateTime.Today.Year + " " +
            DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }
        else
        {
            dateTime = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year + " " +
            DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }

        string cStr = "INSERT INTO [dbo].[Messages] (MessageDate, SenderID, recipientID, TheMessage, SubjectMessage)" +
            " VALUES ('" + dateTime + "', '" + SenderID + "', '" + RecieientID + "', '" + tipulBeGeresh + "', '" + Subject + "')";
        return ExecuteNonQuery(cStr);
    }

    public int SendKolektiveMessage(string SenderID, string userClass, string userType, string Subject, string content)
    {
        List<string> usersIds = new List<string>();
        String cStr = "";
        string classCode = "", dateTime = "";

        if (userClass!= "" )
        {
            Classes Cl = new Classes();

            classCode = Cl.GetClassCodeAccordingToClassFullName(userClass);
        }
        if (classCode == "")
        {
            classCode = userClass;
        }

        switch (userType)
        {
            case "pupils":
                usersIds = getPupilsIdByClassCode(classCode);
                break;
            case "parents":
                usersIds = getParentsIdByClassCode(classCode);
                break;
            case "teachers":
                usersIds = GetTeachersIds();
                break;
            case "parentsAndPupils":
                usersIds = getParentsAndPupilsIdByClassCode(classCode);
                break;
        }
        if (DateTime.Today.Month < 10)
        {
            dateTime = DateTime.Today.Day + "/0" + DateTime.Today.Month + "/" + DateTime.Today.Year + " " +
            DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }
        else
        {
            dateTime = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year + " " +
            DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }

        for (int i = 0; i < usersIds.Count; i++)
        {
            if (SenderID != usersIds[i])
            {
                cStr += "INSERT INTO [dbo].[Messages] (MessageDate, SenderID, recipientID, TheMessage, SubjectMessage) VALUES ('" + dateTime + "','" + SenderID + "', '" + usersIds[i] +
            "', '" + content + "','" + Subject + "')";
            }
        }

        return ExecuteNonQuery(cStr);
    }

    public DataTable getPupillistsByClassCode( string ClassCode)
    {
        String selectSTR =" SELECT  dbo.Users.UserID,dbo.Users.UserFName + ' ' + dbo.Users.UserLName as 'FullName' FROM dbo.Pupil INNER JOIN "+
                            " dbo.Class ON dbo.Pupil.CodeClass = dbo.Class.ClassCode INNER JOIN dbo.Users ON dbo.Pupil.UserID = dbo.Users.UserID where dbo.Class.TotalName = '"+ClassCode+"'";
        DataTable dtt = new DataTable();
        DataSet ds;

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con); // create the data adapter
            ds = new DataSet("HWpupilDS");
            daa.Fill(ds);
            return dtt = ds.Tables[0];
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetUserImgByUserID(string UserID)
    {
        String selectSTR = "SELECT UserImg FROM dbo.Users where UserID = '" + UserID + "'";
        string UserImg = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                UserImg = dr["UserImg"].ToString();
            }
            return UserImg;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
 public List<string> GetUserImgAndFullNameByUserID(string UserID)
    {

         List<string> UserInfo = new List<string>();
        String selectSTR = "SELECT UserFName + ' ' + UserLName as UserName, UserImg FROM dbo.Users where UserID = '" + UserID + "'";
      // string UserImg = "";
       // string UserName = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                UserInfo.Add(dr["UserName"].ToString());
                UserInfo.Add(dr["UserImg"].ToString());
            }
            return UserInfo;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }




    public string UpdateMessageAsRead(string MessageCode)
    {
        String cStr = "UPDATE Messages SET IsReadByRecipient = 1 WHERE SenderID = (select SenderID from Messages where MessageCode = '"+ MessageCode +"')";
        string answer = ExecuteNonQuery(cStr).ToString();
        return answer;
    }

    //********************** add to application **********************************

    public List<Dictionary<string, string>> LoadScheduleForToday(string Id, string userType, int? day = null)
    {
        //keep just one time table for a class. no history.
        List<Dictionary<string, string>> TT = new List<Dictionary<string, string>>();
        SqlCommand cmd; string cStr = "";
        // var weekDayCode = DateTime.Now.DayOfWeek;
        int today;
        if (day != null && day != 0)
        {
            today = day.Value;
        }
        else today = (int)DateTime.Now.DayOfWeek + 1; //check that it is work ok!! ****************************************************************************

        switch (int.Parse(userType))
        {
            case 1: // admin
                break;
            case 2: // teacher
                cStr = "select TimeTableCode, (select WeekDayName from WeekDays where CodeWeekDay = '"+ today + "') as WeekDay, ClassTimeCode, CodeLesson, TeacherId from TimetableLesson where CodeWeekDay = "+ today +" and TeacherId = '" + Id + "'";
                break;
            case 3: // parent
                cStr = "";
                break;
            case 4: // pupil
                var classCode = GetClassCodeByPupilId(Id);
                cStr = "select TimetableLesson.TimeTableCode, (select WeekDayName from WeekDays where CodeWeekDay = '" + today + "') as WeekDay, TimetableLesson.ClassTimeCode, TimetableLesson.CodeLesson, TimetableLesson.TeacherId " +
                    "from TimetableLesson inner join Timetable on TimetableLesson.TimeTableCode = Timetable.TimeTableCode and TimeTable.ClassCode = '"+ classCode + "' and TimetableLesson.CodeWeekDay = '"+ today +"'";
                break;
        }

        SqlConnection con2 = new SqlConnection();

        try
        {
            con2 = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            cmd = new SqlCommand(cStr, con2);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string lessonName, lessonHours, className, teacherName;
            while (dr.Read())
            {
                Dictionary<string, string> lesson = new Dictionary<string, string>();
                lesson.Add("TimeTableCode", dr["TimeTableCode"].ToString());
                className = GetClassNameByTimeTableCode(dr["TimeTableCode"].ToString());
                lesson.Add("ClassName", className);

                lesson.Add("WeekDay", dr["WeekDay"].ToString());
                lesson.Add("ClassTimeCode", dr["ClassTimeCode"].ToString());

                lessonHours = GetLessonHoursByCode(dr["ClassTimeCode"].ToString());
                lesson.Add("lessonHours", lessonHours);
                lessonName = GetLessonNameByLessonCode(dr["CodeLesson"].ToString());
                lesson.Add("LessonName", lessonName);
                lesson.Add("TeacherId", dr["TeacherId"].ToString());

                teacherName = GetUserFullNameByID(dr["TeacherId"].ToString());
                lesson.Add("TeacherName", teacherName);

                TT.Add(lesson);
            }
            return TT;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con2 != null)
            {
                con2.Close();
            }
        }
    }

    public string GetLessonHoursByCode(string code)
    {
        SqlCommand cmd; string cStr = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cStr = "select CONVERT(varchar,EndClassTime , 108) + ' - ' + CONVERT(varchar,StartClassTime , 108) as LessonHours from ClassTime where ClassTimeCode = '" + code + "'";

        try
        {
            cmd = CreateCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string hours = "";

            while (dr.Read())
            {
                hours = dr["LessonHours"].ToString();
            }
            return hours;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetClassNameByTimeTableCode(string TTC)
    {
        SqlCommand cmd; string cStr = "";
        try
        {
                con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cStr = "select ClassCode from TimeTable where TimeTableCode = '"+ TTC +"'";

        try
        {
            cmd = CreateCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string className = "";

            while (dr.Read())
            {
                className = GetClassNameByCodeClass(int.Parse(dr["ClassCode"].ToString()));
            }
            return className;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public string GetClassCodeByPupilId(string Id)
    {
        SqlCommand cmd; string cStr = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cStr = "select CodeClass from Pupil where UserID = '" + Id + "'";

        try
        {
            cmd = CreateCommand(cStr, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string classCode = "";

            while (dr.Read())
            {
                classCode = dr["CodeClass"].ToString();
            }
            return classCode;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> GetClassesFullName_JustClassesWithPupils()
    {
        String selectSTR = "select distinct Class.[TotalName], Class.[OtClass], Class.[NumClass] from [dbo].[Class] INNER JOIN [dbo].[Pupil] ON Class.ClassCode = Pupil.CodeClass order by OtClass, NumClass";
        string Ot;
        List<string> l = new List<string>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Ot = dr["TotalName"].ToString();
                l.Add(Ot);
            }
            return l;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Users> getUserList(string PrivOrColec,string type, string ClassCode)
    {
        String selectSTR = "";
   
        switch (PrivOrColec)
        {
            case "Privet":
                 selectSTR = "select [UserID],[PushRegID] from  [dbo].[Users] where [PushRegID] != 'null' and [UserID] ='"+ ClassCode+"'";
                break;
            case "Colective":

                switch (type)
                {
                    case "1": //admin
                        selectSTR = "select [UserID],[PushRegID] from  [dbo].[Users] where [CodeUserType]=1 and [PushRegID] != 'null'";
                        break;
                    case "2": //teacher
                        selectSTR = "select [UserID],[PushRegID] from  [dbo].[Users] where [CodeUserType]=2 and [PushRegID] != 'null'";
                        break;
                    case "3": //parent
                        selectSTR = "select [UserID],[PushRegID] from  [dbo].[Users] where [CodeUserType]=3 and [UserID] in (select ParentID from PupilsParent where codeClass="+ ClassCode+" ) and [PushRegID] != 'null'";
                        break;
                    case "4": // pupil
                        selectSTR = "select [UserID],[PushRegID] from  [dbo].[Users] where [CodeUserType]=4 and [UserID] in (select UserID from Pupil where codeClass="+ ClassCode+" ) and [PushRegID] != 'null'";
                        break;
                    case "5": //pupils+parent of spesific class
                        selectSTR = "select [UserID],[PushRegID] from  [dbo].[Users] where ([CodeUserType]=4 or  [CodeUserType]=3) and ( [UserID] in (select ParentID from PupilsParent where codeClass=" + ClassCode + ") " +
                                    " or [UserID] in (select UserID from Pupil where codeClass = " + ClassCode + " )) and [PushRegID] != 'null'";
                        break;
                    case "6": // //pupil+parent of spesific pupil
                        selectSTR = "select [UserID],[PushRegID] from  [dbo].[Users] where UserID ='" + ClassCode + "' or UserID  = (select ParentID from PupilsParent where PupilID= '" + ClassCode + "' ) and [PushRegID] != 'null'";
                        break;
                }
                break;
        }

        List<Users> userList = new List<Users>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Users u = new Users();
                u.UserID1 = dr["UserID"].ToString();
                u.RegId = dr["PushRegID"].ToString();

                userList.Add(u);
            }
            return userList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Users> getSpesificUserList(Dictionary<string,string> UserList)
    {
        String selectSTR = "";
        List<Users> userList = new List<Users>();

        foreach (var item in UserList)
        {
            selectSTR = "select [UserID],[PushRegID] from  [dbo].[Users] where [PushRegID] != 'null' and [UserID] ='" + item.Key + "'";

            try
            {
                con = connect("Betsefer"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            try
            {
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Users u = new Users();
                    u.UserID1 = dr["UserID"].ToString();
                    u.RegId = dr["PushRegID"].ToString();

                    userList.Add(u);
                }
                
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        return userList;


    }

    public int GetCodeWeekDayByDate(string date)
    {
        int year = int.Parse(date.Substring(6)), mont = int.Parse(date.Substring(3, 2)), day = int.Parse(date.Substring(0,2));
        DateTime dateValue = new DateTime(year, mont, day);
        return (int)dateValue.DayOfWeek;
    }

    public string SaveMeMeeting(string ParentsDayMeeting, string PupilID)
    {
        string num = "";
        try
        {
            using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Betsefer"].ConnectionString))
            {
                using (var cmd = new SqlCommand("UpdateMeeting", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PupilID", PupilID);
                    cmd.Parameters.AddWithValue("@MeetingCode", ParentsDayMeeting);

                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            num = reader[0].ToString();
                        }
                        //  num = 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return num;
    }

    public int DeleteMyMeeting(string ParentsDayMeeting)
    {
        String cStr = "UPDATE ParentsDayMeeting SET PupilID = null WHERE MeetingCode = " + ParentsDayMeeting;
        return ExecuteNonQuery(cStr);
    }

    public string GetLessonCodeByLessonName(string Lesson) {
        String selectSTR = "SELECT CodeLesson FROM Lessons where LessonName = '" + Lesson + "'";
        string lessonCode = "";
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                lessonCode = dr[0].ToString();
            }
            return lessonCode;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public Dictionary<string, string> GetChildrenByParentID(string parentSelected)
    {
        String selectSTR = "SELECT dbo.Users.UserID, dbo.Users.UserFName +' '+dbo.Users.UserLName as FullPupilName, dbo.PupilsParent.ParentID "+ 
                            "FROM dbo.Users INNER JOIN dbo.PupilsParent ON  dbo.Users.UserID = dbo.PupilsParent.PupilID " +
                            "where dbo.PupilsParent.ParentID = '"+ parentSelected + "'";
        Dictionary<string, string> children = new Dictionary<string, string>();

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                children.Add(dr["UserID"].ToString(), dr["FullPupilName"].ToString());
            }
            return children;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public Dictionary<string, string> getAllPupils()
    {
        String selectSTR = "SELECT UserID, UserFName +' '+UserLName as FullPupilName " +
                            "FROM dbo.Users where CodeUserType = 4";

        Dictionary<string, string> pupils = new Dictionary<string, string>();

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                pupils.Add(dr["UserID"].ToString(), dr["FullPupilName"].ToString());
            }
            return pupils;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public int UploadImg(string UserID, string Img)
    {
        String cStr = "update Users set UserImg = '" + Img + "' where UserID = '" + UserID + "'";
        return ExecuteNonQuery(cStr); // execute the command   
    }

 public string GetGradesFeedbackPerStudent(string PupilID)
    {
        List<string> good = new List<string>();
        List<string> bad = new List<string>();

        //get list avg every subject per pupil
        Dictionary<string, int> avgSubjectsPupil = GetAvgEachSubjectPerPupil(PupilID);

        //get class code
        string classCode = GetClassCodeByPupilId(PupilID);

        //get list avg class every subject
        Dictionary<string, int> avgSubjectsClass = GetAvgEachSubjectPerClass(classCode);

        // check where the pupil is under the avg and if it much lower,
        //and where he is higher than avg class and keep it in 2 lists.
        foreach (var item in avgSubjectsPupil)
        {
            if (item.Value < avgSubjectsClass[item.Key]) //under the avg
            {
                if (avgSubjectsClass[item.Key] - item.Value >= 10) //HomeWork much under (if more than 20 points different)
                {
                    //change the subjects code to subjects name
                    bad.Add(GetSubjectNameBySubjectCode(item.Key));
                }
            }
            else if (avgSubjectsClass[item.Key] < 75)
            { 
                if (item.Value - avgSubjectsClass[item.Key] >= 15) //higher thgan avg (if more than 20 points different)
                {
                    //change the subjects code to subjects name
                    good.Add(GetSubjectNameBySubjectCode(item.Key));
                }
            }
            else if (item.Value > avgSubjectsClass[item.Key] + 5)
            {
                good.Add(GetSubjectNameBySubjectCode(item.Key));
            }
        }

        //random from the table sentence
        List<string> randon = GetEncourageAndComplimentSentences();

        //return sentence and insert the subjects that he had to practice on and also good at them
        //combine the to lists to one sentence. (כל הכבוד אתה ממש טוב במתמטיקה ואנגלית. אולי כדאי לצפות ביוטיוב בנושאים הקשורים לפיזיקה)
        string subjectsGood = "", subjectsBad = "";

        for (int i = 0; i < good.Count; i++)
        {
            subjectsGood += good[i];
            if (i + 1 != good.Count)
            {
                if (i + 2 == good.Count)
                {
                    subjectsGood += " ו";
                }
                else subjectsGood += ", ";
            }
            else
            {
                subjectsGood += ".\n";
            }
        }
        for (int i = 0; i < bad.Count; i++)
        {
            subjectsBad += bad[i];
            if (i + 1 != bad.Count)
            {
                if (i + 2 == bad.Count)
                {
                    subjectsBad += " ו";
                }
                else subjectsBad += ", ";
            }
            else
            {
                subjectsBad += ".\n";
            }
        }
        string answer = "";
        if (good.Count > 0)
        {
            answer += randon.First() + subjectsGood;
        }
        if (bad.Count > 0)
        {
            answer += randon.Last() + subjectsBad;
        }
        return answer;
    }

    private Dictionary<string, int> GetAvgEachSubjectPerPupil(string PupilID)
    {
        String selectSTR = "SELECT  dbo.Exams.SubjectCode, avg(dbo.Grades.Grade) 'AvgGarde' FROM dbo.Exams INNER JOIN " +
            "dbo.Grades ON dbo.Exams.ExamCode = dbo.Grades.ExamCode where dbo.Grades.PupilID='" +
            PupilID + "' group by dbo.Exams.SubjectCode order by AvgGarde desc";

        Dictionary<string, int> avgSubjectsPupil = new Dictionary<string, int>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                avgSubjectsPupil.Add(dr["SubjectCode"].ToString(), int.Parse(dr["AvgGarde"].ToString()));
            }
            return avgSubjectsPupil;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    private Dictionary<string, int> GetAvgEachSubjectPerClass(string classCode)
    {
        String selectSTR = "SELECT  dbo.Exams.SubjectCode, avg(dbo.Grades.Grade) 'AvgGarde' FROM dbo.Exams INNER JOIN " +
            "dbo.Grades ON dbo.Exams.ExamCode = dbo.Grades.ExamCode where dbo.Exams.ClassCode='" +
            classCode + "' group by dbo.Exams.SubjectCode order by AvgGarde desc";

        Dictionary<string, int> avgSubjectsClass = new Dictionary<string, int>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                avgSubjectsClass.Add(dr["SubjectCode"].ToString(), int.Parse(dr["AvgGarde"].ToString()));
            }
            return avgSubjectsClass;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    private List<string> GetEncourageAndComplimentSentences()
    {
        Random random = new Random();
        int rnd1 = random.Next(1, 10), rnd2 = random.Next(1, 10); // 1-9
        List<string> sentences = new List<string>();

        String selectSTR =  " SELECT ComplimentsStr, EnSentence FROM dbo.EncourageSentence CROSS JOIN " +
                           "  dbo.Compliments where ComplimentCode = "+ rnd1+" and EnSenCode =  " + rnd2;
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                sentences.Add(dr["ComplimentsStr"].ToString());
                sentences.Add(dr["EnSentence"].ToString());
            }
            return sentences;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<int> GetNumbersOfUsersForPie()
    {
        String selectSTR = "SELECT count(UserID) from Users where CodeUserType is not null group by CodeUserType";

        List<int> users = new List<int>();
        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                users.Add(int.Parse(dr[0].ToString()));
            }
            return users;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<string> GetTeachersToSubjectsBar()
    {
        String selectSTR = "SELECT Lessons.LessonName, count(TeachersTeachesSubjects.TeacherID) as NumberOfTeachers " +
"FROM Lessons INNER JOIN TeachersTeachesSubjects ON " +
"Lessons.CodeLesson=TeachersTeachesSubjects.CodeLessons group by Lessons.LessonName " +
"order by NumberOfTeachers desc";

        List<string> subjects = new List<string>();
        List<int> numbers = new List<int>();

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                subjects.Add(dr["LessonName"].ToString());
                numbers.Add(int.Parse(dr["NumberOfTeachers"].ToString()));
            }

            List<string> together = new List<string>();
            for (int i = 0; i < subjects.Count; i++)
            {
                together.Add(subjects[i]);
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                together.Add(numbers[i].ToString());
            }
            return together;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
}
