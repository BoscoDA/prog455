using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GameService
    {
        readonly int maxGuess = 4;

        /// <summary>
        /// Checks if the two strings passed in are equal to each other
        /// </summary>
        /// <param name="answer"></param>
        /// <param name="guess"></param>
        /// <returns>True if the string equal and false if they do not</returns>
        public bool HasWin(string answer, string guess)
        {
            return answer.ToLower() == guess.ToLower();
        }

        /// <summary>
        /// Checks if the number of guesses has met the maximun number of guesses
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool HasEnd(int count)
        {
            return count + 1 > maxGuess;
        }
    }
}
