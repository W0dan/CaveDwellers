using System;

namespace CaveDwellers.Core
{
    public class Rnd : IRnd
    {
        private readonly Random _random = new Random();

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }

    public interface IRnd
    {
        int Next(int maxValue);
    }
}