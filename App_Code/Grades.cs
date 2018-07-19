using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Grades
/// </summary>
public class Grades
{
    DBconnectionTeacher dbT;
    DBconnection db;
    string subject;
    string date;
    string teacherID;
    string pupilID;
    int grade;
    int classID;

    public Grades()
    {
        dbT = new DBconnectionTeacher();
        db = new DBconnection();
    }

    public Grades(string _subject, string _date, string _teacherID, string _pupilID, int _grade, int _classID)
    {
        subject = _subject;
        date = _date;
        teacherID = _teacherID;
        pupilID = _pupilID;
        grade = _grade;
        classID = _classID;
    }

    public Dictionary<string, string> FillClassOt()
    {
        return db.FillClassOt();
    }

    public Dictionary<string, string> FillLessons()
    {
        return dbT.FillLessons();
    }

    public DataTable PupilList(string ClassOtID)
    {
        return dbT.PupilList(ClassOtID);
    }

    public int InsertGrade(string PupilID, string TeacherID, string CodeLesson, string ExamDate, int Grade, int ClassId)
    {
        return dbT.InsertGrade(PupilID, TeacherID, CodeLesson, ExamDate, Grade, ClassId);
    }

    public DataTable PupilGrades(string PupilID) // NEW !!!!
    {
        return dbT.PupilGrades(PupilID);
    }

    public DataTable FilterGrade(string GradeDate)  // NEW !
    {
        return dbT.FilterGrade(GradeDate);
    }

    public DataTable PupilAvgGrades(string ClassCode) // NEW !!!!
    {
        return dbT.PupilAvgGrades(ClassCode);
    }

    public int InsertGradesAfterAdjustTheDetails(List<Object> pupilGrade)
    {
        List<Grades> grades = new List<Grades>();

        for (int i = 0; i < pupilGrade.Count; i++)
        {// lo oved offfff

            Dictionary<System.String, System.Object> y = (Dictionary<System.String, System.Object>)pupilGrade[i];

            Grades g = new Grades();
            g.subject = y["subject"].ToString();
            g.teacherID = y["teacherID"].ToString();
            g.pupilID = y["pupilID"].ToString();
            g.grade = int.Parse(y["grade"].ToString());
            g.date = y["date"].ToString();
            g.classID = int.Parse(db.GetClassCodeByPupilId(g.pupilID));
            grades.Add(g);
        }

        string lessonCode = db.GetLessonCodeByLessonName(grades[0].subject);
        int counter = 0;
        for (int i = 0; i < pupilGrade.Count; i++)
        {
            counter += InsertGrade(grades[i].pupilID, grades[i].teacherID, lessonCode, grades[i].date, grades[i].grade, grades[i].classID);
        }
        if (counter == grades.Count)
        {
            return 1;
        }
        return 0;
    }
}