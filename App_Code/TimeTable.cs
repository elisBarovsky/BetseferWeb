using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeTable
/// </summary>
public class TimeTable
{
    DBconnection db = new DBconnection();

    public TimeTable()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertTimeTable(string date, int classCode,bool publish)
    {
        return db.InsertTimeTable(date, classCode, publish);
    }

    public int InsertTempTimeTable(string date, int CodeWeekDay, int ClassTimeCode, int CodeLesson, string TeacherId, int ClassNum)
    {
        return db.InsertTempTimeTable(date, CodeWeekDay, ClassTimeCode, CodeLesson, TeacherId, ClassNum);
    }

    public List<string> GetCellInfo(string date, int WeekDay,int LessonNum, int ClassNmum)
    {
        return db.GetCellInfo(date, WeekDay, LessonNum, ClassNmum);
    }

    public List<Dictionary<string, string>> GetTimeTableAcordingToClassCode(int classCode)
    {
        return db.GetTimeTableAcordingToClassCode(classCode);
    }

    public List<Dictionary<string, string>> GetTimeTableAcordingToClassCodeForMobile(int classCode)
    {
        return db.GetTimeTableAcordingToClassCodeForMobile(classCode);
    }

    public bool IsClassHasTimeTable(string classCodee)
    {
        return db.IsClassHasTimeTable(classCodee);
    }

    public int DeleteTimeTableLessons(string classCode)
    {
        return db.DeleteTimeTableLessons(classCode);
    }

    public int DeleteTimeTable(string classCode)
    {
        return db.DeleteTimeTable(classCode);
    }

    public int DeleteTempTT(string date, string classcode)
    {
        return db.DeleteTempTT(date, classcode);
    }

    public string GetLessonNameByLessonCode(string lessonCode)
    {
        return db.GetLessonNameByLessonCode(lessonCode);
    }
}