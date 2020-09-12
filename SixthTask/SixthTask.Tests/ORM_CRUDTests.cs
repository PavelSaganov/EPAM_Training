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
    public class ORM_CRUDTests
    {
        ConnectionToDB connection = new ConnectionToDB(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=University; Integrated Security=True");

        [TestMethod]
        public void Read()
        {
            connection.Open();

            List<Student> students = ORM.Read<Student>();
            List<Session> session = ORM.Read<Session>();
            connection.Close();

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
            connection.Close();

        }

        [TestMethod]
        public void Update()
        {
            connection.Open();

            List<Student> students = ORM.Read<Student>();
            var newStudent = new Student
            {
                GroupId = 2,
                BirthDay = new DateTime(2020, 3, 5),
                SecondName = "Sergeevich",
                FirstName = "Anatoliy",
                Surname = "Kybonin"
            };

            ORM.Update(students.Last(), newStudent);
            Assert.AreEqual(newStudent, students.Last());
            connection.Close();

        }

        [TestMethod]
        public void Delete()
        {
            connection.Open();

            List<Student> students = ORM.Read<Student>();

            // Arrange
            int arrange = students.Count;
            ORM.Delete(students.Last());

            // Current
            int current = ORM.Read<Student>().Count;

            // Assert
            Assert.AreEqual(arrange - 1, current);
            connection.Close();

        }
    }
}
