using Exercise_3__Products_;
using System;
using Xunit;

namespace SecondTask.Tests
{
    public class Exercise3
    {
        [Fact]
        public void Converting_CheeseCost_37and52_to_int()
        {
            //arrange
            Cheese cheese = new Cheese("Bree", "Parmesan Luigi", 37.52);
            int arrange = 37;

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
    }
}
