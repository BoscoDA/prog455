using Week7UnitTests;

namespace TestProject1
{
    public class JoinNameTests
    {
        //Write unit tests to test your utilities class, must contain at least 3 facts and
        //3 theories with 3 inline data elements for each method.

        Utilities util = new Utilities();

        [Fact]
        public void JoinName_OutputType_OutputNotNull()
        {
            //Arrange
            util = new Utilities();
            var firstName = "John";
            var lastName = "Doe";

            //Act
            var result = util.JoinName(firstName, lastName);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void JoinName_OutputType_ReturnsString()
        {
            //Arrange
            util = new Utilities();
            var firstName = "John";
            var lastName = "Doe";
            var expected = typeof(string);
            //Act
            var result = util.JoinName(firstName, lastName);

            //Assert
            Assert.IsType(expected, result);
        }

        [Fact]
        public void JoinName_OutputFormat_FormatFirstnameLastname()
        {
            //Arrange
            util = new Utilities();
            var firstName = "John";
            var lastName = "Doe";
            var expected = firstName + ',' + lastName;
            //Act
            var result = util.JoinName(firstName, lastName);

            //Assert

            //Verify firstname is first
            Assert.Equal(firstName, result.Substring(0,firstName.Length));

            //Verify lastname is second
            Assert.Equal(lastName, result.Substring(firstName.Length+1, lastName.Length));
        }

        [Theory]
        [InlineData("John", "Doe", ",")]
        [InlineData("Jane", "Doe", ",")]
        [InlineData("Janice", "Doe", ",")]
        public void JoinName_DelimitirCharacter_DelimitirIsComma(string firstname, string lastname, string delimitir)
        {
            //Arrange
            util = new Utilities();
            var expected = delimitir;
            //Act
            var resultString = util.JoinName(firstname, lastname);
            var result = resultString.Substring(firstname.Length, 1);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("John", "", ",")]
        [InlineData("Jane", "", ",")]
        [InlineData("Janice", "", ",")]
        public void JoinName_EmptyLastNameInput_ReturnDefault(string firstname, string lastname, string delimitir)
        {
            //Arrange
            util = new Utilities();
            var expected = firstname + delimitir + "Doe";
            //Act
            var result = util.JoinName(firstname, lastname);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", "Donaldson", ",")]
        [InlineData("", "Jackson", ",")]
        [InlineData("", "Murray", ",")]
        public void JoinName_EmptyFirstNameInput_ReturnDefault(string firstname, string lastname, string delimitir)
        {
            //Arrange
            util = new Utilities();
            var expected = "John" + delimitir + lastname;
            //Act
            var result = util.JoinName(firstname, lastname);

            //Assert
            Assert.Equal(expected, result);
        }


    }
}