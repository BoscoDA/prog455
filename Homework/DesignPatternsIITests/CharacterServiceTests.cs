using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10DesignPatternII.Models;
using Week10DesignPatternII.Models.Items;
using Week10DesignPatternII.Services;

namespace DesignPatternsIITests
{
    public class CharacterServiceTests
    {
        [Theory]
        [InlineData("Bill")]
        [InlineData("Ted")]
        [InlineData("Steve")]
        public void CharacterService_SetName_Equal(string input)
        {
            //arrange
            Character character = new Character();
            CharacterService service = new CharacterService();
            //act
            service.SetName(input, character);
            //assert
            Assert.Equal(input, character.Name);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        public void CharacterService_SetJerseyColor_Equal(string input)
        {
            //arrange
            Character character = new Character();
            CharacterService service = new CharacterService();
            var inputToInt = Convert.ToInt32(input);
            var expected = (ConsoleColor)inputToInt;
            //act
            service.SetJerseyColor(input, character);
            //assert
            Assert.Equal(expected, character.UniformColor);
        }

        [Theory]
        [InlineData("Ruby")]
        [InlineData("Emerald")]
        [InlineData("Sapphire")]
        public void CharacterService_SetGem_Equal(string input)
        {
            //arrange
            Character character = new Character();
            CharacterService service = new CharacterService();
            //act
            service.SetGemStone(input, character);
            //assert
            Assert.Equal(input, character.GemStone);
        }

        [Fact]
        public void CharacterService_SetStatsBootWeight_Equal()
        {
            //arrange
            Item item = new Item("Test", "Test", 25, "Boot");
            Character character = new Character();
            character.Inventory.Add(item);
            CharacterService service = new CharacterService();

            var expected = 125;
            //act
            service.SetStats(character);
            //assert
            Assert.Equal(expected, character.Weight);
        }

        [Fact]
        public void CharacterService_SetStatsSuitWeight_Equal()
        {
            //arrange
            Item item = new Item("Test", "Test", 25, "Suit");
            Character character = new Character();
            character.Inventory.Add(item);
            CharacterService service = new CharacterService();

            var expected = 125;
            //act
            service.SetStats(character);
            //assert
            Assert.Equal(expected, character.Weight);
        }

        [Fact]
        public void CharacterService_SetStatsSuitHP_Equal()
        {
            //arrange
            Item item = new Item("Test", "Test", 25, "Suit");
            Character character = new Character();
            character.Inventory.Add(item);
            CharacterService service = new CharacterService();

            var expected = 125;
            //act
            service.SetStats(character);
            //assert
            Assert.Equal(expected, character.HP);
        }

        [Fact]
        public void CharacterService_ValidateCharacterAllErrors_Equal()
        {
            //arrange
            CharacterService service = new CharacterService();
            Character character = new Character();
            character.Inventory.Add(new Item("Test", "Test", 25, "Test"));
            character.Inventory.Add(new Item("Test", "Test", 25, "Test"));
            character.Inventory.Add(new Item("Test", "Test", 25, "Test"));

            var expected = 4;

            //act
            var result = service.ValidateCharacter(character).Count;
            //assert
            Assert.Equal(expected, result);
        }
    }
}
