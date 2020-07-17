using Exercise_2__Polynomial_;
using Exercise_2__Polynomial_.Comparers;
using Xunit;

namespace SecondTask.Tests
{
    public class Exercise2Tests
    {
        [Fact]
        public void SummingPolynomials()
        {
            Polynomial polynomial1 = new Polynomial(3, 6, 4, 2);
            Polynomial polynomial2 = new Polynomial(6, 4, 2);

            //arrange
            Polynomial arrange = new Polynomial(9, 10, 6, 2);

            //actual
            Polynomial actual = polynomial1 + polynomial2;

            //assert
            Assert.Equal(arrange, actual, new PolynomialEqualityComparer());
        }

        [Fact]
        public void TheDifferenceBetweenPolynomials()
        {
            Polynomial polynomial1 = new Polynomial(3, 6, 4, 1);
            Polynomial polynomial2 = new Polynomial(6, 4, 4);

            //arrange
            Polynomial arrange = new Polynomial( -3, 2, 0, 1 );

            //actual
            Polynomial actual = polynomial1 - polynomial2;

            //assert
            Assert.Equal(arrange, actual, new PolynomialEqualityComparer());
        }

        [Fact]
        public void MultiplyPolynomials()
        {
            Polynomial polynomial1 = new Polynomial(3, 6, 4, 1);
            Polynomial polynomial2 = new Polynomial(6, 4, 4);

            //arrange
            Polynomial arrange = new Polynomial(18, 48, 60, 46, 20, 4);

            //actual
            Polynomial actual = polynomial1 * polynomial2;

            //assert
            Assert.Equal(arrange, actual, new PolynomialEqualityComparer());
        }
    }
}
