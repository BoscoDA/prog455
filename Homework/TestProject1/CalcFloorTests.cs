using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7UnitTests;

namespace TestProject1
{
    public class CalcFloorTests
    {
        //Write unit tests to test your utilities class, must contain at least 3 facts and
        //3 theories with 3 inline data elements for each method.

        Utilities util = new Utilities();

        [Fact]
        public void CalcFloor_ReturnType_IsDouble()
        {
            //Arrange
            util = new Utilities();
            var inputA = 54;
            var inputB = 4;

            var expected = typeof(double);
            //Act
            var result = util.CalcFloor(inputA, inputB);

            //Assert
            Assert.IsType(expected, result);
        }

        [Fact]
        public void CalcFloor_ReturnValue_NotNull()
        {
            //Arrange
            util = new Utilities();
            var inputA = 54;
            var inputB = 4;

            //Act
            var result = util.CalcFloor(inputA, inputB);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void CalcFloor_TwoNegativeIntInputs_Equal()
        {
            //Arrange
            int inputA = -15;
            int inputB = -5;
            double input = inputB / inputA;
            double expected = Math.Floor(input);

            //Act
            var result = util.CalcFloor(inputA, inputB);

            //Assert
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData(12,43)]
        [InlineData(21, 3)]
        [InlineData(300,4)]
        public void CalcFloor_OutputSmallOverBig_NotEqual(int a, int b)
        {
            //Arrange
            util = new Utilities();
            double numerator = a < b ? a : b;
            double denominator = a < b ? b : a;
            var expected = Math.Floor(numerator / denominator);
            //Act
            var result = util.CalcFloor(a, b);

            //Assert
            Assert.NotEqual(expected, result);
        }

        [Theory]
        [InlineData(54, 43)]
        [InlineData(21, 3)]
        [InlineData(300, 4)]
        public void CalcFloor_OutputFloor_Equal(int a, int b)
        {
            //Arrange
            util = new Utilities();
            double numerator = a > b ? a : b;
            double denominator = a > b ? b : a;
            var expected = Math.Floor(numerator / denominator);
            //Act
            var result = util.CalcFloor(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-12,24)]
        [InlineData(45,-80)]
        [InlineData(-6,-8)]
        public void CalcFloor_MixedSignedInputs_Equal(int a, int b)
        {
            //Arrange
            util = new Utilities();
            double numerator = a > b ? a : b;
            double denominator = a > b ? b : a;
            var expected = Math.Floor(numerator / denominator);
            //Act
            var result = util.CalcFloor(a, b);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
