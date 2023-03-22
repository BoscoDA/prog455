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

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Floor Number: {floor.FloorNumber} | {floor.Name} \n\n");
            stringBuilder.Append($"{floor.Riddle.PresentRiddle()}{Environment.NewLine}");

            var expected = stringBuilder.ToString();

            //act
            var result = mansion.DisplayFloor();

            //assert
            Assert.Equal(expected, result);

        }
    }
}
