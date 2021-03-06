﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Teacher
/// </summary>
public class Teacher : Users
{
    DBconnection db = new DBconnection();
    DBconnectionTeacher dbt = new DBconnectionTeacher();

    public string classMainTeacher { get; set; }
    public bool isMainTeacher { get; set; }

    public Teacher()
    {
        //i need to check what returns when this is not a main teacher if null or zero or something.

        classMainTeacher = db.IsAlreadyMainTeacher(this.UserID1).FirstOrDefault();
        if (classMainTeacher != null) isMainTeacher = true;
        else isMainTeacher = false;
    }

    public Dictionary<string, string> FillClassOtAccordingTeacherIdAndSubjectCode(string teacherID, string LessonCode)
    {
        Dictionary<string, string> d = new Dictionary<string, string>();

        return dbt.FillClassOtAccordingTeacherIdAndSubjectCode(teacherID, LessonCode);
    }

    public Dictionary<string, string> FillLessonsAccordingTeacherIdAndClassCode(string teacherID, string classCode)
    {
        Dictionary<string, string> d = new Dictionary<string, string>();

        return dbt.FillLessonsAccordingTeacherIdAndClassCode(teacherID, classCode);
    }

    public Dictionary<string, string> FillLessonsAccordingTeacherId(string teacherID)
    {
        Dictionary<string, string> d = new Dictionary<string, string>();

        return dbt.FillLessonsAccordingTeacherId(teacherID);
    }


    public Dictionary<string, string> FillClassOtAccordingTeacherId(string teacherID)
    {
        Dictionary<string, string> d = new Dictionary<string, string>();

        return dbt.FillClassOtAccordingTeacherId(teacherID);
    }

    public List<string> FillClassOtAccordingTeacherId_List(string teacherID)
    {
        Dictionary<string, string> d = new Dictionary<string, string>();

        return dbt.FillClassOtAccordingTeacherId_List(teacherID);
    }

    public Dictionary<string, string> FillClassOtAccordingTeacherIdAndSubject(string teacherID, string Lesson)
    {
        string lessonCode = db.GetLessonCodeByLessonName(Lesson);
        return FillClassOtAccordingTeacherIdAndSubjectCode(teacherID, lessonCode);
    }

    public List<string> GetNoteByMonth(string teacherID)
    {
        return dbt.GetNoteByMonth(teacherID);
    }

    public List<string> GetAvgByClasses(string teacherID)
    {
        return dbt.GetAvgByClasses(teacherID);
    }
    
}