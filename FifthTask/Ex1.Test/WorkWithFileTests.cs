using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace Ex1.Test
{
    public class WorkWithFileTests
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

            Student student4 = new Student()
            {
                Name = "Alex",
                Test = new StudentTest()
                {
                    Name = "Physics exam",
                    Mark = 5,
                    Date = new DateTime(2019, 11, 24),
                }
            };

            BinaryTree<Student> root = new BinaryTree<Student>(student);

            root.Add(new BinaryTree<Student>(student2));
            root.Add(new BinaryTree<Student>(student3));
            root.Children[0].Add(new BinaryTree<Student>(student4));

            var a = root.Find(student2);
            var b = root.Find(s => s.Parent == root.Children[0]);
            //binaryTree.Add();
        }

        [Test]
        public void Serialize()
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

            List<BinaryTree<Student>> treeList = new List<BinaryTree<Student>>
            { root };

            WorkWithFile.XmlSerialize(@"..//BinaryTrees.xml", treeList);
            Assert.Pass();
        }
    }
}
