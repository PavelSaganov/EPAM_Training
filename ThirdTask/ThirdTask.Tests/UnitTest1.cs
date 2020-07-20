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
            IPaper s = new Circle(4, 2, 1);
            Assert.IsTrue(s is ICelluloseTape);
        }
    }
}
