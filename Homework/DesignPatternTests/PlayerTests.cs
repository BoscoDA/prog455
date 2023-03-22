using Week8AssignmentDesignPatterns;

namespace DesignPatternTests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_SingleInstance_Same()
        {
            //arrange
            var expected = Player.Instance();

            //act
            var result = Player.Instance();

            //assert
            Assert.Same(expected, result);
        }

        [Fact]
        public void LoseLife_DecrementLife_Equal()
        {
            //arrange
            var player = Player.Instance();
            var expected = 4;

            //act
            player.LoseLife();
            var result = player.Lives;

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Player_ConstructorSetLives_Equal()
        {
            //arrange
            var expected = 5;

            //act
            var player = Player.Instance();
            var result = player.Lives;

            //assert
            Assert.Equal(expected, result);

        }
    }
}