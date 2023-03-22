using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Week8AssignmentDesignPatterns.Models.Riddle
{
    public class InfoBank
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
            {1, ItemFactory.CreateItem("Heart Key", "A key that has a red heart on its top", ItemFactory.ItemType.KEY) },
            {2, ItemFactory.CreateItem("Human Eyeball", "A goopy rotting human eyeball", ItemFactory.ItemType.EYEBALL) },
            {3, ItemFactory.CreateItem("Sapde Key", "A key that has a purple spade on its top", ItemFactory.ItemType.KEY) },
            {4, ItemFactory.CreateItem("Red Potion", "A glass vial with a mysterious red liquid inside.", ItemFactory.ItemType.POTION) },
            {5, ItemFactory.CreateItem("Blue Potion", "A glass vial with a mysterious blue liquid inside.", ItemFactory.ItemType.POTION) },
            {6, ItemFactory.CreateItem("Fish Eyeball", "A fresh fish eyeball", ItemFactory.ItemType.EYEBALL) }

        };

        public RiddleType GetRiddleType(int floorNumber)
        {
            return FloorsRiddleType[floorNumber];
        }

        public Dictionary<int, string> Riddles = new Dictionary<int, string>()
        {
            {1, "What has roots as nobody sees,\r\nIs taller than trees,\r\nUp, up it goes,\r\nAnd yet never grows?" },
            {2, "If p=false and q=true then what is the value of p=>q?" },
            {3, "Voiceless it cries,\r\nWingless flutters,\r\nToothless bites,\r\nMouthless mutters." },
            {4, "Every aniaml with a tail is a dog." },
            {5, "Alive without breath,\r\nAs cold as death;\r\nNever thirsty, ever drinking,\r\nAll in mail never clinking." },
            {6, "3 is a prime number." }
        };

        public Dictionary<int, int> RiddleAnswers = new Dictionary<int, int>()
        {
            {1, 3},
            {2, 1},
            {3, 4},
            {4, 2},
            {5, 2},
            {6, 1}
        };

        public Dictionary<int, List<string>> RiddleChoices = new Dictionary<int, List<string>>()
        {
            {0, new List<string>(){"True", "False" } },
            {1, new List<string>(){"Fish", "Tree", "Mountain", "Time" } },
            {3, new List<string>(){ "Water", "Air", "Sound", "Wind" } },
            {5, new List<string>(){ "River", "Fish", "Frog", "Snail" }}
        };

        public string GetRiddle(int riddleNum)
        {
            return Riddles[riddleNum];
        }

        public int GetAnswer(int riddleNum)
        {
            return RiddleAnswers[riddleNum];   
        }

        public List<string> GetChoices(int riddleNum, RiddleType type)
        {
            switch (type)
            {
                case RiddleType.MC:
                    return RiddleChoices[riddleNum];

                case RiddleType.TF:
                    return RiddleChoices[0];

                default: throw new ArgumentException("Invalid Floor Type");
            }
            
        }
    }

    public enum RiddleType
    {
        MC,
        TF
    }
}
