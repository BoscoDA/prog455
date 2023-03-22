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

        /// <summary>
        /// Outputs a string of the riddle
        /// </summary>
        /// <returns></returns>
        public virtual string PresentRiddle()
        {
            return "That should not have happened!";
        }

        /// <summary>
        /// Returns the answer to the riddle
        /// </summary>
        /// <returns></returns>
        public virtual int GetAnswer()
        {
            return RiddleAnswer;
        }
    }
}
