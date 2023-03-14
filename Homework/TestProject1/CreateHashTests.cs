using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Week7UnitTests;

namespace TestProject1
{
    public class CreateHashTests
    {
        //Write unit tests to test your utilities class, must contain at least 3 facts and
        //3 theories with 3 inline data elements for each method.

        Utilities util = new Utilities();

        [Fact]
        public void CreateHash_OutputType_OutputIsNotNull()
        {
            //Arrange
            util = new Utilities();
            var input = "password";

            //Act
            var result = util.CreateHash(input);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateHash_OutputType_OutputIsString()
        {
            //Arrange
            util = new Utilities();
            var input = "password";
            var expected = typeof(string);

            //Act
            var result = util.CreateHash(input);

            //Assert
            Assert.IsType(expected, result);
        }

        [Fact]
        public void CreateHash_InputEmpty_Returns64CharHash()
        {
            //Arrange
            util = new Utilities();
            var input = "";
            var expected = 64;

            //Act
            var result = util.CreateHash(input);

            //Assert
            Assert.Equal(expected, result.Length);
        }

        [Theory]
        [InlineData("password")]
        [InlineData("helloworld")]
        [InlineData("unittestsarefun")]
        public void CreateHash_OutputValue_NotEqualToInput(string input)
        {
            //Arrange
            util = new Utilities();

            //Act
            var result = util.CreateHash(input);

            //Assert
            Assert.NotEqual(input, result);
        }

        [Theory]
        [InlineData("password")]
        [InlineData("helloworld")]
        [InlineData("unittestsarefun")]
        public void CreateHash_OutputValue_SHA256Hash(string input)
        {
            //Arrange
            util = new Utilities();
            string expected;

            using (SHA256 hasher = SHA256.Create())
            {
                var bytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                expected = sb.ToString();
            }

            //Act
            var result = util.CreateHash(input);

            //Assert
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData("asdfqwererfgdsfvbsdfgdfgdfgaf")]
        [InlineData("asdfkjlasdhflasdf")]
        [InlineData("sadfqwerqwer")]
        public void CreateHash_HashLength_Hash64Characters(string input)
        {
            //Arrange
            util = new Utilities();
            var expected = 64;

            //Act
            var result = util.CreateHash(input);

            //Assert
            Assert.Equal(expected, result.Length);
        }

    }
}
