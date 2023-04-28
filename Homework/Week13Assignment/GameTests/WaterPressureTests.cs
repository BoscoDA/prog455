using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10DesignPatternII.Models;

namespace DesignPatternsIITests
{
    public class WaterPressureTests
    {
        [Fact]
        public void WaterPressure_Attach_Equal()
        {
            //arrange
            WaterPressure pressure = new WaterPressure();
            Character character = new Character();

            var expected = 1;
            //act
            pressure.Attach(character);
            //assert

            Assert.Equal(expected, pressure.characters.Count);
        }

        [Fact]
        public void WaterPressure_Remove_Equal()
        {
            //arrange
            WaterPressure pressure = new WaterPressure();
            Character character1 = new Character();
            Character character2 = new Character();
            pressure.Attach(character1);
            pressure.Attach(character2);

            var expected = 1;
            //act
            pressure.Remove(character1);

            //assert
            Assert.Equal(expected, pressure.characters.Count);
        }

        [Fact]
        public void WaterPressure_RemoveProperElement_ContainsExpectedCharacter()
        {
            //arrange
            WaterPressure pressure = new WaterPressure();
            Character character1 = new Character();
            Character character2 = new Character();
            pressure.Attach(character1);
            pressure.Attach(character2);

            var expected = 1;
            //act
            pressure.Remove(character1);

            //assert
            Assert.Contains(character2,pressure.characters);
        }

        [Fact]
        public void WaterPressure_NotifyDamageSet_True()
        {
            //arrange
            WaterPressure pressure = new WaterPressure();
            Character character1 = new Character();
            character1.UniformColor = ConsoleColor.White;
            character1.DepthDived = 200;
            pressure.Attach(character1);
            pressure.minDamage = 1;
            pressure.maxDamage = 6;
            //act
            pressure.Notify();
            //assert
            Assert.True(pressure.actualWaterPressureDamage > 0);
        }

        [Fact]
        public void WaterPressure_NotifyCharacterUpdates_True()
        {
            //arrange
            WaterPressure pressure = new WaterPressure();
            Character character1 = new Character();
            var expected = 100;
            character1.UniformColor = ConsoleColor.White;
            character1.DepthDived = 200;
            pressure.Attach(character1);
            pressure.minDamage = 1;
            pressure.maxDamage = 6;
            //act
            pressure.Notify();
            //assert
            Assert.True(character1.HP < expected);
        }

        [Fact]
        public void WaterPressure_DealDamageMinDamageSet_Equal()
        {
            //arrange
            WaterPressure pressure = new WaterPressure();

            var expected = 1;
            //act
            pressure.DealDamage();
            //assert

            Assert.Equal(expected, pressure.minDamage);
        }

        [Fact]
        public void WaterPressure_DealDamageMaxDamageSet_Equal()
        {
            //arrange
            WaterPressure pressure = new WaterPressure();

            var expected = 6;
            //act
            pressure.DealDamage();
            //assert
            Assert.Equal(expected, pressure.maxDamage);
        }
    }
}
