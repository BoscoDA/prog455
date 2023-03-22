using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Enums;
using Week8AssignmentDesignPatterns.Models.Riddles;

namespace Week8AssignmentDesignPatterns.Models.Riddle
{
    public class TrueFalse : Riddle
    {
        private int RiddleNumber;
        private QuestionDataBank bank;
        private List<string> choices;

        public TrueFalse(int riddleNum)
        {
            RiddleNumber = riddleNum;
            bank = new QuestionDataBank();
            choices = new List<string>();

            choices.Add("True");
            choices.Add("False");
        }

        public override string PresentRiddle()
        {
            RiddlePrompt = bank.GetRiddle(RiddleNumber, RiddleType.TF);

            StringBuilder sb = new StringBuilder();
            sb.Append(RiddlePrompt + "\n");
            for(int i =0; i < 2; i++)
            {
                sb.Append($"\n{i+1}.) {choices[i]}");
            }

            return sb.ToString();
        }

        public override int GetAnswer()
        {
            return bank.GetAnswer(RiddleNumber);
        }
    }
}
