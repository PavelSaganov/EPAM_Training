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
    public class CRUDTests
    {
        ConnectionToDB connection = new ConnectionToDB(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=University; Integrated Security=True");

        [TestMethod]
        public void Read()
        {
            connection.Open();


            List<Student> students = ORM.Read<Student>();
            List<Session> session = ORM.Read<Session>();
        }

        [TestMethod]
        public void Create()
        {
            connection.Open();


            ORM.Create(new Student
            {
                GroupId = 2,
                BirthDay = new DateTime(2020, 3, 5),
                SecondName = "Petrovich",
                FirstName = "Evgeniy",
                Surname = "Kybonin"
            });
        }

        [TestMethod]
        public void Update()
        {
            connection.Open();

            List<Student> students = ORM.Read<Student>();

            ORM.Update(students.First(), students.Last());
            ORM.Delete(students);
        }

        [TestMethod]
        public void Delete()
        {
            connection.Open();

            List<Student> students = ORM.Read<Student>();
            ORM.Delete(students);
        }
    }
}
