using NUnit.Framework;
using SeventhTask.Models;
using SeventhTask.WorkWithDB;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;

namespace SeventhTask.Tests
{
    public class ReportTests
    {
        DataContext db;
        string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = University; Integrated Security = True";

        [SetUp]
        public void Setup()
        {
            db = new DataContext(connectionString);
            CRUD.db = db;
        }

        [Test]
        public void WriteExcelMaxAverageMin()
        {
            var session = ((Table<Session>)CRUD.Read<Session>()).ToList();

            Reports.WriteExcelMaxAverageMin(session.First(), Directory.GetCurrentDirectory() + @"..\..\..\..\..\MAMForSession.xlsx");
        }

        [Test]
        public void WriteSessionResult()
        {
            var session = ((Table<Session>)CRUD.Read<Session>()).ToList();

            Reports.WriteExcelSessionResult(session.First(), Directory.GetCurrentDirectory() + @"..\..\..\..\..\SessionResult.xlsx");
        }

        [Test]
        public void WriteSpecialityAverageInSession()
        {
            var session = ((Table<Session>)CRUD.Read<Session>()).ToList();

            Reports.WriteExcelAverageOnSpeciality(session.First(), Directory.GetCurrentDirectory() + @"..\..\..\..\..\SpecialitiesAverageResult.xlsx");
        }

        [Test]
        public void WriteExaminerAverageInSession()
        {
            var session = ((Table<Session>)CRUD.Read<Session>()).ToList();

            Reports.WriteExcelAverageByExaminer(session.First(), Directory.GetCurrentDirectory() + @"..\..\..\..\..\ExaminersAverageResult.xlsx");
        }

        [Test]
        public void WriteChangesOfAverageMark()
        {
            Reports.WriteExcelChangesOfAverageMark(Directory.GetCurrentDirectory() + @"..\..\..\..\..\ChangesOfAverageMark.xlsx");
        }

        [Test]
        public void GetExpulsionList()
        {
            var groups = ((Table<Group>)CRUD.Read<Group>()).ToList();

            var result = Reports.CreateExpulsionList(groups.ElementAt(1));
            Assert.AreEqual(1, result.Count);
        }
    }
}
