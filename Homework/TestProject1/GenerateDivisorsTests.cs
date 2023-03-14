using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7UnitTests;

namespace TestProject1
{
    public class GenerateDivisorsTests
    {
        //Write unit tests to test your utilities class, must contain at least 3 facts and
        //3 theories with 3 inline data elements for each method.

        Utilities util = new Utilities();

        [Fact]
        public void GenerateDivisors_NegativeInput_AllPositiveDivisors()
        {
            //Arrange
            util = new Utilities();
            var input = -36;
            var expected = new List<int>() { 4,6,9,12,18,36};

            //Act
            var result = util.GenerateDivisors(input);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GenerateDivisors_EachOutputElement_IsADivisor()
        {
            //Arrange
            util = new Utilities();
            var input = 72;
            //Act
            var result = util.GenerateDivisors(input);
            //Assert 
            Assert.All(result, item => Assert.Equal(0, input%item));
        }

        [Fact]
        public void GenerateDivisors_OutpuOfInputWithAllPrimeDivisors_Empty()
        {
            //Arrange
            util = new Utilities();
            var input = 6;

            //Act
            var result = util.GenerateDivisors(input);

            //Arrange
            Assert.Empty(result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(73)]
        public void GenerateDivisors_OutputWithPrimeInput_EmptyList(int input)
        {
            //Arrange
            util = new Utilities();

            //Act
            var result = util.GenerateDivisors(input);

            //Assert
            Assert.Empty(result);
        }

        [Theory]
        [InlineData(24)]
        [InlineData(72)]
        [InlineData(16)]
        public void GenerateDivisors_OutputWithInputWithCompositeFactors_NotEmptyList(int input)
        {
            //Arrange
            util = new Utilities();

            //Act
            var result = util.GenerateDivisors(input);

            //Assert
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(234)]
        [InlineData(36)]
        [InlineData(72)]
        public void GenerateDivisors_OutputSize_ProperListSize(int input)
        {
            //Arrange
            util = new Utilities();
            //Act
            var result = util.GenerateDivisors(input);

            //Assert
            Assert.NotEmpty(result);
        }
    }
}
