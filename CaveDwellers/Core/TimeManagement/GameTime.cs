using System;

namespace CaveDwellers.Core.TimeManagement
{
    public class GameTime
    {
        public GameTime(DateTime now, int milliseconds)
        {
            Time = now;
            MillisecondsElapsed = milliseconds;
        }

        public DateTime Time { get; private set; }
        public int MillisecondsElapsed { get; private set; }
    }
}