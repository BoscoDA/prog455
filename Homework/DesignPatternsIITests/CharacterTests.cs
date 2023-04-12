using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10DesignPatternII.Models;

namespace DesignPatternsIITests
{
    public class CharacterTests
    {
        [Fact]
        public void Character_Constructor_NotNull()
        {
            //arrange
            Character character;
            //act
            character = new Character();
            //assert
            Assert.NotNull(character);
        }

        [Fact]
        public void Character_ConstructorDefaultHP_Equal()
        {
            //arrange
            Character character;
            int expected = 100;
            //act
            character = new Character();
            //assert
            Assert.Equal(expected, character.HP);
        }

        [Fact]
        public void Character_ConstructorInventory_NotNull()
        {
            //arrange
            Character character;
            //act
            character = new Character();
            //assert
            Assert.NotNull(character.Inventory);
        }

        [Fact]
        public void Character_ConstructorDefaultWeight_Equal()
        {
            //arrange
            Character character;
            var expected = 100;
            //act
            character = new Character();
            //assert
            Assert.Equal(expected, character.Weight);
        }

        [Fact]
        public void Character_ConstructorDefaultDepthDived_Equal()
        {
            //arrange
            Character character;
            var expected = 0;
            //act
            character = new Character();
            //assert
            Assert.Equal(expected, character.DepthDived);
        }

        [Fact]
        public void Character_UpdateHPChange_Equal()
        {
            //arrange
            Character character = new Character();
            character.UniformColor = ConsoleColor.DarkRed;
            WaterPressure pressure = new WaterPressure();
            var expected = 20;
            var hpBefore = character.HP;
            pressure.Attach(character);
            pressure.actualWaterPressureDamage = expected;
            //act
            character.Update(pressure);
            //assert
            Assert.Equal(expected, hpBefore - character.HP);
        }
    }
}
