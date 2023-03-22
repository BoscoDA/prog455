﻿using System;
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

        public override int GetAnswer()
        {
            return bank.GetAnswer(RiddleNumber);
        }
    }
}