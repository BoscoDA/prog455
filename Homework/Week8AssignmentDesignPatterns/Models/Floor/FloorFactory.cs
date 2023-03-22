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
        public static IFloor CreateFloor( FloorType type, int floorNumber)
        {
            IFloor floor;
            InfoBank database = new InfoBank();

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
