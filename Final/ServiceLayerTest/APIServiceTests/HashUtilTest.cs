using APIService.Utilities;
using System.Security.Cryptography;
using System.Text;

namespace ServiceLayerTest.APIServiceTests
{
    public class HashUtilTest
    {

        [Fact]
        public void CheckPassword_ReturnsTrue_WhenPasswordAndHashMatch()
        {
            // Arrange
            string password = "myPassword123!";
            string salt = "mySalt";

            string expectedHashword = GenerateHash(password, salt);

            // Act
            bool result = HashUtil.CheckPassword(password, salt, expectedHashword);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckPassword_ReturnsFalse_WhenPasswordAndHashDoNotMatch()
        {
            // Arrange
            // Arrange
            string password = "myPassword123!";
            string salt = "mySalt";

            string expectedHashword = GenerateHash(password, salt);

            // Act
            bool result = HashUtil.CheckPassword(password, "wrongsalt", expectedHashword);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GenerateSalt_ReturnsSaltWithExpectedLength()
        {
            // Arrange
            int expectedLength = 64;

            // Act
            string salt = HashUtil.GenerateSalt();

            // Assert
            Assert.Equal(expectedLength, salt.Length);
        }

        [Fact]
        public void GenerateSalt_ReturnsUniqueSaltsOnMultipleCalls()
        {
            // Arrange
            int numCalls = 100;
            string[] salts = new string[numCalls];

            // Act
            for (int i = 0; i < numCalls; i++)
            {
                salts[i] = HashUtil.GenerateSalt();
            }

            // Assert
            Assert.Equal(numCalls, salts.Distinct().Count());
        }

        public string GenerateHash(string password, string salt)
        {
            byte[] byteword = Encoding.Unicode.GetBytes(salt + password);
            SHA512 sha512 = SHA512.Create();
            byteword = sha512.ComputeHash(byteword);

            StringBuilder result = new StringBuilder();
            foreach (byte b in byteword)
            {
                result.Append(b.ToString("x2"));
            }
            return result.ToString();
        }
    }
}