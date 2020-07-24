using Enumerables;
using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThirdTask.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var s = new Circle(4, 2, 1, Materials.Paper);
            //s.Color = Colors.Gray;
            //var a = s.ToString();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ReadXml()
        {
            Figure[] figures = WorkWithFile.ReadXmlFile(@"..\Figures.xml");
            Assert.IsTrue(true);
        }

        //[TestMethod]
        //public void WriteXml()
        //{
        //    Figure[] figures = new Figure[]
        //    {
        //        new Circle(4,5,2, Colors.Black),
        //        new Triangle(4,6,2,1,6,3, Colors.Green),
        //        new Circle(1,2,2, Materials.CelluloseTape),
        //        new Rectangle(6,3, Colors.Pink),
        //        new Circle(6,5,4, Materials.CelluloseTape),
        //        new Triangle(5,3,1,6,6,2, Colors.Purple),
        //        new Triangle(1,2,1,4,2,1, Colors.Orange),
        //        new Rectangle(11,2, Colors.Red),
        //    };
        //    WorkWithFile.WriteToXmlFile(@"..\Figures.xml", figures);
        //    Assert.IsTrue(true);
        //}
    }
}
