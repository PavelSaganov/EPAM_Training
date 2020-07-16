using Exercise_2__Polynomial_;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SecondTask.Tests
{
    public class Exercise2Tests
    {
        [Fact]
        public void SummingPolynomials()
        {
            //arrange
            Polynomial polynomial1 = new Polynomial(3, 6, 4, 2);
            Polynomial polynomial2 = new Polynomial(6, 4, 2);

            double[] arrange = { 9, 10, 6, 2 };

            //actual
            Polynomial sumOfPolinomials = polynomial1 + polynomial2;
            double[] actual = sumOfPolinomials.coefficients;

            //assert
            Assert.Equal(arrange, actual);
        }

        [Fact]
        public void TheDifferenceBetweenPolynomials()
        {
            Polynomial polynomial1 = new Polynomial(3, 6, 4, 1);
            Polynomial polynomial2 = new Polynomial(6, 4, 4);

            Polynomial difOfPolinomials = polynomial1 - polynomial2;

            //arrange
            double[] arrange = { -3, 2, 0, 1 };

            //actual
            double[] actual = difOfPolinomials.coefficients;

            //assert
            Assert.Equal(arrange, actual);
        }

        [Fact]
        public void MultiplyPolynomials()
        {
            Polynomial polynomial1 = new Polynomial(3, 6, 4, 1);
            Polynomial polynomial2 = new Polynomial(6, 4, 4);

            Polynomial mulOfPolinomials = polynomial1 * polynomial2;

            //arrange
            double[] arrange = { 18, 48, 60, 46, 20, 4 };

            //actual
            double[] actual = mulOfPolinomials.coefficients;

            //assert
            Assert.Equal(arrange, actual);
        }
    }
}
