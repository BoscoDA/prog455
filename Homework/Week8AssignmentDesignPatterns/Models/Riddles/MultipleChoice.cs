using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Enums;
using Week8AssignmentDesignPatterns.Models.Riddles;

namespace Week8AssignmentDesignPatterns.Models.Riddle
{
    public class MultipleChoice : Riddle
    {
        private int RiddleNumber;
        private QuestionDataBank bank;
        private List<string> Choices;

        public MultipleChoice(int riddleNum)
        {
            RiddleNumber = riddleNum;
            bank = new QuestionDataBank();
            Choices = new List<string>();
        }

        /// <summary>
        /// Adapter for the QuestionDatabank to allow function with objects of type Riddle
        /// </summary>
        /// <returns></returns>
        public override string PresentRiddle()
        {
            RiddlePrompt = bank.GetRiddle(RiddleNumber, RiddleType.MC);
            Choices = bank.GetChoices(RiddleNumber, RiddleType.MC);

            StringBuilder sb = new StringBuilder();
            sb.Append(RiddlePrompt+"\n");

            for (int i = 0; i < Choices.Count; i++)
            {
                sb.Append($"\n{i+1}.) {Choices[i]}");
            }
            

            return sb.ToString();
        }

        /// <summary>
        /// Adapter for the QuestionDatabank to return the answer of the riddle
        /// </summary>
        /// <returns></returns>
        public override int GetAnswer()
        {
            return bank.GetAnswer(RiddleNumber);
        }
    }
}
