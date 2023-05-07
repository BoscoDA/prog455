using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTest.ServiceTests
{
    public class GameServiceTests
    {
        [Theory]
        [InlineData("Charizard", "charIZard")]
        [InlineData("Charizard", "CHARIZARD")]
        [InlineData("Charizard", "charizard")]
        public void HasWin_ReturnsTrue_WhenAnswerAndGuessAreEqualIgnoringCase(string answer, string guess)
        {
            //arrange
            GameService gameService = new GameService();

            //act
            bool result = gameService.HasWin(answer, guess);

            //assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("Ditto", "GeNgaR")]
        [InlineData("Ditto", "gengar")]
        [InlineData("Ditto", "GENGAR")]
        public void HasWin_ReturnsFalse_WhenAnswerAndGuessAreNotEqualIgnoringCase(string answer, string guess)
        {
            //arrange
            GameService gameService = new GameService();

            //act
            bool result = gameService.HasWin(answer, guess);

            //assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void HasEnd_ReturnsTrue_WhenCountIsEqualToOrGreaterThanMaxGuess(int count)
        {

            //arrange
            GameService gameService = new GameService();

            //act
            bool result = gameService.HasEnd(count);

            //assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void HasEnd_ReturnsFalse_WhenCountIsLessThanMaxGuess(int count)
        {
            //arrange
            GameService gameService = new GameService();

            //act
            bool result = gameService.HasEnd(count);

            //assert
            Assert.False(result);
        }
    }
}
