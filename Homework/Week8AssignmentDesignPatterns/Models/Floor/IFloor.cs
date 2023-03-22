using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Models.Riddle;

namespace Week8AssignmentDesignPatterns.Models
{
    public interface IFloor
    {
        string Name { get; set; }
        int FloorNumber { get; set; }
        Riddle.Riddle Riddle { get; set; }
    }
}
