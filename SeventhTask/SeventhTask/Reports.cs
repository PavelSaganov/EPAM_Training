using Microsoft.Office.Interop.Excel;
using SeventhTask.Models;
using SeventhTask.WorkWithDB;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace SeventhTask
{
    public class Reports
    {
        /// <summary>
        /// Creates an explusion list in student list
        /// </summary>
        /// <param name="students"></param>
        /// <returns></returns>
        public static List<Student> CreateExpulsionList(Group group)
        {
            List<ExamResult> examResults = ((Table<ExamResult>)CRUD.Read<ExamResult>()).ToList();
            List<Student> students = ((Table<Student>)CRUD.Read<Student>()).ToList().Where(s => s.GroupId == group.GroupId).ToList();
            List<Student> result = new List<Student>();
            foreach (var st in students)
            {
                if (examResults.Where(e => e.StudentId == st.StudentId).Count(e => e.Mark < 4) >= 3)
                    result.Add(st);
            }

            return result.Distinct().ToList();
        }

        /// <summary>
        /// Writes Session result to excel file
        /// </summary>
        /// <param name="session"></param>
        /// <param name="path">Path to file</param>
        public static void WriteExcelSessionResult(Session session, string path)
        {
            Application excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;

            List<PartialCreditResult> partialCreditResults = ((Table<PartialCreditResult>)CRUD.Read<PartialCreditResult>()).ToList();
            List<Exam> exams = ((Table<Exam>)CRUD.Read<Exam>()).ToList().Where(e => e.SessionId == session.SessionId).ToList();
            List<Group> groups = new List<Group>();

            foreach (var g in ((Table<Group>)CRUD.Read<Group>()).ToList())
            {
                exams.ForEach(e => { if (e.GroupId == g.GroupId) groups.Add(g); });
            }
            groups.Distinct();

            workSheet.Cells[1, "A"] = "Group/Name";

            int colNumb = 2;
            foreach (var ex in exams)
            {
                workSheet.Cells[1, GetDictionary()[colNumb]] = ex.ExamName;
                colNumb++;
            }

            int rowNumb = 1;
            foreach (var g in groups)
            {
                rowNumb++;
                workSheet.Cells[rowNumb, "A"] = $"{ g.GroupName }";
                rowNumb++;

                List<Student> students = ((Table<Student>)CRUD.Read<Student>()).ToList().Where(s => s.GroupId == g.GroupId).ToList();
                foreach (var st in students)
                {
                    workSheet.Cells[rowNumb, "A"] = $"{ st.FirstName } { st.SecondName } { st.Surname }";
                    List<ExamResult> examResults = ((Table<ExamResult>)CRUD.Read<ExamResult>()).ToList().Where(er => er.StudentId == st.StudentId).ToList();
                    colNumb = 2;
                    foreach (var ex in examResults)
                    {
                        workSheet.Cells[rowNumb, GetDictionary()[colNumb]] = $"{ ex.Mark }";
                        colNumb++;
                    }
                    rowNumb++;
                }
            }

            workBook.Close(true, path);
            excelApp.Quit();
        }

        /// <summary>
        /// Writes a max, min and average marks for each group
        /// </summary>
        /// <param name="session"></param>
        /// <param name="path">Path to file</param>
        public static void WriteExcelMaxAverageMin(Session session, string path)
        {
            Application excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;
            int colNumb = 1;

            workSheet.Cells[colNumb, "A"] = "Session";
            workSheet.Cells[colNumb, "B"] = "Group";
            workSheet.Cells[colNumb, "C"] = "Max Mark";
            workSheet.Cells[colNumb, "D"] = "Average mark";
            workSheet.Cells[colNumb, "E"] = "Min Mark";

            foreach (var item in ((Table<Group>)CRUD.Read<Group>()).ToList())
            {
                colNumb++;
                workSheet.Cells[colNumb, "A"] = $"{ session.StartDate } - { session.EndDate }";
                workSheet.Cells[colNumb, "B"] = item.GroupName;
                workSheet.Cells[colNumb, "C"] = GetMaxMark(item);
                workSheet.Cells[colNumb, "D"] = GetAverageMark(item);
                workSheet.Cells[colNumb, "E"] = GetMinMark(item);
            }

            workBook.Close(true, path);
            excelApp.Quit();
        }

        /// <summary>
        /// Writes average mark of specialties in a session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="path">Path to file</param>
        public static void WriteExcelAverageOnSpeciality(Session session, string path)
        {
            Application excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;

            workSheet.Cells[1, "A"] = "Session";
            workSheet.Cells[1, "B"] = "Speciality";
            workSheet.Cells[1, "C"] = "AverageMark";

            List<Group> allGroups = ((Table<Group>)CRUD.Read<Group>()).ToList();

            int rowNumb = 2;
            workSheet.Cells[rowNumb, "A"] = $"{ session.StartDate } - { session.EndDate }";

            foreach (var spec in ((Table<Speciality>)CRUD.Read<Speciality>()).ToList())
            {
                workSheet.Cells[rowNumb, "B"] = spec.SpecialityName;
                List<Group> groupsOfSpeciality = allGroups.Where(g => g.SpecialityId == spec.SpecialityId).ToList();
                workSheet.Cells[rowNumb, "C"] = groupsOfSpeciality.Average(g => GetAverageMark(g));
                rowNumb++;
            }

            workBook.Close(true, path);
            excelApp.Quit();
        }

        /// <summary>
        /// Writes average mark of examiners in a session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="path">Path to file</param>
        public static void WriteExcelAverageByExaminer(Session session, string path)
        {
            Application excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;

            workSheet.Cells[1, "A"] = "Session";
            workSheet.Cells[1, "B"] = "Examiner";
            workSheet.Cells[1, "C"] = "AverageMark";

            List<Group> allGroups = ((Table<Group>)CRUD.Read<Group>()).ToList();
            int rowNumb = 2;
            workSheet.Cells[rowNumb, "A"] = $"{ session.StartDate } - { session.EndDate }";

            foreach (var ex in ((Table<Examiner>)CRUD.Read<Examiner>()).ToList())
            {
                workSheet.Cells[rowNumb, "B"] = ex.ExaminerName;

                List<Exam> examsOfExaminer = ((Table<Exam>)CRUD.Read<Exam>()).ToList().Where(e => e.ExaminerId == ex.ExaminerId).ToList();
                List<ExamResult> examResultsOfExaminer = new List<ExamResult>();
                foreach (var ee in examsOfExaminer)
                {
                    ExamResult examR;
                    if ((examR = ((Table<ExamResult>)CRUD.Read<ExamResult>()).ToList().FirstOrDefault(e => e.ExamId == ee.ExamId)) != null)
                        examResultsOfExaminer.Add(examR);
                }

                workSheet.Cells[rowNumb, "C"] = examResultsOfExaminer.Average(e => e.Mark);
                rowNumb++;
            }

            workBook.Close(true, path);
            excelApp.Quit();
        }

        /// <summary>
        /// Writes changes of average mark by the yearss
        /// </summary>
        /// <param name="path"></param>
        public static void WriteExcelChangesOfAverageMark(string path)
        {
            Application excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;

            int rowNumb = 3;
            int colNumb = 2;
            List<Exam> allExams = ((Table<Exam>)CRUD.Read<Exam>()).ToList();
            var a = allExams.GroupBy(ae => ae.ExamName);

            workSheet.Cells[1, "A"] = "Year";
            workSheet.Cells[2, "A"] = "Session";

            List<Exam> sameExams = new List<Exam>();
            foreach (var item in allExams)
            {
                if (sameExams.FirstOrDefault(se => se.ExamName == item.ExamName) == null)
                    sameExams.Add(item);
            }

            foreach (var ex in sameExams)
            {
                workSheet.Cells[rowNumb, "A"] = ex.ExamName;
                rowNumb++;
            }
            List<Session> allSessions = ((Table<Session>)CRUD.Read<Session>()).ToList();
            allSessions.Sort();

            foreach (var session in allSessions)
            {
                workSheet.Cells[1, GetDictionary()[colNumb]] = session.StartDate.Year;
                workSheet.Cells[2, GetDictionary()[colNumb]] = $"{session.StartDate} - {session.EndDate}";
                List<Exam> examsInSession = ((Table<Exam>)CRUD.Read<Exam>()).ToList().Where(e => e.SessionId == session.SessionId).ToList();
                List<ExamResult> examResultsInSession = new List<ExamResult>();

                rowNumb = 3;
                foreach (var er in sameExams)
                {
                    try
                    {
                        workSheet.Cells[rowNumb, GetDictionary()[colNumb]] = GetAverageMarkInSession(session, er.ExamName).ToString("#.##");
                    }
                    catch
                    {
                        workSheet.Cells[rowNumb, GetDictionary()[colNumb]] = "-";
                    }
                    rowNumb++;
                }
                colNumb++;
            }

            workBook.Close(true, path);
            excelApp.Quit();
        }

        /// <summary>
        /// Get max mark in the group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        private static int GetMaxMark(Group group)
        {
            List<Student> students = ((Table<Student>)CRUD.Read<Student>()).ToList().Where(s => s.GroupId == group.GroupId).ToList();
            List<ExamResult> examResults = ((Table<ExamResult>)CRUD.Read<ExamResult>()).ToList();
            int max = 0;
            foreach (var st in students)
            {
                if ((examResults = examResults.Where(er => er.StudentId == st.StudentId && er.Mark >= max).ToList()).Count != 0)
                    max = examResults.Max(er => er.Mark);
            }

            return max;
        }

        /// <summary>
        /// Get min mark in the group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        private static int GetMinMark(Group group)
        {
            List<Student> students = ((Table<Student>)CRUD.Read<Student>()).ToList().Where(s => s.GroupId == group.GroupId).ToList();
            List<ExamResult> examResults = ((Table<ExamResult>)CRUD.Read<ExamResult>()).ToList();
            int min = 0;
            foreach (var st in students)
            {
                if ((examResults = examResults.Where(er => er.StudentId == st.StudentId && er.Mark >= min).ToList()).Count != 0)
                    min = examResults.Min(er => er.Mark);
            }

            return min;
        }

        /// <summary>
        /// Get average mark in the group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        private static double GetAverageMark(Group group)
        {
            List<Student> students = ((Table<Student>)CRUD.Read<Student>()).ToList().Where(s => s.GroupId == group.GroupId).ToList();
            List<ExamResult> examResults = ((Table<ExamResult>)CRUD.Read<ExamResult>()).ToList();
            double average = 0;
            foreach (var st in students)
            {
                List<ExamResult> studentExams;
                if ((studentExams = examResults.Where(er => er.StudentId == st.StudentId).ToList()).Count != 0)
                    average = studentExams.Average(er => er.Mark);
            }

            return average;
        }

        /// <summary>
        /// Calculates average mark in session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="examName">Name of exam average mark you want to get</param>
        /// <returns></returns>
        private static double GetAverageMarkInSession(Session session, string examName)
        {
            Exam exam = ((Table<Exam>)CRUD.Read<Exam>()).ToList().FirstOrDefault(e => e.SessionId == session.SessionId && e.ExamName == examName);
            if (exam == null)
                throw new Exception();
            List<ExamResult> examResults = ((Table<ExamResult>)CRUD.Read<ExamResult>()).ToList().Where(e => e.ExamId == exam.ExamId).ToList();
            return examResults.Average(e => e.Mark);
        }

        /// <summary>
        /// Dictionary that helps to work with excel table
        /// </summary>
        /// <returns>Dictionary that translates number of column to letter in excel</returns>
        private static Dictionary<int, string> GetDictionary()
        {
            return new Dictionary<int, string>
            {
                { 1, "A" },
                { 2, "B" },
                { 3, "C" },
                { 4, "D" },
                { 5, "E" },
                { 6, "F" },
                { 7, "G" },
                { 8, "H" },
                { 9, "I" },
                { 10, "J" },
                { 11, "K" },
                { 12, "L" },
                { 13, "M" },
                { 14, "N" }
            };
        }
    }
}
