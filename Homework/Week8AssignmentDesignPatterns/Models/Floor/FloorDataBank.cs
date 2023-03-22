using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Enums;

namespace Week8AssignmentDesignPatterns.Models.Riddle
{
    public class FloorDataBank
    {
        public Dictionary<int, string> Floors = new Dictionary<int, string>()
        {
            {1, "Ground Floor" },
            {2, "Laboratory" },
            {3, "Study" },
            {4, "Living Quarters" },
            {5, "Servents Quarters" },
            {6, "Attic" }
        };

        public Dictionary<int, RiddleType> FloorsRiddleType = new Dictionary<int, RiddleType>()
        {
            {1, RiddleType.MC },
            {2, RiddleType.TF },
            {3, RiddleType.MC },
            {4, RiddleType.TF },
            {5, RiddleType.MC },
            {6, RiddleType.TF }
        };

        public Dictionary<int, IItem> Items = new Dictionary<int, IItem>()
        {
            {1, ItemFactory.CreateItem("Heart Key", "A key that has a red heart on its top", ItemType.KEY) },
            {2, ItemFactory.CreateItem("Human Eyeball", "A goopy rotting human eyeball", ItemType.EYEBALL) },
            {3, ItemFactory.CreateItem("Sapde Key", "A key that has a purple spade on its top", ItemType.KEY) },
            {4, ItemFactory.CreateItem("Red Potion", "A glass vial with a mysterious red liquid inside.", ItemType.POTION) },
            {5, ItemFactory.CreateItem("Blue Potion", "A glass vial with a mysterious blue liquid inside.", ItemType.POTION) },
            {6, ItemFactory.CreateItem("Fish Eyeball", "A fresh fish eyeball", ItemType.EYEBALL) }

        };

        /// <summary>
        /// Retrieves and returns the proper RiddleType that the floor specified by the floor number inputted has.
        /// </summary>
        /// <param name="floorNumber"></param>
        /// <returns></returns>
        public RiddleType GetRiddleType(int floorNumber)
        {
            return FloorsRiddleType[floorNumber];
        }

    }
}
