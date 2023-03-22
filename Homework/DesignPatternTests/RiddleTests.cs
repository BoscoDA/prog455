using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Models.Riddle;

namespace DesignPatternTests
{
    public class RiddleTests
    {
        [Fact]
        public void Riddle_PresentRiddle_Equals()
        {
            //arrange
            var expected = "That should not have happened!";
            var riddle = new Riddle();
            //act
            var result = riddle.PresentRiddle();
            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultipleChoice_PresentRiddle_Equals()
        {
            //arrange
            var bank = new InfoBank();
            var RiddleNumber = 1;

            var riddle = new MultipleChoice(RiddleNumber);

            var RiddlePrompt = bank.GetRiddle(RiddleNumber);
            var Choices = bank.GetChoices(RiddleNumber, RiddleType.MC);

            StringBuilder sb = new StringBuilder();
            sb.Append(RiddlePrompt + "\n");

            for (int i = 0; i < Choices.Count; i++)
            {
                sb.Append($"\n{i + 1}.) {Choices[i]}");
            }

            var expected = sb.ToString();

            //act
            var result = riddle.PresentRiddle();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultipleChoice_GetAnswer_Equals()
        {
            //arrange
            var bank = new InfoBank();
            var RiddleNumber = 1;

            var riddle = new MultipleChoice(RiddleNumber);

            var expected = bank.GetAnswer(RiddleNumber);

            //act
            var result = riddle.GetAnswer();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TrueFalse_PresentRiddle_Equals()
        {
            //arrange
            var bank = new InfoBank();
            var RiddleNumber = 1;

            var riddle = new TrueFalse(RiddleNumber);

            var RiddlePrompt = bank.GetRiddle(RiddleNumber);
            var Choices = bank.RiddleChoices[0];

            StringBuilder sb = new StringBuilder();
            sb.Append(RiddlePrompt + "\n");

            for (int i = 0; i < Choices.Count; i++)
            {
                sb.Append($"\n{i + 1}.) {Choices[i]}");
            }

            var expected = sb.ToString();

            //act
            var result = riddle.PresentRiddle();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TrueFalse_GetAnswer_Equals()
        {
            //arrange
            var bank = new InfoBank();
            var RiddleNumber = 1;

            var riddle = new TrueFalse(RiddleNumber);

            var expected = bank.GetAnswer(RiddleNumber);

            //act
            var result = riddle.GetAnswer();

            //assert
            Assert.Equal(expected, result);
        }
    }
}
