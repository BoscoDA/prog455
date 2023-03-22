using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AssignmentDesignPatterns.Models
{
    public abstract class FloorBase : IFloor
    {
        public string Name { get; set; }
        public int FloorNumber { get; set; }
        public Riddle.Riddle Riddle { get; set; }
    }
}
