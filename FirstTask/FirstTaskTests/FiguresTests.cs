using System;
using System.Text;
using System.Collections.Generic;
using Figures;
using Figures.Comparers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FirstTaskTests
{
    [TestClass()]
    public class FiguresTests
    {
        [TestMethod()]
        public void CorrectFileReading()
        {
            // arrange
            Figure[] figures;

            // actual
            figures = WorkWithFile.ReadFiguresFromTxt(@"..\Figures.txt");

            // assert
            Assert.IsNotNull(figures);
        }

        [TestMethod()]
        public void RectangleSquare_10_30_300returned()
        {
            // arrange
            double arrange = 300;

            // actual
            Rectangle rect = new Rectangle(10, 30);
            double actual = rect.Square;

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod()]
        public void CircleSquare_5_78returned()
        {
            // arrange
            int arrange = 78;

            // actual
            Circle circle = new Circle(5, 5, 5);
            double actual = (int)circle.Square;

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod()]
        public void TriangleSquare_4_0_0_0_3_4_134returned()
        {
            // arrange
            int arrange = 134;

            // actual
            Triangle triangle = new Triangle(4, 0, 0, 0, 3, 4);
            int actual = (int)triangle.Square;

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod()]
        public void CorrectEqualsFigureInArray()
        {
            // arrange
            Figure figure = new Triangle(3, 4, 2, 6, 6, 10);
            Figure[] arrange = new Figure[3]
                { figure, figure, figure };

            // actual
            Figure[] actual = WorkWithFigures.FindEqualFigureInArray(figure, WorkWithFile.ReadFiguresFromTxt(@"..\Figures.txt"));

            // assert
            Assert.IsTrue(actual.SequenceEqual(actual, new FigureEqualityComparer()));
        }
    }
}
