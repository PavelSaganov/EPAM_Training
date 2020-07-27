using Enumerables;
using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThirdTask.Tests
{
    [TestClass]
    public class FigureConverterTests
    {
        [TestMethod]
        public void FromTriangleToCircle_Error_returned()
        {
            Triangle triangle = new Triangle(3, 1, 0, -1, 2, 1, Materials.CelluloseTape);

            Assert.ThrowsException<Exception>(() => { Circle circle = new Circle(6, 0, 12, triangle); });
        }

        [TestMethod]
        public void FromCircleToRectangle_Error_returned()
        {
            Circle circle = new Circle(3, 1, 4, Materials.CelluloseTape);

            Assert.ThrowsException<Exception>(() => { Rectangle rectangle = new Rectangle(13, 4, circle); });
        }

        [TestMethod]
        public void FromTriangleToCircle_Success_returned()
        {
            Triangle triangle = new Triangle(3, 6, 0, -3, 2, 3, Materials.CelluloseTape);

            Circle circle = new Circle(1, 0, 1, triangle);
        }

        [TestMethod]
        public void FromTriangleToRectangle_Success_returned()
        {
            Triangle triangle = new Triangle(3, 6, 0, -3, 2, 3, Materials.CelluloseTape);

            Rectangle rectangle = new Rectangle(1, 2, triangle);
        }

        [TestMethod]
        public void FromCircleToRectangle_Success_returned()
        {
            Circle circle = new Circle(1, 0, 1, Colors.Green);

            Rectangle rectangle = new Rectangle(1, 2, circle);
        }

        [TestMethod]
        public void FromRectangleToTriangle_Success_returned()
        {
            Rectangle rectangle = new Rectangle(12, 5, Colors.Yellow);

            Triangle triangle = new Triangle(1, 0, 1, 2, 3, -1, rectangle);
        }
    }
}
