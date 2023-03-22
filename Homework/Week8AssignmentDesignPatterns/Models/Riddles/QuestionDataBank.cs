using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Enums;

namespace Week8AssignmentDesignPatterns.Models.Riddles
{
    // Adaptee
    public class QuestionDataBank
    {
        public Dictionary<int, string> MultipleChoicePrompt = new Dictionary<int, string>()
        {
            {1, "What has roots as nobody sees,\r\nIs taller than trees,\r\nUp, up it goes,\r\nAnd yet never grows?" },
            {3, "Voiceless it cries,\r\nWingless flutters,\r\nToothless bites,\r\nMouthless mutters." },
            {5, "Alive without breath,\r\nAs cold as death;\r\nNever thirsty, ever drinking,\r\nAll in mail never clinking." }
        };

        public Dictionary<int, string> TrueFalsePrompt = new Dictionary<int, string>()
        {
            {2, "If p=false and q=true then what is the value of p=>q?" },
            {4, "Every aniaml with a tail is a dog." },
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

        /// <summary>
        /// Returns the riddle promt of the specified type of question
        /// </summary>
        /// <param name="riddleNum"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string GetRiddle(int riddleNum, RiddleType type)
        {
            switch (type)
            {
                case RiddleType.MC:
                    return MultipleChoicePrompt[riddleNum];
                case RiddleType.TF:
                    return TrueFalsePrompt[riddleNum];
                default: throw new ArgumentException("Invalid Riddle Type");
            }

        }

        /// <summary>
        /// Retrieves and returns the answer to the question
        /// </summary>
        /// <param name="riddleNum"></param>
        /// <returns></returns>
        public int GetAnswer(int riddleNum)
        {
            return RiddleAnswers[riddleNum];
        }

        /// <summary>
        /// Retrieves and returns the choices to the question
        /// </summary>
        /// <param name="riddleNum"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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

    
}
