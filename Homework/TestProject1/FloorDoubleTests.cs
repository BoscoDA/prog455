using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7UnitTests;

namespace TestProject1
{
    public class FloorDoubleTests
    {
        //Write unit tests to test your utilities class, must contain at least 3 facts and
        //3 theories with 3 inline data elements for each method.

        Utilities util = new Utilities();

        [Fact]
        public void FloorDouble_InputNegativeDouble_InputFloor()
        {
            //Arrange
            util = new Utilities();
            var input = -6.17d;
            var expected = -7;
            //Act
            var result = util.FloorDouble(input);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FloorDouble_OutputType_TypeDouble()
        {
            //Arrange
            util = new Utilities();
            var input = 3.6d;
            var expected = typeof(double);
            //Act
            var result = util.FloorDouble(input);

            //Assert
            Assert.IsType(expected, result);
        }

        [Fact]
        public void FloorDouble_OutputType_NotNull()
        {
            //Arrange
            util = new Utilities();
            var input = 3.6d;
            //Act
            var result = util.FloorDouble(input).GetType();

            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(23.543345)]
        [InlineData(555555.345345345)]
        [InlineData(23452345.2345233452)]
        public void FloorDouble_InputPositiveDouble_InputFloor(double value)
        {
            //Arrange
            util = new Utilities();
            var expected = Math.Floor(value);
            //Act
            var result = util.FloorDouble(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-6)]
        [InlineData(-99)]
        [InlineData(-342)]
        public void FloorDouble_InputNegativeWholeNumber_Input(double value)
        {
            //Arrange
            util = new Utilities();
            var input = value;
            var expected = Math.Floor(value);
            //Act
            var result = util.FloorDouble(input);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(99)]
        [InlineData(342)]
        public void FloorDouble_InputPositiveWholeNumber_Input(double value)
        {
            //Arrange
            util = new Utilities();
            var input = value;
            var expected = Math.Floor(value);
            //Act
            var result = util.FloorDouble(input);

            //Assert
            Assert.Equal(expected, result);
        }

    }
}
