using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AssignmentDesignPatterns.Models.Riddle
{
    public class Riddle
    {
        protected string RiddlePrompt;
        protected int RiddleAnswer;

        public virtual string PresentRiddle()
        {
            return "That should not have happened!";
        }

        public virtual int GetAnswer()
        {
            return RiddleAnswer;
        }
    }
}
