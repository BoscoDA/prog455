using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Models.Riddle;

namespace Week8AssignmentDesignPatterns.Models
{
    public class FloorFactory
    {
        /// <summary>
        /// Factory method used for creating new objects that derive from the IFLoor interface.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="floorNumber"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IFloor CreateFloor( FloorType type, int floorNumber)
        {
            IFloor floor;
            FloorDataBank database = new FloorDataBank();

            switch (type)
            {
                case FloorType.MANSION:
                    floor = new MansionFloor(database.GetRiddleType(floorNumber),floorNumber);
                    ((MansionFloor)floor).item = database.Items[floorNumber];
                    break;

                default: throw new ArgumentException("Invalid Floor Type");
            }

            floor.Name = database.Floors[floorNumber];
            floor.FloorNumber = floorNumber;
            

            return floor;
        }
    }

    public enum FloorType
    {
        MANSION
    }
}
