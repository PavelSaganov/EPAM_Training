using Enumerables;
using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThirdTask.Tests
{
    [TestClass]
    public class BoxOfFiguresTests
    {
        [TestMethod]
        public void SeeFigure()
        {
            Triangle triangle = new Triangle(3, 1, 0, -1, 2, 1, Materials.CelluloseTape);
            Circle circle = new Circle(3, 1, 0, Materials.Paper);
            Rectangle rectangle = new Rectangle(3, 1, Materials.CelluloseTape);

            BoxOfFigures box = new BoxOfFigures(new Figure[] { triangle, circle, rectangle });

            // arrange
            var arrange = circle.ToString();

            // actual
            var actual = box[1];

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod]
        public void GetFigure()
        {
            Triangle triangle = new Triangle(3, 1, 0, -1, 2, 1, Materials.CelluloseTape);
            Circle circle = new Circle(3, 1, 0, Materials.Paper);
            Rectangle rectangle = new Rectangle(3, 1, Materials.CelluloseTape);

            BoxOfFigures box = new BoxOfFigures(new Figure[] { triangle, circle, rectangle });

            // arrange
            var arrange = circle;

            // actual
            var actual = box.GetFigure(1);

            // assert
            if (box.Count == 2)
                Assert.AreEqual(arrange, actual);
            else Assert.Fail();
        }

        [TestMethod]
        public void GetSimilarFigure()
        {
            Triangle triangle = new Triangle(3, 1, 0, -1, 2, 1, Materials.CelluloseTape);
            Circle circle = new Circle(3, 1, 0, Materials.Paper);
            Rectangle rectangle = new Rectangle(3, 1, Materials.CelluloseTape);

            BoxOfFigures box = new BoxOfFigures(new Figure[] { triangle, circle, rectangle });

            // arrange
            Circle arrange = new Circle(3, 1, 0, Materials.Paper);

            // actual
            var actual = box.GetSimilarFigure(arrange);

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod]
        public void GetCircles()
        {
            Triangle triangle = new Triangle(3, 1, 0, -1, 2, 1, Materials.CelluloseTape);
            Circle circle = new Circle(3, 1, 0, Materials.Paper);
            Rectangle rectangle = new Rectangle(3, 1, Materials.CelluloseTape);
            Circle circle2 = new Circle(3, 4, 2, Materials.CelluloseTape);
            Circle circle3 = new Circle(1, 1, 0, Colors.Yellow);

            BoxOfFigures box = new BoxOfFigures(new Figure[] { triangle, circle, rectangle, circle2, circle3 });

            // actual
            List<Figure> actual = box.GetCircles();

            // assert
            if (actual.Any(f => !(f is Circle)))
                Assert.Fail();
        }

        [TestMethod]
        public void GetCelluloseFigures()
        {
            Triangle triangle = new Triangle(3, 1, 0, -1, 2, 1, Materials.CelluloseTape);
            Circle circle = new Circle(3, 1, 0, Materials.Paper);
            Rectangle rectangle = new Rectangle(3, 1, Materials.CelluloseTape);
            Circle circle2 = new Circle(3, 4, 2, Materials.CelluloseTape);
            Circle circle3 = new Circle(1, 1, 0, Colors.Yellow);

            BoxOfFigures box = new BoxOfFigures(new Figure[] { triangle, circle, rectangle, circle2, circle3 });

            // actual
            List<Figure> actual = box.GetCelluloseFigures();

            // assert
            if (actual.Any(f => f.Color != Colors.Colorless))
                Assert.Fail();
        }

        [TestMethod]
        public void AddTwice_Error_returned()
        {
            Triangle triangle = new Triangle(3, 1, 0, -1, 2, 1, Materials.CelluloseTape);
            Circle circle = new Circle(3, 1, 0, Materials.Paper);
            BoxOfFigures box = new BoxOfFigures(new Figure[] { triangle, circle });

            Assert.ThrowsException<Exception>(() =>
            {
                box.Add(circle);
            });
        }

        [TestMethod]
        public void GetTotalSquare_55returned()
        {
            Rectangle rectangle = new Rectangle(1, 5, Materials.CelluloseTape);
            Rectangle rectangle2 = new Rectangle(10, 5, Materials.CelluloseTape);

            BoxOfFigures box = new BoxOfFigures(new Figure[] { rectangle, rectangle2 });

            // arrange
            double arrange = 55;

            // actual
            double actual = box.GetTotalSquare;

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod]
        public void GetTotalSquare_51returned()
        {
            Rectangle rectangle = new Rectangle(3, 5, Materials.CelluloseTape);
            Rectangle rectangle2 = new Rectangle(6, 6, Materials.CelluloseTape);

            BoxOfFigures box = new BoxOfFigures(new Figure[] { rectangle, rectangle2 });

            // arrange
            double arrange = 51;

            // actual
            double actual = box.GetTotalSquare;

            // assert
            Assert.AreEqual(arrange, actual);
        }
    }
}
