using NUnit.Framework;
using SeventhTask.Models;
using SeventhTask.WorkWithDB;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace SeventhTask.Tests
{
    public class Tests
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
        public void Read()
        {
            List<Exam> e = ((Table<Exam>)CRUD.Read<Exam>()).ToList();
            List<Student> s = ((Table<Student>)CRUD.Read<Student>()).ToList();
            List<ExamResult> er = ((Table<ExamResult>)CRUD.Read<ExamResult>()).ToList();
            List<Group> g = ((Table<Group>)CRUD.Read<Group>()).ToList();
            List<PartialCredit> pc = ((Table<PartialCredit>)CRUD.Read<PartialCredit>()).ToList();
            List<PartialCreditResult> pcr = ((Table<PartialCreditResult>)CRUD.Read<PartialCreditResult>()).ToList();
            List<Session> ses = ((Table<Session>)CRUD.Read<Session>()).ToList();
            List<Speciality> sp = ((Table<Speciality>)CRUD.Read<Speciality>()).ToList();
        }

        [Test]
        public void Create()
        {
            Student student = new Student
            {
                BirthDay = DateTime.Now,
                FirstName = "Igor",
                SecondName = "Engelsievich",
                Surname = "Dadanich",
                GroupId = 2
            };

            // arrange
            int arrange = db.GetTable<Student>().ToList().Count;
            CRUD.Create(student);
            // current
            int current = db.GetTable<Student>().ToList().Count;
            // arrange
            Assert.AreEqual(current + 1, arrange);
        }

        [Test]
        public void Update()
        {
            Student old = db.GetTable<Student>().ToList().Last();

            Student newStudent = new Student
            {
                StudentId = old.StudentId,
                BirthDay = DateTime.Now,
                FirstName = "Updated",
                SecondName = "Updatovich",
                Surname = "Updated",
                GroupId = old.GroupId
            };

            CRUD.Update(old, newStudent);
            Assert.AreEqual(db.GetTable<Student>().Last(), newStudent);
        }

        [Test]
        public void Delete()
        {
            // arrange
            int arrange = db.GetTable<Student>().ToList().Count;
            CRUD.Delete(db.GetTable<Student>().ToList().Last());
            // current
            int current = db.GetTable<Student>().ToList().Count;
            // arrange
            Assert.AreEqual(current, arrange - 1);
        }
    }
}