using SixthTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using SixthTask.WorkWithDB;

namespace SixthTask
{
    public static class Reports
    {
        /// <summary>
        /// Creates an explusion list in student list
        /// </summary>
        /// <param name="students"></param>
        /// <returns></returns>
        public static List<Student> CreateExpulsionList(Group group)
        {
            List<ExamResult> examResults = ORM.Read<ExamResult>();
            List<Student> students = ORM.Read<Student>().Where(s => s.GroupId == group.GroupId).ToList();
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
            List<PartialCreditResult> partialCreditResults = ORM.Read<PartialCreditResult>();
            List<Exam> exams = ORM.Read<Exam>().Where(e => e.SessionId == session.SessionId).ToList();
            List<Group> groups = new List<Group>();

            foreach (var g in ORM.Read<Group>())
            {
                exams.ForEach(e => { if (e.GroupId == g.GroupId) groups.Add(g); });
            }
            groups.Distinct();

            workSheet.Cells[1, "A"] = "Group/Name";

            int colNumb = 2;
            foreach (var ex in exams)
            {
                workSheet.Cells[1, GetDictionary()[colNumb]] = ex.Name;
                colNumb++;
            }

            int rowNumb = 1;
            foreach (var g in groups)
            {
                rowNumb++;
                workSheet.Cells[rowNumb, "A"] = $"{ g.Name }";
                rowNumb++;

                List<Student> students = ORM.Read<Student>().Where(s => s.GroupId == g.GroupId).ToList();
                foreach (var st in students)
                {
                    workSheet.Cells[rowNumb, "A"] = $"{ st.FirstName } { st.SecondName } { st.Surname }";
                    List<ExamResult> examResults = ORM.Read<ExamResult>().Where(er => er.StudentId == st.StudentId).ToList();
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

            foreach (var item in ORM.Read<Group>())
            {
                colNumb++;
                workSheet.Cells[colNumb, "A"] = $"{ session.StartDate } - { session.EndDate }";
                workSheet.Cells[colNumb, "B"] = item.Name;
                workSheet.Cells[colNumb, "C"] = GetMaxMark(item);
                workSheet.Cells[colNumb, "D"] = GetAverageMark(item);
                workSheet.Cells[colNumb, "E"] = GetMinMark(item);
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
            List<Student> students = ORM.Read<Student>().Where(s => s.GroupId == group.GroupId).ToList();
            List<ExamResult> examResults = ORM.Read<ExamResult>();
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
            List<Student> students = ORM.Read<Student>().Where(s => s.GroupId == group.GroupId).ToList();
            List<ExamResult> examResults = ORM.Read<ExamResult>();
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
            List<Student> students = ORM.Read<Student>().Where(s => s.GroupId == group.GroupId).ToList();
            List<ExamResult> examResults = ORM.Read<ExamResult>();
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
