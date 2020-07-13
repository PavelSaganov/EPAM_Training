using System;
using EuclideanAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirstTask.Tests
{
    [TestClass()]
    public class EuclideanAlgorithmTests
    {
        [TestMethod()]
        public void Euclid_9_33_3returned()
        {
            // arrange
            int arrange = 3;

            // actual
            int actual = EuclideanAlgorithm.EuclideanAlgorithm.GetGCDByEuclid(out long ms, 9, 33);

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod()]
        public void Euclid_9_33_111_3returned()
        {
            // arrange
            int arrange = 3;

            // actual
            int actual = EuclideanAlgorithm.EuclideanAlgorithm.GetGCDByEuclid(out long ms, 9, 33, 111);

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod()]
        public void Euclid_66_121_242_11returned()
        {
            // arrange
            int arrange = 11;

            // actual
            int actual = EuclideanAlgorithm.EuclideanAlgorithm.GetGCDByEuclid(66, 121, 242);

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod()]
        public void Euclid_66_121_242_550_11returned()
        {
            // arrange
            int arrange = 11;

            // actual
            int actual = EuclideanAlgorithm.EuclideanAlgorithm.GetGCDByEuclid(66, 121, 242, 550);

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod()]
        public void Euclid_24_662_112_46_2returned()
        {
            // arrange
            int arrange = 2;

            // actual
            int actual = EuclideanAlgorithm.EuclideanAlgorithm.GetGCDByEuclid(24, 662, 112, 46);

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod()]
        public void Stein_22_33_11returned()
        {
            // arrange
            int arrange = 11;

            // actual
            int actual = EuclideanAlgorithm.EuclideanAlgorithm.GetGCDByStein(22, 33);

            // assert
            Assert.AreEqual(arrange, actual);
        }

        [TestMethod()]
        public void Stein_54_81_27returned()
        {
            // arrange
            int arrange = 27;

            // actual
            int actual = EuclideanAlgorithm.EuclideanAlgorithm.GetGCDByStein(54, 81);

            // assert
            Assert.AreEqual(arrange, actual);
        }
    }
}
