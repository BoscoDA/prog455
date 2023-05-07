using APIService;
using APIService.DALs;
using APIService.Models;
using Autofac.Extras.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTest.APIServiceTests
{
    public class AuthServiceTests
    {
        [Theory]
        [InlineData("billy1234")]
        [InlineData("johndoe34")]
        [InlineData("superHacker1")]
        public void UsernameExist_ReturnsTrue(string input)
        {
            List<UserRecordModel> users = new List<UserRecordModel>();
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IUserDAL>()
                    .Setup(x => x.GetByUsername(input)).Returns(users);

                var cls = mock.Create<IUserDAL>();

                var service = new AuthService(cls);

                var result = service.UsernameExist(input);

                Assert.True(result);
            }
        }

        [Theory]
        [InlineData("billy1234")]
        [InlineData("johndoe34")]
        [InlineData("superHacker1")]
        public void UsernameExist_ReturnsFalse(string input)
        {

            using (var mock = AutoMock.GetLoose())
            {

                List<UserRecordModel> users = new List<UserRecordModel>
                {
                    new UserRecordModel()
                    {
                        Username = input,
                        Password = "12312341341234",
                        Id = Guid.Empty,
                        Salt = "asdfasdfadsf"
                    }
                };
                mock.Mock<IUserDAL>()
                    .Setup(x => x.GetByUsername(input)).Returns(users);

                var cls = mock.Create<IUserDAL>();

                var service = new AuthService(cls);

                var result = service.UsernameExist(input);

                Assert.False(result);
            }
        }

        [Fact]
        public void AddUser_ReturnsGuid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var model = new UserRecordModel()
                {
                    Username = "JohnDoe",
                    Password = "12312341341234",
                    Id = Guid.Empty,
                    Salt = "asdfasdfadsf"
                };
                mock.Mock<IUserDAL>().Setup(x => x.InsertUser(model)).Returns(Guid.Empty);

                var cls = mock.Create<IUserDAL>();

                var service = new AuthService(cls);

                var result = service.AddUser(model);

                Assert.Equal(Guid.Empty, result);
            }
        }

        [Theory]
        [InlineData("ajksdfhkadfhadjk", "akjdhfklahsdfljka", "asdfasdf")]
        [InlineData("adsfadf", "akjdhfkvbnmcvnclahsdfljka","asdfadsfasdfasdf")]
        [InlineData("ajksdfhkadffdghdfghhadjk", "akjdhg245245g25gfklahsdfljka","asdfasdf")]
        [InlineData("ajksdfhkags3453245dfhadjk", "akjdhg46532653fklahsdfljka","asdfasdfda")]
        public void ValidLogin_ReturnsStringId(string password, string username, string salt)
        {
            using (var mock = AutoMock.GetLoose())
            {

                List<UserRecordModel> users = new List<UserRecordModel>
                {
                    new UserRecordModel()
                    {
                        Username = username,
                        Password = HashPasswordWithSalt(password,salt),
                        Id = Guid.Empty,
                        Salt = salt
                    }
                };
                mock.Mock<IUserDAL>()
                    .Setup(x => x.GetByUsername(username)).Returns(users);

                var cls = mock.Create<IUserDAL>();

                var service = new AuthService(cls);

                var result = service.ValidLogin(username, password);

                Assert.Equal(Guid.Empty.ToString(), result);
            }
        }

        public string HashPasswordWithSalt(string password, string salt)
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
