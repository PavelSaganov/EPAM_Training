using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace Ex1.Test
{
    public class WorkWithFileTests
    {
        BinaryTree<Student> tree;
        List<BinaryTree<Student>> treeList;

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

            tree = new BinaryTree<Student>(student);

            tree.Add(new BinaryTree<Student>(student2));
            tree.Add(new BinaryTree<Student>(student3));

            treeList = new List<BinaryTree<Student>>
            { tree };
        }

        [Test]
        public void Serialize()
        {
            WorkWithFile.XmlSerialize(@"..//BinaryTrees.xml", treeList);
        }

        [Test]
        public void Deserialize()
        {
            // arrange
            var arrange = treeList;
            // actual
            List<BinaryTree<Student>> actual = new List<BinaryTree<Student>>();
            actual = WorkWithFile.XmlDeserialize(@"..//BinaryTrees.xml", actual);
            // assert
            Assert.AreEqual(actual, arrange);
        }
    }
}
