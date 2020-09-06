using Microsoft.VisualStudio.TestTools.UnitTesting;
using SixthTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixthTask.Tests
{
    [TestClass]
    public class CRUDTests
    {
        ConnectionToDB connection = new ConnectionToDB(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=University; Integrated Security=True");

        [TestMethod]
        public void Read()
        {
            connection.Open();


            List<Student> students = WorkWithDb.Read<Student>();
            List<Session> session = WorkWithDb.Read<Session>();
        }
    }
}
