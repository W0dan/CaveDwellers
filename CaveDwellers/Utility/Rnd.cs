using System;

namespace CaveDwellers.Utility
{
    public class Rnd : IRnd
    {
        private readonly Random _random = new Random();

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }
}