using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7UnitTests;

namespace TestProject1
{
    public class CreateDictionaryOfDivisorsTests
    {
        //Write unit tests to test your utilities class, must contain at least 3 facts and
        //3 theories with 3 inline data elements for each method.

        Utilities util = new Utilities();

        //Verfiy keys of the dictionary are odd numbers
        [Theory]
        [InlineData(324)]
        [InlineData(64)]
        [InlineData(72)]
        public void CreateDictionaryOfDivisors_DictionaryIndex_AreOdd(int input)
        {
            //Arrange

            //Act
            var result = util.CreateDictionaryOfDivisors(input);
            //Assert
            Assert.All(result, item => Assert.Equal(1, item.Key%2));
        }

        //Verify dictionary is the proper size
        [Theory]
        [InlineData(72)]
        [InlineData(5)]
        [InlineData(897)]
        public void CreateDictionaryOfDivisors_OutputSize_EqualsDivisorCount(int input)
        {
            //Arrange
            var expected = util.GenerateDivisors(input).Count();

            //Act
            var result = util.CreateDictionaryOfDivisors(input).Count();

            //Assert
            Assert.Equal(expected,result);
        }

        //Verfiy dicitnoary has proper elements
        [Theory]
        [InlineData(72)]
        [InlineData(5)]
        [InlineData(897)]
        public void CreateDictionaryOfDivisors_(int input)
        {
            //Arrange
            var expectedList = util.GenerateDivisors(input);
            var expectedDict = new Dictionary<int, int>();
            int index = 1;
            foreach(var div in expectedList)
            {
                expectedDict.Add(index, div);
                index += 2;
            }
            //Act
            var result = util.CreateDictionaryOfDivisors(input);

            //Assert
            Assert.Equal(expectedDict, result);
        }

        //Verfiy the return type if a dictinoary
        [Fact]
        public void CreateDictionaryOfDivisors_OutputValue_OfTypeDictionary()
        {
            //Arrange
            var input = 72;
            var expected = typeof(Dictionary<int, int>);

            //Act
            var result = util.CreateDictionaryOfDivisors(input);

            //Assert
            Assert.IsType(expected, result);
        }

        //verify the return is not null
        [Fact]
        public void CreateDictionaryOfDivisors_OutputValue_NotNull()
        {
            //Arrange
            var input = 72;

            //Act
            var result = util.CreateDictionaryOfDivisors(input);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateDictioanryOfDivisors_ResultForInputsWithAllPrimeDivisors_EmptyList()
        {
            //Arrange
            var input = 6;

            //Act
            var result = util.CreateDictionaryOfDivisors(input);

            //Assert
            Assert.Empty(result);
        }

    }
}
