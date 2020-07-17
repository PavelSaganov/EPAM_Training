using Exercise_3__Products_;
using Xunit;

namespace SecondTask.Tests
{
    public class Exercise3Tests
    {
        [Fact]
        public void Converting_CheeseCost_37and52_to_int()
        {
            //arrange
            Cheese cheese = new Cheese("Bree", "Parmesan Luigi", 37.52);
            int arrange = 52;

            //actual
            int actual = (int)cheese;

            //assert
            Assert.Equal(arrange, actual);
        }

        [Fact]
        public void Converting_CheeseCost_37and52_to_double()
        {
            //arrange
            Cheese cheese = new Cheese("Bree", "Parmesan Luigi", 37.52);
            double arrange = 37.52;

            //actual
            double actual = (double)cheese;

            //assert
            Assert.Equal(arrange, actual);
        }

        [Fact]
        public void Converting_CheeseToBread()
        {
            Cheese cheese = new Cheese("Bree", "Parmesan Luigi", 37.52);

            //actual
            Bread actual = cheese;

            //assert
            Assert.IsType<Bread>(actual);
        }

        [Fact]
        public void SummingCoconuts()
        {
            //arrange
            Coconut coconut = new Coconut("Common", "Coconaut", 40);
            Coconut coconut2 = new Coconut("Common", "HardNutToCrack", 20);

            //actual
            Coconut actual = coconut + coconut2;
            bool condition = ("Coconaut-HardNutToCrack" == actual.Name && 30 == actual.Cost);

            //assert
            Assert.True(condition);
        }
    }
}
