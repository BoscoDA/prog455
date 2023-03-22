using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Models;
using Week8AssignmentDesignPatterns.Models.Riddle;

namespace DesignPatternTests
{
    public class FloorTests
    {

        [Fact]
        public void MansionFloor_ConstructorMC_RiddleTypeOfMultipleChoice()
        {
            //arrange
            var riddle = RiddleType.MC;
            var floorNum = 1;

            //act
            var result = new MansionFloor(riddle, floorNum);

            //assert
            Assert.IsType<MultipleChoice>(result.Riddle);

        }

        [Fact]
        public void MansionFloor_ConstructorMC_RiddleTypeOfTrueFalse()
        {
            //arrange
            var riddle = RiddleType.TF;
            var floorNum = 1;

            //act
            var result = new MansionFloor(riddle, floorNum);

            //assert
            Assert.IsType<TrueFalse>(result.Riddle);

        }

        [Fact] 
        public void FloorFactory_CreateFloorMansion_ReturnsMansionFloor()
        {
            //arrange

            var floorNum = 1;
            var riddle = RiddleType.MC;

            //act
            var result = FloorFactory.CreateFloor(FloorType.MANSION, floorNum);

            //assert
            Assert.IsType<MansionFloor>(result);
        }
    }
}
