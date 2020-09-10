using Microsoft.VisualStudio.TestTools.UnitTesting;
using SixthTask.Models;
using SixthTask.WorkWithDB;
using System;
using System.Collections.Generic;
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

            Reports.WriteExcelMaxAverageMin(session.First(), @"E:\MAMForSession.xlsx");
        }

        [TestMethod]
        public void WriteSessionResult()
        {
            connection.Open();

            var session = ORM.Read<Session>();

            Reports.WriteExcelSessionResult(session.First(), @"E:\SessionResult.xlsx");
        }

        [TestMethod]
        public void GetExpulsionList()
        {
            connection.Open();

            var groups = ORM.Read<Group>();

            var result = Reports.CreateExpulsionList(groups.ElementAt(1));
        }
    }
}
