using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7UnitTests;

namespace TestProject1
{
    public class IsPrimeTests
    {
        //Write unit tests to test your utilities class, must contain at least 3 facts and
        //3 theories with 3 inline data elements for each method.

        Utilities util = new Utilities();

        [Fact]
        public void IsPrime_OutputValue_IsNotNull()
        {
            //Arrange
            util = new Utilities();
            var input = 7;

            //Act
            var result = util.IsPrime(input);

            //Assert
            Assert.NotNull(result);

        }

        [Fact]
        public void IsPrime_OutputType_TypeIsBool()
        {
            //Arrange
            util = new Utilities();
            var input = 7;
            var expected = typeof(bool);

            //Act
            var result = util.IsPrime(input);

            //Assert
            Assert.IsType(expected, result);

        }

        [Fact]
        public void IsPrime_InputZero_False()
        {
            //Arrange
            util = new Utilities();
            var input = 0;

            //Act
            var result = util.IsPrime(input);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(73)]
        [InlineData(2)]
        public void IsPrime_OutputValuePrimeNum_True(int input)
        {
            //Arrange
            util = new Utilities();

            //Act
            var result = util.IsPrime(input);

            //Assert
            Assert.True(result);

        }

        [Theory]
        [InlineData(10)]
        [InlineData(55)]
        [InlineData(25)]
        public void IsPrime_OutputValueComposNum_False(int input)
        {
            //Arrange
            util = new Utilities();

            //Act
            var result = util.IsPrime(input);

            //Assert
            Assert.False(result);

        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-55)]
        [InlineData(-25)]
        public void IsPrime_InputNegativenumber_False(int input)
        {
            //Arrange
            util = new Utilities();

            //Act
            var result = util.IsPrime(input);

            //Assert
            Assert.False(result);

        }
    }
}
