using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThirdTask;
using ThirdTask.Materials;

namespace ThirdTask.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //IPaper s = new Circle(4, 2, 1);
            //Assert.IsTrue(s is ICelluloseTape);
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
        //        new Circle(4,5,2),
        //        new Triangle(4,6,2,1,6,3),
        //        new Circle(1,2,2),
        //        new Rectangle(6,3),
        //        new Circle(6,5,4),
        //        new Triangle(5,3,1,6,6,2),
        //        new Triangle(1,2,1,4,2,1),
        //        new Rectangle(11,2),
        //    };
        //    WorkWithFile.WriteToXmlFile(@"..\Figures.xml", figures);
        //    Assert.IsTrue(true);
        //}
    }
}
