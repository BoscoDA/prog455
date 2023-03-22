using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AssignmentDesignPatterns.Models
{
    public class Mansion
    {
        public string name { get; set; }
        public int currentFloor { get; set; }
        public List<IFloor> floors;

        public Mansion() 
        {
            name = "The Mansion";
            currentFloor = 1;
            floors = new List<IFloor>();

            for(int i = 1; i < 7; i++)
            {
                floors.Add(FloorFactory.CreateFloor(FloorType.MANSION, i));
            }
        }

        /// <summary>
        /// Return string of current floor information
        /// </summary>
        /// <returns></returns>
        public string DisplayFloor()
        {
            return $"Floor: {floors[currentFloor - 1].FloorNumber} - {floors[currentFloor - 1].Name} \n\n";
        }

        /// <summary>
        /// Returns string of riddle information for the current floor
        /// </summary>
        /// <returns></returns>
        public string DisplayFloorRiddle()
        {
            return $"{floors[currentFloor - 1].Riddle.PresentRiddle()}{Environment.NewLine}";
        }

        /// <summary>
        /// Gets a usable instance of the item on the current floor
        /// </summary>
        /// <returns></returns>
        public IItem GetItem()
        {
            return ((MansionFloor)floors[currentFloor-1]).item;
        }

        /// <summary>
        /// Gets the answer to the riddle on the current floor
        /// </summary>
        /// <returns></returns>
        public int GetRiddleAnswer()
        {
            return floors[currentFloor-1].Riddle.GetAnswer();
        }

        /// <summary>
        /// Increments the current floor property
        /// </summary>
        public void LoadNextFloor()
        {
            currentFloor++;
        }
    }
}
