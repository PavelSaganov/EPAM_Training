using Exercise_1__Vectors_;
using Exercise_1__Vectors_.Comparers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace SecondTask.Tests
{
    public class Exercise1Tests
    {
        [Fact]
        public void LengthVector_4_6_4_8returned()
        {
            Vector vector = new Vector(4, 6, 4);

            //arrange
            int arrange = 8;

            //actual
            int actual = (int)vector.Length;

            //assert
            Assert.Equal(arrange, actual);
        }

        [Fact]
        public void TheDifferenceBetweenVectors()
        {
            Vector v1 = new Vector(3, 6, 4);
            Vector v2 = new Vector(6, 4, 4);

            Vector difOfPolinomials = v1 - v2;

            //arrange
            Vector arrange = new Vector(-3, 2, 0);

            //actual
            Vector actual = v1 - v2;

            //assert
            Assert.Equal(arrange, actual, new VectorEqualityComparer());
        }

        [Fact]
        public void SummingVectors()
        {
            Vector v1 = new Vector(3, 6, 4);
            Vector v2 = new Vector(6, 4, 4);

            Vector difOfPolinomials = v1 - v2;

            //arrange
            Vector arrange = new Vector(9, 10, 8);

            //actual
            Vector actual = v1 + v2;

            //assert
            Assert.Equal(arrange, actual, new VectorEqualityComparer());
        }

        [Fact]
        public void MultiplyVectors()
        {
            Vector v1 = new Vector(3, 6, 4);
            Vector v2 = new Vector(6, 4, 4);

            //arrange
            Vector arrange = new Vector(8, 12, -24);

            //actual
            Vector actual = v1 * v2;

            //assert
            Assert.Equal(arrange, actual, new VectorEqualityComparer());
        }

        [Fact]
        public void GetVectorScalarProduct_37returned()
        {
            Vector v1 = new Vector(11, 2, 3);
            Vector v2 = new Vector(-5, 3, 4);

            //arrange
            double arrange = -37;

            //actual
            double actual = Vector.GetScalarProduct(v1, v2);

            //assert
            Assert.Equal(arrange, actual);
        }
    }
}
