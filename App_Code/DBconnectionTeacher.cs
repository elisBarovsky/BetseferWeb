﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DBconnectionTeacher
/// </summary>
public class DBconnectionTeacher
{
    public SqlDataAdapter da;
    public DataTable dt;
    SqlConnection con = new SqlConnection();
    DBconnection db = new DBconnection();

    public DBconnectionTeacher()
    {
    }

    public SqlConnection connect(String conString)  // read the connection string from the configuration file
    {
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //---------------------------------------------------------------------------------
    // Create the SqlCommand
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object
        cmd.Connection = con;              // assign the connection to the command object
        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 
        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds
        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure
        return cmd;
    }

    public DataTable PupilList(string ClassOtID)
    {
        string selectSTR = " SELECT dbo.Pupil.UserID, (dbo.Users.UserFName +' '+ dbo.Users.UserLName) as PupilName, dbo.Grades.Grade" +
                        " FROM dbo.Pupil INNER JOIN dbo.Users ON dbo.Pupil.UserID = dbo.Users.UserID Full outer JOIN dbo.Grades ON dbo.Users.UserID = dbo.Grades.PupilID where dbo.Pupil.CodeClass = '" + ClassOtID + "'";
        DataTable dtt = new DataTable();
        DataSet ds ;
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
            SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con);
            ds = new DataSet("PupilsDS");
            daa.Fill(ds);
            return  dtt = ds.Tables[0];
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

    public DataTable PupilGrades(string PupilID)  //New !! 
    {
        string selectSTR = "    SELECT ab.ExamCode,dbo.Lessons.LessonName,ab.ExamDate,dbo.Grades.PupilID,dbo.Grades.Grade,    (select [UserFName]+' '+[UserLName]   from [dbo].[Users] where [UserID]= ab.TeacherID) as Teacher_FullName," +
                        "   ( select avg(Grade) 'AvgGarde' from [dbo].[Grades] ac  where ab.ExamCode= dbo.Grades.ExamCode  ) 'ExamAVG'  FROM    dbo.Exams ab INNER JOIN  dbo.Grades ON dbo.Grades.ExamCode = ab.ExamCode INNER JOIN " +
                        "      dbo.Users ON dbo.Grades.PupilID = dbo.Users.UserID  INNER JOIN   dbo.Pupil ON dbo.Users.UserID = dbo.Pupil.UserID INNER JOIN  " +
                        "   dbo.Lessons ON ab.SubjectCode = dbo.Lessons.CodeLesson where  dbo.Grades.PupilID = '" + PupilID + "'  order by ab.ExamDate desc  ";
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
            SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con);
            ds = new DataSet("GradesDS");
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

    public DataTable PupilAvgGrades(string ClassCode)  //New !! 
    {
        string selectSTR = "    SELECT PupilID, avg(Grade) 'AvgGarde' FROM dbo.Exams INNER JOIN dbo.Grades ON dbo.Exams.ExamCode = dbo.Grades.ExamCode where ClassCode='" + ClassCode + "' group by PupilID order by AvgGarde desc";
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
            SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con);
            ds = new DataSet("AvgGradesDS");
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

    public DataTable FilterGrade(string GradeCode) //NEW
    {
        string selectSTR = " SELECT  dbo.Lessons.LessonName,dbo.Grades.PupilID, ab.ExamDate, dbo.Grades.Grade ,( dbo.Users.UserFName+' '+ dbo.Users.UserLName) as TeacherName " +
                          "   FROM    dbo.Exams ab INNER JOIN  dbo.Grades ON dbo.Grades.ExamCode = ab.ExamCode INNER JOIN  " +
                          "     dbo.Users ON dbo.Grades.PupilID = dbo.Users.UserID  INNER JOIN   dbo.Pupil ON dbo.Users.UserID = dbo.Pupil.UserID INNER JOIN " +
                          "   dbo.Lessons ON ab.SubjectCode = dbo.Lessons.CodeLesson where ab.ExamCode='" + GradeCode + "' group by dbo.Lessons.LessonName,ab.ExamDate,dbo.Users.UserFName,dbo.Users.UserLName,dbo.Grades.PupilID ,dbo.Grades.Grade order by dbo.Grades.Grade asc  ";
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
            SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con);
            ds = new DataSet("GradeAvgDS");
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

    public DataTable FilterNotes(string FilterType, string ValueFilter, string teacherID)
    {
        string selectSTR = " SELECT  dbo.Pupil.UserID as 'תעודת זהות תלמיד' ,(dbo.Users.UserFName +' '+ dbo.Users.UserLName) as 'שם תלמיד' , dbo.NoteType.NoteName AS 'הערת משמעת', dbo.Lessons.LessonName AS 'שיעור', dbo.GivenNotes.NoteDate AS 'תאריך' ,dbo.GivenNotes.Comment AS 'הערת מורה'" +
                          " FROM  dbo.Users inner JOIN dbo.Pupil ON dbo.Users.UserID = dbo.Pupil.UserID inner JOIN dbo.GivenNotes " +
                          "ON dbo.Users.UserID = dbo.GivenNotes.PupilID  inner JOIN dbo.NoteType ON dbo.GivenNotes.CodeNoteType = dbo.NoteType.CodeNoteType  INNER JOIN  dbo.Lessons ON dbo.GivenNotes.LessonsCode = dbo.Lessons.CodeLesson " +
                          " where " + FilterType + "='" + ValueFilter + "' and dbo.GivenNotes.TeacherID = '" + teacherID + "'";
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
            SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con);
            ds = new DataSet("NotesDS");
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

    public DataTable FilterHomeWork(string TeacherID, string LessonsCode, string ClassCode)
    {
        string selectSTR = "SELECT HWCode as 'קוד שיעורים', IsLehagasha as 'האם השיעורים להגשה', HWDueDate AS 'תאריך סיום',HWInfo AS 'תוכן שיעורי הבית',HWGivenDate AS 'תאריך נתינת השיעורים'" +
                            " FROM dbo.HomeWork where  CodeClass = '" + ClassCode + "' and LessonsCode = '" + LessonsCode + "' and TeacherID = '" + TeacherID + "'";
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
            ds = new DataSet("HWDS");
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

    public DataTable GivenAllNotes(string PupilID) //webService
    {
        string selectSTR = " SELECT dbo.GivenNotes.CodeGivenNote, dbo.GivenNotes.Comment , dbo.GivenNotes.NoteDate , dbo.Lessons.LessonName , dbo.NoteType.NoteName ,(select ( UserFName+ ' '+ UserLName)  from dbo.Users where [UserID]= dbo.GivenNotes.TeacherID) as Teacher_FullName" +
                          " FROM  dbo.Users inner JOIN dbo.Pupil ON dbo.Users.UserID = dbo.Pupil.UserID inner JOIN dbo.GivenNotes " +
                          "ON dbo.Users.UserID = dbo.GivenNotes.PupilID  inner JOIN dbo.NoteType ON dbo.GivenNotes.CodeNoteType = dbo.NoteType.CodeNoteType  INNER JOIN  dbo.Lessons ON dbo.GivenNotes.LessonsCode = dbo.Lessons.CodeLesson " +
                          " where dbo.Pupil.UserID='" + PupilID + "'order by dbo.GivenNotes.NoteDate desc";
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
            ds = new DataSet("ALLNotesDS");
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

    public DataTable GivenNoteByCode(string NoteID) //webService
    {
        string selectSTR = " SELECT dbo.GivenNotes.Comment, dbo.GivenNotes.NoteDate, dbo.Lessons.LessonName, dbo.NoteType.NoteName, (dbo.Users.UserFName+' '+dbo.Users.UserLName)as TeacherName " +
                          " FROM  dbo.Users INNER JOIN dbo.GivenNotes ON dbo.Users.UserID = dbo.GivenNotes.TeacherID INNER JOIN dbo.NoteType " +
                          " ON dbo.GivenNotes.CodeNoteType = dbo.NoteType.CodeNoteType INNER JOIN  dbo.Lessons ON dbo.GivenNotes.LessonsCode = dbo.Lessons.CodeLesson " +
                          " where dbo.GivenNotes.CodeGivenNote='" + NoteID + "'";
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
            ds = new DataSet("OneNoteDS");
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

    public DataTable GetNotestype() //webService
    {
        string selectSTR = " select * from [dbo].[NoteType]";
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
            ds = new DataSet("NotetypeDS");
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

    public DataTable GivenHTByCode(string HWID) //webService
    {
        string selectSTR = " SELECT dbo.HomeWork.HWCode, dbo.HomeWork.HWInfo, dbo.HomeWork.HWGivenDate, dbo.Lessons.LessonName, dbo.HomeWork.HWDueDate, dbo.HomeWork.IsLehagasha, (dbo.Users.UserFName+' '+ dbo.Users.UserLName) as TeacherName " +
                          " FROM  dbo.HomeWork INNER JOIN dbo.Lessons ON dbo.HomeWork.LessonsCode = dbo.Lessons.CodeLesson INNER JOIN " +
                          " dbo.Users ON dbo.HomeWork.TeacherID = dbo.Users.UserID where dbo.HomeWork.HWCode='" + HWID + "'";
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
            ds = new DataSet("OneNoteDS");
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

    public DataTable FillAllHomeWork(string Id)//WebService  
    {
        string selectSTR = " SELECT dbo.HomeWork.HWCode,  dbo.HomeWork.HWInfo, dbo.HomeWork.HWGivenDate, dbo.Lessons.LessonName, dbo.HomeWork.HWDueDate, dbo.HomeWork.IsLehagasha ,(select(UserFName + ' ' + UserLName)  from dbo.Users where [UserID] = dbo.HomeWork.TeacherID) as Teacher_FullName , dbo.HWPupil.IsDone "+
                            " FROM  dbo.HomeWork INNER JOIN dbo.HWPupil ON dbo.HomeWork.HWCode = dbo.HWPupil.HWCode INNER JOIN  dbo.Lessons ON dbo.HomeWork.LessonsCode = dbo.Lessons.CodeLesson "+
                            " where dbo.HWPupil.PupilID = '"+ Id+ "'  and CAST(SUBSTRING(dbo.HomeWork.HWDueDate, 4, 2)+'/' + SUBSTRING(dbo.HomeWork.HWDueDate, 1, 2) + '/' + SUBSTRING(dbo.HomeWork.HWDueDate, 7, 4) AS DATE) > CONVERT(nvarchar(10), getdate(), 101) and dbo.HWPupil.IsDone = 0 order by CAST(SUBSTRING(dbo.HomeWork.HWDueDate, 4, 2)+'/'+SUBSTRING(dbo.HomeWork.HWDueDate, 1, 2) +'/'+SUBSTRING(dbo.HomeWork.HWDueDate, 7, 4) AS DATE) asc ";
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
            ds = new DataSet("HWDS");
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

    public DataTable FillAllHomeWork_history(string Id)//WebService 
    {
        string selectSTR = " SELECT dbo.HomeWork.HWCode,  dbo.HomeWork.HWInfo, dbo.HomeWork.HWGivenDate, dbo.Lessons.LessonName, dbo.HomeWork.HWDueDate, dbo.HomeWork.IsLehagasha ,(select ( UserFName+ ' '+ UserLName)  from dbo.Users where [UserID]= dbo.HomeWork.TeacherID) as Teacher_FullName , dbo.HWPupil.IsDone "+
                            " FROM dbo.HomeWork INNER JOIN dbo.HWPupil ON dbo.HomeWork.HWCode = dbo.HWPupil.HWCode INNER JOIN  dbo.Lessons ON dbo.HomeWork.LessonsCode = dbo.Lessons.CodeLesson "+
                          " where dbo.HWPupil.PupilID = '"+ Id+"'  and CAST(SUBSTRING(dbo.HomeWork.HWDueDate, 4, 2)+' /' + SUBSTRING(dbo.HomeWork.HWDueDate, 1, 2) + '/' + SUBSTRING(dbo.HomeWork.HWDueDate, 7, 4) AS DATE) < CONVERT(nvarchar(10), getdate(), 101) or dbo.HWPupil.IsDone = 1 order by CAST(SUBSTRING(dbo.HomeWork.HWDueDate, 4, 2) + '/' + SUBSTRING(dbo.HomeWork.HWDueDate, 1, 2) + '/' + SUBSTRING(dbo.HomeWork.HWDueDate, 7, 4) AS DATE) asc  ";
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
            ds = new DataSet("HWDS");
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

    public Dictionary<string, string> FillClassOtAccordingTeacherIdAndSubjectCode(string teacherID, string LessonCode)
    {
        string selectSTR = "SELECT  distinct  dbo.Class.ClassCode, dbo.Class.TotalName FROM dbo.TimetableLesson INNER " +
                           "JOIN dbo.Timetable ON dbo.TimetableLesson.TimeTableCode = dbo.Timetable.TimeTableCode INNER JOIN "+
                           "dbo.Class ON dbo.Timetable.ClassCode = dbo.Class.ClassCode AND dbo.Timetable.ClassCode = " +
                           "dbo.Class.ClassCode where dbo.TimetableLesson.TeacherId = '" + teacherID +
                           "' and dbo.TimetableLesson.CodeLesson = " + LessonCode + " order by dbo.Class.TotalName";

        Dictionary<string, string> classesAccordingTeacherIdAndSubjectCode = new Dictionary<string, string>();

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
                classesAccordingTeacherIdAndSubjectCode.Add(dr["ClassCode"].ToString(), dr["TotalName"].ToString());
            }
            return classesAccordingTeacherIdAndSubjectCode;
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

    public Dictionary<string, string> FillLessonsAccordingTeacherIdAndClassCode(string teacherID, string ClassCode)
    {
        string selectSTR = "SELECT distinct dbo.Lessons.CodeLesson, dbo.Lessons.LessonName FROM dbo.Lessons INNER " +
                           "JOIN dbo.TimetableLesson ON dbo.Lessons.CodeLesson = dbo.TimetableLesson.CodeLesson "+
                           "INNER JOIN dbo.Timetable ON dbo.TimetableLesson.TimeTableCode = dbo.Timetable.TimeTableCode " +
                           "where dbo.TimetableLesson.TeacherId = '" + teacherID + "' and dbo.Timetable.ClassCode = " + ClassCode;

        Dictionary<string, string> lessonsAccordingTeacherIdAndClassCode = new Dictionary<string, string>();

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
                string CodeLesson = dr["CodeLesson"].ToString();
                string LessonName = dr["LessonName"].ToString();
                lessonsAccordingTeacherIdAndClassCode.Add(dr["CodeLesson"].ToString(), dr["LessonName"].ToString());
            }
            return lessonsAccordingTeacherIdAndClassCode;
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

    public Dictionary<string, string> FillLessonsAccordingTeacherId(string teacherID)
    {
        string selectSTR = "SELECT  dbo.Lessons.CodeLesson, dbo.Lessons.LessonName FROM  dbo.Lessons " +
                           "INNER JOIN dbo.TeachersTeachesSubjects ON dbo.Lessons.CodeLesson = " +
                           "dbo.TeachersTeachesSubjects.CodeLessons where dbo.TeachersTeachesSubjects.TeacherID = '" + teacherID + "'";

        Dictionary<string, string> lessonsAccordingTeacherId = new Dictionary<string, string>();

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
                string CodeLesson = dr["CodeLesson"].ToString();
                string LessonName = dr["LessonName"].ToString();
                lessonsAccordingTeacherId.Add(dr["CodeLesson"].ToString(), dr["LessonName"].ToString());
            }
            return lessonsAccordingTeacherId;
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

    public Dictionary<string, string> FillClassOtAccordingTeacherId(string teacherID)
    {
        string selectSTR = "SELECT  distinct  dbo.Class.ClassCode, dbo.Class.TotalName FROM dbo.TimetableLesson " +
                           "INNER JOIN dbo.Timetable ON dbo.TimetableLesson.TimeTableCode = " +
                           "dbo.Timetable.TimeTableCode INNER JOIN dbo.Class ON dbo.Timetable.ClassCode = " +
                           "dbo.Class.ClassCode AND dbo.Timetable.ClassCode = dbo.Class.ClassCode where " +
                           "dbo.TimetableLesson.TeacherId = '" + teacherID + "' order by dbo.Class.TotalName";

        Dictionary<string, string> classesAccordingTeacherId = new Dictionary<string, string>();

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
                string CodeClass = dr["ClassCode"].ToString();
                string ClassName = dr["TotalName"].ToString();
                classesAccordingTeacherId.Add(dr["ClassCode"].ToString(), dr["TotalName"].ToString());
            }
            return classesAccordingTeacherId;
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

    public List<string> FillClassOtAccordingTeacherId_List(string teacherID)
    {
        string selectSTR = "SELECT  distinct  dbo.Class.TotalName FROM dbo.TimetableLesson " +
                           "INNER JOIN dbo.Timetable ON dbo.TimetableLesson.TimeTableCode = " +
                           "dbo.Timetable.TimeTableCode INNER JOIN dbo.Class ON dbo.Timetable.ClassCode = " +
                           "dbo.Class.ClassCode AND dbo.Timetable.ClassCode = dbo.Class.ClassCode where " +
                           "dbo.TimetableLesson.TeacherId = '" + teacherID + "'";

        List<string> classesAccordingTeacherId = new List<string>();

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
                classesAccordingTeacherId.Add(dr["TotalName"].ToString());
            }
            return classesAccordingTeacherId;
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

    public DataTable FillBySubjectHomeWork(string PupilID, string ChooseSubjectCode) //webService
    {
        string selectSTR = " SELECT dbo.HomeWork.HWGivenDate,(dbo.Users.UserFName+' ' +dbo.Users.UserLName) as TeacherName, dbo.Lessons.LessonName ,dbo.HomeWork.HWInfo, dbo.HomeWork.HWDueDate, dbo.HomeWork.IsLehagasha" +
                          " FROM  dbo.Users INNER JOIN dbo.HomeWork ON dbo.Users.UserID = dbo.HomeWork.TeacherID INNER JOIN  dbo.Lessons  " +
                          " ON dbo.HomeWork.LessonsCode = dbo.Lessons.CodeLesson " +
                          " where dbo.HomeWork.CodeClass= (select [CodeClass] from [dbo].[Pupil] where [UserID]='" + PupilID + "') and dbo.Lessons.CodeLesson='" + ChooseSubjectCode + "'";
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
            ds = new DataSet("ALLNotesDS");
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

    public DataTable GivenNotesBySubject(string PupilID, string ChooseSubjectCode) //webService
    {
        string selectSTR = " SELECT  dbo.GivenNotes.Comment , dbo.GivenNotes.NoteDate , dbo.Lessons.LessonName , dbo.NoteType.NoteName" +
                          " FROM  dbo.Users inner JOIN dbo.Pupil ON dbo.Users.UserID = dbo.Pupil.UserID inner JOIN dbo.GivenNotes " +
                          "ON dbo.Users.UserID = dbo.GivenNotes.PupilID  inner JOIN dbo.NoteType ON dbo.GivenNotes.CodeNoteType = dbo.NoteType.CodeNoteType  INNER JOIN  dbo.Lessons ON dbo.GivenNotes.LessonsCode = dbo.Lessons.CodeLesson " +
                          " where dbo.Pupil.UserID='" + PupilID + "' and dbo.GivenNotes.LessonsCode ='" + ChooseSubjectCode + "'";
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
            ds = new DataSet("NotesDS");
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

    public DataTable FilterTelphoneList(string UserTypeFilterType, string ClassFilter)
    {
        string selectSTR = "";
        if (UserTypeFilterType=="4") //pupil
        {
             selectSTR = "  SELECT  dbo.Users.PhoneNumber as 'מספר סלולרי', (dbo.Users.UserFName +' '+ dbo.Users.UserLName) as 'שם מלא' " +
                     " FROM dbo.Users full JOIN dbo.PupilsParent ON dbo.Users.UserID = dbo.PupilsParent.PupilID  AND dbo.Users.UserID = dbo.PupilsParent.ParentID Full JOIN" +
                     " dbo.Pupil ON dbo.Users.UserID = dbo.Pupil.UserID   where dbo.Users.CodeUserType='" + UserTypeFilterType + "'and dbo.Pupil.CodeClass='" + ClassFilter + "'";
        }
        else //parent -> 3
        {
             selectSTR = "SELECT dbo.Users.PhoneNumber  as 'מספר סלולרי',( dbo.Users.UserFName+' '+ dbo.Users.UserLName) as 'שם הורה'" +
                                " FROM dbo.PupilsParent INNER JOIN dbo.Users ON dbo.PupilsParent.ParentID = dbo.Users.UserID"+
                                " where dbo.PupilsParent.codeClass = '"+ ClassFilter + "'";
        }

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
            ds = new DataSet("TelephoneNumDS");
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

    public DataTable FilterTelphoneListForMobile(string UserTypeFilterType, string ClassFilter) //newwwwwwwwww
    {
        string selectSTR = "";
        

        if (UserTypeFilterType == "4") //pupil
        {
            selectSTR = "  SELECT  dbo.Users.PhoneNumber, (dbo.Users.UserFName +' '+ dbo.Users.UserLName) as 'FullName' " +
                   " FROM dbo.Users full JOIN dbo.PupilsParent ON dbo.Users.UserID = dbo.PupilsParent.PupilID  AND dbo.Users.UserID = dbo.PupilsParent.ParentID Full JOIN" +
                   " dbo.Pupil ON dbo.Users.UserID = dbo.Pupil.UserID   where dbo.Users.CodeUserType='" + UserTypeFilterType+"' ";
            if (ClassFilter.Length > 7)//teacher 
            {

                selectSTR += " and dbo.Pupil.CodeClass in (select distinct  dbo.Timetable.ClassCode FROM  dbo.Timetable INNER JOIN " +
                            "  dbo.TimetableLesson ON dbo.Timetable.TimeTableCode = dbo.TimetableLesson.TimeTableCode where dbo.TimetableLesson.TeacherId = '" + ClassFilter + "')";
            }
            else
            {
                selectSTR += "and dbo.Pupil.codeClass = '" + ClassFilter + "'";
            }
        }
        else if (UserTypeFilterType == "3")//parent 
        {
            selectSTR = "SELECT distinct dbo.Users.PhoneNumber,( dbo.Users.UserFName+' '+ dbo.Users.UserLName) as 'FullName'" +
                               " FROM dbo.PupilsParent INNER JOIN dbo.Users ON dbo.PupilsParent.ParentID = dbo.Users.UserID where dbo.PupilsParent.codeClass";

            if (ClassFilter.Length > 7)//teacher 
            {

                selectSTR += " in (select distinct  dbo.Timetable.ClassCode FROM  dbo.Timetable INNER JOIN " +
                            " dbo.TimetableLesson ON dbo.Timetable.TimeTableCode = dbo.TimetableLesson.TimeTableCode where dbo.TimetableLesson.TeacherId = '" + ClassFilter + "')";
            }
            else
            {
                selectSTR += "  = '" + ClassFilter + "'";
            }
        }

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
            ds = new DataSet("TelephoneNumDS");
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

    public string GetUserType(string UserID, string password)
    {
        String selectSTR = "SELECT CodeUserType  FROM Users where UserID  = '" + UserID + "' and LoginPassword  = '" + password + "'";
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

    public List<string> GetUserInfo(string UserID)
    {
        string UserFName, UserLName, BirthDate, UserImg, UserName, UserPassword, PhoneNumber;
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
                UserFName = dr["UserFName"].ToString();
                UserInfo.Add(UserFName);
                UserLName = dr["UserLName"].ToString();
                UserInfo.Add(UserLName);
                BirthDate = dr["BirthDate"].ToString();
                UserInfo.Add(BirthDate);
                UserName = dr["LoginName"].ToString();
                UserInfo.Add(UserName);
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

    public int ChangePassword(string userID, string Password)
    {
        string cStr = "update[dbo].[Users] set[LoginPassword] = ('" + Password + "') WHERE UserID = '" + userID + "'";
        return ExecuteNonQuery(cStr);
    }
    public int InsertGrade(string PupilID, int ExamCode, int Grade)
    {
        string cStr = "INSERT INTO [dbo].[Grades] (ExamCode, PupilID, [Grade]) VALUES ('"+ ExamCode + "','"+ PupilID + "',"+ Grade + ")";
        return ExecuteNonQuery(cStr);
    }

    public Dictionary<string, string> FillNotes()
    {
        String selectSTR = "SELECT CodeNoteType,NoteName FROM NoteType ";
        string CodeNoteType, NoteName;
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
                    CodeNoteType = dr["CodeNoteType"].ToString();
                    NoteName = dr["NoteName"].ToString();
                    l.Add(CodeNoteType, NoteName);
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

    public int InsertNotes(string PupilID, string CodeNoteType, string NoteDate, string TeacherID, string LessonsCode, string Comment)
    {
        string contentToHtml = Comment.Replace("\n", "<br />");
        string tipulBeGeresh = contentToHtml.Replace("'", "''");

        string cStr = "INSERT INTO [dbo].[GivenNotes]  ([PupilID] ,[CodeNoteType],[NoteDate],[TeacherID],[LessonsCode],[Comment])   VALUES ('" + PupilID + "','" + CodeNoteType + "','" + NoteDate + "' ,'" + TeacherID + "' ,'" + LessonsCode + "','" + tipulBeGeresh + "')";
        return ExecuteNonQuery(cStr);
    }

    public int HWDone(string PupilID, bool IsDone, string HWCode)
    {
        int Done = 0;
        if (IsDone)
        {
            Done = 1;
        }
        string cStr = "UPDATE [dbo].[HWPupil] SET [IsDone] =" + Done + " where HWCode= " + HWCode + " and PupilID ='" + PupilID + "'";
        return ExecuteNonQuery(cStr);
    }

    public int InserHomeWork(string LessonsCode, string HWInfo, string TeacherID, string CodeClass, string HWDate, bool IsLehagasha, string GivenDate)
    {
        int num = 0;
        string contentToHtml = HWInfo.Replace("\n", "<br />");
        string tipulBeGeresh = contentToHtml.Replace("'", "''");
        try
        {
            using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Betsefer"].ConnectionString))
            {
                using (var cmd = new SqlCommand("InsertHomeWork", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LessonsCode", LessonsCode);
                    cmd.Parameters.AddWithValue("@HWInfo", tipulBeGeresh);
                    cmd.Parameters.AddWithValue("@GivenDate", GivenDate);
                    cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
                    cmd.Parameters.AddWithValue("@CodeClass", CodeClass);
                    cmd.Parameters.AddWithValue("@WDate", HWDate);
                    cmd.Parameters.AddWithValue("@IsLehagasha", IsLehagasha);

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

    public Dictionary<string, string> FillLessons()
    {
        String selectSTR = "SELECT CodeLesson, LessonName from Lessons";
        string CodeLesson, LessonName;
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
                l.Add("0", "בחר מקצוע");
                while (dr.Read())
                {
                    CodeLesson = dr["CodeLesson"].ToString();
                    LessonName = dr["LessonName"].ToString();
                    l.Add(CodeLesson, LessonName);
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

    public int GetMainTeacherClass(string id)
    {
        String selectSTR = "SELECT ClassCode FROM Class where MainTeacherID  = '" + id + "'";
        int classCode = -1;
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
                classCode = int.Parse(dr[0].ToString());
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
            // write to log
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

    public string GiveNoteCodeByNoteName(string NoteName)
    {
        String selectSTR = "select CodeNoteType from [dbo].[NoteType] where NoteName=  '" + NoteName + "'";
        string subjectCode = "";
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
                subjectCode = dr[0].ToString();
            }
            return subjectCode;
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

    public string GetSubjectCodeBySubjectName(string subjectName)
    {
        String selectSTR = "SELECT CodeLesson FROM Lessons where LessonName  = '" + subjectName + "'";
        string subjectCode = "";
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
                subjectCode = dr[0].ToString();
            }
            return subjectCode;
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

    public bool IfMehanech(string UserId)
    {
        String selectSTR = "SELECT IsMainTeacher FROM Teachers where TeacherID  = '" + UserId + "'";
        bool mehanech = false;
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
                mehanech = bool.Parse(dr[0].ToString());
            }
            return mehanech;
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

    public int GetClassCodeByMainTeacherID(string teacherID)
    {
        String selectSTR = "SELECT ClassCode FROM Class where MainTeacherID  = '" + teacherID + "'";
        int classCode = 0;
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
                classCode = int.Parse(dr[0].ToString());
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

    public List<Meeting> GetMeetingsByParentsDayCode(int ParentsDayCode)
    {
        List<Meeting> meetings = new List<Meeting>();

        String selectSTR = "SELECT * FROM ParentsDayMeeting where ParentsDayCode  = " + ParentsDayCode;

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
            DBconnection db = new DBconnection();
            while (dr.Read())
            {
                Meeting m = new Meeting();
                m.MeetingCode = dr["MeetingCode"].ToString();
                m.PupilID = dr["PupilID"].ToString();
                m.PupilName = db.GetUserFullNameByID(m.PupilID);
                m.StartTime = dr["StartTime"].ToString();
                m.EndTime = dr["EndTime"].ToString();

                meetings.Add(m);
            }
            return meetings;
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

    public ParentsDay LoadParentDay(string UserId)
    {
        ParentsDay p = null;

        if (!IfMehanech(UserId)) // not mehanech
        {
            return p;
        }

        p = new ParentsDay();
        p.TeacherID = UserId;
        p.ClassCode = GetClassCodeByMainTeacherID(UserId);

        String selectSTR = "SELECT * FROM ParentsDay where ClassCode  = '" + p.ClassCode + "' and ParentsDayDate >= (convert(nvarchar(10), SYSDATETIME(), 103))";

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
            DBconnection db = new DBconnection();
            while (dr.Read())
            {
                p.ParentsDayCode = int.Parse(dr["ParentsDayCode"].ToString());
                p.ClassCode = int.Parse(dr["ClassCode"].ToString());
                p.ClassName = db.GetClassNameByCodeClass(p.ClassCode);
                p.CodeWeekDay = int.Parse(dr["CodeWeekDay"].ToString());
                p.ParentsDayDate = dr["ParentsDayDate"].ToString();
                
            }
            p.ParentsDayMeetings = GetMeetingsByParentsDayCode(p.ParentsDayCode);
            return p;
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

    public ParentsDay Parent_LoadParentDay(string PupilID)
    {
        ParentsDay p = null;
        DBconnection db = new DBconnection();

        p = new ParentsDay();
        p.ClassCode = int.Parse(db.GetClassCodeByPupilId(PupilID));

        String selectSTR = "SELECT * FROM ParentsDay where ClassCode  = '" + p.ClassCode + "' and ParentsDayDate >= (convert(nvarchar(10), SYSDATETIME(), 103))";

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
                p.ParentsDayCode = int.Parse(dr["ParentsDayCode"].ToString());
                p.ClassName = db.GetClassNameByCodeClass(p.ClassCode);
                p.CodeWeekDay = int.Parse(dr["CodeWeekDay"].ToString());
                p.WeekDayName = GetWeekDayNameByCode(p.CodeWeekDay);
                p.ParentsDayDate = dr["ParentsDayDate"].ToString();
                p.TeacherID = dr["TeacherID"].ToString();
                p.TeacherName = db.GetTeacherNameByID(p.TeacherID);

            }
            p.ParentsDayMeetings = GetMeetingsByParentsDayCode(p.ParentsDayCode);
            return p;
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

    public string GetWeekDayNameByCode(int CodeWeekDay)
    {
        String selectSTR = "SELECT WeekDayName FROM WeekDays where CodeWeekDay  = " + CodeWeekDay;

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
            string weekDayName = "";
            while (dr.Read())
            {
                weekDayName = dr["WeekDayName"].ToString();
            }
            return weekDayName;
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

    public int GetParentsDayCodeByDateAndTeacherID(string ParentsDayDate, string TeacherID)
    {
        int parentsDayCode = -1;

        String selectSTR = "SELECT ParentsDayCode FROM ParentsDay where ParentsDayDate  = '" +
            ParentsDayDate + "' and TeacherID = '"+ TeacherID + "'";

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
            DBconnection db = new DBconnection();
            while (dr.Read())
            {
                int.TryParse(dr["ParentsDayCode"].ToString(), out parentsDayCode);
            }
            return parentsDayCode;
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

    public int SaveParentsDay(ParentsDay p)
    {
        DBconnection db = new DBconnection();
        p.CodeWeekDay = db.GetCodeWeekDayByDate(p.ParentsDayDate);
        p.ClassCode = GetClassCodeByMainTeacherID(p.TeacherID);

        String insertSTR = "insert into ParentsDay(CodeWeekDay, ParentsDayDate, TeacherID, ClassCode) "+
            "values("+ p.CodeWeekDay +",'"+ p.ParentsDayDate +"','"+ p.TeacherID +"',"+ p.ClassCode +")";

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
            int answerParentsDayTable = ExecuteNonQuery(insertSTR);

            int parentsDayCode = GetParentsDayCodeByDateAndTeacherID(p.ParentsDayDate, p.TeacherID);

            DateTime from = DateTime.Parse(p.from), to;
            insertSTR = "";
            while (from < DateTime.Parse(p.to)) //add less long meeting to stay in range.
            {
                to = from.AddMinutes((double)p.longMeeting);
                insertSTR += " insert into ParentsDayMeeting (TeacherID, ParentsDayCode, StartTime, EndTime) " +
                    "values ('" + p.TeacherID + "', " + parentsDayCode + ", '" + from.ToShortTimeString() + "', '" + to.ToShortTimeString() + "')";
                from = from.AddMinutes((double)p.longMeeting);
            }

            int answerParentsDayMeetingsTable = ExecuteNonQuery(insertSTR);
            return answerParentsDayTable + answerParentsDayMeetingsTable; // should be bigger than two. maybe i should know the number of meetings and check if it is OK
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

    public string GiveMeBreak(string ParentsDayMeeting)
    {

        string num = "";
        try
        {
            using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Betsefer"].ConnectionString))
            {
                using (var cmd = new SqlCommand("UpdateMeeting", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PupilID", 0);
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

    public int DeleteBreak(string ParentsDayMeeting)
    {
        string cStr = "UPDATE ParentsDayMeeting SET PupilID = null WHERE MeetingCode = '"+ ParentsDayMeeting + "'";
        return ExecuteNonQuery(cStr);
    }

    public DataTable getHwInfoForProgBar(string Id)//WebService
    {
        string selectSTR =" SELECT  count(dbo.HomeWork.HWCode) as 'Made_HW', (select count(dbo.HomeWork.HWCode) "+
                         " FROM dbo.HomeWork INNER JOIN dbo.HWPupil ON dbo.HomeWork.HWCode = dbo.HWPupil.HWCode INNER JOIN  dbo.Lessons ON dbo.HomeWork.LessonsCode = dbo.Lessons.CodeLesson "+
                        " where dbo.HWPupil.PupilID = '"+ Id+"'  and CAST(SUBSTRING(dbo.HomeWork.HWDueDate, 4, 2)+' /' + SUBSTRING(dbo.HomeWork.HWDueDate, 1, 2) + '/' + SUBSTRING(dbo.HomeWork.HWDueDate, 7, 4) AS DATE)> CONVERT(datetime, getdate(), 101)) as 'total_HW' " +
                         " FROM dbo.HomeWork INNER JOIN dbo.HWPupil ON dbo.HomeWork.HWCode = dbo.HWPupil.HWCode INNER JOIN  dbo.Lessons ON dbo.HomeWork.LessonsCode = dbo.Lessons.CodeLesson "+
                        " where dbo.HWPupil.PupilID = '"+ Id+"'  and CAST(SUBSTRING(dbo.HomeWork.HWDueDate, 4, 2)+' /' + SUBSTRING(dbo.HomeWork.HWDueDate, 1, 2) + '/' + SUBSTRING(dbo.HomeWork.HWDueDate, 7, 4) AS DATE)> CONVERT(datetime, getdate(), 101) and dbo.HWPupil.IsDone = 1";



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

    public List<Grades> LoadTestsByTeacherID(string teacherId)
    {
        string selectSTR = "select ExamCode, ExamDate, ClassCode, SubjectCode from Exams where " +
            "TeacherID = '" + teacherId + "' order by ExamDate desc";

        List<Grades> tests = new List<Grades>();

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
            DBconnection db = new DBconnection();
            while (dr.Read())
            {
                Grades g = new Grades();
                g.examCode = int.Parse(dr["ExamCode"].ToString());
                g.date = dr["ExamDate"].ToString();
                g.classID = int.Parse(dr["ClassCode"].ToString());
                g.subjectCode = dr["SubjectCode"].ToString();

                tests.Add(g);
            }
            return tests;
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

    public int InserExam(string examDate, string teacherID, int classCode, string lessonCode)
    {
        string cStr = "INSERT INTO [dbo].[Exams] ([ExamDate] ,[TeacherID],[ClassCode],[SubjectCode]) "+
            " VALUES ('" + examDate + "','" + teacherID + "','" + classCode + "' ,'" + lessonCode + "')";
        return ExecuteNonQuery(cStr);
    }

    public int GetLastExamCode()
    {
        string selectSTR = "select max(ExamCode) from Exams";

        int examCode = 0;

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
            DBconnection db = new DBconnection();
            while (dr.Read())
            {
                examCode = int.Parse(dr[0].ToString());
            }
            return examCode;
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

    
    public List<Grades> GetAllGradesByExamCode(string examCode)
    {
        string selectSTR = "select [PupilID], [Grade] from [dbo].[Grades] where [ExamCode] = '" + examCode + "'";

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
            List<Grades> grades = new List<Grades>();

            while (dr.Read())
            {
                Grades g = new Grades();
                g.pupilID = dr["PupilID"].ToString();
                g.grade = int.Parse(dr["Grade"].ToString());
                g.pupilName = db.GetUserFullNameByID(g.pupilID);

                grades.Add(g);
            }
            return grades;
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

    public int SaveTeachersToSubject(List<string> teachersSubject, string newSubject)
    {
        string cStr = ""; 

        foreach (var item in teachersSubject)
        {
            cStr += "INSERT INTO [dbo].[TeachersTeachesSubjects] ([TeacherID] ,[CodeLessons]) " +
            " VALUES ('"+ item + "', '" + newSubject + "'); ";
        }
        return ExecuteNonQuery(cStr);
    }

    public Dictionary<string,string> GetPupilIdWhiceDidntMakeHWYet()
    {

        string selectSTR = "SELECT  PupilID,LessonName, dbo.Users.PushRegID FROM    dbo.HomeWork INNER JOIN    dbo.HWPupil ON dbo.HomeWork.HWCode = dbo.HWPupil.HWCode INNER JOIN "+
                            " dbo.Lessons ON dbo.HomeWork.LessonsCode = dbo.Lessons.CodeLesson  INNER JOIN dbo.Users ON  dbo.HWPupil.PupilID = dbo.Users.UserID where IsDone = 0 "+
                            " and HWDueDate = CONVERT(nvarchar, GETDATE() + 1, 103)  and dbo.Users.PushRegID != 'null' ";

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
            Dictionary<string, string> PupilsId = new Dictionary<string, string>();
            string ID, LessonName, RegId;
            while (dr.Read())
            {
              //  ID = dr["LessonName"].ToString();
                LessonName = dr["LessonName"].ToString();
                RegId = dr["PushRegID"].ToString();
                PupilsId.Add( LessonName, RegId);
            }
            return PupilsId;
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

    public List<string> GetNoteByMonth(string teacherID)
    {
        string selectSTR = "select count(CodeGivenNote) as 'amountsOfNotes', SUBSTRING(GivenNotes.NoteDate, 4, 2) as 'monthDate' " +
                        "from GivenNotes " +
                        "where TeacherID = '"+ teacherID + "' " +
                        "group by SUBSTRING(GivenNotes.NoteDate, 4, 2) " +
                        "order by SUBSTRING(GivenNotes.NoteDate, 4, 2) "; 
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
            List<string> noteAmounts = new List<string>();
            List<string> noteMonth = new List<string>();

            while (dr.Read())
            {
                noteAmounts.Add(dr["amountsOfNotes"].ToString());
                noteMonth.Add(dr["monthDate"].ToString());
            }

            for (int i = 0; i < noteAmounts.Count; i++)
            {
                noteMonth.Add(noteAmounts[i]);
            }
            return noteMonth;
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

    public List<string> GetAvgByClasses(string teacherID)
    {
        string selectSTR = "SELECT dbo.Class.TotalName+' - '+ dbo.Lessons.LessonName as 'TotalDesc', AVG( dbo.Grades.Grade) " +
                "as AvgGradeClass FROM dbo.Exams INNER JOIN   dbo.Grades ON dbo.Exams.ExamCode = dbo.Grades.ExamCode " +
                "INNER JOIN dbo.Lessons ON dbo.Exams.SubjectCode = dbo.Lessons.CodeLesson INNER JOIN  dbo.Class ON " +
                "dbo.Exams.ClassCode = dbo.Class.ClassCode where dbo.Exams.TeacherID ='989898988' group by dbo.Class.TotalName, " +
                "dbo.Lessons.LessonName";
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
            List<string> gradeAvg = new List<string>();
            List<string> classes = new List<string>();

            while (dr.Read())
            {
                classes.Add(dr["TotalDesc"].ToString());
                gradeAvg.Add(dr["AvgGradeClass"].ToString());
            }

            for (int i = 0; i < gradeAvg.Count; i++)
            {
                classes.Add(gradeAvg[i]);
            }
            return classes;
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