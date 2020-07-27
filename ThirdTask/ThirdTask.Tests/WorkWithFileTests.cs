using Enumerables;
using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ThirdTask.Tests
{
    [TestClass]
    public class WorkWithFileTests
    {
        [TestMethod]
        public void StreamlWriter_XmlReader()
        {
            try
            {
                Figure[] figures = new Figure[]
                {
                new Circle(4,5,2, Colors.Black),
                new Triangle(4,6,2,1,6,3, Colors.Green),
                new Circle(1,2,2, Materials.CelluloseTape),
                new Rectangle(6,3, Colors.Pink),
                new Circle(6,5,4, Materials.CelluloseTape),
                new Triangle(5,3,1,6,6,2, Materials.Paper),
                new Triangle(1,2,1,4,2,1, Colors.Orange),
                new Rectangle(11,2, Colors.Red),
                };
                WorkWithFile.WriteXmlFileByStreamWriter(@"..\Figures.xml", figures);

                figures = WorkWithFile.ReadXmlFileByXmlReader(@"..\Figures.xml");
            }
            catch { Assert.Fail(); }
        }

        [TestMethod]
        public void StreamlWriter_StreamReader()
        {
            try
            {
                Figure[] figures = new Figure[]
                {
                new Circle(4,5,2, Colors.Black),
                new Triangle(4,6,2,1,6,3, Colors.Green),
                new Circle(1,2,2, Materials.CelluloseTape),
                new Rectangle(6,3, Colors.Pink),
                new Circle(6,5,4, Materials.CelluloseTape),
                new Triangle(5,3,1,6,6,2, Materials.Paper),
                new Triangle(1,2,1,4,2,1, Colors.Orange),
                new Rectangle(11,2, Colors.Red),
                };
                WorkWithFile.WriteXmlFileByStreamWriter(@"..\Figures.xml", figures);

                figures = WorkWithFile.ReadXmlFileByStreamReader(@"..\Figures.xml");
            }
            catch { Assert.Fail(); }
        }

        [TestMethod]
        public void XmlWriter_XmlReader()
        {
            try
            {
                Figure[] figures = new Figure[]
                {
                new Circle(4,5,2, Colors.Black),
                new Triangle(4,6,2,1,6,3, Colors.Green),
                new Circle(1,2,2, Materials.CelluloseTape),
                new Rectangle(6,3, Colors.Pink),
                new Circle(6,5,4, Materials.CelluloseTape),
                new Triangle(5,3,1,6,6,2, Materials.Paper),
                new Triangle(1,2,1,4,2,1, Colors.Orange),
                new Rectangle(11,2, Colors.Red),
                };
                WorkWithFile.WriteXmlFileByXmlWriter(@"..\Figures.xml", figures);

                figures = WorkWithFile.ReadXmlFileByXmlReader(@"..\Figures.xml");
            }
            catch { Assert.Fail(); }
        }

        [TestMethod]
        public void XmlWriter_StreamReader()
        {
            try
            {
                Figure[] figures = new Figure[]
                {
                new Circle(4,5,2, Colors.Black),
                new Triangle(4,6,2,1,6,3, Colors.Green),
                new Circle(1,2,2, Materials.CelluloseTape),
                new Rectangle(6,3, Colors.Pink),
                new Circle(6,5,4, Materials.CelluloseTape),
                new Triangle(5,3,1,6,6,2, Materials.Paper),
                new Triangle(1,2,1,4,2,1, Colors.Orange),
                new Rectangle(11,2, Colors.Red),
                };
                WorkWithFile.WriteXmlFileByXmlWriter(@"..\Figures.xml", figures);

                figures = WorkWithFile.ReadXmlFileByStreamReader(@"..\Figures.xml");
            }
            catch { Assert.Fail(); }
        }
    }
}
