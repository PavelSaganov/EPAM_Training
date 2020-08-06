using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Ex1.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Student student = new Student()
            {
                Name = "Nikita",
                Test = new StudentTest()
                {
                    Name = "Math exam",
                    Mark = 8,
                    Date = new DateTime(2019, 11, 23),
                }
            };

            Student student2 = new Student()
            {
                Name = "Artem",
                Test = new StudentTest()
                {
                    Name = "Math exam",
                    Mark = 7,
                    Date = new DateTime(2019, 11, 23),
                }
            };

            Student student3 = new Student()
            {
                Name = "Viktor",
                Test = new StudentTest()
                {
                    Name = "Physics exam",
                    Mark = 9,
                    Date = new DateTime(2019, 11, 24),
                }
            };

            BinaryTree<Student> root = new BinaryTree<Student>(student);

            root.Add(new BinaryTree<Student>(student2));
            root.Add(new BinaryTree<Student>(student3));

            //binaryTree.Add();
        }

        [Test]
        public void FindChildTest()
        {
            Student student = new Student()
            {
                Name = "Nikita",
                Test = new StudentTest()
                {
                    Name = "Math exam",
                    Mark = 8,
                    Date = new DateTime(2019, 11, 23),
                }
            };

            Student student2 = new Student()
            {
                Name = "Artem",
                Test = new StudentTest()
                {
                    Name = "Math exam",
                    Mark = 7,
                    Date = new DateTime(2019, 11, 23),
                }
            };

            Student student3 = new Student()
            {
                Name = "Viktor",
                Test = new StudentTest()
                {
                    Name = "Physics exam",
                    Mark = 9,
                    Date = new DateTime(2019, 11, 24),
                }
            };

            BinaryTree<Student> root = new BinaryTree<Student>(student);

            root.Add(new BinaryTree<Student>(student2));
            root.Add(new BinaryTree<Student>(student3));

            Assert.Pass();
        }
    }
}