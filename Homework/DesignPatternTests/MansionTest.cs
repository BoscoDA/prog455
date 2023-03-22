using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns;
using Week8AssignmentDesignPatterns.Models;

namespace DesignPatternTests
{
    public class MansionTest
    {
        [Fact]
        public void Mansion_Constructor_NotNull()
        {
            //arrange


            //act
            var result = new Mansion();

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Mansion_GetItem_ReturnsIItem()
        {
            //arrange
            var expected = typeof(IItem);
            var mansion = new Mansion();
            //act
            var actual = mansion.GetItem();

            //assert
            Assert.IsAssignableFrom<IItem>(actual);
        }

        [Fact]
        public void Mansion_GetAnswer_ReturnsInt()
        {
            //arrange
            var expected = typeof(int);
            var mansion = new Mansion();
            //act
            var actual = mansion.GetRiddleAnswer();

            //assert
            Assert.IsType<int>(actual);
        }

        [Fact]
        public void Mansion_LoadNextFloor_IncrementFloorNum() 
        {
            //arrange
            var expected = 2;
            var mansion = new Mansion();
            //act
            mansion.LoadNextFloor();
            //assert
            Assert.Equal(expected, mansion.currentFloor);
        }

        [Fact]
        public void Mansion_DisplayFloor_OutputString()
        {
            //arrange
            var floor = FloorFactory.CreateFloor(FloorType.MANSION, 1);
            var mansion = new Mansion();

            var expected = $"Floor: {floor.FloorNumber} - {floor.Name} \n\n";

            //act
            var result = mansion.DisplayFloor();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Mansion_DisplayFloorRiddle_OutputString()
        {
            //arrange
            var floor = FloorFactory.CreateFloor(FloorType.MANSION, 1);
            var mansion = new Mansion();

            var expected = $"{floor.Riddle.PresentRiddle()}{Environment.NewLine}";

            //act
            var result = mansion.DisplayFloorRiddle();

            //assert
            Assert.Equal(expected, result);
        }
    }
}
