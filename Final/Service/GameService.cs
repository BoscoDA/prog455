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

        public bool HasWin(string answer, string guess)
        {
            return answer.ToLower() == guess.ToLower();
        }

        public bool HasEnd(int count)
        {
            return count + 1 > maxGuess;
        }
    }
}
