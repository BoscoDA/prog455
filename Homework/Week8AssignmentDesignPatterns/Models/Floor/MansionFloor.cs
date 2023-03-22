using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Models.Riddle;

namespace Week8AssignmentDesignPatterns.Models
{
    public class MansionFloor : FloorBase
    {
        public IItem item { get; set; }

        public MansionFloor(RiddleType type, int floorNum) 
        {
            if(type == RiddleType.MC)
            {
                Riddle = new MultipleChoice(floorNum);
            }
            else
            {
                Riddle = new TrueFalse(floorNum);
            }
        }
    }
}
