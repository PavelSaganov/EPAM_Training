using Microsoft.VisualStudio.TestTools.UnitTesting;
using SixthTask.Models;
using SixthTask.WorkWithDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SixthTask.Tests
{
    [TestClass]
    public class ReportTests
    {
        ConnectionToDB connection = new ConnectionToDB(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=University; Integrated Security=True");

        [TestMethod]
        public void WriteExcelMaxAverageMin()
        {
            connection.Open();

            var session = ORM.Read<Session>();

            Reports.WriteExcelMaxAverageMin(session.First(), Directory.GetCurrentDirectory() + @"..\..\..\..\..\MAMForSession.xlsx");
            connection.Close();
        }

        [TestMethod]
        public void WriteSessionResult()
        {
            connection.Open();

            var session = ORM.Read<Session>();

            Reports.WriteExcelSessionResult(session.First(), Directory.GetCurrentDirectory() + @"..\..\..\..\..\SessionResult.xlsx");
            connection.Close();
        }

        [TestMethod]
        public void GetExpulsionList()
        {
            connection.Open();

            var groups = ORM.Read<Group>();

            var result = Reports.CreateExpulsionList(groups.ElementAt(1));
            Assert.AreEqual(1, result.Count);
            connection.Close();
        }
    }
}
