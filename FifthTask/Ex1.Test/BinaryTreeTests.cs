using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Ex1.Test
{
    public class BinaryTreeTests
    {
        BinaryTree<Student> tree;
        BinaryTree<Student> tree2;
        BinaryTree<Student> BalancedTree2;

        /// <summary>
        /// Creates a trees
        /// </summary>
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

            Student student5 = new Student()
            {
                Name = "Elena",
                Test = new StudentTest()
                {
                    Name = "Physics exam",
                    Mark = 7,
                    Date = new DateTime(2019, 11, 24),
                }
            };

            Student student6 = new Student()
            {
                Name = "Nikita",
                Test = new StudentTest()
                {
                    Name = "Math exam",
                    Mark = 8,
                    Date = new DateTime(2019, 11, 23),
                }
            };

            Student student7 = new Student()
            {
                Name = "Artem",
                Test = new StudentTest()
                {
                    Name = "Math exam",
                    Mark = 7,
                    Date = new DateTime(2019, 11, 23),
                }
            };

            Student student8 = new Student()
            {
                Name = "Viktor",
                Test = new StudentTest()
                {
                    Name = "Physics exam",
                    Mark = 9,
                    Date = new DateTime(2019, 11, 24),
                }
            };

            Student student9 = new Student()
            {
                Name = "Alex",
                Test = new StudentTest()
                {
                    Name = "Physics exam",
                    Mark = 5,
                    Date = new DateTime(2019, 11, 24),
                }
            };

            Student student10 = new Student()
            {
                Name = "Elena",
                Test = new StudentTest()
                {
                    Name = "Physics exam",
                    Mark = 7,
                    Date = new DateTime(2019, 11, 24),
                }
            };

            tree = new BinaryTree<Student>(student);
            tree2 = new BinaryTree<Student>(student6);

            tree.Add(new BinaryTree<Student>(student2));
            tree.Add(new BinaryTree<Student>(student3));
            tree.Children[0].Add(new BinaryTree<Student>(student4));
            tree.Children[0].Add(new BinaryTree<Student>(student5));

            tree2.Add(new BinaryTree<Student>(student7));
            tree2.Add(new BinaryTree<Student>(student8));
            tree2.Children[1].Add(new BinaryTree<Student>(student9));
            tree2.Children[1].Add(new BinaryTree<Student>(student10));

            Student student11 = new Student()
            {
                Name = "Nikita",
                Test = new StudentTest()
                {
                    Name = "Math exam",
                    Mark = 8,
                    Date = new DateTime(2019, 11, 23),
                }
            };

            Student student12 = new Student()
            {
                Name = "Artem",
                Test = new StudentTest()
                {
                    Name = "Math exam",
                    Mark = 7,
                    Date = new DateTime(2019, 11, 23),
                }
            };

            Student student13 = new Student()
            {
                Name = "Viktor",
                Test = new StudentTest()
                {
                    Name = "Physics exam",
                    Mark = 9,
                    Date = new DateTime(2019, 11, 24),
                }
            };

            Student student14 = new Student()
            {
                Name = "Alex",
                Test = new StudentTest()
                {
                    Name = "Physics exam",
                    Mark = 5,
                    Date = new DateTime(2019, 11, 24),
                }
            };

            Student student15 = new Student()
            {
                Name = "Elena",
                Test = new StudentTest()
                {
                    Name = "Physics exam",
                    Mark = 7,
                    Date = new DateTime(2019, 11, 24),
                }
            };

            Student st16 = new Student
            {
                Name = "Evgen",
                Test = new StudentTest()
                {
                    Name = "English Language exam",
                    Mark = 7,
                    Date = new DateTime(2019, 11, 22),
                }
            };

            Student st17 = new Student
            {
                Name = "Marks",
                Test = new StudentTest()
                {
                    Name = "English Language exam",
                    Mark = 10,
                    Date = new DateTime(2019, 11, 22),
                }
            };

            BalancedTree2 = new BinaryTree<Student>(student14);
            BalancedTree2.Add(new BinaryTree<Student>(student11));
            BalancedTree2.Add(new BinaryTree<Student>(student13));
            BalancedTree2.Children[0].Add(new BinaryTree<Student>(student12));
            BalancedTree2.Children[0].Add(new BinaryTree<Student>(st16));

            BalancedTree2.Children[1].Add(new BinaryTree<Student>(st17));
            BalancedTree2.Children[1].Add(new BinaryTree<Student>(student15));
        }

        [Test]
        public void FindChildTest()
        {
            // actual
            var actual = tree.Children[1].Value;

            // arrange
            var arrange = tree.Find(n => n.Value.Equals(actual)).Value;

            // assert
            Assert.AreEqual(actual, arrange);
        }

        [Test]
        public void RightRotate()
        {
            // actual
            var actual = tree.RightRotate();

            // arrange
            var arrange = tree2;

            // assert
            Assert.AreEqual(actual, arrange);
        }

        [Test]
        public void LeftRotate()
        {
            // actual
            var actual = tree2.LeftRotate();

            // arrange
            var arrange = tree;

            // assert
            Assert.AreEqual(actual, arrange);
        }

        [Test]
        public void BalanceTree()
        {
            Student st = new Student
            {
                Name = "Evgen",
                Test = new StudentTest()
                {
                    Name = "English Language exam",
                    Mark = 7,
                    Date = new DateTime(2019, 11, 22),
                }
            };

            Student st2 = new Student
            {
                Name = "Marks",
                Test = new StudentTest()
                {
                    Name = "English Language exam",
                    Mark = 10,
                    Date = new DateTime(2019, 11, 22),
                }
            };
            tree2.Children[1].Children[0].Add(new BinaryTree<Student>(st));
            tree2.Children[1].Children[0].Add(new BinaryTree<Student>(st2));

            // actual
            var actual = tree2.Balance();

            // arrange
            var arrange = BalancedTree2;

            // assert
            Assert.AreEqual(actual, arrange);
        }
    }
}