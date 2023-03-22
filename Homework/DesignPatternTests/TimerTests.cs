using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns;

namespace DesignPatternTests
{
    public class TimerTests
    {
        [Fact]
        public void Timer_SingleInstance_Same()
        {
            //arrange
            var expected = GameTimer.GetInstance;

            //act
            var result = GameTimer.GetInstance;

            //assert
            Assert.Same(expected, result);
        }

        [Fact]
        public void TimerFunctionality_StopwatchStartsAndStops()
        {
            //arrange
            var gameTimer = GameTimer.GetInstance;
            var input = 2000;
            var expected = new TimeSpan(0, 0, input / 1000).TotalSeconds;
            //act
            gameTimer.StartTimer();
            Thread.Sleep(input);
            gameTimer.StopTimer();
            //assert
            Assert.Equal(expected, gameTimer.GetTime().Seconds);

        }
    }
}
